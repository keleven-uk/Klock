Public Class frmKlock

    '   Main Klock application.       K. Scott    November 2012
    '
    '   March 2013      V1.0.1 - added contacts tab              [build 14]
    '   June 2013       V1.0.2 - added user settings             [build 23]
    '   July 2013       V1.0.3 - added reminder & events tab     [build 30]
    '   October 2013    V1.0.4 - added memo tab                  [build 37]
    '   November 2013   V1.0.5 - added Double Agent              [build 44] :: parked for now
    '   July 2014       V1.0.6 - added Text Klock                [build 46] :: copied from V1.0.4
    '   July 2015       V1.1.0 - Moved to VS2013 & GitHub        no build numbers now.


    Public startTime As Integer

    Public displayOneTime As selectTime         '   instance of selectTime, allows different time formats.
    Public displayTwoTime As selectTime         '   instance of selectTime, allows different time formats.
    Public displayTimer As Timer                '   instance of timer, a wrapper of the stopwatch class.
    Public displayAction As selectAction        '   instance of selectAction, allows different actions to be performed.
    Public usrSettings As UserSettings          '   instance of user settings.
    Public usrVoice As Voice                    '   instance of user voice
    Public usrFonts As UserFonts                '   instance of user fonts.
    Public myManagedPower As ManagedPower       '   instance of managed Power

    Public CountDownTime As Integer             '   Holds number of minutes for the countdown timer.
    Public ReminderDateTime As DateTime         '   Holds the date [and time] of the set reminder.

    Public F_ADDING As Boolean = False          '   Will be true if adding an friend, false if editing.
    Public E_ADDING As Boolean = False          '   Will be true if adding an event, false if editing.
    Public M_ADDING As Boolean = False          '   Will be true if adding an memo, false if editing.
    Public M_SHOW As Boolean = False            '   Will be true if displaying a secret memo test.

    Public reloadFriends As Boolean = True      '   if true, friends file will be re-loaded
    Public reloadEvents As Boolean = True       '   if true, events file will be re-loaded.
    Public reloadMemo As Boolean = True         '   if true, memo file will be re-loaded.

    Public strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "klock.chm") '   set up help location

    Public grphcs As Graphics = Me.CreateGraphics   '   create graphic object globally, used to measure time text width
    Public hours() As String = {"twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}    '   create global, not every time.

    Public knownFirstNames As New AutoCompleteStringCollection      '   Auto Complete for friends first name.
    Public knownMiddleNames As New AutoCompleteStringCollection     '   Auto Complete for friends middle name.
    Public knownLastnames As New AutoCompleteStringCollection       '   Auto Complete for friends last name.
    Public knownAddress1 As New AutoCompleteStringCollection        '   Auto Complete for friends address line 1.
    Public knownAddress2 As New AutoCompleteStringCollection        '   Auto Complete for friends address line 2.
    Public knownCities As New AutoCompleteStringCollection          '   Auto Complete for friends address city.
    Public knownPostCode As New AutoCompleteStringCollection        '   Auto Complete for friends address post code.
    Public knownCounties As New AutoCompleteStringCollection        '   Auto Complete for friends address county.

    ' ************************************************************************************** clock routines **************************
    ' Separate clocks are used for each function, to reduce load on main clock

    Private Sub TmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMain.Tick
        '   Main clock tick.
        '   Sets current time & date to the status bar.
        '   Checks for Caps Lock, Num Lock & Scroll Lock - set message in status bar.

        Dim currentSecond As Integer = Now.TimeOfDay.TotalSeconds                       '  so, all use the same time.
        Dim tmStr As String = ""

        If Me.Visible Then                                                              '   Only update if form is visible, can't see if in system tray.
            Me.updateStatusBar()
            Me.updateTitleText()

            If Me.TbCntrl.SelectedIndex = 0 Then

                Me.displayOneTime.set24Hour = Me.usrSettings.usrTimeOne24Hour
                tmStr = Me.displayOneTime.getTime()

                Me.LblTimeOneTime.Font = Me.usrFonts.getFont(tmStr, Me.displayOneTime.getTitle, grphcs)
                Me.LblTimeOneTime.Text = tmStr             '   Update local time in desired time format.

                If Me.usrSettings.usrTimeTwoFormats Then

                    Me.displayTwoTime.set24Hour = Me.usrSettings.usrTimeTwo24Hour
                    tmStr = Me.displayTwoTime.getTime()

                    Me.LblTimeTwoTime.Font = Me.usrFonts.getFont(tmStr, Me.displayTwoTime.getTitle, grphcs)
                    Me.LblTimeTwoTime.Text = tmStr              '   display local time in desired time format.

                End If      '   If Me.usrSettings.usrTimeTwoFormats Then
            ElseIf Me.TbCntrl.SelectedIndex = 1 Then
                Me.updateWorldKlock() '   Update World Klock.
            End If          '   If Me.TbCntrl.SelectedIndex = 0 [or 1] Then
        Else                '   else If Me.Visible Then
            Me.NotificationDispaly(currentSecond)                                       '   display a notification, if desired
        End If          '   If Me.Visible Then

        Me.playHourlyChimes(currentSecond)                                              '   Play a hourly chime,  if desired.
        Me.Notificationspeech(currentSecond)                                            '   Speak time, if desired.
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns"

        '                                               if running on battery, change status info colour to red as a warning.
        If Me.myManagedPower.powerSource().Contains("AC") Then
            Me.stsLblTime.ForeColor = Color.Black
            Me.StsLblDate.ForeColor = Color.Black
            Me.StsLblKeys.ForeColor = Color.Black
        Else
            Me.stsLblTime.ForeColor = Color.Red
            Me.StsLblDate.ForeColor = Color.Red
            Me.StsLblKeys.ForeColor = Color.Red
        End If

        If My.Computer.Keyboard.CapsLock.ToString() Then strKey = Replace(strKey, "c", "C")
        If My.Computer.Keyboard.NumLock.ToString() Then strKey = Replace(strKey, "n", "N")
        If My.Computer.Keyboard.ScrollLock.ToString() Then strKey = Replace(strKey, "s", "S")

        If Me.usrSettings.usrTimeSystem24Hour Then
            Me.stsLblTime.Text = String.Format("{0:HH:mm:ss}", System.DateTime.Now)
        Else
            Me.stsLblTime.Text = String.Format("{0:hh:mm:ss tt}", System.DateTime.Now)
        End If

        '   Me.stsLblTime.Text = Format(Now, "Long Time")
        Me.StsLblDate.Text = Format(Now, "Long Date")
        Me.StsLblKeys.Text = strKey

        '   Works out idle time, but only if needed

        If Me.usrSettings.usrTimeIdleTime Then
            Me.stsLbIdkeTime.Visible = True
            Me.stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            Me.stsLbIdkeTime.Visible = False
        End If
    End Sub

    Private Sub updateTitleText()
        '   Updates application title.

        Me.setTitleText()

        Dim titletext As String = Me.Text

        If Me.usrSettings.usrTimerAdd And Me.tmrTimer.Enabled Then          '   time is running
            If Me.usrSettings.usrTimerHigh Then                             '   are we displaying milliseconds in timer.
                titletext = titletext & " .::. " & displayTimer.getHighElapsedTime() & " : "
            Else
                titletext = titletext & " .::. " & displayTimer.getLowElapsedTime() & " : "
            End If
        End If

        If Me.usrSettings.usrCountdownAdd And Me.tmrCountDown.Enabled Then '   countdown is running.
            titletext = titletext & " .::. " & Me.minsToString(Me.CountDownTime)
        End If

        If Me.usrSettings.usrReminderAdd And Me.tmrReminder.Enabled Then
            If Me.usrSettings.usrReminderTimeChecked Then
                titletext = titletext & " .::. Reminder set for " & Me.ReminderDateTime.ToLongDateString & " @ " & Me.ReminderDateTime.ToLongTimeString
            Else
                titletext = titletext & " .::. Reminder set for " & Me.ReminderDateTime.ToLongDateString
            End If
        End If

        Me.Text = titletext
    End Sub

    Private Sub playHourlyChimes(ByVal m As Integer)
        '   Depending upon user settings, will play hourly pips or chimes.
        '   The chimes can sound on the hour and every quarter hour if desired.

        If Me.usrSettings.usrTimeHourPips And (Math.Floor(m Mod 3600) = 0) Then                                 '    will this work at midnight???

            Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\thepips.mp3"))  '    Play the Pips on the hour, if desired.
        ElseIf Me.usrSettings.usrTimeHourChimes And (Math.Floor(m Mod 3600) = 0) Then                           '    Play hourly chimes, if desired.

            Dim hour As Integer = Now.Hour

            If hour > 12 Then hour -= 12

            Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\" & hours(hour) & ".mp3"))
        ElseIf Me.usrSettings.usrTimeQuarterChimes And (Math.Floor(m Mod 900) = 0) Then            '    Play quarter chimes, if desired.

            Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\quarterchime.mp3"))
        ElseIf Me.usrSettings.usrTimeHalfChimes And (Math.Floor(m Mod 1800) = 0) Then              '    Play half hourly chimes, if desired.

            Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\halfchime.mp3"))
        ElseIf Me.usrSettings.usrTimeQuarterChimes And (Math.Floor(m Mod 2700) = 0) Then      '    Play three quarter chimes, if desired.

            Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\threequarterchime.mp3"))
        End If
    End Sub

    Private Sub Notificationspeech(ByVal m As Integer)
        '   if desired, check the status of speak time - should speak time every ?? minutes.

        Dim noSecs As Integer = Me.usrSettings.usrTimeVoiceMinutes * 60

        If Me.usrSettings.usrTimeVoiceMinimised And (Math.Floor(m Mod noSecs) = 0) Then usrVoice.Say(displayOneTime.getTime())
    End Sub

    Private Sub NotificationDispaly(ByVal m As Integer)
        '   If desired, check the status of notifications - should display the time every ?? minutes.
        '   Also, display result to time and countdown, if there running.  TO DO, should they be on their own settings?

        Me.displayOneTime.set24Hour = Me.usrSettings.usrTimeOne24Hour
        Try
            Me.NtfyIcnKlock.Text = Me.displayOneTime.getTitle & " : " & Me.displayOneTime.getTime()    '   set icon tool tip to current time [must be less then 64 chars].
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Notification Error", ex.Message)
        End Try

        Dim noSecs As Integer = Me.usrSettings.usrTimeDisplayMinutes * 60

        If Me.usrSettings.usrTimeDisplayMinimised And (Math.Floor(m Mod noSecs) = 0) Then

            Me.displayAction.DisplayReminder("Time", displayOneTime.getTime()) ' display current time as a toast notification,if desired

            If Me.usrSettings.usrTimerAdd And Me.tmrTimer.Enabled Then     ' time is running
                If Me.usrSettings.usrTimerHigh Then                            '   are we displaying milliseconds in timer.
                    Me.displayAction.DisplayReminder("Timer", "Timer Running :: " & displayTimer.getHighElapsedTime())
                Else
                    Me.displayAction.DisplayReminder("Timer", "Timer Running :: " & displayTimer.getLowElapsedTime())
                End If
            End If

            If Me.usrSettings.usrCountdownAdd And Me.tmrCountDown.Enabled Then '   countdown is running.
                Me.displayAction.DisplayReminder("Countdown", "Countdown Running :: " & Me.minsToString(Me.CountDownTime))
            End If

            If Me.usrSettings.usrReminderAdd And Me.tmrReminder.Enabled Then
                If Me.usrSettings.usrReminderTimeChecked Then
                    Me.displayAction.DisplayReminder("Reminder", "Reminder set for " & Me.ReminderDateTime.ToLongDateString & " @ " & Me.ReminderDateTime.ToLongTimeString)
                Else
                    Me.displayAction.DisplayReminder("Reminder", "Reminder set for " & Me.ReminderDateTime.ToLongDateString)
                End If
            End If

            If Me.usrSettings.usrWorldKlockAdd Then

                Dim wctext As String

                If RdBtnWorldClockTimeZoneLongName.Checked Then
                    Dim TzInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Me.CmbBxWorldKlockTimeZones.SelectedItem.id)
                    wctext = TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongDateString & " :: " & TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongTimeString
                Else
                    wctext = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, Me.CmbBxWorldKlockTimeZones.SelectedItem).ToLongDateString & " :: " & TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, Me.CmbBxWorldKlockTimeZones.SelectedItem).ToLongTimeString
                End If

                Me.displayAction.DisplayReminder("World Klock :: " & Me.CmbBxWorldKlockTimeZones.SelectedItem.ToString, wctext)
            End If

        End If          '   If Me.usrsettings.usrTimeDislayMinimised
    End Sub

    ' *************************************************************************************************************** Timer clock ***********************
    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        '   If enabled, timer is running - update timer label

        Me.lblTimerTime.Text = If(Me.usrSettings.usrTimerHigh, displayTimer.getHighElapsedTime(), displayTimer.getLowElapsedTime())
    End Sub

    ' ******************************************************************************************************************* Countdown clock ****************
    Private Sub tmrCountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountDown.Tick
        '   If enabled, countdown is running - clock ticks every second.

        Me.CountDownTime -= 1                                           '   decrement countdown every second.
        Me.lblCountDownTime.Text = Me.minsToString(Me.CountDownTime)    '   update countdown label.

        If Me.CountDownTime = 0 Then                                    '   countdown has finished.
            Me.CountDownAction()                                        '   perform action.
            Me.CountDownClear()                                         '   clear down countdown.
        End If
    End Sub

    ' ******************************************************************************************************************* Reminder clock ******************

    Private Sub tmrReminder_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReminder.Tick
        '   If enabled, a reminder has been set.

        If Now() > Me.ReminderDateTime Then
            Me.ReminderAction()
            Me.clearReminder()                                             '   clear down reminder tab after action.
        End If
    End Sub

    ' ******************************************************************************************************************* Event clock ******************

    Private Sub tmrEvents_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEvents.Tick
        '   if enabled, there is events that need checking.
        '   The timer fires every minute, the sub keeps score of the minutes.
        '   If the number of minutes exceeds the stores value, the events are checked.

        Static noOfMinutes As Integer = 0

        noOfMinutes += 1

        If noOfMinutes > Me.usrSettings.usrEventsTimerInterval Then
            noOfMinutes = 0
            Me.checkEvents()
        End If
    End Sub

    '   *************************************************************************************** Global Tab Change ****************************************

    Private Sub TbCntrl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCntrl.SelectedIndexChanged
        '    Performed when ever the main tab is changed, used for any tab initialisation.

        Select Case Me.TbCntrl.SelectedIndex
            Case 0                                              '   time tab
                FEMcommon.ButtonsVisible(False)
            Case 1                                              '   World Klock
                FEMcommon.ButtonsVisible(False)
                Me.updateWorldKlock()
            Case 2                                              '   countdown tab
                FEMcommon.ButtonsVisible(False)
            Case 3                                              '   timer tab
                FEMcommon.ButtonsVisible(False)
            Case 4                                              '   reminder tab
                FEMcommon.ButtonsVisible(False)

                If Me.usrSettings.usrReminderTimeChecked Then
                    Me.TmPckrRiminder.Enabled = True
                    Me.TmPckrRiminder.Value = Now()
                Else
                    Me.TmPckrRiminder.Enabled = False
                    Me.TmPckrRiminder.Value = Today
                End If
            Case 5                                              '   friends tab
                FEMcommon.ButtonsVisible(True)

                If Me.reloadFriends Then
                    IOcommon.loadFriends()
                    Me.blankFriendsDate()
                    Me.LoadAutoCompleteStuff()
                    Me.reloadFriends = False                    ' do not reload, if not necessary
                End If

                If Me.LstBxFriends.Items.Count > 0 Then
                    Me.btnDelete.Enabled = True
                    Me.btnEdit.Enabled = True
                    Me.showFriends(0)
                End If
            Case 6                                              '   Events tab
                FEMcommon.ButtonsVisible(True)

                If Me.reloadEvents Then
                    IOcommon.loadEvents()
                    Me.reloadEvents = False
                End If

                If Me.LstBxEvents.Items.Count > 0 Then
                    Me.btnDelete.Enabled = True
                    Me.btnEdit.Enabled = True
                    Me.showEvents(0)
                End If
            Case 7                                              '   Memo tab
                FEMcommon.ButtonsVisible(True)

                If Me.reloadMemo Then
                    IOcommon.loadMemo()
                    Me.reloadMemo = False
                End If

                If Me.LstBxMemo.Items.Count > 0 Then
                    Me.btnDelete.Enabled = True
                    Me.btnEdit.Enabled = True
                    Me.showMemo(0)
                End If
        End Select

        Me.setTitleText()
    End Sub

    Private Sub setTitleText()
        Select Case Me.TbCntrl.SelectedIndex
            Case 0                                              '   time tab
                Me.Text = "Klock - Tells you the time :: " & Me.displayOneTime.getTitle()
            Case 1                                              '   world klock tab
                Me.Text = "Klock - Tells you the time around the World"
            Case 2                                              '   countdown tab
                Me.Text = "Klock - Countdowns the time"
            Case 3                                              '   timer tab
                Me.Text = "Klock - Measures the time"
            Case 4                                              '   reminder tab
                Me.Text = "Klock - Reminds you of the time"
            Case 5                                              '   friends tab
                Me.Text = "Klock - Reminds you of your friends"
            Case 6                                              '   events tab
                Me.Text = "Klock - Reminds you of important events."
            Case 7                                              '   Memo tab
                Me.Text = "Klock - Reminds you of Memoranda."
        End Select
    End Sub

    '   ************************************************************************************************** time ****************************************

    Sub setTimeTypes()
        '   Loads the different time format types and load into combo box.

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        Me.CmbBxTimeOne.Items.AddRange(names)
        Me.CmbBxTimeTwo.Items.AddRange(names)
        frmOptions.CmbBxDefaultTimeFormat.Items.AddRange(names)
        frmOptions.CmbBxDefaultTimeTwoFormat.Items.AddRange(names)

        Me.CmbBxTimeOne.SelectedIndex = Me.usrSettings.usrTimeDefaultFormat
        Me.CmbBxTimeTwo.SelectedIndex = Me.usrSettings.usrTimeTWODefaultFormat
        frmOptions.CmbBxDefaultTimeFormat.SelectedIndex = Me.usrSettings.usrTimeDefaultFormat
        frmOptions.CmbBxDefaultTimeTwoFormat.SelectedIndex = Me.usrSettings.usrTimeTWODefaultFormat
    End Sub

    'TODO :: following two subs should be combined
    Private Sub CmbBxTimeOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxTimeOne.SelectedIndexChanged
        '   Inform displayTime of the chosen time format.

        Me.displayOneTime.setType = CmbBxTimeOne.SelectedIndex
    End Sub

    Private Sub CmbBxTimeTwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxTimeTwo.SelectedIndexChanged
        '   Inform displayTime of the chosen time format.

        Me.displayTwoTime.setType = CmbBxTimeTwo.SelectedIndex
    End Sub
    '   ************************************************************************************************** timer ***************************************

    Private Sub btnTimerStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStart.Click
        '   Start the timer

        Me.displayTimer.startStopWatch()

        Me.tmrTimer.Enabled = True

        Me.btnTimerStop.Enabled = True
        Me.btnTimerSplit.Enabled = True
        Me.btnTimerStart.Enabled = False
        Me.btnTimerClear.Enabled = False
    End Sub

    Private Sub btnTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStop.Click
        '   Stop the timer, allows to be resumed by renaming the start button.

        Me.displayTimer.stopStopWatch()

        Me.tmrTimer.Enabled = False

        Me.btnTimerStop.Enabled = False
        Me.btnTimerClear.Enabled = True

        Me.btnTimerStart.Text = "Resume"
        Me.btnTimerStart.Enabled = True
    End Sub

    Private Sub btnTimerClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerClear.Click
        '   Clears down the countdown, if enables also clear split time.

        Me.displayTimer.clearStopWatch()

        Me.btnTimerClear.Enabled = False
        Me.btnTimerSplit.Enabled = False

        Me.btnTimerStart.Text = "Start"
        Me.btnTimerStart.Enabled = True

        If Me.usrSettings.usrTimerClearSplit Then
            If Me.usrSettings.usrTimerHigh Then
                Me.lblTimerTime.Text = "00:00:00:00"
                Me.lblTimerSplit.Text = "00:00:00:00"
            Else
                Me.lblTimerTime.Text = "00:00:00"
                Me.lblTimerSplit.Text = "00:00:00"
            End If
            Me.btnTimerSplitClear.Enabled = False
        Else
            Me.lblTimerTime.Text = If(Me.usrSettings.usrTimerHigh, "00:00:00:00", "00:00:00")
        End If
    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplit.Click
        '   Copies time to split time.

        Me.lblTimerSplit.Text = Me.lblTimerTime.Text

        Me.btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplitClear.Click
        '   Clears the split time.

        Me.lblTimerSplit.Text = If(Me.usrSettings.usrTimerHigh, "00:00:00:00", "00:00:00")

        Me.btnTimerSplitClear.Enabled = False
    End Sub

    ' ************************************************************************************************************ Countdown ******************************
    Private Sub upDwnCntDownValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upDwnCntDownValue.ValueChanged
        '   When the up down counter has been changed, enable the start button and update the countdown label.

        Me.btnCountDownStart.Enabled = If(Me.upDwnCntDownValue.Value = 0, False, True)

        Me.CountDownTime = Me.upDwnCntDownValue.Value * 60
        Me.lblCountDownTime.Text = Me.minsToString(CountDownTime)
    End Sub

    Private Sub btnCountDownStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownStart.Click
        '   Start the countdown by enabling the timer.
        '   Also, enable the stop button and countdown label and switch off quick start buttons..

        Me.tmrCountDown.Enabled = True

        Me.btnCountDownStart.Enabled = False
        Me.btnCountDownStop.Enabled = True
        Me.upDwnCntDownValue.Enabled = False
        Me.lblCountDownTime.Enabled = True
        Me.QuickStartButtons(False)
    End Sub

    Private Sub btnCountDownStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownStop.Click
        '   Clear the countdown.

        Me.CountDownClear()
    End Sub

    Private Sub btnCountdown30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdown30.Click
        '   runs the countdown for 30 minutes form the quick start button.

        Me.CountDownTime = 30 * 60                                  '   30 minutes in seconds.
        Me.lblCountDownTime.Text = Me.minsToString(CountDownTime)
        Me.btnCountDownStart_Click(sender, e)                       '   call click sub to start countdown.
    End Sub

    Private Sub btnCountdown60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdown60.Click
        '   runs the countdown for 60 minutes form the quick start button.

        Me.CountDownTime = 60 * 60                                  '   60 minutes in seconds.
        Me.lblCountDownTime.Text = Me.minsToString(CountDownTime)
        Me.btnCountDownStart_Click(sender, e)                       '   call click sub to start countdown.
    End Sub

    Private Sub btnCountdown90_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdown90.Click
        '   runs the countdown for 90 minutes form the quick start button.

        Me.CountDownTime = 90 * 60                                  '   90 minutes in seconds.
        Me.lblCountDownTime.Text = Me.minsToString(CountDownTime)
        Me.btnCountDownStart_Click(sender, e)                       '   call click sub to start countdown.
    End Sub

    Private Sub QuickStartButtons(ByVal b As Boolean)
        '   toggles the quick start buttons on/off.

        btnCountdown30.Enabled = b
        btnCountdown60.Enabled = b
        btnCountdown90.Enabled = b
    End Sub

    Private Sub CmbBxCountDownAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxCountDownAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate  action controls.

        Select Case Me.CmbBxCountDownAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                Me.CountDownSound(True)
                Me.CountDownReminder(False)
                Me.CountDownSystem(False)
                Me.CountDownCommand(False)
                Me.CountdownSpeech(False)
                Me.CountdownScreenSaver(False)
            Case 1                                                  '   Reminder chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(True)
                Me.CountDownSystem(False)
                Me.CountDownCommand(False)
                Me.CountdownSpeech(False)
                Me.CountdownScreenSaver(False)
            Case 2                                                  '   System action chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(False)
                Me.CountDownSystem(True)
                Me.CountDownCommand(False)
                Me.CountdownSpeech(False)
                Me.CountdownScreenSaver(False)
            Case 3                                                  '   Run Command chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(False)
                Me.CountDownSystem(False)
                Me.CountDownCommand(True)
                Me.CountdownSpeech(False)
                Me.CountdownScreenSaver(False)
            Case 4                                                  '   Speak chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(False)
                Me.CountDownSystem(False)
                Me.CountDownCommand(False)
                Me.CountdownSpeech(True)
                Me.CountdownScreenSaver(False)
            Case 5                                                  '   Screen Saver chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(False)
                Me.CountDownSystem(False)
                Me.CountDownCommand(False)
                Me.CountdownSpeech(False)
                Me.CountdownScreenSaver(True)
        End Select
    End Sub


    Private Sub ChckBxCountDownSound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownSound.CheckedChanged
        '   Selects sound action controls if checked.
        '   NB :: every time the checkbox changes, this toggles the state of the enables flag.

        Me.TxtBxCountDownAction.Enabled = Not Me.TxtBxCountDownAction.Enabled
        Me.btnCountdownLoadSound.Enabled = Not Me.btnCountdownLoadSound.Enabled
        Me.btnCountDownTestSound.Enabled = Not Me.btnCountDownTestSound.Enabled
    End Sub

    Private Sub ChckBxCountDownReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownReminder.CheckedChanged
        '   Selects reminder action controls if checked.

        Me.TxtBxCountDownReminder.Enabled = Not Me.TxtBxCountDownReminder.Enabled
    End Sub

    Private Sub ChckBxCountDownSystem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownSystem.CheckedChanged
        '   Selects countdown action controls if checked.

        Me.CmbBxCountDownSystem.Enabled = Not Me.CmbBxCountDownSystem.Enabled
    End Sub

    Private Sub ChckBxCountDownCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownCommand.CheckedChanged
        '   Selects run command action controls if checked.

        Me.TxtBxCountDowndCommand.Enabled = Not Me.TxtBxCountDowndCommand.Enabled
        Me.btnCountDownLoadCommand.Enabled = Not Me.btnCountDownLoadCommand.Enabled
    End Sub

    Private Sub ChckBxCountdownspeech_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountdownSpeech.CheckedChanged
        '   Selects speech action controls if desired.

        Me.TxtBxCountdownSpeech.Enabled = Not Me.TxtBxCountdownSpeech.Enabled
    End Sub

    Private Sub btnCountDownTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownTestSound.Click
        '   Play sound in test button is pressed.

        Me.displayAction.PlaySound(TxtBxCountDownAction.Text)
    End Sub

    Private Sub btnCountdownLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdownLoadSound.Click
        '   Open file dialog to load sound file.

        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Sound Files|*.wav; *.mp3"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.btnCountDownTestSound.Enabled = True
            Me.TxtBxCountDownAction.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnCountDownLoadCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownLoadCommand.Click
        '   Open file dialog to load command file.

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxCountDowndCommand.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Sub CountDownAction()
        '   When Countdown is finished, perform desired action
        '   Setting the checked to false fires the checkedChange sub, which turns off the appropriate controls.

        If Me.ChckBxCountDownSound.Checked Then                                '   do sound action.
            Me.ChckBxCountDownSound.Checked = False
            Me.displayAction.PlaySound(TxtBxCountDownAction.Text)
        End If
        If Me.ChckBxCountDownReminder.Checked Then                             '   do reminder action.
            Me.ChckBxCountDownReminder.Checked = False
            Me.displayAction.DisplayReminder("CountDown", TxtBxCountDownReminder.Text)
        End If
        If Me.ChckBxCountDownSystem.Checked Then                               '   do system action action.
            If Me.NtfyIcnKlock.Visible Then                                    '   if main form not visible, then show
                Me.NtfyIcnKlock.Visible = False                                '   so abort button can be deployed.
                Me.Visible = True
            End If
            Me.ChckBxCountDownSystem.Checked = False
            Me.btnCountdownSystemAbort.Enabled = True                          '   Allows system command to be aborted.
            Me.displayAction.DoSystemCommand(CmbBxCountDownSystem.SelectedIndex)
        End If
        If Me.ChckBxCountDownCommand.Checked Then                              '   do run command action.
            Me.ChckBxCountDownCommand.Checked = False
            Me.displayAction.DoCommand(TxtBxCountDowndCommand.Text)
        End If
        If Me.ChckBxCountdownSpeech.Checked Then                               '   do speech action.
            Me.ChckBxCountdownSpeech.Checked = False
            usrVoice.Say(Me.TxtBxCountdownSpeech.Text)
        End If
        If Me.ChckBxCountdownScreenSaver.CheckAlign Then                       '   call screen saver
            Me.ChckBxCountdownScreenSaver.Checked = False
            Me.displayAction.ScreenSaver()
        End If
    End Sub

    Private Sub btnCountdownSystemAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdownSystemAbort.Click
        '   If abort pressed,  perform system command abort and start clean up.

        Me.displayAction.AbortSystemCommand()
        Me.btnCountdownSystemAbort.Enabled = False

        Me.CountDownClear()
    End Sub

    Sub CountDownClear()
        '   Clear down Countdown.

        Me.ChckBxCountDownSound.Checked = False
        Me.ChckBxCountDownReminder.Checked = False
        Me.ChckBxCountDownSystem.Checked = False
        Me.ChckBxCountDownCommand.Checked = False

        Me.tmrCountDown.Enabled = False
        Me.lblCountDownTime.Text = "00:00"
        Me.lblCountDownTime.Enabled = False
        Me.upDwnCntDownValue.Enabled = True
        Me.upDwnCntDownValue.Value = 0

        Me.btnCountDownStart.Enabled = False
        Me.btnCountDownStop.Enabled = False

        Me.QuickStartButtons(True)
    End Sub

    Function minsToString(ByVal m As Integer) As String
        '   Reformat number of seconds in string in minutes and seconds [mm:ss].

        Dim hours As Integer
        Dim mins As Integer

        hours = m \ 60
        mins = m - (hours * 60)

        Return String.Format("{0:00}:{1:00}", hours, mins)
    End Function

    Sub CountDownSound(ByVal b As Boolean)
        '   Sets visible to b for all sound components

        Me.ChckBxCountDownSound.Visible = b
        Me.TxtBxCountDownAction.Visible = b
        Me.btnCountdownLoadSound.Visible = b
        Me.btnCountDownTestSound.Visible = b
    End Sub

    Sub CountDownReminder(ByVal b As Boolean)
        '   Sets visible to b for all reminder components

        Me.ChckBxCountDownReminder.Visible = b
        Me.TxtBxCountDownReminder.Visible = b
    End Sub

    Sub CountDownSystem(ByVal b As Boolean)
        '   Sets visible to b for all system components

        Me.ChckBxCountDownSystem.Visible = b
        Me.CmbBxCountDownSystem.Visible = b
        Me.btnCountdownSystemAbort.Visible = b
    End Sub

    Sub CountDownCommand(ByVal b As Boolean)
        '   Sets visible to b for all command components

        Me.ChckBxCountDownCommand.Visible = b
        Me.TxtBxCountDowndCommand.Visible = b
        Me.btnCountDownLoadCommand.Visible = b
    End Sub

    Sub CountdownSpeech(ByVal b As Boolean)
        '   sets visible to b for all speech components

        Me.ChckBxCountdownSpeech.Visible = b
        Me.TxtBxCountdownSpeech.Visible = b
    End Sub

    Sub CountdownScreenSaver(ByVal b As Boolean)
        '   set visible to b for all screen saver components

        Me.ChckBxCountdownScreenSaver.Visible = b
    End Sub
    ' **************************************************************************************************** Reminder ****************************************

    Private Sub CmbBxReminderAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxReminderAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate action controls.

        Select Case Me.CmbBxReminderAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                Me.ReminderSound(True)
                Me.ReminderReminder(False)
                Me.ReminderSystem(False)
                Me.ReminderCommand(False)
                Me.ReminderSpeech(False)
                Me.ReminderScreenSaver(False)
            Case 1                                                  '   Reminder chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(True)
                Me.ReminderSystem(False)
                Me.ReminderCommand(False)
                Me.ReminderSpeech(False)
                Me.ReminderScreenSaver(False)
            Case 2                                                  '   System action chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(False)
                Me.ReminderSystem(True)
                Me.ReminderCommand(False)
                Me.ReminderSpeech(False)
                Me.ReminderScreenSaver(False)
            Case 3                                                  '   Run Command chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(False)
                Me.ReminderSystem(False)
                Me.ReminderCommand(True)
                Me.ReminderSpeech(False)
                Me.ReminderScreenSaver(False)
            Case 4                                                  '   speech chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(False)
                Me.ReminderSystem(False)
                Me.ReminderCommand(False)
                Me.ReminderSpeech(True)
                Me.ReminderScreenSaver(False)
            Case 5                                                  '   Screen Saver chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(False)
                Me.ReminderSystem(False)
                Me.ReminderCommand(False)
                Me.ReminderSpeech(False)
                Me.ReminderScreenSaver(True)
        End Select
    End Sub


    Private Sub ChckBxReminderSound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderSound.CheckedChanged
        '   Selects sound action controls if checked.
        '   NB :: every time the checkbox changes, this toggles the state of the enables flag.

        Me.TxtBxReminderAction.Enabled = Not Me.TxtBxReminderAction.Enabled
        Me.btnReminderLoadSound.Enabled = Not Me.btnReminderLoadSound.Enabled
        Me.btnReminderTestSound.Enabled = Not Me.btnReminderTestSound.Enabled
    End Sub

    Private Sub ChckBxReminderReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderReminder.CheckedChanged
        '   Selects reminder action controls if checked.

        Me.TxtBxReminderReminder.Enabled = Not Me.TxtBxReminderReminder.Enabled
    End Sub

    Private Sub ChckBxReminderSystem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderSystem.CheckedChanged
        '   Selects countdown action controls if checked.

        Me.CmbBxReminderSystem.Enabled = Not Me.CmbBxReminderSystem.Enabled
    End Sub

    Private Sub chckBXReminderCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBXReminderCommand.CheckedChanged
        '   Selects run command action controls if checked.

        Me.TxtBxReminderCommand.Enabled = Not Me.TxtBxReminderCommand.Enabled
        Me.btnReminderLoadCommand.Enabled = Not Me.btnReminderLoadCommand.Enabled
    End Sub

    Private Sub ChckBxReminderSpeech_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderSpeech.CheckedChanged
        '   Selects speech command action controls if checked.

        Me.TxtBxReminderSpeech.Enabled = Not Me.TxtBxCountdownSpeech.Enabled
    End Sub

    Private Sub btnReminderTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderTestSound.Click
        ' Play sound in test button is pressed.

        Me.displayAction.PlaySound(TxtBxReminderAction.Text)
    End Sub

    Private Sub btnReminderLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderLoadSound.Click
        ' Open file dialog to load sound file.

        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Sound Files|*.wav; *.mp3"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.btnReminderTestSound.Enabled = True
            Me.TxtBxReminderAction.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReminderLoadCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderLoadCommand.Click
        ' Open file dialog to load command file.

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxReminderCommand.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Sub ReminderAction()
        '   When Reminder is finished, perform desired action
        '   Setting the checked to false fires the checkedChange sub, which turns off the appropriate controls.

        If Me.ChckBxReminderSound.Checked Then                                  '   do sound action.
            Me.ChckBxReminderSound.Checked = False
            Me.displayAction.PlaySound(TxtBxReminderAction.Text)
        End If
        If Me.ChckBxReminderReminder.Checked Then                               '   do reminder action.
            Me.ChckBxReminderReminder.Checked = False
            Me.displayAction.DisplayReminder("Reminder", TxtBxReminderReminder.Text)
        End If
        If Me.ChckBxReminderSystem.Checked Then                                 '   do system action action.
            If NtfyIcnKlock.Visible Then                                        '   if main form not visible, then show
                Me.NtfyIcnKlock.Visible = False                                 '   so abort button can be deployed.
                Me.Visible = True
            End If
            Me.ChckBxReminderSystem.Checked = False
            Me.btnReminderSystemAbort.Enabled = True                            '   Allows system command to be aborted.
            Me.displayAction.DoSystemCommand(CmbBxReminderSystem.SelectedIndex)
        End If
        If Me.chckBXReminderCommand.Checked Then                                '   do run command action.
            Me.chckBXReminderCommand.Checked = False
            Me.displayAction.DoCommand(TxtBxReminderCommand.Text)
        End If
        If Me.ChckBxReminderSpeech.Checked Then                                 '   do speech action.
            Me.ChckBxReminderSpeech.Checked = False
            Me.usrVoice.Say(Me.TxtBxReminderSpeech.Text)
        End If
        If Me.ChckBxReminderScreenSaver.Checked Then                           '   call screen saver.
            Me.ChckBxReminderScreenSaver.Checked = False
            Me.displayAction.ScreenSaver()
        End If
    End Sub

    Private Sub btnReminderSystemAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderSystemAbort.Click
        '   If abort pressed,  perform system command abort and start clean up.

        Me.displayAction.AbortSystemCommand()
        Me.btnReminderSystemAbort.Enabled = False

        Me.clearReminder()
    End Sub

    Private Sub btnReminderSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderSet.Click
        '   Set a new reminder.  Sets appropriate text and sets the global reminder date for checking.
        '   Also, enables the reminder timer, which checks if reminder is due every minute..

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year,
                         Me.DtPckrRiminder.Value.Month,
                         Me.DtPckrRiminder.Value.Day,
                         Me.TmPckrRiminder.Value.Hour,
                         Me.TmPckrRiminder.Value.Minute,
                         0)

        Me.tmrReminder.Enabled = True       '   start reminder timer.

        Me.btnReminderSet.Enabled = False
        Me.btnReminderClear.Enabled = True
        Me.DtPckrRiminder.Visible = False
        Me.ChckBxReminderTimeCheck.Visible = False
        Me.TmPckrRiminder.Visible = False

        If Me.usrSettings.usrReminderTimeChecked Then
            Me.lblReminderText.Text = "Reminder set for " & d.ToLongDateString & " @ " & d.ToShortTimeString
        Else
            Me.lblReminderText.Text = "Reminder set for " & d.ToLongDateString
        End If

        Me.ReminderDateTime = d            '   set global, so can be checked by reminder timer.
    End Sub

    Private Sub btnReminderClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderClear.Click
        '   Clear reminder is pressed.

        Me.clearReminder()
    End Sub

    Private Sub clearReminder()
        '   Perform the reminder clear.

        Me.ChckBxReminderSound.Checked = False
        Me.ChckBxReminderReminder.Checked = False
        Me.ChckBxReminderSystem.Checked = False
        Me.chckBXReminderCommand.Checked = False

        Me.DtPckrRiminder.Visible = True
        Me.ChckBxReminderTimeCheck.Visible = True
        Me.TmPckrRiminder.Visible = True

        Me.btnReminderClear.Enabled = False

        Me.tmrReminder.Enabled = False      '   stop reminder timer.

        Me.DtPckrRiminder.Value = Today

        If Me.usrSettings.usrReminderTimeChecked Then
            Me.ChckBxReminderTimeCheck.Checked = True
            Me.TmPckrRiminder.Enabled = True
            Me.TmPckrRiminder.Value = Now()
        Else
            Me.ChckBxReminderTimeCheck.Checked = False
            Me.TmPckrRiminder.Enabled = False
            Me.TmPckrRiminder.Value = Today
        End If

        Me.lblReminderText.Text = "Reminder Not set"
    End Sub

    Sub ReminderSound(ByVal b As Boolean)
        '   Sets visible to b for all sound components

        Me.ChckBxReminderSound.Visible = b
        Me.TxtBxReminderAction.Visible = b
        Me.btnReminderLoadSound.Visible = b
        Me.btnReminderTestSound.Visible = b
    End Sub

    Private Sub ReminderReminder(ByVal b As Boolean)
        '   Sets visible to b for all reminder components

        Me.ChckBxReminderReminder.Visible = b
        Me.TxtBxReminderReminder.Visible = b
    End Sub

    Private Sub ReminderSystem(ByVal b As Boolean)
        '   Sets visible to b for all system components

        Me.ChckBxReminderSystem.Visible = b
        Me.CmbBxReminderSystem.Visible = b
        Me.btnReminderSystemAbort.Visible = b
    End Sub

    Private Sub ReminderCommand(ByVal b As Boolean)
        '   Sets visible to b for all command components

        Me.chckBXReminderCommand.Visible = b
        Me.TxtBxReminderCommand.Visible = b
        Me.btnReminderLoadCommand.Visible = b
    End Sub

    Private Sub ReminderSpeech(ByVal b As Boolean)
        '   Sets visible to b for all command components

        Me.ChckBxReminderSpeech.Visible = b
        Me.TxtBxReminderSpeech.Visible = b
    End Sub

    Private Sub ReminderScreenSaver(ByVal b As Boolean)
        '   Sets visible to b for all screen saver components

        Me.ChckBxReminderScreenSaver.Visible = b
    End Sub

    Private Sub reminder_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckrRiminder.ValueChanged, TmPckrRiminder.ValueChanged
        '   Checks to see if the reminder date if in the future [> now()], only then enable the set button.

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year,
                         Me.DtPckrRiminder.Value.Month,
                         Me.DtPckrRiminder.Value.Day,
                         Me.TmPckrRiminder.Value.Hour,
                         Me.TmPckrRiminder.Value.Minute,
                         0)

        Me.btnReminderSet.Enabled = If(d > Now(), True, False)
    End Sub

    Private Sub ChckBxReminderTimeCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderTimeCheck.CheckedChanged
        '   Allows the reminder date to include a time component.

        If Me.ChckBxReminderTimeCheck.Checked Then
            Me.usrSettings.usrReminderTimeChecked = True
            Me.TmPckrRiminder.Enabled = True
            Me.TmPckrRiminder.Value = Now()
        Else
            Me.usrSettings.usrReminderTimeChecked = False
            Me.TmPckrRiminder.Enabled = False
            Me.TmPckrRiminder.Value = Today
        End If
    End Sub

    ' **************************************************************************************************** Friends ****************************************

    Private Sub FirstAndLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbxFriendsFirstName.TextChanged, txtbxFriendsLastName.TextChanged
        '   Only allow adding if first and last name exist.

        If Me.F_ADDING Then
            If Me.txtbxFriendsFirstName.Text <> "" And Me.txtbxFriendsLastName.Text <> "" Then
                Me.btnAdd.Enabled = True
            Else
                Me.btnAdd.Enabled = False
            End If
        End If
    End Sub

    Public Sub FriendsClearText()
        '   Clears all date entry fields.

        FEMcommon.PanelTop()

        Me.txtbxFriendsFirstName.Text = ""
        Me.txtbxFriendsMiddleName.Text = ""
        Me.txtbxFriendsLastName.Text = ""
        Me.txtbxFriendsEmail1.Text = ""
        Me.txtbxFriendsEmail2.Text = ""
        Me.txtbxFriendsEmail3.Text = ""
        Me.txtbxFriendsTelephone1.Text = ""
        Me.txtbxFriendsTelephone2.Text = ""
        Me.txtbxFriendsTelephone3.Text = ""
        Me.txtbxFriendsAddressNo.Text = ""
        Me.txtbxFriendsAddressLine1.Text = ""
        Me.txtbxFriendsAddressLine2.Text = ""
        Me.txtbxFriendsAddressCity.Text = ""
        Me.txtbxFriendsAddressPostCode.Text = ""
        Me.txtbxFriendsAddressCounty.Text = ""
        Me.txtbxFriendsHomePage.Text = ""
        Me.txtbxFriendsNotes.Text = ""

        Me.blankFriendsDate()
    End Sub

    Public Sub FriendsReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on the textboxes.
        '   True = can be input or edit.
        '   False = display only

        Me.txtbxFriendsFirstName.ReadOnly = b
        Me.txtbxFriendsMiddleName.ReadOnly = b
        Me.txtbxFriendsLastName.ReadOnly = b
        Me.txtbxFriendsEmail1.ReadOnly = b
        Me.txtbxFriendsEmail2.ReadOnly = b
        Me.txtbxFriendsEmail3.ReadOnly = b
        Me.txtbxFriendsTelephone1.ReadOnly = b
        Me.txtbxFriendsTelephone2.ReadOnly = b
        Me.txtbxFriendsTelephone3.ReadOnly = b
        Me.txtbxFriendsAddressNo.ReadOnly = b
        Me.txtbxFriendsAddressLine1.ReadOnly = b
        Me.txtbxFriendsAddressLine2.ReadOnly = b
        Me.txtbxFriendsAddressCity.ReadOnly = b
        Me.txtbxFriendsAddressPostCode.ReadOnly = b
        Me.txtbxFriendsAddressCounty.ReadOnly = b
        Me.txtbxFriendsHomePage.ReadOnly = b
        Me.txtbxFriendsNotes.ReadOnly = b

        Me.DtPckrFriendsDOB.Enabled = Not b
    End Sub

    Private Sub LstBxFriends_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstBxFriends.SelectedIndexChanged
        '   A new entry has been selected in the listview box, display new entry.

        Me.showFriends(Me.LstBxFriends.SelectedIndex)
    End Sub

    Public Sub showFriends(ByVal pos As Integer)
        '   Populates the text boxes on the form with the person at the specified position of the listview box.

        FEMcommon.PanelTop()

        If pos >= 0 Then
            Dim p As Person = CType(Me.LstBxFriends.Items.Item(pos), Person)

            Me.txtbxFriendsFirstName.Text = p.FirstName
            Me.txtbxFriendsMiddleName.Text = p.MiddleName
            Me.txtbxFriendsLastName.Text = p.LastName
            Me.txtbxFriendsEmail1.Text = p.EMail1
            Me.txtbxFriendsEmail2.Text = p.EMail2
            Me.txtbxFriendsEmail3.Text = p.EMail3
            Me.txtbxFriendsTelephone1.Text = p.TelNo1
            Me.txtbxFriendsTelephone2.Text = p.TelNo2
            Me.txtbxFriendsTelephone3.Text = p.TelNo3
            Me.txtbxFriendsAddressNo.Text = p.HouseNo
            Me.txtbxFriendsAddressLine1.Text = p.Address1
            Me.txtbxFriendsAddressLine2.Text = p.Address2
            Me.txtbxFriendsAddressCity.Text = p.City
            Me.txtbxFriendsAddressPostCode.Text = p.PostCode
            Me.txtbxFriendsAddressCounty.Text = p.County
            Me.txtbxFriendsHomePage.Text = p.WebPage
            Me.txtbxFriendsNotes.Text = p.Notes

            If p.DOB = " " Then
                Me.blankFriendsDate()
            Else
                Me.normalFriendsDate()
                Me.DtPckrFriendsDOB.Value = p.DOB
            End If

            Me.LstBxFriends.SelectedIndex = pos
        End If
    End Sub

    Public Sub populateFriend(ByVal mode As String)
        '   populates the person class with the corresponding data from the form.
        '   If adding, the person is added to the list view box, if not the current entry is updated.

        Dim p As New Person

        Try
            p.FirstName = Me.txtbxFriendsFirstName.Text
            p.MiddleName = Me.txtbxFriendsMiddleName.Text
            p.LastName = Me.txtbxFriendsLastName.Text
            p.EMail1 = Me.txtbxFriendsEmail1.Text
            p.EMail2 = Me.txtbxFriendsEmail2.Text
            p.EMail3 = Me.txtbxFriendsEmail3.Text
            p.TelNo1 = Me.txtbxFriendsTelephone1.Text
            p.TelNo2 = Me.txtbxFriendsTelephone2.Text
            p.TelNo3 = Me.txtbxFriendsTelephone3.Text
            p.HouseNo = Me.txtbxFriendsAddressNo.Text
            p.Address1 = Me.txtbxFriendsAddressLine1.Text
            p.Address2 = Me.txtbxFriendsAddressLine2.Text
            p.City = Me.txtbxFriendsAddressCity.Text
            p.PostCode = Me.txtbxFriendsAddressPostCode.Text
            p.County = Me.txtbxFriendsAddressCounty.Text
            p.Notes = Me.txtbxFriendsNotes.Text
            p.WebPage = Me.txtbxFriendsHomePage.Text

            If Me.DtPckrFriendsDOB.Format = DateTimePickerFormat.Long Then  ' if no date selected, save as an empty string i.e." ".
                p.DOB = Me.DtPckrFriendsDOB.Value.Date.ToString
            Else
                p.DOB = " "
            End If

            If mode = "ADD" Then
                Me.LstBxFriends.Items.Add(p)                                '   Populate listview.
                Me.FriendsAddToKnown(p)                                     '   Populate autocomplete collections.
            Else    '   mode = "EDIT"
                Me.LstBxFriends.Items(Me.LstBxFriends.SelectedIndex) = p    '   Update listview.
            End If

        Catch ex As Exception
            Me.displayAction.DisplayReminder("ERROR :: populating friend", ex.Message)
        End Try
    End Sub

    Private Sub LoadAutoCompleteStuff()
        '   Attach the relevant auto complete collections to the text boxes.

        Me.txtbxFriendsFirstName.AutoCompleteCustomSource = Me.knownFirstNames
        Me.txtbxFriendsFirstName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsFirstName.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsMiddleName.AutoCompleteCustomSource = Me.knownMiddleNames
        Me.txtbxFriendsMiddleName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsMiddleName.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsLastName.AutoCompleteCustomSource = Me.knownLastnames
        Me.txtbxFriendsLastName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsLastName.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsAddressLine1.AutoCompleteCustomSource = Me.knownAddress1
        Me.txtbxFriendsAddressLine1.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsAddressLine1.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsAddressLine2.AutoCompleteCustomSource = Me.knownAddress2
        Me.txtbxFriendsAddressLine2.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsAddressLine2.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsAddressCity.AutoCompleteCustomSource = Me.knownCities
        Me.txtbxFriendsAddressCity.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsAddressCity.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsAddressPostCode.AutoCompleteCustomSource = Me.knownPostCode
        Me.txtbxFriendsAddressPostCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsAddressPostCode.AutoCompleteMode = AutoCompleteMode.Append

        Me.txtbxFriendsAddressCounty.AutoCompleteCustomSource = Me.knownCounties
        Me.txtbxFriendsAddressCounty.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.txtbxFriendsAddressCounty.AutoCompleteMode = AutoCompleteMode.Append
    End Sub

    Private Sub DtPckrFriendsDOB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckrFriendsDOB.ValueChanged
        '   If the value of the date picker is altered, reset then date format back to long.

        Me.normalFriendsDate()
    End Sub

    Private Sub blankFriendsDate()
        '   To achieve a blank date in the date picker, a custom format has to be set to ""

        Me.DtPckrFriendsDOB.Format = DateTimePickerFormat.Custom
        Me.DtPckrFriendsDOB.CustomFormat = " "
        Me.DtPckrFriendsDOB.Checked = False
    End Sub

    Private Sub normalFriendsDate()
        '   To display a date in the date picker, the custom format has to be removed.

        Me.DtPckrFriendsDOB.Format = DateTimePickerFormat.Long
        Me.DtPckrFriendsDOB.CustomFormat = Now().Date
    End Sub

    Public Sub FriendsAddToKnown(ByVal p As Person)
        '   A number of collections are maintained for the auto complete.
        '   One array for each textbox.
        '   Each time a friend is added, the contents of the text box is added to the relevant collections.

        If Not Me.knownFirstNames.Contains(p.FirstName) Then Me.knownFirstNames.Add(p.FirstName)
        If Not Me.knownMiddleNames.Contains(p.MiddleName) Then Me.knownMiddleNames.Add(p.MiddleName)
        If Not Me.knownLastnames.Contains(p.LastName) Then Me.knownLastnames.Add(p.LastName)
        If Not Me.knownAddress1.Contains(p.Address1) Then Me.knownAddress1.Add(p.Address1)
        If Not Me.knownAddress2.Contains(p.Address2) Then Me.knownAddress2.Add(p.Address2)
        If Not Me.knownPostCode.Contains(p.PostCode) Then Me.knownPostCode.Add(p.PostCode)
        If Not Me.knownCities.Contains(p.City) Then Me.knownCities.Add(p.City)
        If Not Me.knownCounties.Contains(p.County) Then Me.knownCounties.Add(p.County)

    End Sub

    Private Sub txtbxFriendsAddressPostCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbxFriendsAddressPostCode.KeyPress
        '   Post code may only contain upper case letters and numbers.

        If Char.IsLetterOrDigit(e.KeyChar) Then

            If Char.IsLetter(e.KeyChar) Then
                Me.txtbxFriendsAddressPostCode.SelectedText = UCase(e.KeyChar)
            Else
                Me.txtbxFriendsAddressPostCode.SelectedText = e.KeyChar
            End If

            e.Handled = True

        End If
    End Sub

    Private Sub FriendsTelephone1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbxFriendsTelephone1.KeyPress, txtbxFriendsTelephone2.KeyPress, txtbxFriendsTelephone3.KeyPress
        '   Telephone numbers may only contain numbers.

        If Char.IsNumber(e.KeyChar) Then

        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else

        End If
    End Sub

    ' **************************************************************************************************** Friends & Events Buttons ***********************
    '   Combined the buttons for both friends and events - they share a lot of functionality.
    '   Moved the guts of each routing into a sperate module, trying to reduce clutter in main program file.

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        '   Sets up to add new friend / Event.

        FEMcommon.btnNew()
    End Sub

    Private Sub btnFriendsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        '   Adds a new friend / Event to listview box and saves a new friend / Event file.

        FEMcommon.btnAdd()
    End Sub

    Private Sub btnFriendsClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        '   Clears everything [not sure when called].

        FEMcommon.btnClear()
    End Sub

    Private Sub btnFriendsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        '   allows selected entry in listveiw box to be edited.
        '   Changed button to "Save", which then will save new data to selected entry and save new friend / Event file.

        FEMcommon.btnEdit()
    End Sub

    Private Sub btnFriendsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '   Deletes the currently selected entry form the listviewbox.
        '   Saves new friend / Event file and display first entry [if exists].

        FEMcommon.btnDelete()
    End Sub

    ' ********************************************************************************************************************************* Events ********

    Private Sub btnEventsCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventsCheck.Click
        '   force a check of the events.

        Me.checkEvents()
    End Sub


    Private Sub TxtBxEventsName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBxEventsName.TextChanged
        '   Only allow adding if name contains some text.

        If Me.E_ADDING Then
            If Me.TxtBxEventsName.Text <> "" Then
                Me.btnAdd.Enabled = True
            Else
                Me.btnAdd.Enabled = False
            End If
        End If
    End Sub

    Public Sub EventsClearText()
        '   Clears all date entry fields.

        Me.TxtBxEventsName.Text = ""
        Me.txtbxEventNotes.Text = ""

        Me.DtTmPckrEventsDate.Value = Today
    End Sub

    Public Sub EventsReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on textboxes.
        '   true = can be input of edit.
        '   false = display only

        Me.TxtBxEventsName.ReadOnly = Not b
        Me.CmbBxEventTypes.Enabled = b
        Me.DtTmPckrEventsDate.Enabled = b
        Me.txtbxEventNotes.ReadOnly = Not b
    End Sub


    Public Sub showEvents(ByVal pos As Integer)
        '   populates the text boxes on the form with the event at the specified position of the list view box.

        FEMcommon.PanelTop()

        If pos >= 0 Then
            Dim e As Events = CType(Me.LstBxEvents.Items.Item(pos), Events)

            Me.TxtBxEventsName.Text = e.EventName
            Me.CmbBxEventTypes.SelectedIndex = e.EventType
            Me.txtbxEventNotes.Text = e.EventNotes

            Me.LstBxEvents.SelectedIndex = pos
        End If
    End Sub

    Public Sub populateEvents(ByVal mode As String)
        '   populates the events class with the corresponding data from the form.
        '   If adding, the event is added to the list view box, if not the current entry is updated.

        Dim e As New Events

        Try
            e.EventName = Me.TxtBxEventsName.Text
            e.EventType = Me.CmbBxEventTypes.SelectedIndex
            e.EventDate = Me.DtTmPckrEventsDate.Value
            e.EventNotes = Me.txtbxEventNotes.Text
            e.EventFirstReminder = True
            e.EventSecondreminder = True
            e.EventThirdReminder = True

            If mode = "ADD" Then
                Me.LstBxEvents.Items.Add(e)                             '   populate listview
            Else
                Me.LstBxEvents.Items(Me.LstBxEvents.SelectedIndex) = e
            End If
        Catch ex As Exception
            Me.displayAction.DisplayReminder("ERROR :: populating event", ex.Message)
        End Try
    End Sub

    Private Sub LstBxEvents_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstBxEvents.SelectedIndexChanged
        '   A new entry has been selected in the listview box, display new entry.

        Me.showEvents(Me.LstBxEvents.SelectedIndex)
    End Sub

    Private Sub checkEvents()
        '   For each event, check if a reminder is due.

        '   for each event, check if the number of days to go is under the reminder limit, if so then display a message
        '   and set the reminder to false (not to display again).

        Dim e As Events
        Dim reSave As Boolean = False

        For Each e In LstBxEvents.Items        '   Create list.

            If e.EventFirstReminder And (e.DaysToGo < Me.usrSettings.usrEventsFirstReminder) Then
                Me.displayAction.DisplayEvent(e)
                e.EventFirstReminder = False
                reSave = True
            ElseIf e.EventSecondreminder And (e.DaysToGo < Me.usrSettings.usrEventsSecondReminder) Then
                Me.displayAction.DisplayEvent(e)
                e.EventSecondreminder = False
                reSave = True
            ElseIf e.EventThirdReminder And (e.DaysToGo < Me.usrSettings.usrEventsThirdReminder) Then
                Me.displayAction.DisplayEvent(e)
                e.EventThirdReminder = False
                reSave = True
            End If
        Next

        If reSave Then
            IOcommon.saveEvents()
        Else
            Me.displayAction.DisplayReminder("Events", "No events near")
        End If

    End Sub

    ' ************************************************************************************************************************************** Memo ********

    Public Sub MemoClearText()
        '   Clears all date entry fields.

        Me.TxtBxMemoName.Text = ""
        Me.TxtBxMemo.Text = ""
        Me.ChckBxMemoEncypt.Checked = False
    End Sub

    Public Sub memoReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on textboxes.
        '   true = can be input of edit.
        '   false = display only

        Me.TxtBxMemoName.ReadOnly = Not b
        Me.TxtBxMemo.ReadOnly = Not b
    End Sub

    Private Sub LstBxMemo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstBxMemo.SelectedIndexChanged
        '   A new memo has been selected in the listview box, display new entry

        Dim password As String = ""

        Me.showMemo(Me.LstBxMemo.SelectedIndex)
    End Sub

    Private Sub btnMemoDecrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemoDecrypt.Click

        Me.M_SHOW = True
        Me.TmrMemo.Enabled = True
        Me.showMemo(Me.LstBxMemo.SelectedIndex)
    End Sub

    Public Sub populateMemo(ByVal mode As String)
        '   populates the memo class with the corresponding data from the form.
        '   If adding, the event is added to the list view box, if not the current entry is updated.

        Dim m As New Memo

        Try
            m.memoName = Me.TxtBxMemoName.Text
            m.memoSecret = Me.ChckBxMemoEncypt.Checked

            If m.memoSecret Then
                Dim password As String = Me.getMemoPassword()
                If password = "-1" Then Exit Sub '   cancel been pressed - abort.

                Dim des As New Simple3Des(password)
                m.memoText = des.EncryptData(Me.TxtBxMemo.Text)
            Else
                m.memoText = Me.TxtBxMemo.Text
            End If

            If mode = "ADD" Then
                Me.LstBxMemo.Items.Add(m)
            Else
                Me.LstBxMemo.Items(Me.LstBxMemo.SelectedIndex) = m
            End If
        Catch ex As Exception
            Me.displayAction.DisplayReminder("ERROR :: populating memo", ex.Message)
        End Try
    End Sub

    Public Sub showMemo(ByVal pos As Integer)
        '   populates the text boxes on the form with the memo at the specified position of the list view box.

        FEMcommon.PanelTop()

        If pos >= 0 Then
            Dim m As Memo = CType(Me.LstBxMemo.Items.Item(pos), Memo)

            Me.TxtBxMemoName.Text = m.memoName
            Me.ChckBxMemoEncypt.Checked = m.memoSecret

            If m.memoSecret Then
                Me.TxtBxMemo.Text = "It's a secret"
                Me.btnMemoDecrypt.Enabled = True
            Else
                Me.TxtBxMemo.Text = m.memoText
                Me.btnMemoDecrypt.Enabled = False
            End If

            If Me.M_SHOW = True Then
                Dim password As String = Me.getMemoPassword()

                If password = "-1" Then         '   cancel been pressed - abort.
                    Me.TxtBxMemo.Text = "It's a secret"
                    Exit Sub
                End If

                Dim des As New Simple3Des(password)
                Try
                    Me.TxtBxMemo.Text = des.DecryptData(m.memoText)
                Catch ex As Exception
                    Me.displayAction.DisplayReminder("Memo Error", "Seems to be the wrong password")
                End Try

                Me.M_SHOW = False
            End If

            Me.LstBxMemo.SelectedIndex = pos
        End If
    End Sub

    Private Function getMemoPassword() As String
        '   asks a password for the user.
        '   returns either the password or the default password if allowed.
        '   returns -1 if cancel is pressed - unlikely to be a password.


        Dim password As String = ""

        If Me.usrSettings.usrMemoUseDefaultPassword Then                            '   system set up to use default password.
            password = Me.usrSettings.usrMemoDefaultPassword                        '   return default password.
        Else                                                                        '   prompt user for password.
            frmMemoPassword.ShowDialog()                                            '   display password form.

            If frmMemoPassword.DialogResult = Windows.Forms.DialogResult.OK Then    '   user pressed ok on password.
                password = frmMemoPassword.TxtBxMemoPassword.Text                   '   return user entered password.
            Else                                                                    '   user pressed cancel on password form.
                password = "-1"                                                     '   return -1 to tell the world, user pressed cancel.
            End If
        End If  '   Me.usrSettings.usrMemoUseDefaultPassword

        Return password
    End Function

    Private Sub TmrMemo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMemo.Tick
        '   if enabled, a secret memo test has been decrypted.
        '   The timer fires every second, the sub keeps score of the seconds.
        '   If the number of seconds exceeds the stores value, the memo text is changed to "Its a secret".

        Static noOfSeconds As Integer = 0

        noOfSeconds += 1

        If noOfSeconds > Me.usrSettings.usrMemoDecyptTimeOut Then
            noOfSeconds = 0
            Me.showMemo(Me.LstBxMemo.SelectedIndex)
            Me.TmrMemo.Enabled = False
        End If
    End Sub

    ' ********************************************************************************************************************************* World Klock ******
    Private Sub CmbBxWorldKlockTimeZones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxWorldKlockTimeZones.SelectedIndexChanged
        '   Call update on world klock when a new time zone is chosen.
        '   This is called from the main timer if the world klock is visible, following sub's don't then need to call this.

        Me.updateWorldKlock()
    End Sub

    Private Sub updateWorldKlock()
        '   Update the world klock, with local time and time of chosen time zone.
        '   Slightly different update, depending on if long name of id;s are being used for time zones.

        Dim wt As String
        Dim ct As String

        If RdBtnWorldClockTimeZoneLongName.Checked Then
            Dim TzInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Me.CmbBxWorldKlockTimeZones.SelectedItem.id)
            wt = String.Format("  World Time : {0} :: {1}", TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongDateString, TimeZoneInfo.ConvertTime(Now, TzInfo).ToLongTimeString)
        Else
            wt = String.Format("  World Time : {0} :: {1}", TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, Me.CmbBxWorldKlockTimeZones.SelectedItem).ToLongDateString, TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, Me.CmbBxWorldKlockTimeZones.SelectedItem).ToLongTimeString)
        End If

        ct = String.Format("Current Time : {0} :: {1}", Now.ToLongDateString, Now.ToLongTimeString)

        Me.LblWorldKlockLocal.Text = ct
        Me.LblWorldKlockWorld.Text = wt
    End Sub

    Private Sub setTimeZones(ByVal pos As Integer)
        '   Load the time zones into the World Klock Combo Box.
        '   Slightly different update, depending on if long name of id's are being used for time zones.
        '   Argument passed in is the position of the current time zone, so it can be restored.

        Dim f As System.TimeZoneInfo

        Me.CmbBxWorldKlockTimeZones.Items.Clear()

        For Each f In TimeZoneInfo.GetSystemTimeZones
            If RdBtnWorldClockTimeZoneLongName.Checked Then
                Me.CmbBxWorldKlockTimeZones.Items.Add(f)
            Else
                Me.CmbBxWorldKlockTimeZones.Items.Add(f.Id)
            End If
        Next

        Me.CmbBxWorldKlockTimeZones.SelectedIndex = pos
    End Sub

    Private Sub RdBtnWorldClockTimeZoneLongName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBtnWorldClockTimeZoneLongName.CheckedChanged, RdBtnWorldClockTimeZoneID.CheckedChanged
        '   reload the combo box with time zones, in either long names or time zone id's.

        Dim pos As Integer = Me.CmbBxWorldKlockTimeZones.SelectedIndex
        Me.setTimeZones(pos)
    End Sub

    ' ******************************************************************************************************************************** Global Stuff ******
    Private Sub frmKlock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   Apply current setting on form load.

        Me.TmrMain.Enabled = False                      '   Turn off main timer while we sort things out.

        Me.startTime = My.Computer.Clock.TickCount      '   used for app running time.
        Me.displayOneTime = New selectTime              '   user selected time I
        Me.displayTwoTime = New selectTime              '   user selected time II
        Me.displayAction = New selectAction             '   user selected actions
        Me.displayTimer = New Timer                     '   timer stuff
        Me.usrSettings = New UserSettings               '   user settings
        Me.usrFonts = New UserFonts                     '   user fonts
        Me.usrVoice = New Voice                         '   user voice

        Me.myManagedPower = New ManagedPower            '   system power source

        Me.HlpPrvdrKlock.HelpNamespace = Me.strHelpPath '   set up help path.

        Me.DtPckrFriendsDOB.MaxDate = Now()             '   nobody is born after today :-)

        Me.setSettings()                                '   load user settings
        Me.setTimeTypes()                               '   load time types into combo box.
        Me.setActionTypes()                             '   load action types into combo box.
        Me.setTimeZones(0)                              '   load time zones into combo box, making index 0 active.
        Me.setTitleText()                               '   set app title text

        FEMcommon.ButtonsVisible(False)

        Me.TmrMain.Enabled = True                       '   Turn on main timer now things are sorted out.
    End Sub

    Private Sub frmKlock_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        '   If desired, start klock minimised i.e. in system tray.
        '   Did not seem to work in form load, so stuffed in here.

        If Me.usrSettings.usrStartMinimised Then
            Me.NtfyIcnKlock.Visible = True
            Me.Visible = False
        End If
    End Sub

    Private Sub frmKlock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '   Processes key presses at form level, before passed to components.
        '   Pressing F12, will shown total number of friends.
        '   The rest of the codes is so that enter is handled correctly when inputting a new friend.  Pressing enter or hitting
        '   the tab key will do the same thine, that is move focus to the next data entry box.

        If e.KeyCode = Keys.F12 Then
            '   MessageBox.Show(String.Format("The are {0} friends", Me.LstBxFriends.Items.Count.ToString))
            Me.displayAction.DisplayReminder("Friends", String.Format("The are {0} friends", Me.LstBxFriends.Items.Count.ToString))
            e.Handled = True
        End If

        If Me.TbCntrl.SelectedIndex <> 4 Then   '   if not friends tab - ignore reminder of sub.
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter And Not (e.Alt Or e.Control) Then
            e.SuppressKeyPress = True

            ' Make sure that the active control is a TextBox control
            ' Do not use the Enter key as tab when a button has the focus!
            If Me.ActiveControl.GetType Is GetType(TextBox) Or Me.ActiveControl.GetType Is GetType(CheckBox) Or Me.ActiveControl.GetType Is GetType(DateTimePicker) Then

                If e.Shift Then                      ' Use Shift + Enter to move backwards through the tab order
                    Me.ProcessTabKey(False)
                Else
                    Me.ProcessTabKey(True)
                End If
            End If
        End If
    End Sub

    Private Sub frmKlock_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '   On form close and if needed, save form position.

        If Me.usrSettings.usrSavePosition Then
            Me.usrSettings.usrFormTop = Me.Top
            Me.usrSettings.usrFormLeft = Me.Left
        End If

        Me.usrSettings.writeSettings()      '   save settings, not sure if anything has changed.

        grphcs.Dispose()
    End Sub

    Sub setSettings()
        '   Apply current settings,

        Me.usrSettings.readSettings()           '   read settings file, if not there a default one will be created.

        Me.TbCntrl.SelectedIndex = Me.usrSettings.usrDefaultTab

        Me.BackColor = Me.usrSettings.usrFormColour
        Me.StsStrpInfo.BackColor = Me.usrSettings.usrFormColour
        Me.MainMenuStrip.BackColor = Me.usrSettings.usrFormColour

        Me.TbPgTime.BackColor = Me.usrSettings.usrFormColour
        Me.TbPgCountDown.BackColor = Me.usrSettings.usrFormColour
        Me.TbPgTimer.BackColor = Me.usrSettings.usrFormColour
        Me.TbPgReminder.BackColor = Me.usrSettings.usrFormColour

        If Me.usrSettings.usrSavePosition Then
            Me.Top = Me.usrSettings.usrFormTop
            Me.Left = Me.usrSettings.usrFormLeft
        End If

        If Me.usrSettings.usrTimerHigh Then
            Me.lblTimerTime.Text = "00:00:00:00"
            Me.lblTimerSplit.Text = "00:00:00:00"
        Else
            Me.lblTimerTime.Text = "00:00:00"
            Me.lblTimerSplit.Text = "00:00:00"
        End If

        Me.TlStrpMnItmTime.Checked = Me.usrSettings.usrTimeDisplayMinimised
        Me.ChckBxReminderTimeCheck.Checked = Me.usrSettings.usrReminderTimeChecked
        Me.DisplayTwoTimeFormatsToolStripMenuItem.Checked = Me.usrSettings.usrTimeTwoFormats
        Me.DisplayIdleTime.Checked = Me.usrSettings.usrTimeIdleTime
        Me.MonitorDisableSleep.Checked = Me.usrSettings.usrDisableMonitorSleep

        If Me.usrSettings.usrTimeTwoFormats Then               '   switch on second time format, if desired.
            Me.CmbBxTimeTwo.Visible = True
            Me.LblTimeTwoTime.Visible = True
            Me.GroupBox14.Visible = True                    '   sorry i don't name groupboxs
            Me.GroupBox15.Visible = True
        Else
            Me.CmbBxTimeTwo.Visible = False
            Me.LblTimeTwoTime.Visible = False
            Me.GroupBox14.Visible = False
            Me.GroupBox15.Visible = False
        End If

        Me.DisplayTwoTimeFormatsToolStripMenuItem.Checked = Me.usrSettings.usrTimeTwoFormats    '   Set menu check accordingly.
        Me.DisplayIdleTime.Checked = Me.usrSettings.usrTimeIdleTime                             '   

        If Me.reloadFriends Then
            IOcommon.loadFriends()
            Me.blankFriendsDate()
            Me.LoadAutoCompleteStuff()

            If Me.TbCntrl.SelectedIndex = 5 And Me.LstBxFriends.Items.Count > 0 Then
                Me.btnDelete.Enabled = True
                Me.btnEdit.Enabled = True
                Me.showFriends(0)
            End If
        End If

        If Me.reloadEvents Then IOcommon.loadEvents()
        If Me.LstBxEvents.Items.Count > 0 Then Me.checkEvents()
        If Me.reloadMemo Then IOcommon.loadMemo()

        Me.reloadFriends = False                        '   set to re-load friends file to false.
        Me.reloadEvents = False                         '   set to re-load events file to false.
        Me.reloadMemo = False                           '   set to re-load memo file to false
    End Sub

    Sub setActionTypes()
        '   Loads the different action types and load into combo box.
        '   Loads the different system action types and load into combo box.
        '   Also use this sub to load the event types and periods into there respective combo boxes.


        Dim actionNames = System.Enum.GetNames(GetType(selectAction.ActionTypes))
        Dim systemNames = System.Enum.GetNames(GetType(selectAction.SystemTypes))
        Dim eventTypes = System.Enum.GetNames(GetType(Events.EventTypes))

        Me.CmbBxCountDownAction.Items.AddRange(actionNames)
        Me.CmbBxCountDownSystem.Items.AddRange(systemNames)

        Me.CmbBxReminderAction.Items.AddRange(actionNames)
        Me.CmbBxReminderSystem.Items.AddRange(systemNames)

        Me.CmbBxEventTypes.Items.AddRange(eventTypes)

        Me.CmbBxCountDownAction.SelectedIndex = 0       '   until I know how to do this at design time :o)
        Me.CmbBxReminderAction.SelectedIndex = 0
        Me.CmbBxEventTypes.SelectedIndex = 0
    End Sub


    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        '   Hides main form and call system tray icon.

        Me.NtfyIcnKlock.Visible = True
        Me.Visible = False
    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click, MnItmSubHelp.Click, TlStrpMnItmHelp.Click

        Help.ShowHelp(Me, Me.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub

    ' *************************************************************************************************************************** menu stuff *************
    Private Sub closeKlock(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click, MnItmExit.Click, TlStrpMnItmExit.Click
        '   Close application.
        '   Called from close button, main menu [file / exit] and system tray right click menu.

        Me.Close()
    End Sub

    Private Sub aboutKlock(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmAbout.Click
        '   Display About screen.

        frmAbout.ShowDialog()
    End Sub

    Private Sub LicenseKlockk(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmLicense.Click
        '   Display License Screen.

        frmLicence.ShowDialog()
    End Sub

    Private Sub OptionsKlock(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmOptions.Click, TlStrpMnItmOptions.Click
        '   Display Settings Screen and apply settings, they may have changed.
        '   Called from main menu [file / options] and system tray right click menu.

        frmOptions.ShowDialog()

        Me.setSettings()

    End Sub

    ' ********************************************************************************************************************** time menu stuff *************

    Private Sub TextKlockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TextKlockToolStripMenuItem.Click
        '   if chosen from menus, switch on a text klock - appears in a seperate window.
        '   Will hide main window when created.

        Me.NtfyIcnKlock.Visible = True
        Me.Visible = False

        frmTextKlock.Show()

    End Sub

    Private Sub DisplayTwoTimeFormatsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DisplayTwoTimeFormatsToolStripMenuItem.Click
        '   If chosen from menus, switch on two time formats.

        If Me.DisplayTwoTimeFormatsToolStripMenuItem.Checked Then
            Me.usrSettings.usrTimeTwoFormats = True
            Me.CmbBxTimeTwo.Visible = True
            Me.LblTimeTwoTime.Visible = True
            Me.GroupBox14.Visible = True                    '   sorry i don't name groupboxs
            Me.GroupBox15.Visible = True
        Else
            Me.usrSettings.usrTimeTwoFormats = False
            Me.CmbBxTimeTwo.Visible = False
            Me.LblTimeTwoTime.Visible = False
            Me.GroupBox14.Visible = False
            Me.GroupBox15.Visible = False
        End If
    End Sub

    Private Sub DisplayIdleTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayIdleTime.Click
        '   If chosen from menus, display idle time in status bar.

        If Me.DisplayIdleTime.Checked Then
            Me.usrSettings.usrTimeIdleTime = True
        Else
            Me.usrSettings.usrTimeIdleTime = False
        End If
    End Sub


    ' ********************************************************************************************************************** monitor menu stuff *************

    Private Sub DisableSleepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitorDisableSleep.Click
        '   If chosen from menus, disable the monitor from going to sleep.

        If Me.MonitorDisableSleep.Checked Then
            KlockThings.KeepMonitorActive()
        Else
            KlockThings.RestoreMonitorSettings()
        End If
    End Sub

    ' ********************************************************************************************************************** info menu stuff *************

    Private Sub InfoMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaylightSavingToolStripMenuItem.Click, CultureToolStripMenuItem.Click, OSToolStripMenuItem.Click, PowerSourceToolStripMenuItem.Click
        '   Display some information.

        InfoCommon.displayInfo(sender.ToString)
    End Sub

    ' ****************************************************************************************************** context Strip Menu **************************
    ' menu loads when right clicking on tray icon

    Private Sub TlStrpMnItmShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmShow.Click, NtfyIcnKlock.MouseDoubleClick
        '   Hide system tray icon and show main form.
        '   Called from system tray right click menu and double clicking the tray icon.

        Me.NtfyIcnKlock.Visible = False
        Me.Visible = True
    End Sub

    Private Sub TlStrpMnItmTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmTime.CheckedChanged
        '   if checked, the system tray icon tooltip will be set to correct time [by main clock]

        Me.usrSettings.usrTimeDisplayMinimised = If(Me.TlStrpMnItmTime.Checked, True, False)

    End Sub


    ' ********************************************************************************************************************************* END **************




End Class
