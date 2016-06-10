Imports System.IO
Imports System.IO.Compression

Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    Public displayAction As selectAction

    '-----------------------------------------------------------Analogue Klock---------------------------------------------------------------

    Private Sub btnAnlgKlockBackColour_Click(sender As Object, e As EventArgs) Handles btnAnlgKlockBackColour.Click
        '   Sets the background colour for the analogue klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrAnalogueKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrAnalogueKlockBackColour = clrDlgFormColour.Color
            btnAnlgKlockBackColour.BackColor = frmKlock.usrSettings.usrAnalogueKlockBackColour
            setSettings()
        End If
    End Sub

    Private Sub btnAnlgKlockPictureLocation_Click(sender As Object, e As EventArgs) Handles btnAnlgKlockPictureLocation.Click
        '   Load the background image for analogue klock.

        OpenFileDialog1.InitialDirectory = System.IO.Path.Combine(Application.StartupPath, "images")
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxAnlgKlockPictureLocation.Text = OpenFileDialog1.SafeFileName

            If My.Computer.FileSystem.FileExists(OpenFileDialog1.FileName) Then
                frmKlock.usrSettings.usrAnalogueKlockPicture = OpenFileDialog1.FileName
                pctrBxAnlgKlockPicture.ImageLocation = OpenFileDialog1.FileName
                pctrBxAnlgKlockPicture.Load()
                frmAnalogueKlock.analogueKlockRefresh()
            End If
        End If
    End Sub

    Private Sub btnArchiveDirectory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnArchiveDirectory.Click
        '   Prompt user for location of the Archive file.
        '   If file exists, enable load button.  Enable save button as well

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtBxArchiveDirectory.Text = FolderBrowserDialog1.SelectedPath

            btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text)) Then
                btnArchiveLoad.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnArchiveFriendsFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnArchiveFile.Click
        '   Prompt user for file name of the Archive file.
        '   If file exists, enable load button.  Enable save button as well


        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = txtBxArchiveDirectory.Text
        OpenFileDialog1.FileName = txtBxArchiveFile.Text
        OpenFileDialog1.DefaultExt = ".zip"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxArchiveFile.Text = OpenFileDialog1.SafeFileName

            btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text)) Then
                btnArchiveLoad.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnArchiveLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnArchiveLoad.Click
        '   Load the friends, events, memo & settings files from Archive.
        '   Will also load sticky notes  and log files, if they where present during save.
        '   The file will only be overwritten, if it exists, on user prompt.
        '   If the path does not exist, it will be created.

        '   Could use archive.ExtractToDirectory(zipdir), if file checking was not used.

        Dim zippath As String = Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text)   '   path of source sip file.
        Dim zipdir As String = frmKlock.usrSettings.usrOptionsSavePath                                      '   path of destination directory.
        Dim ziperror As Boolean = True

        If Not My.Computer.FileSystem.DirectoryExists(zipdir) Then
            My.Computer.FileSystem.CreateDirectory(zipdir)
        End If

        Using archive As ZipArchive = ZipFile.OpenRead(zippath)
            For Each entry As ZipArchiveEntry In archive.Entries
                Try
                    If fileExists(Path.Combine(zipdir, entry.FullName)) Then  '   archive already exists and to overwrite.
                        entry.ExtractToFile(Path.Combine(zipdir, entry.FullName), True)
                        If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.logMessage("frmOptions.btnArchiveLoad_Click", " Restoring file :: " & entry.FullName)
                    End If
                Catch ex As Exception
                    ziperror = False
                    If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("frmOptions.btnArchiveLoad_Click", ex)
                    displayAction.DisplayReminder("Error Loading Data Files. " & ex.Message, "G", "Loading File Error")
                End Try
            Next
            If ziperror Then
                displayAction.DisplayReminder("Loading Data Files Successful.", "G", "Loading File Okay")

                setSettings()                       '   apply new settings.
                frmKlock.myStickyNotes.Load()       '   apply sticky notes
            End If
        End Using
    End Sub

    Private Sub btnArchiveSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnArchiveSave.Click
        '   Saves the friends, events, memo & settings files to Archive [zip].
        '   Will also save sticky notes and log files.
        '   If the achieve already exists, it will only be overwritten on user prompt.

        Dim zippath As String = Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text)       '   path of destination zip file.
        Dim zipdir As String = frmKlock.usrSettings.usrOptionsSavePath                                '   path of source directory.
        Dim ziperror As Boolean = True

        If Not fileExists(zippath) Then         '   archive already exists and not to overwrite.
            btnArchiveSave.Enabled = False
            Exit Sub
        End If

        Using archive As ZipArchive = ZipFile.Open(zippath, ZipArchiveMode.Update)
            For Each file As String In My.Computer.FileSystem.GetFiles(zipdir)
                Try
                    archive.CreateEntryFromFile(file, My.Computer.FileSystem.GetName(file), CompressionLevel.Optimal)
                    If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.logMessage("frmOptions.btnArchiveSave_Click", " Archiving file :: " & file)
                Catch ex As Exception
                    ziperror = False
                    If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("frmOptions.btnArchiveSave_Click", ex)
                    displayAction.DisplayReminder("Error archiving Data Files. " & ex.Message, "G", "Saving File Error")
                End Try
            Next
            If ziperror Then displayAction.DisplayReminder("Archiving Data Files Successful.", "G", "Saving File Okay")
        End Using
    End Sub

    Private Sub btnBgTxtKlckBckClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckBckClr.Click
        '   Sets the Back colour for the Big text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockBackColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckFrClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckFrClr.Click
        '   Sets the Fore colour for the Big text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockForeColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockForeColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckOffClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckOffClr.Click
        '   Sets the Off colour for the Big text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockOffColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockOffColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBnryKlckBckClr_Click(sender As Object, e As EventArgs)
        '   Sets the Back colour for the Binary klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBinaryKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBinaryKlockBackColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    '-----------------------------------------------------------Binary Klock-----------------------------------------------------------------

    Private Sub btnBnryKlckFrClr_Click(sender As Object, e As EventArgs)
        '   Sets the Fore colour for the Binary klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBinaryKlockForeColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBinaryKlockForeColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBnryKlckOffClr_Click(sender As Object, e As EventArgs)
        '   Sets the Off colour for the Binary klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBinaryKlockOffColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBinaryKlockOffColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnDefaultColour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        frmKlock.usrSettings.usrFormColour = frmOptions.DefaultBackColor
        frmKlock.usrSettings.usrFormFont = frmOptions.DefaultFont
        frmKlock.usrSettings.usrFormFontColour = frmOptions.DefaultForeColor

        setSettings()
    End Sub

    '-----------------------------------------------------------Event Notification--------------------------------------------------------------

    Private Sub btnEventNotificationFont_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEventNotificationFont.Click
        '   Set the Event Notification main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrEventNotificationFont                  '   current Event Notification font
        fntDlgFont.Color = frmKlock.usrSettings.usrEventNotificationFontColour           '   current Event Notification font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrEventNotificationFont = fntDlgFont.Font
            frmKlock.usrSettings.usrEventNotificationFontColour = fntDlgFont.Color
        End If
    End Sub

    Private Sub btnEventNotificationTest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEventNotificationTest.Click
        '   Display a test event notification, showing the current event notification opacity.

        Dim ev As New Events

        ev.EventName = "btnEventNotificationTest"

        displayAction.DisplayEvent(ev)
    End Sub

    Private Sub btnFirstEventNotificationColour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFirstEventNotificationColour.Click
        '   Set the First Event Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrFirstEventNotificationbackColour   '   current First Event Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFirstEventNotificationbackColour = clrDlgFormColour.Color
            pctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        End If
    End Sub

    '-----------------------------------------------------------Notification---------------------------------------------------------------

    Private Sub btnNotificationColour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotificationColour.Click
        '   Set the Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrNotificationbackColour   '   current Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationbackColour = clrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrNotificationFont                  '   current Notification font
        fntDlgFont.Color = frmKlock.usrSettings.usrNotificationFontColour           '   current Notification font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationFont = fntDlgFont.Font
            frmKlock.usrSettings.usrNotificationFontColour = fntDlgFont.Color
        End If
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotificationTest.Click
        '   Display a test notification, showing the current notification opacity.

        displayAction.DisplayReminder(String.Format(" Opacity = {0}", frmKlock.usrSettings.usrNotificationOpacity), "G", "Notification Test")
    End Sub

    '-----------------------------------------------------------Buttons---------------------------------------------------------------

    Private Sub btnOptionsCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsCancel.Click
        '   when cancelled, close but not save.

        Close()
    End Sub



    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        loadSettings()

        frmKlock.usrSettings.writeSettings()
        frmKlock.setSettings()

        Close()
    End Sub

    '---------------------------------------------------------- Events Options  ---------------------------------------------------------------

    Private Sub btnOptionsEventsFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsEventsFile.Click
        '   Prompt user for the filename of the Events file - Default to Events.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        OpenFileDialog1.FileName = txtBxOptionsEventsFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxOptionsEventsFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrEventsFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    '-----------------------------------------------------------Global---------------------------------------------------------------

    Private Sub btnOptionsFormColour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrFormColour          '   current main form colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrFormFont                  '   current main form font
        fntDlgFont.Color = frmKlock.usrSettings.usrFormFontColour            '   current main form font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormFont = fntDlgFont.Font
            frmKlock.usrSettings.usrFormFontColour = fntDlgFont.Color
            setSettings()
        End If
    End Sub
    '---------------------------------------------------------- Friends Options  ---------------------------------------------------------------

    Private Sub btnOptionsFriendsFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsFriendsFile.Click
        '   Prompt user for the filename of the friends file - Default to friends.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = txtBxOptionsFriendsDirectory.Text
        OpenFileDialog1.FileName = txtBxOptionsFriendsFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxOptionsFriendsFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrFriendsFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Memo Options  ---------------------------------------------------------------

    Private Sub btnOptionsMemoFile_Click(sender As Object, e As EventArgs) Handles btnOptionsMemoFile.Click
        '   Prompt user for the filename of the Memo file - Default to memo.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        OpenFileDialog1.FileName = txtBxOptionsMemoFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxOptionsMemoFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrMemoFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    ' **************************************************************************************** Archive stuff ***************************

    Private Sub btnOptionsPathReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsPathReset.Click
        '   Reset the location of the data files to that of the system default data area [i.e. same as settings file].

        txtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath
        txtBxOptionsFriendsFile.Text = "Friends.bin"

        txtBxOptionsEventsFile.Text = "Events.bin"
    End Sub

    Private Sub btnOptionsTestVolume_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOptionsTestVolume.Click
        '   Play a sound to test system volume.

        displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\halfchime.mp3"))
    End Sub

    Private Sub btnResetBigKlock_Click(sender As Object, e As EventArgs) Handles btnResetBigKlock.Click
        '   reset colours for big klock.

        frmKlock.usrSettings.usrBigKlockBackColour = Color.Black
        frmKlock.usrSettings.usrBigKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrBigKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    Private Sub btnResetBnryKlock_Click(sender As Object, e As EventArgs)
        '   reset colours for Binary klock.

        frmKlock.usrSettings.usrBinaryKlockBackColour = Color.Black
        frmKlock.usrSettings.usrBinaryKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrBinaryKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    Private Sub btnResetSmallKlock_Click(sender As Object, e As EventArgs) Handles btnResetSmallKlock.Click
        '   reset colours for small klock.

        frmKlock.usrSettings.usrSmallKlockBackColour = Color.Black
        frmKlock.usrSettings.usrSmallKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrSmallKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    Private Sub btnSayingNotificationColour_Click(sender As Object, e As EventArgs) Handles btnSayingNotificationColour.Click
        '   Set the Sayings main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSayingsbackColour   '   current Sayings colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSayingsbackColour = clrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnSayingNotificationFont_Click(sender As Object, e As EventArgs) Handles btnSayingNotificationFont.Click
        '   Set the Sayings main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrSayingsFont                  '   current Sayings font
        fntDlgFont.Color = frmKlock.usrSettings.usrSayingsFontColour           '   current Sayings font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSayingsFont = fntDlgFont.Font
            frmKlock.usrSettings.usrSayingsFontColour = fntDlgFont.Color
        End If
    End Sub

    Private Sub btnSayingNotificationTest_Click(sender As Object, e As EventArgs) Handles btnSayingNotificationTest.Click
        '   Display a test Sayings, showing the current Sayings opacity.

        displayAction.DisplayReminder(String.Format(" Opacity = {0}", frmKlock.usrSettings.usrSayingsOpacity), "S", "Sayings Test")
    End Sub

    Private Sub btnSecondEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondEventNotificationColour.Click
        '   Set the Second Event Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSecondEventNotificationbackColour   '   current Second Event Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSecondEventNotificationbackColour = clrDlgFormColour.Color
            pctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        End If
    End Sub

    Private Sub btnSettingsReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSettingsReset.Click
        '   re-write settings file with defaults.

        frmKlock.usrSettings.writeDefaultSettings()
        frmKlock.usrSettings.readSettings()
        setSettings()
        frmKlock.setSettings()
    End Sub

    Private Sub btnSmlTxtKlckBckClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckBckClr.Click
        '   Sets the Back colour for the small text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockBackColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    '
    '-----------------------------------------------------------Text Klock---------------------------------------------------------------
    '
    Private Sub btnSmlTxtKlckFrClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckFrClr.Click
        '   Sets the Fore colour for the small text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockForeColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockForeColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnSmlTxtKlckOffClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckOffClr.Click
        '   Sets the Off colour for the small text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockOffColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockOffColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnStckyNtFont_Click(sender As Object, e As EventArgs) Handles btnStckyNtFont.Click
        '   Set the Sticky Note main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrStickyNoteFont                   '   current Sticky Note font
        fntDlgFont.Color = frmKlock.usrSettings.usrStickyNoteFontColour            '   current Sticky Note font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrStickyNoteFont = fntDlgFont.Font
            frmKlock.usrSettings.usrStickyNoteFontColour = fntDlgFont.Color
        End If
    End Sub

    Private Sub btnStckyNtkBgClr_Click(sender As Object, e As EventArgs) Handles btnStckyNtkBgClr.Click
        '   Sets the Back colour for the Sticky Note.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrStickyNoteBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrStickyNoteBackColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub
    '
    '-----------------------------------------------------------Sticky Notes---------------------------------------------------------------
    '
    Private Sub btnStckyNtkFrClr_Click(sender As Object, e As EventArgs) Handles btnStckyNtkFrClr.Click
        '   Sets the Fore colour for the Sticky Note.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrStickyNoteForeColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrStickyNoteForeColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnThirdEventNotificationColour_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnThirdEventNotificationColour.Click
        '   Set the Third Event Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrThirdEventNotificationbackColour   '   current Third Event Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrThirdEventNotificationbackColour = clrDlgFormColour.Color
            pctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour
        End If
    End Sub

    Private Sub ChckBxAllowStckyNtfadeOut_CheckedChanged(sender As Object, e As EventArgs) Handles ChckBxAllowStckyNtfadeOut.CheckedChanged

        lblStckyNtMinOpacity.Enabled = ChckBxAllowStckyNtfadeOut.Checked
        lblStckyNtfadeOutStep.Enabled = ChckBxAllowStckyNtfadeOut.Checked
        NmrcUpDwnStkyNtMinOpacity.Enabled = ChckBxAllowStckyNtfadeOut.Checked
        NmrcUpDwnStkyNtfadeOutStep.Enabled = ChckBxAllowStckyNtfadeOut.Checked
    End Sub

    Private Sub chckBxAnlgKlockDate_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockDate.CheckedChanged
        '   Display the date on the analogue klocks dial.

        frmKlock.usrSettings.usrAnalogueKlockShowDate = chckBxAnlgKlockDate.Checked
    End Sub

    Private Sub chckBxAnlgKlockDisplayPicture_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockDisplayPicture.CheckedChanged
        '   Sets if a background image is displayed.

        checkPicture()
        frmAnalogueKlock.analogueKlockRefresh()
    End Sub

    Private Sub chckBxAnlgKlockIdleTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockIdleTime.CheckedChanged

        frmKlock.usrSettings.usrAnalogueKlockShowIdleTime = chckBxAnlgKlockIdleTime.Checked
    End Sub

    Private Sub chckBxAnlgKlockTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockTime.CheckedChanged
        '   Display the digital time on the analogue klocks dial.

        frmKlock.usrSettings.usrAnalogueKlockShowTime = chckBxAnlgKlockTime.Checked
    End Sub

    Private Sub chckBxAnlgKlockTransparent_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockTransparent.CheckedChanged
        '   Make the analogue klock transparent.

        frmKlock.usrSettings.usrAnalogueKlcokTransparent = chckBxAnlgKlockTransparent.Checked
        btnAnlgKlockBackColour.Enabled = Not chckBxAnlgKlockTransparent.Checked
        lblAnlgKlockBackColour.Enabled = Not chckBxAnlgKlockTransparent.Checked

    End Sub

    ' ********************************************************************************** Clipboard monitor stuff ***************************

    Private Sub ChckBxClipboardMonitor_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxClipboardMonitor.CheckedChanged
        '   Determines if clipboard monitor is active.

        frmKlock.usrSettings.usrClipboardMonitor = chckBxClipboardMonitor.Checked
        chckBxClipboardSavePos.Enabled = chckBxClipboardMonitor.Checked
        chckBxClipboardSaveCSV.Enabled = chckBxClipboardMonitor.Checked
    End Sub

    '---------------------------------------------------------- Monitor Options  ---------------------------------------------------------------

    Private Sub ChckBxDisableMonitorSleep_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxDisableMonitorSleep.CheckedChanged
        '   if checkbox is enabled, then disallow the monitor from going to sleep.
        '   other wise allow monitor to go to sleep as system [OS] default.

        If chckBxDisableMonitorSleep.Checked Then
            frmKlock.usrSettings.usrDisableMonitorSleep = True
            KlockThings.KeepMonitorActive()
        Else
            frmKlock.usrSettings.usrDisableMonitorSleep = False
            KlockThings.RestoreMonitorSettings()
        End If
    End Sub

    Private Sub chckBxIdleTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxIdleTime.CheckedChanged
        '   Sets options for display idle time.
        '   Is selected, then select to display on analogue klock.

        frmKlock.DisplayIdleTime.Checked = chckBxIdleTime.Checked

        If chckBxIdleTime.Checked Then
            frmKlock.usrSettings.usrAnalogueKlockShowIdleTime = True
            chckBxAnlgKlockIdleTime.Checked = True
            chckBxAnlgKlockTime.Checked = True
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------ Logging Settings ----------

    Private Sub ChckBxLoging_CheckedChanged(sender As Object, e As EventArgs) Handles ChckBxLoging.CheckedChanged
        '   Only enable logging settings, if logging is enabled.

        nmrcUpDwnLogDaysKeep.Enabled = ChckBxLoging.Checked
        lblLogFilePath.Enabled = ChckBxLoging.Checked
        lstBxLogFiles.Enabled = ChckBxLoging.Checked

        '   if enabled, the re-scan directory for log files.
        If ChckBxLoging.Checked Then
            poolForLogs()
        Else
            lstBxLogFiles.Items.Clear()
        End If
    End Sub

    Private Sub ChckBxMemoDefaultPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxMemoDefaultPassword.CheckedChanged

        txtBxMemoDefaultPassword.Enabled = chckBxMemoDefaultPassword.Checked
        txtBxMemoDefaultPassword.ReadOnly = chckBxMemoDefaultPassword.Checked
        nmrcUpDwnMemoDecrypt.Enabled = chckBxMemoDefaultPassword.Checked
    End Sub

    Private Sub chckBxOptionsRememberKlockMode_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxOptionsRememberKlockMode.CheckedChanged

        cmbBxDefaultMode.Enabled = chckBxOptionsRememberKlockMode.Checked
    End Sub

    Private Sub ChckBxOptionsRunOnStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxOptionsRunOnStartup.CheckedChanged
        '   Sets or deletes the registry key required for running on windows start up.
        '   Only sets for current user.

        Try
            If chckBxOptionsRunOnStartup.Checked Then
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("frmOptions.ChckBxOptionsRunOnStartup_CheckedChanged", ex)
            displayAction.DisplayReminder(ex.Message, "G", "Registry Error :: Cant write entry to Registry")
        End Try
    End Sub

    Private Sub chckBxOptionsStartupMinimised_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxOptionsStartupMinimised.CheckedChanged
        '   Only allow to select start up mode, if klock not starting minimised.

        chckBxOptionsRememberKlockMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
        cmbBxDefaultMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
    End Sub

    '-------------------------------------------------------------- Sayings ------------------------------------------------------------------

    Private Sub ChckBxSayings_CheckedChanged(sender As Object, e As EventArgs) Handles ChckBxSayings.CheckedChanged
        '   determines if sayings are to be used.
        '   if not, disable all sayings options.
        '   Also, set time to state of checkbox.  i.e. if checked start timer.

        lblSayings1.Enabled = ChckBxSayings.Checked
        btnSayingNotificationColour.Enabled = ChckBxSayings.Checked
        lblSayings2.Enabled = ChckBxSayings.Checked
        btnSayingNotificationFont.Enabled = ChckBxSayings.Checked
        lblSayings3.Enabled = ChckBxSayings.Checked
        nmrcUpDwnSayingDisplay.Enabled = ChckBxSayings.Checked
        lblSayings4.Enabled = ChckBxSayings.Checked
        nmrcUpDwnSayingNotificationTimeOut.Enabled = ChckBxSayings.Checked
        lblSayings5.Enabled = ChckBxSayings.Checked
        nmrcUpDwnSayingNotificationOpacity.Enabled = ChckBxSayings.Checked
        btnSayingNotificationTest.Enabled = ChckBxSayings.Checked

        frmKlock.tmrSayings.Interval = nmrcUpDwnSayingDisplay.Value * 1000
        frmKlock.tmrSayings.Enabled = ChckBxSayings.Checked
    End Sub

    Private Sub ChckBxTimeHourlyChimes_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chckBxTimeHourlyChimes.CheckedChanged
        '   if chimes are selected, disable the pips.

        If chckBxTimeHourlyChimes.Checked Then
            chckBxTimeHourPips.Enabled = False
            chckBxTimeHourPips.Checked = False
            chckBxTimeHalfChimes.Enabled = True
            chckBxTimeQuarterChimes.Enabled = True
        Else
            chckBxTimeHourPips.Enabled = True
            chckBxTimeHalfChimes.Checked = False
            chckBxTimeHalfChimes.Enabled = False
            chckBxTimeQuarterChimes.Checked = False
            chckBxTimeQuarterChimes.Enabled = False
        End If
    End Sub

    Private Sub ChckBxTimeHourPips_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chckBxTimeHourPips.CheckedChanged
        '   It the pips are selected, disable all chimes.

        If chckBxTimeHourPips.Checked Then
            chckBxTimeHourlyChimes.Enabled = False
            chckBxTimeHourlyChimes.Checked = False
            chckBxTimeHalfChimes.Enabled = False
            chckBxTimeHalfChimes.Checked = False
            chckBxTimeQuarterChimes.Enabled = False
            chckBxTimeQuarterChimes.Checked = False
        Else
            chckBxTimeHourlyChimes.Enabled = True
            chckBxTimeHalfChimes.Enabled = True
            chckBxTimeQuarterChimes.Enabled = True
        End If
    End Sub

    Private Sub ChckBxTimeSystem12_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxTimeSystem12.CheckedChanged

        chckBxTimeSystem24.Checked = Not chckBxTimeSystem12.Checked
    End Sub

    Private Sub ChckBxTimeSystem24_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxTimeSystem24.CheckedChanged

        chckBxTimeSystem12.Checked = Not chckBxTimeSystem24.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne12_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxTimeTimeOne12.CheckedChanged

        chckBxTimeTimeOne24.Checked = Not chckBxTimeTimeOne12.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne24_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxTimeTimeOne24.CheckedChanged

        chckBxTimeTimeOne12.Checked = Not chckBxTimeTimeOne24.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo12_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxTimeTimeTwo12.CheckedChanged

        chckBxTimeTimeTwo24.Checked = Not chckBxTimeTimeTwo12.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo24_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxTimeTimeTwo24.CheckedChanged

        chckBxTimeTimeTwo12.Checked = Not chckBxTimeTimeTwo24.Checked
    End Sub

    Private Sub ChckBxTimeToast_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chckBxTimeToast.CheckedChanged
        '   If checkbox to enable notification message every nth minutes if checked, enables the minute counter.

        upDwnTimeDisplay.Enabled = chckBxTimeToast.Checked
    End Sub
    '-----------------------------------------------------------Time---------------------------------------------------------------

    Private Sub chckBxTimeTwoFormats_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chckBxTimeTwoFormats.CheckedChanged
        '   Only display two time default format if needed.

        lblTimeTwo.Enabled = chckBxTimeTwoFormats.Checked
        cmbBxDefaultTimeTwoFormat.Enabled = chckBxTimeTwoFormats.Checked
    End Sub

    Private Sub cxtBxAnlgKlock_TextChanged(sender As Object, e As EventArgs) Handles txtBxAnlgKlock.TextChanged
        '   Sets the dial text for the analogue klock

        frmKlock.usrSettings.usrAnalogueKlockText = txtBxAnlgKlock.Text
    End Sub


    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '   When opened, set settings

        Dim tabs() As String = {"Fuzzy Time", "World Klock", "Count Down", "Timer", "Reminder", "Friends", "Events", "Memo", "Converter"}
        Dim mode() As String = {"Klock", "Analogue Klock", "Small Text Klock", "Big text Klock", "Binary Klock"}

        cmbBxDefaultTab.Items.AddRange(tabs)
        cmbBxDefaultMode.Items.AddRange(mode)

        '   Only allow to select start up mode, if klock not starting minimised.
        If chckBxOptionsStartupMinimised.Checked Then
            chckBxOptionsRememberKlockMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
            cmbBxDefaultMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
        Else
            cmbBxDefaultMode.Enabled = chckBxOptionsRememberKlockMode.Checked
        End If

        displayAction = New selectAction

        txtBxArchiveFile.Text = "Klock_" & DateTime.Now.ToString("ddMMyyyy") & ".zip"
        lblOptionSavepath.Text = System.IO.Path.Combine(frmKlock.usrSettings.usrOptionsSavePath(), frmKlock.usrSettings.usrOptionsSaveFile())

        checkPicture()

        showArchiveButtons(False)
        setSettings()
    End Sub

    Private Sub lstBxLogFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBxLogFiles.SelectedIndexChanged
        '   If an entry in the log file list is clicked, the log file is loaded into the default text editor.

        Dim fName As String = lstBxLogFiles.Items(lstBxLogFiles.SelectedIndex)

        '   in case file has been removed.
        If Not My.Computer.FileSystem.FileExists(fName) Then Exit Sub

        Dim ps As New ProcessStartInfo()
        With ps
            .FileName = fName
            .UseShellExecute = True
        End With

        Try
            Dim p As New Process
            p.StartInfo = ps
            p.Start()
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("frmOptions.lstBxLogFiles_SelectedIndexChanged", ex)
            frmKlock.displayAction.DisplayReminder("Sorry, can't find log. " & ex.Message, "G", "Log File Error")
        End Try
    End Sub

    Private Sub NmrcUpDwnEventNotificationOpacity_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nmrcUpDwnEventNotificationOpacity.ValueChanged
        'Set the Opacity of the Event Notification.

        frmKlock.usrSettings.usrEventNotificationOpacity = nmrcUpDwnEventNotificationOpacity.Value
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        frmKlock.usrSettings.usrNotificationOpacity = nmrcUpDwnNotificationOpacity.Value
    End Sub


    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrNotificationTimeOut = nmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub nmrcUpDwnSayingNotificationOpacity_ValueChanged(sender As Object, e As EventArgs) Handles nmrcUpDwnSayingNotificationOpacity.ValueChanged
        'Set the Opacity of the Sayings.

        frmKlock.usrSettings.usrSayingsOpacity = nmrcUpDwnSayingNotificationOpacity.Value
    End Sub

    Private Sub nmrcUpDwnSayingNotificationTimeOut_ValueChanged(sender As Object, e As EventArgs) Handles nmrcUpDwnSayingNotificationTimeOut.ValueChanged
        '   set the time out value of the Sayings.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrSayingsTimeOut = nmrcUpDwnSayingNotificationTimeOut.Value * 1000
    End Sub

    Private Sub showArchiveButtons(ByVal b As Boolean)
        '   either show of hide the archive buttons.
        '   not enough space on tab for buttons.

        btnArchiveLoad.Visible = b
        btnArchiveSave.Visible = b
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------tab control ---------------------

    Private Sub TabCntrlOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbCntrlOptions.SelectedIndexChanged
        '   actions depending upon which tab is chosen.

        Select Case tbCntrlOptions.SelectedIndex
            Case 0              '   Global options
                showArchiveButtons(False)
            Case 1              '   Notification options
                showArchiveButtons(False)
            Case 2              '   Time options
                showArchiveButtons(False)
            Case 3              '   other Stuff
                showArchiveButtons(False)
            Case 4              '   Analogue Klock options
                showArchiveButtons(False)
            Case 5              '   Extra Klocks options
                showArchiveButtons(False)
            Case 6              '   Sticky Notes options
                showArchiveButtons(False)
            Case 7              '   Archive options
                showArchiveButtons(True)
            Case 8              '   Event options
                showArchiveButtons(False)
            Case 9              '   memo options
                showArchiveButtons(False)
            Case 10              '   Logging options
                showArchiveButtons(False)
                poolForLogs()
        End Select
    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles trckBrOptionsVolume.Scroll
        '   Set system volume.

        frmKlock.usrSettings.usrSoundVolume = trckBrOptionsVolume.Value
    End Sub

End Class