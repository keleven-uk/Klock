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

    End Sub

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

    Private Sub Stub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   Apply current setting on form load.

        startTime = My.Computer.Clock.TickCount

        setSettings()
    End Sub

    Private Sub frmStub_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        '   on close and if needed, save sform position.

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

        If frmOptions.ChckBxOptionsSavePos.Checked Then
            Me.Top = My.Settings.usrFormTop
            Me.Left = My.Settings.usrFormLeft
        End If
    End Sub


End Class
