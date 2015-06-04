Imports Klock.frmOptions
Imports System.IO


Public Class frmKlock

    '   Main Klock application.       K. Scott    November 2012



    Public startTime As Integer

    '   Write debug onformation to test file - i.e. sw.writeLine("   ")
    '   uncomment following two lines and the close statements in form close.

    '   Dim fs As FileStream = New FileStream("debug.log", FileMode.Create)
    '   Dim sw As New StreamWriter(fs)

    Public displayTime As selectTime
    Public displayTimer As Timer
    Public displayAction As selectAction

    Public CountDownTime As Integer

    ' ************************************************************************************** clock routines **************************
    ' Seperate clocks are used for each function, to reduce load on main clock

    Private Sub TmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMain.Tick
        '   Main clock tick.
        '   Sets current time & date to status bar.
        '   Checks for Capps Lock, Num Lock & Scoll Lock - set message in status bar.

        Dim strKey As String = "cns"

        stsLblTime.Text = Format(Now, "Long Time")
        StsLblDate.Text = Format(Now, "Long Date")

        If My.Computer.Keyboard.CapsLock.ToString() Then
            strKey = Replace(strKey, "c", "C")
        End If
        If My.Computer.Keyboard.NumLock.ToString() Then
            strKey = Replace(strKey, "n", "N")
        End If
        If My.Computer.Keyboard.ScrollLock.ToString() Then
            strKey = Replace(strKey, "s", "S")
        End If

        StsLblKeys.Text = strKey

        LblTimeTime.Text = displayTime.getTime()                    '   display local time in desired time format.

        If Me.NtfyIcnKlock.Visible Then
            Me.NtfyIcnKlock.Text = displayTime.getTime()
        End If
    End Sub

    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        '   if enabled, timer is running - update timer label

        If My.Settings.usrTimerHigh Then                            '   are we displaying milliseconds in timer.
            lblTimerTime.Text = displayTimer.getHighElapsedTime()
        Else
            lblTimerTime.Text = displayTimer.getLowElapsedTime()
        End If

    End Sub

    Private Sub tmrCountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCountDown.Tick
        '   if enabled, countdown is running - clock ticks ever second.

        CountDownTime -= 1                                      '   decrement countdown every second.
        lblCountDownTime.Text = minsToString(CountDownTime)     '   update countdown label.

        If CountDownTime = 0 Then                               '   countdown has finished.
            CountDownClear()                                    '   clear down countdown.
            CountDownAction()                                   '   perform action.
        End If
    End Sub

    '   ********************************************************************************* time ****************************************

    Sub setTimeTypes()
        '   Loads the different time format types and load into combo box.

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        CmbBxTime.Items.AddRange(names)

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

        tmrTimer.Enabled = True

        btnTimerStop.Enabled = True
        btnTimerSplit.Enabled = True
        btnTimerStart.Enabled = False
        btnTimerClear.Enabled = False
    End Sub

    Private Sub btnTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStop.Click
        '   Stop the timer, allows to be resumed by renaming the start button.

        displayTimer.stopStopWatch()

        tmrTimer.Enabled = False

        btnTimerStop.Enabled = False
        btnTimerClear.Enabled = True

        btnTimerStart.Text = "Resume"
        btnTimerStart.Enabled = True
    End Sub

    Private Sub btnTimerClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerClear.Click
        '   Clears down the countdown, if enables also clear split time.

        displayTimer.clearStopWatch()

        btnTimerClear.Enabled = False
        btnTimerSplit.Enabled = False

        btnTimerStart.Text = "Start"
        btnTimerStart.Enabled = True

        If My.Settings.usrTimerClearSplit Then
            If My.Settings.usrTimerHigh Then
                lblTimerTime.Text = "00:00:00:00"
                lblTimerSplit.Text = "00:00:00:00"
            Else
                lblTimerTime.Text = "00:00:00"
                lblTimerSplit.Text = "00:00:00"
            End If
            btnTimerSplitClear.Enabled = False
        Else
            If My.Settings.usrTimerHigh Then
                lblTimerTime.Text = "00:00:00:00"
            Else
                lblTimerTime.Text = "00:00:00"
            End If
        End If

    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplit.Click
        '   Copies time to spli time.

        lblTimerSplit.Text = lblTimerTime.Text

        btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplitClear.Click
        '   Clears the split time.

        If My.Settings.usrTimerHigh Then
            lblTimerSplit.Text = "00:00:00:00"
        Else
            lblTimerSplit.Text = "00:00:00"
        End If

        btnTimerSplitClear.Enabled = False
    End Sub

    ' **************************************************************************************** CountDown ******************************
    Sub setActionTypes()
        '   Loads the different action types and load into combo box.   
        '   Loads the different system action types and load into combo box.

        Dim actionNames = System.Enum.GetNames(GetType(selectAction.ActionTypes))
        Dim systemNames = System.Enum.GetNames(GetType(selectAction.SystemTypes))

        CmbBxCountDownAction.Items.AddRange(actionNames)
        CmbBxCountDownSystem.Items.AddRange(systemNames)

        Me.CmbBxCountDownAction.SelectedIndex = 0       '   until I know how to do this at design time :o)

    End Sub

    Private Sub upDwnCntDownValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upDwnCntDownValue.ValueChanged
        '   when the up down counter has been changed, enable the start button and update the countdown label.
        btnCountDownStart.Enabled = True

        CountDownTime = upDwnCntDownValue.Value * 60
        lblCountDownTime.Text = minsToString(CountDownTime)
    End Sub

    Private Sub btnCountDownStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownStart.Click
        '   Start the countdown by enabling the timer.
        '   Also, enable the stop button and coundown label.

        tmrCountDown.Enabled = True

        btnCountDownStart.Enabled = False
        btnCountDownStop.Enabled = True
        upDwnCntDownValue.Enabled = False
        lblCountDownTime.Enabled = True
    End Sub

    Private Sub btnCountDownStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownStop.Click
        '   Clear the countdown.

        CountDownClear()
    End Sub

    Private Sub CmbBxCountDownAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxCountDownAction.SelectedIndexChanged
        '   Depending on the position of the action combo box, enable the apporiota action controls.

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
        '   Selects sound action conrols if checked.

        If ChckBxCountDownSound.Checked Then
            TxtBxAction.Enabled = True
            btnCountdownLoadSound.Enabled = True
        Else
            TxtBxAction.Enabled = False
            btnCountdownLoadSound.Enabled = False
            btnCountDownTestSound.Enabled = False
        End If

    End Sub

    Private Sub ChckBxCountDownReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownReminder.CheckedChanged
        '   Selects reminder action conrols if checked.

        If ChckBxCountDownReminder.Checked Then
            TxtBxCountDownReminder.Enabled = True
        Else
            TxtBxCountDownReminder.Enabled = False
        End If
    End Sub

    Private Sub ChckBxCountDownSystem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownSystem.CheckedChanged
        '   Selects countdown action conrols if checked.

        If ChckBxCountDownSystem.Checked Then
            CmbBxCountDownSystem.Enabled = True
        Else
            CmbBxCountDownSystem.Enabled = False
        End If
    End Sub

    Private Sub ChckBxCountDownCommand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxCountDownCommand.CheckedChanged
        '   Selects run command action conrols if checked.

        If ChckBxCountDownCommand.Checked Then
            TxtBxCountDowndCommand.Enabled = True
            btnCountDownLoadCommand.Enabled = True
        Else
            TxtBxCountDowndCommand.Enabled = False
            btnCountDownLoadCommand.Enabled = False
        End If
    End Sub

    Private Sub btnCountDownTestSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownTestSound.Click
        ' play sound in test button is pressed.

        displayAction.PlaySound(TxtBxAction.Text)
    End Sub

    Private Sub btnCountdownLoadSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountdownLoadSound.Click
        ' open file dialog to load sound file.

        OpenFileDialog1.Filter = "Sound Files|*.wav"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            btnCountDownTestSound.Enabled = True
            TxtBxAction.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub btnCountDownLoadCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCountDownLoadCommand.Click
        ' open file dialog to load command file.

        OpenFileDialog1.Filter = "All Files|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxCountDowndCommand.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Sub CountDownAction()
        '   When CountDown is finished, perform desired action

        If ChckBxCountDownSound.Checked Then                                '   do sound action.
            ChckBxCountDownSound.Checked = False
            TxtBxAction.Enabled = False
            btnCountdownLoadSound.Enabled = False
            btnCountDownTestSound.Enabled = False
            displayAction.PlaySound(TxtBxAction.Text)
        End If
        If ChckBxCountDownReminder.Checked Then                             '   do reminder action.
            ChckBxCountDownReminder.Checked = False
            TxtBxCountDownReminder.Enabled = False
            displayAction.DisplayReminder(TxtBxCountDownReminder.Text)
        End If
        If ChckBxCountDownSystem.Checked Then                               '   do system action action.
            ChckBxCountDownSystem.Checked = False
            CmbBxCountDownSystem.Enabled = False
            displayAction.DoSystemCommand(CmbBxCountDownSystem.SelectedIndex)
        End If
        If ChckBxCountDownCommand.Checked Then                              '   do run command action.
            ChckBxCountDownCommand.Checked = False
            TxtBxCountDowndCommand.Enabled = False
            btnCountDownLoadCommand.Enabled = False
            displayAction.DoCommand(TxtBxCountDowndCommand.Text)
        End If

    End Sub

    Sub CountDownClear()
        '   Clear down CountDown.

        tmrCountDown.Enabled = False
        lblCountDownTime.Text = "00:00"
        lblCountDownTime.Enabled = False
        upDwnCntDownValue.Enabled = True
        upDwnCntDownValue.Value = 0

        btnCountDownStart.Enabled = False
        btnCountDownStop.Enabled = False
    End Sub

    Function minsToString(ByVal m As Integer) As String
        '   re-format number of seconds in string in minuts and seconds [mm:ss].

        Dim hours As Integer
        Dim mins As Integer

        hours = m \ 60
        mins = m - (hours * 60)

        minsToString = String.Format("{0:00}:{1:00}", hours, mins)
    End Function

    Sub CountDownSound(ByVal b As Boolean)
        '   sets visible to b for all sound components

        ChckBxCountDownSound.Visible = b
        TxtBxAction.Visible = b
        btnCountdownLoadSound.Visible = b
        btnCountDownTestSound.Visible = b
    End Sub

    Sub CountDownReminder(ByVal b As Boolean)
        '   sets visible to b for all reminder components

        ChckBxCountDownReminder.Visible = b
        TxtBxCountDownReminder.Visible = b
    End Sub

    Sub CountDownSystem(ByVal b As Boolean)
        '   sets visible to b for all system components

        ChckBxCountDownSystem.Visible = b
        CmbBxCountDownSystem.Visible = b
    End Sub

    Sub CountDownCommand(ByVal b As Boolean)
        '   sets enable to b for all command components

        ChckBxCountDownCommand.Visible = b
        TxtBxCountDowndCommand.Visible = b
        btnCountDownLoadCommand.Visible = b
    End Sub
    ' ********************************************************************************************************************************


    Private Sub MnItmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnItmExit.Click
        '   Close application.

        Close()
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
        '   Display Settings Scrren and apply settings, they may have changed.

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

        If frmOptions.ChckBxOptionsSavePos.Checked Then
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

        If frmOptions.ChckBxOptionsSavePos.Checked Then
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
        Me.NtfyIcnKlock.Visible = False
        Me.Visible = True
    End Sub

    Private Sub TlStrpMnItmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmExit.Click
        Me.Close()
    End Sub

    Private Sub TlStrpMnItmTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TlStrpMnItmTime.Click

    End Sub

    ' *********************************************************************************************************************************


End Class
