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
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaylightSavingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CultureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PowerSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmSubHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmLicense = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnItmAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.TbCntrl = New System.Windows.Forms.TabControl()
        Me.TbPgTime = New System.Windows.Forms.TabPage()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.LblTimeTwoTime = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.CmbBxTimeTwo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblTimeOneTime = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbBxTimeOne = New System.Windows.Forms.ComboBox()
        Me.TbPgWorldClock = New System.Windows.Forms.TabPage()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.LblWorldKlockWorld = New System.Windows.Forms.Label()
        Me.LblWorldKlockLocal = New System.Windows.Forms.Label()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.RdBtnWorldClockTimeZoneID = New System.Windows.Forms.RadioButton()
        Me.RdBtnWorldClockTimeZoneLongName = New System.Windows.Forms.RadioButton()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.CmbBxWorldKlockTimeZones = New System.Windows.Forms.ComboBox()
        Me.TbPgCountDown = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ChckBxCountdownScreenSaver = New System.Windows.Forms.CheckBox()
        Me.TxtBxCountdownSpeech = New System.Windows.Forms.TextBox()
        Me.ChckBxCountdownSpeech = New System.Windows.Forms.CheckBox()
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
        Me.btnCountdown90 = New System.Windows.Forms.Button()
        Me.btnCountdown60 = New System.Windows.Forms.Button()
        Me.btnCountdown30 = New System.Windows.Forms.Button()
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
        Me.ChckBxReminderScreenSaver = New System.Windows.Forms.CheckBox()
        Me.TxtBxReminderSpeech = New System.Windows.Forms.TextBox()
        Me.ChckBxReminderSpeech = New System.Windows.Forms.CheckBox()
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
        Me.TbPgFriends = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.pnlFriends = New System.Windows.Forms.Panel()
        Me.DtPckrFriendsDOB = New System.Windows.Forms.DateTimePicker()
        Me.txtbxFriendsNotes = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtbxFriendsHomePage = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtbxFriendsAddressCounty = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsAddressPostCode = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsAddressCity = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtbxFriendsAddressLine2 = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsAddressLine1 = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsAddressNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtbxFriendsTelephone3 = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsTelephone2 = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsTelephone1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbxFriendsEmail3 = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsEmail2 = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsEmail1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtbxFriendsLastName = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsMiddleName = New System.Windows.Forms.TextBox()
        Me.txtbxFriendsFirstName = New System.Windows.Forms.TextBox()
        Me.lblFriendsLastName = New System.Windows.Forms.Label()
        Me.lblFriendsMiddleName = New System.Windows.Forms.Label()
        Me.lblFriendsFirstName = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.LstBxFriends = New System.Windows.Forms.ListBox()
        Me.TbPgEvents = New System.Windows.Forms.TabPage()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.pnlEvents = New System.Windows.Forms.Panel()
        Me.txtbxEventNotes = New System.Windows.Forms.TextBox()
        Me.lblEventNotes = New System.Windows.Forms.Label()
        Me.DtTmPckrEventsDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEventsDate = New System.Windows.Forms.Label()
        Me.lblEventsName = New System.Windows.Forms.Label()
        Me.CmbBxEventTypes = New System.Windows.Forms.ComboBox()
        Me.lblEventsType = New System.Windows.Forms.Label()
        Me.TxtBxEventsName = New System.Windows.Forms.TextBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.LstBxEvents = New System.Windows.Forms.ListBox()
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
        Me.TlStrpMnItmHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.TlStrpMnItmOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.TlStrpMnItmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrReminder = New System.Windows.Forms.Timer(Me.components)
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.HlpPrvdrKlock = New System.Windows.Forms.HelpProvider()
        Me.tmrEvents = New System.Windows.Forms.Timer(Me.components)
        Me.btnEventsCheck = New System.Windows.Forms.Button()
        Me.StsStrpInfo.SuspendLayout()
        Me.MnStrpMain.SuspendLayout()
        Me.TbCntrl.SuspendLayout()
        Me.TbPgTime.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TbPgWorldClock.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
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
        Me.TbPgFriends.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.pnlFriends.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TbPgEvents.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.pnlEvents.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.CntxtMnStrpKlock.SuspendLayout()
        Me.SuspendLayout()
        '
        'StsStrpInfo
        '
        Me.StsStrpInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLblTime, Me.StsLblDate, Me.StsLblKeys})
        Me.StsStrpInfo.Location = New System.Drawing.Point(0, 240)
        Me.StsStrpInfo.Name = "StsStrpInfo"
        Me.StsStrpInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StsStrpInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StsStrpInfo.Size = New System.Drawing.Size(696, 24)
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
        Me.TmrMain.Interval = 1000
        '
        'MnStrpMain
        '
        Me.MnStrpMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnItmFile, Me.InfoToolStripMenuItem, Me.MnItmHelp})
        Me.MnStrpMain.Location = New System.Drawing.Point(0, 0)
        Me.MnStrpMain.Name = "MnStrpMain"
        Me.MnStrpMain.Size = New System.Drawing.Size(696, 24)
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
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DaylightSavingToolStripMenuItem, Me.CultureToolStripMenuItem, Me.OSToolStripMenuItem, Me.PowerSourceToolStripMenuItem})
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.InfoToolStripMenuItem.Text = "&Info"
        '
        'DaylightSavingToolStripMenuItem
        '
        Me.DaylightSavingToolStripMenuItem.Name = "DaylightSavingToolStripMenuItem"
        Me.DaylightSavingToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DaylightSavingToolStripMenuItem.Text = "Daylight Saving"
        '
        'CultureToolStripMenuItem
        '
        Me.CultureToolStripMenuItem.Name = "CultureToolStripMenuItem"
        Me.CultureToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CultureToolStripMenuItem.Text = "Culture"
        '
        'OSToolStripMenuItem
        '
        Me.OSToolStripMenuItem.Name = "OSToolStripMenuItem"
        Me.OSToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.OSToolStripMenuItem.Text = "Operating System"
        '
        'PowerSourceToolStripMenuItem
        '
        Me.PowerSourceToolStripMenuItem.Name = "PowerSourceToolStripMenuItem"
        Me.PowerSourceToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.PowerSourceToolStripMenuItem.Text = "Power Source"
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
        Me.TbCntrl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TbCntrl.Controls.Add(Me.TbPgTime)
        Me.TbCntrl.Controls.Add(Me.TbPgWorldClock)
        Me.TbCntrl.Controls.Add(Me.TbPgCountDown)
        Me.TbCntrl.Controls.Add(Me.TbPgTimer)
        Me.TbCntrl.Controls.Add(Me.TbPgReminder)
        Me.TbCntrl.Controls.Add(Me.TbPgFriends)
        Me.TbCntrl.Controls.Add(Me.TbPgEvents)
        Me.TbCntrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbCntrl.Location = New System.Drawing.Point(12, 27)
        Me.TbCntrl.Name = "TbCntrl"
        Me.TbCntrl.SelectedIndex = 0
        Me.TbCntrl.Size = New System.Drawing.Size(679, 160)
        Me.TbCntrl.TabIndex = 2
        '
        'TbPgTime
        '
        Me.TbPgTime.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTime.Controls.Add(Me.GroupBox15)
        Me.TbPgTime.Controls.Add(Me.GroupBox14)
        Me.TbPgTime.Controls.Add(Me.GroupBox2)
        Me.TbPgTime.Controls.Add(Me.GroupBox1)
        Me.TbPgTime.Location = New System.Drawing.Point(4, 25)
        Me.TbPgTime.Name = "TbPgTime"
        Me.TbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgTime.Size = New System.Drawing.Size(671, 131)
        Me.TbPgTime.TabIndex = 0
        Me.TbPgTime.Text = "Fuzzy Time"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.LblTimeTwoTime)
        Me.GroupBox15.Location = New System.Drawing.Point(115, 69)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(550, 57)
        Me.GroupBox15.TabIndex = 4
        Me.GroupBox15.TabStop = False
        '
        'LblTimeTwoTime
        '
        Me.LblTimeTwoTime.AutoSize = True
        Me.LblTimeTwoTime.Font = New System.Drawing.Font("Lucida Calligraphy", 16.0!)
        Me.LblTimeTwoTime.Location = New System.Drawing.Point(6, 16)
        Me.LblTimeTwoTime.Name = "LblTimeTwoTime"
        Me.LblTimeTwoTime.Size = New System.Drawing.Size(506, 28)
        Me.LblTimeTwoTime.TabIndex = 0
        Me.LblTimeTwoTime.Text = "twelve minutes past eleven in the evening"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.CmbBxTimeTwo)
        Me.GroupBox14.Location = New System.Drawing.Point(6, 69)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(103, 57)
        Me.GroupBox14.TabIndex = 3
        Me.GroupBox14.TabStop = False
        '
        'CmbBxTimeTwo
        '
        Me.CmbBxTimeTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxTimeTwo.FormattingEnabled = True
        Me.CmbBxTimeTwo.Location = New System.Drawing.Point(6, 19)
        Me.CmbBxTimeTwo.Name = "CmbBxTimeTwo"
        Me.CmbBxTimeTwo.Size = New System.Drawing.Size(86, 21)
        Me.CmbBxTimeTwo.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblTimeOneTime)
        Me.GroupBox2.Location = New System.Drawing.Point(115, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(550, 57)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'LblTimeOneTime
        '
        Me.LblTimeOneTime.AutoSize = True
        Me.LblTimeOneTime.Font = New System.Drawing.Font("Lucida Calligraphy", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTimeOneTime.Location = New System.Drawing.Point(6, 19)
        Me.LblTimeOneTime.Name = "LblTimeOneTime"
        Me.LblTimeOneTime.Size = New System.Drawing.Size(506, 28)
        Me.LblTimeOneTime.TabIndex = 0
        Me.LblTimeOneTime.Text = "twelve minutes past eleven in the evening"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbBxTimeOne)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 57)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CmbBxTimeOne
        '
        Me.CmbBxTimeOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxTimeOne.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbBxTimeOne.FormattingEnabled = True
        Me.CmbBxTimeOne.Location = New System.Drawing.Point(6, 19)
        Me.CmbBxTimeOne.Name = "CmbBxTimeOne"
        Me.CmbBxTimeOne.Size = New System.Drawing.Size(86, 21)
        Me.CmbBxTimeOne.TabIndex = 0
        '
        'TbPgWorldClock
        '
        Me.TbPgWorldClock.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgWorldClock.Controls.Add(Me.GroupBox18)
        Me.TbPgWorldClock.Controls.Add(Me.GroupBox17)
        Me.TbPgWorldClock.Controls.Add(Me.GroupBox16)
        Me.TbPgWorldClock.Location = New System.Drawing.Point(4, 25)
        Me.TbPgWorldClock.Name = "TbPgWorldClock"
        Me.TbPgWorldClock.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgWorldClock.Size = New System.Drawing.Size(671, 131)
        Me.TbPgWorldClock.TabIndex = 5
        Me.TbPgWorldClock.Text = "World Klock"
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.LblWorldKlockWorld)
        Me.GroupBox18.Controls.Add(Me.LblWorldKlockLocal)
        Me.GroupBox18.Location = New System.Drawing.Point(365, 6)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(300, 120)
        Me.GroupBox18.TabIndex = 2
        Me.GroupBox18.TabStop = False
        '
        'LblWorldKlockWorld
        '
        Me.LblWorldKlockWorld.AutoSize = True
        Me.LblWorldKlockWorld.Location = New System.Drawing.Point(20, 63)
        Me.LblWorldKlockWorld.Name = "LblWorldKlockWorld"
        Me.LblWorldKlockWorld.Size = New System.Drawing.Size(45, 15)
        Me.LblWorldKlockWorld.TabIndex = 1
        Me.LblWorldKlockWorld.Text = "Label2"
        '
        'LblWorldKlockLocal
        '
        Me.LblWorldKlockLocal.AutoSize = True
        Me.LblWorldKlockLocal.Location = New System.Drawing.Point(20, 25)
        Me.LblWorldKlockLocal.Name = "LblWorldKlockLocal"
        Me.LblWorldKlockLocal.Size = New System.Drawing.Size(45, 15)
        Me.LblWorldKlockLocal.TabIndex = 0
        Me.LblWorldKlockLocal.Text = "Label1"
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.RdBtnWorldClockTimeZoneID)
        Me.GroupBox17.Controls.Add(Me.RdBtnWorldClockTimeZoneLongName)
        Me.GroupBox17.Location = New System.Drawing.Point(6, 69)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(353, 57)
        Me.GroupBox17.TabIndex = 1
        Me.GroupBox17.TabStop = False
        '
        'RdBtnWorldClockTimeZoneID
        '
        Me.RdBtnWorldClockTimeZoneID.AutoSize = True
        Me.RdBtnWorldClockTimeZoneID.Location = New System.Drawing.Point(154, 19)
        Me.RdBtnWorldClockTimeZoneID.Name = "RdBtnWorldClockTimeZoneID"
        Me.RdBtnWorldClockTimeZoneID.Size = New System.Drawing.Size(127, 19)
        Me.RdBtnWorldClockTimeZoneID.TabIndex = 1
        Me.RdBtnWorldClockTimeZoneID.Text = "by Standard Name"
        Me.RdBtnWorldClockTimeZoneID.UseVisualStyleBackColor = True
        '
        'RdBtnWorldClockTimeZoneLongName
        '
        Me.RdBtnWorldClockTimeZoneLongName.AutoSize = True
        Me.RdBtnWorldClockTimeZoneLongName.Checked = True
        Me.RdBtnWorldClockTimeZoneLongName.Location = New System.Drawing.Point(29, 19)
        Me.RdBtnWorldClockTimeZoneLongName.Name = "RdBtnWorldClockTimeZoneLongName"
        Me.RdBtnWorldClockTimeZoneLongName.Size = New System.Drawing.Size(105, 19)
        Me.RdBtnWorldClockTimeZoneLongName.TabIndex = 0
        Me.RdBtnWorldClockTimeZoneLongName.TabStop = True
        Me.RdBtnWorldClockTimeZoneLongName.Text = "by Long Name"
        Me.RdBtnWorldClockTimeZoneLongName.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.CmbBxWorldKlockTimeZones)
        Me.GroupBox16.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(353, 57)
        Me.GroupBox16.TabIndex = 0
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Time Zones"
        '
        'CmbBxWorldKlockTimeZones
        '
        Me.CmbBxWorldKlockTimeZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxWorldKlockTimeZones.FormattingEnabled = True
        Me.CmbBxWorldKlockTimeZones.Location = New System.Drawing.Point(6, 19)
        Me.CmbBxWorldKlockTimeZones.Name = "CmbBxWorldKlockTimeZones"
        Me.CmbBxWorldKlockTimeZones.Size = New System.Drawing.Size(337, 21)
        Me.CmbBxWorldKlockTimeZones.TabIndex = 0
        '
        'TbPgCountDown
        '
        Me.TbPgCountDown.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgCountDown.Controls.Add(Me.GroupBox5)
        Me.TbPgCountDown.Controls.Add(Me.GroupBox4)
        Me.TbPgCountDown.Controls.Add(Me.GroupBox3)
        Me.TbPgCountDown.Location = New System.Drawing.Point(4, 25)
        Me.TbPgCountDown.Name = "TbPgCountDown"
        Me.TbPgCountDown.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgCountDown.Size = New System.Drawing.Size(671, 131)
        Me.TbPgCountDown.TabIndex = 1
        Me.TbPgCountDown.Text = "CountDown"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ChckBxCountdownScreenSaver)
        Me.GroupBox5.Controls.Add(Me.TxtBxCountdownSpeech)
        Me.GroupBox5.Controls.Add(Me.ChckBxCountdownSpeech)
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
        Me.GroupBox5.Size = New System.Drawing.Size(550, 57)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'ChckBxCountdownScreenSaver
        '
        Me.ChckBxCountdownScreenSaver.AutoSize = True
        Me.ChckBxCountdownScreenSaver.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxCountdownScreenSaver.Name = "ChckBxCountdownScreenSaver"
        Me.ChckBxCountdownScreenSaver.Size = New System.Drawing.Size(99, 19)
        Me.ChckBxCountdownScreenSaver.TabIndex = 15
        Me.ChckBxCountdownScreenSaver.Text = "Screen Saver"
        Me.ChckBxCountdownScreenSaver.UseVisualStyleBackColor = True
        '
        'TxtBxCountdownSpeech
        '
        Me.TxtBxCountdownSpeech.Enabled = False
        Me.TxtBxCountdownSpeech.Location = New System.Drawing.Point(188, 24)
        Me.TxtBxCountdownSpeech.Name = "TxtBxCountdownSpeech"
        Me.TxtBxCountdownSpeech.Size = New System.Drawing.Size(241, 20)
        Me.TxtBxCountdownSpeech.TabIndex = 14
        Me.TxtBxCountdownSpeech.Text = "Finished counting, now Sir!"
        '
        'ChckBxCountdownSpeech
        '
        Me.ChckBxCountdownSpeech.AutoSize = True
        Me.ChckBxCountdownSpeech.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxCountdownSpeech.Name = "ChckBxCountdownSpeech"
        Me.ChckBxCountdownSpeech.Size = New System.Drawing.Size(68, 19)
        Me.ChckBxCountdownSpeech.TabIndex = 13
        Me.ChckBxCountdownSpeech.Text = "Speech"
        Me.ChckBxCountdownSpeech.UseVisualStyleBackColor = True
        '
        'btnCountdownSystemAbort
        '
        Me.btnCountdownSystemAbort.Enabled = False
        Me.btnCountdownSystemAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCountdownSystemAbort.Location = New System.Drawing.Point(444, 24)
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
        Me.TxtBxCountDowndCommand.Size = New System.Drawing.Size(239, 20)
        Me.TxtBxCountDowndCommand.TabIndex = 11
        '
        'btnCountDownLoadCommand
        '
        Me.btnCountDownLoadCommand.Enabled = False
        Me.btnCountDownLoadCommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCountDownLoadCommand.Location = New System.Drawing.Point(444, 24)
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
        Me.btnCountdownLoadSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCountdownLoadSound.Location = New System.Drawing.Point(379, 24)
        Me.btnCountdownLoadSound.Name = "btnCountdownLoadSound"
        Me.btnCountdownLoadSound.Size = New System.Drawing.Size(50, 20)
        Me.btnCountdownLoadSound.TabIndex = 4
        Me.btnCountdownLoadSound.Text = "..."
        Me.btnCountdownLoadSound.UseVisualStyleBackColor = True
        '
        'btnCountDownTestSound
        '
        Me.btnCountDownTestSound.Enabled = False
        Me.btnCountDownTestSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCountDownTestSound.Location = New System.Drawing.Point(444, 24)
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
        Me.TxtBxCountDownAction.Size = New System.Drawing.Size(170, 20)
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
        Me.GroupBox4.Controls.Add(Me.btnCountdown90)
        Me.GroupBox4.Controls.Add(Me.btnCountdown60)
        Me.GroupBox4.Controls.Add(Me.btnCountdown30)
        Me.GroupBox4.Controls.Add(Me.upDwnCntDownValue)
        Me.GroupBox4.Controls.Add(Me.lblCountDownTime)
        Me.GroupBox4.Location = New System.Drawing.Point(115, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(550, 57)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'btnCountdown90
        '
        Me.btnCountdown90.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCountdown90.Location = New System.Drawing.Point(469, 20)
        Me.btnCountdown90.Name = "btnCountdown90"
        Me.btnCountdown90.Size = New System.Drawing.Size(50, 25)
        Me.btnCountdown90.TabIndex = 4
        Me.btnCountdown90.Text = "90"
        Me.btnCountdown90.UseVisualStyleBackColor = True
        '
        'btnCountdown60
        '
        Me.btnCountdown60.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCountdown60.Location = New System.Drawing.Point(413, 20)
        Me.btnCountdown60.Name = "btnCountdown60"
        Me.btnCountdown60.Size = New System.Drawing.Size(50, 25)
        Me.btnCountdown60.TabIndex = 3
        Me.btnCountdown60.Text = "60"
        Me.btnCountdown60.UseVisualStyleBackColor = True
        '
        'btnCountdown30
        '
        Me.btnCountdown30.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCountdown30.Location = New System.Drawing.Point(357, 20)
        Me.btnCountdown30.Name = "btnCountdown30"
        Me.btnCountdown30.Size = New System.Drawing.Size(50, 25)
        Me.btnCountdown30.TabIndex = 2
        Me.btnCountdown30.Text = "30"
        Me.btnCountdown30.UseVisualStyleBackColor = True
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
        Me.TbPgTimer.Location = New System.Drawing.Point(4, 25)
        Me.TbPgTimer.Name = "TbPgTimer"
        Me.TbPgTimer.Size = New System.Drawing.Size(671, 131)
        Me.TbPgTimer.TabIndex = 2
        Me.TbPgTimer.Text = "Timer"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnTimerSplitClear)
        Me.GroupBox8.Controls.Add(Me.lblTimerSplit)
        Me.GroupBox8.Location = New System.Drawing.Point(115, 69)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(553, 57)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        '
        'btnTimerSplitClear
        '
        Me.btnTimerSplitClear.Enabled = False
        Me.btnTimerSplitClear.Location = New System.Drawing.Point(360, 22)
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
        Me.GroupBox7.Size = New System.Drawing.Size(553, 57)
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
        Me.btnTimerSplit.Location = New System.Drawing.Point(360, 19)
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
        Me.TbPgReminder.Location = New System.Drawing.Point(4, 25)
        Me.TbPgReminder.Name = "TbPgReminder"
        Me.TbPgReminder.Size = New System.Drawing.Size(671, 131)
        Me.TbPgReminder.TabIndex = 3
        Me.TbPgReminder.Text = "Reminder"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.ChckBxReminderScreenSaver)
        Me.GroupBox11.Controls.Add(Me.TxtBxReminderSpeech)
        Me.GroupBox11.Controls.Add(Me.ChckBxReminderSpeech)
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
        Me.GroupBox11.Size = New System.Drawing.Size(553, 57)
        Me.GroupBox11.TabIndex = 3
        Me.GroupBox11.TabStop = False
        '
        'ChckBxReminderScreenSaver
        '
        Me.ChckBxReminderScreenSaver.AutoSize = True
        Me.ChckBxReminderScreenSaver.Location = New System.Drawing.Point(101, 23)
        Me.ChckBxReminderScreenSaver.Name = "ChckBxReminderScreenSaver"
        Me.ChckBxReminderScreenSaver.Size = New System.Drawing.Size(99, 19)
        Me.ChckBxReminderScreenSaver.TabIndex = 15
        Me.ChckBxReminderScreenSaver.Text = "Screen Saver"
        Me.ChckBxReminderScreenSaver.UseVisualStyleBackColor = True
        '
        'TxtBxReminderSpeech
        '
        Me.TxtBxReminderSpeech.Enabled = False
        Me.TxtBxReminderSpeech.Location = New System.Drawing.Point(188, 24)
        Me.TxtBxReminderSpeech.Name = "TxtBxReminderSpeech"
        Me.TxtBxReminderSpeech.Size = New System.Drawing.Size(241, 20)
        Me.TxtBxReminderSpeech.TabIndex = 14
        Me.TxtBxReminderSpeech.Text = "Reminding you now, Sir!"
        '
        'ChckBxReminderSpeech
        '
        Me.ChckBxReminderSpeech.AutoSize = True
        Me.ChckBxReminderSpeech.Location = New System.Drawing.Point(100, 23)
        Me.ChckBxReminderSpeech.Name = "ChckBxReminderSpeech"
        Me.ChckBxReminderSpeech.Size = New System.Drawing.Size(68, 19)
        Me.ChckBxReminderSpeech.TabIndex = 13
        Me.ChckBxReminderSpeech.Text = "Speech"
        Me.ChckBxReminderSpeech.UseVisualStyleBackColor = True
        '
        'btnReminderSystemAbort
        '
        Me.btnReminderSystemAbort.Enabled = False
        Me.btnReminderSystemAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReminderSystemAbort.Location = New System.Drawing.Point(444, 24)
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
        Me.TxtBxReminderCommand.Size = New System.Drawing.Size(239, 20)
        Me.TxtBxReminderCommand.TabIndex = 11
        '
        'btnReminderLoadCommand
        '
        Me.btnReminderLoadCommand.Enabled = False
        Me.btnReminderLoadCommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReminderLoadCommand.Location = New System.Drawing.Point(444, 24)
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
        Me.btnReminderLoadSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReminderLoadSound.Location = New System.Drawing.Point(379, 24)
        Me.btnReminderLoadSound.Name = "btnReminderLoadSound"
        Me.btnReminderLoadSound.Size = New System.Drawing.Size(50, 20)
        Me.btnReminderLoadSound.TabIndex = 4
        Me.btnReminderLoadSound.Text = "..."
        Me.btnReminderLoadSound.UseVisualStyleBackColor = True
        '
        'btnReminderTestSound
        '
        Me.btnReminderTestSound.Enabled = False
        Me.btnReminderTestSound.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReminderTestSound.Location = New System.Drawing.Point(444, 24)
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
        Me.TxtBxReminderAction.Size = New System.Drawing.Size(170, 20)
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
        Me.GroupBox10.Size = New System.Drawing.Size(553, 57)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        '
        'ChckBxReminderTimeCheck
        '
        Me.ChckBxReminderTimeCheck.AutoSize = True
        Me.ChckBxReminderTimeCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckBxReminderTimeCheck.Location = New System.Drawing.Point(414, 22)
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
        Me.TmPckrRiminder.Location = New System.Drawing.Point(444, 19)
        Me.TmPckrRiminder.Name = "TmPckrRiminder"
        Me.TmPckrRiminder.ShowUpDown = True
        Me.TmPckrRiminder.Size = New System.Drawing.Size(50, 20)
        Me.TmPckrRiminder.TabIndex = 2
        '
        'DtPckrRiminder
        '
        Me.DtPckrRiminder.CustomFormat = """yyyy-MM-dd HH:mm"""
        Me.DtPckrRiminder.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.DtPckrRiminder.Location = New System.Drawing.Point(273, 19)
        Me.DtPckrRiminder.Name = "DtPckrRiminder"
        Me.DtPckrRiminder.Size = New System.Drawing.Size(124, 20)
        Me.DtPckrRiminder.TabIndex = 1
        '
        'lblReminderText
        '
        Me.lblReminderText.AutoSize = True
        Me.lblReminderText.Font = New System.Drawing.Font("Lucida Calligraphy", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReminderText.Location = New System.Drawing.Point(6, 19)
        Me.lblReminderText.Name = "lblReminderText"
        Me.lblReminderText.Size = New System.Drawing.Size(224, 28)
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
        'TbPgFriends
        '
        Me.TbPgFriends.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgFriends.Controls.Add(Me.GroupBox13)
        Me.TbPgFriends.Controls.Add(Me.GroupBox12)
        Me.TbPgFriends.Location = New System.Drawing.Point(4, 25)
        Me.TbPgFriends.Name = "TbPgFriends"
        Me.TbPgFriends.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgFriends.Size = New System.Drawing.Size(671, 131)
        Me.TbPgFriends.TabIndex = 4
        Me.TbPgFriends.Text = "Friends"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.pnlFriends)
        Me.GroupBox13.Location = New System.Drawing.Point(251, 6)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(413, 122)
        Me.GroupBox13.TabIndex = 1
        Me.GroupBox13.TabStop = False
        '
        'pnlFriends
        '
        Me.pnlFriends.AutoScroll = True
        Me.pnlFriends.Controls.Add(Me.DtPckrFriendsDOB)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsNotes)
        Me.pnlFriends.Controls.Add(Me.Label15)
        Me.pnlFriends.Controls.Add(Me.Label14)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsHomePage)
        Me.pnlFriends.Controls.Add(Me.Label13)
        Me.pnlFriends.Controls.Add(Me.Label12)
        Me.pnlFriends.Controls.Add(Me.Label11)
        Me.pnlFriends.Controls.Add(Me.Label10)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsAddressCounty)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsAddressPostCode)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsAddressCity)
        Me.pnlFriends.Controls.Add(Me.Label9)
        Me.pnlFriends.Controls.Add(Me.Label8)
        Me.pnlFriends.Controls.Add(Me.Label7)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsAddressLine2)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsAddressLine1)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsAddressNo)
        Me.pnlFriends.Controls.Add(Me.Label6)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsTelephone3)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsTelephone2)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsTelephone1)
        Me.pnlFriends.Controls.Add(Me.Label5)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsEmail3)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsEmail2)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsEmail1)
        Me.pnlFriends.Controls.Add(Me.Label4)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsLastName)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsMiddleName)
        Me.pnlFriends.Controls.Add(Me.txtbxFriendsFirstName)
        Me.pnlFriends.Controls.Add(Me.lblFriendsLastName)
        Me.pnlFriends.Controls.Add(Me.lblFriendsMiddleName)
        Me.pnlFriends.Controls.Add(Me.lblFriendsFirstName)
        Me.pnlFriends.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFriends.Location = New System.Drawing.Point(3, 16)
        Me.pnlFriends.Name = "pnlFriends"
        Me.pnlFriends.Size = New System.Drawing.Size(407, 103)
        Me.pnlFriends.TabIndex = 0
        '
        'DtPckrFriendsDOB
        '
        Me.DtPckrFriendsDOB.Checked = False
        Me.DtPckrFriendsDOB.Enabled = False
        Me.DtPckrFriendsDOB.Location = New System.Drawing.Point(85, 275)
        Me.DtPckrFriendsDOB.Name = "DtPckrFriendsDOB"
        Me.DtPckrFriendsDOB.Size = New System.Drawing.Size(179, 20)
        Me.DtPckrFriendsDOB.TabIndex = 29
        '
        'txtbxFriendsNotes
        '
        Me.txtbxFriendsNotes.Location = New System.Drawing.Point(85, 313)
        Me.txtbxFriendsNotes.Multiline = True
        Me.txtbxFriendsNotes.Name = "txtbxFriendsNotes"
        Me.txtbxFriendsNotes.ReadOnly = True
        Me.txtbxFriendsNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtbxFriendsNotes.Size = New System.Drawing.Size(295, 67)
        Me.txtbxFriendsNotes.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(33, 313)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 15)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Notes"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 280)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 15)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Date of Birth"
        '
        'txtbxFriendsHomePage
        '
        Me.txtbxFriendsHomePage.Location = New System.Drawing.Point(85, 246)
        Me.txtbxFriendsHomePage.Name = "txtbxFriendsHomePage"
        Me.txtbxFriendsHomePage.ReadOnly = True
        Me.txtbxFriendsHomePage.Size = New System.Drawing.Size(179, 20)
        Me.txtbxFriendsHomePage.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 15)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Home Page"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(200, 211)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "County"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(181, 189)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Post Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(218, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "City"
        '
        'txtbxFriendsAddressCounty
        '
        Me.txtbxFriendsAddressCounty.Location = New System.Drawing.Point(260, 208)
        Me.txtbxFriendsAddressCounty.Name = "txtbxFriendsAddressCounty"
        Me.txtbxFriendsAddressCounty.ReadOnly = True
        Me.txtbxFriendsAddressCounty.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsAddressCounty.TabIndex = 23
        '
        'txtbxFriendsAddressPostCode
        '
        Me.txtbxFriendsAddressPostCode.Location = New System.Drawing.Point(260, 182)
        Me.txtbxFriendsAddressPostCode.Name = "txtbxFriendsAddressPostCode"
        Me.txtbxFriendsAddressPostCode.ReadOnly = True
        Me.txtbxFriendsAddressPostCode.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsAddressPostCode.TabIndex = 22
        '
        'txtbxFriendsAddressCity
        '
        Me.txtbxFriendsAddressCity.Location = New System.Drawing.Point(260, 156)
        Me.txtbxFriendsAddressCity.Name = "txtbxFriendsAddressCity"
        Me.txtbxFriendsAddressCity.ReadOnly = True
        Me.txtbxFriendsAddressCity.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsAddressCity.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 15)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "No."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Line 1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 15)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Line 2"
        '
        'txtbxFriendsAddressLine2
        '
        Me.txtbxFriendsAddressLine2.Location = New System.Drawing.Point(47, 208)
        Me.txtbxFriendsAddressLine2.Name = "txtbxFriendsAddressLine2"
        Me.txtbxFriendsAddressLine2.ReadOnly = True
        Me.txtbxFriendsAddressLine2.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsAddressLine2.TabIndex = 17
        '
        'txtbxFriendsAddressLine1
        '
        Me.txtbxFriendsAddressLine1.Location = New System.Drawing.Point(47, 182)
        Me.txtbxFriendsAddressLine1.Name = "txtbxFriendsAddressLine1"
        Me.txtbxFriendsAddressLine1.ReadOnly = True
        Me.txtbxFriendsAddressLine1.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsAddressLine1.TabIndex = 16
        '
        'txtbxFriendsAddressNo
        '
        Me.txtbxFriendsAddressNo.Location = New System.Drawing.Point(47, 156)
        Me.txtbxFriendsAddressNo.Name = "txtbxFriendsAddressNo"
        Me.txtbxFriendsAddressNo.ReadOnly = True
        Me.txtbxFriendsAddressNo.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsAddressNo.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Address"
        '
        'txtbxFriendsTelephone3
        '
        Me.txtbxFriendsTelephone3.Location = New System.Drawing.Point(260, 94)
        Me.txtbxFriendsTelephone3.Name = "txtbxFriendsTelephone3"
        Me.txtbxFriendsTelephone3.ReadOnly = True
        Me.txtbxFriendsTelephone3.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsTelephone3.TabIndex = 13
        '
        'txtbxFriendsTelephone2
        '
        Me.txtbxFriendsTelephone2.Location = New System.Drawing.Point(134, 94)
        Me.txtbxFriendsTelephone2.Name = "txtbxFriendsTelephone2"
        Me.txtbxFriendsTelephone2.ReadOnly = True
        Me.txtbxFriendsTelephone2.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsTelephone2.TabIndex = 12
        '
        'txtbxFriendsTelephone1
        '
        Me.txtbxFriendsTelephone1.Location = New System.Drawing.Point(6, 94)
        Me.txtbxFriendsTelephone1.Name = "txtbxFriendsTelephone1"
        Me.txtbxFriendsTelephone1.ReadOnly = True
        Me.txtbxFriendsTelephone1.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsTelephone1.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Telehphone Number"
        '
        'txtbxFriendsEmail3
        '
        Me.txtbxFriendsEmail3.Location = New System.Drawing.Point(260, 55)
        Me.txtbxFriendsEmail3.Name = "txtbxFriendsEmail3"
        Me.txtbxFriendsEmail3.ReadOnly = True
        Me.txtbxFriendsEmail3.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsEmail3.TabIndex = 9
        '
        'txtbxFriendsEmail2
        '
        Me.txtbxFriendsEmail2.Location = New System.Drawing.Point(134, 55)
        Me.txtbxFriendsEmail2.Name = "txtbxFriendsEmail2"
        Me.txtbxFriendsEmail2.ReadOnly = True
        Me.txtbxFriendsEmail2.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsEmail2.TabIndex = 8
        '
        'txtbxFriendsEmail1
        '
        Me.txtbxFriendsEmail1.Location = New System.Drawing.Point(8, 55)
        Me.txtbxFriendsEmail1.Name = "txtbxFriendsEmail1"
        Me.txtbxFriendsEmail1.ReadOnly = True
        Me.txtbxFriendsEmail1.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsEmail1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "E-Mail"
        '
        'txtbxFriendsLastName
        '
        Me.txtbxFriendsLastName.Location = New System.Drawing.Point(260, 18)
        Me.txtbxFriendsLastName.Name = "txtbxFriendsLastName"
        Me.txtbxFriendsLastName.ReadOnly = True
        Me.txtbxFriendsLastName.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsLastName.TabIndex = 5
        '
        'txtbxFriendsMiddleName
        '
        Me.txtbxFriendsMiddleName.Location = New System.Drawing.Point(134, 18)
        Me.txtbxFriendsMiddleName.Name = "txtbxFriendsMiddleName"
        Me.txtbxFriendsMiddleName.ReadOnly = True
        Me.txtbxFriendsMiddleName.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsMiddleName.TabIndex = 4
        '
        'txtbxFriendsFirstName
        '
        Me.txtbxFriendsFirstName.Location = New System.Drawing.Point(8, 18)
        Me.txtbxFriendsFirstName.Name = "txtbxFriendsFirstName"
        Me.txtbxFriendsFirstName.ReadOnly = True
        Me.txtbxFriendsFirstName.Size = New System.Drawing.Size(120, 20)
        Me.txtbxFriendsFirstName.TabIndex = 3
        '
        'lblFriendsLastName
        '
        Me.lblFriendsLastName.AutoSize = True
        Me.lblFriendsLastName.Location = New System.Drawing.Point(257, 0)
        Me.lblFriendsLastName.Name = "lblFriendsLastName"
        Me.lblFriendsLastName.Size = New System.Drawing.Size(67, 15)
        Me.lblFriendsLastName.TabIndex = 2
        Me.lblFriendsLastName.Text = "Last Name"
        '
        'lblFriendsMiddleName
        '
        Me.lblFriendsMiddleName.AutoSize = True
        Me.lblFriendsMiddleName.Location = New System.Drawing.Point(134, 0)
        Me.lblFriendsMiddleName.Name = "lblFriendsMiddleName"
        Me.lblFriendsMiddleName.Size = New System.Drawing.Size(82, 15)
        Me.lblFriendsMiddleName.TabIndex = 1
        Me.lblFriendsMiddleName.Text = "Middle Name"
        '
        'lblFriendsFirstName
        '
        Me.lblFriendsFirstName.AutoSize = True
        Me.lblFriendsFirstName.Location = New System.Drawing.Point(3, 0)
        Me.lblFriendsFirstName.Name = "lblFriendsFirstName"
        Me.lblFriendsFirstName.Size = New System.Drawing.Size(67, 15)
        Me.lblFriendsFirstName.TabIndex = 0
        Me.lblFriendsFirstName.Text = "First Name"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.LstBxFriends)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(239, 122)
        Me.GroupBox12.TabIndex = 0
        Me.GroupBox12.TabStop = False
        '
        'LstBxFriends
        '
        Me.LstBxFriends.Font = New System.Drawing.Font("Lucida Sans Typewriter", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstBxFriends.FormattingEnabled = True
        Me.LstBxFriends.ItemHeight = 12
        Me.LstBxFriends.Location = New System.Drawing.Point(6, 19)
        Me.LstBxFriends.Name = "LstBxFriends"
        Me.LstBxFriends.Size = New System.Drawing.Size(227, 88)
        Me.LstBxFriends.Sorted = True
        Me.LstBxFriends.TabIndex = 0
        '
        'TbPgEvents
        '
        Me.TbPgEvents.Controls.Add(Me.GroupBox20)
        Me.TbPgEvents.Controls.Add(Me.GroupBox19)
        Me.TbPgEvents.Location = New System.Drawing.Point(4, 25)
        Me.TbPgEvents.Name = "TbPgEvents"
        Me.TbPgEvents.Size = New System.Drawing.Size(671, 131)
        Me.TbPgEvents.TabIndex = 6
        Me.TbPgEvents.Text = "Events"
        Me.TbPgEvents.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.pnlEvents)
        Me.GroupBox20.Location = New System.Drawing.Point(251, 6)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(413, 122)
        Me.GroupBox20.TabIndex = 1
        Me.GroupBox20.TabStop = False
        '
        'pnlEvents
        '
        Me.pnlEvents.AutoScroll = True
        Me.pnlEvents.Controls.Add(Me.txtbxEventNotes)
        Me.pnlEvents.Controls.Add(Me.lblEventNotes)
        Me.pnlEvents.Controls.Add(Me.DtTmPckrEventsDate)
        Me.pnlEvents.Controls.Add(Me.lblEventsDate)
        Me.pnlEvents.Controls.Add(Me.lblEventsName)
        Me.pnlEvents.Controls.Add(Me.CmbBxEventTypes)
        Me.pnlEvents.Controls.Add(Me.lblEventsType)
        Me.pnlEvents.Controls.Add(Me.TxtBxEventsName)
        Me.pnlEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEvents.Location = New System.Drawing.Point(3, 16)
        Me.pnlEvents.Name = "pnlEvents"
        Me.pnlEvents.Size = New System.Drawing.Size(407, 103)
        Me.pnlEvents.TabIndex = 0
        '
        'txtbxEventNotes
        '
        Me.txtbxEventNotes.Location = New System.Drawing.Point(17, 69)
        Me.txtbxEventNotes.Multiline = True
        Me.txtbxEventNotes.Name = "txtbxEventNotes"
        Me.txtbxEventNotes.ReadOnly = True
        Me.txtbxEventNotes.Size = New System.Drawing.Size(363, 63)
        Me.txtbxEventNotes.TabIndex = 11
        '
        'lblEventNotes
        '
        Me.lblEventNotes.AutoSize = True
        Me.lblEventNotes.Location = New System.Drawing.Point(14, 45)
        Me.lblEventNotes.Name = "lblEventNotes"
        Me.lblEventNotes.Size = New System.Drawing.Size(72, 15)
        Me.lblEventNotes.TabIndex = 6
        Me.lblEventNotes.Text = "Event Notes"
        '
        'DtTmPckrEventsDate
        '
        Me.DtTmPckrEventsDate.Enabled = False
        Me.DtTmPckrEventsDate.Location = New System.Drawing.Point(134, 18)
        Me.DtTmPckrEventsDate.Name = "DtTmPckrEventsDate"
        Me.DtTmPckrEventsDate.Size = New System.Drawing.Size(119, 20)
        Me.DtTmPckrEventsDate.TabIndex = 5
        '
        'lblEventsDate
        '
        Me.lblEventsDate.AutoSize = True
        Me.lblEventsDate.Location = New System.Drawing.Point(131, 0)
        Me.lblEventsDate.Name = "lblEventsDate"
        Me.lblEventsDate.Size = New System.Drawing.Size(66, 15)
        Me.lblEventsDate.TabIndex = 4
        Me.lblEventsDate.Text = "Event Date"
        '
        'lblEventsName
        '
        Me.lblEventsName.AutoSize = True
        Me.lblEventsName.Location = New System.Drawing.Point(3, 0)
        Me.lblEventsName.Name = "lblEventsName"
        Me.lblEventsName.Size = New System.Drawing.Size(74, 15)
        Me.lblEventsName.TabIndex = 0
        Me.lblEventsName.Text = "Event Name"
        '
        'CmbBxEventTypes
        '
        Me.CmbBxEventTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxEventTypes.Enabled = False
        Me.CmbBxEventTypes.FormattingEnabled = True
        Me.CmbBxEventTypes.Location = New System.Drawing.Point(259, 18)
        Me.CmbBxEventTypes.Name = "CmbBxEventTypes"
        Me.CmbBxEventTypes.Size = New System.Drawing.Size(121, 21)
        Me.CmbBxEventTypes.Sorted = True
        Me.CmbBxEventTypes.TabIndex = 3
        '
        'lblEventsType
        '
        Me.lblEventsType.AutoSize = True
        Me.lblEventsType.Location = New System.Drawing.Point(256, 0)
        Me.lblEventsType.Name = "lblEventsType"
        Me.lblEventsType.Size = New System.Drawing.Size(66, 15)
        Me.lblEventsType.TabIndex = 2
        Me.lblEventsType.Text = "Event Type"
        '
        'TxtBxEventsName
        '
        Me.TxtBxEventsName.Location = New System.Drawing.Point(8, 18)
        Me.TxtBxEventsName.Name = "TxtBxEventsName"
        Me.TxtBxEventsName.ReadOnly = True
        Me.TxtBxEventsName.Size = New System.Drawing.Size(120, 20)
        Me.TxtBxEventsName.TabIndex = 1
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.LstBxEvents)
        Me.GroupBox19.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(239, 122)
        Me.GroupBox19.TabIndex = 0
        Me.GroupBox19.TabStop = False
        '
        'LstBxEvents
        '
        Me.LstBxEvents.Font = New System.Drawing.Font("Lucida Sans Typewriter", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstBxEvents.FormattingEnabled = True
        Me.LstBxEvents.ItemHeight = 12
        Me.LstBxEvents.Location = New System.Drawing.Point(6, 19)
        Me.LstBxEvents.Name = "LstBxEvents"
        Me.LstBxEvents.Size = New System.Drawing.Size(227, 88)
        Me.LstBxEvents.Sorted = True
        Me.LstBxEvents.TabIndex = 0
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(575, 193)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(75, 23)
        Me.btnHide.TabIndex = 3
        Me.btnHide.Text = "Hide"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(491, 193)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(404, 193)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'tmrTimer
        '
        Me.tmrTimer.Interval = 1000
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
        Me.CntxtMnStrpKlock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TlStrpMnItmShow, Me.TlStrpMnItmTime, Me.TlStrpMnItmHelp, Me.TlStrpMnItmOptions, Me.TlStrpMnItmExit})
        Me.CntxtMnStrpKlock.Name = "CntxtMnStrpKlock"
        Me.CntxtMnStrpKlock.Size = New System.Drawing.Size(117, 114)
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
        'TlStrpMnItmHelp
        '
        Me.TlStrpMnItmHelp.Name = "TlStrpMnItmHelp"
        Me.TlStrpMnItmHelp.Size = New System.Drawing.Size(116, 22)
        Me.TlStrpMnItmHelp.Text = "Help"
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
        'tmrReminder
        '
        Me.tmrReminder.Interval = 1000
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(16, 198)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(42, 23)
        Me.btnNew.TabIndex = 6
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(65, 198)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(42, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(114, 198)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(42, 23)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(163, 198)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(42, 23)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(212, 198)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(49, 23)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'tmrEvents
        '
        Me.tmrEvents.Interval = 60000
        '
        'btnEventsCheck
        '
        Me.btnEventsCheck.Enabled = False
        Me.btnEventsCheck.Location = New System.Drawing.Point(267, 198)
        Me.btnEventsCheck.Name = "btnEventsCheck"
        Me.btnEventsCheck.Size = New System.Drawing.Size(49, 23)
        Me.btnEventsCheck.TabIndex = 16
        Me.btnEventsCheck.Text = "Check"
        Me.btnEventsCheck.UseVisualStyleBackColor = True
        '
        'frmKlock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 264)
        Me.Controls.Add(Me.btnEventsCheck)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.StsStrpInfo)
        Me.Controls.Add(Me.MnStrpMain)
        Me.Controls.Add(Me.TbCntrl)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnHide)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnStrpMain
        Me.MaximizeBox = False
        Me.Name = "frmKlock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Klock"
        Me.StsStrpInfo.ResumeLayout(False)
        Me.StsStrpInfo.PerformLayout()
        Me.MnStrpMain.ResumeLayout(False)
        Me.MnStrpMain.PerformLayout()
        Me.TbCntrl.ResumeLayout(False)
        Me.TbPgTime.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TbPgWorldClock.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
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
        Me.TbPgFriends.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.pnlFriends.ResumeLayout(False)
        Me.pnlFriends.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.TbPgEvents.ResumeLayout(False)
        Me.GroupBox20.ResumeLayout(False)
        Me.pnlEvents.ResumeLayout(False)
        Me.pnlEvents.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
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
    Friend WithEvents CmbBxTimeOne As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTimeOneTime As System.Windows.Forms.Label
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
    Friend WithEvents tmrReminder As System.Windows.Forms.Timer
    Friend WithEvents TbPgFriends As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents LstBxFriends As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlFriends As System.Windows.Forms.Panel
    Friend WithEvents txtbxFriendsLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblFriendsLastName As System.Windows.Forms.Label
    Friend WithEvents lblFriendsMiddleName As System.Windows.Forms.Label
    Friend WithEvents lblFriendsFirstName As System.Windows.Forms.Label
    Friend WithEvents txtbxFriendsEmail3 As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbxFriendsNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtbxFriendsHomePage As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtbxFriendsAddressCounty As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsAddressPostCode As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsAddressCity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtbxFriendsAddressLine2 As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsAddressLine1 As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsAddressNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtbxFriendsTelephone3 As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsTelephone2 As System.Windows.Forms.TextBox
    Friend WithEvents txtbxFriendsTelephone1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents DtPckrFriendsDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents LblTimeTwoTime As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBxTimeTwo As System.Windows.Forms.ComboBox
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaylightSavingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CultureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TbPgWorldClock As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBxWorldKlockTimeZones As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents LblWorldKlockWorld As System.Windows.Forms.Label
    Friend WithEvents LblWorldKlockLocal As System.Windows.Forms.Label
    Friend WithEvents RdBtnWorldClockTimeZoneID As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtnWorldClockTimeZoneLongName As System.Windows.Forms.RadioButton
    Friend WithEvents OSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxtBxCountdownSpeech As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxCountdownSpeech As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBxReminderSpeech As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxReminderSpeech As System.Windows.Forms.CheckBox
    Friend WithEvents PowerSourceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCountdown90 As System.Windows.Forms.Button
    Friend WithEvents btnCountdown60 As System.Windows.Forms.Button
    Friend WithEvents btnCountdown30 As System.Windows.Forms.Button
    Friend WithEvents HlpPrvdrKlock As System.Windows.Forms.HelpProvider
    Friend WithEvents TlStrpMnItmHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChckBxCountdownScreenSaver As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxReminderScreenSaver As System.Windows.Forms.CheckBox
    Friend WithEvents TbPgEvents As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents LstBxEvents As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBxEventsName As System.Windows.Forms.TextBox
    Friend WithEvents lblEventsName As System.Windows.Forms.Label
    Friend WithEvents CmbBxEventTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblEventsType As System.Windows.Forms.Label
    Friend WithEvents pnlEvents As System.Windows.Forms.Panel
    Friend WithEvents DtTmPckrEventsDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEventsDate As System.Windows.Forms.Label
    Friend WithEvents lblEventNotes As System.Windows.Forms.Label
    Friend WithEvents txtbxEventNotes As System.Windows.Forms.TextBox
    Friend WithEvents tmrEvents As System.Windows.Forms.Timer
    Friend WithEvents btnEventsCheck As System.Windows.Forms.Button

End Class
