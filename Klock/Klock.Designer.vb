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
        Me.TbCntrl = New System.Windows.Forms.TabControl()
        Me.TbPgTime = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblTimeTime = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbBxTime = New System.Windows.Forms.ComboBox()
        Me.TbPgCountDown = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TxtBxCountDowndCommand = New System.Windows.Forms.TextBox()
        Me.btnCountDownLoadCommand = New System.Windows.Forms.Button()
        Me.ChckBxCountDownCommand = New System.Windows.Forms.CheckBox()
        Me.CmbBxCountDownSystem = New System.Windows.Forms.ComboBox()
        Me.ChckBxCountDownSystem = New System.Windows.Forms.CheckBox()
        Me.TxtBxCountDownReminder = New System.Windows.Forms.TextBox()
        Me.ChckBxCountDownReminder = New System.Windows.Forms.CheckBox()
        Me.btnCountdownLoadSound = New System.Windows.Forms.Button()
        Me.btnCountDownTestSound = New System.Windows.Forms.Button()
        Me.TxtBxAction = New System.Windows.Forms.TextBox()
        Me.ChckBxCountDownSound = New System.Windows.Forms.CheckBox()
        Me.CmbBxCountDownAction = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.upDwnCntDownValue = New System.Windows.Forms.NumericUpDown()
        Me.lblCountDownTime = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCountDownStop = New System.Windows.Forms.Button()
        Me.btnCountDownStart = New System.Windows.Forms.Button()
        Me.TbPgTimer = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnTimerSplitClear = New System.Windows.Forms.Button()
        Me.lblTimerSplit = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblTimerTime = New System.Windows.Forms.Label()
        Me.btnTimerSplit = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnTimerClear = New System.Windows.Forms.Button()
        Me.btnTimerStop = New System.Windows.Forms.Button()
        Me.btnTimerStart = New System.Windows.Forms.Button()
        Me.btnHide = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StsStrpInfo.SuspendLayout()
        Me.MnStrpMain.SuspendLayout()
        Me.TbCntrl.SuspendLayout()
        Me.TbPgTime.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TbPgCountDown.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.upDwnCntDownValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TbPgTimer.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'StsStrpInfo
        '
        Me.StsStrpInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLblTime, Me.StsLblDate, Me.StsLblKeys})
        Me.StsStrpInfo.Location = New System.Drawing.Point(0, 255)
        Me.StsStrpInfo.Name = "StsStrpInfo"
        Me.StsStrpInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StsStrpInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StsStrpInfo.Size = New System.Drawing.Size(593, 24)
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
        Me.MnStrpMain.Size = New System.Drawing.Size(593, 24)
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
        'TbCntrl
        '
        Me.TbCntrl.Controls.Add(Me.TbPgTime)
        Me.TbCntrl.Controls.Add(Me.TbPgCountDown)
        Me.TbCntrl.Controls.Add(Me.TbPgTimer)
        Me.TbCntrl.Location = New System.Drawing.Point(12, 27)
        Me.TbCntrl.Name = "TbCntrl"
        Me.TbCntrl.SelectedIndex = 0
        Me.TbCntrl.Size = New System.Drawing.Size(573, 160)
        Me.TbCntrl.TabIndex = 2
        '
        'TbPgTime
        '
        Me.TbPgTime.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTime.Controls.Add(Me.GroupBox2)
        Me.TbPgTime.Controls.Add(Me.GroupBox1)
        Me.TbPgTime.Location = New System.Drawing.Point(4, 22)
        Me.TbPgTime.Name = "TbPgTime"
        Me.TbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgTime.Size = New System.Drawing.Size(565, 134)
        Me.TbPgTime.TabIndex = 0
        Me.TbPgTime.Text = "Fuzzy Time"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblTimeTime)
        Me.GroupBox2.Location = New System.Drawing.Point(115, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'LblTimeTime
        '
        Me.LblTimeTime.AutoSize = True
        Me.LblTimeTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTimeTime.Location = New System.Drawing.Point(6, 19)
        Me.LblTimeTime.Name = "LblTimeTime"
        Me.LblTimeTime.Size = New System.Drawing.Size(359, 24)
        Me.LblTimeTime.TabIndex = 0
        Me.LblTimeTime.Text = "twelve minutes past eleven in the evening"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbBxTime)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 57)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CmbBxTime
        '
        Me.CmbBxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxTime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbBxTime.FormattingEnabled = True
        Me.CmbBxTime.Location = New System.Drawing.Point(6, 19)
        Me.CmbBxTime.Name = "CmbBxTime"
        Me.CmbBxTime.Size = New System.Drawing.Size(86, 21)
        Me.CmbBxTime.TabIndex = 0
        '
        'TbPgCountDown
        '
        Me.TbPgCountDown.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgCountDown.Controls.Add(Me.GroupBox5)
        Me.TbPgCountDown.Controls.Add(Me.GroupBox4)
        Me.TbPgCountDown.Controls.Add(Me.GroupBox3)
        Me.TbPgCountDown.Location = New System.Drawing.Point(4, 22)
        Me.TbPgCountDown.Name = "TbPgCountDown"
        Me.TbPgCountDown.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgCountDown.Size = New System.Drawing.Size(565, 134)
        Me.TbPgCountDown.TabIndex = 1
        Me.TbPgCountDown.Text = "CountDown"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxtBxCountDowndCommand)
        Me.GroupBox5.Controls.Add(Me.btnCountDownLoadCommand)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownCommand)
        Me.GroupBox5.Controls.Add(Me.CmbBxCountDownSystem)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownSystem)
        Me.GroupBox5.Controls.Add(Me.TxtBxCountDownReminder)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownReminder)
        Me.GroupBox5.Controls.Add(Me.btnCountdownLoadSound)
        Me.GroupBox5.Controls.Add(Me.btnCountDownTestSound)
        Me.GroupBox5.Controls.Add(Me.TxtBxAction)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownSound)
        Me.GroupBox5.Controls.Add(Me.CmbBxCountDownAction)
        Me.GroupBox5.Location = New System.Drawing.Point(115, 69)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'TxtBxCountDowndCommand
        '
        Me.TxtBxCountDowndCommand.Enabled = False
        Me.TxtBxCountDowndCommand.Location = New System.Drawing.Point(190, 24)
        Me.TxtBxCountDowndCommand.Name = "TxtBxCountDowndCommand"
        Me.TxtBxCountDowndCommand.Size = New System.Drawing.Size(183, 20)
        Me.TxtBxCountDowndCommand.TabIndex = 11
        '
        'btnCountDownLoadCommand
        '
        Me.btnCountDownLoadCommand.Enabled = False
        Me.btnCountDownLoadCommand.Location = New System.Drawing.Point(379, 24)
        Me.btnCountDownLoadCommand.Name = "btnCountDownLoadCommand"
        Me.btnCountDownLoadCommand.Size = New System.Drawing.Size(50, 20)
        Me.btnCountDownLoadCommand.TabIndex = 10
        Me.btnCountDownLoadCommand.Text = "..."
        Me.btnCountDownLoadCommand.UseVisualStyleBackColor = True
        '
        'ChckBxCountDownCommand
        '
        Me.ChckBxCountDownCommand.AutoSize = True
        Me.ChckBxCountDownCommand.Location = New System.Drawing.Point(111, 23)
        Me.ChckBxCountDownCommand.Name = "ChckBxCountDownCommand"
        Me.ChckBxCountDownCommand.Size = New System.Drawing.Size(73, 17)
        Me.ChckBxCountDownCommand.TabIndex = 9
        Me.ChckBxCountDownCommand.Text = "Command"
        Me.ChckBxCountDownCommand.UseVisualStyleBackColor = True
        '
        'CmbBxCountDownSystem
        '
        Me.CmbBxCountDownSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCountDownSystem.Enabled = False
        Me.CmbBxCountDownSystem.FormattingEnabled = True
        Me.CmbBxCountDownSystem.Location = New System.Drawing.Point(174, 23)
        Me.CmbBxCountDownSystem.Name = "CmbBxCountDownSystem"
        Me.CmbBxCountDownSystem.Size = New System.Drawing.Size(100, 21)
        Me.CmbBxCountDownSystem.TabIndex = 8
        '
        'ChckBxCountDownSystem
        '
        Me.ChckBxCountDownSystem.AutoSize = True
        Me.ChckBxCountDownSystem.Location = New System.Drawing.Point(111, 23)
        Me.ChckBxCountDownSystem.Name = "ChckBxCountDownSystem"
        Me.ChckBxCountDownSystem.Size = New System.Drawing.Size(60, 17)
        Me.ChckBxCountDownSystem.TabIndex = 7
        Me.ChckBxCountDownSystem.Text = "System"
        Me.ChckBxCountDownSystem.UseVisualStyleBackColor = True
        '
        'TxtBxCountDownReminder
        '
        Me.TxtBxCountDownReminder.Enabled = False
        Me.TxtBxCountDownReminder.Location = New System.Drawing.Point(188, 24)
        Me.TxtBxCountDownReminder.Name = "TxtBxCountDownReminder"
        Me.TxtBxCountDownReminder.Size = New System.Drawing.Size(241, 20)
        Me.TxtBxCountDownReminder.TabIndex = 6
        Me.TxtBxCountDownReminder.Text = "Finished counting, now Sir!"
        '
        'ChckBxCountDownReminder
        '
        Me.ChckBxCountDownReminder.AutoSize = True
        Me.ChckBxCountDownReminder.Location = New System.Drawing.Point(111, 23)
        Me.ChckBxCountDownReminder.Name = "ChckBxCountDownReminder"
        Me.ChckBxCountDownReminder.Size = New System.Drawing.Size(71, 17)
        Me.ChckBxCountDownReminder.TabIndex = 5
        Me.ChckBxCountDownReminder.Text = "Reminder"
        Me.ChckBxCountDownReminder.UseVisualStyleBackColor = True
        '
        'btnCountdownLoadSound
        '
        Me.btnCountdownLoadSound.Enabled = False
        Me.btnCountdownLoadSound.Location = New System.Drawing.Point(323, 23)
        Me.btnCountdownLoadSound.Name = "btnCountdownLoadSound"
        Me.btnCountdownLoadSound.Size = New System.Drawing.Size(50, 20)
        Me.btnCountdownLoadSound.TabIndex = 4
        Me.btnCountdownLoadSound.Text = "..."
        Me.btnCountdownLoadSound.UseVisualStyleBackColor = True
        '
        'btnCountDownTestSound
        '
        Me.btnCountDownTestSound.Enabled = False
        Me.btnCountDownTestSound.Location = New System.Drawing.Point(379, 23)
        Me.btnCountDownTestSound.Name = "btnCountDownTestSound"
        Me.btnCountDownTestSound.Size = New System.Drawing.Size(50, 20)
        Me.btnCountDownTestSound.TabIndex = 3
        Me.btnCountDownTestSound.Text = "Test"
        Me.btnCountDownTestSound.UseVisualStyleBackColor = True
        '
        'TxtBxAction
        '
        Me.TxtBxAction.Enabled = False
        Me.TxtBxAction.Location = New System.Drawing.Point(174, 23)
        Me.TxtBxAction.Name = "TxtBxAction"
        Me.TxtBxAction.Size = New System.Drawing.Size(143, 20)
        Me.TxtBxAction.TabIndex = 2
        '
        'ChckBxCountDownSound
        '
        Me.ChckBxCountDownSound.AutoSize = True
        Me.ChckBxCountDownSound.Location = New System.Drawing.Point(111, 23)
        Me.ChckBxCountDownSound.Name = "ChckBxCountDownSound"
        Me.ChckBxCountDownSound.Size = New System.Drawing.Size(57, 17)
        Me.ChckBxCountDownSound.TabIndex = 1
        Me.ChckBxCountDownSound.Text = "Sound"
        Me.ChckBxCountDownSound.UseVisualStyleBackColor = True
        '
        'CmbBxCountDownAction
        '
        Me.CmbBxCountDownAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCountDownAction.FormattingEnabled = True
        Me.CmbBxCountDownAction.Location = New System.Drawing.Point(18, 19)
        Me.CmbBxCountDownAction.Name = "CmbBxCountDownAction"
        Me.CmbBxCountDownAction.Size = New System.Drawing.Size(76, 21)
        Me.CmbBxCountDownAction.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.upDwnCntDownValue)
        Me.GroupBox4.Controls.Add(Me.lblCountDownTime)
        Me.GroupBox4.Location = New System.Drawing.Point(115, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'upDwnCntDownValue
        '
        Me.upDwnCntDownValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upDwnCntDownValue.Location = New System.Drawing.Point(18, 16)
        Me.upDwnCntDownValue.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.upDwnCntDownValue.Name = "upDwnCntDownValue"
        Me.upDwnCntDownValue.Size = New System.Drawing.Size(57, 29)
        Me.upDwnCntDownValue.TabIndex = 1
        '
        'lblCountDownTime
        '
        Me.lblCountDownTime.AutoSize = True
        Me.lblCountDownTime.Enabled = False
        Me.lblCountDownTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountDownTime.Location = New System.Drawing.Point(90, 15)
        Me.lblCountDownTime.Name = "lblCountDownTime"
        Me.lblCountDownTime.Size = New System.Drawing.Size(103, 39)
        Me.lblCountDownTime.TabIndex = 0
        Me.lblCountDownTime.Text = "00:00"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCountDownStop)
        Me.GroupBox3.Controls.Add(Me.btnCountDownStart)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(103, 120)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'btnCountDownStop
        '
        Me.btnCountDownStop.Enabled = False
        Me.btnCountDownStop.Location = New System.Drawing.Point(14, 73)
        Me.btnCountDownStop.Name = "btnCountDownStop"
        Me.btnCountDownStop.Size = New System.Drawing.Size(75, 23)
        Me.btnCountDownStop.TabIndex = 1
        Me.btnCountDownStop.Text = "Stop"
        Me.btnCountDownStop.UseVisualStyleBackColor = True
        '
        'btnCountDownStart
        '
        Me.btnCountDownStart.Enabled = False
        Me.btnCountDownStart.Location = New System.Drawing.Point(14, 34)
        Me.btnCountDownStart.Name = "btnCountDownStart"
        Me.btnCountDownStart.Size = New System.Drawing.Size(75, 23)
        Me.btnCountDownStart.TabIndex = 0
        Me.btnCountDownStart.Text = "Start"
        Me.btnCountDownStart.UseVisualStyleBackColor = True
        '
        'TbPgTimer
        '
        Me.TbPgTimer.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTimer.Controls.Add(Me.GroupBox8)
        Me.TbPgTimer.Controls.Add(Me.GroupBox7)
        Me.TbPgTimer.Controls.Add(Me.GroupBox6)
        Me.TbPgTimer.Location = New System.Drawing.Point(4, 22)
        Me.TbPgTimer.Name = "TbPgTimer"
        Me.TbPgTimer.Size = New System.Drawing.Size(565, 134)
        Me.TbPgTimer.TabIndex = 2
        Me.TbPgTimer.Text = "Timer"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnTimerSplitClear)
        Me.GroupBox8.Controls.Add(Me.lblTimerSplit)
        Me.GroupBox8.Location = New System.Drawing.Point(115, 69)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        '
        'btnTimerSplitClear
        '
        Me.btnTimerSplitClear.Enabled = False
        Me.btnTimerSplitClear.Location = New System.Drawing.Point(298, 22)
        Me.btnTimerSplitClear.Name = "btnTimerSplitClear"
        Me.btnTimerSplitClear.Size = New System.Drawing.Size(75, 23)
        Me.btnTimerSplitClear.TabIndex = 2
        Me.btnTimerSplitClear.Text = "Clear"
        Me.btnTimerSplitClear.UseVisualStyleBackColor = True
        '
        'lblTimerSplit
        '
        Me.lblTimerSplit.AutoSize = True
        Me.lblTimerSplit.Enabled = False
        Me.lblTimerSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimerSplit.Location = New System.Drawing.Point(6, 15)
        Me.lblTimerSplit.Name = "lblTimerSplit"
        Me.lblTimerSplit.Size = New System.Drawing.Size(151, 39)
        Me.lblTimerSplit.TabIndex = 1
        Me.lblTimerSplit.Text = "00:00:00"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblTimerTime)
        Me.GroupBox7.Controls.Add(Me.btnTimerSplit)
        Me.GroupBox7.Location = New System.Drawing.Point(115, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        '
        'lblTimerTime
        '
        Me.lblTimerTime.AutoSize = True
        Me.lblTimerTime.Enabled = False
        Me.lblTimerTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimerTime.Location = New System.Drawing.Point(6, 15)
        Me.lblTimerTime.Name = "lblTimerTime"
        Me.lblTimerTime.Size = New System.Drawing.Size(151, 39)
        Me.lblTimerTime.TabIndex = 0
        Me.lblTimerTime.Text = "00:00:00"
        '
        'btnTimerSplit
        '
        Me.btnTimerSplit.Enabled = False
        Me.btnTimerSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTimerSplit.Location = New System.Drawing.Point(298, 19)
        Me.btnTimerSplit.Name = "btnTimerSplit"
        Me.btnTimerSplit.Size = New System.Drawing.Size(75, 23)
        Me.btnTimerSplit.TabIndex = 0
        Me.btnTimerSplit.Text = "Split"
        Me.btnTimerSplit.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnTimerClear)
        Me.GroupBox6.Controls.Add(Me.btnTimerStop)
        Me.GroupBox6.Controls.Add(Me.btnTimerStart)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(103, 120)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'btnTimerClear
        '
        Me.btnTimerClear.Enabled = False
        Me.btnTimerClear.Location = New System.Drawing.Point(14, 85)
        Me.btnTimerClear.Name = "btnTimerClear"
        Me.btnTimerClear.Size = New System.Drawing.Size(75, 23)
        Me.btnTimerClear.TabIndex = 2
        Me.btnTimerClear.Text = "Clear"
        Me.btnTimerClear.UseVisualStyleBackColor = True
        '
        'btnTimerStop
        '
        Me.btnTimerStop.Enabled = False
        Me.btnTimerStop.Location = New System.Drawing.Point(14, 52)
        Me.btnTimerStop.Name = "btnTimerStop"
        Me.btnTimerStop.Size = New System.Drawing.Size(75, 23)
        Me.btnTimerStop.TabIndex = 1
        Me.btnTimerStop.Text = "Stop"
        Me.btnTimerStop.UseVisualStyleBackColor = True
        '
        'btnTimerStart
        '
        Me.btnTimerStart.Location = New System.Drawing.Point(14, 19)
        Me.btnTimerStart.Name = "btnTimerStart"
        Me.btnTimerStart.Size = New System.Drawing.Size(75, 23)
        Me.btnTimerStart.TabIndex = 0
        Me.btnTimerStart.Text = "Start"
        Me.btnTimerStart.UseVisualStyleBackColor = True
        '
        'btnHide
        '
        Me.btnHide.Enabled = False
        Me.btnHide.Location = New System.Drawing.Point(510, 211)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(75, 23)
        Me.btnHide.TabIndex = 3
        Me.btnHide.Text = "Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(429, 211)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Enabled = False
        Me.btnHelp.Location = New System.Drawing.Point(348, 211)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'tmrTimer
        '
        '
        'tmrCountDown
        '
        Me.tmrCountDown.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmKlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 279)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnHide)
        Me.Controls.Add(Me.TbCntrl)
        Me.Controls.Add(Me.StsStrpInfo)
        Me.Controls.Add(Me.MnStrpMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MnStrpMain
        Me.Name = "frmKlock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klock"
        Me.StsStrpInfo.ResumeLayout(False)
        Me.StsStrpInfo.PerformLayout()
        Me.MnStrpMain.ResumeLayout(False)
        Me.MnStrpMain.PerformLayout()
        Me.TbCntrl.ResumeLayout(False)
        Me.TbPgTime.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TbPgCountDown.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.upDwnCntDownValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.TbPgTimer.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
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
    Friend WithEvents TbCntrl As System.Windows.Forms.TabControl
    Friend WithEvents TbPgTime As System.Windows.Forms.TabPage
    Friend WithEvents TbPgCountDown As System.Windows.Forms.TabPage
    Friend WithEvents TbPgTimer As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBxTime As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTimeTime As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBxCountDownAction As System.Windows.Forms.ComboBox
    Friend WithEvents upDwnCntDownValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCountDownTime As System.Windows.Forms.Label
    Friend WithEvents btnCountDownStop As System.Windows.Forms.Button
    Friend WithEvents btnCountDownStart As System.Windows.Forms.Button
    Friend WithEvents btnCountdownLoadSound As System.Windows.Forms.Button
    Friend WithEvents btnCountDownTestSound As System.Windows.Forms.Button
    Friend WithEvents TxtBxAction As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxCountDownSound As System.Windows.Forms.CheckBox
    Friend WithEvents btnHide As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTimerSplit As System.Windows.Forms.Label
    Friend WithEvents btnTimerSplit As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTimerTime As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTimerClear As System.Windows.Forms.Button
    Friend WithEvents btnTimerStop As System.Windows.Forms.Button
    Friend WithEvents btnTimerStart As System.Windows.Forms.Button
    Friend WithEvents tmrTimer As System.Windows.Forms.Timer
    Friend WithEvents btnTimerSplitClear As System.Windows.Forms.Button
    Friend WithEvents tmrCountDown As System.Windows.Forms.Timer
    Friend WithEvents ChckBxCountDownReminder As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBxCountDownReminder As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxCountDownSystem As System.Windows.Forms.CheckBox
    Friend WithEvents CmbBxCountDownSystem As System.Windows.Forms.ComboBox
    Friend WithEvents ChckBxCountDownCommand As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBxCountDowndCommand As System.Windows.Forms.TextBox
    Friend WithEvents btnCountDownLoadCommand As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
