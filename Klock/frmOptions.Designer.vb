<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.btnOptionsClose = New System.Windows.Forms.Button()
        Me.ClrDlgFormColour = New System.Windows.Forms.ColorDialog()
        Me.btnOptionsFormColour = New System.Windows.Forms.Button()
        Me.lblColour = New System.Windows.Forms.Label()
        Me.btnOptionsFormFont = New System.Windows.Forms.Button()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.FntDlgFont = New System.Windows.Forms.FontDialog()
        Me.ChckBxOptionsSavePos = New System.Windows.Forms.CheckBox()
        Me.btnDefaultColour = New System.Windows.Forms.Button()
        Me.lblDefaultColour = New System.Windows.Forms.Label()
        Me.TabCntrlOptions = New System.Windows.Forms.TabControl()
        Me.TbPgGlobal = New System.Windows.Forms.TabPage()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.CmbBxDefaultTab = New System.Windows.Forms.ComboBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSettingsReset = New System.Windows.Forms.Button()
        Me.LblOptionSavepath = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.ChckBxOptionsRunOnStartup = New System.Windows.Forms.CheckBox()
        Me.ChckBxOptionsStartupMinimised = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOptionsTestVolume = New System.Windows.Forms.Button()
        Me.TrckBrOptionsVolume = New System.Windows.Forms.TrackBar()
        Me.TbPgNotification = New System.Windows.Forms.TabPage()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.btnEventNotificationTest = New System.Windows.Forms.Button()
        Me.NmrcUpDwnEventNotificationOpacity = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnEventNotificationFont = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PctrBxNotification = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNotificationTest = New System.Windows.Forms.Button()
        Me.btnNotificationColour = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NmrcUpDwnNotificationOpacity = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNotificationFont = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NmrcUpDwnNotificationTimeOut = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TbPgTime = New System.Windows.Forms.TabPage()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.ChckBxTimeTimeTwo12 = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeTimeOne12 = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeSystem12 = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeTimeTwo24 = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeTimeOne24 = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeSystem24 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chckBxIdleTime = New System.Windows.Forms.CheckBox()
        Me.lblTimeTwo = New System.Windows.Forms.Label()
        Me.CmbBxDefaultTimeTwoFormat = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CmbBxDefaultTimeFormat = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.UpDwnVoiceDisplay = New System.Windows.Forms.NumericUpDown()
        Me.ChckBxOptionsVoice = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeTwoFormats = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeHexIntuitor = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeNetSeconds = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chckBxTimeSwatch = New System.Windows.Forms.CheckBox()
        Me.UpDwnTimeDisplay = New System.Windows.Forms.NumericUpDown()
        Me.ChckBxTimeToast = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChckBxTimeHalfChimes = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeQuarterChimes = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeHourlyChimes = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeHourPips = New System.Windows.Forms.CheckBox()
        Me.TbPgOtherStuff = New System.Windows.Forms.TabPage()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.ChckBxDisableMonitorSleep = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ChckBxReminderAdd = New System.Windows.Forms.CheckBox()
        Me.ChckBxReminderTimeCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChckBxTimerAdd = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimerHigh = New System.Windows.Forms.CheckBox()
        Me.ChckBxClearSplit = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.ChckBxCountdownAdd = New System.Windows.Forms.CheckBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.ChckBxWorldKlockAdd = New System.Windows.Forms.CheckBox()
        Me.TbPgArchive = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.TxtBxArchiveFile = New System.Windows.Forms.TextBox()
        Me.TxtBxArchiveDirectory = New System.Windows.Forms.TextBox()
        Me.btnArchiveFile = New System.Windows.Forms.Button()
        Me.btnArchiveDirectory = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TxtBxOptionsSettingsFile = New System.Windows.Forms.TextBox()
        Me.TxtBxOptionsMemoFile = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnOptionsMemoFile = New System.Windows.Forms.Button()
        Me.label18 = New System.Windows.Forms.Label()
        Me.btnOptionsEventsFile = New System.Windows.Forms.Button()
        Me.TxtBxOptionsEventsFile = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOptionsPathReset = New System.Windows.Forms.Button()
        Me.btnOptionsFriendsFile = New System.Windows.Forms.Button()
        Me.TxtBxOptionsFriendsFile = New System.Windows.Forms.TextBox()
        Me.btnOptionsFriendsDirectory = New System.Windows.Forms.Button()
        Me.TxtBxOptionsFriendsDirectory = New System.Windows.Forms.TextBox()
        Me.TbPgEvents = New System.Windows.Forms.TabPage()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.PctrBxThirdEvent = New System.Windows.Forms.PictureBox()
        Me.btnThirdEventNotificationColour = New System.Windows.Forms.Button()
        Me.PctrBxSecondEvent = New System.Windows.Forms.PictureBox()
        Me.btnSecondEventNotificationColour = New System.Windows.Forms.Button()
        Me.PctrBxFirstEvent = New System.Windows.Forms.PictureBox()
        Me.btnFirstEventNotificationColour = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblEventsInterval = New System.Windows.Forms.Label()
        Me.NmrcUpDwnEventsInterval = New System.Windows.Forms.NumericUpDown()
        Me.NmrcUpDwnThirdReminder = New System.Windows.Forms.NumericUpDown()
        Me.NmrcUpDwnSecondReminder = New System.Windows.Forms.NumericUpDown()
        Me.NmrcUpDwnFirstReminder = New System.Windows.Forms.NumericUpDown()
        Me.lblThirdReminder = New System.Windows.Forms.Label()
        Me.lblSecondReminder = New System.Windows.Forms.Label()
        Me.lblFirstreminder = New System.Windows.Forms.Label()
        Me.TbPgMemo = New System.Windows.Forms.TabPage()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.NmrcUpDwnMemoDecrypt = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtBxMemoDefaultPassword = New System.Windows.Forms.TextBox()
        Me.ChckBxMemoDefaultPassword = New System.Windows.Forms.CheckBox()
        Me.btnArchiveLoad = New System.Windows.Forms.Button()
        Me.btnArchiveSave = New System.Windows.Forms.Button()
        Me.btnOptionsCancel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabCntrlOptions.SuspendLayout()
        Me.TbPgGlobal.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrckBrOptionsVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgNotification.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.NmrcUpDwnEventNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PctrBxNotification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgTime.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.UpDwnVoiceDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDwnTimeDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TbPgOtherStuff.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TbPgArchive.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TbPgEvents.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.PctrBxThirdEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PctrBxSecondEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PctrBxFirstEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnEventsInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnThirdReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnSecondReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnFirstReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgMemo.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        CType(Me.NmrcUpDwnMemoDecrypt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOptionsClose
        '
        Me.btnOptionsClose.Location = New System.Drawing.Point(579, 312)
        Me.btnOptionsClose.Name = "btnOptionsClose"
        Me.btnOptionsClose.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsClose.TabIndex = 0
        Me.btnOptionsClose.Text = "OK"
        Me.btnOptionsClose.UseVisualStyleBackColor = True
        '
        'btnOptionsFormColour
        '
        Me.btnOptionsFormColour.Enabled = False
        Me.btnOptionsFormColour.Location = New System.Drawing.Point(141, 12)
        Me.btnOptionsFormColour.Name = "btnOptionsFormColour"
        Me.btnOptionsFormColour.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFormColour.TabIndex = 1
        Me.btnOptionsFormColour.Text = "..."
        Me.btnOptionsFormColour.UseVisualStyleBackColor = True
        '
        'lblColour
        '
        Me.lblColour.AutoSize = True
        Me.lblColour.Enabled = False
        Me.lblColour.Location = New System.Drawing.Point(6, 22)
        Me.lblColour.Name = "lblColour"
        Me.lblColour.Size = New System.Drawing.Size(129, 13)
        Me.lblColour.TabIndex = 2
        Me.lblColour.Text = "Change Form Main Colour"
        '
        'btnOptionsFormFont
        '
        Me.btnOptionsFormFont.Enabled = False
        Me.btnOptionsFormFont.Location = New System.Drawing.Point(141, 41)
        Me.btnOptionsFormFont.Name = "btnOptionsFormFont"
        Me.btnOptionsFormFont.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFormFont.TabIndex = 3
        Me.btnOptionsFormFont.Text = "..."
        Me.btnOptionsFormFont.UseVisualStyleBackColor = True
        '
        'lblFont
        '
        Me.lblFont.AutoSize = True
        Me.lblFont.Enabled = False
        Me.lblFont.Location = New System.Drawing.Point(15, 46)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(120, 13)
        Me.lblFont.TabIndex = 4
        Me.lblFont.Text = "Change Form Main Font"
        '
        'FntDlgFont
        '
        Me.FntDlgFont.ShowColor = True
        '
        'ChckBxOptionsSavePos
        '
        Me.ChckBxOptionsSavePos.AutoSize = True
        Me.ChckBxOptionsSavePos.Location = New System.Drawing.Point(45, 31)
        Me.ChckBxOptionsSavePos.Name = "ChckBxOptionsSavePos"
        Me.ChckBxOptionsSavePos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxOptionsSavePos.Size = New System.Drawing.Size(163, 17)
        Me.ChckBxOptionsSavePos.TabIndex = 5
        Me.ChckBxOptionsSavePos.Text = "Save Screen Position on Exit"
        Me.ChckBxOptionsSavePos.UseVisualStyleBackColor = True
        '
        'btnDefaultColour
        '
        Me.btnDefaultColour.Location = New System.Drawing.Point(141, 70)
        Me.btnDefaultColour.Name = "btnDefaultColour"
        Me.btnDefaultColour.Size = New System.Drawing.Size(75, 23)
        Me.btnDefaultColour.TabIndex = 6
        Me.btnDefaultColour.Text = "Reset"
        Me.btnDefaultColour.UseVisualStyleBackColor = True
        '
        'lblDefaultColour
        '
        Me.lblDefaultColour.AutoSize = True
        Me.lblDefaultColour.Enabled = False
        Me.lblDefaultColour.Location = New System.Drawing.Point(15, 75)
        Me.lblDefaultColour.Name = "lblDefaultColour"
        Me.lblDefaultColour.Size = New System.Drawing.Size(120, 13)
        Me.lblDefaultColour.TabIndex = 7
        Me.lblDefaultColour.Text = "Reset to default Colours"
        '
        'TabCntrlOptions
        '
        Me.TabCntrlOptions.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabCntrlOptions.Controls.Add(Me.TbPgGlobal)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgNotification)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgTime)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgOtherStuff)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgArchive)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgEvents)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgMemo)
        Me.TabCntrlOptions.Location = New System.Drawing.Point(12, 12)
        Me.TabCntrlOptions.Multiline = True
        Me.TabCntrlOptions.Name = "TabCntrlOptions"
        Me.TabCntrlOptions.SelectedIndex = 0
        Me.TabCntrlOptions.Size = New System.Drawing.Size(668, 294)
        Me.TabCntrlOptions.TabIndex = 8
        '
        'TbPgGlobal
        '
        Me.TbPgGlobal.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgGlobal.Controls.Add(Me.GroupBox17)
        Me.TbPgGlobal.Controls.Add(Me.GroupBox13)
        Me.TbPgGlobal.Controls.Add(Me.GroupBox8)
        Me.TbPgGlobal.Controls.Add(Me.GroupBox7)
        Me.TbPgGlobal.Controls.Add(Me.GroupBox2)
        Me.TbPgGlobal.Location = New System.Drawing.Point(4, 25)
        Me.TbPgGlobal.Name = "TbPgGlobal"
        Me.TbPgGlobal.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgGlobal.Size = New System.Drawing.Size(660, 265)
        Me.TbPgGlobal.TabIndex = 0
        Me.TbPgGlobal.Text = "Global"
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.CmbBxDefaultTab)
        Me.GroupBox17.Location = New System.Drawing.Point(280, 8)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(143, 97)
        Me.GroupBox17.TabIndex = 14
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Default Tab"
        '
        'CmbBxDefaultTab
        '
        Me.CmbBxDefaultTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxDefaultTab.FormattingEnabled = True
        Me.CmbBxDefaultTab.Location = New System.Drawing.Point(14, 39)
        Me.CmbBxDefaultTab.Name = "CmbBxDefaultTab"
        Me.CmbBxDefaultTab.Size = New System.Drawing.Size(121, 21)
        Me.CmbBxDefaultTab.TabIndex = 0
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label10)
        Me.GroupBox13.Controls.Add(Me.btnSettingsReset)
        Me.GroupBox13.Controls.Add(Me.LblOptionSavepath)
        Me.GroupBox13.Controls.Add(Me.Label9)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(268, 97)
        Me.GroupBox13.TabIndex = 13
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Settings"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Reset to system to default settings"
        '
        'btnSettingsReset
        '
        Me.btnSettingsReset.Location = New System.Drawing.Point(184, 63)
        Me.btnSettingsReset.Name = "btnSettingsReset"
        Me.btnSettingsReset.Size = New System.Drawing.Size(75, 23)
        Me.btnSettingsReset.TabIndex = 12
        Me.btnSettingsReset.Text = "Reset"
        Me.btnSettingsReset.UseVisualStyleBackColor = True
        '
        'LblOptionSavepath
        '
        Me.LblOptionSavepath.AutoSize = True
        Me.LblOptionSavepath.Location = New System.Drawing.Point(10, 44)
        Me.LblOptionSavepath.Name = "LblOptionSavepath"
        Me.LblOptionSavepath.Size = New System.Drawing.Size(31, 13)
        Me.LblOptionSavepath.TabIndex = 10
        Me.LblOptionSavepath.Text = """c:\"""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "User settings save in"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.ChckBxOptionsRunOnStartup)
        Me.GroupBox8.Controls.Add(Me.ChckBxOptionsSavePos)
        Me.GroupBox8.Controls.Add(Me.ChckBxOptionsStartupMinimised)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 111)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(648, 68)
        Me.GroupBox8.TabIndex = 12
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Behaviour"
        '
        'ChckBxOptionsRunOnStartup
        '
        Me.ChckBxOptionsRunOnStartup.AutoSize = True
        Me.ChckBxOptionsRunOnStartup.Location = New System.Drawing.Point(268, 31)
        Me.ChckBxOptionsRunOnStartup.Name = "ChckBxOptionsRunOnStartup"
        Me.ChckBxOptionsRunOnStartup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxOptionsRunOnStartup.Size = New System.Drawing.Size(175, 17)
        Me.ChckBxOptionsRunOnStartup.TabIndex = 9
        Me.ChckBxOptionsRunOnStartup.Text = "Run Klock on Windows Startup"
        Me.ChckBxOptionsRunOnStartup.UseVisualStyleBackColor = True
        '
        'ChckBxOptionsStartupMinimised
        '
        Me.ChckBxOptionsStartupMinimised.AutoSize = True
        Me.ChckBxOptionsStartupMinimised.Location = New System.Drawing.Point(505, 31)
        Me.ChckBxOptionsStartupMinimised.Name = "ChckBxOptionsStartupMinimised"
        Me.ChckBxOptionsStartupMinimised.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxOptionsStartupMinimised.Size = New System.Drawing.Size(127, 17)
        Me.ChckBxOptionsStartupMinimised.TabIndex = 10
        Me.ChckBxOptionsStartupMinimised.Text = "Start Klock Minimised"
        Me.ChckBxOptionsStartupMinimised.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnOptionsFormColour)
        Me.GroupBox7.Controls.Add(Me.btnOptionsFormFont)
        Me.GroupBox7.Controls.Add(Me.btnDefaultColour)
        Me.GroupBox7.Controls.Add(Me.lblColour)
        Me.GroupBox7.Controls.Add(Me.lblFont)
        Me.GroupBox7.Controls.Add(Me.lblDefaultColour)
        Me.GroupBox7.Location = New System.Drawing.Point(429, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(225, 99)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Apperance [Not Implemented]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOptionsTestVolume)
        Me.GroupBox2.Controls.Add(Me.TrckBrOptionsVolume)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(648, 68)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Volume"
        '
        'btnOptionsTestVolume
        '
        Me.btnOptionsTestVolume.Location = New System.Drawing.Point(459, 19)
        Me.btnOptionsTestVolume.Name = "btnOptionsTestVolume"
        Me.btnOptionsTestVolume.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsTestVolume.TabIndex = 1
        Me.btnOptionsTestVolume.Text = "Test"
        Me.btnOptionsTestVolume.UseVisualStyleBackColor = True
        '
        'TrckBrOptionsVolume
        '
        Me.TrckBrOptionsVolume.LargeChange = 1
        Me.TrckBrOptionsVolume.Location = New System.Drawing.Point(13, 17)
        Me.TrckBrOptionsVolume.Name = "TrckBrOptionsVolume"
        Me.TrckBrOptionsVolume.Size = New System.Drawing.Size(396, 45)
        Me.TrckBrOptionsVolume.TabIndex = 0
        Me.TrckBrOptionsVolume.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'TbPgNotification
        '
        Me.TbPgNotification.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgNotification.Controls.Add(Me.GroupBox15)
        Me.TbPgNotification.Controls.Add(Me.GroupBox6)
        Me.TbPgNotification.Location = New System.Drawing.Point(4, 25)
        Me.TbPgNotification.Name = "TbPgNotification"
        Me.TbPgNotification.Size = New System.Drawing.Size(660, 265)
        Me.TbPgNotification.TabIndex = 3
        Me.TbPgNotification.Text = "Notification"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.btnEventNotificationTest)
        Me.GroupBox15.Controls.Add(Me.NmrcUpDwnEventNotificationOpacity)
        Me.GroupBox15.Controls.Add(Me.Label20)
        Me.GroupBox15.Controls.Add(Me.btnEventNotificationFont)
        Me.GroupBox15.Controls.Add(Me.Label19)
        Me.GroupBox15.Location = New System.Drawing.Point(330, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(320, 253)
        Me.GroupBox15.TabIndex = 10
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Event Notification Appearance"
        '
        'btnEventNotificationTest
        '
        Me.btnEventNotificationTest.Location = New System.Drawing.Point(144, 172)
        Me.btnEventNotificationTest.Name = "btnEventNotificationTest"
        Me.btnEventNotificationTest.Size = New System.Drawing.Size(50, 23)
        Me.btnEventNotificationTest.TabIndex = 6
        Me.btnEventNotificationTest.Text = "Test"
        Me.btnEventNotificationTest.UseVisualStyleBackColor = True
        '
        'NmrcUpDwnEventNotificationOpacity
        '
        Me.NmrcUpDwnEventNotificationOpacity.Location = New System.Drawing.Point(144, 122)
        Me.NmrcUpDwnEventNotificationOpacity.Name = "NmrcUpDwnEventNotificationOpacity"
        Me.NmrcUpDwnEventNotificationOpacity.Size = New System.Drawing.Size(50, 20)
        Me.NmrcUpDwnEventNotificationOpacity.TabIndex = 5
        Me.NmrcUpDwnEventNotificationOpacity.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(17, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Notification Opacity"
        '
        'btnEventNotificationFont
        '
        Me.btnEventNotificationFont.Location = New System.Drawing.Point(144, 48)
        Me.btnEventNotificationFont.Name = "btnEventNotificationFont"
        Me.btnEventNotificationFont.Size = New System.Drawing.Size(50, 23)
        Me.btnEventNotificationFont.TabIndex = 3
        Me.btnEventNotificationFont.Text = "..."
        Me.btnEventNotificationFont.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Notification Font"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PctrBxNotification)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.btnNotificationTest)
        Me.GroupBox6.Controls.Add(Me.btnNotificationColour)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.NmrcUpDwnNotificationOpacity)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.btnNotificationFont)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.NmrcUpDwnNotificationTimeOut)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(320, 253)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "General Notification Appearance"
        '
        'PctrBxNotification
        '
        Me.PctrBxNotification.Location = New System.Drawing.Point(215, 19)
        Me.PctrBxNotification.Name = "PctrBxNotification"
        Me.PctrBxNotification.Size = New System.Drawing.Size(50, 23)
        Me.PctrBxNotification.TabIndex = 9
        Me.PctrBxNotification.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Notification Back Colour"
        '
        'btnNotificationTest
        '
        Me.btnNotificationTest.Location = New System.Drawing.Point(144, 172)
        Me.btnNotificationTest.Name = "btnNotificationTest"
        Me.btnNotificationTest.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationTest.TabIndex = 8
        Me.btnNotificationTest.Text = "Test"
        Me.btnNotificationTest.UseVisualStyleBackColor = True
        '
        'btnNotificationColour
        '
        Me.btnNotificationColour.Location = New System.Drawing.Point(144, 19)
        Me.btnNotificationColour.Name = "btnNotificationColour"
        Me.btnNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationColour.TabIndex = 2
        Me.btnNotificationColour.Text = "..."
        Me.btnNotificationColour.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Notification Opacity"
        '
        'NmrcUpDwnNotificationOpacity
        '
        Me.NmrcUpDwnNotificationOpacity.Location = New System.Drawing.Point(144, 122)
        Me.NmrcUpDwnNotificationOpacity.Name = "NmrcUpDwnNotificationOpacity"
        Me.NmrcUpDwnNotificationOpacity.Size = New System.Drawing.Size(50, 20)
        Me.NmrcUpDwnNotificationOpacity.TabIndex = 7
        Me.NmrcUpDwnNotificationOpacity.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Notification Font"
        '
        'btnNotificationFont
        '
        Me.btnNotificationFont.Location = New System.Drawing.Point(144, 48)
        Me.btnNotificationFont.Name = "btnNotificationFont"
        Me.btnNotificationFont.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationFont.TabIndex = 3
        Me.btnNotificationFont.Text = "..."
        Me.btnNotificationFont.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Notification Time Out"
        '
        'NmrcUpDwnNotificationTimeOut
        '
        Me.NmrcUpDwnNotificationTimeOut.Location = New System.Drawing.Point(144, 96)
        Me.NmrcUpDwnNotificationTimeOut.Name = "NmrcUpDwnNotificationTimeOut"
        Me.NmrcUpDwnNotificationTimeOut.Size = New System.Drawing.Size(50, 20)
        Me.NmrcUpDwnNotificationTimeOut.TabIndex = 0
        Me.NmrcUpDwnNotificationTimeOut.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Seconds"
        '
        'TbPgTime
        '
        Me.TbPgTime.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTime.Controls.Add(Me.GroupBox18)
        Me.TbPgTime.Controls.Add(Me.GroupBox3)
        Me.TbPgTime.Controls.Add(Me.GroupBox1)
        Me.TbPgTime.Location = New System.Drawing.Point(4, 25)
        Me.TbPgTime.Name = "TbPgTime"
        Me.TbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgTime.Size = New System.Drawing.Size(660, 265)
        Me.TbPgTime.TabIndex = 1
        Me.TbPgTime.Text = "Time"
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.ChckBxTimeTimeTwo12)
        Me.GroupBox18.Controls.Add(Me.ChckBxTimeTimeOne12)
        Me.GroupBox18.Controls.Add(Me.ChckBxTimeSystem12)
        Me.GroupBox18.Controls.Add(Me.ChckBxTimeTimeTwo24)
        Me.GroupBox18.Controls.Add(Me.ChckBxTimeTimeOne24)
        Me.GroupBox18.Controls.Add(Me.ChckBxTimeSystem24)
        Me.GroupBox18.Location = New System.Drawing.Point(322, 165)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(332, 88)
        Me.GroupBox18.TabIndex = 6
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "12 / 24 Hour"
        '
        'ChckBxTimeTimeTwo12
        '
        Me.ChckBxTimeTimeTwo12.AutoSize = True
        Me.ChckBxTimeTimeTwo12.Location = New System.Drawing.Point(190, 65)
        Me.ChckBxTimeTimeTwo12.Name = "ChckBxTimeTimeTwo12"
        Me.ChckBxTimeTimeTwo12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChckBxTimeTimeTwo12.Size = New System.Drawing.Size(64, 17)
        Me.ChckBxTimeTimeTwo12.TabIndex = 5
        Me.ChckBxTimeTimeTwo12.Text = "12 Hour"
        Me.ChckBxTimeTimeTwo12.UseVisualStyleBackColor = True
        '
        'ChckBxTimeTimeOne12
        '
        Me.ChckBxTimeTimeOne12.AutoSize = True
        Me.ChckBxTimeTimeOne12.Location = New System.Drawing.Point(190, 42)
        Me.ChckBxTimeTimeOne12.Name = "ChckBxTimeTimeOne12"
        Me.ChckBxTimeTimeOne12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChckBxTimeTimeOne12.Size = New System.Drawing.Size(64, 17)
        Me.ChckBxTimeTimeOne12.TabIndex = 4
        Me.ChckBxTimeTimeOne12.Text = "12 Hour"
        Me.ChckBxTimeTimeOne12.UseVisualStyleBackColor = True
        '
        'ChckBxTimeSystem12
        '
        Me.ChckBxTimeSystem12.AutoSize = True
        Me.ChckBxTimeSystem12.Location = New System.Drawing.Point(190, 19)
        Me.ChckBxTimeSystem12.Name = "ChckBxTimeSystem12"
        Me.ChckBxTimeSystem12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChckBxTimeSystem12.Size = New System.Drawing.Size(64, 17)
        Me.ChckBxTimeSystem12.TabIndex = 3
        Me.ChckBxTimeSystem12.Text = "12 Hour"
        Me.ChckBxTimeSystem12.UseVisualStyleBackColor = True
        '
        'ChckBxTimeTimeTwo24
        '
        Me.ChckBxTimeTimeTwo24.AutoSize = True
        Me.ChckBxTimeTimeTwo24.Location = New System.Drawing.Point(57, 65)
        Me.ChckBxTimeTimeTwo24.Name = "ChckBxTimeTimeTwo24"
        Me.ChckBxTimeTimeTwo24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeTimeTwo24.Size = New System.Drawing.Size(117, 17)
        Me.ChckBxTimeTimeTwo24.TabIndex = 2
        Me.ChckBxTimeTimeTwo24.Text = "Time Two  24 Hour"
        Me.ChckBxTimeTimeTwo24.UseVisualStyleBackColor = True
        '
        'ChckBxTimeTimeOne24
        '
        Me.ChckBxTimeTimeOne24.AutoSize = True
        Me.ChckBxTimeTimeOne24.Location = New System.Drawing.Point(58, 42)
        Me.ChckBxTimeTimeOne24.Name = "ChckBxTimeTimeOne24"
        Me.ChckBxTimeTimeOne24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeTimeOne24.Size = New System.Drawing.Size(116, 17)
        Me.ChckBxTimeTimeOne24.TabIndex = 1
        Me.ChckBxTimeTimeOne24.Text = "Time One  24 Hour"
        Me.ChckBxTimeTimeOne24.UseVisualStyleBackColor = True
        '
        'ChckBxTimeSystem24
        '
        Me.ChckBxTimeSystem24.AutoSize = True
        Me.ChckBxTimeSystem24.Location = New System.Drawing.Point(20, 19)
        Me.ChckBxTimeSystem24.Name = "ChckBxTimeSystem24"
        Me.ChckBxTimeSystem24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeSystem24.Size = New System.Drawing.Size(154, 17)
        Me.ChckBxTimeSystem24.TabIndex = 0
        Me.ChckBxTimeSystem24.Text = "System Tray Time  24 Hour"
        Me.ChckBxTimeSystem24.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chckBxIdleTime)
        Me.GroupBox3.Controls.Add(Me.lblTimeTwo)
        Me.GroupBox3.Controls.Add(Me.CmbBxDefaultTimeTwoFormat)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.CmbBxDefaultTimeFormat)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.UpDwnVoiceDisplay)
        Me.GroupBox3.Controls.Add(Me.ChckBxOptionsVoice)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeTwoFormats)
        Me.GroupBox3.Controls.Add(Me.ChckBxTimeHexIntuitor)
        Me.GroupBox3.Controls.Add(Me.ChckBxTimeNetSeconds)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeSwatch)
        Me.GroupBox3.Controls.Add(Me.UpDwnTimeDisplay)
        Me.GroupBox3.Controls.Add(Me.ChckBxTimeToast)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(648, 153)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Settings"
        '
        'chckBxIdleTime
        '
        Me.chckBxIdleTime.AutoSize = True
        Me.chckBxIdleTime.Location = New System.Drawing.Point(193, 45)
        Me.chckBxIdleTime.Name = "chckBxIdleTime"
        Me.chckBxIdleTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxIdleTime.Size = New System.Drawing.Size(106, 17)
        Me.chckBxIdleTime.TabIndex = 16
        Me.chckBxIdleTime.Text = "Display Idle Time"
        Me.chckBxIdleTime.UseVisualStyleBackColor = True
        '
        'lblTimeTwo
        '
        Me.lblTimeTwo.AutoSize = True
        Me.lblTimeTwo.Enabled = False
        Me.lblTimeTwo.Location = New System.Drawing.Point(408, 49)
        Me.lblTimeTwo.Name = "lblTimeTwo"
        Me.lblTimeTwo.Size = New System.Drawing.Size(126, 13)
        Me.lblTimeTwo.TabIndex = 15
        Me.lblTimeTwo.Text = "Default Two Time Format"
        '
        'CmbBxDefaultTimeTwoFormat
        '
        Me.CmbBxDefaultTimeTwoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxDefaultTimeTwoFormat.Enabled = False
        Me.CmbBxDefaultTimeTwoFormat.FormattingEnabled = True
        Me.CmbBxDefaultTimeTwoFormat.Location = New System.Drawing.Point(540, 41)
        Me.CmbBxDefaultTimeTwoFormat.Name = "CmbBxDefaultTimeTwoFormat"
        Me.CmbBxDefaultTimeTwoFormat.Size = New System.Drawing.Size(86, 21)
        Me.CmbBxDefaultTimeTwoFormat.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(429, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(102, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Default Time Format"
        '
        'CmbBxDefaultTimeFormat
        '
        Me.CmbBxDefaultTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxDefaultTimeFormat.FormattingEnabled = True
        Me.CmbBxDefaultTimeFormat.Location = New System.Drawing.Point(540, 14)
        Me.CmbBxDefaultTimeFormat.Name = "CmbBxDefaultTimeFormat"
        Me.CmbBxDefaultTimeFormat.Size = New System.Drawing.Size(86, 21)
        Me.CmbBxDefaultTimeFormat.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(81, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Time to speech [every "
        '
        'UpDwnVoiceDisplay
        '
        Me.UpDwnVoiceDisplay.Location = New System.Drawing.Point(202, 112)
        Me.UpDwnVoiceDisplay.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.UpDwnVoiceDisplay.Name = "UpDwnVoiceDisplay"
        Me.UpDwnVoiceDisplay.Size = New System.Drawing.Size(38, 20)
        Me.UpDwnVoiceDisplay.TabIndex = 10
        Me.UpDwnVoiceDisplay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'ChckBxOptionsVoice
        '
        Me.ChckBxOptionsVoice.AutoSize = True
        Me.ChckBxOptionsVoice.Location = New System.Drawing.Point(249, 115)
        Me.ChckBxOptionsVoice.Name = "ChckBxOptionsVoice"
        Me.ChckBxOptionsVoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxOptionsVoice.Size = New System.Drawing.Size(50, 17)
        Me.ChckBxOptionsVoice.TabIndex = 9
        Me.ChckBxOptionsVoice.Text = "[mins"
        Me.ChckBxOptionsVoice.UseVisualStyleBackColor = True
        '
        'chckBxTimeTwoFormats
        '
        Me.chckBxTimeTwoFormats.AutoSize = True
        Me.chckBxTimeTwoFormats.Location = New System.Drawing.Point(149, 22)
        Me.chckBxTimeTwoFormats.Name = "chckBxTimeTwoFormats"
        Me.chckBxTimeTwoFormats.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeTwoFormats.Size = New System.Drawing.Size(150, 17)
        Me.chckBxTimeTwoFormats.TabIndex = 8
        Me.chckBxTimeTwoFormats.Text = "Display Two Time Formats"
        Me.chckBxTimeTwoFormats.UseVisualStyleBackColor = True
        '
        'ChckBxTimeHexIntuitor
        '
        Me.ChckBxTimeHexIntuitor.AutoSize = True
        Me.ChckBxTimeHexIntuitor.Location = New System.Drawing.Point(336, 107)
        Me.ChckBxTimeHexIntuitor.Name = "ChckBxTimeHexIntuitor"
        Me.ChckBxTimeHexIntuitor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeHexIntuitor.Size = New System.Drawing.Size(290, 17)
        Me.ChckBxTimeHexIntuitor.TabIndex = 7
        Me.ChckBxTimeHexIntuitor.Text = "Use Intuitor-hextime formatting i.e. Underscore seperator"
        Me.ChckBxTimeHexIntuitor.UseVisualStyleBackColor = True
        '
        'ChckBxTimeNetSeconds
        '
        Me.ChckBxTimeNetSeconds.AutoSize = True
        Me.ChckBxTimeNetSeconds.Location = New System.Drawing.Point(432, 84)
        Me.ChckBxTimeNetSeconds.Name = "ChckBxTimeNetSeconds"
        Me.ChckBxTimeNetSeconds.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeNetSeconds.Size = New System.Drawing.Size(194, 17)
        Me.ChckBxTimeNetSeconds.TabIndex = 1
        Me.ChckBxTimeNetSeconds.Text = "New Earth Time to display Seconds"
        Me.ChckBxTimeNetSeconds.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Display Time in System Tray [every "
        '
        'chckBxTimeSwatch
        '
        Me.chckBxTimeSwatch.AutoSize = True
        Me.chckBxTimeSwatch.Location = New System.Drawing.Point(438, 130)
        Me.chckBxTimeSwatch.Name = "chckBxTimeSwatch"
        Me.chckBxTimeSwatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeSwatch.Size = New System.Drawing.Size(188, 17)
        Me.chckBxTimeSwatch.TabIndex = 0
        Me.chckBxTimeSwatch.Text = "Swatch Time to display Centibeats"
        Me.chckBxTimeSwatch.UseVisualStyleBackColor = True
        '
        'UpDwnTimeDisplay
        '
        Me.UpDwnTimeDisplay.Location = New System.Drawing.Point(202, 86)
        Me.UpDwnTimeDisplay.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.UpDwnTimeDisplay.Name = "UpDwnTimeDisplay"
        Me.UpDwnTimeDisplay.Size = New System.Drawing.Size(38, 20)
        Me.UpDwnTimeDisplay.TabIndex = 6
        Me.UpDwnTimeDisplay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'ChckBxTimeToast
        '
        Me.ChckBxTimeToast.AutoSize = True
        Me.ChckBxTimeToast.Checked = True
        Me.ChckBxTimeToast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChckBxTimeToast.Location = New System.Drawing.Point(249, 87)
        Me.ChckBxTimeToast.Name = "ChckBxTimeToast"
        Me.ChckBxTimeToast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeToast.Size = New System.Drawing.Size(50, 17)
        Me.ChckBxTimeToast.TabIndex = 3
        Me.ChckBxTimeToast.Text = "[mins"
        Me.ChckBxTimeToast.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHalfChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeQuarterChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHourlyChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHourPips)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 88)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chimes"
        '
        'ChckBxTimeHalfChimes
        '
        Me.ChckBxTimeHalfChimes.AutoSize = True
        Me.ChckBxTimeHalfChimes.Location = New System.Drawing.Point(191, 42)
        Me.ChckBxTimeHalfChimes.Name = "ChckBxTimeHalfChimes"
        Me.ChckBxTimeHalfChimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeHalfChimes.Size = New System.Drawing.Size(108, 17)
        Me.ChckBxTimeHalfChimes.TabIndex = 5
        Me.ChckBxTimeHalfChimes.Text = "Half Hour Chimes"
        Me.ChckBxTimeHalfChimes.UseVisualStyleBackColor = True
        '
        'ChckBxTimeQuarterChimes
        '
        Me.ChckBxTimeQuarterChimes.AutoSize = True
        Me.ChckBxTimeQuarterChimes.Location = New System.Drawing.Point(175, 65)
        Me.ChckBxTimeQuarterChimes.Name = "ChckBxTimeQuarterChimes"
        Me.ChckBxTimeQuarterChimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeQuarterChimes.Size = New System.Drawing.Size(124, 17)
        Me.ChckBxTimeQuarterChimes.TabIndex = 4
        Me.ChckBxTimeQuarterChimes.Text = "Quarter Hour Chimes"
        Me.ChckBxTimeQuarterChimes.UseVisualStyleBackColor = True
        '
        'ChckBxTimeHourlyChimes
        '
        Me.ChckBxTimeHourlyChimes.AutoSize = True
        Me.ChckBxTimeHourlyChimes.Location = New System.Drawing.Point(206, 19)
        Me.ChckBxTimeHourlyChimes.Name = "ChckBxTimeHourlyChimes"
        Me.ChckBxTimeHourlyChimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeHourlyChimes.Size = New System.Drawing.Size(93, 17)
        Me.ChckBxTimeHourlyChimes.TabIndex = 3
        Me.ChckBxTimeHourlyChimes.Text = "Hourly Chimes"
        Me.ChckBxTimeHourlyChimes.UseVisualStyleBackColor = True
        '
        'ChckBxTimeHourPips
        '
        Me.ChckBxTimeHourPips.AutoSize = True
        Me.ChckBxTimeHourPips.Checked = True
        Me.ChckBxTimeHourPips.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChckBxTimeHourPips.Location = New System.Drawing.Point(6, 19)
        Me.ChckBxTimeHourPips.Name = "ChckBxTimeHourPips"
        Me.ChckBxTimeHourPips.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeHourPips.Size = New System.Drawing.Size(171, 17)
        Me.ChckBxTimeHourPips.TabIndex = 2
        Me.ChckBxTimeHourPips.Text = "Sound ""The Pips"" on the Hour"
        Me.ChckBxTimeHourPips.UseVisualStyleBackColor = True
        '
        'TbPgOtherStuff
        '
        Me.TbPgOtherStuff.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgOtherStuff.Controls.Add(Me.GroupBox19)
        Me.TbPgOtherStuff.Controls.Add(Me.GroupBox5)
        Me.TbPgOtherStuff.Controls.Add(Me.GroupBox4)
        Me.TbPgOtherStuff.Controls.Add(Me.GroupBox9)
        Me.TbPgOtherStuff.Controls.Add(Me.GroupBox12)
        Me.TbPgOtherStuff.Location = New System.Drawing.Point(4, 25)
        Me.TbPgOtherStuff.Name = "TbPgOtherStuff"
        Me.TbPgOtherStuff.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgOtherStuff.Size = New System.Drawing.Size(660, 265)
        Me.TbPgOtherStuff.TabIndex = 7
        Me.TbPgOtherStuff.Text = "Other Stuff"
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.ChckBxDisableMonitorSleep)
        Me.GroupBox19.Location = New System.Drawing.Point(6, 218)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(648, 41)
        Me.GroupBox19.TabIndex = 3
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Monitor"
        '
        'ChckBxDisableMonitorSleep
        '
        Me.ChckBxDisableMonitorSleep.AutoSize = True
        Me.ChckBxDisableMonitorSleep.Location = New System.Drawing.Point(52, 18)
        Me.ChckBxDisableMonitorSleep.Name = "ChckBxDisableMonitorSleep"
        Me.ChckBxDisableMonitorSleep.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxDisableMonitorSleep.Size = New System.Drawing.Size(172, 17)
        Me.ChckBxDisableMonitorSleep.TabIndex = 0
        Me.ChckBxDisableMonitorSleep.Text = "Disable Monitor Going to Sleep"
        Me.ChckBxDisableMonitorSleep.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ChckBxReminderAdd)
        Me.GroupBox5.Controls.Add(Me.ChckBxReminderTimeCheck)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 165)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(648, 47)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Reminder Settings"
        '
        'ChckBxReminderAdd
        '
        Me.ChckBxReminderAdd.AutoSize = True
        Me.ChckBxReminderAdd.Location = New System.Drawing.Point(19, 19)
        Me.ChckBxReminderAdd.Name = "ChckBxReminderAdd"
        Me.ChckBxReminderAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxReminderAdd.Size = New System.Drawing.Size(205, 17)
        Me.ChckBxReminderAdd.TabIndex = 1
        Me.ChckBxReminderAdd.Text = "Add Reminder to Notification and Title"
        Me.ChckBxReminderAdd.UseVisualStyleBackColor = True
        '
        'ChckBxReminderTimeCheck
        '
        Me.ChckBxReminderTimeCheck.AutoSize = True
        Me.ChckBxReminderTimeCheck.Location = New System.Drawing.Point(292, 19)
        Me.ChckBxReminderTimeCheck.Name = "ChckBxReminderTimeCheck"
        Me.ChckBxReminderTimeCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxReminderTimeCheck.Size = New System.Drawing.Size(94, 17)
        Me.ChckBxReminderTimeCheck.TabIndex = 0
        Me.ChckBxReminderTimeCheck.Text = "Time checked"
        Me.ChckBxReminderTimeCheck.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChckBxTimerAdd)
        Me.GroupBox4.Controls.Add(Me.ChckBxTimerHigh)
        Me.GroupBox4.Controls.Add(Me.ChckBxClearSplit)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 112)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(648, 47)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Timer Settings"
        '
        'ChckBxTimerAdd
        '
        Me.ChckBxTimerAdd.AutoSize = True
        Me.ChckBxTimerAdd.Location = New System.Drawing.Point(38, 19)
        Me.ChckBxTimerAdd.Name = "ChckBxTimerAdd"
        Me.ChckBxTimerAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimerAdd.Size = New System.Drawing.Size(186, 17)
        Me.ChckBxTimerAdd.TabIndex = 2
        Me.ChckBxTimerAdd.Text = "Add Timer to Notification and Title"
        Me.ChckBxTimerAdd.UseVisualStyleBackColor = True
        '
        'ChckBxTimerHigh
        '
        Me.ChckBxTimerHigh.AutoSize = True
        Me.ChckBxTimerHigh.Location = New System.Drawing.Point(431, 19)
        Me.ChckBxTimerHigh.Name = "ChckBxTimerHigh"
        Me.ChckBxTimerHigh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimerHigh.Size = New System.Drawing.Size(154, 17)
        Me.ChckBxTimerHigh.TabIndex = 0
        Me.ChckBxTimerHigh.Text = "Timer to show MilliSeconds"
        Me.ChckBxTimerHigh.UseVisualStyleBackColor = True
        '
        'ChckBxClearSplit
        '
        Me.ChckBxClearSplit.AutoSize = True
        Me.ChckBxClearSplit.Location = New System.Drawing.Point(277, 19)
        Me.ChckBxClearSplit.Name = "ChckBxClearSplit"
        Me.ChckBxClearSplit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxClearSplit.Size = New System.Drawing.Size(109, 17)
        Me.ChckBxClearSplit.TabIndex = 1
        Me.ChckBxClearSplit.Text = "Clear to clear split"
        Me.ChckBxClearSplit.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.ChckBxCountdownAdd)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 59)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(648, 47)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Countdown Settings"
        '
        'ChckBxCountdownAdd
        '
        Me.ChckBxCountdownAdd.AutoSize = True
        Me.ChckBxCountdownAdd.Location = New System.Drawing.Point(10, 19)
        Me.ChckBxCountdownAdd.Name = "ChckBxCountdownAdd"
        Me.ChckBxCountdownAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxCountdownAdd.Size = New System.Drawing.Size(214, 17)
        Me.ChckBxCountdownAdd.TabIndex = 0
        Me.ChckBxCountdownAdd.Text = "Add Countdown to Notification and Title"
        Me.ChckBxCountdownAdd.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.ChckBxWorldKlockAdd)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(648, 47)
        Me.GroupBox12.TabIndex = 0
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "World KlockSettings"
        '
        'ChckBxWorldKlockAdd
        '
        Me.ChckBxWorldKlockAdd.AutoSize = True
        Me.ChckBxWorldKlockAdd.Location = New System.Drawing.Point(6, 19)
        Me.ChckBxWorldKlockAdd.Name = "ChckBxWorldKlockAdd"
        Me.ChckBxWorldKlockAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxWorldKlockAdd.Size = New System.Drawing.Size(218, 17)
        Me.ChckBxWorldKlockAdd.TabIndex = 0
        Me.ChckBxWorldKlockAdd.Text = "Add World Klock to Notification and Title"
        Me.ChckBxWorldKlockAdd.UseVisualStyleBackColor = True
        '
        'TbPgArchive
        '
        Me.TbPgArchive.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgArchive.Controls.Add(Me.GroupBox11)
        Me.TbPgArchive.Controls.Add(Me.GroupBox10)
        Me.TbPgArchive.Location = New System.Drawing.Point(4, 25)
        Me.TbPgArchive.Name = "TbPgArchive"
        Me.TbPgArchive.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgArchive.Size = New System.Drawing.Size(660, 265)
        Me.TbPgArchive.TabIndex = 6
        Me.TbPgArchive.Text = "Archive"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.TxtBxArchiveFile)
        Me.GroupBox11.Controls.Add(Me.TxtBxArchiveDirectory)
        Me.GroupBox11.Controls.Add(Me.btnArchiveFile)
        Me.GroupBox11.Controls.Add(Me.btnArchiveDirectory)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 204)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(648, 53)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Archive"
        '
        'TxtBxArchiveFile
        '
        Me.TxtBxArchiveFile.Location = New System.Drawing.Point(434, 22)
        Me.TxtBxArchiveFile.Name = "TxtBxArchiveFile"
        Me.TxtBxArchiveFile.ReadOnly = True
        Me.TxtBxArchiveFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxArchiveFile.TabIndex = 3
        '
        'TxtBxArchiveDirectory
        '
        Me.TxtBxArchiveDirectory.Location = New System.Drawing.Point(6, 19)
        Me.TxtBxArchiveDirectory.Name = "TxtBxArchiveDirectory"
        Me.TxtBxArchiveDirectory.ReadOnly = True
        Me.TxtBxArchiveDirectory.Size = New System.Drawing.Size(341, 20)
        Me.TxtBxArchiveDirectory.TabIndex = 2
        '
        'btnArchiveFile
        '
        Me.btnArchiveFile.Location = New System.Drawing.Point(557, 22)
        Me.btnArchiveFile.Name = "btnArchiveFile"
        Me.btnArchiveFile.Size = New System.Drawing.Size(75, 23)
        Me.btnArchiveFile.TabIndex = 1
        Me.btnArchiveFile.Text = "..."
        Me.btnArchiveFile.UseVisualStyleBackColor = True
        '
        'btnArchiveDirectory
        '
        Me.btnArchiveDirectory.Location = New System.Drawing.Point(353, 19)
        Me.btnArchiveDirectory.Name = "btnArchiveDirectory"
        Me.btnArchiveDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnArchiveDirectory.TabIndex = 0
        Me.btnArchiveDirectory.Text = "..."
        Me.btnArchiveDirectory.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsSettingsFile)
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsMemoFile)
        Me.GroupBox10.Controls.Add(Me.Label22)
        Me.GroupBox10.Controls.Add(Me.btnOptionsMemoFile)
        Me.GroupBox10.Controls.Add(Me.label18)
        Me.GroupBox10.Controls.Add(Me.btnOptionsEventsFile)
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsEventsFile)
        Me.GroupBox10.Controls.Add(Me.Label13)
        Me.GroupBox10.Controls.Add(Me.Label12)
        Me.GroupBox10.Controls.Add(Me.Label11)
        Me.GroupBox10.Controls.Add(Me.Label7)
        Me.GroupBox10.Controls.Add(Me.btnOptionsPathReset)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsFile)
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsFriendsFile)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsDirectory)
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsFriendsDirectory)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(648, 192)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Data Files"
        '
        'TxtBxOptionsSettingsFile
        '
        Me.TxtBxOptionsSettingsFile.Location = New System.Drawing.Point(434, 164)
        Me.TxtBxOptionsSettingsFile.Name = "TxtBxOptionsSettingsFile"
        Me.TxtBxOptionsSettingsFile.ReadOnly = True
        Me.TxtBxOptionsSettingsFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxOptionsSettingsFile.TabIndex = 19
        '
        'TxtBxOptionsMemoFile
        '
        Me.TxtBxOptionsMemoFile.Location = New System.Drawing.Point(434, 121)
        Me.TxtBxOptionsMemoFile.Name = "TxtBxOptionsMemoFile"
        Me.TxtBxOptionsMemoFile.ReadOnly = True
        Me.TxtBxOptionsMemoFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxOptionsMemoFile.TabIndex = 18
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(431, 105)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Memo File"
        '
        'btnOptionsMemoFile
        '
        Me.btnOptionsMemoFile.Location = New System.Drawing.Point(557, 118)
        Me.btnOptionsMemoFile.Name = "btnOptionsMemoFile"
        Me.btnOptionsMemoFile.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsMemoFile.TabIndex = 16
        Me.btnOptionsMemoFile.Text = "..."
        Me.btnOptionsMemoFile.UseVisualStyleBackColor = True
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(6, 16)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(75, 13)
        Me.label18.TabIndex = 15
        Me.label18.Text = "Data Directory"
        '
        'btnOptionsEventsFile
        '
        Me.btnOptionsEventsFile.Location = New System.Drawing.Point(557, 78)
        Me.btnOptionsEventsFile.Name = "btnOptionsEventsFile"
        Me.btnOptionsEventsFile.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsEventsFile.TabIndex = 14
        Me.btnOptionsEventsFile.Text = "..."
        Me.btnOptionsEventsFile.UseVisualStyleBackColor = True
        '
        'TxtBxOptionsEventsFile
        '
        Me.TxtBxOptionsEventsFile.Location = New System.Drawing.Point(434, 78)
        Me.TxtBxOptionsEventsFile.Name = "TxtBxOptionsEventsFile"
        Me.TxtBxOptionsEventsFile.ReadOnly = True
        Me.TxtBxOptionsEventsFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxOptionsEventsFile.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(431, 146)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Settings File"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(431, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Events File"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(431, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Friends File"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(162, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Reset path back to Application Folder"
        '
        'btnOptionsPathReset
        '
        Me.btnOptionsPathReset.Location = New System.Drawing.Point(353, 75)
        Me.btnOptionsPathReset.Name = "btnOptionsPathReset"
        Me.btnOptionsPathReset.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsPathReset.TabIndex = 4
        Me.btnOptionsPathReset.Text = "..."
        Me.btnOptionsPathReset.UseVisualStyleBackColor = True
        '
        'btnOptionsFriendsFile
        '
        Me.btnOptionsFriendsFile.Location = New System.Drawing.Point(557, 32)
        Me.btnOptionsFriendsFile.Name = "btnOptionsFriendsFile"
        Me.btnOptionsFriendsFile.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFriendsFile.TabIndex = 3
        Me.btnOptionsFriendsFile.Text = "..."
        Me.btnOptionsFriendsFile.UseVisualStyleBackColor = True
        '
        'TxtBxOptionsFriendsFile
        '
        Me.TxtBxOptionsFriendsFile.Location = New System.Drawing.Point(434, 35)
        Me.TxtBxOptionsFriendsFile.Name = "TxtBxOptionsFriendsFile"
        Me.TxtBxOptionsFriendsFile.ReadOnly = True
        Me.TxtBxOptionsFriendsFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxOptionsFriendsFile.TabIndex = 2
        '
        'btnOptionsFriendsDirectory
        '
        Me.btnOptionsFriendsDirectory.Location = New System.Drawing.Point(353, 33)
        Me.btnOptionsFriendsDirectory.Name = "btnOptionsFriendsDirectory"
        Me.btnOptionsFriendsDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFriendsDirectory.TabIndex = 1
        Me.btnOptionsFriendsDirectory.Text = "..."
        Me.btnOptionsFriendsDirectory.UseVisualStyleBackColor = True
        '
        'TxtBxOptionsFriendsDirectory
        '
        Me.TxtBxOptionsFriendsDirectory.Location = New System.Drawing.Point(6, 36)
        Me.TxtBxOptionsFriendsDirectory.Name = "TxtBxOptionsFriendsDirectory"
        Me.TxtBxOptionsFriendsDirectory.ReadOnly = True
        Me.TxtBxOptionsFriendsDirectory.Size = New System.Drawing.Size(341, 20)
        Me.TxtBxOptionsFriendsDirectory.TabIndex = 0
        '
        'TbPgEvents
        '
        Me.TbPgEvents.Controls.Add(Me.GroupBox14)
        Me.TbPgEvents.Location = New System.Drawing.Point(4, 25)
        Me.TbPgEvents.Name = "TbPgEvents"
        Me.TbPgEvents.Size = New System.Drawing.Size(660, 265)
        Me.TbPgEvents.TabIndex = 8
        Me.TbPgEvents.Text = "Events"
        Me.TbPgEvents.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.PctrBxThirdEvent)
        Me.GroupBox14.Controls.Add(Me.btnThirdEventNotificationColour)
        Me.GroupBox14.Controls.Add(Me.PctrBxSecondEvent)
        Me.GroupBox14.Controls.Add(Me.btnSecondEventNotificationColour)
        Me.GroupBox14.Controls.Add(Me.PctrBxFirstEvent)
        Me.GroupBox14.Controls.Add(Me.btnFirstEventNotificationColour)
        Me.GroupBox14.Controls.Add(Me.Label17)
        Me.GroupBox14.Controls.Add(Me.Label16)
        Me.GroupBox14.Controls.Add(Me.Label15)
        Me.GroupBox14.Controls.Add(Me.Label14)
        Me.GroupBox14.Controls.Add(Me.lblEventsInterval)
        Me.GroupBox14.Controls.Add(Me.NmrcUpDwnEventsInterval)
        Me.GroupBox14.Controls.Add(Me.NmrcUpDwnThirdReminder)
        Me.GroupBox14.Controls.Add(Me.NmrcUpDwnSecondReminder)
        Me.GroupBox14.Controls.Add(Me.NmrcUpDwnFirstReminder)
        Me.GroupBox14.Controls.Add(Me.lblThirdReminder)
        Me.GroupBox14.Controls.Add(Me.lblSecondReminder)
        Me.GroupBox14.Controls.Add(Me.lblFirstreminder)
        Me.GroupBox14.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(653, 253)
        Me.GroupBox14.TabIndex = 0
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Aged days"
        '
        'PctrBxThirdEvent
        '
        Me.PctrBxThirdEvent.Location = New System.Drawing.Point(316, 90)
        Me.PctrBxThirdEvent.Name = "PctrBxThirdEvent"
        Me.PctrBxThirdEvent.Size = New System.Drawing.Size(50, 23)
        Me.PctrBxThirdEvent.TabIndex = 21
        Me.PctrBxThirdEvent.TabStop = False
        '
        'btnThirdEventNotificationColour
        '
        Me.btnThirdEventNotificationColour.Location = New System.Drawing.Point(250, 88)
        Me.btnThirdEventNotificationColour.Name = "btnThirdEventNotificationColour"
        Me.btnThirdEventNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnThirdEventNotificationColour.TabIndex = 20
        Me.btnThirdEventNotificationColour.Text = ",,,"
        Me.btnThirdEventNotificationColour.UseVisualStyleBackColor = True
        '
        'PctrBxSecondEvent
        '
        Me.PctrBxSecondEvent.Location = New System.Drawing.Point(316, 62)
        Me.PctrBxSecondEvent.Name = "PctrBxSecondEvent"
        Me.PctrBxSecondEvent.Size = New System.Drawing.Size(50, 23)
        Me.PctrBxSecondEvent.TabIndex = 18
        Me.PctrBxSecondEvent.TabStop = False
        '
        'btnSecondEventNotificationColour
        '
        Me.btnSecondEventNotificationColour.Location = New System.Drawing.Point(250, 59)
        Me.btnSecondEventNotificationColour.Name = "btnSecondEventNotificationColour"
        Me.btnSecondEventNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnSecondEventNotificationColour.TabIndex = 17
        Me.btnSecondEventNotificationColour.Text = ",,,"
        Me.btnSecondEventNotificationColour.UseVisualStyleBackColor = True
        '
        'PctrBxFirstEvent
        '
        Me.PctrBxFirstEvent.Location = New System.Drawing.Point(316, 33)
        Me.PctrBxFirstEvent.Name = "PctrBxFirstEvent"
        Me.PctrBxFirstEvent.Size = New System.Drawing.Size(50, 23)
        Me.PctrBxFirstEvent.TabIndex = 15
        Me.PctrBxFirstEvent.TabStop = False
        '
        'btnFirstEventNotificationColour
        '
        Me.btnFirstEventNotificationColour.Location = New System.Drawing.Point(250, 33)
        Me.btnFirstEventNotificationColour.Name = "btnFirstEventNotificationColour"
        Me.btnFirstEventNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnFirstEventNotificationColour.TabIndex = 14
        Me.btnFirstEventNotificationColour.Text = ",,,"
        Me.btnFirstEventNotificationColour.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(188, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "days."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(188, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "days."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(188, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "days."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(188, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "mins"
        '
        'lblEventsInterval
        '
        Me.lblEventsInterval.AutoSize = True
        Me.lblEventsInterval.Location = New System.Drawing.Point(8, 133)
        Me.lblEventsInterval.Name = "lblEventsInterval"
        Me.lblEventsInterval.Size = New System.Drawing.Size(122, 13)
        Me.lblEventsInterval.TabIndex = 7
        Me.lblEventsInterval.Text = "Interval to check events"
        '
        'NmrcUpDwnEventsInterval
        '
        Me.NmrcUpDwnEventsInterval.Location = New System.Drawing.Point(136, 126)
        Me.NmrcUpDwnEventsInterval.Name = "NmrcUpDwnEventsInterval"
        Me.NmrcUpDwnEventsInterval.Size = New System.Drawing.Size(46, 20)
        Me.NmrcUpDwnEventsInterval.TabIndex = 6
        Me.NmrcUpDwnEventsInterval.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'NmrcUpDwnThirdReminder
        '
        Me.NmrcUpDwnThirdReminder.Location = New System.Drawing.Point(136, 83)
        Me.NmrcUpDwnThirdReminder.Name = "NmrcUpDwnThirdReminder"
        Me.NmrcUpDwnThirdReminder.Size = New System.Drawing.Size(46, 20)
        Me.NmrcUpDwnThirdReminder.TabIndex = 5
        Me.NmrcUpDwnThirdReminder.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NmrcUpDwnSecondReminder
        '
        Me.NmrcUpDwnSecondReminder.Location = New System.Drawing.Point(136, 57)
        Me.NmrcUpDwnSecondReminder.Name = "NmrcUpDwnSecondReminder"
        Me.NmrcUpDwnSecondReminder.Size = New System.Drawing.Size(46, 20)
        Me.NmrcUpDwnSecondReminder.TabIndex = 4
        Me.NmrcUpDwnSecondReminder.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'NmrcUpDwnFirstReminder
        '
        Me.NmrcUpDwnFirstReminder.Location = New System.Drawing.Point(136, 31)
        Me.NmrcUpDwnFirstReminder.Name = "NmrcUpDwnFirstReminder"
        Me.NmrcUpDwnFirstReminder.Size = New System.Drawing.Size(46, 20)
        Me.NmrcUpDwnFirstReminder.TabIndex = 3
        Me.NmrcUpDwnFirstReminder.Value = New Decimal(New Integer() {31, 0, 0, 0})
        '
        'lblThirdReminder
        '
        Me.lblThirdReminder.AutoSize = True
        Me.lblThirdReminder.Location = New System.Drawing.Point(8, 90)
        Me.lblThirdReminder.Name = "lblThirdReminder"
        Me.lblThirdReminder.Size = New System.Drawing.Size(79, 13)
        Me.lblThirdReminder.TabIndex = 2
        Me.lblThirdReminder.Text = "Third Reminder"
        '
        'lblSecondReminder
        '
        Me.lblSecondReminder.AutoSize = True
        Me.lblSecondReminder.Location = New System.Drawing.Point(8, 64)
        Me.lblSecondReminder.Name = "lblSecondReminder"
        Me.lblSecondReminder.Size = New System.Drawing.Size(92, 13)
        Me.lblSecondReminder.TabIndex = 1
        Me.lblSecondReminder.Text = "Second Reminder"
        '
        'lblFirstreminder
        '
        Me.lblFirstreminder.AutoSize = True
        Me.lblFirstreminder.Location = New System.Drawing.Point(8, 38)
        Me.lblFirstreminder.Name = "lblFirstreminder"
        Me.lblFirstreminder.Size = New System.Drawing.Size(74, 13)
        Me.lblFirstreminder.TabIndex = 0
        Me.lblFirstreminder.Text = "First Reminder"
        '
        'TbPgMemo
        '
        Me.TbPgMemo.Controls.Add(Me.GroupBox16)
        Me.TbPgMemo.Location = New System.Drawing.Point(4, 25)
        Me.TbPgMemo.Name = "TbPgMemo"
        Me.TbPgMemo.Size = New System.Drawing.Size(660, 265)
        Me.TbPgMemo.TabIndex = 9
        Me.TbPgMemo.Text = "Memo"
        Me.TbPgMemo.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.NmrcUpDwnMemoDecrypt)
        Me.GroupBox16.Controls.Add(Me.Label23)
        Me.GroupBox16.Controls.Add(Me.TxtBxMemoDefaultPassword)
        Me.GroupBox16.Controls.Add(Me.ChckBxMemoDefaultPassword)
        Me.GroupBox16.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(653, 253)
        Me.GroupBox16.TabIndex = 0
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Settings"
        '
        'NmrcUpDwnMemoDecrypt
        '
        Me.NmrcUpDwnMemoDecrypt.Location = New System.Drawing.Point(255, 63)
        Me.NmrcUpDwnMemoDecrypt.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NmrcUpDwnMemoDecrypt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmrcUpDwnMemoDecrypt.Name = "NmrcUpDwnMemoDecrypt"
        Me.NmrcUpDwnMemoDecrypt.Size = New System.Drawing.Size(46, 20)
        Me.NmrcUpDwnMemoDecrypt.TabIndex = 4
        Me.NmrcUpDwnMemoDecrypt.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(101, 65)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(122, 13)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Memo Decrypt Time Out"
        '
        'TxtBxMemoDefaultPassword
        '
        Me.TxtBxMemoDefaultPassword.Enabled = False
        Me.TxtBxMemoDefaultPassword.Location = New System.Drawing.Point(255, 18)
        Me.TxtBxMemoDefaultPassword.Name = "TxtBxMemoDefaultPassword"
        Me.TxtBxMemoDefaultPassword.ReadOnly = True
        Me.TxtBxMemoDefaultPassword.Size = New System.Drawing.Size(100, 20)
        Me.TxtBxMemoDefaultPassword.TabIndex = 2
        Me.TxtBxMemoDefaultPassword.Text = "klock"
        '
        'ChckBxMemoDefaultPassword
        '
        Me.ChckBxMemoDefaultPassword.AutoSize = True
        Me.ChckBxMemoDefaultPassword.Location = New System.Drawing.Point(92, 21)
        Me.ChckBxMemoDefaultPassword.Name = "ChckBxMemoDefaultPassword"
        Me.ChckBxMemoDefaultPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxMemoDefaultPassword.Size = New System.Drawing.Size(131, 17)
        Me.ChckBxMemoDefaultPassword.TabIndex = 0
        Me.ChckBxMemoDefaultPassword.Text = "Use Default Password"
        Me.ChckBxMemoDefaultPassword.UseVisualStyleBackColor = True
        '
        'btnArchiveLoad
        '
        Me.btnArchiveLoad.Enabled = False
        Me.btnArchiveLoad.Location = New System.Drawing.Point(112, 312)
        Me.btnArchiveLoad.Name = "btnArchiveLoad"
        Me.btnArchiveLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnArchiveLoad.TabIndex = 5
        Me.btnArchiveLoad.Text = "Load"
        Me.btnArchiveLoad.UseVisualStyleBackColor = True
        '
        'btnArchiveSave
        '
        Me.btnArchiveSave.Enabled = False
        Me.btnArchiveSave.Location = New System.Drawing.Point(31, 312)
        Me.btnArchiveSave.Name = "btnArchiveSave"
        Me.btnArchiveSave.Size = New System.Drawing.Size(75, 23)
        Me.btnArchiveSave.TabIndex = 4
        Me.btnArchiveSave.Text = "Save"
        Me.btnArchiveSave.UseVisualStyleBackColor = True
        '
        'btnOptionsCancel
        '
        Me.btnOptionsCancel.Location = New System.Drawing.Point(481, 312)
        Me.btnOptionsCancel.Name = "btnOptionsCancel"
        Me.btnOptionsCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsCancel.TabIndex = 9
        Me.btnOptionsCancel.Text = "Cancel"
        Me.btnOptionsCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.CheckFileExists = False
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 357)
        Me.Controls.Add(Me.btnArchiveLoad)
        Me.Controls.Add(Me.btnOptionsCancel)
        Me.Controls.Add(Me.btnArchiveSave)
        Me.Controls.Add(Me.TabCntrlOptions)
        Me.Controls.Add(Me.btnOptionsClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.TabCntrlOptions.ResumeLayout(False)
        Me.TbPgGlobal.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrckBrOptionsVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbPgNotification.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.NmrcUpDwnEventNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PctrBxNotification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbPgTime.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.UpDwnVoiceDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDwnTimeDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TbPgOtherStuff.ResumeLayout(False)
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.TbPgArchive.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TbPgEvents.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.PctrBxThirdEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PctrBxSecondEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PctrBxFirstEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnEventsInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnThirdReminder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnSecondReminder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnFirstReminder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbPgMemo.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        CType(Me.NmrcUpDwnMemoDecrypt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOptionsClose As System.Windows.Forms.Button
    Friend WithEvents ClrDlgFormColour As System.Windows.Forms.ColorDialog
    Friend WithEvents btnOptionsFormColour As System.Windows.Forms.Button
    Friend WithEvents lblColour As System.Windows.Forms.Label
    Friend WithEvents btnOptionsFormFont As System.Windows.Forms.Button
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents FntDlgFont As System.Windows.Forms.FontDialog
    Friend WithEvents ChckBxOptionsSavePos As System.Windows.Forms.CheckBox
    Friend WithEvents btnDefaultColour As System.Windows.Forms.Button
    Friend WithEvents lblDefaultColour As System.Windows.Forms.Label
    Friend WithEvents TabCntrlOptions As System.Windows.Forms.TabControl
    Friend WithEvents TbPgGlobal As System.Windows.Forms.TabPage
    Friend WithEvents TbPgTime As System.Windows.Forms.TabPage
    Friend WithEvents chckBxTimeSwatch As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeNetSeconds As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeHourPips As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeToast As System.Windows.Forms.CheckBox
    Friend WithEvents TbPgNotification As System.Windows.Forms.TabPage
    Friend WithEvents NmrcUpDwnNotificationTimeOut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNotificationFont As System.Windows.Forms.Button
    Friend WithEvents btnNotificationColour As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NmrcUpDwnNotificationOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnNotificationTest As System.Windows.Forms.Button
    Friend WithEvents btnOptionsCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxTimeHourlyChimes As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeQuarterChimes As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeHalfChimes As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptionsTestVolume As System.Windows.Forms.Button
    Friend WithEvents TrckBrOptionsVolume As System.Windows.Forms.TrackBar
    Friend WithEvents UpDwnTimeDisplay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChckBxOptionsRunOnStartup As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxOptionsStartupMinimised As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TbPgArchive As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptionsFriendsFile As System.Windows.Forms.Button
    Friend WithEvents TxtBxOptionsFriendsFile As System.Windows.Forms.TextBox
    Friend WithEvents btnOptionsFriendsDirectory As System.Windows.Forms.Button
    Friend WithEvents TxtBxOptionsFriendsDirectory As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOptionsPathReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxTimeHexIntuitor As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeTwoFormats As System.Windows.Forms.CheckBox
    Friend WithEvents TbPgOtherStuff As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxReminderAdd As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxReminderTimeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxTimerAdd As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimerHigh As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxClearSplit As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxCountdownAdd As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxWorldKlockAdd As System.Windows.Forms.CheckBox
    Private WithEvents ChckBxOptionsVoice As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents UpDwnVoiceDisplay As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblOptionSavepath As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSettingsReset As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtBxArchiveFile As System.Windows.Forms.TextBox
    Friend WithEvents TxtBxArchiveDirectory As System.Windows.Forms.TextBox
    Friend WithEvents btnArchiveFile As System.Windows.Forms.Button
    Friend WithEvents btnArchiveDirectory As System.Windows.Forms.Button
    Friend WithEvents btnArchiveLoad As System.Windows.Forms.Button
    Friend WithEvents btnArchiveSave As System.Windows.Forms.Button
    Friend WithEvents btnOptionsEventsFile As System.Windows.Forms.Button
    Friend WithEvents TxtBxOptionsEventsFile As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TbPgEvents As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents lblThirdReminder As System.Windows.Forms.Label
    Friend WithEvents lblSecondReminder As System.Windows.Forms.Label
    Friend WithEvents lblFirstreminder As System.Windows.Forms.Label
    Friend WithEvents NmrcUpDwnThirdReminder As System.Windows.Forms.NumericUpDown
    Friend WithEvents NmrcUpDwnSecondReminder As System.Windows.Forms.NumericUpDown
    Friend WithEvents NmrcUpDwnFirstReminder As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblEventsInterval As System.Windows.Forms.Label
    Friend WithEvents NmrcUpDwnEventsInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents NmrcUpDwnEventNotificationOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnEventNotificationFont As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PctrBxNotification As System.Windows.Forms.PictureBox
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents PctrBxThirdEvent As System.Windows.Forms.PictureBox
    Friend WithEvents btnThirdEventNotificationColour As System.Windows.Forms.Button
    Friend WithEvents PctrBxSecondEvent As System.Windows.Forms.PictureBox
    Friend WithEvents btnSecondEventNotificationColour As System.Windows.Forms.Button
    Friend WithEvents PctrBxFirstEvent As System.Windows.Forms.PictureBox
    Friend WithEvents btnFirstEventNotificationColour As System.Windows.Forms.Button
    Friend WithEvents btnEventNotificationTest As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CmbBxDefaultTimeFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblTimeTwo As System.Windows.Forms.Label
    Friend WithEvents CmbBxDefaultTimeTwoFormat As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBxOptionsMemoFile As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnOptionsMemoFile As System.Windows.Forms.Button
    Friend WithEvents TxtBxOptionsSettingsFile As System.Windows.Forms.TextBox
    Friend WithEvents TbPgMemo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBxMemoDefaultPassword As System.Windows.Forms.TextBox
    Friend WithEvents ChckBxMemoDefaultPassword As System.Windows.Forms.CheckBox
    Friend WithEvents NmrcUpDwnMemoDecrypt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBxDefaultTab As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents ChckBxTimeTimeTwo12 As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeTimeOne12 As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeSystem12 As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeTimeTwo24 As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeTimeOne24 As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeSystem24 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxIdleTime As CheckBox
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents ChckBxDisableMonitorSleep As CheckBox
End Class
