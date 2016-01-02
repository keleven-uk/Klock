<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnalogueKlock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalogueKlock))
        Me.analogueKlock = New AnalogClock.Clock()
        Me.CntxtMnStrpAnalogueKlock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturnToKlockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntxtMnStrpAnalogueKlock.SuspendLayout()
        Me.SuspendLayout()
        '
        'analogueKlock
        '
        Me.analogueKlock.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.analogueKlock.BorderStyle = AnalogClock.BorderStyles.Round
        Me.analogueKlock.CenterPoint.RelativeRadius = 0.03!
        Me.analogueKlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.analogueKlock.HourHand.RelativeRadius = 0.65!
        Me.analogueKlock.HourHand.Width = 5.0!
        Me.analogueKlock.Location = New System.Drawing.Point(0, 0)
        Me.analogueKlock.MinuteHand.RelativeRadius = 0.8!
        Me.analogueKlock.MinuteHand.Width = 5.0!
        Me.analogueKlock.Name = "analogueKlock"
        Me.analogueKlock.SecondHand.RelativeRadius = 0.9!
        Me.analogueKlock.SecondHand.Width = 1.0!
        Me.analogueKlock.Size = New System.Drawing.Size(284, 270)
        Me.analogueKlock.TabIndex = 0
        '
        'CntxtMnStrpAnalogueKlock
        '
        Me.CntxtMnStrpAnalogueKlock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ReturnToKlockToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.CntxtMnStrpAnalogueKlock.Name = "CntxtMnStrpAnalogueKlock"
        Me.CntxtMnStrpAnalogueKlock.Size = New System.Drawing.Size(156, 70)
        Me.CntxtMnStrpAnalogueKlock.Text = "Analogue Klock"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ReturnToKlockToolStripMenuItem
        '
        Me.ReturnToKlockToolStripMenuItem.Name = "ReturnToKlockToolStripMenuItem"
        Me.ReturnToKlockToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ReturnToKlockToolStripMenuItem.Text = "Return to Klock"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CloseToolStripMenuItem.Text = "Close All"
        '
        'frmAnalogueKlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Desktop
        Me.ClientSize = New System.Drawing.Size(284, 270)
        Me.ContextMenuStrip = Me.CntxtMnStrpAnalogueKlock
        Me.Controls.Add(Me.analogueKlock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAnalogueKlock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Analogue Klock"
        Me.CntxtMnStrpAnalogueKlock.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents analogueKlock As AnalogClock.Clock
    Friend WithEvents CntxtMnStrpAnalogueKlock As ContextMenuStrip
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReturnToKlockToolStripMenuItem As ToolStripMenuItem
End Class
