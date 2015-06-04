Imports Klock.frmOptions
Imports System.IO


Public Class frmKlock

    '   Main Klock application.       K. Scott    November 2012



    Public startTime As Integer

    '   Write debug information to test file - i.e. sw.writeLine("   ")
    '   uncomment following two lines and the close statements in form close.

    '   Dim fs As FileStream = New FileStream("debug.log", FileMode.Create)
    '   Dim sw As New StreamWriter(fs)

    Public displayTime As selectTime
    Public displayTimer As Timer
    Public displayAction As selectAction

    Public CountDownTime As Integer
    Public ReminderDateTime As DateTime

    ' ************************************************************************************** clock routines **************************
    ' Seperate clocks are used for each function, to reduce load on main clock

    Private Sub TmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMain.Tick
        '   Main clock tick.
        '   Sets current time & date to status bar.
        '   Checks for Caps Lock, Num Lock & Scroll Lock - set message in status bar.

        Dim strKey As String = "cns"

        Me.stsLblTime.Text = Format(Now, "Long Time")
        Me.StsLblDate.Text = Format(Now, "Long Date")

        If My.Computer.Keyboard.CapsLock.ToString() Then
            strKey = Replace(strKey, "c", "C")
        End If
        If My.Computer.Keyboard.NumLock.ToString() Then
            strKey = Replace(strKey, "n", "N")
        End If
        If My.Computer.Keyboard.ScrollLock.ToString() Then
            strKey = Replace(strKey, "s", "S")
        End If

        Me.StsLblKeys.Text = strKey

        Me.LblTimeTime.Text = displayTime.getTime()                     '   display local time in desired time format.
        Me.TmrMain.Interval = displayTime.getClockTick()

        NotificationDispaly()                                           '   display a notification, if desired
        playHourlyChimes()                                              '   Play a hourly chime,  if desired.

        If Me.btnReminderClear.Enabled Then                             '   a reminder is set, so check.
            checkReminder()                                             '   [clear is only enabled once the reminder has been set]
        End If
    End Sub

    Private Sub checkReminder()

        If Now() > ReminderDateTime Then
            ReminderAction()
            clearReminder()                                             '   clear down reminder tab after action.
        End If

    End Sub

    Private Sub playHourlyChimes()
        '   Depending upon user settings, will play hourly pips or chimes.
        '   The chimes can sound on the hour and every quarter hour if desired.

        Dim hours() As String = {"twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}
        Dim hour As Integer = 0

        hour = Now.Hour

        If hour > 12 Then
            hour -= 12
        End If

        If My.Settings.usrTimeHourPips And (Math.Floor(Now.TimeOfDay.TotalSeconds Mod 3600) = 0) Then          '    will this work at midnight???
            displayAction.PlaySound(Application.StartupPath & "\Sounds\" & hours(hour) & ".wav")               '    Play the Pips on the hour, if desired.
        ElseIf My.Settings.usrTimeHourlyChimes And (Math.Floor(Now.TimeOfDay.TotalSeconds Mod 3600) = 0) Then  '    Play hourly chimes, if desired.
            displayAction.PlaySound(Application.StartupPath & "\Sounds\quarterchime.wav")
        ElseIf My.Settings.usrTimeQuarterChimes And (Math.Floor(Now.TimeOfDay.TotalSeconds Mod 900) = 0) Then  '    Play quarter chimes, if desired.
            displayAction.PlaySound(Application.StartupPath & "\Sounds\quarterchime.wav")
        ElseIf My.Settings.usrTimeHalfChimes And (Math.Floor(Now.TimeOfDay.TotalSeconds Mod 1800) = 0) Then    '    Play half hourly chimes, if desired.
            displayAction.PlaySound(Application.StartupPath & "\Sounds\halfchime.wav")
        ElseIf My.Settings.usrTimeThreeQuarterChimes And (Math.Floor(Now.TimeOfDay.TotalSeconds Mod 2700) = 0) Then '    Play three quarter chimes, if desired.
            displayAction.PlaySound(Application.StartupPath & "\Sounds\threequarterchime.wav")
        End If

    End Sub

    Private Sub NotificationDispaly()

        If Me.NtfyIcnKlock.Visible Then                     '   if in system tray,
            Me.NtfyIcnKlock.Text = displayTime.getTime()    '   set icon tool tip to current time.

            If My.Settings.usrTimeDisplayMinimised And (Math.Floor(Now.TimeOfDay.TotalSeconds Mod 300) = 0) Then

                displayAction.DisplayReminder("Time", displayTime.getTime())                    ' display current time as a toast notification,if desired

            End If          '   If My.Settings.usrTimeDislayMinimised 
        End If              '   If Me.NtfyIcnKlock.Visible Then
    End Sub

    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        '   if enabled, timer is running - update timer label

        If My.Settings.usrTimerHigh Then                            '   are we displaying milliseconds in timer.
            Me.lblTimerTime.Text = displayTimer.getHighElapsedTime()
        Else
            Me.lblTimerTime.Text = displayTimer.getLowElapsedTime()
        End If

    End Sub

    Private Sub tmrCountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountDown.Tick
        '   if enabled, countdown is running - clock ticks ever second.

        CountDownTime -= 1                                      '   decrement countdown every second.
        Me.lblCountDownTime.Text = minsToString(CountDownTime)     '   update countdown label.

        If CountDownTime = 0 Then                               '   countdown has finished.
            CountDownClear()                                    '   clear down countdown.
            CountDownAction()                                   '   perform action.
        End If
    End Sub

    '   ******************************************************************** Global Tab Change ****************************************

    Private Sub TbCntrl_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TbCntrl.SelectedIndexChanged
        '    performed when ever the main tab is changed, used for any tab initalisation.

        Select Case TbCntrl.SelectedIndex
            Case 0                                              '   time tab
            Case 1                                              '   countdown tab

            Case 2                                              '   timer tab

            Case 3                                              '   reminder tab
                If My.Settings.usrReminderTimeChecked Then
                    Me.TmPckrRiminder.Enabled = True
                    Me.TmPckrRiminder.Value = Now()
                Else
                    Me.TmPckrRiminder.Enabled = False
                    Me.TmPckrRiminder.Value = Today
                End If
        End Select

    End Sub

    '   ********************************************************************************* time ****************************************

    Sub setTimeTypes()
        '   Loads the different time format types and load into combo box.

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        Me.CmbBxTime.Items.AddRange(names)

        Me.CmbBxTime.SelectedIndex = 0      '   until I know how to do this at design time :o)

    End Sub

    Private Sub CmbBxTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxTime.SelectedIndexChanged
        '   inform displayTime of the chosen time format.

        displayTime.setType = CmbBxTime.SelectedIndex

    End Sub

    '   ********************************************************************************* timer ***************************************

    Private Sub btnTimerStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStart.Click
        '   Start the timer

        displayTimer.startStopWatch()

        Me.tmrTimer.Enabled = True

        Me.btnTimerStop.Enabled = True
        Me.btnTimerSplit.Enabled = True
        Me.btnTimerStart.Enabled = False
        Me.btnTimerClear.Enabled = False
    End Sub

    Private Sub btnTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStop.Click
        '   Stop the timer, allows to be resumed by renaming the start button.

        displayTimer.stopStopWatch()

        Me.tmrTimer.Enabled = False

        Me.btnTimerStop.Enabled = False
        Me.btnTimerClear.Enabled = True

        Me.btnTimerStart.Text = "Resume"
        Me.btnTimerStart.Enabled = True
    End Sub

    Private Sub btnTimerClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerClear.Click
        '   Clears down the countdown, if enables also clear split time.

        displayTimer.clearStopWatch()

        Me.btnTimerClear.Enabled = False
        Me.btnTimerSplit.Enabled = False

        Me.btnTimerStart.Text = "Start"
        Me.btnTimerStart.Enabled = True

        If My.Settings.usrTimerClearSplit Then
            If My.Settings.usrTimerHigh Then
                Me.lblTimerTime.Text = "00:00:00:00"
                Me.lblTimerSplit.Text = "00:00:00:00"
            Else
                Me.lblTimerTime.Text = "00:00:00"
                Me.lblTimerSplit.Text = "00:00:00"
            End If
            Me.btnTimerSplitClear.Enabled = False
        Else
            If My.Settings.usrTimerHigh Then
                Me.lblTimerTime.Text = "00:00:00:00"
            Else
                Me.lblTimerTime.Text = "00:00:00"
            End If
        End If

    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplit.Click
        '   Copies time to split time.

        Me.lblTimerSplit.Text = lblTimerTime.Text

        Me.btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplitClear.Click
        '   Clears the split time.

        If My.Settings.usrTimerHigh Then
            Me.lblTimerSplit.Text = "00:00:00:00"
        Else
            Me.lblTimerSplit.Text = "00:00:00"
        End If

        Me.btnTimerSplitClear.Enabled = False
    End Sub

    ' **************************************************************************************** Countdown ******************************
    Private Sub upDwnCntDownValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upDwnCntDownValue.ValueChanged
        '   when the up down counter has been changed, enable the start button and update the countdown label.
        Me.btnCountDownStart.Enabled = True

        CountDownTime = upDwnCntDownValue.Value * 60
        Me.lblCountDownTime.Text = minsToString(CountDownTime)
    End Sub

    Private Sub btnCountDownStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownStart.Click
        '   Start the countdown by enabling the timer.
        '   Also, enable the stop button and countdown label.

        Me.tmrCountDown.Enabled = True

        Me.btnCountDownStart.Enabled = False
        Me.btnCountDownStop.Enabled = True
        Me.upDwnCntDownValue.Enabled = False
        Me.lblCountDownTime.Enabled = True
    End Sub

    Private Sub btnCountDownStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownStop.Click
        '   Clear the countdown.

        CountDownClear()
    End Sub

    Private Sub CmbBxCountDownAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxCountDownAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate  action controls.

        Select Case Me.CmbBxCountDownAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                CountDownSound(True)
                CountDownReminder(False)
                CountDownSystem(False)
                CountDownCommand(False)
            Case 1                                                  '   Reminder chosen
                CountDownSound(False)
                CountDownReminder(True)
                CountDownSystem(False)
                CountDownCommand(False)
            Case 2                                                  '   System action chosen
                CountDownSound(False)
                CountDownReminder(False)
                CountDownSystem(True)
                CountDownCommand(False)
            Case 3                                                  '   Run Command chosen
                CountDownSound(False)
                CountDownReminder(False)
                CountDownSystem(False)
                CountDownCommand(True)
        End Select

    End Sub


    Private Sub ChckBxCountDownSound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownSound.CheckedChanged
        '   Selects sound action controls if checked.

        If Me.ChckBxCountDownSound.Checked Then
            Me.TxtBxCountDownAction.Enabled = True
            Me.btnCountdownLoadSound.Enabled = True
        Else
            Me.TxtBxCountDownAction.Enabled = False
            Me.btnCountdownLoadSound.Enabled = False
            Me.btnCountDownTestSound.Enabled = False
        End If

    End Sub

    Private Sub ChckBxCountDownReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownReminder.CheckedChanged
        '   Selects reminder action controls if checked.

        If Me.ChckBxCountDownReminder.Checked Then
            Me.TxtBxCountDownReminder.Enabled = True
        Else
            Me.TxtBxCountDownReminder.Enabled = False
        End If
    End Sub

    Private Sub ChckBxCountDownSystem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownSystem.CheckedChanged
        '   Selects countdown action controls if checked.

        If Me.ChckBxCountDownSystem.Checked Then
            Me.CmbBxCountDownSystem.Enabled = True
        Else
            Me.CmbBxCountDownSystem.Enabled = False
        End If
    End Sub

    Private Sub ChckBxCountDownCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownCommand.CheckedChanged
        '   Selects run command action controls if checked.

        If Me.ChckBxCountDownCommand.Checked Then
            Me.TxtBxCountDowndCommand.Enabled = True
            Me.btnCountDownLoadCommand.Enabled = True
        Else
            Me.TxtBxCountDowndCommand.Enabled = False
            Me.btnCountDownLoadCommand.Enabled = False
        End If
    End Sub

    Private Sub btnCountDownTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownTestSound.Click
        ' play sound in test button is pressed.

        displayAction.PlaySound(TxtBxCountDownAction.Text)
    End Sub

    Private Sub btnCountdownLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdownLoadSound.Click
        ' open file dialog to load sound file.

        Me.OpenFileDialog1.Filter = "Sound Files|*.wav"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.btnCountDownTestSound.Enabled = True
            Me.TxtBxCountDownAction.Text = Me.OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub btnCountDownLoadCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownLoadCommand.Click
        ' open file dialog to load command file.

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxCountDowndCommand.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Sub CountDownAction()
        '   When Countdown is finished, perform desired action

        If Me.ChckBxCountDownSound.Checked Then                                '   do sound action.
            Me.ChckBxCountDownSound.Checked = False
            Me.TxtBxCountDownAction.Enabled = False
            Me.btnCountdownLoadSound.Enabled = False
            Me.btnCountDownTestSound.Enabled = False
            displayAction.PlaySound(TxtBxCountDownAction.Text)
        End If
        If Me.ChckBxCountDownReminder.Checked Then                             '   do reminder action.
            Me.ChckBxCountDownReminder.Checked = False
            Me.TxtBxCountDownReminder.Enabled = False
            displayAction.DisplayReminder("CountDown", TxtBxCountDownReminder.Text)
        End If
        If Me.ChckBxCountDownSystem.Checked Then                               '   do system action action.
            Me.ChckBxCountDownSystem.Checked = False
            Me.CmbBxCountDownSystem.Enabled = False
            displayAction.DoSystemCommand(CmbBxCountDownSystem.SelectedIndex)
        End If
        If Me.ChckBxCountDownCommand.Checked Then                              '   do run command action.
            Me.ChckBxCountDownCommand.Checked = False
            Me.TxtBxCountDowndCommand.Enabled = False
            Me.btnCountDownLoadCommand.Enabled = False
            displayAction.DoCommand(TxtBxCountDowndCommand.Text)
        End If

    End Sub

    Sub CountDownClear()
        '   Clear down Countdown.

        Me.tmrCountDown.Enabled = False
        Me.lblCountDownTime.Text = "00:00"
        Me.lblCountDownTime.Enabled = False
        Me.upDwnCntDownValue.Enabled = True
        Me.upDwnCntDownValue.Value = 0

        Me.btnCountDownStart.Enabled = False
        Me.btnCountDownStop.Enabled = False
    End Sub

    Function minsToString(ByVal m As Integer) As String
        '   reformat number of seconds in string in minutes and seconds [mm:ss].

        Dim hours As Integer
        Dim mins As Integer

        hours = m \ 60
        mins = m - (hours * 60)

        minsToString = String.Format("{0:00}:{1:00}", hours, mins)
    End Function

    Sub CountDownSound(ByVal b As Boolean)
        '   sets visible to b for all sound components

        Me.ChckBxCountDownSound.Visible = b
        Me.TxtBxCountDownAction.Visible = b
        Me.btnCountdownLoadSound.Visible = b
        Me.btnCountDownTestSound.Visible = b
    End Sub

    Sub CountDownReminder(ByVal b As Boolean)
        '   sets visible to b for all reminder components

        Me.ChckBxCountDownReminder.Visible = b
        Me.TxtBxCountDownReminder.Visible = b
    End Sub

    Sub CountDownSystem(ByVal b As Boolean)
        '   sets visible to b for all system components

        Me.ChckBxCountDownSystem.Visible = b
        Me.CmbBxCountDownSystem.Visible = b
    End Sub

    Sub CountDownCommand(ByVal b As Boolean)
        '   sets enable to b for all command components

        Me.ChckBxCountDownCommand.Visible = b
        Me.TxtBxCountDowndCommand.Visible = b
        Me.btnCountDownLoadCommand.Visible = b
    End Sub

    ' ******************************************************************************* Reminder ****************************************

    Private Sub CmbBxReminderAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxReminderAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate action controls.

        Select Case Me.CmbBxReminderAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                ReminderSound(True)
                ReminderReminder(False)
                ReminderSystem(False)
                ReminderCommand(False)
            Case 1                                                  '   Reminder chosen
                ReminderSound(False)
                ReminderReminder(True)
                ReminderSystem(False)
                ReminderCommand(False)
            Case 2                                                  '   System action chosen
                ReminderSound(False)
                ReminderReminder(False)
                ReminderSystem(True)
                ReminderCommand(False)
            Case 3                                                  '   Run Command chosen
                ReminderSound(False)
                ReminderReminder(False)
                ReminderSystem(False)
                ReminderCommand(True)
        End Select
    End Sub


    Private Sub ChckBxReminderSound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderSound.CheckedChanged
        '   Selects sound action controls if checked.

        If Me.ChckBxReminderSound.Checked Then
            Me.TxtBxReminderAction.Enabled = True
            Me.btnReminderLoadSound.Enabled = True
        Else
            Me.TxtBxReminderAction.Enabled = False
            Me.btnReminderLoadSound.Enabled = False
            Me.btnReminderTestSound.Enabled = False
        End If
    End Sub

    Private Sub ChckBxReminderReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxReminderReminder.CheckedChanged
        '   Selects reminder action controls if checked.

        If Me.ChckBxReminderReminder.Checked Then
            Me.TxtBxReminderReminder.Enabled = True
        Else
            Me.TxtBxReminderReminder.Enabled = False
        End If
    End Sub

    Private Sub CmbBxReminderSystem_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxReminderSystem.DropDownClosed
        '   Selects countdown action controls if checked.

        If Me.ChckBxReminderSystem.Checked Then
            Me.CmbBxReminderSystem.Enabled = True
        Else
            Me.CmbBxReminderSystem.Enabled = False
        End If
    End Sub

    Private Sub chckBXReminderCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBXReminderCommand.CheckedChanged
        '   Selects run command action controls if checked.

        If Me.chckBXReminderCommand.Checked Then
            Me.TxtBxReminderCommand.Enabled = True
            Me.btnReminderLoadCommand.Enabled = True
        Else
            Me.TxtBxReminderCommand.Enabled = False
            Me.btnReminderLoadCommand.Enabled = False
        End If
    End Sub

    Private Sub btnReminderTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderTestSound.Click
        ' play sound in test button is pressed.

        displayAction.PlaySound(TxtBxReminderAction.Text)
    End Sub

    Private Sub btnReminderLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderLoadSound.Click
        ' open file dialog to load sound file.

        Me.OpenFileDialog1.Filter = "Sound Files|*.wav"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.btnReminderTestSound.Enabled = True
            Me.TxtBxReminderAction.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReminderLoadCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderLoadCommand.Click
        ' open file dialog to load command file.

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxReminderCommand.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Sub ReminderAction()
        '   When Reminder is finished, perform desired action

        If Me.ChckBxReminderSound.Checked Then                                  '   do sound action.
            Me.ChckBxReminderSound.Checked = False
            Me.TxtBxReminderAction.Enabled = False
            Me.btnReminderLoadSound.Enabled = False
            Me.btnReminderTestSound.Enabled = False
            displayAction.PlaySound(TxtBxReminderAction.Text)
        End If
        If Me.ChckBxReminderReminder.Checked Then                               '   do reminder action.
            Me.ChckBxReminderReminder.Checked = False
            Me.TxtBxReminderReminder.Enabled = False
            displayAction.DisplayReminder("Reminder", TxtBxReminderReminder.Text)
        End If
        If Me.ChckBxReminderSystem.Checked Then                                 '   do system action action.
            Me.ChckBxReminderSystem.Checked = False
            Me.CmbBxReminderSystem.Enabled = False
            displayAction.DoSystemCommand(CmbBxReminderSystem.SelectedIndex)
        End If
        If Me.chckBXReminderCommand.Checked Then                                '   do run command action.
            Me.chckBXReminderCommand.Checked = False
            Me.TxtBxReminderCommand.Enabled = False
            Me.btnReminderLoadCommand.Enabled = False
            displayAction.DoCommand(TxtBxReminderCommand.Text)
        End If

    End Sub

    Private Sub btnReminderSet_Click(sender As System.Object, e As System.EventArgs) Handles btnReminderSet.Click

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year, _
                         Me.DtPckrRiminder.Value.Month, _
                         Me.DtPckrRiminder.Value.Day, _
                         Me.TmPckrRiminder.Value.Hour, _
                         Me.TmPckrRiminder.Value.Second, _
                         0)

        Me.btnReminderSet.Enabled = False
        Me.btnReminderClear.Enabled = True
        Me.DtPckrRiminder.Visible = False
        Me.ChckBxReminderTimeCheck.Visible = False
        Me.TmPckrRiminder.Visible = False



        If My.Settings.usrReminderTimeChecked Then
            lblReminderText.Text = "Reminder set for " & d.ToLongDateString & " : " & d.ToShortTimeString
        Else
            lblReminderText.Text = "Reminder set for " & d.ToLongDateString
        End If

        ReminderDateTime = d            '   set global, so can be checked by main timer.
    End Sub

    Private Sub btnReminderClear_Click(sender As System.Object, e As System.EventArgs) Handles btnReminderClear.Click

        clearReminder()
    End Sub

    Private Sub clearReminder()

        Me.DtPckrRiminder.Visible = True
        Me.ChckBxReminderTimeCheck.Visible = True
        Me.TmPckrRiminder.Visible = True

        Me.btnReminderClear.Enabled = False

        Me.DtPckrRiminder.Value = Today
        If My.Settings.usrReminderTimeChecked Then
            Me.TmPckrRiminder.Enabled = True
            Me.TmPckrRiminder.Value = Now()
        Else
            Me.TmPckrRiminder.Enabled = False
            Me.TmPckrRiminder.Value = Today
        End If

        lblReminderText.Text = "Reminder Not set"
    End Sub

    Sub ReminderSound(ByVal b As Boolean)
        '   sets visible to b for all sound components

        Me.ChckBxReminderSound.Visible = b
        Me.TxtBxReminderAction.Visible = b
        Me.btnReminderLoadSound.Visible = b
        Me.btnReminderTestSound.Visible = b
    End Sub

    Private Sub ReminderReminder(ByVal b As Boolean)
        '   sets visible to b for all reminder components

        Me.ChckBxReminderReminder.Visible = b
        Me.TxtBxReminderReminder.Visible = b
    End Sub

    Private Sub ReminderSystem(ByVal b As Boolean)
        '   sets visible to b for all system components

        Me.ChckBxReminderSystem.Visible = b
        Me.CmbBxReminderSystem.Visible = b
    End Sub

    Private Sub ReminderCommand(ByVal b As Boolean)
        '   sets enable to b for all command components

        Me.chckBXReminderCommand.Visible = b
        Me.TxtBxReminderCommand.Visible = b
        btnReminderLoadCommand.Visible = b
    End Sub

    Private Sub DtPckrRiminder_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtPckrRiminder.ValueChanged

        If validateDateTime() Then
            Me.btnReminderSet.Enabled = True
        Else
            Me.btnReminderSet.Enabled = False
        End If

    End Sub

    Private Sub TmPckrRiminder_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TmPckrRiminder.ValueChanged

        If validateDateTime() Then
            Me.btnReminderSet.Enabled = True
        Else
            Me.btnReminderSet.Enabled = False
        End If

    End Sub

    Private Sub ChckBxReminderTimeCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxReminderTimeCheck.CheckedChanged

        If ChckBxReminderTimeCheck.Checked Then
            My.Settings.usrReminderTimeChecked = True
            Me.TmPckrRiminder.Enabled = True
            Me.TmPckrRiminder.Value = Now()
        Else
            My.Settings.usrReminderTimeChecked = False
            Me.TmPckrRiminder.Enabled = False
            Me.TmPckrRiminder.Value = Today
        End If

    End Sub

    Private Function validateDateTime() As Boolean

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year, _
                                 Me.DtPckrRiminder.Value.Month, _
                                 Me.DtPckrRiminder.Value.Day, _
                                 Me.TmPckrRiminder.Value.Hour, _
                                 Me.TmPckrRiminder.Value.Second, _
                                 0)

        If d > Now() Then
            validateDateTime = True
        Else
            validateDateTime = False

        End If

    End Function


    ' ********************************************************************************************************************************


    Private Sub MnItmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmExit.Click
        '   Close application.

        Me.Close()
    End Sub

    Private Sub MnItmAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmAbout.Click
        '   Display About screen.

        frmAbout.ShowDialog()
    End Sub

    Private Sub MnItmSubHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmSubHelp.Click
        '   Display Help Screen.

        frmHelp.ShowDialog()
    End Sub

    Private Sub LicenseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmLicense.Click
        '   Display License Screen.

        frmLicence.ShowDialog()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmOptions.Click
        '   Display Settings Screen and apply settings, they may have changed.

        frmOptions.ShowDialog()
        setSettings()
    End Sub

    Private Sub frmKlock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   Apply current setting on form load.

        startTime = My.Computer.Clock.TickCount
        displayTime = New selectTime
        displayAction = New selectAction
        displayTimer = New Timer

        setSettings()
        setTimeTypes()
        setActionTypes()
    End Sub

    Private Sub frmKlock_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '   on close and if needed, save form position.

        If My.Settings.usrSavePos Then
            My.Settings.usrFormTop = Me.Top
            My.Settings.usrFormLeft = Me.Left
        End If

        '   fs.Close()
        '   sw.Close()

    End Sub

    Sub setSettings()
        '   Apply current settings,

        Me.BackColor = My.Settings.usrFormColour
        Me.StsStrpInfo.BackColor = My.Settings.usrFormColour
        Me.MainMenuStrip.BackColor = My.Settings.usrFormColour

        Me.TbPgTime.BackColor = My.Settings.usrFormColour
        Me.TbPgCountDown.BackColor = My.Settings.usrFormColour
        Me.TbPgTimer.BackColor = My.Settings.usrFormColour
        Me.TbPgReminder.BackColor = My.Settings.usrFormColour

        If My.Settings.usrSavePos Then
            Me.Top = My.Settings.usrFormTop
            Me.Left = My.Settings.usrFormLeft
        End If

        If My.Settings.usrTimerHigh Then
            lblTimerTime.Text = "00:00:00:00"
            lblTimerSplit.Text = "00:00:00:00"
        Else
            lblTimerTime.Text = "00:00:00"
            lblTimerSplit.Text = "00:00:00"
        End If

        Me.TlStrpMnItmTime.Checked = My.Settings.usrTimeDisplayMinimised
        Me.ChckBxReminderTimeCheck.Checked = My.Settings.usrReminderTimeChecked

    End Sub

    Sub setActionTypes()
        '   Loads the different action types and load into combo box.   
        '   Loads the different system action types and load into combo box.

        Dim actionNames = System.Enum.GetNames(GetType(selectAction.ActionTypes))
        Dim systemNames = System.Enum.GetNames(GetType(selectAction.SystemTypes))

        Me.CmbBxCountDownAction.Items.AddRange(actionNames)
        Me.CmbBxCountDownSystem.Items.AddRange(systemNames)

        Me.CmbBxReminderAction.Items.AddRange(actionNames)
        Me.CmbBxReminderSystem.Items.AddRange(systemNames)

        Me.CmbBxCountDownAction.SelectedIndex = 0       '   until I know how to do this at design time :o)
        Me.CmbBxReminderAction.SelectedIndex = 0
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        '   hides main form and call system tray icon.

        Me.NtfyIcnKlock.Visible = True
        Me.Visible = False
    End Sub
    ' *********************************************************************************** context Strip Menu **************************
    ' menu loads when right clicking on tray icon

    Private Sub TlStrpMnItmShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmShow.Click
        '   hide system tray icon and show main form.

        Me.NtfyIcnKlock.Visible = False
        Me.Visible = True
    End Sub

    Private Sub NtfyIcnKlock_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NtfyIcnKlock.MouseDoubleClick
        '   hide system tray icon and show main form.

        Me.NtfyIcnKlock.Visible = False
        Me.Visible = True
    End Sub

    Private Sub TlStrpMnItmTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmTime.CheckedChanged
        '   if checked, the system tray icon tooltip will be set to correct time [by main clock]

        If TlStrpMnItmTime.Checked = True Then
            My.Settings.usrTimeDisplayMinimised = True
        Else
            My.Settings.usrTimeDisplayMinimised = False
        End If

    End Sub

    Private Sub TlStrpMnItmOptions_Click(sender As System.Object, e As System.EventArgs) Handles TlStrpMnItmOptions.Click

        frmOptions.ShowDialog()
        setSettings()
    End Sub

    Private Sub TlStrpMnItmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmExit.Click
        '   close klock

        Me.Close()
    End Sub


    ' *********************************************************************************************************************************






End Class
