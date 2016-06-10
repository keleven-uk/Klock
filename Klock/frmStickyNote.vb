Public Class frmStickyNote

    Public myStickyNote As stickyNote
    '   Creates a basic sticky note.

    Dim drag As Boolean                                                             '   Global variables used to make the form drag-able.

    Dim FadeStep As Double = frmKlock.usrSettings.usrStickyNoteStpOpacity / 100     '   Global variables for form fade out.
    Dim MaxOpacity As Double = frmKlock.usrSettings.usrStickyNoteMaxOpacity / 100
    Dim MinOpacity As Double = frmKlock.usrSettings.usrStickyNoteMinOpacity / 100
    Dim mousex As Integer
    Dim mousey As Integer
    '

    Public Sub New(sn As stickyNote)
        '   New form constructor.
        '   If called with a stick note, then re-create that sticky note.
        '   If called with nothing, then create new blank sticky note.

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        myStickyNote = New stickyNote

        If sn IsNot Nothing Then                        '   we have a sticky note, re-create it.
            myStickyNote.noteID = sn.noteID
            myStickyNote.noteheader = sn.noteheader
            myStickyNote.noteBody = sn.noteBody
            myStickyNote.noteHeight = sn.noteHeight
            myStickyNote.noteWidth = sn.noteWidth
            myStickyNote.noteTop = sn.noteTop
            myStickyNote.noteLeft = sn.noteLeft
            If frmKlock.usrSettings.usrStickyNoteAllowFadeOut Then TmrStickyNote.Enabled = True
            frmKlock.myStickyNotes.Add(myStickyNote)
        Else                                            '   New blank sticky note.
            myStickyNote.noteID = Handle
            myStickyNote.noteheader = Now.ToLongDateString & " : " & Now.ToLongTimeString
            setStickyNote()
        End If

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        '   Close the sticky note.

        Close()
    End Sub

    Private Sub frmStickyNote_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   The sticky note has been closed by user, remove from store.

        frmKlock.myStickyNotes.Delete(myStickyNote)
    End Sub

    Private Sub frmStickyNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   On loading, set up some stuff.

        setBackColour(frmKlock.usrSettings.usrStickyNoteBackColour)
        setForeColour(frmKlock.usrSettings.usrStickyNoteForeColour)

        Font = frmKlock.usrSettings.usrStickyNoteFont

        Opacity = MaxOpacity

        setForm()
    End Sub
    '
    ' -------------------------------------------------------------------------------- procedures used to make form drag-able -----------------
    '
    Private Sub frmStickyNote_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, RchTxtBxNote.MouseDown, lblHeader.MouseDown

        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmStickyNote_MouseEnter(sender As Object, e As EventArgs) Handles RchTxtBxNote.MouseEnter, MyBase.MouseEnter, lblHeader.MouseEnter
        '   Restore the sticky note if the mouse come back.

        TmrStickyNote.Enabled = False
        Opacity = MaxOpacity
    End Sub

    Private Sub frmStickyNote_MouseLeave(sender As Object, e As EventArgs) Handles RchTxtBxNote.MouseLeave, MyBase.MouseLeave, lblHeader.MouseLeave
        '   Start fade out if the mouse leaves the stick note.

        '   When starts fading, save sticky note.
        setStickyNote()

        If frmKlock.usrSettings.usrStickyNoteAllowFadeOut Then TmrStickyNote.Enabled = True
    End Sub

    Private Sub frmStickyNote_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, RchTxtBxNote.MouseMove, lblHeader.MouseMove

        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmStickyNote_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, RchTxtBxNote.MouseUp, lblHeader.MouseUp

        drag = False
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click

        Close()
    End Sub
    '
    ' -------------------------------------------------------------------------------- procedures used for drag and drop -----------------
    '
    '   It looks like these are not needed, if EnableAutoDragDrop is set to true.
    '   This allows text to be dragged on the form and if a file is dragged a icon representing that file is dropped.
    '   Fortunately, this is the functionality i require :-)
    '
    ' -------------------------------------------------------------------------------- procedures used for colour changing -----------------
    '
    Private Sub NoteColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteColourToolStripMenuItem.Click
        '   Set the sticky note colour.

        clrDlgFormColour.Color = frmStickyNote.DefaultBackColor           '   current sticky note colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            setBackColour(clrDlgFormColour.Color)
        End If
    End Sub

    Private Sub NoteFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteFontToolStripMenuItem.Click
        '   Set the sticky note font.
        '   A try catch is sued, because the font control can not handle true type fonts
        '   and their is no easy was to exclude them.


        FntDlgFormFont.Font = frmStickyNote.DefaultFont
        Try
            If FntDlgFormFont.ShowDialog() = DialogResult.OK Then
                RchTxtBxNote.Font = FntDlgFormFont.Font
            End If
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("frmStickyNotes.btnFont_Click", ex)
            frmKlock.displayAction.DisplayReminder(ex.Message, "G", "ERROR :: frmStickyNotes.btnFont_Click")
        End Try
    End Sub

    Private Sub NoteTextColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteTextColourToolStripMenuItem.Click
        '   Set the sticky note text colour.

        clrDlgFormColour.Color = frmStickyNote.DefaultForeColor           '   current sticky note text colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            setForeColour(clrDlgFormColour.Color)
        End If
    End Sub

    Private Sub setBackColour(c As Color)
        '   Set the backcolour of all the controls to the same colour.

        BackColor = c

        RchTxtBxNote.BackColor = c

        CntxtMnStrpStickyNote.BackColor = c

        lblHeader.BackColor = c
        lblExit.BackColor = c
    End Sub

    Private Sub setForeColour(c As Color)
        '   Set the forecolour of all the controls to the same colour.

        ForeColor = c

        RchTxtBxNote.ForeColor = c

        CntxtMnStrpStickyNote.ForeColor = c

        lblHeader.ForeColor = c
        lblExit.ForeColor = c
    End Sub

    Private Sub setForm()
        '   Set the sticky note to a re-existing stick note.

        RchTxtBxNote.Rtf = myStickyNote.noteBody
        lblHeader.Text = myStickyNote.noteheader
        Height = myStickyNote.noteHeight
        Width = myStickyNote.noteWidth
        Top = myStickyNote.noteTop
        Left = myStickyNote.noteLeft
    End Sub

    Private Sub setStickyNote()
        '   Set current sticky note to reflect form.

        myStickyNote.noteBody = RchTxtBxNote.Rtf
        myStickyNote.noteHeight = Height
        myStickyNote.noteWidth = Width
        myStickyNote.noteTop = Top
        myStickyNote.noteLeft = Left

        frmKlock.myStickyNotes.Add(myStickyNote)
    End Sub

    Private Sub TmrStickyNote_Tick(sender As Object, e As EventArgs) Handles TmrStickyNote.Tick
        '   A timer is used to reduce the opacity of the stick note - to simulate a fade out.

        If Opacity < MinOpacity Then
            TmrStickyNote.Enabled = False

            '   When stops fading, re-save sticky note just in case
            setStickyNote()
        Else
            Opacity -= FadeStep
        End If
    End Sub

End Class