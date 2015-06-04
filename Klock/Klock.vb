Imports Klock.frmOptions
Imports System.IO


Public Class frmKlock

    '   Main Klock application.       K. Scott    November 2012

    '   A VB 2010 template, a starter for future projects.

    Public startTime As Integer

    '   Write debug onformation to test file - i.e. sw.writeLine("   ")
    '   uncomment following two lines and the close statements in form close.
    '   Dim fs As FileStream = New FileStream("debug.log", FileMode.Create)
    '   Dim sw As New StreamWriter(fs)

    Public displayTime As selectTime
    Public displayTimer As Timer

    ' ************************************************************************************** timer routines **************************
    ' Seperate timers are used for each function, to reduce load on main timer


    Private Sub TmrMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrMain.Tick
        '   Main clock tick.
        '   Sets current time & date to status bar.
        '   Checks for Capps Lock, Mum Lock & Scoll Lock - set message in status bar.

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
        LblTimeTime.Text = displayTime.getTime()

    End Sub

    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
        '   if enabled, timer is running - update timer label

        lblTimerTime.Text = displayTimer.getHighElapsedTime()
    End Sub

    '   ********************************************************************************* time ****************************************

    Sub setTimeTypes()

        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))

        CmbBxTime.Items.AddRange(names)

        Me.CmbBxTime.SelectedIndex = 0      '   until I know how to do this at design time :o)
        Me.CmbBxCountDownAction.SelectedIndex = 0

    End Sub

    Private Sub CmbBxTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBxTime.SelectedIndexChanged
        displayTime.setType = CmbBxTime.SelectedIndex

    End Sub

    '   ********************************************************************************* timer ***************************************

    Private Sub btnTimerStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStart.Click
        displayTimer.startStopWatch()

        tmrTimer.Enabled = True

        btnTimerStop.Enabled = True
        btnTimerSplit.Enabled = True
        btnTimerStart.Enabled = False
        btnTimerClear.Enabled = False
    End Sub

    Private Sub btnTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerStop.Click
        displayTimer.stopStopWatch()

        tmrTimer.Enabled = False

        btnTimerStop.Enabled = False
        btnTimerClear.Enabled = True

        btnTimerStart.Text = "Resume"
        btnTimerStart.Enabled = True
    End Sub

    Private Sub btnTimerClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerClear.Click
        displayTimer.clearStopWatch()

        btnTimerClear.Enabled = False
        btnTimerSplit.Enabled = False

        btnTimerStart.Text = "Start"
        btnTimerStart.Enabled = True

        lblTimerTime.Text = "00:00"

    End Sub

    Private Sub btnTimerSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplit.Click
        lblTimerSplit.Text = lblTimerTime.Text

        btnTimerSplitClear.Enabled = True
    End Sub

    Private Sub btnTimerSplitClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimerSplitClear.Click

        lblTimerSplit.Text = "00:00:00"

        btnTimerSplitClear.Enabled = False
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
        displayTimer = New Timer

        setSettings()
        setTimeTypes()
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
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    ' *********************************************************************************************************************************




End Class
