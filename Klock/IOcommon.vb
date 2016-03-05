Imports System.Runtime.Serialization.Formatters.Binary
Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.IO

Module IOcommon
    '   Friends, Events & Memo share similar routines to read and save files.
    '   Moved the sub's into here, will try and reduce the redundancy.

    Public Sub saveFriends()
        '   Save friends to file in data directory.
        '   Creates a list of all entries in the list-view box and then writes this list to a binary file.

        Dim saveFile As FileStream = File.Create(getPath("Friend"))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Person)
        Dim p As New Person

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each p In frmKlock.LstBxFriends.Items        '   Create list.
            AL.Add(p)
        Next

        Try
            Formatter.Serialize(saveFile, AL)           '   Write list to binary file.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Friends Error", "Error saving Friends File." & vbCrLf & ex.Message, "G")
        End Try

        saveFile.Close()

        Formatter = Nothing
    End Sub

    Public Sub loadFriends()
        '   Loads friends from file and populate the list-view box.
        '   Loads file into a list and then transfers each item in the list to the list-view box.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(getPath("Friend")) Then
            readFile = File.OpenRead(getPath("Friend"))
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("Friends", "No Friends file found - will create if needed.", "G")
            Exit Sub
        End If

        Dim AL As New List(Of Person)
        Dim p As New Person

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Friends Error", "Error loading Friends File. " & ex.Message, "G")
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        frmKlock.LstBxFriends.Items.Clear()
        frmKlock.knownCities.Clear()

        For Each p In AL                            '   For each item in the list.
            frmKlock.LstBxFriends.Items.Add(p)      '   Populate list-view.
            frmKlock.FriendsAddToKnown(p)           '   Populate autocomplete collections.
        Next

        readFile.Close()
        Formatter = Nothing
    End Sub


    Public Sub saveEvents()
        '   Save Events to file in data directory.
        '   Creates a list of all entries in the list-view box and then writes this list to a binary file.

        Dim saveFile As FileStream = File.Create(getPath("Event"))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Events)
        Dim e As New Events

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each e In frmKlock.LstBxEvents.Items        '   Create list.
            AL.Add(e)
        Next

        Try
            Formatter.Serialize(saveFile, AL)           '   Write list to binary file.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Events Error", "Error saving Events File." & vbCrLf & ex.Message, "G")
        End Try

        saveFile.Close()

        Formatter = Nothing
    End Sub

    Public Sub loadEvents()
        '   Loads Events from file and populate the list-view box.
        '   Loads file into a list and then transfers each item in the list to the list-view box.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(getPath("Event")) Then
            readFile = File.OpenRead(getPath("Event"))
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("Event", "No Event file found - will create if needed.", "G")
            Exit Sub
        End If

        Dim AL As New List(Of Events)
        Dim e As New Events

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Events Error", "Error Events Friends File. " & ex.Message, "G")
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        frmKlock.LstBxEvents.Items.Clear()

        For Each e In AL                            '   For each item in the list.
            frmKlock.LstBxEvents.Items.Add(e)       '   Populate list-view.
        Next

        readFile.Close()
        Formatter = Nothing

        If frmKlock.LstBxEvents.Items.Count > 0 Then
            frmKlock.tmrEvents.Enabled = True
            frmKlock.btnEventsCheck.Enabled = True
        Else
            frmKlock.tmrEvents.Enabled = False
            frmKlock.btnEventsCheck.Enabled = False
        End If
    End Sub


    Public Sub saveMemo()
        '   Save Memo to file in data directory.
        '   Creates a list of all Memo in the list-view box and then writes this list to a binary file.

        Dim saveFile As FileStream = File.Create(getPath("Memo"))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Memo)
        Dim m As New Memo

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each m In frmKlock.LstBxMemo.Items        '   Create list.
            AL.Add(m)
        Next

        Try
            Formatter.Serialize(saveFile, AL)       '   Write list to binary file.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Memo Error", "Error saving Memo File." & vbCrLf & ex.Message, "G")
        End Try

        saveFile.Close()

        Formatter = Nothing
    End Sub

    Public Sub loadMemo()
        '   Loads Memo from file and populate the list-view box.
        '   Loads file into a list and then transfers each item in the list to the list-view box.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(getPath("Memo")) Then
            readFile = File.OpenRead(getPath("Memo"))
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("Memo", "No Memo file found - will create if needed.", "G")
            Exit Sub
        End If

        Dim AL As New List(Of Memo)
        Dim m As New Memo

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Memo Error", "Error Memo Friends File. " & ex.Message, "G")
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        frmKlock.LstBxMemo.Items.Clear()

        For Each m In AL                    '   For each item in the list.
            frmKlock.LstBxMemo.Items.Add(m)       '   Populate listview.
        Next

        readFile.Close()
        Formatter = Nothing
    End Sub

    Public Function getPath(ByVal mode As String) As String

        Dim file As String = ""
        Dim dir As String = frmKlock.usrSettings.usrOptionsSavePath

        Select Case mode
            Case "Friend"
                file = frmKlock.usrSettings.usrFriendsFile
            Case "Event"
                file = frmKlock.usrSettings.usrEventsFile
            Case "Memo"
                file = frmKlock.usrSettings.usrMemoFile
            Case "Settings"
                file = frmKlock.usrSettings.usrOptionsSaveFile
        End Select

        Return System.IO.Path.Combine(dir, file)
    End Function

    ' ----------------------------------------------------- routines for save and load clipboard --------------------------------------------------------------

    Public Sub saveClipboardCVS()

        frmClipboardMonitor.SaveFileDialog1.Title = "Save Clipboard as CSV"
        frmClipboardMonitor.SaveFileDialog1.FileName = String.Empty
        frmClipboardMonitor.SaveFileDialog1.Filter = "CSV Files (*.csv*)|*.csv"
        frmClipboardMonitor.SaveFileDialog1.AddExtension = True
        frmClipboardMonitor.SaveFileDialog1.DefaultExt = ".csv"

        If frmClipboardMonitor.SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim csvFileName As String = frmClipboardMonitor.SaveFileDialog1.FileName

            Dim csvFileContents As New StringBuilder
            Dim currLine As String = String.Empty
            Dim cl As New clipItem

            'Write out the data.

            For Each cl In frmClipboardMonitor.LstbxClipboardData.Items

                currLine = (String.Format("{0},{1},{2}", cl.itemType, cl.itemDateTime, cl.itemText))

                csvFileContents.AppendLine(currLine.Substring(0, currLine.Length - 1))
                currLine = String.Empty
            Next

            Try
                '   Create the file
                Dim csvFile As New StreamWriter(csvFileName)

                csvFile.WriteLine(csvFileContents.ToString)
                csvFile.Flush()
                csvFile.Dispose()
            Catch ex As Exception
                frmKlock.displayAction.DisplayReminder("Clipboard Error", "Error saving Clipboard CSV File." & vbCrLf & ex.Message, "G")
            End Try
        End If
    End Sub

    Public Sub saveClipboardBIN()

        '   Save Clipboard history items to file in data directory.
        '   Creates a list of all entries in the list-view box and then writes this list to a binary file.

        frmClipboardMonitor.SaveFileDialog1.Title = "Save Clipboard as BIN"
        frmClipboardMonitor.SaveFileDialog1.FileName = String.Empty
        frmClipboardMonitor.SaveFileDialog1.Filter = "BIN Files (*.bin*)|*.bin"
        frmClipboardMonitor.SaveFileDialog1.AddExtension = True
        frmClipboardMonitor.SaveFileDialog1.DefaultExt = ".bin"

        If frmClipboardMonitor.SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim binFileName As FileStream = File.Create(frmClipboardMonitor.SaveFileDialog1.FileName)

            binFileName.Seek(0, SeekOrigin.End)

            Dim AL As New List(Of clipItem)
            Dim cl As New clipItem

            Dim Formatter As BinaryFormatter = New BinaryFormatter

            For Each cl In frmClipboardMonitor.LstbxClipboardData.Items        '   Create list.
                AL.Add(cl)
            Next

            Try
                Formatter.Serialize(binFileName, AL)           '   Write list to binary file.
            Catch ex As Exception
                frmKlock.displayAction.DisplayReminder("Clipboard Error", "Error saving Clipboard binary File." & vbCrLf & ex.Message, "G")
            End Try

            binFileName.Close()

            Formatter = Nothing
        End If
    End Sub

    Public Sub loadClipboardCVS()

        frmClipboardMonitor.LstbxClipboardData.Items.Clear()

        frmClipboardMonitor.OpenFileDialog1.FileName = ""
        frmClipboardMonitor.OpenFileDialog1.Filter = "CSV Files|*.csv; *.csv"
        If frmClipboardMonitor.OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim csvFileName As String = frmClipboardMonitor.OpenFileDialog1.FileName

            Dim csvFile As New TextFieldParser(csvFileName)
            Dim f As Integer

            csvFile.Delimiters = New String() {","}
            Dim currentRow As String()
            csvFile.TextFieldType = FieldType.Delimited
            csvFile.HasFieldsEnclosedInQuotes = False

            Dim cl As New clipItem
            Dim itmtext As New StringBuilder

            While csvFile.EndOfData = False
                Try
                    currentRow = csvFile.ReadFields()

                    cl.itemType = currentRow(0)
                    cl.itemDateTime = currentRow(1)
                    itmtext.Append(currentRow(2))

                    If currentRow.Length > 3 Then       '   multiple text - possible multiple commas.
                        For f = 3 To currentRow.Length - 1
                            itmtext.Append(currentRow(f))
                        Next
                    End If
                    cl.itemText = itmtext.ToString()
                Catch ex As Exception
                    '   probable a carriage return, ignore for now.
                End Try


                frmClipboardMonitor.addToList(cl.itemText, cl.itemDateTime, cl.itemType)
            End While
        End If
    End Sub

    Public Sub loadClipboardBIN()

        '   Loads friends from file and populate the list-view box.
        '   Loads file into a list and then transfers each item in the list to the list-view box.

        frmClipboardMonitor.LstbxClipboardData.Items.Clear()

        frmClipboardMonitor.OpenFileDialog1.FileName = ""
        frmClipboardMonitor.OpenFileDialog1.Filter = "BIN Files|*.bin; *.bin"

        If frmClipboardMonitor.OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim readFile As FileStream

            If My.Computer.FileSystem.FileExists(frmClipboardMonitor.OpenFileDialog1.FileName) Then
                readFile = File.OpenRead(frmClipboardMonitor.OpenFileDialog1.FileName)
                readFile.Seek(0, SeekOrigin.Begin)
            Else
                frmKlock.displayAction.DisplayReminder("Clipboard", "No Clipboard file found - will create if needed.", "G")
                Exit Sub
            End If

            Dim AL As New List(Of clipItem)
            Dim cl As New clipItem

            Dim Formatter As BinaryFormatter = New BinaryFormatter

            Try
                AL = Formatter.Deserialize(readFile)        '   loads file into the list.
            Catch ex As Exception
                frmKlock.displayAction.DisplayReminder("Clipboard Error", "Error loading Clipboard File. " & ex.Message, "G")
                Exit Sub
            End Try

            '   If got to here, have successfully read and decoded friends file.

            For Each cl In AL                            '   For each item in the list.
                frmClipboardMonitor.addToList(cl.itemText, cl.itemDateTime, cl.itemType)
            Next

            readFile.Close()
            Formatter = Nothing
        End If
    End Sub
End Module
