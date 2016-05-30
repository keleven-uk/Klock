<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStickyNote
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.RchTxtBxNote = New System.Windows.Forms.RichTextBox()
        Me.CntxtMnStrpStickyNote = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NoteColourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoteTextColourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoteFontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.clrDlgFormColour = New System.Windows.Forms.ColorDialog()
        Me.FntDlgFormFont = New System.Windows.Forms.FontDialog()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.TmrStickyNote = New System.Windows.Forms.Timer(Me.components)
        Me.CntxtMnStrpStickyNote.SuspendLayout()
        Me.SuspendLayout()
        '
        'RchTxtBxNote
        '
        Me.RchTxtBxNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RchTxtBxNote.ContextMenuStrip = Me.CntxtMnStrpStickyNote
        Me.RchTxtBxNote.EnableAutoDragDrop = True
        Me.RchTxtBxNote.Location = New System.Drawing.Point(-1, 25)
        Me.RchTxtBxNote.Name = "RchTxtBxNote"
        Me.RchTxtBxNote.Size = New System.Drawing.Size(235, 209)
        Me.RchTxtBxNote.TabIndex = 3
        Me.RchTxtBxNote.Text = ""
        '
        'CntxtMnStrpStickyNote
        '
        Me.CntxtMnStrpStickyNote.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoteColourToolStripMenuItem, Me.NoteTextColourToolStripMenuItem, Me.NoteFontToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.CntxtMnStrpStickyNote.Name = "CntxtMnStrpStickyNote"
        Me.CntxtMnStrpStickyNote.Size = New System.Drawing.Size(164, 92)
        '
        'NoteColourToolStripMenuItem
        '
        Me.NoteColourToolStripMenuItem.Name = "NoteColourToolStripMenuItem"
        Me.NoteColourToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.NoteColourToolStripMenuItem.Text = "Note Colour"
        '
        'NoteTextColourToolStripMenuItem
        '
        Me.NoteTextColourToolStripMenuItem.Name = "NoteTextColourToolStripMenuItem"
        Me.NoteTextColourToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.NoteTextColourToolStripMenuItem.Text = "Note Text Colour"
        '
        'NoteFontToolStripMenuItem
        '
        Me.NoteFontToolStripMenuItem.Name = "NoteFontToolStripMenuItem"
        Me.NoteFontToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.NoteFontToolStripMenuItem.Text = "Note Font"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CloseToolStripMenuItem.Text = "Note Close"
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Location = New System.Drawing.Point(-1, 6)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(39, 13)
        Me.lblHeader.TabIndex = 4
        Me.lblHeader.Text = "Label1"
        '
        'lblExit
        '
        Me.lblExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExit.AutoSize = True
        Me.lblExit.Location = New System.Drawing.Point(205, 6)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(14, 13)
        Me.lblExit.TabIndex = 5
        Me.lblExit.Text = "X"
        '
        'TmrStickyNote
        '
        '
        'frmStickyNote
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.RchTxtBxNote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(110, 100)
        Me.Name = "frmStickyNote"
        Me.Opacity = 0.8R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.CntxtMnStrpStickyNote.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RchTxtBxNote As RichTextBox
    Friend WithEvents lblHeader As Label
    Friend WithEvents clrDlgFormColour As ColorDialog
    Friend WithEvents FntDlgFormFont As FontDialog
    Friend WithEvents lblExit As Label
    Friend WithEvents CntxtMnStrpStickyNote As ContextMenuStrip
    Friend WithEvents NoteColourToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NoteFontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NoteTextColourToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TmrStickyNote As Windows.Forms.Timer
End Class
