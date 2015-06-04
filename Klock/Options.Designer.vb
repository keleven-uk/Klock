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
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
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
        Me.TbPgFriends = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.btnarchiveFriendsLoad = New System.Windows.Forms.Button()
        Me.btnarchiveFriendsSave = New System.Windows.Forms.Button()
        Me.TxtBxarchiveFriendsFile = New System.Windows.Forms.TextBox()
        Me.TxtBxarchiveFriendsDirectory = New System.Windows.Forms.TextBox()
        Me.btnarchiveFriendsFile = New System.Windows.Forms.Button()
        Me.btnarchiveFriendsDirectory = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.lblOptionsSettingsDirectory = New System.Windows.Forms.Label()
        Me.lblOptionsSettingsFile = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOptionsFriendsPathReset = New System.Windows.Forms.Button()
        Me.btnOptionsFriendsFile = New System.Windows.Forms.Button()
        Me.TxtBxOptionsFriendsFile = New System.Windows.Forms.TextBox()
        Me.btnOptionsFriendsDirectory = New System.Windows.Forms.Button()
        Me.TxtBxOptionsFriendsDirectory = New System.Windows.Forms.TextBox()
        Me.btnOptionsCancel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabCntrlOptions.SuspendLayout()
        Me.TbPgGlobal.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrckBrOptionsVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgNotification.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.NmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgTime.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.UpDwnVoiceDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDwnTimeDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TbPgOtherStuff.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TbPgFriends.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
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
        Me.ChckBxOptionsSavePos.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        Me.lblDefaultColour.Location = New System.Drawing.Point(15, 70)
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
        Me.TabCntrlOptions.Controls.Add(Me.TbPgFriends)
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
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label10)
        Me.GroupBox13.Controls.Add(Me.btnSettingsReset)
        Me.GroupBox13.Controls.Add(Me.LblOptionSavepath)
        Me.GroupBox13.Controls.Add(Me.Label9)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(417, 97)
        Me.GroupBox13.TabIndex = 13
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Settings"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Reset to system default location"
        '
        'btnSettingsReset
        '
        Me.btnSettingsReset.Location = New System.Drawing.Point(173, 68)
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
        Me.ChckBxOptionsRunOnStartup.Location = New System.Drawing.Point(256, 31)
        Me.ChckBxOptionsRunOnStartup.Name = "ChckBxOptionsRunOnStartup"
        Me.ChckBxOptionsRunOnStartup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChckBxOptionsRunOnStartup.Size = New System.Drawing.Size(175, 17)
        Me.ChckBxOptionsRunOnStartup.TabIndex = 9
        Me.ChckBxOptionsRunOnStartup.Text = "Run Klock on Windows Startup"
        Me.ChckBxOptionsRunOnStartup.UseVisualStyleBackColor = True
        '
        'ChckBxOptionsStartupMinimised
        '
        Me.ChckBxOptionsStartupMinimised.AutoSize = True
        Me.ChckBxOptionsStartupMinimised.Location = New System.Drawing.Point(486, 31)
        Me.ChckBxOptionsStartupMinimised.Name = "ChckBxOptionsStartupMinimised"
        Me.ChckBxOptionsStartupMinimised.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        Me.TbPgNotification.Controls.Add(Me.GroupBox6)
        Me.TbPgNotification.Location = New System.Drawing.Point(4, 25)
        Me.TbPgNotification.Name = "TbPgNotification"
        Me.TbPgNotification.Size = New System.Drawing.Size(660, 265)
        Me.TbPgNotification.TabIndex = 3
        Me.TbPgNotification.Text = "Notification"
        '
        'GroupBox6
        '
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
        Me.GroupBox6.Size = New System.Drawing.Size(653, 253)
        Me.GroupBox6.TabIndex = 9
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Appearance"
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
        Me.TbPgTime.Controls.Add(Me.GroupBox3)
        Me.TbPgTime.Controls.Add(Me.GroupBox1)
        Me.TbPgTime.Location = New System.Drawing.Point(4, 25)
        Me.TbPgTime.Name = "TbPgTime"
        Me.TbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgTime.Size = New System.Drawing.Size(660, 265)
        Me.TbPgTime.TabIndex = 1
        Me.TbPgTime.Text = "Time"
        '
        'GroupBox3
        '
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
        Me.GroupBox3.Size = New System.Drawing.Size(648, 125)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Settings"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(79, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Time to speech [every "
        '
        'UpDwnVoiceDisplay
        '
        Me.UpDwnVoiceDisplay.Location = New System.Drawing.Point(202, 62)
        Me.UpDwnVoiceDisplay.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.UpDwnVoiceDisplay.Name = "UpDwnVoiceDisplay"
        Me.UpDwnVoiceDisplay.Size = New System.Drawing.Size(38, 20)
        Me.UpDwnVoiceDisplay.TabIndex = 10
        Me.UpDwnVoiceDisplay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'ChckBxOptionsVoice
        '
        Me.ChckBxOptionsVoice.AutoSize = True
        Me.ChckBxOptionsVoice.Location = New System.Drawing.Point(249, 63)
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
        Me.chckBxTimeTwoFormats.Location = New System.Drawing.Point(149, 14)
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
        Me.ChckBxTimeHexIntuitor.Location = New System.Drawing.Point(321, 39)
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
        Me.ChckBxTimeNetSeconds.Location = New System.Drawing.Point(417, 14)
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
        Me.Label6.Location = New System.Drawing.Point(22, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Display Time in System Tray [every "
        '
        'chckBxTimeSwatch
        '
        Me.chckBxTimeSwatch.AutoSize = True
        Me.chckBxTimeSwatch.Location = New System.Drawing.Point(423, 63)
        Me.chckBxTimeSwatch.Name = "chckBxTimeSwatch"
        Me.chckBxTimeSwatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeSwatch.Size = New System.Drawing.Size(188, 17)
        Me.chckBxTimeSwatch.TabIndex = 0
        Me.chckBxTimeSwatch.Text = "Swatch Time to display Centibeats"
        Me.chckBxTimeSwatch.UseVisualStyleBackColor = True
        '
        'UpDwnTimeDisplay
        '
        Me.UpDwnTimeDisplay.Location = New System.Drawing.Point(202, 36)
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
        Me.ChckBxTimeToast.Location = New System.Drawing.Point(246, 37)
        Me.ChckBxTimeToast.Name = "ChckBxTimeToast"
        Me.ChckBxTimeToast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeToast.Size = New System.Drawing.Size(53, 17)
        Me.ChckBxTimeToast.TabIndex = 3
        Me.ChckBxTimeToast.Text = " [mins"
        Me.ChckBxTimeToast.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHalfChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeQuarterChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHourlyChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHourPips)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 116)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chimes"
        '
        'ChckBxTimeHalfChimes
        '
        Me.ChckBxTimeHalfChimes.AutoSize = True
        Me.ChckBxTimeHalfChimes.Location = New System.Drawing.Point(347, 42)
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
        Me.ChckBxTimeQuarterChimes.Location = New System.Drawing.Point(331, 65)
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
        Me.ChckBxTimeHourlyChimes.Location = New System.Drawing.Point(362, 19)
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
        Me.ChckBxTimeHourPips.Location = New System.Drawing.Point(128, 19)
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
        'TbPgFriends
        '
        Me.TbPgFriends.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgFriends.Controls.Add(Me.GroupBox11)
        Me.TbPgFriends.Controls.Add(Me.GroupBox10)
        Me.TbPgFriends.Location = New System.Drawing.Point(4, 25)
        Me.TbPgFriends.Name = "TbPgFriends"
        Me.TbPgFriends.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgFriends.Size = New System.Drawing.Size(660, 265)
        Me.TbPgFriends.TabIndex = 6
        Me.TbPgFriends.Text = "archive"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.btnarchiveFriendsLoad)
        Me.GroupBox11.Controls.Add(Me.btnarchiveFriendsSave)
        Me.GroupBox11.Controls.Add(Me.TxtBxarchiveFriendsFile)
        Me.GroupBox11.Controls.Add(Me.TxtBxarchiveFriendsDirectory)
        Me.GroupBox11.Controls.Add(Me.btnarchiveFriendsFile)
        Me.GroupBox11.Controls.Add(Me.btnarchiveFriendsDirectory)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 150)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(648, 103)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "archive"
        '
        'btnarchiveFriendsLoad
        '
        Me.btnarchiveFriendsLoad.Enabled = False
        Me.btnarchiveFriendsLoad.Location = New System.Drawing.Point(557, 56)
        Me.btnarchiveFriendsLoad.Name = "btnarchiveFriendsLoad"
        Me.btnarchiveFriendsLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnarchiveFriendsLoad.TabIndex = 5
        Me.btnarchiveFriendsLoad.Text = "Load"
        Me.btnarchiveFriendsLoad.UseVisualStyleBackColor = True
        '
        'btnarchiveFriendsSave
        '
        Me.btnarchiveFriendsSave.Enabled = False
        Me.btnarchiveFriendsSave.Location = New System.Drawing.Point(476, 56)
        Me.btnarchiveFriendsSave.Name = "btnarchiveFriendsSave"
        Me.btnarchiveFriendsSave.Size = New System.Drawing.Size(75, 23)
        Me.btnarchiveFriendsSave.TabIndex = 4
        Me.btnarchiveFriendsSave.Text = "Save"
        Me.btnarchiveFriendsSave.UseVisualStyleBackColor = True
        '
        'TxtBxarchiveFriendsFile
        '
        Me.TxtBxarchiveFriendsFile.Location = New System.Drawing.Point(434, 22)
        Me.TxtBxarchiveFriendsFile.Name = "TxtBxarchiveFriendsFile"
        Me.TxtBxarchiveFriendsFile.ReadOnly = True
        Me.TxtBxarchiveFriendsFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxarchiveFriendsFile.TabIndex = 3
        '
        'TxtBxarchiveFriendsDirectory
        '
        Me.TxtBxarchiveFriendsDirectory.Location = New System.Drawing.Point(6, 20)
        Me.TxtBxarchiveFriendsDirectory.Name = "TxtBxarchiveFriendsDirectory"
        Me.TxtBxarchiveFriendsDirectory.ReadOnly = True
        Me.TxtBxarchiveFriendsDirectory.Size = New System.Drawing.Size(341, 20)
        Me.TxtBxarchiveFriendsDirectory.TabIndex = 2
        '
        'btnarchiveFriendsFile
        '
        Me.btnarchiveFriendsFile.Location = New System.Drawing.Point(557, 20)
        Me.btnarchiveFriendsFile.Name = "btnarchiveFriendsFile"
        Me.btnarchiveFriendsFile.Size = New System.Drawing.Size(75, 23)
        Me.btnarchiveFriendsFile.TabIndex = 1
        Me.btnarchiveFriendsFile.Text = "..."
        Me.btnarchiveFriendsFile.UseVisualStyleBackColor = True
        '
        'btnarchiveFriendsDirectory
        '
        Me.btnarchiveFriendsDirectory.Location = New System.Drawing.Point(353, 20)
        Me.btnarchiveFriendsDirectory.Name = "btnarchiveFriendsDirectory"
        Me.btnarchiveFriendsDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnarchiveFriendsDirectory.TabIndex = 0
        Me.btnarchiveFriendsDirectory.Text = "..."
        Me.btnarchiveFriendsDirectory.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.lblOptionsSettingsDirectory)
        Me.GroupBox10.Controls.Add(Me.lblOptionsSettingsFile)
        Me.GroupBox10.Controls.Add(Me.Label7)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsPathReset)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsFile)
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsFriendsFile)
        Me.GroupBox10.Controls.Add(Me.btnOptionsFriendsDirectory)
        Me.GroupBox10.Controls.Add(Me.TxtBxOptionsFriendsDirectory)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(648, 121)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Data Files"
        '
        'lblOptionsSettingsDirectory
        '
        Me.lblOptionsSettingsDirectory.AutoSize = True
        Me.lblOptionsSettingsDirectory.Location = New System.Drawing.Point(6, 56)
        Me.lblOptionsSettingsDirectory.Name = "lblOptionsSettingsDirectory"
        Me.lblOptionsSettingsDirectory.Size = New System.Drawing.Size(129, 13)
        Me.lblOptionsSettingsDirectory.TabIndex = 7
        Me.lblOptionsSettingsDirectory.Text = "Options Settings Directory"
        '
        'lblOptionsSettingsFile
        '
        Me.lblOptionsSettingsFile.AutoSize = True
        Me.lblOptionsSettingsFile.Location = New System.Drawing.Point(431, 56)
        Me.lblOptionsSettingsFile.Name = "lblOptionsSettingsFile"
        Me.lblOptionsSettingsFile.Size = New System.Drawing.Size(103, 13)
        Me.lblOptionsSettingsFile.TabIndex = 6
        Me.lblOptionsSettingsFile.Text = "Options Settings File"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(146, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Reset path back to Application Folder"
        '
        'btnOptionsFriendsPathReset
        '
        Me.btnOptionsFriendsPathReset.Location = New System.Drawing.Point(353, 92)
        Me.btnOptionsFriendsPathReset.Name = "btnOptionsFriendsPathReset"
        Me.btnOptionsFriendsPathReset.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFriendsPathReset.TabIndex = 4
        Me.btnOptionsFriendsPathReset.Text = "..."
        Me.btnOptionsFriendsPathReset.UseVisualStyleBackColor = True
        '
        'btnOptionsFriendsFile
        '
        Me.btnOptionsFriendsFile.Location = New System.Drawing.Point(557, 18)
        Me.btnOptionsFriendsFile.Name = "btnOptionsFriendsFile"
        Me.btnOptionsFriendsFile.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFriendsFile.TabIndex = 3
        Me.btnOptionsFriendsFile.Text = "..."
        Me.btnOptionsFriendsFile.UseVisualStyleBackColor = True
        '
        'TxtBxOptionsFriendsFile
        '
        Me.TxtBxOptionsFriendsFile.Location = New System.Drawing.Point(434, 18)
        Me.TxtBxOptionsFriendsFile.Name = "TxtBxOptionsFriendsFile"
        Me.TxtBxOptionsFriendsFile.ReadOnly = True
        Me.TxtBxOptionsFriendsFile.Size = New System.Drawing.Size(117, 20)
        Me.TxtBxOptionsFriendsFile.TabIndex = 2
        '
        'btnOptionsFriendsDirectory
        '
        Me.btnOptionsFriendsDirectory.Location = New System.Drawing.Point(353, 15)
        Me.btnOptionsFriendsDirectory.Name = "btnOptionsFriendsDirectory"
        Me.btnOptionsFriendsDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsFriendsDirectory.TabIndex = 1
        Me.btnOptionsFriendsDirectory.Text = "..."
        Me.btnOptionsFriendsDirectory.UseVisualStyleBackColor = True
        '
        'TxtBxOptionsFriendsDirectory
        '
        Me.TxtBxOptionsFriendsDirectory.Location = New System.Drawing.Point(6, 18)
        Me.TxtBxOptionsFriendsDirectory.Name = "TxtBxOptionsFriendsDirectory"
        Me.TxtBxOptionsFriendsDirectory.ReadOnly = True
        Me.TxtBxOptionsFriendsDirectory.Size = New System.Drawing.Size(341, 20)
        Me.TxtBxOptionsFriendsDirectory.TabIndex = 0
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
        Me.Controls.Add(Me.btnOptionsCancel)
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
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.NmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbPgTime.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.UpDwnVoiceDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDwnTimeDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TbPgOtherStuff.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.TbPgFriends.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
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
    Friend WithEvents TbPgFriends As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptionsFriendsFile As System.Windows.Forms.Button
    Friend WithEvents TxtBxOptionsFriendsFile As System.Windows.Forms.TextBox
    Friend WithEvents btnOptionsFriendsDirectory As System.Windows.Forms.Button
    Friend WithEvents TxtBxOptionsFriendsDirectory As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOptionsFriendsPathReset As System.Windows.Forms.Button
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
    Friend WithEvents lblOptionsSettingsDirectory As System.Windows.Forms.Label
    Friend WithEvents lblOptionsSettingsFile As System.Windows.Forms.Label
    Friend WithEvents TxtBxarchiveFriendsFile As System.Windows.Forms.TextBox
    Friend WithEvents TxtBxarchiveFriendsDirectory As System.Windows.Forms.TextBox
    Friend WithEvents btnarchiveFriendsFile As System.Windows.Forms.Button
    Friend WithEvents btnarchiveFriendsDirectory As System.Windows.Forms.Button
    Friend WithEvents btnarchiveFriendsLoad As System.Windows.Forms.Button
    Friend WithEvents btnarchiveFriendsSave As System.Windows.Forms.Button
End Class
