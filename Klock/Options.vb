Imports System.IO
Imports System.IO.Compression
Imports Ionic.Zip

Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    '   The settings are saved using applications settings, automatically handled by
    '   the program.  A save is called when form is closed.

    Public displayAction As selectAction


    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   When opened, set settings

        displayAction = New selectAction

        Me.TxtBxArchieveFriendsFile.Text = "Friends.zip"

        Me.setSettings()
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        Me.BackColor = My.Settings.usrFormColour

        Me.lblColour.Font = My.Settings.usrFormFont
        Me.lblColour.ForeColor = My.Settings.usrFormFontColour

        Me.lblFont.Font = My.Settings.usrFormFont
        Me.lblFont.ForeColor = My.Settings.usrFormFontColour

        Me.lblDefaultColour.Font = My.Settings.usrFormFont
        Me.lblDefaultColour.ForeColor = My.Settings.usrFormFontColour

        Me.TbPgGlobal.BackColor = My.Settings.usrFormColour
        Me.TbPgTime.BackColor = My.Settings.usrFormColour
        Me.TbPgTimer.BackColor = My.Settings.usrFormColour

        Me.ChckBxOptionsSavePos.Checked = My.Settings.usrSavePos
        Me.ChckBxOptionsSavePos.Font = My.Settings.usrFormFont
        Me.ChckBxOptionsSavePos.ForeColor = My.Settings.usrFormFontColour

        Me.ChckBxOptionsRunOnStartup.Checked = My.Settings.usrRunOnStartup
        Me.ChckBxOptionsStartupMinimised.Checked = My.Settings.usrStartMinimised

        Me.ChckBxTimerHigh.Checked = My.Settings.usrTimerHigh
        Me.ChckBxClearSplit.Checked = My.Settings.usrTimerClearSplit

        Me.chckBxTimeTwoFormats.Checked = My.Settings.usrTimeTwoFormats

        Me.chckBxTimeSwatch.Checked = My.Settings.usrTimeSwatchCentibeats
        Me.ChckBxTimeNetSeconds.Checked = My.Settings.usrTimeNETSeconds
        Me.ChckBxTimeHexIntuitor.Checked = My.Settings.usrTimeHexIntuitor
        Me.ChckBxTimeHourPips.Checked = My.Settings.usrTimeHourPips
        Me.ChckBxTimeHourlyChimes.Checked = My.Settings.usrTimeHourlyChimes
        Me.ChckBxTimeHalfChimes.Checked = My.Settings.usrTimeHalfChimes
        Me.ChckBxTimeQuarterChimes.Checked = My.Settings.usrTimeQuarterChimes
        Me.ChckBxTimeToast.Checked = My.Settings.usrTimeDisplayMinimised
        Me.UpDwnTimeDisplay.Value = My.Settings.usrTimeDisplayMinutes

        Me.ChckBxReminderAdd.Checked = My.Settings.usrReminderAdd
        Me.ChckBxTimerAdd.Checked = My.Settings.usrTimerAdd
        Me.ChckBxCountdownAdd.Checked = My.Settings.usrCountdownAdd

        If My.Settings.usrTimeDisplayMinimised Then
            Me.UpDwnTimeDisplay.Enabled = True
        Else
            Me.UpDwnTimeDisplay.Enabled = False
        End If

        Me.NmrcUpDwnNotificationTimeOut.Value = My.Settings.usrNotificationTimeOut / 1000
        Me.NmrcUpDwnNotificationOpacity.Value = My.Settings.usrNotificationOpacity

        Me.TrckBrOptionsVolume.Minimum = 0
        Me.TrckBrOptionsVolume.Maximum = 1000
        Me.TrckBrOptionsVolume.TickFrequency = 100
        Me.TrckBrOptionsVolume.Value = My.Settings.usrSoundVolume

        If My.Settings.usrFriendsDirectory = "" Then
            Me.TxtBxOptionsFriendsDirectory.Text = Application.StartupPath & "\Data"
        Else
            Me.TxtBxOptionsFriendsDirectory.Text = My.Settings.usrFriendsDirectory
        End If

        If My.Settings.usrFriendsFile = "" Then
            Me.TxtBxOptionsFriendsFile.Text = "Friends.bin"
        Else
            Me.TxtBxOptionsFriendsFile.Text = My.Settings.usrFriendsFile
        End If

    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        My.Settings.usrSavePos = Me.ChckBxOptionsSavePos.Checked
        My.Settings.usrRunOnStartup = Me.ChckBxOptionsRunOnStartup.Checked
        My.Settings.usrStartMinimised = Me.ChckBxOptionsStartupMinimised.Checked

        If My.Settings.usrSavePos Then
            My.Settings.usrFormTop = frmKlock.Top
            My.Settings.usrFormLeft = frmKlock.Left
        End If

        My.Settings.usrTimerHigh = Me.ChckBxTimerHigh.Checked
        My.Settings.usrTimerClearSplit = Me.ChckBxClearSplit.Checked

        My.Settings.usrTimeTwoFormats = Me.chckBxTimeTwoFormats.Checked

        My.Settings.usrTimeSwatchCentibeats = Me.chckBxTimeSwatch.Checked
        My.Settings.usrTimeNETSeconds = Me.ChckBxTimeNetSeconds.Checked
        My.Settings.usrTimeHexIntuitor = Me.ChckBxTimeHexIntuitor.Checked
        My.Settings.usrTimeHourPips = Me.ChckBxTimeHourPips.Checked
        My.Settings.usrTimeHourlyChimes = Me.ChckBxTimeHourlyChimes.Checked
        My.Settings.usrTimeHalfChimes = Me.ChckBxTimeHalfChimes.Checked
        My.Settings.usrTimeQuarterChimes = Me.ChckBxTimeQuarterChimes.Checked
        My.Settings.usrTimeThreeQuarterChimes = Me.ChckBxTimeQuarterChimes.Checked
        My.Settings.usrTimeDisplayMinimised = Me.ChckBxTimeToast.Checked
        My.Settings.usrTimeDisplayMinutes = Me.UpDwnTimeDisplay.Value

        My.Settings.usrReminderAdd = Me.ChckBxReminderAdd.Checked
        My.Settings.usrTimerAdd = Me.ChckBxTimerAdd.Checked
        My.Settings.usrCountdownAdd = Me.ChckBxCountdownAdd.Checked

        My.Settings.usrReminderTimeChecked = Me.ChckBxReminderTimeCheck.Checked

        My.Settings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

        My.Settings.usrFriendsDirectory = Me.TxtBxOptionsFriendsDirectory.Text
        My.Settings.usrFriendsFile = Me.TxtBxOptionsFriendsFile.Text

        My.Settings.Save()

        Me.Close()
    End Sub

    Private Sub btnOptionsCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsCancel.Click
        '   when canceled, close but not save.

        Me.Close()
    End Sub


    Private Sub btnOptionsFormColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        Me.ClrDlgFormColour.Color = My.Settings.usrFormColour          '   current main form colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            My.Settings.usrFormColour = Me.ClrDlgFormColour.Color
            Me.setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled separately.

        FntDlgFont.Font = My.Settings.usrFormFont                  '   current main form font
        FntDlgFont.Color = My.Settings.usrFormFontColour            '   current main form font colour

        If FntDlgFont.ShowDialog() = DialogResult.OK Then
            My.Settings.usrFormFont = FntDlgFont.Font
            My.Settings.usrFormFontColour = FntDlgFont.Color
            Me.setSettings()
        End If
    End Sub

    Private Sub btnDefaultColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        My.Settings.usrFormColour = frmOptions.DefaultBackColor
        My.Settings.usrFormFont = frmOptions.DefaultFont
        My.Settings.usrFormFontColour = frmOptions.DefaultForeColor

        Me.setSettings()
    End Sub

    Private Sub ChckBxOptionsRunOnStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxOptionsRunOnStartup.CheckedChanged
        '   Sets or deletes the registry key required for running on windows start up.
        '   Only sets for current user.

        Try
            If Me.ChckBxOptionsRunOnStartup.Checked Then
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Registry Error :: Cant write entry to Registry", ex.Message)
        End Try
    End Sub

    '-----------------------------------------------------------Time---------------------------------------------------------------

    Private Sub ChckBxTimeHourPips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeHourPips.CheckedChanged
        '   It the pips are selected, disable all chimes.

        If Me.ChckBxTimeHourPips.Checked Then
            Me.ChckBxTimeHourlyChimes.Enabled = False
            Me.ChckBxTimeHourlyChimes.Checked = False
            Me.ChckBxTimeHalfChimes.Enabled = False
            Me.ChckBxTimeHalfChimes.Checked = False
            Me.ChckBxTimeQuarterChimes.Enabled = False
            Me.ChckBxTimeQuarterChimes.Checked = False
        Else
            Me.ChckBxTimeHourlyChimes.Enabled = True
            Me.ChckBxTimeHalfChimes.Enabled = True
            Me.ChckBxTimeQuarterChimes.Enabled = True
        End If
    End Sub

    Private Sub ChckBxTimeHourlyChimes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeHourlyChimes.CheckedChanged
        '   if chimes are selected, disable the pips.

        If Me.ChckBxTimeHourlyChimes.Checked Then
            Me.ChckBxTimeHourPips.Enabled = False
            Me.ChckBxTimeHourPips.Checked = False
            Me.ChckBxTimeHalfChimes.Enabled = True
            Me.ChckBxTimeQuarterChimes.Enabled = True
        Else
            Me.ChckBxTimeHourPips.Enabled = True
            Me.ChckBxTimeHalfChimes.Checked = False
            Me.ChckBxTimeHalfChimes.Enabled = False
            Me.ChckBxTimeQuarterChimes.Checked = False
            Me.ChckBxTimeQuarterChimes.Enabled = False
        End If
    End Sub


    '-----------------------------------------------------------Notification---------------------------------------------------------------

    Private Sub btnNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationColour.Click
        '   Set the Notification main colour.

        Me.ClrDlgFormColour.Color = My.Settings.usrNotificationBackColour   '   current Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            My.Settings.usrNotificationBackColour = Me.ClrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        Me.FntDlgFont.Font = My.Settings.usrNotificationFont                  '   current Notification font
        Me.FntDlgFont.Color = My.Settings.usrNotificationFontColour           '   current Notification font colour

        If Me.FntDlgFont.ShowDialog() = DialogResult.OK Then
            My.Settings.usrNotificationFont = Me.FntDlgFont.Font
            My.Settings.usrNotificationFontColour = Me.FntDlgFont.Color
        End If
    End Sub

    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        My.Settings.usrNotificationTimeOut = Me.NmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        My.Settings.usrNotificationOpacity = Me.NmrcUpDwnNotificationOpacity.Value
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationTest.Click
        '   Display a test notification, showing the current notification opacity.

        Me.displayAction.DisplayReminder("Notification Test", String.Format(" Opacity = {0}", My.Settings.usrNotificationOpacity))
    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrckBrOptionsVolume.Scroll
        '   Set system volume.

        My.Settings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

    End Sub

    Private Sub btnOptionsTestVolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsTestVolume.Click
        '   Play a sound to test system volume.

        Me.displayAction.PlaySound(Application.StartupPath & "\Sounds\halfchime.mp3")

    End Sub

    Private Sub ChckBxTimeToast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeToast.CheckedChanged
        '   If checkbox to enable notification message every nth minutes if checked, enables the minute counter.

        If Me.ChckBxTimeToast.Checked Then
            Me.UpDwnTimeDisplay.Enabled = True
        Else
            Me.UpDwnTimeDisplay.Enabled = False
        End If
    End Sub

    '---------------------------------------------------------- Friends Options  ---------------------------------------------------------------

    Private Sub btnOptionsFriendsDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsDirectory.Click
        '   Promt user to the location of the frinds file - Default to Application Path \data.

        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsFriendsDirectory.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnOptionsFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsFile.Click
        '   Prompt user for the filename of the friends file - Default to freinds.bin

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = Me.TxtBxOptionsFriendsDirectory.Text
        Me.OpenFileDialog1.FileName = Me.TxtBxOptionsFriendsFile.Text

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsFriendsFile.Text = Me.OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub btnOptionsFriendsPathReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsPathReset.Click
        '   Reset the location of the friends file to that of the application, plust \Data

        Me.TxtBxOptionsFriendsDirectory.Text = Application.StartupPath & "\Data"
        Me.TxtBxOptionsFriendsFile.Text = "Friends.bin"
    End Sub

    Private Sub btnArchieveFriendsDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchieveFriendsDirectory.Click
        '   Prompt user for location of the archive file.
        '   If file exixts, enable load button.  Enable save button as well

        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxArchieveFriendsDirectory.Text = Me.FolderBrowserDialog1.SelectedPath

            Me.btnArchieveFriendsSave.Enabled = True

            If My.Computer.FileSystem.FileExists(Me.TxtBxArchieveFriendsDirectory.Text & "\" & Me.TxtBxArchieveFriendsFile.Text) Then
                Me.btnArchieveFriendsLoad.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnArchieveFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchieveFriendsFile.Click
        '   Prompt user for file name of the archive file.
        '   If file exixts, enable load button.  Enable save button as well


        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = Me.TxtBxArchieveFriendsDirectory.Text
        Me.OpenFileDialog1.FileName = Me.TxtBxArchieveFriendsFile.Text
        Me.OpenFileDialog1.DefaultExt = ".zip"

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxArchieveFriendsFile.Text = Me.OpenFileDialog1.SafeFileName

            Me.btnArchieveFriendsSave.Enabled = True

            If My.Computer.FileSystem.FileExists(Me.TxtBxArchieveFriendsDirectory.Text & "\" & Me.TxtBxArchieveFriendsFile.Text) Then
                Me.btnArchieveFriendsLoad.Enabled = True
            End If
        End If


    End Sub

    Private Sub btnArchieveFriendsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchieveFriendsSave.Click
        '   Saves the friends file to archive [zip].
        '   If the archieve already exists, it will only be overwritten on user prompt.

        Dim zippath As String = Me.TxtBxArchieveFriendsDirectory.Text & "\" & Me.TxtBxArchieveFriendsFile.Text

        If My.Computer.FileSystem.FileExists(zippath) Then      '   file already exists, prompt user.
            Dim reply As MsgBoxResult

            reply = MsgBox("This will over write existing archieve file", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

            If reply = MsgBoxResult.No Then     '   Not to over write, exit sub.
                Me.btnArchieveFriendsSave.Enabled = False
                Exit Sub
            End If
        End If

        Using zip As ZipFile = New ZipFile

            zip.AddDirectory(Me.TxtBxOptionsFriendsDirectory.Text)      '   add directory to archieve.

            Try
                zip.Save(zippath)                                       '   save archive
            Catch ex As Exception
                Me.displayAction.DisplayReminder("Saving File Error", "Error archieving Friends File. " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub btnArchieveFriendsLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchieveFriendsLoad.Click
        '   Load the friends file from archive.
        '   The file will only be overwritten, if it exists, on user prompt.
        '   If the path does not exist, it will be created.

        Dim zippath As String = Me.TxtBxArchieveFriendsDirectory.Text & "\" & Me.TxtBxArchieveFriendsFile.Text
        Dim reply As MsgBoxResult
        Dim extract As Boolean

        Using zip As ZipFile = ZipFile.Read(zippath)        '   

            Dim entry As ZipEntry

            For Each entry In zip                           '   for each file in the zipfile.

                extract = True                              '   set to extract initially.

                If My.Computer.FileSystem.FileExists(entry.FileName) Then
                    reply = MsgBox("This will over write existing data", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

                    If reply = MsgBoxResult.No Then         '   Not to over write, do not extract.
                        extract = False
                    End If      '   if reply
                End If          '   if my.computer

                If extract Then                             '   extract file.
                    Try                                     '   catch extract error, if any.
                        entry.Extract(Me.TxtBxOptionsFriendsDirectory.Text)
                    Catch ex As Exception
                        Me.displayAction.DisplayReminder("Saving File Error", "Error archieving Friends File. " & ex.Message)
                    End Try
                End If          '   if extract

            Next                '   for each entry in zip

        End Using

    End Sub
End Class