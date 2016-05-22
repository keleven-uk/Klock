<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBinaryKlock
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
        Me.StsStrpInfo = New System.Windows.Forms.StatusStrip()
        Me.stsLblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblKeys = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsLbIdkeTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PctrBxBinaryKlock = New System.Windows.Forms.PictureBox()
        Me.tmrBinaryKlock = New System.Windows.Forms.Timer(Me.components)
        Me.toTpBinaryKlock = New System.Windows.Forms.ToolTip(Me.components)
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReturnToKlockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewStickyNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CntxtMnStrpBinaryKlock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StsStrpInfo.SuspendLayout()
        CType(Me.PctrBxBinaryKlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CntxtMnStrpBinaryKlock.SuspendLayout()
        Me.SuspendLayout()
        '
        'StsStrpInfo
        '
        Me.StsStrpInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLblTime, Me.StsLblDate, Me.StsLblKeys, Me.stsLbIdkeTime})
        Me.StsStrpInfo.Location = New System.Drawing.Point(0, 202)
        Me.StsStrpInfo.Name = "StsStrpInfo"
        Me.StsStrpInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StsStrpInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StsStrpInfo.Size = New System.Drawing.Size(309, 22)
        Me.StsStrpInfo.SizingGrip = False
        Me.StsStrpInfo.TabIndex = 53
        '
        'stsLblTime
        '
        Me.stsLblTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.stsLblTime.Name = "stsLblTime"
        Me.stsLblTime.Size = New System.Drawing.Size(49, 17)
        Me.stsLblTime.Text = "00:00:00"
        '
        'StsLblDate
        '
        Me.StsLblDate.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.StsLblDate.Name = "StsLblDate"
        Me.StsLblDate.Size = New System.Drawing.Size(59, 17)
        Me.StsLblDate.Text = "14/1/2015"
        '
        'StsLblKeys
        '
        Me.StsLblKeys.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.StsLblKeys.Name = "StsLblKeys"
        Me.StsLblKeys.Size = New System.Drawing.Size(43, 17)
        Me.StsLblKeys.Text = "cns off"
        '
        'stsLbIdkeTime
        '
        Me.stsLbIdkeTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.stsLbIdkeTime.Name = "stsLbIdkeTime"
        Me.stsLbIdkeTime.Size = New System.Drawing.Size(110, 17)
        Me.stsLbIdkeTime.Text = "Idle Time :: 00:00:00"
        '
        'PctrBxBinaryKlock
        '
        Me.PctrBxBinaryKlock.ContextMenuStrip = Me.CntxtMnStrpBinaryKlock
        Me.PctrBxBinaryKlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PctrBxBinaryKlock.Location = New System.Drawing.Point(0, 0)
        Me.PctrBxBinaryKlock.Name = "PctrBxBinaryKlock"
        Me.PctrBxBinaryKlock.Size = New System.Drawing.Size(309, 202)
        Me.PctrBxBinaryKlock.TabIndex = 54
        Me.PctrBxBinaryKlock.TabStop = False
        '
        'tmrBinaryKlock
        '
        Me.tmrBinaryKlock.Interval = 1000
        '
        'toTpBinaryKlock
        '
        Me.toTpBinaryKlock.AutoPopDelay = 5000
        Me.toTpBinaryKlock.InitialDelay = 0
        Me.toTpBinaryKlock.IsBalloon = True
        Me.toTpBinaryKlock.ReshowDelay = 100
        Me.toTpBinaryKlock.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.toTpBinaryKlock.ToolTipTitle = "Klock"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ReturnToKlockToolStripMenuItem
        '
        Me.ReturnToKlockToolStripMenuItem.Name = "ReturnToKlockToolStripMenuItem"
        Me.ReturnToKlockToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ReturnToKlockToolStripMenuItem.Text = "Return to Klock"
        '
        'NewStickyNoteToolStripMenuItem
        '
        Me.NewStickyNoteToolStripMenuItem.Name = "NewStickyNoteToolStripMenuItem"
        Me.NewStickyNoteToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.NewStickyNoteToolStripMenuItem.Text = "New Sticky Note"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CloseToolStripMenuItem.Text = "Close All"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(158, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'CntxtMnStrpBinaryKlock
        '
        Me.CntxtMnStrpBinaryKlock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ReturnToKlockToolStripMenuItem, Me.NewStickyNoteToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ToolStripSeparator1, Me.HelpToolStripMenuItem, Me.ToolStripSeparator2, Me.AboutToolStripMenuItem})
        Me.CntxtMnStrpBinaryKlock.Name = "CntxtMnStrpAnalogueKlock"
        Me.CntxtMnStrpBinaryKlock.Size = New System.Drawing.Size(162, 148)
        Me.CntxtMnStrpBinaryKlock.Text = "Analogue Klock"
        '
        'frmBinaryKlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 224)
        Me.ContextMenuStrip = Me.CntxtMnStrpBinaryKlock
        Me.Controls.Add(Me.PctrBxBinaryKlock)
        Me.Controls.Add(Me.StsStrpInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBinaryKlock"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Binary Klock "
        Me.StsStrpInfo.ResumeLayout(False)
        Me.StsStrpInfo.PerformLayout()
        CType(Me.PctrBxBinaryKlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CntxtMnStrpBinaryKlock.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StsStrpInfo As StatusStrip
    Friend WithEvents stsLblTime As ToolStripStatusLabel
    Friend WithEvents StsLblDate As ToolStripStatusLabel
    Friend WithEvents StsLblKeys As ToolStripStatusLabel
    Friend WithEvents stsLbIdkeTime As ToolStripStatusLabel
    Friend WithEvents PctrBxBinaryKlock As PictureBox
    Friend WithEvents tmrBinaryKlock As Windows.Forms.Timer
    Friend WithEvents toTpBinaryKlock As ToolTip
    Friend WithEvents CntxtMnStrpBinaryKlock As ContextMenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReturnToKlockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewStickyNoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
