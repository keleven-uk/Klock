﻿Imports Klock.frmOptions
Imports System.IO


Public Class frmKlock

    '   Main Klock application.       K. Scott    November 2012



    Public startTime As Integer

    '   Write debug information to test file - i.e. sw.writeLine("   ")
    '   uncomment following two lines and the close statements in form close.
    '   Dim fs As FileStream = New FileStream("debug.log", FileMode.Create)
    '   Dim sw As New StreamWriter(fs)

    Public displayTime As selectTime            '   instance of selectTime, allows different time formats.
    Public displayTimer As Timer                '   instance of timer, a wrapper of the stopwatch class.
    Public displayAction As selectAction        '   instance of selectAction, allows different actions to be performed.

    Public CountDownTime As Integer             '   Holds number of minutes for the countdown timer.
    Public ReminderDateTime As DateTime         '   Holds the date [and time] of the set reminder.

    Public knownFirstNames As New AutoCompleteStringCollection      '   Auto Complete for friends first name.
    Public knownMiddleNames As New AutoCompleteStringCollection     '   Auto Complete for friends middle name.
    Public knownLastnames As New AutoCompleteStringCollection       '   Auto Complete for friends last name.
    Public knownAddress1 As New AutoCompleteStringCollection        '   Auto Complete for friends address line 1.
    Public knownAddress2 As New AutoCompleteStringCollection        '   Auto Complete for friends address line 2.
    Public knownCities As New AutoCompleteStringCollection          '   Auto Complete for friends address city.
    Public knownPostCode As New AutoCompleteStringCollection        '   Auto Complete for friends address post code.
    Public knownCounties As New AutoCompleteStringCollection        '   Auto Complete for friends address county.

    ' ************************************************************************************** clock routines **************************
    ' Seperate clocks are used for each function, to reduce load on main clock

    Private Sub TmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMain.Tick
        '   Main clock tick.
        '   Sets current time & date to the status bar.
        '   Checks for Caps Lock, Num Lock & Scroll Lock - set message in status bar.

        Dim currentSecond As Integer = Now.TimeOfDay.TotalSeconds                    '  so, all use the same time.

        Me.NotificationDispaly(currentSecond)                                        '   display a notification, if desired
        Me.playHourlyChimes(currentSecond)                                           '   Play a hourly chime,  if desired.

        Me.updateStatusBar()

        Me.LblTimeTime.Text = Me.displayTime.getTime()                     '   display local time in desired time format.
        Me.TmrMain.Interval = Me.displayTime.getClockTick()

    End Sub

    Private Sub updateStatusBar()
        '    updates the status bar - time, date and status of caps, scroll and num lock keys.
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
    End Sub

    Private Sub playHourlyChimes(m As Integer)
        '   Depending upon user settings, will play hourly pips or chimes.
        '   The chimes can sound on the hour and every quarter hour if desired.

        If My.Settings.usrTimeHourPips And (Math.Floor(m Mod 3600) = 0) Then          '    will this work at midnight???

            Me.displayAction.PlaySound(Application.StartupPath & "\Sounds\thepips.mp3")     '    Play the Pips on the hour, if desired.
        ElseIf My.Settings.usrTimeHourlyChimes And (Math.Floor(m Mod 3600) = 0) Then             '    Play hourly chimes, if desired.

            Dim hours() As String = {"twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}
            Dim hour As Integer = Now.Hour

            If hour > 12 Then
                hour -= 12
            End If
            Me.displayAction.PlaySound(Application.StartupPath & "\Sounds\" & hours(hour) & ".mp3")
        ElseIf My.Settings.usrTimeQuarterChimes And (Math.Floor(m Mod 900) = 0) Then            '    Play quarter chimes, if desired.

            Me.displayAction.PlaySound(Application.StartupPath & "\Sounds\quarterchime.mp3")
        ElseIf My.Settings.usrTimeHalfChimes And (Math.Floor(m Mod 1800) = 0) Then              '    Play half hourly chimes, if desired.

            Me.displayAction.PlaySound(Application.StartupPath & "\Sounds\halfchime.mp3")
        ElseIf My.Settings.usrTimeThreeQuarterChimes And (Math.Floor(m Mod 2700) = 0) Then      '    Play three quarter chimes, if desired.

            Me.displayAction.PlaySound(Application.StartupPath & "\Sounds\threequarterchime.mp3")
        End If

    End Sub

    Private Sub NotificationDispaly(m As Integer)
        '   if desired, check the status of notifications - should display the time every five minutes.

        If Me.NtfyIcnKlock.Visible Then                     '   if in system tray,
            Me.NtfyIcnKlock.Text = displayTime.getTime()    '   set icon tool tip to current time.

            If My.Settings.usrTimeDisplayMinimised And (Math.Floor(m Mod 300) = 0) Then

                Me.displayAction.DisplayReminder("Time", displayTime.getTime())          ' display current time as a toast notification,if desired

            End If          '   If My.Settings.usrTimeDislayMinimised 
        End If              '   If Me.NtfyIcnKlock.Visible Then
    End Sub

    ' *************************************************************************************************************** timer clock ***********************
    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        '   if enabled, timer is running - update timer label

        If My.Settings.usrTimerHigh Then                            '   are we displaying milliseconds in timer.
            Me.lblTimerTime.Text = displayTimer.getHighElapsedTime()
        Else
            Me.lblTimerTime.Text = displayTimer.getLowElapsedTime()
        End If

    End Sub

    ' ******************************************************************************************************************* countdown clock ****************
    Private Sub tmrCountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountDown.Tick
        '   if enabled, countdown is running - clock ticks every second.

        Me.CountDownTime -= 1                                           '   decrement countdown every second.
        Me.lblCountDownTime.Text = Me.minsToString(Me.CountDownTime)    '   update countdown label.

        If Me.CountDownTime = 0 Then                                    '   countdown has finished.
            Me.CountDownAction()                                        '   perform action.
            Me.CountDownClear()                                         '   clear down countdown.
        End If
    End Sub

    ' ******************************************************************************************************************* reminder clock ******************

    Private Sub tmrReminder_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReminder.Tick
        '   if enabled, a reminder has been set - clocks ticks every 10 minute

        If Now() > Me.ReminderDateTime Then
            Me.ReminderAction()
            Me.clearReminder()                                             '   clear down reminder tab after action.
        End If

    End Sub

    '   *************************************************************************************** Global Tab Change ****************************************

    Private Sub TbCntrl_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TbCntrl.SelectedIndexChanged
        '    performed when ever the main tab is changed, used for any tab initalisation.

        Select Case Me.TbCntrl.SelectedIndex
            Case 0                                              '   time tab
                Me.Text = "Klock - tells you the time"
                Me.FriendsButtonsVisible(False)
            Case 1                                              '   countdown tab
                Me.Text = "Klock - Countdown the time"
                Me.FriendsButtonsVisible(False)
            Case 2                                              '   timer tab
                Me.Text = "Klock - measures the time"
                Me.FriendsButtonsVisible(False)
            Case 3                                              '   reminder tab
                Me.Text = "Klock - Reminds you of the time"
                Me.FriendsButtonsVisible(False)
                If My.Settings.usrReminderTimeChecked Then
                    Me.TmPckrRiminder.Enabled = True
                    Me.TmPckrRiminder.Value = Now()
                Else
                    Me.TmPckrRiminder.Enabled = False
                    Me.TmPckrRiminder.Value = Today
                End If
            Case 4
                Me.Text = "Klock - reminds you of your friends"
                Me.FriendsButtonsVisible(True)
        End Select

    End Sub

    '   ************************************************************************************************** time ****************************************

    Sub setTimeTypes()
        '   Loads the different time format types and load into combo box.

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        Me.CmbBxTime.Items.AddRange(names)

        Me.CmbBxTime.SelectedIndex = 0      '   until I know how to do this at design time :o)

    End Sub

    Private Sub CmbBxTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxTime.SelectedIndexChanged
        '   inform displayTime of the chosen time format.

        Me.displayTime.setType = CmbBxTime.SelectedIndex

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
            Me.lblTimerTime.Text = IIf(My.Settings.usrTimerHigh, "00:00:00:00", "00:00:00")
        End If

    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplit.Click
        '   Copies time to split time.

        Me.lblTimerSplit.Text = Me.lblTimerTime.Text

        Me.btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplitClear.Click
        '   Clears the split time.

        Me.lblTimerSplit.Text = IIf(My.Settings.usrTimerHigh, "00:00:00:00", "00:00:00")

        Me.btnTimerSplitClear.Enabled = False
    End Sub

    ' ************************************************************************************************************ Countdown ******************************
    Private Sub upDwnCntDownValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upDwnCntDownValue.ValueChanged
        '   when the up down counter has been changed, enable the start button and update the countdown label.

        Me.btnCountDownStart.Enabled = IIf(Me.upDwnCntDownValue.Value = 0, False, True)

        Me.CountDownTime = Me.upDwnCntDownValue.Value * 60
        Me.lblCountDownTime.Text = Me.minsToString(CountDownTime)
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

        Me.CountDownClear()
    End Sub

    Private Sub CmbBxCountDownAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxCountDownAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the appropriate  action controls.

        Select Case Me.CmbBxCountDownAction.SelectedIndex
            Case 0                                                  '   Sound chosen
                Me.CountDownSound(True)
                Me.CountDownReminder(False)
                Me.CountDownSystem(False)
                Me.CountDownCommand(False)
            Case 1                                                  '   Reminder chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(True)
                Me.CountDownSystem(False)
                Me.CountDownCommand(False)
            Case 2                                                  '   System action chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(False)
                Me.CountDownSystem(True)
                Me.CountDownCommand(False)
            Case 3                                                  '   Run Command chosen
                Me.CountDownSound(False)
                Me.CountDownReminder(False)
                Me.CountDownSystem(False)
                Me.CountDownCommand(True)
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
        Me.btnCountdownSystemAbort.Enabled = Not Me.btnCountdownSystemAbort.Enabled
    End Sub

    Private Sub ChckBxCountDownCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownCommand.CheckedChanged
        '   Selects run command action controls if checked.

        Me.TxtBxCountDowndCommand.Enabled = Not Me.TxtBxCountDowndCommand.Enabled
        Me.btnCountDownLoadCommand.Enabled = Not Me.btnCountDownLoadCommand.Enabled
    End Sub

    Private Sub btnCountDownTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownTestSound.Click
        ' play sound in test button is pressed.

        Me.displayAction.PlaySound(TxtBxCountDownAction.Text)
    End Sub

    Private Sub btnCountdownLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdownLoadSound.Click
        ' open file dialog to load sound file.

        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Sound Files|*.wav; *.mp3"
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
        '   Setting the checked to false fires the checkedChange sub, which turns off the appropiate controls.

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
            Me.btnCountdownSystemAbort.Enabled = True                          '   alow system command to be aborted.
            Me.displayAction.DoSystemCommand(CmbBxCountDownSystem.SelectedIndex)
        End If
        If Me.ChckBxCountDownCommand.Checked Then                              '   do run command action.
            Me.ChckBxCountDownCommand.Checked = False
            Me.displayAction.DoCommand(TxtBxCountDowndCommand.Text)
        End If

    End Sub

    Private Sub btnCountdownSystemAbort_Click(sender As System.Object, e As System.EventArgs) Handles btnCountdownSystemAbort.Click
        '   if abort pressed,  perform system command abort and start clean up.

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
        Me.btnCountdownSystemAbort.Visible = b
    End Sub

    Sub CountDownCommand(ByVal b As Boolean)
        '   sets enable to b for all command components

        Me.ChckBxCountDownCommand.Visible = b
        Me.TxtBxCountDowndCommand.Visible = b
        Me.btnCountDownLoadCommand.Visible = b
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
            Case 1                                                  '   Reminder chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(True)
                Me.ReminderSystem(False)
                Me.ReminderCommand(False)
            Case 2                                                  '   System action chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(False)
                Me.ReminderSystem(True)
                Me.ReminderCommand(False)
            Case 3                                                  '   Run Command chosen
                Me.ReminderSound(False)
                Me.ReminderReminder(False)
                Me.ReminderSystem(False)
                Me.ReminderCommand(True)
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

    Private Sub ChckBxReminderSystem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxReminderSystem.CheckedChanged
        '   Selects countdown action controls if checked.

        Me.CmbBxReminderSystem.Enabled = Not Me.CmbBxReminderSystem.Enabled
        Me.btnReminderSystemAbort.Enabled = Not Me.btnReminderSystemAbort.Enabled
    End Sub

    Private Sub chckBXReminderCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBXReminderCommand.CheckedChanged
        '   Selects run command action controls if checked.

        Me.TxtBxReminderCommand.Enabled = Not Me.TxtBxReminderCommand.Enabled
        Me.btnReminderLoadCommand.Enabled = Not Me.btnReminderLoadCommand.Enabled
    End Sub

    Private Sub btnReminderTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderTestSound.Click
        ' play sound in test button is pressed.

        Me.displayAction.PlaySound(TxtBxReminderAction.Text)
    End Sub

    Private Sub btnReminderLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderLoadSound.Click
        ' open file dialog to load sound file.

        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Sound Files|*.wav; *.mp3"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.btnReminderTestSound.Enabled = True
            Me.TxtBxReminderAction.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReminderLoadCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReminderLoadCommand.Click
        ' open file dialog to load command file.

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxReminderCommand.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Sub ReminderAction()
        '   When Reminder is finished, perform desired action
        '   Setting the checked to false fires the checkedChange sub, which turns off the appropiate controls.

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
            Me.btnReminderSystemAbort.Enabled = True                            '   alow system command to be aborted.
            Me.displayAction.DoSystemCommand(CmbBxReminderSystem.SelectedIndex)
        End If
        If Me.chckBXReminderCommand.Checked Then                                '   do run command action.
            Me.chckBXReminderCommand.Checked = False
            Me.displayAction.DoCommand(TxtBxReminderCommand.Text)
        End If

    End Sub

    Private Sub btnReminderSystemAbort_Click(sender As System.Object, e As System.EventArgs) Handles btnReminderSystemAbort.Click
        '   if abort pressed,  perform system command abort and start clean up.

        Me.displayAction.AbortSystemCommand()
        Me.btnReminderSystemAbort.Enabled = False

        Me.clearReminder()
    End Sub

    Private Sub btnReminderSet_Click(sender As System.Object, e As System.EventArgs) Handles btnReminderSet.Click
        '   Set a new reminder.  Sets appropiate text and sets the global reminder date for checking.
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

        If My.Settings.usrReminderTimeChecked Then
            Me.lblReminderText.Text = "Reminder set for " & d.ToLongDateString & " @ " & d.ToShortTimeString
        Else
            Me.lblReminderText.Text = "Reminder set for " & d.ToLongDateString
        End If

        Me.ReminderDateTime = d            '   set global, so can be checked by reminder timer.
    End Sub

    Private Sub btnReminderClear_Click(sender As System.Object, e As System.EventArgs) Handles btnReminderClear.Click
        '   clear reminder is pressed.

        Me.clearReminder()
    End Sub

    Private Sub clearReminder()
        '   perform the reminder clear.

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

        If My.Settings.usrReminderTimeChecked Then
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
        Me.btnReminderSystemAbort.Visible = b
    End Sub

    Private Sub ReminderCommand(ByVal b As Boolean)
        '   sets enable to b for all command components

        Me.chckBXReminderCommand.Visible = b
        Me.TxtBxReminderCommand.Visible = b
        Me.btnReminderLoadCommand.Visible = b
    End Sub

    Private Sub reminder_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DtPckrRiminder.ValueChanged, TmPckrRiminder.ValueChanged
        '   checks to see if the reminder date if in the furire [> now()], only then enable the set button.

        Dim d As New DateTime(Me.DtPckrRiminder.Value.Year, _
                         Me.DtPckrRiminder.Value.Month, _
                         Me.DtPckrRiminder.Value.Day, _
                         Me.TmPckrRiminder.Value.Hour, _
                         Me.TmPckrRiminder.Value.Minute, _
                         0)

        Me.btnReminderSet.Enabled = IIf(d > Now(), True, False)
    End Sub

    Private Sub ChckBxReminderTimeCheck_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxReminderTimeCheck.CheckedChanged
        '   allows the reminder date to include a time component.

        If Me.ChckBxReminderTimeCheck.Checked Then
            My.Settings.usrReminderTimeChecked = True
            Me.TmPckrRiminder.Enabled = True
            Me.TmPckrRiminder.Value = Now()
        Else
            My.Settings.usrReminderTimeChecked = False
            Me.TmPckrRiminder.Enabled = False
            Me.TmPckrRiminder.Value = Today
        End If
    End Sub

    ' **************************************************************************************************** Friends ****************************************

    Private Sub btnFriendsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriendsNew.Click

    End Sub

    Private Sub FriendsButtonsVisible(ByVal b As Boolean)

        Me.btnFriendsNew.Visible = b
        Me.btnFriendsAdd.Visible = b
        Me.btnFriendsClear.Visible = b
        Me.btnFriendsEdit.Visible = b
        Me.btnFriendsDelete.Visible = b
    End Sub

    Private Sub LoadAutoCompleteStuff()

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

        Me.normalFriendsDate()
    End Sub

    Private Sub blankFriendsDate()
        Me.DtPckrFriendsDOB.Format = DateTimePickerFormat.Custom
        Me.DtPckrFriendsDOB.CustomFormat = " "
        Me.DtPckrFriendsDOB.Checked = False
    End Sub

    Private Sub normalFriendsDate()
        Me.DtPckrFriendsDOB.Format = DateTimePickerFormat.Long
        Me.DtPckrFriendsDOB.CustomFormat = Now().Date
    End Sub

    ' ******************************************************************************************************************************** global stuff ******
    Private Sub frmKlock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   Apply current setting on form load.

        Me.startTime = My.Computer.Clock.TickCount      '   used for app rinning time.
        Me.displayTime = New selectTime
        Me.displayAction = New selectAction
        Me.displayTimer = New Timer

        Me.DtPckrFriendsDOB.MaxDate = Now()

        Me.setSettings()
        Me.setTimeTypes()
        Me.setActionTypes()
        Me.FriendsButtonsVisible(False)
        Me.blankFriendsDate()
        Me.LoadAutoCompleteStuff()

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
            Me.lblTimerTime.Text = "00:00:00:00"
            Me.lblTimerSplit.Text = "00:00:00:00"
        Else
            Me.lblTimerTime.Text = "00:00:00"
            Me.lblTimerSplit.Text = "00:00:00"
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


    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        '   hides main form and call system tray icon.

        Me.NtfyIcnKlock.Visible = True
        Me.Visible = False
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

    Private Sub helpKlock(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmSubHelp.Click
        '   Display Help Screen.

        frmHelp.ShowDialog()
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

    ' ****************************************************************************************************** context Strip Menu **************************
    ' menu loads when right clicking on tray icon

    Private Sub TlStrpMnItmShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmShow.Click, NtfyIcnKlock.MouseDoubleClick
        '   hide system tray icon and show main form.
        '   Called from system tray right click menu and double cliccking the tray icon.

        Me.NtfyIcnKlock.Visible = False
        Me.Visible = True
    End Sub

    Private Sub TlStrpMnItmTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmTime.CheckedChanged
        '   if checked, the system tray icon tooltip will be set to correct time [by main clock]

        My.Settings.usrTimeDisplayMinimised = IIf(Me.TlStrpMnItmTime.Checked, True, False)

    End Sub


    ' ********************************************************************************************************************************* END **************




End Class
