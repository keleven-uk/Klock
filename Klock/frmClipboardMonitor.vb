Imports System.Text
Imports System.IO

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
    Public usrFonts As UserFonts                    '   instance of user fonts.


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '   Close button has been pressed.
        '   NB : does not disable clipboard monitoring.

        tmrClipboardMonitor.Enabled = False
        Close()
    End Sub

    Private Sub frmClipboardMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Start the time on form load.

        displayAction = New selectAction                '   user selected actions
        usrFonts = New UserFonts                        '   user fonts

        LstbxClipboardData.DrawMode = DrawMode.OwnerDrawFixed
        LstbxClipboardData.Font = usrFonts.getFont()

        If frmKlock.usrSettings.usrClipboardMonitorSaveCSV Then
            btnSave.Text = "Save as .csv "
            btnLoad.Text = "Load as .csv "
        Else
            btnSave.Text = "Save as .bin "
            btnLoad.Text = "Load as .bin "
        End If

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

    Private Sub LstbxClipboardData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstbxClipboardData.SelectedIndexChanged
        '   Only enable copy button, it there is items to copy.

        If LstbxClipboardData.Items.Count = 0 Then
            btnCopy.Enabled = False
        Else
            btnCopy.Enabled = True
        End If
    End Sub

    Private Sub LstbxClipboardData_Click(sender As Object, e As EventArgs) Handles LstbxClipboardData.Click

        If LstbxClipboardData.SelectedIndex >= 0 Then
            LstbxClipboardData.SetSelected(LstbxClipboardData.SelectedIndex, True)
            btnCopy_Click(sender, e)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        '   Clears the data in the list-box.

        LstbxClipboardData.Items.Clear()
        btnCopy.Enabled = False
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        '   Copies the selected list-box entry to the clipboard.

        Dim cl As New clipItem

        CL_IMAGE = False                                                                    '   image copy kludge, see addToList()

        cl = LstbxClipboardData.Items(LstbxClipboardData.SelectedIndex)

        Dim itmText = cl.itemText

        Try
            Select Case cl.itemType

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
                        LstbxClipboardData.Items(LstbxClipboardData.SelectedIndex).Remove()
                    End If

                Case "Dir"                                                                 '   Copies dir - similar to file.

                    If My.Computer.FileSystem.DirectoryExists(itmText) Then
                        Dim filePaths As New System.Collections.Specialized.StringCollection()
                        filePaths.Add(itmText)                                              '   Get file name from list-view.
                        My.Computer.Clipboard.SetFileDropList(filePaths)                    '   Copy file to clipboard
                    Else
                        displayAction.DisplayReminder("Clipboard Error", itmText & "No Longer Exists", "G")
                        LstbxClipboardData.Items(LstbxClipboardData.SelectedIndex).Remove()
                    End If

                Case "Image"                                                                '   Copies Images

                    CL_IMAGE = True                                                         '   image copy kludge, see addToList()

                    If My.Computer.FileSystem.FileExists(itmText) Then
                        Dim i As Image = Image.FromFile(itmText)                            '   Get file name of image from list-view.
                        My.Computer.Clipboard.SetImage(i)                                   '   Copy image to clipboard
                        i.Dispose()
                    Else
                        displayAction.DisplayReminder("Clipboard Error", itmText & "No Longer Exists", "G")
                        LstbxClipboardData.Items(LstbxClipboardData.SelectedIndex).Remove()
                    End If

                Case Else
                    '   probably error, ignore
            End Select

        Catch ex As ArgumentException
            MessageBox.Show("ERROR :: Copying to clipboard" & ex.Message, "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub addToList(text As String, dateTime As String, type As String)
        '   Clipboard has data.
        '   Only adds the data is not already remembered - so only one instance of data is displayed.
        '   This gets around the problem been triggered by klock copying to the clipboard :-)
        '   This also causes a problem with images.  Because the clipboard does not seem to know
        '   where the image has come from [no file location], i give it a random filename when i save it away.
        '   This means when the image is selected again in the clipboard history, it will appear twice in that history.
        '   A kludge is used to stop this, CL_IMAGE is used to indicate that an image is being processed
        '   and not to be added to the history a second time.

        Dim cl As New clipItem
        Dim found As Boolean = False

        cl.itemType = type
        cl.itemDateTime = dateTime
        cl.itemText = text

        '   iterate through items to see if already there - items.contains does not seem to work.

        For Each LbItem As clipItem In LstbxClipboardData.Items
            If LbItem.itemText.Contains(text) Then found = True
        Next

        If CL_IMAGE Then found = True                             '   image copy kludge, see addToList()

        If Not found Then

            LstbxClipboardData.Items.Add(cl)
            ListBoxEnsureVisible(LstbxClipboardData)

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

        stsLblTime.Text = statusTime()
        StsLblDate.Text = Format(Now, "Long Date")
        StsLblKeys.Text = statusInfo()

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = "Idle Time :: " & KlockThings.idleTime()
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

        Dim dateTime As String = (String.Format("{0} : {1}", Format(Now, "Short Date"), statusTime()))

        If My.Computer.Clipboard.ContainsText(TextDataFormat.Text) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.Text), dateTime, "Text")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.UnicodeText) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.UnicodeText), dateTime, "UNI")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.Rtf) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.Rtf), dateTime, "RTF")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.Html) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.Html), dateTime, "HTML")

        ElseIf My.Computer.Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue) Then

            addToList(My.Computer.Clipboard.GetText(TextDataFormat.CommaSeparatedValue), dateTime, "CSV")

        ElseIf My.Computer.Clipboard.ContainsFileDropList Then

            Dim s As String = My.Computer.Clipboard.GetFileDropList.Item(0)

            If My.Computer.FileSystem.FileExists(s) Then
                addToList(s, dateTime, "File")
            Else
                addToList(s, dateTime, "Dir")
            End If

        ElseIf My.Computer.Clipboard.ContainsImage Then

            Dim i As Image = My.Computer.Clipboard.GetImage

            Dim fn As String = System.IO.Path.Combine(frmKlock.usrSettings.usrClipboardSavePath, Guid.NewGuid.ToString + ".png")

            addToList(fn, dateTime, "Image")
            i.Save(fn, Imaging.ImageFormat.Png)

            i.Dispose()

        Else
            '   frmClipboardMonitor.addToList("Unknown clipboard type " & My.Computer.Clipboard.GetType.ToString, "Error")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If frmKlock.usrSettings.usrClipboardMonitorSaveCSV Then
            saveClipboardCVS()
        Else
            saveClipboardBIN()
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        If frmKlock.usrSettings.usrClipboardMonitorSaveCSV Then
            loadClipboardCVS()
        Else
            loadClipboardBIN()
        End If
    End Sub

    Private Sub LstbxClipboardData_DrawItem(sender As Object, e As DrawItemEventArgs) Handles LstbxClipboardData.DrawItem
        '   This routine is called for every item when re-drawn.
        '   This enables us to set the for-colour [brush colour] of each item.  :-)

        e.DrawBackground()

        Dim cl As New clipItem
        Dim myBrush As Brush
        Dim itm As String = LstbxClipboardData.Items(e.Index).ToString                      '   retrieve item as string.
        Dim type As String = Microsoft.VisualBasic.Left(itm, cl.itemTypeSize()).Trim()      '   retrieve item type.

        myBrush = itemBrushcolor(type)

        e.Graphics.DrawString(itm, e.Font, myBrush, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        e.DrawFocusRectangle()

    End Sub

    Public Function itemBrushcolor(type As String) As Brush
        '   Returns a colour for use in the clipboard history brush colour.
        '   used in frmClipboardMonitor.LstbxClipboardData_DrawItem

        Select Case type                                        '   set up text colour depending on object type
            Case "Text"
                Return Brushes.Red
            Case "UNI"
                Return Brushes.DeepPink
            Case "RTF"
                Return Brushes.BurlyWood
            Case "HTML"
                Return Brushes.DarkSlateBlue
            Case "CSVL"
                Return Brushes.Firebrick
            Case "File"
                Return Brushes.Blue
            Case "Dir"
                Return Brushes.LightBlue
            Case "Audio"
                Return Brushes.DarkGoldenrod
            Case "Image"
                Return Brushes.Green
            Case "Error"
                Return Brushes.DarkOrange
            Case Else
                '   probably error, ignore
                Return Brushes.Black
        End Select
    End Function

End Class