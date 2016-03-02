<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClipboardMonitor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClipboardMonitor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LstbxClipboardData = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClearClipboard = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.StsStrpInfo = New System.Windows.Forms.StatusStrip()
        Me.stsLblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StsLblKeys = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsLbIdkeTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TlStrpPrgrsBrMemo = New System.Windows.Forms.ToolStripProgressBar()
        Me.tmrClipboardMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StsStrpInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.LstbxClipboardData)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(626, 208)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LstbxClipboardData
        '
        Me.LstbxClipboardData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstbxClipboardData.FormattingEnabled = True
        Me.LstbxClipboardData.Location = New System.Drawing.Point(6, 19)
        Me.LstbxClipboardData.Name = "LstbxClipboardData"
        Me.LstbxClipboardData.Size = New System.Drawing.Size(614, 173)
        Me.LstbxClipboardData.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.Controls.Add(Me.btnLoad)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.btnClearClipboard)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.btnCopy)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(634, 83)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(387, 27)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 37)
        Me.btnLoad.TabIndex = 5
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(306, 27)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 37)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClearClipboard
        '
        Me.btnClearClipboard.Location = New System.Drawing.Point(193, 27)
        Me.btnClearClipboard.Name = "btnClearClipboard"
        Me.btnClearClipboard.Size = New System.Drawing.Size(75, 37)
        Me.btnClearClipboard.TabIndex = 3
        Me.btnClearClipboard.Text = "Clear Clipboard"
        Me.btnClearClipboard.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(553, 27)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 37)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(112, 27)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 37)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear Monitor"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Enabled = False
        Me.btnCopy.Location = New System.Drawing.Point(6, 27)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 37)
        Me.btnCopy.TabIndex = 0
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'StsStrpInfo
        '
        Me.StsStrpInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLblTime, Me.StsLblDate, Me.StsLblKeys, Me.stsLbIdkeTime, Me.TlStrpPrgrsBrMemo})
        Me.StsStrpInfo.Location = New System.Drawing.Point(0, 312)
        Me.StsStrpInfo.Name = "StsStrpInfo"
        Me.StsStrpInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StsStrpInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StsStrpInfo.Size = New System.Drawing.Size(645, 24)
        Me.StsStrpInfo.SizingGrip = False
        Me.StsStrpInfo.TabIndex = 2
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
        Me.StsLblKeys.Size = New System.Drawing.Size(47, 19)
        Me.StsLblKeys.Text = "cns off"
        '
        'stsLbIdkeTime
        '
        Me.stsLbIdkeTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.stsLbIdkeTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.stsLbIdkeTime.Name = "stsLbIdkeTime"
        Me.stsLbIdkeTime.Size = New System.Drawing.Size(53, 19)
        Me.stsLbIdkeTime.Text = "00:00:00"
        '
        'TlStrpPrgrsBrMemo
        '
        Me.TlStrpPrgrsBrMemo.Name = "TlStrpPrgrsBrMemo"
        Me.TlStrpPrgrsBrMemo.Size = New System.Drawing.Size(100, 18)
        Me.TlStrpPrgrsBrMemo.Visible = False
        '
        'tmrClipboardMonitor
        '
        Me.tmrClipboardMonitor.Enabled = True
        Me.tmrClipboardMonitor.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmClipboardMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(645, 336)
        Me.Controls.Add(Me.StsStrpInfo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClipboardMonitor"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Clipboard Monitor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.StsStrpInfo.ResumeLayout(False)
        Me.StsStrpInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnClearClipboard As Button
    Friend WithEvents StsStrpInfo As StatusStrip
    Friend WithEvents stsLblTime As ToolStripStatusLabel
    Friend WithEvents StsLblDate As ToolStripStatusLabel
    Friend WithEvents StsLblKeys As ToolStripStatusLabel
    Friend WithEvents stsLbIdkeTime As ToolStripStatusLabel
    Friend WithEvents TlStrpPrgrsBrMemo As ToolStripProgressBar
    Friend WithEvents tmrClipboardMonitor As Windows.Forms.Timer
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents LstbxClipboardData As ListBox
End Class
