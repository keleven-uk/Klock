
'   A sticky notes class.
'   A class to handle a number of stick notes

'   Needs to be called with a file location for the sticky note store.
'   If not present, will create.

Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class stickyNotes

    Dim StickyNotesStore As New Dictionary(Of Integer, stickyNote)      '   set up sticky note store.
    Dim StickyNotesFile As String = ""



    Public Sub New(f As String)
        MyBase.New()

        StickyNotesFile = f                                             '   File location of sticky note store.
    End Sub

    Public Sub Add(sn As stickyNote)
        '   Add a new sticky note to the store.
        '   If the sticky note is already in the store, amend the stored one.

        If StickyNotesStore.ContainsKey(sn.noteID) Then
            StickyNotesStore(sn.noteID).noteBody = sn.noteBody
            StickyNotesStore(sn.noteID).noteHeight = sn.noteHeight
            StickyNotesStore(sn.noteID).noteWidth = sn.noteWidth
            StickyNotesStore(sn.noteID).noteTop = sn.noteTop
            StickyNotesStore(sn.noteID).noteLeft = sn.noteLeft
        Else
            Try
                StickyNotesStore.Add(sn.noteID, sn)
            Catch ex As Exception
                If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("stickyNotes.Add", ex)
            End Try
        End If

        Save()
    End Sub

    Public Sub Delete(sn As stickyNote)
        '   Delete a sticky note from the store and then save the store.
        '   DOES NOT ASK.

        Try
            StickyNotesStore.Remove(sn.noteID)
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("stickyNotes.Delete", ex)
        End Try

        Save()
    End Sub

    Public Sub Save()
        '   Save the store to a location specified when the store was created.

        Dim saveFile As FileStream = File.Create(StickyNotesFile)

        saveFile.Seek(0, SeekOrigin.End)

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            Formatter.Serialize(saveFile, StickyNotesStore)           '   Write sticky note store to binary file.
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("stickyNotes.save", ex)
            frmKlock.displayAction.DisplayReminder("Error saving Sticky Notes File." & vbCrLf & ex.Message, "G", "Sticky Error")
        End Try

        saveFile.Close()
        Formatter = Nothing
    End Sub

    Public Sub Load()
        '   Load the store to a location specified when the store was created.
        '   Then creates a new sticky note on screen for each item in the store.

        Dim readFile As FileStream

        If My.Computer.FileSystem.FileExists(StickyNotesFile) Then
            readFile = File.OpenRead(StickyNotesFile)
            readFile.Seek(0, SeekOrigin.Begin)
        Else
            frmKlock.displayAction.DisplayReminder("No Sticky Note File found - will create if needed.", "G", "Sticky Error")
            Exit Sub
        End If

        Dim Formatter As BinaryFormatter = New BinaryFormatter

        Try
            StickyNotesStore = Formatter.Deserialize(readFile)        '   loads file into the list.
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("stickyNotes.load", ex)
            frmKlock.displayAction.DisplayReminder("Error loading Sticky Notes File. " & ex.Message, "G", "Sticky Error")
            Exit Sub
        End Try


        readFile.Close()
        Formatter = Nothing

        '   If got To here, have successfully read And decoded Sticky Notes file.

        For Each item As KeyValuePair(Of Integer, stickyNote) In StickyNotesStore

            '   Create a new sticky note.

            Dim note As New frmStickyNote(item.Value)

            note.Show()
        Next

    End Sub

    Public Function isEmpty() As Boolean
        '   Will return true if the file contains data.
        '   Will return false if file is zero length or does not exist.

        If My.Computer.FileSystem.FileExists(StickyNotesFile) Then
            Dim myFile As New FileInfo(StickyNotesFile)

            Return If(myFile.Length > 0, False, True)
        Else
            Return True
        End If
    End Function
End Class
