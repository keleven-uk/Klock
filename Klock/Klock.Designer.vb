<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKlock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKlock))
        Me.StsStrpInfo = New System.Windows.Forms.StatusStrip()
        Me.stsLblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblKeys = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.MnStrpMain = New System.Windows.Forms.MenuStrip()
        Me.MnItmFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmSubHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmLicense = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.StsStrpInfo.SuspendLayout()
        Me.MnStrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'StsStrpInfo
        '
        Me.StsStrpInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLblTime, Me.StsLblDate, Me.StsLblKeys})
        Me.StsStrpInfo.Location = New System.Drawing.Point(0, 238)
        Me.StsStrpInfo.Name = "StsStrpInfo"
        Me.StsStrpInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StsStrpInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StsStrpInfo.Size = New System.Drawing.Size(284, 24)
        Me.StsStrpInfo.TabIndex = 0
        '
        'stsLblTime
        '
        Me.stsLblTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.stsLblTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.stsLblTime.Name = "stsLblTime"
        Me.stsLblTime.Size = New System.Drawing.Size(53, 19)
        Me.stsLblTime.Text = "00:00:00"
        '
        'StsLblDate
        '
        Me.StsLblDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StsLblDate.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.StsLblDate.Name = "StsLblDate"
        Me.StsLblDate.Size = New System.Drawing.Size(75, 19)
        Me.StsLblDate.Text = "18 Nov 2012"
        '
        'StsLblKeys
        '
        Me.StsLblKeys.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StsLblKeys.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.StsLblKeys.Name = "StsLblKeys"
        Me.StsLblKeys.Size = New System.Drawing.Size(29, 19)
        Me.StsLblKeys.Text = "cns"
        '
        'TmrMain
        '
        Me.TmrMain.Enabled = True
        '
        'MnStrpMain
        '
        Me.MnStrpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnItmFile, Me.MnItmHelp})
        Me.MnStrpMain.Location = New System.Drawing.Point(0, 0)
        Me.MnStrpMain.Name = "MnStrpMain"
        Me.MnStrpMain.Size = New System.Drawing.Size(284, 24)
        Me.MnStrpMain.TabIndex = 1
        Me.MnStrpMain.Text = "MenuStrip1"
        '
        'MnItmFile
        '
        Me.MnItmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnItmExit, Me.MnItmOptions})
        Me.MnItmFile.Name = "MnItmFile"
        Me.MnItmFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.MnItmFile.Size = New System.Drawing.Size(37, 20)
        Me.MnItmFile.Text = "File"
        '
        'MnItmExit
        '
        Me.MnItmExit.Name = "MnItmExit"
        Me.MnItmExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MnItmExit.Size = New System.Drawing.Size(155, 22)
        Me.MnItmExit.Text = "E&xit"
        '
        'MnItmOptions
        '
        Me.MnItmOptions.Name = "MnItmOptions"
        Me.MnItmOptions.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnItmOptions.Size = New System.Drawing.Size(155, 22)
        Me.MnItmOptions.Text = "&Options"
        '
        'MnItmHelp
        '
        Me.MnItmHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnItmSubHelp, Me.MnItmLicense, Me.MnItmAbout})
        Me.MnItmHelp.Name = "MnItmHelp"
        Me.MnItmHelp.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.MnItmHelp.Size = New System.Drawing.Size(44, 20)
        Me.MnItmHelp.Text = "&Help"
        '
        'MnItmSubHelp
        '
        Me.MnItmSubHelp.Name = "MnItmSubHelp"
        Me.MnItmSubHelp.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnItmSubHelp.Size = New System.Drawing.Size(149, 22)
        Me.MnItmSubHelp.Text = "Hel&p"
        '
        'MnItmLicense
        '
        Me.MnItmLicense.Name = "MnItmLicense"
        Me.MnItmLicense.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.MnItmLicense.Size = New System.Drawing.Size(149, 22)
        Me.MnItmLicense.Text = "&License"
        '
        'MnItmAbout
        '
        Me.MnItmAbout.Name = "MnItmAbout"
        Me.MnItmAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MnItmAbout.Size = New System.Drawing.Size(149, 22)
        Me.MnItmAbout.Text = "&About"
        '
        'frmStub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.StsStrpInfo)
        Me.Controls.Add(Me.MnStrpMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MnStrpMain
        Me.Name = "frmStub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klock"
        Me.StsStrpInfo.ResumeLayout(False)
        Me.StsStrpInfo.PerformLayout()
        Me.MnStrpMain.ResumeLayout(False)
        Me.MnStrpMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StsStrpInfo As System.Windows.Forms.StatusStrip
    Friend WithEvents stsLblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StsLblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TmrMain As System.Windows.Forms.Timer
    Friend WithEvents StsLblKeys As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MnStrpMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnItmFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnItmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnItmHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnItmSubHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnItmAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnItmLicense As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnItmOptions As System.Windows.Forms.ToolStripMenuItem

End Class
