Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module IOcommon
    '   Friends, Events & Memo share similar routines to reas and save files.
    '   Moved the sub's into here, will try and reduce the redunandcy.

    Public Sub saveFriends()
        '   Save friends to file in data directory.
        '   Creates a list of all entries in the listview box and then writes this list to a binary file.

        Dim saveFile As FileStream = File.Create(getPath("Friend"))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Person)
        Dim p As Person

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each p In frmKlock.LstBxFriends.Items        '   Create list.
            AL.Add(p)
        Next

        Try
            Formatter.Serialize(saveFile, AL)   '   Write list to binary file.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Friends Error", "Error saving Friends File." & vbCrLf & ex.Message)
        End Try

        saveFile.Close()

        Formatter = Nothing
    End Sub

    Public Sub loadFriends()
        '   Loads friends from file and populate the listview box.
        '   Loads file into a list and then transfers each item in the list to the listview box.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(getPath("Friend")) Then
            readFile = File.OpenRead(getPath("Friend"))
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("Friends", "No Friends file found - will create if needed.")
            Exit Sub
        End If

        Dim AL As New List(Of Person)
        Dim p As Person

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Friends Error", "Error loading Friends File. " & ex.Message)
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        frmKlock.LstBxFriends.Items.Clear()
        frmKlock.knownCities.Clear()

        For Each p In AL                    '   For each item in the list.
            frmKlock.LstBxFriends.Items.Add(p)    '   Populate listview.
            frmKlock.FriendsAddToKnown(p)         '   Populate autocomplete collections.
        Next

        readFile.Close()
        Formatter = Nothing
    End Sub


    Public Sub saveEvents()
        '   Save Events to file in data directory.
        '   Creates a list of all entries in the listview box and then writes this list to a binary file.

        Dim saveFile As FileStream = File.Create(getPath("Event"))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Events)
        Dim e As Events

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each e In frmKlock.LstBxEvents.Items        '   Create list.
            AL.Add(e)
        Next

        Try
            Formatter.Serialize(saveFile, AL)   '   Write list to binary file.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Events Error", "Error saving Events File." & vbCrLf & ex.Message)
        End Try

        saveFile.Close()

        Formatter = Nothing
    End Sub

    Public Sub loadEvents()
        '   Loads Events from file and populate the listview box.
        '   Loads file into a list and then transfers each item in the list to the listview box.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(getPath("Event")) Then
            readFile = File.OpenRead(getPath("Event"))
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("Event", "No Event file found - will create if needed.")
            Exit Sub
        End If

        Dim AL As New List(Of Events)
        Dim e As Events

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Events Error", "Error Events Friends File. " & ex.Message)
            Exit Sub
        End Try

        '   If got to here, have successfully read and decoded friends file.
        frmKlock.LstBxEvents.Items.Clear()

        For Each e In AL                    '   For each item in the list.
            frmKlock.LstBxEvents.Items.Add(e)     '   Populate listview.
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
        '   Creates a list of all Memo in the listview box and then writes this list to a binary file.

        Dim saveFile As FileStream = File.Create(getPath("Memo"))

        saveFile.Seek(0, SeekOrigin.End)

        Dim AL As New List(Of Memo)
        Dim m As Memo

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        For Each m In frmKlock.LstBxMemo.Items        '   Create list.
            AL.Add(m)
        Next

        Try
            Formatter.Serialize(saveFile, AL)   '   Write list to binary file.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Memo Error", "Error saving Memo File." & vbCrLf & ex.Message)
        End Try

        saveFile.Close()

        Formatter = Nothing
    End Sub

    Public Sub loadMemo()
        '   Loads Memo from file and populate the listview box.
        '   Loads file into a list and then transfers each item in the list to the listview box.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(getPath("Memo")) Then
            readFile = File.OpenRead(getPath("Memo"))
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("Memo", "No Memo file found - will create if needed.")
            Exit Sub
        End If

        Dim AL As New List(Of Memo)
        Dim m As Memo

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            AL = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Memo Error", "Error Memo Friends File. " & ex.Message)
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

        getPath = System.IO.Path.Combine(dir, file)
    End Function

End Module
