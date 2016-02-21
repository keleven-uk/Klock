Public Class frmClipboardMonitor
    '   Manages the clipboard.
    '   When monitoring the clipboard is enabled in klock options], if something is copied to the clipboard
    '   is should be added to the list-box on this form.  Then any entry ion the list-box can then be
    '   copied back to the clipboard and used in any applications.  In a effect, this remembers the clipboard history.

    '   The majority of the code is placed in frmKlock.  This is because it needs to hook the main application [klock]
    '   into the clipboard viewer chain.

    '   Will copy Text, Files & images.

    Public CL_IMAGE As Boolean = False              '   image copy kludge, see addToList()


    Public displayAction As selectAction            '   instance of selectAction, allows different actions to be performed.

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '   Close button has been pressed.
        '   NB : does not disable clipboard monitoring.

        tmrClipboardMonitor.Enabled = False
        Close()
    End Sub

    Private Sub frmClipboardMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Start the time on form load.

        displayAction = New selectAction                '   user selected actions

        tmrClipboardMonitor.Enabled = True
        btnCopy.Enabled = False

        If frmKlock.usrSettings.usrClipboardMonitorSavePosition Then
            Top = frmKlock.usrSettings.usrClipboardMonitorTop
            Left = frmKlock.usrSettings.usrClipboardMonitorLeft
        End If

        CreateClipboardSave()                           '   Creates temp dir for saving clipboard images.
    End Sub

    Private Sub frmClipboardMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   Save form position, is enabled, on closing.

        If frmKlock.usrSettings.usrClipboardMonitorSavePosition Then
            frmKlock.usrSettings.usrClipboardMonitorTop = Top
            frmKlock.usrSettings.usrClipboardMonitorLeft = Left
        End If

        DeleteClipboardSave()                           '   Deletes temp dir for saving clipboard images, will include all images..

        frmKlock.usrSettings.writeSettings()             '   save settings, not sure if anything has changed.
    End Sub

    'Private Sub lstBxClipboardData_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    '   Only enable copy button, it there is items to copy.

    '    If LstVwClipboardData.Items.Count = 0 Then
    '        btnCopy.Enabled = False
    '    Else
    '        btnCopy.Enabled = True
    '    End If
    'End Sub

    Private Sub LstVwClipboardData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstVwClipboardData.SelectedIndexChanged
        '   Only enable copy button, it there is items to copy.

        If LstVwClipboardData.Items.Count = 0 Then
            btnCopy.Enabled = False
        Else
            btnCopy.Enabled = True
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        '   Clears the data in the list-box.

        LstVwClipboardData.Items.Clear()
        btnCopy.Enabled = False
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        '   Copies the selected list-box entry to the clipboard.

        CL_IMAGE = False                                                                    '   image copy kludge, see addToList()

        Dim itmText = LstVwClipboardData.FocusedItem.SubItems(2).Text

        Try
            Select Case LstVwClipboardData.FocusedItem.SubItems(0).Text

                Case "Text"                                                                 '   Copies text

                    My.Computer.Clipboard.SetText(itmText, TextDataFormat.Text)

                Case "UNI"                                                                 '   Copies Unicode text

                    My.Computer.Clipboard.SetText(itmText, TextDataFormat.UnicodeText)

                Case "RTF"                                                                 '   Copies RTF text

                    My.Computer.Clipboard.SetText(itmText, TextDataFormat.Rtf)

                Case "HTML"                                                                 '   Copies HTML

                    My.Computer.Clipboard.SetText(itmText, TextDataFormat.Html)

                Case "CSV"                                                                 '   Copies CSV

                    My.Computer.Clipboard.SetText(itmText, TextDataFormat.CommaSeparatedValue)

                Case "File"                                                                 '   Copies file

                    If My.Computer.FileSystem.FileExists(itmText) Then
                        Dim filePaths As New System.Collections.Specialized.StringCollection()
                        filePaths.Add(itmText)                                              '   Get file name from list-view.
                        My.Computer.Clipboard.SetFileDropList(filePaths)                    '   Copy file to clipboard
                    Else
                        displayAction.DisplayReminder("Clipboard Error", itmText & "No Longer Exists", "G")
                        LstVwClipboardData.FocusedItem.Remove()
                    End If

                Case "Dir"                                                                 '   Copies dir - similar to file.

                    If My.Computer.FileSystem.DirectoryExists(itmText) Then
                        Dim filePaths As New System.Collections.Specialized.StringCollection()
                        filePaths.Add(itmText)                                              '   Get file name from list-view.
                        My.Computer.Clipboard.SetFileDropList(filePaths)                    '   Copy file to clipboard
                    Else
                        displayAction.DisplayReminder("Clipboard Error", itmText & "No Longer Exists", "G")
                        LstVwClipboardData.FocusedItem.Remove()
                    End If

                Case "Image"                                                                '   Copies Images

                    CL_IMAGE = True                                                         '   image copy kludge, see addToList()

                    If My.Computer.FileSystem.FileExists(itmText) Then
                        Dim i As Image = Image.FromFile(itmText)                            '   Get file name of image from list-view.
                        My.Computer.Clipboard.SetImage(i)                                   '   Copy image to clipboard
                        i.Dispose()
                    Else
                        displayAction.DisplayReminder("Clipboard Error", itmText & "No Longer Exists", "G")
                        LstVwClipboardData.FocusedItem.Remove()
                    End If

                Case Else
                    '   probably error, ignore
            End Select


        Catch ex As ArgumentException
            MessageBox.Show("ERROR :: Copying to clipboard" & ex.Message, "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub addToList(text As String, type As String)
        '   Clipboard has data.
        '   Only adds the data is not already remembered - so only one instance of data is displayed.
        '   This gets around the problem been triggered by klock copying to the clipboard :-)
        '   This also causes a problem with images.  Because the clipboard does not seem to know
        '   where the image has come from [no file location], i give it a random filename when i save it away.
        '   This means when the image is selected again in the clipboard history, it will appear twice in that history.
        '   A kludge is used to stop this, CL_IMAGE is used to indicate that an image is being processed
        '   and not to be added to the history a second time.


        Dim arr As String() = New String(2) {}
        Dim itm As ListViewItem
        Dim found As Boolean = False

        arr(0) = type
        arr(1) = Format(Now, "Short Date") & " : " & If(frmKlock.usrSettings.usrTimeSystem24Hour, String.Format("{0:HH:mm:ss}", System.DateTime.Now), String.Format("{0:hh:mm:ss tt}", System.DateTime.Now))
        arr(2) = text

        itm = New ListViewItem(arr)

        itm.ForeColor = itemForecolor(type)

        '   iterate through items to see if already there - items.contains does not seem to work.

        For Each LvItem As ListViewItem In LstVwClipboardData.Items
            If LvItem.SubItems(2).Text.Contains(text) Then found = True
        Next

        If CL_IMAGE Then found = True                             '   image copy kludge, see addToList()

        If Not found Then
            LstVwClipboardData.Items.Add(itm)
            LstVwClipboardData.Items.Item(LstVwClipboardData.Items.Count - 1).EnsureVisible()

            If Not Visible Then Show()
        End If
    End Sub

    Private Sub btnClearClipboard_Click(sender As Object, e As EventArgs) Handles btnClearClipboard.Click
        '    Clears the clipboard.

        My.Computer.Clipboard.Clear()
    End Sub

    Private Sub tmrClipboardMonitor_Tick(sender As Object, e As EventArgs) Handles tmrClipboardMonitor.Tick

        updateStatusBar()
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns off"

        '                                               if running on battery, change status info colour to red as a warning.
        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = Color.Black
            StsLblDate.ForeColor = Color.Black
            StsLblKeys.ForeColor = Color.Black
        Else
            stsLblTime.ForeColor = Color.Red
            StsLblDate.ForeColor = Color.Red
            StsLblKeys.ForeColor = Color.Red
        End If

        If My.Computer.Keyboard.CapsLock.ToString() Then strKey = Replace(strKey, "c", "C")
        If My.Computer.Keyboard.NumLock.ToString() Then strKey = Replace(strKey, "n", "N")
        If My.Computer.Keyboard.ScrollLock.ToString() Then strKey = Replace(strKey, "s", "S")
        If KlockThings.HaveInternetConnection() Then strKey = Replace(strKey, "off", "ON")

        stsLblTime.Text = If(frmKlock.usrSettings.usrTimeSystem24Hour, String.Format("{0:HH:mm:ss}", System.DateTime.Now), String.Format("{0:hh:mm:ss tt}", System.DateTime.Now))

        '   Me.stsLblTime.Text = Format(Now, "Long Time")
        StsLblDate.Text = Format(Now, "Long Date")
        StsLblKeys.Text = strKey

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If

    End Sub

    Private Sub CreateClipboardSave()
        '   Image copied from the clipboard are saved for later use.
        '   Create holding directory, if needed.
        '   Holding directory currently hard coded to be System.IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "Klock\Clipsave")

        Dim dir As String = frmKlock.usrSettings.usrClipboardSavePath

        If Not My.Computer.FileSystem.DirectoryExists(dir) Then
            Try
                My.Computer.FileSystem.CreateDirectory(dir)
            Catch ex As ArgumentException
                displayAction.DisplayReminder("Clipboard Error", ex.Message, "G")
            End Try
        End If
    End Sub

    Private Sub DeleteClipboardSave()
        '   Delete holding directory, if needed.

        Dim dir As String = frmKlock.usrSettings.usrClipboardSavePath

        If My.Computer.FileSystem.DirectoryExists(dir) Then
            Try
                My.Computer.FileSystem.DeleteDirectory(dir, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As ArgumentException
                displayAction.DisplayReminder("Clipboard Error", ex.Message, "G")
            End Try
        End If
    End Sub

    '   Not sure this sub should be here, maybe in klockThings.vb.  Or create a clipboardThings.vb.
    '   Does simplify the call to addlist() though.

    Public Sub handleClipboardChanged()
        '   Clipboard has data.
        '   Only adds the data is not already remembered - so only one instance of data is displayed.
        '   This gets around the problem been triggered by klock copying to the clipboard :-)

        '   Handles data as text, file, image

        If My.Computer.Clipboard.ContainsText(TextDataFormat.Text) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.Text), "Text")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.UnicodeText) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.UnicodeText), "UNI")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.Rtf), "RTF")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.Html) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.Html), "HTML")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.CommaSeparatedValue), "CSV")

        ElseIf My.Computer.Clipboard.ContainsFileDropList Then

            Dim s As String = My.Computer.Clipboard.GetFileDropList.Item(0)

            If My.Computer.FileSystem.FileExists(s) Then
                addToList(s, "File")
            Else
                addToList(s, "Dir")
            End If

        ElseIf My.Computer.Clipboard.ContainsImage Then

            Dim i As Image = My.Computer.Clipboard.GetImage

            Dim fn As String = System.IO.Path.Combine(frmKlock.usrSettings.usrClipboardSavePath, Guid.NewGuid.ToString + ".png")

            addToList(fn, "Image")
            i.Save(fn, Imaging.ImageFormat.Png)

            i.Dispose()

        Else
            '   frmClipboardMonitor.addToList("Unknown clipboard type " & My.Computer.Clipboard.GetType.ToString, "Error")
        End If
    End Sub
End Class