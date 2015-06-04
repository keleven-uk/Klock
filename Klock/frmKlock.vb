Imports Klock.frmOptions
Imports System
Imports System.IO
Imports System.Globalization
Imports Microsoft.VisualBasic
Imports System.Runtime.Serialization.Formatters.Binary



Public Class frmKlock

    '   Main Klock application.       K. Scott    November 2012



    Public startTime As Integer

    Public displayOneTime As selectTime         '   instance of selectTime, allows different time formats.
    Public displayTwoTime As selectTime         '   instance of selectTime, allows different time formats.
    Public displayTimer As Timer                '   instance of timer, a wrapper of the stopwatch class.
    Public displayAction As selectAction        '   instance of selectAction, allows different actions to be performed.
    Public usrSettings As UserSettings          '   instance of user settings.
    Public usrVoice As Voice                    '   instance of user voice
    Public myManagedPower As ManagedPower       '   instance of managed Power

    Public CountDownTime As Integer             '   Holds number of minutes for the countdown timer.
    Public ReminderDateTime As DateTime         '   Holds the date [and time] of the set reminder.

    Public F_ADDING As Boolean = False          '   Will be true if adding friend, false if editing.
    Public E_ADDING As Boolean = False          '   Will be true if adding event, false if editing.

    Public reloadFriends As Boolean = True      '   if true, friends file will be re-loaded
    Public reloadEvents As Boolean = True       '   if true, events file will be re-loaded.

    Public epoc As Date = #1/1/1970#            '   used to set time picker to 0:00 i.e. midnight.

    Public strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "klock.chm") '   set up help location

    Public TEXT_WIDTH1 As Single = 400          '   the width bands to determine which font [below] to use - time labels.
    Public TEXT_WIDTH2 As Single = 500          '
    Public TEXT_WIDTH3 As Single = 580          '

    Dim txtLrgFont As New Font("Lucida Calligraphy", 17, FontStyle.Regular)     '   large font.
    Dim txtBigFont As New Font("Lucida Calligraphy", 16, FontStyle.Regular)     '   big font.
    Dim txtSmlFont As New Font("Lucida Calligraphy", 15, FontStyle.Regular)     '   small font.
    Dim txtTnyFont As New Font("Lucida Calligraphy", 14, FontStyle.Regular)     '   tiny font.

    Public grphcs As Graphics = Me.CreateGraphics   '   create graphic object globably, used to measure time text width
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

        If Me.Visible Then                                                              '   Only update if form is visible, can't see if in system tray.
            Me.updateStatusBar()
            Me.updateTitleText()

            If Me.TbCntrl.SelectedIndex = 0 Then

                Dim tmStr = Me.displayOneTime.getTime()
                Dim textSize = grphcs.MeasureString(tmStr, txtBigFont)

                Select Case textSize.Width
                    Case TEXT_WIDTH1 To TEXT_WIDTH2             '   400 to 500
                        Me.LblTimeOneTime.Font = txtBigFont
                    Case TEXT_WIDTH2 To TEXT_WIDTH3             '   500 to 580
                        Me.LblTimeOneTime.Font = txtSmlFont
                    Case Is > TEXT_WIDTH3                       '   > 580
                        Me.LblTimeOneTime.Font = txtTnyFont
                    Case Else                                   '   < 400
                        Me.LblTimeOneTime.Font = txtLrgFont
                End Select

                Me.LblTimeOneTime.Text = tmStr                   '   Update local time in desired time format.
            End If

            If Me.TbCntrl.SelectedIndex = 0 And Me.usrSettings.usrTimeTwoFormats Then

                Dim tmStr = Me.displayTwoTime.getTime()
                Dim textSize = grphcs.MeasureString(tmStr, txtBigFont)

                Select Case textSize.Width
                    Case TEXT_WIDTH1 To TEXT_WIDTH2             '   400 to 500
                        Me.LblTimeTwoTime.Font = txtBigFont
                    Case TEXT_WIDTH2 To TEXT_WIDTH3             '   500 to 580
                        Me.LblTimeTwoTime.Font = txtSmlFont
                    Case Is > TEXT_WIDTH3                       '   > 580
                        Me.LblTimeTwoTime.Font = txtTnyFont
                    Case Else                                   '   < 400
                        Me.LblTimeTwoTime.Font = txtLrgFont
                End Select

                Me.LblTimeTwoTime.Text = tmStr              '   display local time in desired time format.
            End If

            If Me.TbCntrl.SelectedIndex = 1 Then                                        '   Update World Klock.
                Me.updateWorldKlock()
            End If

            Me.TmrMain.Interval = Me.displayOneTime.getClockTick()
        Else
            Me.NotificationDispaly(currentSecond)                                       '   display a notification, if desired
        End If

        Me.playHourlyChimes(currentSecond)                                              '   Play a hourly chime,  if desired.
        Notificationspeech(currentSecond)                                               '   Speak time, if desired.

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

        Me.stsLblTime.Text = Format(Now, "Long Time")
        Me.StsLblDate.Text = Format(Now, "Long Date")
        Me.StsLblKeys.Text = strKey
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

        If Me.usrsettings.usrCountdownAdd And Me.tmrCountDown.Enabled Then '   countdown is running.
            titletext = titletext & " .::. " & Me.minsToString(Me.CountDownTime)
        End If

        If Me.usrsettings.usrReminderAdd And Me.tmrReminder.Enabled Then
            If Me.usrsettings.usrReminderTimeChecked Then
                titletext = titletext & " .::. Reminder set for " & Me.ReminderDateTime.ToLongDateString & " @ " & Me.ReminderDateTime.ToLongTimeString
            Else
                titletext = titletext & " .::. Reminder set for " & Me.ReminderDateTime.ToLongDateString
            End If
        End If

        Me.Text = titletext
    End Sub

    Private Sub playHourlyChimes(m As Integer)
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

        If Me.usrSettings.usrTimeVoiceMinimised And (Math.Floor(m Mod noSecs) = 0) Then
            usrVoice.Say(displayOneTime.getTime())
        End If

    End Sub

    Private Sub NotificationDispaly(ByVal m As Integer)
        '   If desired, check the status of notifications - should display the time every ?? minutes.
        '   Also, display result to time and countdown, if there running.  TO DO, should they be on their own settings?

        Me.NtfyIcnKlock.Text = Me.displayOneTime.getTitle() & " : " & Me.displayOneTime.getTime()    '   set icon tool tip to current time.

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

        If Me.usrsettings.usrTimerHigh Then                            '   are we displaying milliseconds in timer.
            Me.lblTimerTime.Text = displayTimer.getHighElapsedTime()
        Else
            Me.lblTimerTime.Text = displayTimer.getLowElapsedTime()
        End If

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
        '   If enabled, a reminder has been set - clocks ticks every 10 minute

        If Now() > Me.ReminderDateTime Then
            Me.ReminderAction()
            Me.clearReminder()                                             '   clear down reminder tab after action.
        End If

    End Sub

    ' ******************************************************************************************************************* Event clock ******************

    Private Sub tmrEvents_Tick(sender As System.Object, e As System.EventArgs) Handles tmrEvents.Tick
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
                Me.FriendsButtonsVisible(False)
                Me.eventsButtonsVisible(False)
            Case 1                                              '   World Klock
                Me.FriendsButtonsVisible(False)
                Me.eventsButtonsVisible(False)
                Me.updateWorldKlock()
            Case 2                                              '   countdown tab
                Me.FriendsButtonsVisible(False)
                Me.eventsButtonsVisible(False)
            Case 3                                              '   timer tab
                Me.FriendsButtonsVisible(False)
                Me.eventsButtonsVisible(False)
            Case 4                                              '   reminder tab
                Me.FriendsButtonsVisible(False)
                Me.eventsButtonsVisible(False)

                If Me.usrSettings.usrReminderTimeChecked Then
                    Me.TmPckrRiminder.Enabled = True
                    Me.TmPckrRiminder.Value = Now()
                Else
                    Me.TmPckrRiminder.Enabled = False
                    Me.TmPckrRiminder.Value = Today
                End If
            Case 5                                              '   friends tab
                Me.FriendsButtonsVisible(True)
                Me.eventsButtonsVisible(False)

                If Me.reloadFriends Then
                    Me.loadFriends()
                    Me.blankFriendsDate()
                    Me.LoadAutoCompleteStuff()
                    Me.reloadFriends = False                    ' do not reload, if not necessary
                End If

                If Me.LstBxFriends.Items.Count > 0 Then
                    Me.btnFriendsDelete.Enabled = True
                    Me.btnFriendsEdit.Enabled = True
                    Me.showFriends(0)
                End If
            Case 6                                              '   Events tab
                Me.FriendsButtonsVisible(False)
                Me.eventsButtonsVisible(True)

                If Me.reloadEvents Then
                    Me.loadEvents()
                    Me.reloadEvents = False
                End If

                If Me.LstBxEvents.Items.Count > 0 Then
                    Me.btnEventsDelete.Enabled = True
                    Me.btnEventsEdit.Enabled = True
                    Me.showEvents(0)
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
        End Select
    End Sub

    '   ************************************************************************************************** time ****************************************

    Sub setTimeTypes()
        '   Loads the different time format types and load into combo box.

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        Me.CmbBxTimeOne.Items.AddRange(names)
        Me.CmbBxTimeTwo.Items.AddRange(names)

        Me.CmbBxTimeOne.SelectedIndex = 0      '   until I know how to do this at design time :o)
        Me.CmbBxTimeTwo.SelectedIndex = 1

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

        If Me.usrsettings.usrTimerClearSplit Then
            If Me.usrsettings.usrTimerHigh Then
                Me.lblTimerTime.Text = "00:00:00:00"
                Me.lblTimerSplit.Text = "00:00:00:00"
            Else
                Me.lblTimerTime.Text = "00:00:00"
                Me.lblTimerSplit.Text = "00:00:00"
            End If
            Me.btnTimerSplitClear.Enabled = False
        Else
            Me.lblTimerTime.Text = IIf(Me.usrsettings.usrTimerHigh, "00:00:00:00", "00:00:00")
        End If

    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplit.Click
        '   Copies time to split time.

        Me.lblTimerSplit.Text = Me.lblTimerTime.Text

        Me.btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplitClear.Click
        '   Clears the split time.

        Me.lblTimerSplit.Text = IIf(Me.usrsettings.usrTimerHigh, "00:00:00:00", "00:00:00")

        Me.btnTimerSplitClear.Enabled = False
    End Sub

    ' ************************************************************************************************************ Countdown ******************************
    Private Sub upDwnCntDownValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upDwnCntDownValue.ValueChanged
        '   When the up down counter has been changed, enable the start button and update the countdown label.

        Me.btnCountDownStart.Enabled = IIf(Me.upDwnCntDownValue.Value = 0, False, True)

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
        Me.btnCountDownStart_Click(sender, e)                       '   call click sub to strat countdown.
    End Sub

    Private Sub btnCountdown60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdown60.Click
        '   runs the countdown for 60 minutes form the quick start button.

        Me.CountDownTime = 60 * 60                                  '   60 minutes in seconds.
        Me.lblCountDownTime.Text = Me.minsToString(CountDownTime)
        Me.btnCountDownStart_Click(sender, e)                       '   call click sub to strat countdown.
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

        minsToString = String.Format("{0:00}:{1:00}", hours, mins)
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

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year, _
                         Me.DtPckrRiminder.Value.Month, _
                         Me.DtPckrRiminder.Value.Day, _
                         Me.TmPckrRiminder.Value.Hour, _
                         Me.TmPckrRiminder.Value.Minute, _
                         0)

        Me.tmrReminder.Enabled = True       '   start reminder timer.

        Me.btnReminderSet.Enabled = False
        Me.btnReminderClear.Enabled = True
        Me.DtPckrRiminder.Visible = False
        Me.ChckBxReminderTimeCheck.Visible = False
        Me.TmPckrRiminder.Visible = False

        If Me.usrsettings.usrReminderTimeChecked Then
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

        If Me.usrsettings.usrReminderTimeChecked Then
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

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year, _
                         Me.DtPckrRiminder.Value.Month, _
                         Me.DtPckrRiminder.Value.Day, _
                         Me.TmPckrRiminder.Value.Hour, _
                         Me.TmPckrRiminder.Value.Minute, _
                         0)

        Me.btnReminderSet.Enabled = IIf(d > Now(), True, False)
    End Sub

    Private Sub ChckBxReminderTimeCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderTimeCheck.CheckedChanged
        '   Allows the reminder date to include a time component.

        If Me.ChckBxReminderTimeCheck.Checked Then
            Me.usrsettings.usrReminderTimeChecked = True
            Me.TmPckrRiminder.Enabled = True
            Me.TmPckrRiminder.Value = Now()
        Else
            Me.usrsettings.usrReminderTimeChecked = False
            Me.TmPckrRiminder.Enabled = False
            Me.TmPckrRiminder.Value = Today
        End If
    End Sub

    ' **************************************************************************************************** Friends ****************************************

    Private Sub btnFriendsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriendsNew.Click
        '   Sets up to add new friend.

        Me.scrollFriendsPanelToTop()
        Me.btnFriendsClear.Enabled = True
        Me.btnFriendsNew.Enabled = False
        Me.btnFriendsEdit.Enabled = False
        Me.txtbxFriendsFirstName.Focus()

        Me.FriendsClearText()
        Me.FriendsReadOnlyText(False)

        Me.F_ADDING = True
    End Sub

    Private Sub btnFriendsClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriendsClear.Click
        '   Clears everything [not sure when called].

        Me.scrollFriendsPanelToTop()

        Me.F_ADDING = False

        Me.btnFriendsEdit.Enabled = False
        Me.btnFriendsEdit.Text = "Edit"
        Me.btnFriendsClear.Enabled = False
        Me.btnFriendsAdd.Enabled = False
        Me.btnFriendsNew.Enabled = True

        If Me.LstBxFriends.Items.Count > 0 Then
            Me.btnFriendsDelete.Enabled = True
            Me.btnFriendsEdit.Enabled = True
            Me.showFriends(0)
        Else
            Me.btnFriendsEdit.Enabled = False
            Me.FriendsClearText()
        End If

        Me.FriendsReadOnlyText(True)
    End Sub

    Private Sub FirstAndLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbxFriendsFirstName.TextChanged, txtbxFriendsLastName.TextChanged
        '   Only allow adding if first and last name exist.

        If Me.F_ADDING Then
            If Me.txtbxFriendsFirstName.Text <> "" And Me.txtbxFriendsLastName.Text <> "" Then
                Me.btnFriendsAdd.Enabled = True
            Else
                Me.btnFriendsAdd.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnFriendsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriendsAdd.Click
        '   Adds a new friend to listview box and saves a new friends file.

        Me.populateFriend("ADD")

        Me.F_ADDING = False

        Me.btnFriendsNew.Enabled = True
        Me.btnFriendsDelete.Enabled = True
        Me.btnFriendsEdit.Enabled = True
        Me.btnFriendsClear.Enabled = False
        Me.btnFriendsAdd.Enabled = False

        Me.FriendsClearText()
        Me.FriendsReadOnlyText(True)
        Me.showFriends(0)                       '   Display first friend :: TODO should display new friend ??
        Me.savefriends()                        '   Saves new friends file.
    End Sub

    Private Sub btnFriendsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriendsEdit.Click
        '   allows selected entry in listveiw box to be edited.
        '   Changed button to "Save", which then will save new data to selected entry and save new friends file.

        Me.scrollFriendsPanelToTop()

        If Me.btnFriendsEdit.Text = "Edit" Then
            Me.txtbxFriendsFirstName.Focus()
            Me.btnFriendsEdit.Text = "Save"
            Me.btnFriendsClear.Enabled = True
            Me.btnFriendsDelete.Enabled = False
            Me.btnFriendsNew.Enabled = False

            Me.FriendsReadOnlyText(False)
        Else
            Me.populateFriend("EDIT")               '   Save new data back to listview box

            Me.btnFriendsEdit.Text = "Edit"
            Me.btnFriendsClear.Enabled = False
            Me.btnFriendsDelete.Enabled = True
            Me.btnFriendsNew.Enabled = True

            Me.FriendsReadOnlyText(True)

            Me.savefriends()                        '   Saves new friends file.
        End If
    End Sub

    Private Sub btnFriendsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriendsDelete.Click
        '   Deletes the currently selected entry form the listviewbox.
        '   Saves new friends file and display first entry [if exists].

        Dim reply As MsgBoxResult

        reply = MsgBox("Are you sure to DELETE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

        If reply = MsgBoxResult.No Then Exit Sub '   Not to delete, exit sub.

        If Me.LstBxFriends.SelectedIndex > -1 Then          '   If entries in listview box.
            Me.LstBxFriends.Items.RemoveAt(Me.LstBxFriends.SelectedIndex)
            Me.savefriends()
            Me.FriendsClearText()
            Me.FriendsReadOnlyText(True)
        End If

        If Me.LstBxFriends.Items.Count > 0 Then             '   If entries in list view box, after delete.
            Me.btnFriendsDelete.Enabled = True
            Me.btnFriendsEdit.Enabled = True
            Me.showFriends(0)
        Else                                                '   No entries in listview box after delete.
            Me.btnFriendsDelete.Enabled = False
            Me.btnFriendsEdit.Enabled = False
        End If
    End Sub

    Private Sub FriendsClearText()
        '   Clears all date entry fields.

        Me.scrollFriendsPanelToTop()

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

    Private Sub FriendsReadOnlyText(ByVal b As Boolean)
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

    Private Sub showFriends(ByVal pos As Integer)
        '   Populates the text boxes on the form with the person at the specified position of the listview box.

        Me.scrollFriendsPanelToTop()

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

    Private Sub populateFriend(ByVal mode As String)
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

    Private Sub FriendsButtonsVisible(ByVal b As Boolean)
        '   Switch on the friends editing buttons.

        Me.btnFriendsNew.Visible = b
        Me.btnFriendsAdd.Visible = b
        Me.btnFriendsClear.Visible = b
        Me.btnFriendsEdit.Visible = b
        Me.btnFriendsDelete.Visible = b
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

    Private Sub FriendsAddToKnown(ByVal p As Person)
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

    Private Sub savefriends()
        '   Save friends to file in data directory.
        '   Creates a list of all entries in the listview box and then writes this list to a binary file.

        checkFriendsDirectory()        '   Check for data directory first, will be created if not there.

        Dim saveFile As FileStream = File.Create(System.IO.Path.Combine(Me.usrSettings.usrFriendsDirectory, Me.usrSettings.usrFriendsFile))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Person)
        Dim p As Person

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each p In Me.LstBxFriends.Items        '   Create list.
            AL.Add(p)
        Next

        Try
            Formatter.Serialize(saveFile, AL)   '   Write list to binary file.
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Friends Error", "Error saving Friends File." & vbCrLf & ex.Message)
        End Try


        saveFile.Close()

        Formatter = Nothing

    End Sub

    Private Sub loadFriends()
        '   Loads friends from file and populate the listview box.
        '   Loads file into a list and then transfers each item in the list to the listview box.

        Dim readFile As FileStream

        Try
            readFile = File.OpenRead(System.IO.Path.Combine(Me.usrSettings.usrFriendsDirectory, Me.usrSettings.usrFriendsFile))
            readFile.Seek(0, SeekOrigin.Begin)
        Catch ex As Exception                   '   not there, go away.
            Me.displayAction.DisplayReminder("Friends", "No Friends file found - will create if needed.")
            Exit Sub
        End Try

        Dim AL As New List(Of Person)
        Dim p As Person

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Friends Error", "Error loading Friends File. " & ex.Message)
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        Me.LstBxFriends.Items.Clear()
        Me.knownCities.Clear()

        For Each p In AL                    '   For each item in the list.
            Me.LstBxFriends.Items.Add(p)    '   Populate listview.
            Me.FriendsAddToKnown(p)         '   Populate autocomplete collections.
        Next

        readFile.Close()
        Formatter = Nothing

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

    Private Sub checkFriendsDirectory()
        '   Check for data directory, which can be user selected [i.e. might not be application starting directory].  if doesn't exist, create it.

        Dim FriendsDirectory As String = Me.usrsettings.usrFriendsDirectory

        If Not My.Computer.FileSystem.DirectoryExists(FriendsDirectory) Then
            Me.displayAction.DisplayReminder("Friends", "Creating " & FriendsDirectory)
            My.Computer.FileSystem.CreateDirectory(FriendsDirectory)
        Else
            Me.displayAction.DisplayReminder("Friends", "Using " & FriendsDirectory)
        End If
    End Sub

    Private Sub scrollFriendsPanelToTop()
        '   scroll friends panel back to top.

        Me.pnlFriends.ScrollControlIntoView(Me.lblFriendsFirstName)
    End Sub

    ' ********************************************************************************************************************************* Events ********

    Private Sub eventsButtonsVisible(ByVal b As Boolean)
        '   Switch on the events editing buttons.

        Me.btnEventsNew.Visible = b
        Me.btnEventsAdd.Visible = b
        Me.btnEventsClear.Visible = b
        Me.btnEventsEdit.Visible = b
        Me.btnEventsDelete.Visible = b
    End Sub

    Private Sub btnEventsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventsNew.Click
        '   Sets up to add new event.

        Me.ScrollEventsPanelTop()

        Me.btnEventsClear.Enabled = True
        Me.btnEventsAdd.Enabled = False
        Me.btnEventsNew.Enabled = False
        Me.btnEventsEdit.Enabled = False
        Me.TxtBxEventsName.Focus()

        Me.EventsClearText()
        Me.EventsReadOnlyText(True)

        Me.E_ADDING = True
    End Sub

    Private Sub btnEventsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventsAdd.Click
        '   Adds a new event to listview and saves a new event file.

        Me.populateEvents("ADD")

        Me.btnEventsNew.Enabled = True
        Me.btnEventsDelete.Enabled = True
        Me.btnEventsEdit.Enabled = True
        Me.btnEventsClear.Enabled = True
        Me.btnEventsAdd.Enabled = False

        Me.EventsClearText()
        Me.EventsReadOnlyText(True)
        Me.showEvents(0)
        Me.saveEvents()
    End Sub

    Private Sub btnEventsClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventsClear.Click
        '   Cleares everything [not sure when called]

        Me.ScrollEventsPanelTop()

        Me.E_ADDING = False

        Me.btnEventsEdit.Enabled = False
        Me.btnEventsEdit.Text = "Edit"
        Me.btnEventsClear.Enabled = False
        Me.btnEventsAdd.Enabled = False
        Me.btnEventsNew.Enabled = False

        If Me.LstBxEvents.Items.Count > 0 Then
            Me.btnEventsDelete.Enabled = True
            Me.btnEventsEdit.Enabled = True
            Me.showEvents(0)
            Me.tmrEvents.Interval = Me.usrSettings.usrEventsTimerInterval * 60      '   interval is held in minutes
            Me.tmrEvents.Enabled = True                                             '   enable events timer.
        Else
            Me.btnEventsEdit.Enabled = False
            Me.btnEventsDelete.Enabled = False
            Me.EventsClearText()
            Me.tmrEvents.Enabled = False                                           '   disable events timer.
        End If

        Me.EventsReadOnlyText(False)
    End Sub

    Private Sub btnEventsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventsEdit.Click
        '   allows selected entry in listveiw box to be edited.
        '   Changed button to "Save", which then will save new data to selected entry and save new friends file.

        Me.ScrollEventsPanelTop()

        If Me.btnEventsEdit.Text = "Edit" Then
            Me.TxtBxEventsName.Focus()
            Me.btnEventsEdit.Text = "Save"
            Me.btnEventsClear.Enabled = True
            Me.btnEventsDelete.Enabled = False
            Me.btnEventsNew.Enabled = False

            Me.EventsReadOnlyText(False)
        Else
            Me.populateEvents("Edit")                           '   Save new data back to listview box

            Me.btnEventsEdit.Text = "Edit"
            Me.btnEventsClear.Enabled = False
            Me.btnEventsDelete.Enabled = True
            Me.btnEventsNew.Enabled = True

            Me.EventsReadOnlyText(True)                         '   Saves new events file.

            Me.saveEvents()
        End If
    End Sub

    Private Sub btnEventsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventsDelete.Click
        '   Deletes the currently selected entry form the listviewbox.
        '   Saves new evenst file and display first entry [if exists].

        Dim reply As MsgBoxResult

        reply = MsgBox("Are you sure to DELETE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

        If reply = MsgBoxResult.No Then Exit Sub '   Not to delete, exit sub.

        If Me.LstBxEvents.SelectedIndex > -1 Then          '   If entries in listview box.
            Me.LstBxEvents.Items.RemoveAt(Me.LstBxEvents.SelectedIndex)
            Me.saveEvents()
            Me.EventsClearText()
            Me.EventsReadOnlyText(True)
        End If

        If Me.LstBxEvents.Items.Count > 0 Then                                      '   If entries in list view box, after delete.
            Me.btnEventsDelete.Enabled = True
            Me.btnEventsEdit.Enabled = True
            Me.showEvents(0)
            Me.tmrEvents.Interval = Me.usrSettings.usrEventsTimerInterval * 60      '   interval is held in minutes
            Me.tmrEvents.Enabled = True                                             '   enable events timer.
        Else                                                                        '   No entries in listview box after delete.
            Me.btnEventsDelete.Enabled = False
            Me.btnEventsEdit.Enabled = False
            Me.tmrEvents.Enabled = False                                             '   enable events timer.
        End If
    End Sub

    Private Sub ChckBxEventRecuring_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxEventRecuring.CheckedChanged

        Me.CmbBxEventPeriod.Enabled = ChckBxEventRecuring.Checked
        Me.ChckBxEventOneOff.Enabled = Not ChckBxEventRecuring.Checked
    End Sub

    Private Sub ChckBxEventOneOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxEventOneOff.CheckedChanged

        Me.ChckBxEventRecuring.Enabled = Not Me.ChckBxEventOneOff.Checked
    End Sub

    Private Sub TxtBxEventsName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBxEventsName.TextChanged
        '   Only allow adding if name contains some text.

        If Me.E_ADDING Then
            If Me.TxtBxEventsName.Text <> "" Then
                Me.btnEventsAdd.Enabled = True
            Else
                Me.btnEventsAdd.Enabled = False
            End If
        End If
    End Sub

    Private Sub EventsClearText()
        '   Clears all date entry dields.

        Me.TxtBxEventsName.Text = ""
        Me.txtbxEventNotes.Text = ""

        Me.DtTmPckrEventsDate.Value = Today

        Me.ChckBxEventRecuring.Checked = False
        Me.ChckBxEventOneOff.Checked = False
    End Sub

    Private Sub EventsReadOnlyText(ByVal b As Boolean)
        '   Sets the read-only value on textboxes.
        '   true = can be input of edit.
        '   false = display only

        Me.TxtBxEventsName.ReadOnly = Not b
        Me.CmbBxEventTypes.Enabled = b
        Me.ChckBxEventOneOff.Enabled = b
        Me.DtTmPckrEventsDate.Enabled = b
        Me.ChckBxEventRecuring.Enabled = b
        Me.txtbxEventNotes.ReadOnly = Not b
    End Sub

    Private Sub ScrollEventsPanelTop()
        '   Scroll events pannel back to top.

        Me.pnlEvents.ScrollControlIntoView(Me.lblEventsName)
    End Sub

    Private Sub showEvents(ByVal pos As Integer)
        '   populates the text boxes on the form with the event at the specified position of the list view box.

        Me.ScrollEventsPanelTop()

        If pos >= 0 Then
            Dim e As Events = CType(Me.LstBxEvents.Items.Item(pos), Events)

            Me.TxtBxEventsName.Text = e.EventName
            Me.CmbBxEventTypes.SelectedIndex = e.EventType
            Me.ChckBxEventRecuring.Checked = e.EventRecuring
            Me.ChckBxEventOneOff.Checked = e.EventOneOff
            Me.CmbBxEventPeriod.SelectedIndex = e.EventPeriod
            Me.txtbxEventNotes.Text = e.EventNotes

            Me.LstBxEvents.SelectedIndex = pos
        End If
    End Sub

    Private Sub populateEvents(ByVal mode As String)
        '   populates the events class with the corresponding data from the form.
        '   If adding, the event is added to the list view box, if not the current entry is updated.

        Dim e As New Events

        Try
            e.EventName = Me.TxtBxEventsName.Text
            e.EventType = Me.CmbBxEventTypes.SelectedIndex
            e.EventDate = Me.DtTmPckrEventsDate.Value
            e.EventRecuring = Me.ChckBxEventRecuring.Checked
            e.EventOneOff = Me.ChckBxEventOneOff.Checked
            e.EventPeriod = Me.CmbBxEventPeriod.SelectedIndex
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

    Private Sub saveEvents()
        '   Save Events to file in data directory.
        '   Creates a list of all entries in the listview box and then writes this list to a binary file.

        checkEventsDirectory()        '   Check for data directory first, will be created if not there.

        Dim saveFile As FileStream = File.Create(System.IO.Path.Combine(Me.usrSettings.usrEventsDirectory, Me.usrSettings.usrEventsFile))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Events)
        Dim e As Events

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each e In LstBxEvents.Items        '   Create list.
            AL.Add(e)
        Next

        Try
            Formatter.Serialize(saveFile, AL)   '   Write list to binary file.
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Events Error", "Error saving Events File." & vbCrLf & ex.Message)
        End Try


        saveFile.Close()

        Formatter = Nothing

    End Sub

    Private Sub loadEvents()
        '   Loads Events from file and populate the listview box.
        '   Loads file into a list and then transfers each item in the list to the listview box.

        Dim readFile As FileStream

        Try
            readFile = File.OpenRead(System.IO.Path.Combine(Me.usrSettings.usrEventsDirectory, Me.usrSettings.usrEventsFile))
            readFile.Seek(0, SeekOrigin.Begin)
        Catch ex As Exception                   '   not there, go away.
            Me.displayAction.DisplayReminder("Events", "No Events file found - will create if needed.")
            Exit Sub
        End Try

        Dim AL As New List(Of Events)
        Dim e As Events

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Events Error", "Error Events Friends File. " & ex.Message)
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        Me.LstBxEvents.Items.Clear()

        For Each e In AL                    '   For each item in the list.
            Me.LstBxEvents.Items.Add(e)     '   Populate listview.
        Next

        readFile.Close()
        Formatter = Nothing

        If Me.LstBxEvents.Items.Count > 0 Then
            Me.tmrEvents.Enabled = True
        Else
            Me.tmrEvents.Enabled = False
        End If


    End Sub

    Private Sub LstBxEvents_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstBxEvents.SelectedIndexChanged
        '   A new entry has been selected in the listview box, display new entry.

        Me.showEvents(Me.LstBxEvents.SelectedIndex)
    End Sub

    Private Sub checkEventsDirectory()
        '   Check for data directory, which can be user selected [i.e. might not be application starting directory].  if doesn't exist, create it.

        Dim EventsDirectory As String = Me.usrSettings.usrEventsDirectory

        If Not My.Computer.FileSystem.DirectoryExists(EventsDirectory) Then
            Me.displayAction.DisplayReminder("Events", "Creating " & EventsDirectory)
            My.Computer.FileSystem.CreateDirectory(EventsDirectory)
        Else
            Me.displayAction.DisplayReminder("Events", "Using " & EventsDirectory)
        End If
    End Sub

    Private Sub checkEvents()
        '   For each event, check if a reminder is due.

        '   for each event, check if the number of days to go is under the reminder limit, if so then display a message
        '   and set the reminder to false (not to display again).

        Me.displayAction.DisplayReminder("Events", "Checking Events ")

        Dim e As Events

        For Each e In LstBxEvents.Items        '   Create list.

            If e.EventThirdReminder And (e.DaysToGo < Me.usrSettings.usrEventsThirdReminder) Then
                Me.displayAction.DisplayEvent("Event Reminder", e.EventName & " in " & e.DaysToGo.ToString & " DAYS")
                MessageBox.Show(e.EventName & "in " & e.DaysToGo.ToString & " DAYS", "Event Reminder")
                e.EventThirdReminder = False
            ElseIf e.EventSecondreminder And (e.DaysToGo < Me.usrSettings.usrEventsSecondReminder) Then
                Me.displayAction.DisplayEvent("Event Reminder", e.EventName & " in " & e.DaysToGo.ToString & " DAYS")
                e.EventSecondreminder = False
            ElseIf e.EventFirstReminder And (e.DaysToGo < Me.usrSettings.usrEventsFirstReminder) Then
                Me.displayAction.DisplayEvent("Event Reminder", e.EventName & " in " & e.DaysToGo.ToString & " DAYS")
                e.EventFirstReminder = False
            End If
        Next
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
        '   Slightly different update, depending on if long name of id;s are being used for time zones.
        '   Argument passed in is the position of the current time zone, so it can be restored.

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
        Me.usrVoice = New Voice                         '   user voice
        Me.myManagedPower = New ManagedPower            '   system power source

        Me.HlpPrvdrKlock.HelpNamespace = Me.strHelpPath '   set up help path.

        Me.DtPckrFriendsDOB.MaxDate = Now()             '   nobody is born after today :-)

        Me.setSettings()                                '   load user settings
        Me.setTimeTypes()                               '   load time types into combo box.
        Me.setActionTypes()                             '   load action types into combo box.
        Me.setTimeZones(0)                              '   load time zones into combo box, making index 0 active.
        Me.setTitleText()                               '   set app title text

        Me.FriendsButtonsVisible(False)
        Me.eventsButtonsVisible(False)

        '   For the moment, we will load both friends and events file at form load.
        '   We need to load events file to see if any evenst need to be parsed.
        '   if this causes a delay, friends file can be loaded on entering the friends tab [as before].

        Me.loadFriends()                                '   load friends file - if there.
        Me.loadEvents()                                 '   load events file - if there.

        If Me.LstBxEvents.Items.Count > 0 Then Me.checkEvents()

        Me.reloadFriends = False                        '   set to re-load friends file to false.
        Me.reloadEvents = False                         '   set to re-load events file to false.

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

        If Me.usrsettings.usrSavePosition Then
            Me.usrsettings.usrFormTop = Me.Top
            Me.usrSettings.usrFormLeft = Me.Left
            Me.usrSettings.writeSettings()
        End If

        grphcs.Dispose()

        '   fs.Close()
        '   sw.Close()

    End Sub

    Sub setSettings()
        '   Apply current settings,

        Me.usrsettings.readSettings()           '   read settings file, if not there a default one will be created.

        Me.BackColor = Me.usrsettings.usrFormColour
        Me.StsStrpInfo.BackColor = Me.usrsettings.usrFormColour
        Me.MainMenuStrip.BackColor = Me.usrsettings.usrFormColour

        Me.TbPgTime.BackColor = Me.usrsettings.usrFormColour
        Me.TbPgCountDown.BackColor = Me.usrsettings.usrFormColour
        Me.TbPgTimer.BackColor = Me.usrsettings.usrFormColour
        Me.TbPgReminder.BackColor = Me.usrsettings.usrFormColour

        If Me.usrsettings.usrSavePosition Then
            Me.Top = Me.usrsettings.usrFormTop
            Me.Left = Me.usrsettings.usrFormLeft
        End If

        If Me.usrsettings.usrTimerHigh Then
            Me.lblTimerTime.Text = "00:00:00:00"
            Me.lblTimerSplit.Text = "00:00:00:00"
        Else
            Me.lblTimerTime.Text = "00:00:00"
            Me.lblTimerSplit.Text = "00:00:00"
        End If

        Me.TlStrpMnItmTime.Checked = Me.usrsettings.usrTimeDisplayMinimised
        Me.ChckBxReminderTimeCheck.Checked = Me.usrsettings.usrReminderTimeChecked

        If Me.usrsettings.usrTimeTwoFormats Then               '   switch on second time format, if desired.
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

        If Me.reloadFriends Then
            Me.loadFriends()
            Me.blankFriendsDate()
            Me.LoadAutoCompleteStuff()
            Me.reloadFriends = False        ' do not reload, in not necserry

            If Me.TbCntrl.SelectedIndex = 5 And Me.LstBxFriends.Items.Count > 0 Then
                Me.btnFriendsDelete.Enabled = True
                Me.btnFriendsEdit.Enabled = True
                Me.showFriends(0)
            End If
        End If

    End Sub

    Sub setActionTypes()
        '   Loads the different action types and load into combo box.   
        '   Loads the different system action types and load into combo box.
        '   Also use this sub to load the event types and periods into thies respective combo boxes.


        Dim actionNames = System.Enum.GetNames(GetType(selectAction.ActionTypes))
        Dim systemNames = System.Enum.GetNames(GetType(selectAction.SystemTypes))
        Dim eventTypes = System.Enum.GetNames(GetType(Events.EventTypes))
        Dim eventPeriods = System.Enum.GetNames(GetType(Events.Eventsperiods))

        Me.CmbBxCountDownAction.Items.AddRange(actionNames)
        Me.CmbBxCountDownSystem.Items.AddRange(systemNames)

        Me.CmbBxReminderAction.Items.AddRange(actionNames)
        Me.CmbBxReminderSystem.Items.AddRange(systemNames)

        Me.CmbBxEventTypes.Items.AddRange(eventTypes)
        Me.CmbBxEventPeriod.Items.AddRange(eventPeriods)

        Me.CmbBxCountDownAction.SelectedIndex = 0       '   until I know how to do this at design time :o)
        Me.CmbBxReminderAction.SelectedIndex = 0
        Me.CmbBxEventTypes.SelectedIndex = 0
        Me.CmbBxEventPeriod.SelectedIndex = 0
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

        '   try updating setting from options form.
        'Me.reloadFriends = True             '   set to re-load friends file.
        'Me.usrsettings.writeSettings()      '   write new options to settings file.
        'Me.setSettings()                    '   Apply new Settings.

    End Sub

    Private Sub DaylightSavingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaylightSavingToolStripMenuItem.Click
        '   Display some information of Daylight Saving.

        ' Get the local time zone and the current  year. 
        Dim localZone As TimeZone = TimeZone.CurrentTimeZone
        Dim currentDate As DateTime = DateTime.Now
        Dim currentYear As Integer = currentDate.Year
        Dim daylight As DaylightTime = localZone.GetDaylightChanges(currentYear)

        frmInfo.Text = "Info - Daylight Saving"

        If localZone.IsDaylightSavingTime(currentDate) Then
            frmInfo.GroupBox1.Text = "Summer Time"
        Else
            frmInfo.GroupBox1.Text = "Winter Time"
        End If

        frmInfo.Label1.Text = "Standard Time Name : " & localZone.StandardName
        frmInfo.Label2.Text = "Daylight Saving Time : " & localZone.DaylightName
        frmInfo.Label3.Text = "Daylight saving time for " & currentYear
        frmInfo.Label4.Text = String.Format(" Move the clocks forward {0} Hour on {1} at {2}", daylight.Delta.Hours, daylight.Start.ToLongDateString, daylight.Start.ToShortTimeString)
        frmInfo.Label5.Text = String.Format(" Move the clocks back {0} Hour on {1} at {2}", daylight.Delta.Hours, daylight.End.ToLongDateString, daylight.End.ToShortTimeString)

        frmInfo.ShowDialog()
    End Sub


    Private Sub CultureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CultureToolStripMenuItem.Click

        frmInfo.Text = "Info - Current Culture"
        frmInfo.GroupBox1.Text = "Current Culture"

        frmInfo.Label1.Text = "Current Culture Name : " & CultureInfo.CurrentCulture.EnglishName
        frmInfo.Label2.Text = "Three Letter ISO Name : " & CultureInfo.CurrentCulture.ThreeLetterISOLanguageName
        frmInfo.Label3.Text = "Full Date Time Pattern : " & CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern
        frmInfo.Label4.Text = "Currency Symbol : " & CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol
        frmInfo.Label5.Text = "First Day of the Week : " & CultureInfo.CurrentCulture.DateTimeFormat.DayNames(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)

        frmInfo.ShowDialog()
    End Sub

    Private Sub OSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OSToolStripMenuItem.Click

        frmInfo.Text = "Info - Operating System"
        frmInfo.GroupBox1.Text = "Operating System"

        frmInfo.Label1.Text = "Computer Name : " & My.Computer.Name.ToString
        frmInfo.Label2.Text = ""
        frmInfo.Label3.Text = "OS Full Name : " & My.Computer.Info.OSFullName
        frmInfo.Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
        frmInfo.Label5.Text = "OS Version : " & My.Computer.Info.OSVersion

        frmInfo.ShowDialog()
    End Sub


    Private Sub PowerSourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerSourceToolStripMenuItem.Click



        frmInfo.Text = "Info - Power Source"
        frmInfo.GroupBox1.Text = "Power Source"

        frmInfo.Label1.Text = Me.myManagedPower.powerSource()
        frmInfo.Label2.Text = ""
        frmInfo.Label3.Text = Me.myManagedPower.powerStatus()
        frmInfo.Label4.Text = Me.myManagedPower.chargingStatus()
        frmInfo.Label5.Text = ""

        frmInfo.ShowDialog()
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

        Me.usrsettings.usrTimeDisplayMinimised = IIf(Me.TlStrpMnItmTime.Checked, True, False)

    End Sub


    ' ********************************************************************************************************************************* END **************



End Class
