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
        Me.btnCountdownSystemAbort = New System.Windows.Forms.Button()
        Me.TxtBxCountDowndCommand = New System.Windows.Forms.TextBox()
        Me.btnCountDownLoadCommand = New System.Windows.Forms.Button()
        Me.ChckBxCountDownCommand = New System.Windows.Forms.CheckBox()
        Me.CmbBxCountDownSystem = New System.Windows.Forms.ComboBox()
        Me.ChckBxCountDownSystem = New System.Windows.Forms.CheckBox()
        Me.TxtBxCountDownReminder = New System.Windows.Forms.TextBox()
        Me.ChckBxCountDownReminder = New System.Windows.Forms.CheckBox()
        Me.btnCountdownLoadSound = New System.Windows.Forms.Button()
        Me.btnCountDownTestSound = New System.Windows.Forms.Button()
        Me.TxtBxCountDownAction = New System.Windows.Forms.TextBox()
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
        Me.TbPgReminder = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.btnReminderSystemAbort = New System.Windows.Forms.Button()
        Me.TxtBxReminderCommand = New System.Windows.Forms.TextBox()
        Me.btnReminderLoadCommand = New System.Windows.Forms.Button()
        Me.chckBXReminderCommand = New System.Windows.Forms.CheckBox()
        Me.CmbBxReminderSystem = New System.Windows.Forms.ComboBox()
        Me.ChckBxReminderSystem = New System.Windows.Forms.CheckBox()
        Me.TxtBxReminderReminder = New System.Windows.Forms.TextBox()
        Me.ChckBxReminderReminder = New System.Windows.Forms.CheckBox()
        Me.btnReminderLoadSound = New System.Windows.Forms.Button()
        Me.btnReminderTestSound = New System.Windows.Forms.Button()
        Me.TxtBxReminderAction = New System.Windows.Forms.TextBox()
        Me.ChckBxReminderSound = New System.Windows.Forms.CheckBox()
        Me.CmbBxReminderAction = New System.Windows.Forms.ComboBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.ChckBxReminderTimeCheck = New System.Windows.Forms.CheckBox()
        Me.TmPckrRiminder = New System.Windows.Forms.DateTimePicker()
        Me.DtPckrRiminder = New System.Windows.Forms.DateTimePicker()
        Me.lblReminderText = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnReminderClear = New System.Windows.Forms.Button()
        Me.btnReminderSet = New System.Windows.Forms.Button()
        Me.btnHide = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.NtfyIcnKlock = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CntxtMnStrpKlock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TlStrpMnItmShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.TlStrpMnItmTime = New System.Windows.Forms.ToolStripMenuItem()
        Me.TlStrpMnItmOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.TlStrpMnItmExit = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TbPgReminder.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.CntxtMnStrpKlock.SuspendLayout()
        Me.SuspendLayout()
        '
        'StsStrpInfo
        '
        Me.StsStrpInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLblTime, Me.StsLblDate, Me.StsLblKeys})
        Me.StsStrpInfo.Location = New System.Drawing.Point(0, 231)
        Me.StsStrpInfo.Name = "StsStrpInfo"
        Me.StsStrpInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StsStrpInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StsStrpInfo.Size = New System.Drawing.Size(597, 24)
        Me.StsStrpInfo.SizingGrip = False
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
        Me.MnStrpMain.Size = New System.Drawing.Size(597, 24)
        Me.MnStrpMain.TabIndex = 1
        Me.MnStrpMain.Text = "MenuStrip1"
        '
        'MnItmFile
        '
        Me.MnItmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnItmExit, Me.MnItmOptions})
        Me.MnItmFile.Name = "MnItmFile"
        Me.MnItmFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.MnItmFile.Size = New System.Drawing.Size(37, 20)
        Me.MnItmFile.Text = "&File"
        '
        'MnItmExit
        '
        Me.MnItmExit.Name = "MnItmExit"
        Me.MnItmExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.MnItmExit.Size = New System.Drawing.Size(159, 22)
        Me.MnItmExit.Text = "E&xit"
        '
        'MnItmOptions
        '
        Me.MnItmOptions.Name = "MnItmOptions"
        Me.MnItmOptions.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnItmOptions.Size = New System.Drawing.Size(159, 22)
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
        Me.MnItmSubHelp.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnItmSubHelp.Size = New System.Drawing.Size(153, 22)
        Me.MnItmSubHelp.Text = "Hel&p"
        '
        'MnItmLicense
        '
        Me.MnItmLicense.Name = "MnItmLicense"
        Me.MnItmLicense.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.MnItmLicense.Size = New System.Drawing.Size(153, 22)
        Me.MnItmLicense.Text = "&License"
        '
        'MnItmAbout
        '
        Me.MnItmAbout.Name = "MnItmAbout"
        Me.MnItmAbout.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MnItmAbout.Size = New System.Drawing.Size(153, 22)
        Me.MnItmAbout.Text = "&About"
        '
        'TbCntrl
        '
        Me.TbCntrl.Controls.Add(Me.TbPgTime)
        Me.TbCntrl.Controls.Add(Me.TbPgCountDown)
        Me.TbCntrl.Controls.Add(Me.TbPgTimer)
        Me.TbCntrl.Controls.Add(Me.TbPgReminder)
        Me.TbCntrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.LblTimeTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.GroupBox5.Controls.Add(Me.btnCountdownSystemAbort)
        Me.GroupBox5.Controls.Add(Me.TxtBxCountDowndCommand)
        Me.GroupBox5.Controls.Add(Me.btnCountDownLoadCommand)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownCommand)
        Me.GroupBox5.Controls.Add(Me.CmbBxCountDownSystem)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownSystem)
        Me.GroupBox5.Controls.Add(Me.TxtBxCountDownReminder)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownReminder)
        Me.GroupBox5.Controls.Add(Me.btnCountdownLoadSound)
        Me.GroupBox5.Controls.Add(Me.btnCountDownTestSound)
        Me.GroupBox5.Controls.Add(Me.TxtBxCountDownAction)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountDownSound)
        Me.GroupBox5.Controls.Add(Me.CmbBxCountDownAction)
        Me.GroupBox5.Location = New System.Drawing.Point(115, 69)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'btnCountdownSystemAbort
        '
        Me.btnCountdownSystemAbort.Enabled = False
        Me.btnCountdownSystemAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCountdownSystemAbort.Location = New System.Drawing.Point(379, 25)
        Me.btnCountdownSystemAbort.Name = "btnCountdownSystemAbort"
        Me.btnCountdownSystemAbort.Size = New System.Drawing.Size(50, 20)
        Me.btnCountdownSystemAbort.TabIndex = 12
        Me.btnCountdownSystemAbort.Text = "Abort"
        Me.btnCountdownSystemAbort.UseVisualStyleBackColor = True
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
        Me.ChckBxCountDownCommand.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxCountDownCommand.Name = "ChckBxCountDownCommand"
        Me.ChckBxCountDownCommand.Size = New System.Drawing.Size(84, 19)
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
        Me.ChckBxCountDownSystem.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxCountDownSystem.Name = "ChckBxCountDownSystem"
        Me.ChckBxCountDownSystem.Size = New System.Drawing.Size(66, 19)
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
        Me.ChckBxCountDownReminder.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxCountDownReminder.Name = "ChckBxCountDownReminder"
        Me.ChckBxCountDownReminder.Size = New System.Drawing.Size(81, 19)
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
        'TxtBxCountDownAction
        '
        Me.TxtBxCountDownAction.Enabled = False
        Me.TxtBxCountDownAction.Location = New System.Drawing.Point(174, 23)
        Me.TxtBxCountDownAction.Name = "TxtBxCountDownAction"
        Me.TxtBxCountDownAction.Size = New System.Drawing.Size(143, 20)
        Me.TxtBxCountDownAction.TabIndex = 2
        '
        'ChckBxCountDownSound
        '
        Me.ChckBxCountDownSound.AutoSize = True
        Me.ChckBxCountDownSound.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxCountDownSound.Name = "ChckBxCountDownSound"
        Me.ChckBxCountDownSound.Size = New System.Drawing.Size(62, 19)
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
        'TbPgReminder
        '
        Me.TbPgReminder.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgReminder.Controls.Add(Me.GroupBox11)
        Me.TbPgReminder.Controls.Add(Me.GroupBox10)
        Me.TbPgReminder.Controls.Add(Me.GroupBox9)
        Me.TbPgReminder.Location = New System.Drawing.Point(4, 22)
        Me.TbPgReminder.Name = "TbPgReminder"
        Me.TbPgReminder.Size = New System.Drawing.Size(565, 134)
        Me.TbPgReminder.TabIndex = 3
        Me.TbPgReminder.Text = "Reminder"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.btnReminderSystemAbort)
        Me.GroupBox11.Controls.Add(Me.TxtBxReminderCommand)
        Me.GroupBox11.Controls.Add(Me.btnReminderLoadCommand)
        Me.GroupBox11.Controls.Add(Me.chckBXReminderCommand)
        Me.GroupBox11.Controls.Add(Me.CmbBxReminderSystem)
        Me.GroupBox11.Controls.Add(Me.ChckBxReminderSystem)
        Me.GroupBox11.Controls.Add(Me.TxtBxReminderReminder)
        Me.GroupBox11.Controls.Add(Me.ChckBxReminderReminder)
        Me.GroupBox11.Controls.Add(Me.btnReminderLoadSound)
        Me.GroupBox11.Controls.Add(Me.btnReminderTestSound)
        Me.GroupBox11.Controls.Add(Me.TxtBxReminderAction)
        Me.GroupBox11.Controls.Add(Me.ChckBxReminderSound)
        Me.GroupBox11.Controls.Add(Me.CmbBxReminderAction)
        Me.GroupBox11.Location = New System.Drawing.Point(115, 69)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox11.TabIndex = 3
        Me.GroupBox11.TabStop = False
        '
        'btnReminderSystemAbort
        '
        Me.btnReminderSystemAbort.Enabled = False
        Me.btnReminderSystemAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReminderSystemAbort.Location = New System.Drawing.Point(379, 24)
        Me.btnReminderSystemAbort.Name = "btnReminderSystemAbort"
        Me.btnReminderSystemAbort.Size = New System.Drawing.Size(50, 20)
        Me.btnReminderSystemAbort.TabIndex = 12
        Me.btnReminderSystemAbort.Text = "Abort"
        Me.btnReminderSystemAbort.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReminderSystemAbort.UseVisualStyleBackColor = True
        '
        'TxtBxReminderCommand
        '
        Me.TxtBxReminderCommand.Enabled = False
        Me.TxtBxReminderCommand.Location = New System.Drawing.Point(190, 24)
        Me.TxtBxReminderCommand.Name = "TxtBxReminderCommand"
        Me.TxtBxReminderCommand.Size = New System.Drawing.Size(183, 20)
        Me.TxtBxReminderCommand.TabIndex = 11
        '
        'btnReminderLoadCommand
        '
        Me.btnReminderLoadCommand.Enabled = False
        Me.btnReminderLoadCommand.Location = New System.Drawing.Point(379, 24)
        Me.btnReminderLoadCommand.Name = "btnReminderLoadCommand"
        Me.btnReminderLoadCommand.Size = New System.Drawing.Size(50, 20)
        Me.btnReminderLoadCommand.TabIndex = 10
        Me.btnReminderLoadCommand.Text = "..."
        Me.btnReminderLoadCommand.UseVisualStyleBackColor = True
        '
        'chckBXReminderCommand
        '
        Me.chckBXReminderCommand.AutoSize = True
        Me.chckBXReminderCommand.Location = New System.Drawing.Point(100, 23)
        Me.chckBXReminderCommand.Name = "chckBXReminderCommand"
        Me.chckBXReminderCommand.Size = New System.Drawing.Size(84, 19)
        Me.chckBXReminderCommand.TabIndex = 9
        Me.chckBXReminderCommand.Text = "Command"
        Me.chckBXReminderCommand.UseVisualStyleBackColor = True
        '
        'CmbBxReminderSystem
        '
        Me.CmbBxReminderSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxReminderSystem.Enabled = False
        Me.CmbBxReminderSystem.FormattingEnabled = True
        Me.CmbBxReminderSystem.Location = New System.Drawing.Point(174, 23)
        Me.CmbBxReminderSystem.Name = "CmbBxReminderSystem"
        Me.CmbBxReminderSystem.Size = New System.Drawing.Size(100, 21)
        Me.CmbBxReminderSystem.TabIndex = 8
        '
        'ChckBxReminderSystem
        '
        Me.ChckBxReminderSystem.AutoSize = True
        Me.ChckBxReminderSystem.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxReminderSystem.Name = "ChckBxReminderSystem"
        Me.ChckBxReminderSystem.Size = New System.Drawing.Size(66, 19)
        Me.ChckBxReminderSystem.TabIndex = 7
        Me.ChckBxReminderSystem.Text = "System"
        Me.ChckBxReminderSystem.UseVisualStyleBackColor = True
        '
        'TxtBxReminderReminder
        '
        Me.TxtBxReminderReminder.Enabled = False
        Me.TxtBxReminderReminder.Location = New System.Drawing.Point(188, 24)
        Me.TxtBxReminderReminder.Name = "TxtBxReminderReminder"
        Me.TxtBxReminderReminder.Size = New System.Drawing.Size(241, 20)
        Me.TxtBxReminderReminder.TabIndex = 6
        Me.TxtBxReminderReminder.Text = "Reminding you now, Sir!"
        '
        'ChckBxReminderReminder
        '
        Me.ChckBxReminderReminder.AutoSize = True
        Me.ChckBxReminderReminder.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxReminderReminder.Name = "ChckBxReminderReminder"
        Me.ChckBxReminderReminder.Size = New System.Drawing.Size(81, 19)
        Me.ChckBxReminderReminder.TabIndex = 5
        Me.ChckBxReminderReminder.Text = "Reminder"
        Me.ChckBxReminderReminder.UseVisualStyleBackColor = True
        '
        'btnReminderLoadSound
        '
        Me.btnReminderLoadSound.Enabled = False
        Me.btnReminderLoadSound.Location = New System.Drawing.Point(323, 23)
        Me.btnReminderLoadSound.Name = "btnReminderLoadSound"
        Me.btnReminderLoadSound.Size = New System.Drawing.Size(50, 20)
        Me.btnReminderLoadSound.TabIndex = 4
        Me.btnReminderLoadSound.Text = "..."
        Me.btnReminderLoadSound.UseVisualStyleBackColor = True
        '
        'btnReminderTestSound
        '
        Me.btnReminderTestSound.Enabled = False
        Me.btnReminderTestSound.Location = New System.Drawing.Point(379, 23)
        Me.btnReminderTestSound.Name = "btnReminderTestSound"
        Me.btnReminderTestSound.Size = New System.Drawing.Size(50, 20)
        Me.btnReminderTestSound.TabIndex = 3
        Me.btnReminderTestSound.Text = "Test"
        Me.btnReminderTestSound.UseVisualStyleBackColor = True
        '
        'TxtBxReminderAction
        '
        Me.TxtBxReminderAction.Enabled = False
        Me.TxtBxReminderAction.Location = New System.Drawing.Point(174, 23)
        Me.TxtBxReminderAction.Name = "TxtBxReminderAction"
        Me.TxtBxReminderAction.Size = New System.Drawing.Size(143, 20)
        Me.TxtBxReminderAction.TabIndex = 2
        '
        'ChckBxReminderSound
        '
        Me.ChckBxReminderSound.AutoSize = True
        Me.ChckBxReminderSound.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxReminderSound.Name = "ChckBxReminderSound"
        Me.ChckBxReminderSound.Size = New System.Drawing.Size(62, 19)
        Me.ChckBxReminderSound.TabIndex = 1
        Me.ChckBxReminderSound.Text = "Sound"
        Me.ChckBxReminderSound.UseVisualStyleBackColor = True
        '
        'CmbBxReminderAction
        '
        Me.CmbBxReminderAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxReminderAction.FormattingEnabled = True
        Me.CmbBxReminderAction.Location = New System.Drawing.Point(18, 19)
        Me.CmbBxReminderAction.Name = "CmbBxReminderAction"
        Me.CmbBxReminderAction.Size = New System.Drawing.Size(76, 21)
        Me.CmbBxReminderAction.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.ChckBxReminderTimeCheck)
        Me.GroupBox10.Controls.Add(Me.TmPckrRiminder)
        Me.GroupBox10.Controls.Add(Me.DtPckrRiminder)
        Me.GroupBox10.Controls.Add(Me.lblReminderText)
        Me.GroupBox10.Location = New System.Drawing.Point(115, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(440, 57)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        '
        'ChckBxReminderTimeCheck
        '
        Me.ChckBxReminderTimeCheck.AutoSize = True
        Me.ChckBxReminderTimeCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxReminderTimeCheck.Location = New System.Drawing.Point(358, 22)
        Me.ChckBxReminderTimeCheck.Name = "ChckBxReminderTimeCheck"
        Me.ChckBxReminderTimeCheck.Size = New System.Drawing.Size(15, 14)
        Me.ChckBxReminderTimeCheck.TabIndex = 3
        Me.ChckBxReminderTimeCheck.UseVisualStyleBackColor = True
        '
        'TmPckrRiminder
        '
        Me.TmPckrRiminder.Checked = False
        Me.TmPckrRiminder.CustomFormat = "HH:mm"
        Me.TmPckrRiminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TmPckrRiminder.Location = New System.Drawing.Point(379, 19)
        Me.TmPckrRiminder.Name = "TmPckrRiminder"
        Me.TmPckrRiminder.ShowUpDown = True
        Me.TmPckrRiminder.Size = New System.Drawing.Size(50, 20)
        Me.TmPckrRiminder.TabIndex = 2
        '
        'DtPckrRiminder
        '
        Me.DtPckrRiminder.CustomFormat = """yyyy-MM-dd HH:mm"""
        Me.DtPckrRiminder.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DtPckrRiminder.Location = New System.Drawing.Point(217, 19)
        Me.DtPckrRiminder.Name = "DtPckrRiminder"
        Me.DtPckrRiminder.Size = New System.Drawing.Size(124, 20)
        Me.DtPckrRiminder.TabIndex = 1
        '
        'lblReminderText
        '
        Me.lblReminderText.AutoSize = True
        Me.lblReminderText.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReminderText.Location = New System.Drawing.Point(6, 19)
        Me.lblReminderText.Name = "lblReminderText"
        Me.lblReminderText.Size = New System.Drawing.Size(159, 24)
        Me.lblReminderText.TabIndex = 0
        Me.lblReminderText.Text = "Reminder Not Set"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnReminderClear)
        Me.GroupBox9.Controls.Add(Me.btnReminderSet)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(103, 120)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        '
        'btnReminderClear
        '
        Me.btnReminderClear.Enabled = False
        Me.btnReminderClear.Location = New System.Drawing.Point(14, 73)
        Me.btnReminderClear.Name = "btnReminderClear"
        Me.btnReminderClear.Size = New System.Drawing.Size(75, 23)
        Me.btnReminderClear.TabIndex = 1
        Me.btnReminderClear.Text = "Clear"
        Me.btnReminderClear.UseVisualStyleBackColor = True
        '
        'btnReminderSet
        '
        Me.btnReminderSet.Enabled = False
        Me.btnReminderSet.Location = New System.Drawing.Point(14, 34)
        Me.btnReminderSet.Name = "btnReminderSet"
        Me.btnReminderSet.Size = New System.Drawing.Size(75, 23)
        Me.btnReminderSet.TabIndex = 0
        Me.btnReminderSet.Text = "Set"
        Me.btnReminderSet.UseVisualStyleBackColor = True
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(510, 193)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(75, 23)
        Me.btnHide.TabIndex = 3
        Me.btnHide.Text = "Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(429, 193)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Enabled = False
        Me.btnHelp.Location = New System.Drawing.Point(348, 193)
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
        'NtfyIcnKlock
        '
        Me.NtfyIcnKlock.ContextMenuStrip = Me.CntxtMnStrpKlock
        Me.NtfyIcnKlock.Icon = CType(resources.GetObject("NtfyIcnKlock.Icon"), System.Drawing.Icon)
        Me.NtfyIcnKlock.Text = "Klock"
        '
        'CntxtMnStrpKlock
        '
        Me.CntxtMnStrpKlock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlStrpMnItmShow, Me.TlStrpMnItmTime, Me.TlStrpMnItmOptions, Me.TlStrpMnItmExit})
        Me.CntxtMnStrpKlock.Name = "CntxtMnStrpKlock"
        Me.CntxtMnStrpKlock.Size = New System.Drawing.Size(117, 92)
        '
        'TlStrpMnItmShow
        '
        Me.TlStrpMnItmShow.Name = "TlStrpMnItmShow"
        Me.TlStrpMnItmShow.Size = New System.Drawing.Size(116, 22)
        Me.TlStrpMnItmShow.Text = "Show"
        '
        'TlStrpMnItmTime
        '
        Me.TlStrpMnItmTime.CheckOnClick = True
        Me.TlStrpMnItmTime.Name = "TlStrpMnItmTime"
        Me.TlStrpMnItmTime.Size = New System.Drawing.Size(116, 22)
        Me.TlStrpMnItmTime.Text = "Time"
        '
        'TlStrpMnItmOptions
        '
        Me.TlStrpMnItmOptions.Name = "TlStrpMnItmOptions"
        Me.TlStrpMnItmOptions.Size = New System.Drawing.Size(116, 22)
        Me.TlStrpMnItmOptions.Text = "Options"
        '
        'TlStrpMnItmExit
        '
        Me.TlStrpMnItmExit.Name = "TlStrpMnItmExit"
        Me.TlStrpMnItmExit.Size = New System.Drawing.Size(116, 22)
        Me.TlStrpMnItmExit.Text = "Exit"
        '
        'frmKlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 255)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnHide)
        Me.Controls.Add(Me.StsStrpInfo)
        Me.Controls.Add(Me.MnStrpMain)
        Me.Controls.Add(Me.TbCntrl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MnStrpMain
        Me.MaximumSize = New System.Drawing.Size(607, 287)
        Me.MinimumSize = New System.Drawing.Size(607, 287)
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
        Me.TbPgReminder.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.CntxtMnStrpKlock.ResumeLayout(False)
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
    Friend WithEvents TxtBxCountDownAction As System.Windows.Forms.TextBox
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
    Friend WithEvents NtfyIcnKlock As System.Windows.Forms.NotifyIcon
    Friend WithEvents CntxtMnStrpKlock As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TlStrpMnItmShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TlStrpMnItmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TlStrpMnItmTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbPgReminder As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReminderClear As System.Windows.Forms.Button
    Friend WithEvents btnReminderSet As System.Windows.Forms.Button
    Friend WithEvents DtPckrRiminder As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReminderText As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBxReminderCommand As System.Windows.Forms.TextBox
    Friend WithEvents btnReminderLoadCommand As System.Windows.Forms.Button
    Friend WithEvents chckBXReminderCommand As System.Windows.Forms.CheckBox
    Friend WithEvents CmbBxReminderSystem As System.Windows.Forms.ComboBox
    Friend WithEvents ChckBxReminderSystem As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBxReminderReminder As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxReminderReminder As System.Windows.Forms.CheckBox
    Friend WithEvents btnReminderLoadSound As System.Windows.Forms.Button
    Friend WithEvents btnReminderTestSound As System.Windows.Forms.Button
    Friend WithEvents TxtBxReminderAction As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxReminderSound As System.Windows.Forms.CheckBox
    Friend WithEvents CmbBxReminderAction As System.Windows.Forms.ComboBox
    Friend WithEvents TmPckrRiminder As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChckBxReminderTimeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents TlStrpMnItmOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReminderSystemAbort As System.Windows.Forms.Button
    Friend WithEvents btnCountdownSystemAbort As System.Windows.Forms.Button

End Class
