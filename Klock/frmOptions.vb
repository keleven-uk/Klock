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

        Me.TxtBxarchiveFriendsFile.Text = "Friends.zip"

        Me.lblOptionsSettingsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath
        Me.lblOptionsSettingsFile.Text = frmKlock.usrSettings.usrOptionsSaveFile

        Me.setSettings()
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        Me.LblOptionSavepath.Text = frmKlock.usrSettings.usrOptionsSavePath

        Me.BackColor = frmKlock.usrSettings.usrFormColour

        Me.lblColour.Font = frmKlock.usrSettings.usrFormFont
        Me.lblColour.ForeColor = frmKlock.usrSettings.usrFormFontColour

        Me.lblFont.Font = frmKlock.usrSettings.usrFormFont
        Me.lblFont.ForeColor = frmKlock.usrSettings.usrFormFontColour

        Me.lblDefaultColour.Font = frmKlock.usrSettings.usrFormFont
        Me.lblDefaultColour.ForeColor = frmKlock.usrSettings.usrFormFontColour

        Me.TbPgGlobal.BackColor = frmKlock.usrSettings.usrFormColour

        Me.ChckBxOptionsSavePos.Checked = frmKlock.usrSettings.usrSavePosition
        Me.ChckBxOptionsRunOnStartup.Checked = frmKlock.usrSettings.usrRunOnStartup
        Me.ChckBxOptionsStartupMinimised.Checked = frmKlock.usrSettings.usrStartMinimised

        Me.ChckBxTimerHigh.Checked = frmKlock.usrSettings.usrTimerHigh
        Me.ChckBxClearSplit.Checked = frmKlock.usrSettings.usrTimerClearSplit

        Me.chckBxTimeTwoFormats.Checked = frmKlock.usrSettings.usrTimeTwoFormats

        Me.chckBxTimeSwatch.Checked = frmKlock.usrSettings.usrTimeSwatchCentibeats
        Me.ChckBxTimeNetSeconds.Checked = frmKlock.usrSettings.usrTimeNETSeconds
        Me.ChckBxTimeHexIntuitor.Checked = frmKlock.usrSettings.usrTimeHexIntuitorFormat
        Me.ChckBxTimeHourPips.Checked = frmKlock.usrSettings.usrTimeHourPips
        Me.ChckBxTimeHourlyChimes.Checked = frmKlock.usrSettings.usrTimeHourChimes
        Me.ChckBxTimeHalfChimes.Checked = frmKlock.usrSettings.usrTimeHalfChimes
        Me.ChckBxTimeQuarterChimes.Checked = frmKlock.usrSettings.usrTimeQuarterChimes
        Me.ChckBxTimeToast.Checked = frmKlock.usrSettings.usrTimeDisplayMinimised
        Me.UpDwnTimeDisplay.Value = frmKlock.usrSettings.usrTimeDisplayMinutes
        Me.ChckBxOptionsVoice.Checked = frmKlock.usrSettings.usrTimeVoiceMinimised
        Me.UpDwnVoiceDisplay.Value = frmKlock.usrSettings.usrTimeVoiceMinutes

        Me.ChckBxReminderAdd.Checked = frmKlock.usrSettings.usrReminderAdd
        Me.ChckBxTimerAdd.Checked = frmKlock.usrSettings.usrTimerAdd
        Me.ChckBxCountdownAdd.Checked = frmKlock.usrSettings.usrCountdownAdd
        Me.ChckBxWorldKlockAdd.Checked = frmKlock.usrSettings.usrWorldKlockAdd

        If frmKlock.usrSettings.usrTimeDisplayMinutes Then
            Me.UpDwnTimeDisplay.Enabled = True
        Else
            Me.UpDwnTimeDisplay.Enabled = False
        End If

        Me.NmrcUpDwnNotificationTimeOut.Value = frmKlock.usrSettings.usrNotificationTimeOut / 1000
        Me.NmrcUpDwnNotificationOpacity.Value = frmKlock.usrSettings.usrNotificationOpacity

        Me.TrckBrOptionsVolume.Minimum = 0
        Me.TrckBrOptionsVolume.Maximum = 1000
        Me.TrckBrOptionsVolume.TickFrequency = 100
        Me.TrckBrOptionsVolume.Value = frmKlock.usrSettings.usrSoundVolume

        If frmKlock.usrSettings.usrFriendsDirectory = "" Then
            Me.TxtBxOptionsFriendsDirectory.Text = System.IO.Path.Combine(Application.StartupPath, "Data")
        Else
            Me.TxtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrFriendsDirectory
        End If

        If frmKlock.usrSettings.usrFrinedsFile = "" Then
            Me.TxtBxOptionsFriendsFile.Text = "Friends.bin"
        Else
            Me.TxtBxOptionsFriendsFile.Text = frmKlock.usrSettings.usrFrinedsFile
        End If

    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        frmKlock.usrSettings.usrSavePosition = Me.ChckBxOptionsSavePos.Checked
        frmKlock.usrSettings.usrRunOnStartup = Me.ChckBxOptionsRunOnStartup.Checked
        frmKlock.usrSettings.usrStartMinimised = Me.ChckBxOptionsStartupMinimised.Checked

        If frmKlock.usrSettings.usrSavePosition Then
            frmKlock.usrSettings.usrFormTop = frmKlock.Top
            frmKlock.usrSettings.usrFormLeft = frmKlock.Left
        End If

        frmKlock.usrSettings.usrTimerHigh = Me.ChckBxTimerHigh.Checked
        frmKlock.usrSettings.usrTimerClearSplit = Me.ChckBxClearSplit.Checked

        frmKlock.usrSettings.usrTimeTwoFormats = Me.chckBxTimeTwoFormats.Checked

        frmKlock.usrSettings.usrTimeSwatchCentibeats = Me.chckBxTimeSwatch.Checked
        frmKlock.usrSettings.usrTimeNETSeconds = Me.ChckBxTimeNetSeconds.Checked
        frmKlock.usrSettings.usrTimeHexIntuitorFormat = Me.ChckBxTimeHexIntuitor.Checked
        frmKlock.usrSettings.usrTimeHourPips = Me.ChckBxTimeHourPips.Checked
        frmKlock.usrSettings.usrTimeHourChimes = Me.ChckBxTimeHourlyChimes.Checked
        frmKlock.usrSettings.usrTimeHalfChimes = Me.ChckBxTimeHalfChimes.Checked
        frmKlock.usrSettings.usrTimeQuarterChimes = Me.ChckBxTimeQuarterChimes.Checked
        frmKlock.usrSettings.usrTimeDisplayMinimised = Me.ChckBxTimeToast.Checked
        frmKlock.usrSettings.usrTimeDisplayMinutes = Me.UpDwnTimeDisplay.Value
        frmKlock.usrSettings.usrTimeVoiceMinimised = Me.ChckBxOptionsVoice.Checked
        frmKlock.usrSettings.usrTimeVoiceMinutes = Me.UpDwnVoiceDisplay.Value

        frmKlock.usrSettings.usrReminderAdd = Me.ChckBxReminderAdd.Checked
        frmKlock.usrSettings.usrTimerAdd = Me.ChckBxTimerAdd.Checked
        frmKlock.usrSettings.usrCountdownAdd = Me.ChckBxCountdownAdd.Checked
        frmKlock.usrSettings.usrWorldKlockAdd = Me.ChckBxWorldKlockAdd.Checked

        frmKlock.usrSettings.usrReminderTimeChecked = Me.ChckBxReminderTimeCheck.Checked

        frmKlock.usrSettings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

        frmKlock.usrSettings.usrFriendsDirectory = Me.TxtBxOptionsFriendsDirectory.Text
        frmKlock.usrSettings.usrFrinedsFile = Me.TxtBxOptionsFriendsFile.Text

        frmKlock.usrSettings.writeSettings()
        frmKlock.setSettings()

        Me.Close()
    End Sub

    Private Sub btnOptionsCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsCancel.Click
        '   when canceled, close but not save.

        Me.Close()
    End Sub

    Private Sub btnSettingsReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettingsReset.Click
        '   re-write settings file with defaults.

        frmKlock.usrSettings.writeDefaultSettings()
        frmKlock.usrSettings.readSettings()
        Me.setSettings()
    End Sub


    Private Sub btnOptionsFormColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrFormColour          '   current main form colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormColour = Me.ClrDlgFormColour.Color
            Me.setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled separately.

        FntDlgFont.Font = frmKlock.usrSettings.usrFormFont                  '   current main form font
        FntDlgFont.Color = frmKlock.usrSettings.usrFormFontColour            '   current main form font colour

        If FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormFont = FntDlgFont.Font
            frmKlock.usrSettings.usrFormFontColour = FntDlgFont.Color
            Me.setSettings()
        End If
    End Sub

    Private Sub btnDefaultColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        frmKlock.usrSettings.usrFormColour = frmOptions.DefaultBackColor
        frmKlock.usrSettings.usrFormFont = frmOptions.DefaultFont
        frmKlock.usrSettings.usrFormFontColour = frmOptions.DefaultForeColor

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

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrNotificationbackColour   '   current Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationbackColour = Me.ClrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        Me.FntDlgFont.Font = frmKlock.usrSettings.usrNotificationFont                  '   current Notification font
        Me.FntDlgFont.Color = frmKlock.usrSettings.usrNotificationFontColour           '   current Notification font colour

        If Me.FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationFont = Me.FntDlgFont.Font
            frmKlock.usrSettings.usrNotificationFontColour = Me.FntDlgFont.Color
        End If
    End Sub

    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrNotificationTimeOut = Me.NmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        frmKlock.usrSettings.usrNotificationOpacity = Me.NmrcUpDwnNotificationOpacity.Value
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationTest.Click
        '   Display a test notification, showing the current notification opacity.

        Me.displayAction.DisplayReminder("Notification Test", String.Format(" Opacity = {0}", frmKlock.usrSettings.usrNotificationOpacity))
    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrckBrOptionsVolume.Scroll
        '   Set system volume.

        frmKlock.usrSettings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

    End Sub

    Private Sub btnOptionsTestVolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsTestVolume.Click
        '   Play a sound to test system volume.

        Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\halfchime.mp3"))

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
        '   Prompt user to the location of the friends file - Default to Application Path \data.

        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsFriendsDirectory.Text = Me.FolderBrowserDialog1.SelectedPath
            frmKlock.usrSettings.usrFriendsDirectory = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnOptionsFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsFile.Click
        '   Prompt user for the filename of the friends file - Default to freinds.bin

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = Me.TxtBxOptionsFriendsDirectory.Text
        Me.OpenFileDialog1.FileName = Me.TxtBxOptionsFriendsFile.Text

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsFriendsFile.Text = Me.OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrFrinedsFile = Me.OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub btnOptionsFriendsPathReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsPathReset.Click
        '   Reset the location of the friends file to that of the system default data area [i.e. same as settings file].

        Me.TxtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath
        Me.TxtBxOptionsFriendsFile.Text = "Friends.bin"
    End Sub

    Private Sub btnArchiveFriendsDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnarchiveFriendsDirectory.Click
        '   Prompt user for location of the Archive file.
        '   If file exists, enable load button.  Enable save button as well

        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxarchiveFriendsDirectory.Text = Me.FolderBrowserDialog1.SelectedPath

            Me.btnarchiveFriendsSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(Me.TxtBxarchiveFriendsDirectory.Text, Me.TxtBxarchiveFriendsFile.Text)) Then
                Me.btnarchiveFriendsLoad.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnArchiveFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnarchiveFriendsFile.Click
        '   Prompt user for file name of the Archive file.
        '   If file exists, enable load button.  Enable save button as well


        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = Me.TxtBxarchiveFriendsDirectory.Text
        Me.OpenFileDialog1.FileName = Me.TxtBxarchiveFriendsFile.Text
        Me.OpenFileDialog1.DefaultExt = ".zip"

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxarchiveFriendsFile.Text = Me.OpenFileDialog1.SafeFileName

            Me.btnarchiveFriendsSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(Me.TxtBxarchiveFriendsDirectory.Text, Me.TxtBxarchiveFriendsFile.Text)) Then
                Me.btnarchiveFriendsLoad.Enabled = True
            End If
        End If


    End Sub

    Private Sub btnArchiveFriendsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnarchiveFriendsSave.Click
        '   Saves the friends file to Archive [zip].
        '   If the achieve already exists, it will only be overwritten on user prompt.

        Dim zippath As String = System.IO.Path.Combine(Me.TxtBxarchiveFriendsDirectory.Text, Me.TxtBxarchiveFriendsFile.Text)

        If My.Computer.FileSystem.FileExists(zippath) Then      '   file already exists, prompt user.
            Dim reply As MsgBoxResult

            reply = MsgBox("This will over write existing Archive file", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

            If reply = MsgBoxResult.No Then     '   Not to over write, exit sub.
                Me.btnarchiveFriendsSave.Enabled = False
                Exit Sub
            End If
        End If

        Using zip As ZipFile = New ZipFile

            'zip.AddDirectory(Me.TxtBxOptionsFriendsDirectory.Text)      '   add directory to Archive.
            zip.AddFile(System.IO.Path.Combine(frmKlock.usrSettings.usrFriendsDirectory, frmKlock.usrSettings.usrFrinedsFile))
            zip.AddFile(System.IO.Path.Combine(frmKlock.usrSettings.usrOptionsSavePath, frmKlock.usrSettings.usrOptionsSaveFile))

            Try
                zip.Save(zippath)                                       '   save Archive
                Me.displayAction.DisplayReminder("Saving File", "Archive saved Okay. ")
            Catch ex As Exception
                Me.displayAction.DisplayReminder("Saving File Error", "Error archieving Friends File. " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub btnArchiveFriendsLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnarchiveFriendsLoad.Click
        '   Load the friends file from Archive.
        '   The file will only be overwritten, if it exists, on user prompt.
        '   If the path does not exist, it will be created.

        Dim zippath As String = System.IO.Path.Combine(Me.TxtBxarchiveFriendsDirectory.Text, Me.TxtBxarchiveFriendsFile.Text)
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
                        frmKlock.reloadFriends = True             '   set to re-load friends file.
                        Me.displayAction.DisplayReminder("Loading File", entry.FileName)
                    Catch ex As Exception
                        Me.displayAction.DisplayReminder("Loading File Error", "Error archieving Friends File. " & ex.Message)
                    End Try
                End If          '   if extract

            Next                '   for each entry in zip

        End Using

    End Sub


End Class