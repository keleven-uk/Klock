Public Class frmStickyNote
    '   Creates a basic sticky note.

    Dim drag As Boolean                     '   Global variables used to make the form drag-able.
    Dim mousex As Integer                   '
    Dim mousey As Integer                   '

    Dim longHeader As String
    Dim shorthHeader As String

    Private Sub frmStickyNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' On loading, set up some stuff.

        setBackColour(Color.Yellow)

        longHeader = Now.ToLongDateString & " : " & Now.ToLongTimeString
        shorthHeader = Now.ToShortDateString

        lblHeader.Text = longHeader
    End Sub

    Private Sub setBackColour(c As Color)
        '   Set the backcolour of all the controls to the same colour.

        BackColor = c

        RchTxtBxNote.BackColor = c

        CntxtMnStrpStickyNote.BackColor = c

        lblHeader.BackColor = c
        lblExit.BackColor = c
    End Sub

    '
    ' -------------------------------------------------------------------------------- procedures used to make form drag-able -----------------
    '
    Private Sub frmStickyNote_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, RchTxtBxNote.MouseDown

        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmStickyNote_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, RchTxtBxNote.MouseMove

        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmStickyNote_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, RchTxtBxNote.MouseUp

        drag = False
    End Sub

    Private Sub lblExit_Click(sender As Object, e As EventArgs) Handles lblExit.Click

        Close()
    End Sub
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

    Private Sub NoteTextColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteTextColourToolStripMenuItem.Click
        '   Set the sticky note text colour.

        clrDlgFormColour.Color = frmStickyNote.DefaultForeColor           '   current sticky note text colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            RchTxtBxNote.ForeColor = clrDlgFormColour.Color
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

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        '   Close the sticky note.

        Close()
    End Sub

    Private Sub frmStickyNote_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        '   If the sticky note is made smaller, then reduce the header to date only.

        Select Case Width
            Case > 160
                lblHeader.Text = longHeader
            Case Else
                lblHeader.Text = shorthHeader
        End Select
    End Sub

    Private Sub TmrStickyNote_Tick(sender As Object, e As EventArgs) Handles TmrStickyNote.Tick
        '   A timer is used to reduce the opacity of the stick note - to simulate a fade out.

        If Opacity < 0.3 Then
            TmrStickyNote.Enabled = False
        Else
            Opacity -= 0.05
        End If

    End Sub

    Private Sub frmStickyNote_MouseLeave(sender As Object, e As EventArgs) Handles RchTxtBxNote.MouseLeave, MyBase.MouseLeave
        '   Start fade out if the mouse leaves the stick note.

        TmrStickyNote.Enabled = True
    End Sub

    Private Sub frmStickyNote_MouseEnter(sender As Object, e As EventArgs) Handles RchTxtBxNote.MouseEnter, MyBase.MouseEnter
        '   Restore the sticky note if the mouse come back.

        TmrStickyNote.Enabled = False
        Opacity = 0.8
    End Sub
End Class