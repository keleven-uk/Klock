<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.btnOptionsClose = New System.Windows.Forms.Button()
        Me.clrDlgFormColour = New System.Windows.Forms.ColorDialog()
        Me.btnOptionsFormColour = New System.Windows.Forms.Button()
        Me.lblColour = New System.Windows.Forms.Label()
        Me.btnOptionsFormFont = New System.Windows.Forms.Button()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.fntDlgFont = New System.Windows.Forms.FontDialog()
        Me.chckBxOptionsSavePos = New System.Windows.Forms.CheckBox()
        Me.btnDefaultColour = New System.Windows.Forms.Button()
        Me.lblDefaultColour = New System.Windows.Forms.Label()
        Me.tbCntrlOptions = New System.Windows.Forms.TabControl()
        Me.tbPgGlobal = New System.Windows.Forms.TabPage()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.cmbBxDefaultTab = New System.Windows.Forms.ComboBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSettingsReset = New System.Windows.Forms.Button()
        Me.lblOptionSavepath = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chckBxOptionsRunOnStartup = New System.Windows.Forms.CheckBox()
        Me.chckBxOptionsStartupMinimised = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOptionsTestVolume = New System.Windows.Forms.Button()
        Me.trckBrOptionsVolume = New System.Windows.Forms.TrackBar()
        Me.tbPgNotification = New System.Windows.Forms.TabPage()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.lblSayings3 = New System.Windows.Forms.Label()
        Me.nmrcUpDwnSayingDisplay = New System.Windows.Forms.NumericUpDown()
        Me.ChckBxSayings = New System.Windows.Forms.CheckBox()
        Me.lblSayings1 = New System.Windows.Forms.Label()
        Me.btnSayingNotificationTest = New System.Windows.Forms.Button()
        Me.btnSayingNotificationColour = New System.Windows.Forms.Button()
        Me.lblSayings5 = New System.Windows.Forms.Label()
        Me.nmrcUpDwnSayingNotificationOpacity = New System.Windows.Forms.NumericUpDown()
        Me.lblSayings2 = New System.Windows.Forms.Label()
        Me.btnSayingNotificationFont = New System.Windows.Forms.Button()
        Me.lblSayings4 = New System.Windows.Forms.Label()
        Me.nmrcUpDwnSayingNotificationTimeOut = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.btnEventNotificationTest = New System.Windows.Forms.Button()
        Me.nmrcUpDwnEventNotificationOpacity = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnEventNotificationFont = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNotificationTest = New System.Windows.Forms.Button()
        Me.btnNotificationColour = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nmrcUpDwnNotificationOpacity = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNotificationFont = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nmrcUpDwnNotificationTimeOut = New System.Windows.Forms.NumericUpDown()
        Me.tbPgTime = New System.Windows.Forms.TabPage()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.chckBxTimeTimeTwo12 = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeTimeOne12 = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeSystem12 = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeTimeTwo24 = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeTimeOne24 = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeSystem24 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chckBxIdleTime = New System.Windows.Forms.CheckBox()
        Me.lblTimeTwo = New System.Windows.Forms.Label()
        Me.cmbBxDefaultTimeTwoFormat = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbBxDefaultTimeFormat = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.upDwnVoiceDisplay = New System.Windows.Forms.NumericUpDown()
        Me.chckBxOptionsVoice = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeTwoFormats = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeHexIntuitor = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeNetSeconds = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chckBxTimeSwatch = New System.Windows.Forms.CheckBox()
        Me.upDwnTimeDisplay = New System.Windows.Forms.NumericUpDown()
        Me.chckBxTimeToast = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chckBxTimeHalfChimes = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeQuarterChimes = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeHourlyChimes = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeHourPips = New System.Windows.Forms.CheckBox()
        Me.tbPgAnalogueKlock = New System.Windows.Forms.TabPage()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.pctrBxAnlgKlockPicture = New System.Windows.Forms.PictureBox()
        Me.txtBxAnlgKlockPictureLocation = New System.Windows.Forms.TextBox()
        Me.btnAnlgKlockPictureLocation = New System.Windows.Forms.Button()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.chckBxAnlgKlockDisplayPicture = New System.Windows.Forms.CheckBox()
        Me.chckBxAnlgKlockSavePos = New System.Windows.Forms.CheckBox()
        Me.chckBxAnlgKlockTransparent = New System.Windows.Forms.CheckBox()
        Me.btnAnlgKlockBackColour = New System.Windows.Forms.Button()
        Me.lblAnlgKlockBackColour = New System.Windows.Forms.Label()
        Me.chckBxAnlgKlockTime = New System.Windows.Forms.CheckBox()
        Me.chckBxAnlgKlockDate = New System.Windows.Forms.CheckBox()
        Me.txtBxAnlgKlock = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbPgTextKlock = New System.Windows.Forms.TabPage()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.chckBxBgTxKlockSavePos = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnResetBigKlock = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnBgTxtKlckBckClr = New System.Windows.Forms.Button()
        Me.btnBgTxtKlckOffClr = New System.Windows.Forms.Button()
        Me.btnBgTxtKlckFrClr = New System.Windows.Forms.Button()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.chckBxSmlTxKlockSavePos = New System.Windows.Forms.CheckBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnResetSmallKlock = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnSmlTxtKlckBckClr = New System.Windows.Forms.Button()
        Me.btnSmlTxtKlckOffClr = New System.Windows.Forms.Button()
        Me.btnSmlTxtKlckFrClr = New System.Windows.Forms.Button()
        Me.tbPgOtherStuff = New System.Windows.Forms.TabPage()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.chckBxChckInternet = New System.Windows.Forms.CheckBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.chckBxDisableMonitorSleep = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chckBxReminderAdd = New System.Windows.Forms.CheckBox()
        Me.chckBxReminderTimeCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chckBxTimerAdd = New System.Windows.Forms.CheckBox()
        Me.chckBxTimerHigh = New System.Windows.Forms.CheckBox()
        Me.chckBxClearSplit = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.chckBxCountdownAdd = New System.Windows.Forms.CheckBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.chckBxWorldKlockAdd = New System.Windows.Forms.CheckBox()
        Me.tbPgArchive = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtBxArchiveFile = New System.Windows.Forms.TextBox()
        Me.txtBxArchiveDirectory = New System.Windows.Forms.TextBox()
        Me.btnArchiveFile = New System.Windows.Forms.Button()
        Me.btnArchiveDirectory = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtBxOptionsSettingsFile = New System.Windows.Forms.TextBox()
        Me.txtBxOptionsMemoFile = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnOptionsMemoFile = New System.Windows.Forms.Button()
        Me.label18 = New System.Windows.Forms.Label()
        Me.btnOptionsEventsFile = New System.Windows.Forms.Button()
        Me.txtBxOptionsEventsFile = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOptionsPathReset = New System.Windows.Forms.Button()
        Me.btnOptionsFriendsFile = New System.Windows.Forms.Button()
        Me.txtBxOptionsFriendsFile = New System.Windows.Forms.TextBox()
        Me.btnOptionsFriendsDirectory = New System.Windows.Forms.Button()
        Me.txtBxOptionsFriendsDirectory = New System.Windows.Forms.TextBox()
        Me.tbPgEvents = New System.Windows.Forms.TabPage()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.pctrBxThirdEvent = New System.Windows.Forms.PictureBox()
        Me.btnThirdEventNotificationColour = New System.Windows.Forms.Button()
        Me.pctrBxSecondEvent = New System.Windows.Forms.PictureBox()
        Me.btnSecondEventNotificationColour = New System.Windows.Forms.Button()
        Me.pctrBxFirstEvent = New System.Windows.Forms.PictureBox()
        Me.btnFirstEventNotificationColour = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblEventsInterval = New System.Windows.Forms.Label()
        Me.nmrcUpDwnEventsInterval = New System.Windows.Forms.NumericUpDown()
        Me.nmrcUpDwnThirdReminder = New System.Windows.Forms.NumericUpDown()
        Me.nmrcUpDwnSecondReminder = New System.Windows.Forms.NumericUpDown()
        Me.nmrcUpDwnFirstReminder = New System.Windows.Forms.NumericUpDown()
        Me.lblThirdReminder = New System.Windows.Forms.Label()
        Me.lblSecondReminder = New System.Windows.Forms.Label()
        Me.lblFirstreminder = New System.Windows.Forms.Label()
        Me.tbPgMemo = New System.Windows.Forms.TabPage()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.nmrcUpDwnMemoDecrypt = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtBxMemoDefaultPassword = New System.Windows.Forms.TextBox()
        Me.chckBxMemoDefaultPassword = New System.Windows.Forms.CheckBox()
        Me.btnArchiveLoad = New System.Windows.Forms.Button()
        Me.btnArchiveSave = New System.Windows.Forms.Button()
        Me.btnOptionsCancel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tbCntrlOptions.SuspendLayout()
        Me.tbPgGlobal.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.trckBrOptionsVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPgNotification.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        CType(Me.nmrcUpDwnSayingDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnSayingNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnSayingNotificationTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox15.SuspendLayout()
        CType(Me.nmrcUpDwnEventNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.nmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPgTime.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.upDwnVoiceDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnTimeDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tbPgAnalogueKlock.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        CType(Me.pctrBxAnlgKlockPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox23.SuspendLayout()
        Me.tbPgTextKlock.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.tbPgOtherStuff.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.tbPgArchive.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.tbPgEvents.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.pctrBxThirdEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctrBxSecondEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctrBxFirstEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnEventsInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnThirdReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnSecondReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmrcUpDwnFirstReminder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPgMemo.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        CType(Me.nmrcUpDwnMemoDecrypt, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'fntDlgFont
        '
        Me.fntDlgFont.ShowColor = True
        '
        'chckBxOptionsSavePos
        '
        Me.chckBxOptionsSavePos.AutoSize = True
        Me.chckBxOptionsSavePos.Location = New System.Drawing.Point(45, 31)
        Me.chckBxOptionsSavePos.Name = "chckBxOptionsSavePos"
        Me.chckBxOptionsSavePos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxOptionsSavePos.Size = New System.Drawing.Size(163, 17)
        Me.chckBxOptionsSavePos.TabIndex = 5
        Me.chckBxOptionsSavePos.Text = "Save Screen Position on Exit"
        Me.chckBxOptionsSavePos.UseVisualStyleBackColor = True
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
        'tbCntrlOptions
        '
        Me.tbCntrlOptions.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbCntrlOptions.Controls.Add(Me.tbPgGlobal)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgNotification)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgTime)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgAnalogueKlock)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgTextKlock)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgOtherStuff)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgArchive)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgEvents)
        Me.tbCntrlOptions.Controls.Add(Me.tbPgMemo)
        Me.tbCntrlOptions.Location = New System.Drawing.Point(6, 6)
        Me.tbCntrlOptions.Multiline = True
        Me.tbCntrlOptions.Name = "tbCntrlOptions"
        Me.tbCntrlOptions.SelectedIndex = 0
        Me.tbCntrlOptions.Size = New System.Drawing.Size(668, 294)
        Me.tbCntrlOptions.TabIndex = 8
        '
        'tbPgGlobal
        '
        Me.tbPgGlobal.BackColor = System.Drawing.SystemColors.Control
        Me.tbPgGlobal.Controls.Add(Me.GroupBox17)
        Me.tbPgGlobal.Controls.Add(Me.GroupBox13)
        Me.tbPgGlobal.Controls.Add(Me.GroupBox8)
        Me.tbPgGlobal.Controls.Add(Me.GroupBox7)
        Me.tbPgGlobal.Controls.Add(Me.GroupBox2)
        Me.tbPgGlobal.Location = New System.Drawing.Point(4, 25)
        Me.tbPgGlobal.Name = "tbPgGlobal"
        Me.tbPgGlobal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPgGlobal.Size = New System.Drawing.Size(660, 265)
        Me.tbPgGlobal.TabIndex = 0
        Me.tbPgGlobal.Text = "Global"
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.cmbBxDefaultTab)
        Me.GroupBox17.Location = New System.Drawing.Point(280, 8)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(143, 97)
        Me.GroupBox17.TabIndex = 14
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Default Tab"
        '
        'cmbBxDefaultTab
        '
        Me.cmbBxDefaultTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBxDefaultTab.FormattingEnabled = True
        Me.cmbBxDefaultTab.Location = New System.Drawing.Point(14, 39)
        Me.cmbBxDefaultTab.Name = "cmbBxDefaultTab"
        Me.cmbBxDefaultTab.Size = New System.Drawing.Size(121, 21)
        Me.cmbBxDefaultTab.TabIndex = 0
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label10)
        Me.GroupBox13.Controls.Add(Me.btnSettingsReset)
        Me.GroupBox13.Controls.Add(Me.lblOptionSavepath)
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
        'lblOptionSavepath
        '
        Me.lblOptionSavepath.AutoSize = True
        Me.lblOptionSavepath.Location = New System.Drawing.Point(10, 44)
        Me.lblOptionSavepath.Name = "lblOptionSavepath"
        Me.lblOptionSavepath.Size = New System.Drawing.Size(31, 13)
        Me.lblOptionSavepath.TabIndex = 10
        Me.lblOptionSavepath.Text = """c:\"""
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
        Me.GroupBox8.Controls.Add(Me.chckBxOptionsRunOnStartup)
        Me.GroupBox8.Controls.Add(Me.chckBxOptionsSavePos)
        Me.GroupBox8.Controls.Add(Me.chckBxOptionsStartupMinimised)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 111)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(648, 68)
        Me.GroupBox8.TabIndex = 12
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Behaviour"
        '
        'chckBxOptionsRunOnStartup
        '
        Me.chckBxOptionsRunOnStartup.AutoSize = True
        Me.chckBxOptionsRunOnStartup.Location = New System.Drawing.Point(268, 31)
        Me.chckBxOptionsRunOnStartup.Name = "chckBxOptionsRunOnStartup"
        Me.chckBxOptionsRunOnStartup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxOptionsRunOnStartup.Size = New System.Drawing.Size(175, 17)
        Me.chckBxOptionsRunOnStartup.TabIndex = 9
        Me.chckBxOptionsRunOnStartup.Text = "Run Klock on Windows Start up"
        Me.chckBxOptionsRunOnStartup.UseVisualStyleBackColor = True
        '
        'chckBxOptionsStartupMinimised
        '
        Me.chckBxOptionsStartupMinimised.AutoSize = True
        Me.chckBxOptionsStartupMinimised.Location = New System.Drawing.Point(505, 31)
        Me.chckBxOptionsStartupMinimised.Name = "chckBxOptionsStartupMinimised"
        Me.chckBxOptionsStartupMinimised.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxOptionsStartupMinimised.Size = New System.Drawing.Size(127, 17)
        Me.chckBxOptionsStartupMinimised.TabIndex = 10
        Me.chckBxOptionsStartupMinimised.Text = "Start Klock Minimised"
        Me.chckBxOptionsStartupMinimised.UseVisualStyleBackColor = True
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
        Me.GroupBox7.Text = "Appearance [Not Implemented]"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOptionsTestVolume)
        Me.GroupBox2.Controls.Add(Me.trckBrOptionsVolume)
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
        'trckBrOptionsVolume
        '
        Me.trckBrOptionsVolume.LargeChange = 1
        Me.trckBrOptionsVolume.Location = New System.Drawing.Point(13, 17)
        Me.trckBrOptionsVolume.Name = "trckBrOptionsVolume"
        Me.trckBrOptionsVolume.Size = New System.Drawing.Size(396, 45)
        Me.trckBrOptionsVolume.TabIndex = 0
        Me.trckBrOptionsVolume.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'tbPgNotification
        '
        Me.tbPgNotification.BackColor = System.Drawing.SystemColors.Control
        Me.tbPgNotification.Controls.Add(Me.GroupBox25)
        Me.tbPgNotification.Controls.Add(Me.GroupBox15)
        Me.tbPgNotification.Controls.Add(Me.GroupBox6)
        Me.tbPgNotification.Location = New System.Drawing.Point(4, 25)
        Me.tbPgNotification.Name = "tbPgNotification"
        Me.tbPgNotification.Size = New System.Drawing.Size(660, 265)
        Me.tbPgNotification.TabIndex = 3
        Me.tbPgNotification.Text = "Notification"
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.lblSayings3)
        Me.GroupBox25.Controls.Add(Me.nmrcUpDwnSayingDisplay)
        Me.GroupBox25.Controls.Add(Me.ChckBxSayings)
        Me.GroupBox25.Controls.Add(Me.lblSayings1)
        Me.GroupBox25.Controls.Add(Me.btnSayingNotificationTest)
        Me.GroupBox25.Controls.Add(Me.btnSayingNotificationColour)
        Me.GroupBox25.Controls.Add(Me.lblSayings5)
        Me.GroupBox25.Controls.Add(Me.nmrcUpDwnSayingNotificationOpacity)
        Me.GroupBox25.Controls.Add(Me.lblSayings2)
        Me.GroupBox25.Controls.Add(Me.btnSayingNotificationFont)
        Me.GroupBox25.Controls.Add(Me.lblSayings4)
        Me.GroupBox25.Controls.Add(Me.nmrcUpDwnSayingNotificationTimeOut)
        Me.GroupBox25.Location = New System.Drawing.Point(436, 3)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(210, 253)
        Me.GroupBox25.TabIndex = 11
        Me.GroupBox25.TabStop = False
        Me.GroupBox25.Text = "Sayings"
        '
        'lblSayings3
        '
        Me.lblSayings3.AutoSize = True
        Me.lblSayings3.Location = New System.Drawing.Point(16, 124)
        Me.lblSayings3.Name = "lblSayings3"
        Me.lblSayings3.Size = New System.Drawing.Size(97, 13)
        Me.lblSayings3.TabIndex = 20
        Me.lblSayings3.Text = "Sayings Frequency"
        '
        'nmrcUpDwnSayingDisplay
        '
        Me.nmrcUpDwnSayingDisplay.Location = New System.Drawing.Point(144, 122)
        Me.nmrcUpDwnSayingDisplay.Name = "nmrcUpDwnSayingDisplay"
        Me.nmrcUpDwnSayingDisplay.Size = New System.Drawing.Size(50, 20)
        Me.nmrcUpDwnSayingDisplay.TabIndex = 19
        Me.nmrcUpDwnSayingDisplay.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'ChckBxSayings
        '
        Me.ChckBxSayings.AutoSize = True
        Me.ChckBxSayings.Checked = True
        Me.ChckBxSayings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChckBxSayings.Location = New System.Drawing.Point(16, 19)
        Me.ChckBxSayings.Name = "ChckBxSayings"
        Me.ChckBxSayings.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxSayings.Size = New System.Drawing.Size(100, 17)
        Me.ChckBxSayings.TabIndex = 18
        Me.ChckBxSayings.Text = "Display Sayings"
        Me.ChckBxSayings.UseVisualStyleBackColor = True
        '
        'lblSayings1
        '
        Me.lblSayings1.AutoSize = True
        Me.lblSayings1.Location = New System.Drawing.Point(16, 50)
        Me.lblSayings1.Name = "lblSayings1"
        Me.lblSayings1.Size = New System.Drawing.Size(121, 13)
        Me.lblSayings1.TabIndex = 9
        Me.lblSayings1.Text = "Notification Back Colour"
        '
        'btnSayingNotificationTest
        '
        Me.btnSayingNotificationTest.Location = New System.Drawing.Point(144, 224)
        Me.btnSayingNotificationTest.Name = "btnSayingNotificationTest"
        Me.btnSayingNotificationTest.Size = New System.Drawing.Size(50, 23)
        Me.btnSayingNotificationTest.TabIndex = 17
        Me.btnSayingNotificationTest.Text = "Test"
        Me.btnSayingNotificationTest.UseVisualStyleBackColor = True
        '
        'btnSayingNotificationColour
        '
        Me.btnSayingNotificationColour.Location = New System.Drawing.Point(144, 45)
        Me.btnSayingNotificationColour.Name = "btnSayingNotificationColour"
        Me.btnSayingNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnSayingNotificationColour.TabIndex = 12
        Me.btnSayingNotificationColour.Text = "..."
        Me.btnSayingNotificationColour.UseVisualStyleBackColor = True
        '
        'lblSayings5
        '
        Me.lblSayings5.AutoSize = True
        Me.lblSayings5.Location = New System.Drawing.Point(16, 186)
        Me.lblSayings5.Name = "lblSayings5"
        Me.lblSayings5.Size = New System.Drawing.Size(83, 13)
        Me.lblSayings5.TabIndex = 15
        Me.lblSayings5.Text = "Sayings Opacity"
        '
        'nmrcUpDwnSayingNotificationOpacity
        '
        Me.nmrcUpDwnSayingNotificationOpacity.Location = New System.Drawing.Point(144, 184)
        Me.nmrcUpDwnSayingNotificationOpacity.Name = "nmrcUpDwnSayingNotificationOpacity"
        Me.nmrcUpDwnSayingNotificationOpacity.Size = New System.Drawing.Size(50, 20)
        Me.nmrcUpDwnSayingNotificationOpacity.TabIndex = 16
        Me.nmrcUpDwnSayingNotificationOpacity.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'lblSayings2
        '
        Me.lblSayings2.AutoSize = True
        Me.lblSayings2.Location = New System.Drawing.Point(16, 79)
        Me.lblSayings2.Name = "lblSayings2"
        Me.lblSayings2.Size = New System.Drawing.Size(84, 13)
        Me.lblSayings2.TabIndex = 11
        Me.lblSayings2.Text = "Notification Font"
        '
        'btnSayingNotificationFont
        '
        Me.btnSayingNotificationFont.Location = New System.Drawing.Point(144, 74)
        Me.btnSayingNotificationFont.Name = "btnSayingNotificationFont"
        Me.btnSayingNotificationFont.Size = New System.Drawing.Size(50, 23)
        Me.btnSayingNotificationFont.TabIndex = 13
        Me.btnSayingNotificationFont.Text = "..."
        Me.btnSayingNotificationFont.UseVisualStyleBackColor = True
        '
        'lblSayings4
        '
        Me.lblSayings4.AutoSize = True
        Me.lblSayings4.Location = New System.Drawing.Point(16, 160)
        Me.lblSayings4.Name = "lblSayings4"
        Me.lblSayings4.Size = New System.Drawing.Size(90, 13)
        Me.lblSayings4.TabIndex = 14
        Me.lblSayings4.Text = "Sayings Time Out"
        '
        'nmrcUpDwnSayingNotificationTimeOut
        '
        Me.nmrcUpDwnSayingNotificationTimeOut.Location = New System.Drawing.Point(144, 158)
        Me.nmrcUpDwnSayingNotificationTimeOut.Name = "nmrcUpDwnSayingNotificationTimeOut"
        Me.nmrcUpDwnSayingNotificationTimeOut.Size = New System.Drawing.Size(50, 20)
        Me.nmrcUpDwnSayingNotificationTimeOut.TabIndex = 10
        Me.nmrcUpDwnSayingNotificationTimeOut.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.btnEventNotificationTest)
        Me.GroupBox15.Controls.Add(Me.nmrcUpDwnEventNotificationOpacity)
        Me.GroupBox15.Controls.Add(Me.Label20)
        Me.GroupBox15.Controls.Add(Me.btnEventNotificationFont)
        Me.GroupBox15.Controls.Add(Me.Label19)
        Me.GroupBox15.Location = New System.Drawing.Point(220, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(210, 253)
        Me.GroupBox15.TabIndex = 10
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Event Notification Appearance"
        '
        'btnEventNotificationTest
        '
        Me.btnEventNotificationTest.Location = New System.Drawing.Point(144, 224)
        Me.btnEventNotificationTest.Name = "btnEventNotificationTest"
        Me.btnEventNotificationTest.Size = New System.Drawing.Size(50, 23)
        Me.btnEventNotificationTest.TabIndex = 6
        Me.btnEventNotificationTest.Text = "Test"
        Me.btnEventNotificationTest.UseVisualStyleBackColor = True
        '
        'nmrcUpDwnEventNotificationOpacity
        '
        Me.nmrcUpDwnEventNotificationOpacity.Location = New System.Drawing.Point(144, 184)
        Me.nmrcUpDwnEventNotificationOpacity.Name = "nmrcUpDwnEventNotificationOpacity"
        Me.nmrcUpDwnEventNotificationOpacity.Size = New System.Drawing.Size(50, 20)
        Me.nmrcUpDwnEventNotificationOpacity.TabIndex = 5
        Me.nmrcUpDwnEventNotificationOpacity.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 186)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Notification Opacity"
        '
        'btnEventNotificationFont
        '
        Me.btnEventNotificationFont.Location = New System.Drawing.Point(144, 74)
        Me.btnEventNotificationFont.Name = "btnEventNotificationFont"
        Me.btnEventNotificationFont.Size = New System.Drawing.Size(50, 23)
        Me.btnEventNotificationFont.TabIndex = 3
        Me.btnEventNotificationFont.Text = "..."
        Me.btnEventNotificationFont.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Notification Font"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.btnNotificationTest)
        Me.GroupBox6.Controls.Add(Me.btnNotificationColour)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.nmrcUpDwnNotificationOpacity)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.btnNotificationFont)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.nmrcUpDwnNotificationTimeOut)
        Me.GroupBox6.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(210, 253)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "General Notification Appearance"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Notification Back Colour"
        '
        'btnNotificationTest
        '
        Me.btnNotificationTest.Location = New System.Drawing.Point(144, 224)
        Me.btnNotificationTest.Name = "btnNotificationTest"
        Me.btnNotificationTest.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationTest.TabIndex = 8
        Me.btnNotificationTest.Text = "Test"
        Me.btnNotificationTest.UseVisualStyleBackColor = True
        '
        'btnNotificationColour
        '
        Me.btnNotificationColour.Location = New System.Drawing.Point(144, 45)
        Me.btnNotificationColour.Name = "btnNotificationColour"
        Me.btnNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationColour.TabIndex = 2
        Me.btnNotificationColour.Text = "..."
        Me.btnNotificationColour.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Notification Opacity"
        '
        'nmrcUpDwnNotificationOpacity
        '
        Me.nmrcUpDwnNotificationOpacity.Location = New System.Drawing.Point(144, 184)
        Me.nmrcUpDwnNotificationOpacity.Name = "nmrcUpDwnNotificationOpacity"
        Me.nmrcUpDwnNotificationOpacity.Size = New System.Drawing.Size(50, 20)
        Me.nmrcUpDwnNotificationOpacity.TabIndex = 7
        Me.nmrcUpDwnNotificationOpacity.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Notification Font"
        '
        'btnNotificationFont
        '
        Me.btnNotificationFont.Location = New System.Drawing.Point(144, 74)
        Me.btnNotificationFont.Name = "btnNotificationFont"
        Me.btnNotificationFont.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationFont.TabIndex = 3
        Me.btnNotificationFont.Text = "..."
        Me.btnNotificationFont.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Notification Time Out"
        '
        'nmrcUpDwnNotificationTimeOut
        '
        Me.nmrcUpDwnNotificationTimeOut.Location = New System.Drawing.Point(144, 158)
        Me.nmrcUpDwnNotificationTimeOut.Name = "nmrcUpDwnNotificationTimeOut"
        Me.nmrcUpDwnNotificationTimeOut.Size = New System.Drawing.Size(50, 20)
        Me.nmrcUpDwnNotificationTimeOut.TabIndex = 0
        Me.nmrcUpDwnNotificationTimeOut.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'tbPgTime
        '
        Me.tbPgTime.BackColor = System.Drawing.SystemColors.Control
        Me.tbPgTime.Controls.Add(Me.GroupBox18)
        Me.tbPgTime.Controls.Add(Me.GroupBox3)
        Me.tbPgTime.Controls.Add(Me.GroupBox1)
        Me.tbPgTime.Location = New System.Drawing.Point(4, 25)
        Me.tbPgTime.Name = "tbPgTime"
        Me.tbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPgTime.Size = New System.Drawing.Size(660, 265)
        Me.tbPgTime.TabIndex = 1
        Me.tbPgTime.Text = "Time"
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.chckBxTimeTimeTwo12)
        Me.GroupBox18.Controls.Add(Me.chckBxTimeTimeOne12)
        Me.GroupBox18.Controls.Add(Me.chckBxTimeSystem12)
        Me.GroupBox18.Controls.Add(Me.chckBxTimeTimeTwo24)
        Me.GroupBox18.Controls.Add(Me.chckBxTimeTimeOne24)
        Me.GroupBox18.Controls.Add(Me.chckBxTimeSystem24)
        Me.GroupBox18.Location = New System.Drawing.Point(322, 165)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(332, 88)
        Me.GroupBox18.TabIndex = 6
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "12 / 24 Hour"
        '
        'chckBxTimeTimeTwo12
        '
        Me.chckBxTimeTimeTwo12.AutoSize = True
        Me.chckBxTimeTimeTwo12.Location = New System.Drawing.Point(190, 65)
        Me.chckBxTimeTimeTwo12.Name = "chckBxTimeTimeTwo12"
        Me.chckBxTimeTimeTwo12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chckBxTimeTimeTwo12.Size = New System.Drawing.Size(64, 17)
        Me.chckBxTimeTimeTwo12.TabIndex = 5
        Me.chckBxTimeTimeTwo12.Text = "12 Hour"
        Me.chckBxTimeTimeTwo12.UseVisualStyleBackColor = True
        '
        'chckBxTimeTimeOne12
        '
        Me.chckBxTimeTimeOne12.AutoSize = True
        Me.chckBxTimeTimeOne12.Location = New System.Drawing.Point(190, 42)
        Me.chckBxTimeTimeOne12.Name = "chckBxTimeTimeOne12"
        Me.chckBxTimeTimeOne12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chckBxTimeTimeOne12.Size = New System.Drawing.Size(64, 17)
        Me.chckBxTimeTimeOne12.TabIndex = 4
        Me.chckBxTimeTimeOne12.Text = "12 Hour"
        Me.chckBxTimeTimeOne12.UseVisualStyleBackColor = True
        '
        'chckBxTimeSystem12
        '
        Me.chckBxTimeSystem12.AutoSize = True
        Me.chckBxTimeSystem12.Location = New System.Drawing.Point(190, 19)
        Me.chckBxTimeSystem12.Name = "chckBxTimeSystem12"
        Me.chckBxTimeSystem12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chckBxTimeSystem12.Size = New System.Drawing.Size(64, 17)
        Me.chckBxTimeSystem12.TabIndex = 3
        Me.chckBxTimeSystem12.Text = "12 Hour"
        Me.chckBxTimeSystem12.UseVisualStyleBackColor = True
        '
        'chckBxTimeTimeTwo24
        '
        Me.chckBxTimeTimeTwo24.AutoSize = True
        Me.chckBxTimeTimeTwo24.Location = New System.Drawing.Point(57, 65)
        Me.chckBxTimeTimeTwo24.Name = "chckBxTimeTimeTwo24"
        Me.chckBxTimeTimeTwo24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeTimeTwo24.Size = New System.Drawing.Size(117, 17)
        Me.chckBxTimeTimeTwo24.TabIndex = 2
        Me.chckBxTimeTimeTwo24.Text = "Time Two  24 Hour"
        Me.chckBxTimeTimeTwo24.UseVisualStyleBackColor = True
        '
        'chckBxTimeTimeOne24
        '
        Me.chckBxTimeTimeOne24.AutoSize = True
        Me.chckBxTimeTimeOne24.Location = New System.Drawing.Point(58, 42)
        Me.chckBxTimeTimeOne24.Name = "chckBxTimeTimeOne24"
        Me.chckBxTimeTimeOne24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeTimeOne24.Size = New System.Drawing.Size(116, 17)
        Me.chckBxTimeTimeOne24.TabIndex = 1
        Me.chckBxTimeTimeOne24.Text = "Time One  24 Hour"
        Me.chckBxTimeTimeOne24.UseVisualStyleBackColor = True
        '
        'chckBxTimeSystem24
        '
        Me.chckBxTimeSystem24.AutoSize = True
        Me.chckBxTimeSystem24.Location = New System.Drawing.Point(20, 19)
        Me.chckBxTimeSystem24.Name = "chckBxTimeSystem24"
        Me.chckBxTimeSystem24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeSystem24.Size = New System.Drawing.Size(154, 17)
        Me.chckBxTimeSystem24.TabIndex = 0
        Me.chckBxTimeSystem24.Text = "System Tray Time  24 Hour"
        Me.chckBxTimeSystem24.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chckBxIdleTime)
        Me.GroupBox3.Controls.Add(Me.lblTimeTwo)
        Me.GroupBox3.Controls.Add(Me.cmbBxDefaultTimeTwoFormat)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.cmbBxDefaultTimeFormat)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.upDwnVoiceDisplay)
        Me.GroupBox3.Controls.Add(Me.chckBxOptionsVoice)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeTwoFormats)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeHexIntuitor)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeNetSeconds)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeSwatch)
        Me.GroupBox3.Controls.Add(Me.upDwnTimeDisplay)
        Me.GroupBox3.Controls.Add(Me.chckBxTimeToast)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(648, 153)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "General Time Settings"
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
        'cmbBxDefaultTimeTwoFormat
        '
        Me.cmbBxDefaultTimeTwoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBxDefaultTimeTwoFormat.Enabled = False
        Me.cmbBxDefaultTimeTwoFormat.FormattingEnabled = True
        Me.cmbBxDefaultTimeTwoFormat.Location = New System.Drawing.Point(540, 41)
        Me.cmbBxDefaultTimeTwoFormat.Name = "cmbBxDefaultTimeTwoFormat"
        Me.cmbBxDefaultTimeTwoFormat.Size = New System.Drawing.Size(86, 21)
        Me.cmbBxDefaultTimeTwoFormat.TabIndex = 14
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
        'cmbBxDefaultTimeFormat
        '
        Me.cmbBxDefaultTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBxDefaultTimeFormat.FormattingEnabled = True
        Me.cmbBxDefaultTimeFormat.Location = New System.Drawing.Point(540, 14)
        Me.cmbBxDefaultTimeFormat.Name = "cmbBxDefaultTimeFormat"
        Me.cmbBxDefaultTimeFormat.Size = New System.Drawing.Size(86, 21)
        Me.cmbBxDefaultTimeFormat.TabIndex = 12
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
        'upDwnVoiceDisplay
        '
        Me.upDwnVoiceDisplay.Location = New System.Drawing.Point(202, 112)
        Me.upDwnVoiceDisplay.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.upDwnVoiceDisplay.Name = "upDwnVoiceDisplay"
        Me.upDwnVoiceDisplay.Size = New System.Drawing.Size(38, 20)
        Me.upDwnVoiceDisplay.TabIndex = 10
        Me.upDwnVoiceDisplay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'chckBxOptionsVoice
        '
        Me.chckBxOptionsVoice.AutoSize = True
        Me.chckBxOptionsVoice.Location = New System.Drawing.Point(249, 115)
        Me.chckBxOptionsVoice.Name = "chckBxOptionsVoice"
        Me.chckBxOptionsVoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxOptionsVoice.Size = New System.Drawing.Size(50, 17)
        Me.chckBxOptionsVoice.TabIndex = 9
        Me.chckBxOptionsVoice.Text = "[mins"
        Me.chckBxOptionsVoice.UseVisualStyleBackColor = True
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
        'chckBxTimeHexIntuitor
        '
        Me.chckBxTimeHexIntuitor.AutoSize = True
        Me.chckBxTimeHexIntuitor.Location = New System.Drawing.Point(336, 107)
        Me.chckBxTimeHexIntuitor.Name = "chckBxTimeHexIntuitor"
        Me.chckBxTimeHexIntuitor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeHexIntuitor.Size = New System.Drawing.Size(290, 17)
        Me.chckBxTimeHexIntuitor.TabIndex = 7
        Me.chckBxTimeHexIntuitor.Text = "Use Intuitor-hextime formatting i.e. Underscore separator"
        Me.chckBxTimeHexIntuitor.UseVisualStyleBackColor = True
        '
        'chckBxTimeNetSeconds
        '
        Me.chckBxTimeNetSeconds.AutoSize = True
        Me.chckBxTimeNetSeconds.Location = New System.Drawing.Point(432, 84)
        Me.chckBxTimeNetSeconds.Name = "chckBxTimeNetSeconds"
        Me.chckBxTimeNetSeconds.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeNetSeconds.Size = New System.Drawing.Size(194, 17)
        Me.chckBxTimeNetSeconds.TabIndex = 1
        Me.chckBxTimeNetSeconds.Text = "New Earth Time to display Seconds"
        Me.chckBxTimeNetSeconds.UseVisualStyleBackColor = True
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
        'upDwnTimeDisplay
        '
        Me.upDwnTimeDisplay.Location = New System.Drawing.Point(202, 86)
        Me.upDwnTimeDisplay.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.upDwnTimeDisplay.Name = "upDwnTimeDisplay"
        Me.upDwnTimeDisplay.Size = New System.Drawing.Size(38, 20)
        Me.upDwnTimeDisplay.TabIndex = 6
        Me.upDwnTimeDisplay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'chckBxTimeToast
        '
        Me.chckBxTimeToast.AutoSize = True
        Me.chckBxTimeToast.Checked = True
        Me.chckBxTimeToast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chckBxTimeToast.Location = New System.Drawing.Point(249, 87)
        Me.chckBxTimeToast.Name = "chckBxTimeToast"
        Me.chckBxTimeToast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeToast.Size = New System.Drawing.Size(50, 17)
        Me.chckBxTimeToast.TabIndex = 3
        Me.chckBxTimeToast.Text = "[mins"
        Me.chckBxTimeToast.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chckBxTimeHalfChimes)
        Me.GroupBox1.Controls.Add(Me.chckBxTimeQuarterChimes)
        Me.GroupBox1.Controls.Add(Me.chckBxTimeHourlyChimes)
        Me.GroupBox1.Controls.Add(Me.chckBxTimeHourPips)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 88)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chimes"
        '
        'chckBxTimeHalfChimes
        '
        Me.chckBxTimeHalfChimes.AutoSize = True
        Me.chckBxTimeHalfChimes.Location = New System.Drawing.Point(191, 42)
        Me.chckBxTimeHalfChimes.Name = "chckBxTimeHalfChimes"
        Me.chckBxTimeHalfChimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeHalfChimes.Size = New System.Drawing.Size(108, 17)
        Me.chckBxTimeHalfChimes.TabIndex = 5
        Me.chckBxTimeHalfChimes.Text = "Half Hour Chimes"
        Me.chckBxTimeHalfChimes.UseVisualStyleBackColor = True
        '
        'chckBxTimeQuarterChimes
        '
        Me.chckBxTimeQuarterChimes.AutoSize = True
        Me.chckBxTimeQuarterChimes.Location = New System.Drawing.Point(175, 65)
        Me.chckBxTimeQuarterChimes.Name = "chckBxTimeQuarterChimes"
        Me.chckBxTimeQuarterChimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeQuarterChimes.Size = New System.Drawing.Size(124, 17)
        Me.chckBxTimeQuarterChimes.TabIndex = 4
        Me.chckBxTimeQuarterChimes.Text = "Quarter Hour Chimes"
        Me.chckBxTimeQuarterChimes.UseVisualStyleBackColor = True
        '
        'chckBxTimeHourlyChimes
        '
        Me.chckBxTimeHourlyChimes.AutoSize = True
        Me.chckBxTimeHourlyChimes.Location = New System.Drawing.Point(206, 19)
        Me.chckBxTimeHourlyChimes.Name = "chckBxTimeHourlyChimes"
        Me.chckBxTimeHourlyChimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeHourlyChimes.Size = New System.Drawing.Size(93, 17)
        Me.chckBxTimeHourlyChimes.TabIndex = 3
        Me.chckBxTimeHourlyChimes.Text = "Hourly Chimes"
        Me.chckBxTimeHourlyChimes.UseVisualStyleBackColor = True
        '
        'chckBxTimeHourPips
        '
        Me.chckBxTimeHourPips.AutoSize = True
        Me.chckBxTimeHourPips.Checked = True
        Me.chckBxTimeHourPips.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chckBxTimeHourPips.Location = New System.Drawing.Point(6, 19)
        Me.chckBxTimeHourPips.Name = "chckBxTimeHourPips"
        Me.chckBxTimeHourPips.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeHourPips.Size = New System.Drawing.Size(171, 17)
        Me.chckBxTimeHourPips.TabIndex = 2
        Me.chckBxTimeHourPips.Text = "Sound ""The Pips"" on the Hour"
        Me.chckBxTimeHourPips.UseVisualStyleBackColor = True
        '
        'tbPgAnalogueKlock
        '
        Me.tbPgAnalogueKlock.Controls.Add(Me.GroupBox24)
        Me.tbPgAnalogueKlock.Controls.Add(Me.GroupBox23)
        Me.tbPgAnalogueKlock.Location = New System.Drawing.Point(4, 25)
        Me.tbPgAnalogueKlock.Name = "tbPgAnalogueKlock"
        Me.tbPgAnalogueKlock.Size = New System.Drawing.Size(660, 265)
        Me.tbPgAnalogueKlock.TabIndex = 11
        Me.tbPgAnalogueKlock.Text = "Analogue Klock"
        Me.tbPgAnalogueKlock.UseVisualStyleBackColor = True
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.pctrBxAnlgKlockPicture)
        Me.GroupBox24.Controls.Add(Me.txtBxAnlgKlockPictureLocation)
        Me.GroupBox24.Controls.Add(Me.btnAnlgKlockPictureLocation)
        Me.GroupBox24.Location = New System.Drawing.Point(298, 6)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(359, 253)
        Me.GroupBox24.TabIndex = 1
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Analogue Klock Background Picture"
        '
        'pctrBxAnlgKlockPicture
        '
        Me.pctrBxAnlgKlockPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pctrBxAnlgKlockPicture.Location = New System.Drawing.Point(127, 19)
        Me.pctrBxAnlgKlockPicture.Name = "pctrBxAnlgKlockPicture"
        Me.pctrBxAnlgKlockPicture.Size = New System.Drawing.Size(162, 150)
        Me.pctrBxAnlgKlockPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctrBxAnlgKlockPicture.TabIndex = 7
        Me.pctrBxAnlgKlockPicture.TabStop = False
        '
        'txtBxAnlgKlockPictureLocation
        '
        Me.txtBxAnlgKlockPictureLocation.Location = New System.Drawing.Point(127, 213)
        Me.txtBxAnlgKlockPictureLocation.Name = "txtBxAnlgKlockPictureLocation"
        Me.txtBxAnlgKlockPictureLocation.ReadOnly = True
        Me.txtBxAnlgKlockPictureLocation.Size = New System.Drawing.Size(162, 20)
        Me.txtBxAnlgKlockPictureLocation.TabIndex = 9
        '
        'btnAnlgKlockPictureLocation
        '
        Me.btnAnlgKlockPictureLocation.Location = New System.Drawing.Point(173, 184)
        Me.btnAnlgKlockPictureLocation.Name = "btnAnlgKlockPictureLocation"
        Me.btnAnlgKlockPictureLocation.Size = New System.Drawing.Size(75, 23)
        Me.btnAnlgKlockPictureLocation.TabIndex = 8
        Me.btnAnlgKlockPictureLocation.Text = "..."
        Me.btnAnlgKlockPictureLocation.UseVisualStyleBackColor = True
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.chckBxAnlgKlockDisplayPicture)
        Me.GroupBox23.Controls.Add(Me.chckBxAnlgKlockSavePos)
        Me.GroupBox23.Controls.Add(Me.chckBxAnlgKlockTransparent)
        Me.GroupBox23.Controls.Add(Me.btnAnlgKlockBackColour)
        Me.GroupBox23.Controls.Add(Me.lblAnlgKlockBackColour)
        Me.GroupBox23.Controls.Add(Me.chckBxAnlgKlockTime)
        Me.GroupBox23.Controls.Add(Me.chckBxAnlgKlockDate)
        Me.GroupBox23.Controls.Add(Me.txtBxAnlgKlock)
        Me.GroupBox23.Controls.Add(Me.Label32)
        Me.GroupBox23.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(286, 253)
        Me.GroupBox23.TabIndex = 0
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "Analogue Klock Settings"
        '
        'chckBxAnlgKlockDisplayPicture
        '
        Me.chckBxAnlgKlockDisplayPicture.AutoSize = True
        Me.chckBxAnlgKlockDisplayPicture.Location = New System.Drawing.Point(85, 175)
        Me.chckBxAnlgKlockDisplayPicture.Name = "chckBxAnlgKlockDisplayPicture"
        Me.chckBxAnlgKlockDisplayPicture.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxAnlgKlockDisplayPicture.Size = New System.Drawing.Size(152, 17)
        Me.chckBxAnlgKlockDisplayPicture.TabIndex = 11
        Me.chckBxAnlgKlockDisplayPicture.Text = "Display background Image"
        Me.chckBxAnlgKlockDisplayPicture.UseVisualStyleBackColor = True
        '
        'chckBxAnlgKlockSavePos
        '
        Me.chckBxAnlgKlockSavePos.AutoSize = True
        Me.chckBxAnlgKlockSavePos.Location = New System.Drawing.Point(74, 206)
        Me.chckBxAnlgKlockSavePos.Name = "chckBxAnlgKlockSavePos"
        Me.chckBxAnlgKlockSavePos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxAnlgKlockSavePos.Size = New System.Drawing.Size(163, 17)
        Me.chckBxAnlgKlockSavePos.TabIndex = 10
        Me.chckBxAnlgKlockSavePos.Text = "Save Screen Position on Exit"
        Me.chckBxAnlgKlockSavePos.UseVisualStyleBackColor = True
        '
        'chckBxAnlgKlockTransparent
        '
        Me.chckBxAnlgKlockTransparent.AutoSize = True
        Me.chckBxAnlgKlockTransparent.Location = New System.Drawing.Point(103, 152)
        Me.chckBxAnlgKlockTransparent.Name = "chckBxAnlgKlockTransparent"
        Me.chckBxAnlgKlockTransparent.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxAnlgKlockTransparent.Size = New System.Drawing.Size(134, 17)
        Me.chckBxAnlgKlockTransparent.TabIndex = 6
        Me.chckBxAnlgKlockTransparent.Text = "Transparent Klock Dial"
        Me.chckBxAnlgKlockTransparent.UseVisualStyleBackColor = True
        '
        'btnAnlgKlockBackColour
        '
        Me.btnAnlgKlockBackColour.Location = New System.Drawing.Point(192, 111)
        Me.btnAnlgKlockBackColour.Name = "btnAnlgKlockBackColour"
        Me.btnAnlgKlockBackColour.Size = New System.Drawing.Size(75, 23)
        Me.btnAnlgKlockBackColour.TabIndex = 5
        Me.btnAnlgKlockBackColour.Text = "..."
        Me.btnAnlgKlockBackColour.UseVisualStyleBackColor = True
        '
        'lblAnlgKlockBackColour
        '
        Me.lblAnlgKlockBackColour.AutoSize = True
        Me.lblAnlgKlockBackColour.Location = New System.Drawing.Point(50, 116)
        Me.lblAnlgKlockBackColour.Name = "lblAnlgKlockBackColour"
        Me.lblAnlgKlockBackColour.Size = New System.Drawing.Size(127, 13)
        Me.lblAnlgKlockBackColour.TabIndex = 4
        Me.lblAnlgKlockBackColour.Text = "Klock background Colour"
        '
        'chckBxAnlgKlockTime
        '
        Me.chckBxAnlgKlockTime.AutoSize = True
        Me.chckBxAnlgKlockTime.Checked = True
        Me.chckBxAnlgKlockTime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chckBxAnlgKlockTime.Location = New System.Drawing.Point(53, 86)
        Me.chckBxAnlgKlockTime.Name = "chckBxAnlgKlockTime"
        Me.chckBxAnlgKlockTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxAnlgKlockTime.Size = New System.Drawing.Size(184, 17)
        Me.chckBxAnlgKlockTime.TabIndex = 3
        Me.chckBxAnlgKlockTime.Text = "Display Digital Time on Klock Dial"
        Me.chckBxAnlgKlockTime.UseVisualStyleBackColor = True
        '
        'chckBxAnlgKlockDate
        '
        Me.chckBxAnlgKlockDate.AutoSize = True
        Me.chckBxAnlgKlockDate.Checked = True
        Me.chckBxAnlgKlockDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chckBxAnlgKlockDate.Location = New System.Drawing.Point(85, 63)
        Me.chckBxAnlgKlockDate.Name = "chckBxAnlgKlockDate"
        Me.chckBxAnlgKlockDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxAnlgKlockDate.Size = New System.Drawing.Size(152, 17)
        Me.chckBxAnlgKlockDate.TabIndex = 2
        Me.chckBxAnlgKlockDate.Text = "Display Date on Klock Dial"
        Me.chckBxAnlgKlockDate.UseVisualStyleBackColor = True
        '
        'txtBxAnlgKlock
        '
        Me.txtBxAnlgKlock.Location = New System.Drawing.Point(135, 26)
        Me.txtBxAnlgKlock.Name = "txtBxAnlgKlock"
        Me.txtBxAnlgKlock.Size = New System.Drawing.Size(102, 20)
        Me.txtBxAnlgKlock.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(50, 29)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(79, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Klock Dial Text"
        '
        'tbPgTextKlock
        '
        Me.tbPgTextKlock.Controls.Add(Me.GroupBox22)
        Me.tbPgTextKlock.Controls.Add(Me.GroupBox21)
        Me.tbPgTextKlock.Location = New System.Drawing.Point(4, 25)
        Me.tbPgTextKlock.Name = "tbPgTextKlock"
        Me.tbPgTextKlock.Size = New System.Drawing.Size(660, 265)
        Me.tbPgTextKlock.TabIndex = 10
        Me.tbPgTextKlock.Text = "Text Klock"
        Me.tbPgTextKlock.UseVisualStyleBackColor = True
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.chckBxBgTxKlockSavePos)
        Me.GroupBox22.Controls.Add(Me.Label31)
        Me.GroupBox22.Controls.Add(Me.btnResetBigKlock)
        Me.GroupBox22.Controls.Add(Me.Label27)
        Me.GroupBox22.Controls.Add(Me.Label28)
        Me.GroupBox22.Controls.Add(Me.Label29)
        Me.GroupBox22.Controls.Add(Me.btnBgTxtKlckBckClr)
        Me.GroupBox22.Controls.Add(Me.btnBgTxtKlckOffClr)
        Me.GroupBox22.Controls.Add(Me.btnBgTxtKlckFrClr)
        Me.GroupBox22.Location = New System.Drawing.Point(334, 6)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(323, 253)
        Me.GroupBox22.TabIndex = 1
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Big Text Klock Settings"
        '
        'chckBxBgTxKlockSavePos
        '
        Me.chckBxBgTxKlockSavePos.AutoSize = True
        Me.chckBxBgTxKlockSavePos.Location = New System.Drawing.Point(43, 141)
        Me.chckBxBgTxKlockSavePos.Name = "chckBxBgTxKlockSavePos"
        Me.chckBxBgTxKlockSavePos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxBgTxKlockSavePos.Size = New System.Drawing.Size(163, 17)
        Me.chckBxBgTxKlockSavePos.TabIndex = 14
        Me.chckBxBgTxKlockSavePos.Text = "Save Screen Position on Exit"
        Me.chckBxBgTxKlockSavePos.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(6, 105)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(114, 13)
        Me.Label31.TabIndex = 13
        Me.Label31.Text = "Reset colour to default"
        '
        'btnResetBigKlock
        '
        Me.btnResetBigKlock.Location = New System.Drawing.Point(131, 100)
        Me.btnResetBigKlock.Name = "btnResetBigKlock"
        Me.btnResetBigKlock.Size = New System.Drawing.Size(75, 23)
        Me.btnResetBigKlock.TabIndex = 12
        Me.btnResetBigKlock.Text = "Reset"
        Me.btnResetBigKlock.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 78)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 13)
        Me.Label27.TabIndex = 11
        Me.Label27.Text = "Change off colour"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 13)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "Change back colour"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 26)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 13)
        Me.Label29.TabIndex = 9
        Me.Label29.Text = "Change fore colour"
        '
        'btnBgTxtKlckBckClr
        '
        Me.btnBgTxtKlckBckClr.Location = New System.Drawing.Point(131, 45)
        Me.btnBgTxtKlckBckClr.Name = "btnBgTxtKlckBckClr"
        Me.btnBgTxtKlckBckClr.Size = New System.Drawing.Size(75, 23)
        Me.btnBgTxtKlckBckClr.TabIndex = 8
        Me.btnBgTxtKlckBckClr.Text = "..."
        Me.btnBgTxtKlckBckClr.UseVisualStyleBackColor = True
        '
        'btnBgTxtKlckOffClr
        '
        Me.btnBgTxtKlckOffClr.Location = New System.Drawing.Point(131, 71)
        Me.btnBgTxtKlckOffClr.Name = "btnBgTxtKlckOffClr"
        Me.btnBgTxtKlckOffClr.Size = New System.Drawing.Size(75, 23)
        Me.btnBgTxtKlckOffClr.TabIndex = 7
        Me.btnBgTxtKlckOffClr.Text = "..."
        Me.btnBgTxtKlckOffClr.UseVisualStyleBackColor = True
        '
        'btnBgTxtKlckFrClr
        '
        Me.btnBgTxtKlckFrClr.Location = New System.Drawing.Point(131, 19)
        Me.btnBgTxtKlckFrClr.Name = "btnBgTxtKlckFrClr"
        Me.btnBgTxtKlckFrClr.Size = New System.Drawing.Size(75, 23)
        Me.btnBgTxtKlckFrClr.TabIndex = 6
        Me.btnBgTxtKlckFrClr.Text = "..."
        Me.btnBgTxtKlckFrClr.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.chckBxSmlTxKlockSavePos)
        Me.GroupBox21.Controls.Add(Me.Label30)
        Me.GroupBox21.Controls.Add(Me.btnResetSmallKlock)
        Me.GroupBox21.Controls.Add(Me.Label26)
        Me.GroupBox21.Controls.Add(Me.Label25)
        Me.GroupBox21.Controls.Add(Me.Label24)
        Me.GroupBox21.Controls.Add(Me.btnSmlTxtKlckBckClr)
        Me.GroupBox21.Controls.Add(Me.btnSmlTxtKlckOffClr)
        Me.GroupBox21.Controls.Add(Me.btnSmlTxtKlckFrClr)
        Me.GroupBox21.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(322, 253)
        Me.GroupBox21.TabIndex = 0
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Small Text Klock Settings"
        '
        'chckBxSmlTxKlockSavePos
        '
        Me.chckBxSmlTxKlockSavePos.AutoSize = True
        Me.chckBxSmlTxKlockSavePos.Location = New System.Drawing.Point(43, 141)
        Me.chckBxSmlTxKlockSavePos.Name = "chckBxSmlTxKlockSavePos"
        Me.chckBxSmlTxKlockSavePos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxSmlTxKlockSavePos.Size = New System.Drawing.Size(163, 17)
        Me.chckBxSmlTxKlockSavePos.TabIndex = 11
        Me.chckBxSmlTxKlockSavePos.Text = "Save Screen Position on Exit"
        Me.chckBxSmlTxKlockSavePos.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 105)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(114, 13)
        Me.Label30.TabIndex = 7
        Me.Label30.Text = "Reset colour to default"
        '
        'btnResetSmallKlock
        '
        Me.btnResetSmallKlock.Location = New System.Drawing.Point(131, 100)
        Me.btnResetSmallKlock.Name = "btnResetSmallKlock"
        Me.btnResetSmallKlock.Size = New System.Drawing.Size(75, 23)
        Me.btnResetSmallKlock.TabIndex = 6
        Me.btnResetSmallKlock.Text = "Reset"
        Me.btnResetSmallKlock.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Change off colour"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 52)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 13)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Change back colour"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 13)
        Me.Label24.TabIndex = 3
        Me.Label24.Text = "Change fore colour"
        '
        'btnSmlTxtKlckBckClr
        '
        Me.btnSmlTxtKlckBckClr.Location = New System.Drawing.Point(131, 45)
        Me.btnSmlTxtKlckBckClr.Name = "btnSmlTxtKlckBckClr"
        Me.btnSmlTxtKlckBckClr.Size = New System.Drawing.Size(75, 23)
        Me.btnSmlTxtKlckBckClr.TabIndex = 2
        Me.btnSmlTxtKlckBckClr.Text = "..."
        Me.btnSmlTxtKlckBckClr.UseVisualStyleBackColor = True
        '
        'btnSmlTxtKlckOffClr
        '
        Me.btnSmlTxtKlckOffClr.Location = New System.Drawing.Point(131, 71)
        Me.btnSmlTxtKlckOffClr.Name = "btnSmlTxtKlckOffClr"
        Me.btnSmlTxtKlckOffClr.Size = New System.Drawing.Size(75, 23)
        Me.btnSmlTxtKlckOffClr.TabIndex = 1
        Me.btnSmlTxtKlckOffClr.Text = "..."
        Me.btnSmlTxtKlckOffClr.UseVisualStyleBackColor = True
        '
        'btnSmlTxtKlckFrClr
        '
        Me.btnSmlTxtKlckFrClr.Location = New System.Drawing.Point(131, 19)
        Me.btnSmlTxtKlckFrClr.Name = "btnSmlTxtKlckFrClr"
        Me.btnSmlTxtKlckFrClr.Size = New System.Drawing.Size(75, 23)
        Me.btnSmlTxtKlckFrClr.TabIndex = 0
        Me.btnSmlTxtKlckFrClr.Text = "..."
        Me.btnSmlTxtKlckFrClr.UseVisualStyleBackColor = True
        '
        'tbPgOtherStuff
        '
        Me.tbPgOtherStuff.BackColor = System.Drawing.SystemColors.Control
        Me.tbPgOtherStuff.Controls.Add(Me.GroupBox20)
        Me.tbPgOtherStuff.Controls.Add(Me.GroupBox19)
        Me.tbPgOtherStuff.Controls.Add(Me.GroupBox5)
        Me.tbPgOtherStuff.Controls.Add(Me.GroupBox4)
        Me.tbPgOtherStuff.Controls.Add(Me.GroupBox9)
        Me.tbPgOtherStuff.Controls.Add(Me.GroupBox12)
        Me.tbPgOtherStuff.Location = New System.Drawing.Point(4, 25)
        Me.tbPgOtherStuff.Name = "tbPgOtherStuff"
        Me.tbPgOtherStuff.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPgOtherStuff.Size = New System.Drawing.Size(660, 265)
        Me.tbPgOtherStuff.TabIndex = 7
        Me.tbPgOtherStuff.Text = "Other Stuff"
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.chckBxChckInternet)
        Me.GroupBox20.Location = New System.Drawing.Point(9, 212)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(645, 41)
        Me.GroupBox20.TabIndex = 4
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Internet"
        '
        'chckBxChckInternet
        '
        Me.chckBxChckInternet.AutoSize = True
        Me.chckBxChckInternet.Location = New System.Drawing.Point(49, 18)
        Me.chckBxChckInternet.Name = "chckBxChckInternet"
        Me.chckBxChckInternet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxChckInternet.Size = New System.Drawing.Size(172, 17)
        Me.chckBxChckInternet.TabIndex = 0
        Me.chckBxChckInternet.Text = "Check for Internet Connectivity"
        Me.chckBxChckInternet.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.chckBxDisableMonitorSleep)
        Me.GroupBox19.Location = New System.Drawing.Point(9, 165)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(645, 41)
        Me.GroupBox19.TabIndex = 3
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Monitor"
        '
        'chckBxDisableMonitorSleep
        '
        Me.chckBxDisableMonitorSleep.AutoSize = True
        Me.chckBxDisableMonitorSleep.Location = New System.Drawing.Point(49, 18)
        Me.chckBxDisableMonitorSleep.Name = "chckBxDisableMonitorSleep"
        Me.chckBxDisableMonitorSleep.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxDisableMonitorSleep.Size = New System.Drawing.Size(172, 17)
        Me.chckBxDisableMonitorSleep.TabIndex = 0
        Me.chckBxDisableMonitorSleep.Text = "Disable Monitor Going to Sleep"
        Me.chckBxDisableMonitorSleep.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chckBxReminderAdd)
        Me.GroupBox5.Controls.Add(Me.chckBxReminderTimeCheck)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 112)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(648, 47)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Reminder Settings"
        '
        'chckBxReminderAdd
        '
        Me.chckBxReminderAdd.AutoSize = True
        Me.chckBxReminderAdd.Location = New System.Drawing.Point(19, 19)
        Me.chckBxReminderAdd.Name = "chckBxReminderAdd"
        Me.chckBxReminderAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxReminderAdd.Size = New System.Drawing.Size(205, 17)
        Me.chckBxReminderAdd.TabIndex = 1
        Me.chckBxReminderAdd.Text = "Add Reminder to Notification and Title"
        Me.chckBxReminderAdd.UseVisualStyleBackColor = True
        '
        'chckBxReminderTimeCheck
        '
        Me.chckBxReminderTimeCheck.AutoSize = True
        Me.chckBxReminderTimeCheck.Location = New System.Drawing.Point(292, 19)
        Me.chckBxReminderTimeCheck.Name = "chckBxReminderTimeCheck"
        Me.chckBxReminderTimeCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxReminderTimeCheck.Size = New System.Drawing.Size(94, 17)
        Me.chckBxReminderTimeCheck.TabIndex = 0
        Me.chckBxReminderTimeCheck.Text = "Time checked"
        Me.chckBxReminderTimeCheck.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chckBxTimerAdd)
        Me.GroupBox4.Controls.Add(Me.chckBxTimerHigh)
        Me.GroupBox4.Controls.Add(Me.chckBxClearSplit)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 59)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(648, 47)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Timer Settings"
        '
        'chckBxTimerAdd
        '
        Me.chckBxTimerAdd.AutoSize = True
        Me.chckBxTimerAdd.Location = New System.Drawing.Point(38, 19)
        Me.chckBxTimerAdd.Name = "chckBxTimerAdd"
        Me.chckBxTimerAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimerAdd.Size = New System.Drawing.Size(186, 17)
        Me.chckBxTimerAdd.TabIndex = 2
        Me.chckBxTimerAdd.Text = "Add Timer to Notification and Title"
        Me.chckBxTimerAdd.UseVisualStyleBackColor = True
        '
        'chckBxTimerHigh
        '
        Me.chckBxTimerHigh.AutoSize = True
        Me.chckBxTimerHigh.Location = New System.Drawing.Point(431, 19)
        Me.chckBxTimerHigh.Name = "chckBxTimerHigh"
        Me.chckBxTimerHigh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimerHigh.Size = New System.Drawing.Size(154, 17)
        Me.chckBxTimerHigh.TabIndex = 0
        Me.chckBxTimerHigh.Text = "Timer to show MilliSeconds"
        Me.chckBxTimerHigh.UseVisualStyleBackColor = True
        '
        'chckBxClearSplit
        '
        Me.chckBxClearSplit.AutoSize = True
        Me.chckBxClearSplit.Location = New System.Drawing.Point(277, 19)
        Me.chckBxClearSplit.Name = "chckBxClearSplit"
        Me.chckBxClearSplit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxClearSplit.Size = New System.Drawing.Size(109, 17)
        Me.chckBxClearSplit.TabIndex = 1
        Me.chckBxClearSplit.Text = "Clear to clear split"
        Me.chckBxClearSplit.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.chckBxCountdownAdd)
        Me.GroupBox9.Location = New System.Drawing.Point(334, 6)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(320, 47)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Countdown Settings"
        '
        'chckBxCountdownAdd
        '
        Me.chckBxCountdownAdd.AutoSize = True
        Me.chckBxCountdownAdd.Location = New System.Drawing.Point(10, 19)
        Me.chckBxCountdownAdd.Name = "chckBxCountdownAdd"
        Me.chckBxCountdownAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxCountdownAdd.Size = New System.Drawing.Size(214, 17)
        Me.chckBxCountdownAdd.TabIndex = 0
        Me.chckBxCountdownAdd.Text = "Add Countdown to Notification and Title"
        Me.chckBxCountdownAdd.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.chckBxWorldKlockAdd)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(320, 47)
        Me.GroupBox12.TabIndex = 0
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "World KlockSettings"
        '
        'chckBxWorldKlockAdd
        '
        Me.chckBxWorldKlockAdd.AutoSize = True
        Me.chckBxWorldKlockAdd.Location = New System.Drawing.Point(6, 19)
        Me.chckBxWorldKlockAdd.Name = "chckBxWorldKlockAdd"
        Me.chckBxWorldKlockAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxWorldKlockAdd.Size = New System.Drawing.Size(218, 17)
        Me.chckBxWorldKlockAdd.TabIndex = 0
        Me.chckBxWorldKlockAdd.Text = "Add World Klock to Notification and Title"
        Me.chckBxWorldKlockAdd.UseVisualStyleBackColor = True
        '
        'tbPgArchive
        '
        Me.tbPgArchive.BackColor = System.Drawing.SystemColors.Control
        Me.tbPgArchive.Controls.Add(Me.GroupBox11)
        Me.tbPgArchive.Controls.Add(Me.GroupBox10)
        Me.tbPgArchive.Location = New System.Drawing.Point(4, 25)
        Me.tbPgArchive.Name = "tbPgArchive"
        Me.tbPgArchive.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPgArchive.Size = New System.Drawing.Size(660, 265)
        Me.tbPgArchive.TabIndex = 6
        Me.tbPgArchive.Text = "Archive"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtBxArchiveFile)
        Me.GroupBox11.Controls.Add(Me.txtBxArchiveDirectory)
        Me.GroupBox11.Controls.Add(Me.btnArchiveFile)
        Me.GroupBox11.Controls.Add(Me.btnArchiveDirectory)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 204)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(648, 53)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Archive Location"
        '
        'txtBxArchiveFile
        '
        Me.txtBxArchiveFile.Location = New System.Drawing.Point(434, 22)
        Me.txtBxArchiveFile.Name = "txtBxArchiveFile"
        Me.txtBxArchiveFile.ReadOnly = True
        Me.txtBxArchiveFile.Size = New System.Drawing.Size(117, 20)
        Me.txtBxArchiveFile.TabIndex = 3
        '
        'txtBxArchiveDirectory
        '
        Me.txtBxArchiveDirectory.Location = New System.Drawing.Point(6, 19)
        Me.txtBxArchiveDirectory.Name = "txtBxArchiveDirectory"
        Me.txtBxArchiveDirectory.ReadOnly = True
        Me.txtBxArchiveDirectory.Size = New System.Drawing.Size(341, 20)
        Me.txtBxArchiveDirectory.TabIndex = 2
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
        Me.GroupBox10.Controls.Add(Me.txtBxOptionsSettingsFile)
        Me.GroupBox10.Controls.Add(Me.txtBxOptionsMemoFile)
        Me.GroupBox10.Controls.Add(Me.Label22)
        Me.GroupBox10.Controls.Add(Me.btnOptionsMemoFile)
        Me.GroupBox10.Controls.Add(Me.label18)
        Me.GroupBox10.Controls.Add(Me.btnOptionsEventsFile)
        Me.GroupBox10.Controls.Add(Me.txtBxOptionsEventsFile)
        Me.GroupBox10.Controls.Add(Me.Label13)
        Me.GroupBox10.Controls.Add(Me.Label12)
        Me.GroupBox10.Controls.Add(Me.Label11)
        Me.GroupBox10.Controls.Add(Me.Label7)
        Me.GroupBox10.Controls.Add(Me.btnOptionsPathReset)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsFile)
        Me.GroupBox10.Controls.Add(Me.txtBxOptionsFriendsFile)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsDirectory)
        Me.GroupBox10.Controls.Add(Me.txtBxOptionsFriendsDirectory)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(648, 192)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Data Files"
        '
        'txtBxOptionsSettingsFile
        '
        Me.txtBxOptionsSettingsFile.Location = New System.Drawing.Point(434, 164)
        Me.txtBxOptionsSettingsFile.Name = "txtBxOptionsSettingsFile"
        Me.txtBxOptionsSettingsFile.ReadOnly = True
        Me.txtBxOptionsSettingsFile.Size = New System.Drawing.Size(117, 20)
        Me.txtBxOptionsSettingsFile.TabIndex = 19
        '
        'txtBxOptionsMemoFile
        '
        Me.txtBxOptionsMemoFile.Location = New System.Drawing.Point(434, 121)
        Me.txtBxOptionsMemoFile.Name = "txtBxOptionsMemoFile"
        Me.txtBxOptionsMemoFile.ReadOnly = True
        Me.txtBxOptionsMemoFile.Size = New System.Drawing.Size(117, 20)
        Me.txtBxOptionsMemoFile.TabIndex = 18
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
        'txtBxOptionsEventsFile
        '
        Me.txtBxOptionsEventsFile.Location = New System.Drawing.Point(434, 78)
        Me.txtBxOptionsEventsFile.Name = "txtBxOptionsEventsFile"
        Me.txtBxOptionsEventsFile.ReadOnly = True
        Me.txtBxOptionsEventsFile.Size = New System.Drawing.Size(117, 20)
        Me.txtBxOptionsEventsFile.TabIndex = 12
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
        'txtBxOptionsFriendsFile
        '
        Me.txtBxOptionsFriendsFile.Location = New System.Drawing.Point(434, 35)
        Me.txtBxOptionsFriendsFile.Name = "txtBxOptionsFriendsFile"
        Me.txtBxOptionsFriendsFile.ReadOnly = True
        Me.txtBxOptionsFriendsFile.Size = New System.Drawing.Size(117, 20)
        Me.txtBxOptionsFriendsFile.TabIndex = 2
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
        'txtBxOptionsFriendsDirectory
        '
        Me.txtBxOptionsFriendsDirectory.Location = New System.Drawing.Point(6, 36)
        Me.txtBxOptionsFriendsDirectory.Name = "txtBxOptionsFriendsDirectory"
        Me.txtBxOptionsFriendsDirectory.ReadOnly = True
        Me.txtBxOptionsFriendsDirectory.Size = New System.Drawing.Size(341, 20)
        Me.txtBxOptionsFriendsDirectory.TabIndex = 0
        '
        'tbPgEvents
        '
        Me.tbPgEvents.Controls.Add(Me.GroupBox14)
        Me.tbPgEvents.Location = New System.Drawing.Point(4, 25)
        Me.tbPgEvents.Name = "tbPgEvents"
        Me.tbPgEvents.Size = New System.Drawing.Size(660, 265)
        Me.tbPgEvents.TabIndex = 8
        Me.tbPgEvents.Text = "Events"
        Me.tbPgEvents.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.pctrBxThirdEvent)
        Me.GroupBox14.Controls.Add(Me.btnThirdEventNotificationColour)
        Me.GroupBox14.Controls.Add(Me.pctrBxSecondEvent)
        Me.GroupBox14.Controls.Add(Me.btnSecondEventNotificationColour)
        Me.GroupBox14.Controls.Add(Me.pctrBxFirstEvent)
        Me.GroupBox14.Controls.Add(Me.btnFirstEventNotificationColour)
        Me.GroupBox14.Controls.Add(Me.Label17)
        Me.GroupBox14.Controls.Add(Me.Label16)
        Me.GroupBox14.Controls.Add(Me.Label15)
        Me.GroupBox14.Controls.Add(Me.Label14)
        Me.GroupBox14.Controls.Add(Me.lblEventsInterval)
        Me.GroupBox14.Controls.Add(Me.nmrcUpDwnEventsInterval)
        Me.GroupBox14.Controls.Add(Me.nmrcUpDwnThirdReminder)
        Me.GroupBox14.Controls.Add(Me.nmrcUpDwnSecondReminder)
        Me.GroupBox14.Controls.Add(Me.nmrcUpDwnFirstReminder)
        Me.GroupBox14.Controls.Add(Me.lblThirdReminder)
        Me.GroupBox14.Controls.Add(Me.lblSecondReminder)
        Me.GroupBox14.Controls.Add(Me.lblFirstreminder)
        Me.GroupBox14.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(653, 253)
        Me.GroupBox14.TabIndex = 0
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Events Settings"
        '
        'pctrBxThirdEvent
        '
        Me.pctrBxThirdEvent.Location = New System.Drawing.Point(316, 90)
        Me.pctrBxThirdEvent.Name = "pctrBxThirdEvent"
        Me.pctrBxThirdEvent.Size = New System.Drawing.Size(50, 23)
        Me.pctrBxThirdEvent.TabIndex = 21
        Me.pctrBxThirdEvent.TabStop = False
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
        'pctrBxSecondEvent
        '
        Me.pctrBxSecondEvent.Location = New System.Drawing.Point(316, 62)
        Me.pctrBxSecondEvent.Name = "pctrBxSecondEvent"
        Me.pctrBxSecondEvent.Size = New System.Drawing.Size(50, 23)
        Me.pctrBxSecondEvent.TabIndex = 18
        Me.pctrBxSecondEvent.TabStop = False
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
        'pctrBxFirstEvent
        '
        Me.pctrBxFirstEvent.Location = New System.Drawing.Point(316, 33)
        Me.pctrBxFirstEvent.Name = "pctrBxFirstEvent"
        Me.pctrBxFirstEvent.Size = New System.Drawing.Size(50, 23)
        Me.pctrBxFirstEvent.TabIndex = 15
        Me.pctrBxFirstEvent.TabStop = False
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
        'nmrcUpDwnEventsInterval
        '
        Me.nmrcUpDwnEventsInterval.Location = New System.Drawing.Point(136, 126)
        Me.nmrcUpDwnEventsInterval.Name = "nmrcUpDwnEventsInterval"
        Me.nmrcUpDwnEventsInterval.Size = New System.Drawing.Size(46, 20)
        Me.nmrcUpDwnEventsInterval.TabIndex = 6
        Me.nmrcUpDwnEventsInterval.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'nmrcUpDwnThirdReminder
        '
        Me.nmrcUpDwnThirdReminder.Location = New System.Drawing.Point(136, 83)
        Me.nmrcUpDwnThirdReminder.Name = "nmrcUpDwnThirdReminder"
        Me.nmrcUpDwnThirdReminder.Size = New System.Drawing.Size(46, 20)
        Me.nmrcUpDwnThirdReminder.TabIndex = 5
        Me.nmrcUpDwnThirdReminder.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'nmrcUpDwnSecondReminder
        '
        Me.nmrcUpDwnSecondReminder.Location = New System.Drawing.Point(136, 57)
        Me.nmrcUpDwnSecondReminder.Name = "nmrcUpDwnSecondReminder"
        Me.nmrcUpDwnSecondReminder.Size = New System.Drawing.Size(46, 20)
        Me.nmrcUpDwnSecondReminder.TabIndex = 4
        Me.nmrcUpDwnSecondReminder.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'nmrcUpDwnFirstReminder
        '
        Me.nmrcUpDwnFirstReminder.Location = New System.Drawing.Point(136, 31)
        Me.nmrcUpDwnFirstReminder.Name = "nmrcUpDwnFirstReminder"
        Me.nmrcUpDwnFirstReminder.Size = New System.Drawing.Size(46, 20)
        Me.nmrcUpDwnFirstReminder.TabIndex = 3
        Me.nmrcUpDwnFirstReminder.Value = New Decimal(New Integer() {31, 0, 0, 0})
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
        'tbPgMemo
        '
        Me.tbPgMemo.Controls.Add(Me.GroupBox16)
        Me.tbPgMemo.Location = New System.Drawing.Point(4, 25)
        Me.tbPgMemo.Name = "tbPgMemo"
        Me.tbPgMemo.Size = New System.Drawing.Size(660, 265)
        Me.tbPgMemo.TabIndex = 9
        Me.tbPgMemo.Text = "Memo"
        Me.tbPgMemo.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.nmrcUpDwnMemoDecrypt)
        Me.GroupBox16.Controls.Add(Me.Label23)
        Me.GroupBox16.Controls.Add(Me.txtBxMemoDefaultPassword)
        Me.GroupBox16.Controls.Add(Me.chckBxMemoDefaultPassword)
        Me.GroupBox16.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(653, 253)
        Me.GroupBox16.TabIndex = 0
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Memo Settings"
        '
        'nmrcUpDwnMemoDecrypt
        '
        Me.nmrcUpDwnMemoDecrypt.Location = New System.Drawing.Point(255, 63)
        Me.nmrcUpDwnMemoDecrypt.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nmrcUpDwnMemoDecrypt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nmrcUpDwnMemoDecrypt.Name = "nmrcUpDwnMemoDecrypt"
        Me.nmrcUpDwnMemoDecrypt.Size = New System.Drawing.Size(46, 20)
        Me.nmrcUpDwnMemoDecrypt.TabIndex = 4
        Me.nmrcUpDwnMemoDecrypt.Value = New Decimal(New Integer() {30, 0, 0, 0})
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
        'txtBxMemoDefaultPassword
        '
        Me.txtBxMemoDefaultPassword.Enabled = False
        Me.txtBxMemoDefaultPassword.Location = New System.Drawing.Point(255, 18)
        Me.txtBxMemoDefaultPassword.Name = "txtBxMemoDefaultPassword"
        Me.txtBxMemoDefaultPassword.ReadOnly = True
        Me.txtBxMemoDefaultPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtBxMemoDefaultPassword.TabIndex = 2
        Me.txtBxMemoDefaultPassword.Text = "klock"
        '
        'chckBxMemoDefaultPassword
        '
        Me.chckBxMemoDefaultPassword.AutoSize = True
        Me.chckBxMemoDefaultPassword.Location = New System.Drawing.Point(92, 21)
        Me.chckBxMemoDefaultPassword.Name = "chckBxMemoDefaultPassword"
        Me.chckBxMemoDefaultPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxMemoDefaultPassword.Size = New System.Drawing.Size(131, 17)
        Me.chckBxMemoDefaultPassword.TabIndex = 0
        Me.chckBxMemoDefaultPassword.Text = "Use Default Password"
        Me.chckBxMemoDefaultPassword.UseVisualStyleBackColor = True
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
        Me.OpenFileDialog1.FileName = "openFileDialog"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 357)
        Me.Controls.Add(Me.btnArchiveLoad)
        Me.Controls.Add(Me.btnOptionsCancel)
        Me.Controls.Add(Me.btnArchiveSave)
        Me.Controls.Add(Me.tbCntrlOptions)
        Me.Controls.Add(Me.btnOptionsClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.tbCntrlOptions.ResumeLayout(False)
        Me.tbPgGlobal.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.trckBrOptionsVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPgNotification.ResumeLayout(False)
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox25.PerformLayout()
        CType(Me.nmrcUpDwnSayingDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnSayingNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnSayingNotificationTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.nmrcUpDwnEventNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.nmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPgTime.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.upDwnVoiceDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnTimeDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbPgAnalogueKlock.ResumeLayout(False)
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        CType(Me.pctrBxAnlgKlockPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        Me.tbPgTextKlock.ResumeLayout(False)
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.tbPgOtherStuff.ResumeLayout(False)
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
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
        Me.tbPgArchive.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.tbPgEvents.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.pctrBxThirdEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctrBxSecondEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctrBxFirstEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnEventsInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnThirdReminder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnSecondReminder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmrcUpDwnFirstReminder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPgMemo.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        CType(Me.nmrcUpDwnMemoDecrypt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOptionsClose As System.Windows.Forms.Button
    Friend WithEvents clrDlgFormColour As System.Windows.Forms.ColorDialog
    Friend WithEvents btnOptionsFormColour As System.Windows.Forms.Button
    Friend WithEvents lblColour As System.Windows.Forms.Label
    Friend WithEvents btnOptionsFormFont As System.Windows.Forms.Button
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents fntDlgFont As System.Windows.Forms.FontDialog
    Friend WithEvents chckBxOptionsSavePos As System.Windows.Forms.CheckBox
    Friend WithEvents btnDefaultColour As System.Windows.Forms.Button
    Friend WithEvents lblDefaultColour As System.Windows.Forms.Label
    Friend WithEvents tbCntrlOptions As System.Windows.Forms.TabControl
    Friend WithEvents tbPgGlobal As System.Windows.Forms.TabPage
    Friend WithEvents tbPgTime As System.Windows.Forms.TabPage
    Friend WithEvents chckBxTimeSwatch As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeNetSeconds As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeHourPips As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeToast As System.Windows.Forms.CheckBox
    Friend WithEvents tbPgNotification As System.Windows.Forms.TabPage
    Friend WithEvents nmrcUpDwnNotificationTimeOut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNotificationFont As System.Windows.Forms.Button
    Friend WithEvents btnNotificationColour As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nmrcUpDwnNotificationOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNotificationTest As System.Windows.Forms.Button
    Friend WithEvents btnOptionsCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxTimeHourlyChimes As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeQuarterChimes As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeHalfChimes As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptionsTestVolume As System.Windows.Forms.Button
    Friend WithEvents trckBrOptionsVolume As System.Windows.Forms.TrackBar
    Friend WithEvents upDwnTimeDisplay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chckBxOptionsRunOnStartup As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxOptionsStartupMinimised As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents tbPgArchive As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptionsFriendsFile As System.Windows.Forms.Button
    Friend WithEvents txtBxOptionsFriendsFile As System.Windows.Forms.TextBox
    Friend WithEvents btnOptionsFriendsDirectory As System.Windows.Forms.Button
    Friend WithEvents txtBxOptionsFriendsDirectory As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOptionsPathReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxTimeHexIntuitor As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeTwoFormats As System.Windows.Forms.CheckBox
    Friend WithEvents tbPgOtherStuff As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxReminderAdd As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxReminderTimeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxTimerAdd As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimerHigh As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxClearSplit As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxCountdownAdd As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxWorldKlockAdd As System.Windows.Forms.CheckBox
    Private WithEvents chckBxOptionsVoice As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents upDwnVoiceDisplay As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOptionSavepath As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSettingsReset As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBxArchiveFile As System.Windows.Forms.TextBox
    Friend WithEvents txtBxArchiveDirectory As System.Windows.Forms.TextBox
    Friend WithEvents btnArchiveFile As System.Windows.Forms.Button
    Friend WithEvents btnArchiveDirectory As System.Windows.Forms.Button
    Friend WithEvents btnArchiveLoad As System.Windows.Forms.Button
    Friend WithEvents btnArchiveSave As System.Windows.Forms.Button
    Friend WithEvents btnOptionsEventsFile As System.Windows.Forms.Button
    Friend WithEvents txtBxOptionsEventsFile As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbPgEvents As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents lblThirdReminder As System.Windows.Forms.Label
    Friend WithEvents lblSecondReminder As System.Windows.Forms.Label
    Friend WithEvents lblFirstreminder As System.Windows.Forms.Label
    Friend WithEvents nmrcUpDwnThirdReminder As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmrcUpDwnSecondReminder As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmrcUpDwnFirstReminder As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblEventsInterval As System.Windows.Forms.Label
    Friend WithEvents nmrcUpDwnEventsInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents nmrcUpDwnEventNotificationOpacity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnEventNotificationFont As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents pctrBxThirdEvent As System.Windows.Forms.PictureBox
    Friend WithEvents btnThirdEventNotificationColour As System.Windows.Forms.Button
    Friend WithEvents pctrBxSecondEvent As System.Windows.Forms.PictureBox
    Friend WithEvents btnSecondEventNotificationColour As System.Windows.Forms.Button
    Friend WithEvents pctrBxFirstEvent As System.Windows.Forms.PictureBox
    Friend WithEvents btnFirstEventNotificationColour As System.Windows.Forms.Button
    Friend WithEvents btnEventNotificationTest As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbBxDefaultTimeFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblTimeTwo As System.Windows.Forms.Label
    Friend WithEvents cmbBxDefaultTimeTwoFormat As System.Windows.Forms.ComboBox
    Friend WithEvents txtBxOptionsMemoFile As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnOptionsMemoFile As System.Windows.Forms.Button
    Friend WithEvents txtBxOptionsSettingsFile As System.Windows.Forms.TextBox
    Friend WithEvents tbPgMemo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBxMemoDefaultPassword As System.Windows.Forms.TextBox
    Friend WithEvents chckBxMemoDefaultPassword As System.Windows.Forms.CheckBox
    Friend WithEvents nmrcUpDwnMemoDecrypt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBxDefaultTab As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents chckBxTimeTimeTwo12 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeTimeOne12 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeSystem12 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeTimeTwo24 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeTimeOne24 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeSystem24 As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxIdleTime As CheckBox
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents chckBxDisableMonitorSleep As CheckBox
    Friend WithEvents GroupBox20 As GroupBox
    Friend WithEvents chckBxChckInternet As CheckBox
    Friend WithEvents tbPgTextKlock As TabPage
    Friend WithEvents GroupBox22 As GroupBox
    Friend WithEvents GroupBox21 As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents btnBgTxtKlckBckClr As Button
    Friend WithEvents btnBgTxtKlckOffClr As Button
    Friend WithEvents btnBgTxtKlckFrClr As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents btnSmlTxtKlckBckClr As Button
    Friend WithEvents btnSmlTxtKlckOffClr As Button
    Friend WithEvents btnSmlTxtKlckFrClr As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents btnResetBigKlock As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents btnResetSmallKlock As Button
    Friend WithEvents tbPgAnalogueKlock As TabPage
    Friend WithEvents GroupBox23 As GroupBox
    Friend WithEvents chckBxAnlgKlockTime As CheckBox
    Friend WithEvents chckBxAnlgKlockDate As CheckBox
    Friend WithEvents txtBxAnlgKlock As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents btnAnlgKlockBackColour As Button
    Friend WithEvents lblAnlgKlockBackColour As Label
    Friend WithEvents chckBxAnlgKlockTransparent As CheckBox
    Friend WithEvents txtBxAnlgKlockPictureLocation As TextBox
    Friend WithEvents btnAnlgKlockPictureLocation As Button
    Friend WithEvents pctrBxAnlgKlockPicture As PictureBox
    Friend WithEvents chckBxAnlgKlockSavePos As CheckBox
    Friend WithEvents chckBxBgTxKlockSavePos As CheckBox
    Friend WithEvents chckBxSmlTxKlockSavePos As CheckBox
    Friend WithEvents GroupBox24 As GroupBox
    Friend WithEvents chckBxAnlgKlockDisplayPicture As CheckBox
    Friend WithEvents GroupBox25 As GroupBox
    Friend WithEvents lblSayings1 As Label
    Friend WithEvents btnSayingNotificationTest As Button
    Friend WithEvents btnSayingNotificationColour As Button
    Friend WithEvents lblSayings5 As Label
    Friend WithEvents nmrcUpDwnSayingNotificationOpacity As NumericUpDown
    Friend WithEvents lblSayings2 As Label
    Friend WithEvents btnSayingNotificationFont As Button
    Friend WithEvents lblSayings4 As Label
    Friend WithEvents nmrcUpDwnSayingNotificationTimeOut As NumericUpDown
    Friend WithEvents lblSayings3 As Label
    Friend WithEvents nmrcUpDwnSayingDisplay As NumericUpDown
    Friend WithEvents ChckBxSayings As CheckBox
End Class
