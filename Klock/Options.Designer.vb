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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOptionsTestVolume = New System.Windows.Forms.Button()
        Me.TrckBrOptionsVolume = New System.Windows.Forms.TrackBar()
        Me.TbPgNotification = New System.Windows.Forms.TabPage()
        Me.btnNotificationTest = New System.Windows.Forms.Button()
        Me.NmrcUpDwnNotificationOpacity = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NmrcUpDwnNotificationTimeOut = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNotificationFont = New System.Windows.Forms.Button()
        Me.btnNotificationColour = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbPgTime = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChckBxTimeHalfChimes = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeQuarterChimes = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeHourlyChimes = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeHourPips = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeToast = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeNetSeconds = New System.Windows.Forms.CheckBox()
        Me.chckBxTimeSwatch = New System.Windows.Forms.CheckBox()
        Me.TbPgTimer = New System.Windows.Forms.TabPage()
        Me.ChckBxClearSplit = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimerHigh = New System.Windows.Forms.CheckBox()
        Me.TbPgReminder = New System.Windows.Forms.TabPage()
        Me.ChckBxReminderTimeCheck = New System.Windows.Forms.CheckBox()
        Me.btnOptionsCancel = New System.Windows.Forms.Button()
        Me.TabCntrlOptions.SuspendLayout()
        Me.TbPgGlobal.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrckBrOptionsVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgNotification.SuspendLayout()
        CType(Me.NmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbPgTime.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TbPgTimer.SuspendLayout()
        Me.TbPgReminder.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOptionsClose
        '
        Me.btnOptionsClose.Location = New System.Drawing.Point(293, 312)
        Me.btnOptionsClose.Name = "btnOptionsClose"
        Me.btnOptionsClose.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsClose.TabIndex = 0
        Me.btnOptionsClose.Text = "OK"
        Me.btnOptionsClose.UseVisualStyleBackColor = True
        '
        'btnOptionsFormColour
        '
        Me.btnOptionsFormColour.Enabled = False
        Me.btnOptionsFormColour.Location = New System.Drawing.Point(277, 17)
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
        Me.lblColour.Location = New System.Drawing.Point(16, 22)
        Me.lblColour.Name = "lblColour"
        Me.lblColour.Size = New System.Drawing.Size(129, 13)
        Me.lblColour.TabIndex = 2
        Me.lblColour.Text = "Change Form Main Colour"
        '
        'btnOptionsFormFont
        '
        Me.btnOptionsFormFont.Enabled = False
        Me.btnOptionsFormFont.Location = New System.Drawing.Point(277, 55)
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
        Me.lblFont.Location = New System.Drawing.Point(16, 65)
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
        Me.ChckBxOptionsSavePos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChckBxOptionsSavePos.Location = New System.Drawing.Point(19, 145)
        Me.ChckBxOptionsSavePos.Name = "ChckBxOptionsSavePos"
        Me.ChckBxOptionsSavePos.Size = New System.Drawing.Size(163, 17)
        Me.ChckBxOptionsSavePos.TabIndex = 5
        Me.ChckBxOptionsSavePos.Text = "Save Screen Position on Exit"
        Me.ChckBxOptionsSavePos.UseVisualStyleBackColor = True
        '
        'btnDefaultColour
        '
        Me.btnDefaultColour.Location = New System.Drawing.Point(277, 94)
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
        Me.lblDefaultColour.Location = New System.Drawing.Point(16, 104)
        Me.lblDefaultColour.Name = "lblDefaultColour"
        Me.lblDefaultColour.Size = New System.Drawing.Size(120, 13)
        Me.lblDefaultColour.TabIndex = 7
        Me.lblDefaultColour.Text = "Reset to default Colours"
        '
        'TabCntrlOptions
        '
        Me.TabCntrlOptions.Controls.Add(Me.TbPgGlobal)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgNotification)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgTime)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgTimer)
        Me.TabCntrlOptions.Controls.Add(Me.TbPgReminder)
        Me.TabCntrlOptions.Location = New System.Drawing.Point(12, 12)
        Me.TabCntrlOptions.Name = "TabCntrlOptions"
        Me.TabCntrlOptions.SelectedIndex = 0
        Me.TabCntrlOptions.Size = New System.Drawing.Size(386, 285)
        Me.TabCntrlOptions.TabIndex = 8
        '
        'TbPgGlobal
        '
        Me.TbPgGlobal.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgGlobal.Controls.Add(Me.GroupBox2)
        Me.TbPgGlobal.Controls.Add(Me.lblColour)
        Me.TbPgGlobal.Controls.Add(Me.ChckBxOptionsSavePos)
        Me.TbPgGlobal.Controls.Add(Me.btnDefaultColour)
        Me.TbPgGlobal.Controls.Add(Me.lblDefaultColour)
        Me.TbPgGlobal.Controls.Add(Me.lblFont)
        Me.TbPgGlobal.Controls.Add(Me.btnOptionsFormFont)
        Me.TbPgGlobal.Controls.Add(Me.btnOptionsFormColour)
        Me.TbPgGlobal.Location = New System.Drawing.Point(4, 22)
        Me.TbPgGlobal.Name = "TbPgGlobal"
        Me.TbPgGlobal.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgGlobal.Size = New System.Drawing.Size(378, 259)
        Me.TbPgGlobal.TabIndex = 0
        Me.TbPgGlobal.Text = "Global"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOptionsTestVolume)
        Me.GroupBox2.Controls.Add(Me.TrckBrOptionsVolume)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 68)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Volume"
        '
        'btnOptionsTestVolume
        '
        Me.btnOptionsTestVolume.Location = New System.Drawing.Point(271, 19)
        Me.btnOptionsTestVolume.Name = "btnOptionsTestVolume"
        Me.btnOptionsTestVolume.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsTestVolume.TabIndex = 1
        Me.btnOptionsTestVolume.Text = "Test"
        Me.btnOptionsTestVolume.UseVisualStyleBackColor = True
        '
        'TrckBrOptionsVolume
        '
        Me.TrckBrOptionsVolume.Location = New System.Drawing.Point(13, 19)
        Me.TrckBrOptionsVolume.Name = "TrckBrOptionsVolume"
        Me.TrckBrOptionsVolume.Size = New System.Drawing.Size(252, 45)
        Me.TrckBrOptionsVolume.TabIndex = 0
        '
        'TbPgNotification
        '
        Me.TbPgNotification.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgNotification.Controls.Add(Me.btnNotificationTest)
        Me.TbPgNotification.Controls.Add(Me.NmrcUpDwnNotificationOpacity)
        Me.TbPgNotification.Controls.Add(Me.Label5)
        Me.TbPgNotification.Controls.Add(Me.Label4)
        Me.TbPgNotification.Controls.Add(Me.NmrcUpDwnNotificationTimeOut)
        Me.TbPgNotification.Controls.Add(Me.Label3)
        Me.TbPgNotification.Controls.Add(Me.btnNotificationFont)
        Me.TbPgNotification.Controls.Add(Me.btnNotificationColour)
        Me.TbPgNotification.Controls.Add(Me.Label2)
        Me.TbPgNotification.Controls.Add(Me.Label1)
        Me.TbPgNotification.Location = New System.Drawing.Point(4, 22)
        Me.TbPgNotification.Name = "TbPgNotification"
        Me.TbPgNotification.Size = New System.Drawing.Size(378, 259)
        Me.TbPgNotification.TabIndex = 3
        Me.TbPgNotification.Text = "Notification"
        '
        'btnNotificationTest
        '
        Me.btnNotificationTest.Location = New System.Drawing.Point(166, 175)
        Me.btnNotificationTest.Name = "btnNotificationTest"
        Me.btnNotificationTest.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationTest.TabIndex = 8
        Me.btnNotificationTest.Text = "Test"
        Me.btnNotificationTest.UseVisualStyleBackColor = True
        '
        'NmrcUpDwnNotificationOpacity
        '
        Me.NmrcUpDwnNotificationOpacity.Location = New System.Drawing.Point(166, 136)
        Me.NmrcUpDwnNotificationOpacity.Name = "NmrcUpDwnNotificationOpacity"
        Me.NmrcUpDwnNotificationOpacity.Size = New System.Drawing.Size(50, 20)
        Me.NmrcUpDwnNotificationOpacity.TabIndex = 7
        Me.NmrcUpDwnNotificationOpacity.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Notification Opacity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Seconds"
        '
        'NmrcUpDwnNotificationTimeOut
        '
        Me.NmrcUpDwnNotificationTimeOut.Location = New System.Drawing.Point(166, 98)
        Me.NmrcUpDwnNotificationTimeOut.Name = "NmrcUpDwnNotificationTimeOut"
        Me.NmrcUpDwnNotificationTimeOut.Size = New System.Drawing.Size(50, 20)
        Me.NmrcUpDwnNotificationTimeOut.TabIndex = 0
        Me.NmrcUpDwnNotificationTimeOut.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Notification Time Out"
        '
        'btnNotificationFont
        '
        Me.btnNotificationFont.Location = New System.Drawing.Point(166, 57)
        Me.btnNotificationFont.Name = "btnNotificationFont"
        Me.btnNotificationFont.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationFont.TabIndex = 3
        Me.btnNotificationFont.Text = "..."
        Me.btnNotificationFont.UseVisualStyleBackColor = True
        '
        'btnNotificationColour
        '
        Me.btnNotificationColour.Location = New System.Drawing.Point(166, 17)
        Me.btnNotificationColour.Name = "btnNotificationColour"
        Me.btnNotificationColour.Size = New System.Drawing.Size(50, 23)
        Me.btnNotificationColour.TabIndex = 2
        Me.btnNotificationColour.Text = "..."
        Me.btnNotificationColour.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Notification Font"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Notification Back Colour"
        '
        'TbPgTime
        '
        Me.TbPgTime.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTime.Controls.Add(Me.GroupBox1)
        Me.TbPgTime.Controls.Add(Me.ChckBxTimeToast)
        Me.TbPgTime.Controls.Add(Me.ChckBxTimeNetSeconds)
        Me.TbPgTime.Controls.Add(Me.chckBxTimeSwatch)
        Me.TbPgTime.Location = New System.Drawing.Point(4, 22)
        Me.TbPgTime.Name = "TbPgTime"
        Me.TbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgTime.Size = New System.Drawing.Size(378, 259)
        Me.TbPgTime.TabIndex = 1
        Me.TbPgTime.Text = "Time"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHalfChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeQuarterChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHourlyChimes)
        Me.GroupBox1.Controls.Add(Me.ChckBxTimeHourPips)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 116)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chimes"
        '
        'ChckBxTimeHalfChimes
        '
        Me.ChckBxTimeHalfChimes.AutoSize = True
        Me.ChckBxTimeHalfChimes.Location = New System.Drawing.Point(118, 65)
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
        Me.ChckBxTimeQuarterChimes.Location = New System.Drawing.Point(102, 88)
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
        Me.ChckBxTimeHourlyChimes.Location = New System.Drawing.Point(133, 42)
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
        Me.ChckBxTimeHourPips.Location = New System.Drawing.Point(55, 19)
        Me.ChckBxTimeHourPips.Name = "ChckBxTimeHourPips"
        Me.ChckBxTimeHourPips.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeHourPips.Size = New System.Drawing.Size(171, 17)
        Me.ChckBxTimeHourPips.TabIndex = 2
        Me.ChckBxTimeHourPips.Text = "Sound ""The Pips"" on the Hour"
        Me.ChckBxTimeHourPips.UseVisualStyleBackColor = True
        '
        'ChckBxTimeToast
        '
        Me.ChckBxTimeToast.AutoSize = True
        Me.ChckBxTimeToast.Checked = True
        Me.ChckBxTimeToast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChckBxTimeToast.Location = New System.Drawing.Point(16, 153)
        Me.ChckBxTimeToast.Name = "ChckBxTimeToast"
        Me.ChckBxTimeToast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeToast.Size = New System.Drawing.Size(226, 17)
        Me.ChckBxTimeToast.TabIndex = 3
        Me.ChckBxTimeToast.Text = "Display Time in System Tray [every 5 mins]"
        Me.ChckBxTimeToast.UseVisualStyleBackColor = True
        '
        'ChckBxTimeNetSeconds
        '
        Me.ChckBxTimeNetSeconds.AutoSize = True
        Me.ChckBxTimeNetSeconds.Location = New System.Drawing.Point(48, 199)
        Me.ChckBxTimeNetSeconds.Name = "ChckBxTimeNetSeconds"
        Me.ChckBxTimeNetSeconds.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeNetSeconds.Size = New System.Drawing.Size(194, 17)
        Me.ChckBxTimeNetSeconds.TabIndex = 1
        Me.ChckBxTimeNetSeconds.Text = "New Earth Time to display Seconds"
        Me.ChckBxTimeNetSeconds.UseVisualStyleBackColor = True
        '
        'chckBxTimeSwatch
        '
        Me.chckBxTimeSwatch.AutoSize = True
        Me.chckBxTimeSwatch.Location = New System.Drawing.Point(54, 176)
        Me.chckBxTimeSwatch.Name = "chckBxTimeSwatch"
        Me.chckBxTimeSwatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chckBxTimeSwatch.Size = New System.Drawing.Size(188, 17)
        Me.chckBxTimeSwatch.TabIndex = 0
        Me.chckBxTimeSwatch.Text = "Swatch Time to display Centibeats"
        Me.chckBxTimeSwatch.UseVisualStyleBackColor = True
        '
        'TbPgTimer
        '
        Me.TbPgTimer.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTimer.Controls.Add(Me.ChckBxClearSplit)
        Me.TbPgTimer.Controls.Add(Me.ChckBxTimerHigh)
        Me.TbPgTimer.Location = New System.Drawing.Point(4, 22)
        Me.TbPgTimer.Name = "TbPgTimer"
        Me.TbPgTimer.Size = New System.Drawing.Size(378, 259)
        Me.TbPgTimer.TabIndex = 2
        Me.TbPgTimer.Text = "Timer"
        '
        'ChckBxClearSplit
        '
        Me.ChckBxClearSplit.AutoSize = True
        Me.ChckBxClearSplit.Location = New System.Drawing.Point(61, 62)
        Me.ChckBxClearSplit.Name = "ChckBxClearSplit"
        Me.ChckBxClearSplit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxClearSplit.Size = New System.Drawing.Size(109, 17)
        Me.ChckBxClearSplit.TabIndex = 1
        Me.ChckBxClearSplit.Text = "Clear to clear split"
        Me.ChckBxClearSplit.UseVisualStyleBackColor = True
        '
        'ChckBxTimerHigh
        '
        Me.ChckBxTimerHigh.AutoSize = True
        Me.ChckBxTimerHigh.Location = New System.Drawing.Point(16, 26)
        Me.ChckBxTimerHigh.Name = "ChckBxTimerHigh"
        Me.ChckBxTimerHigh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimerHigh.Size = New System.Drawing.Size(154, 17)
        Me.ChckBxTimerHigh.TabIndex = 0
        Me.ChckBxTimerHigh.Text = "Timer to show MilliSeconds"
        Me.ChckBxTimerHigh.UseVisualStyleBackColor = True
        '
        'TbPgReminder
        '
        Me.TbPgReminder.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgReminder.Controls.Add(Me.ChckBxReminderTimeCheck)
        Me.TbPgReminder.Location = New System.Drawing.Point(4, 22)
        Me.TbPgReminder.Name = "TbPgReminder"
        Me.TbPgReminder.Size = New System.Drawing.Size(378, 259)
        Me.TbPgReminder.TabIndex = 4
        Me.TbPgReminder.Text = "Reminder"
        '
        'ChckBxReminderTimeCheck
        '
        Me.ChckBxReminderTimeCheck.AutoSize = True
        Me.ChckBxReminderTimeCheck.Location = New System.Drawing.Point(16, 26)
        Me.ChckBxReminderTimeCheck.Name = "ChckBxReminderTimeCheck"
        Me.ChckBxReminderTimeCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxReminderTimeCheck.Size = New System.Drawing.Size(94, 17)
        Me.ChckBxReminderTimeCheck.TabIndex = 0
        Me.ChckBxReminderTimeCheck.Text = "Time checked"
        Me.ChckBxReminderTimeCheck.UseVisualStyleBackColor = True
        '
        'btnOptionsCancel
        '
        Me.btnOptionsCancel.Location = New System.Drawing.Point(212, 312)
        Me.btnOptionsCancel.Name = "btnOptionsCancel"
        Me.btnOptionsCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsCancel.TabIndex = 9
        Me.btnOptionsCancel.Text = "Cancel"
        Me.btnOptionsCancel.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 357)
        Me.Controls.Add(Me.btnOptionsCancel)
        Me.Controls.Add(Me.TabCntrlOptions)
        Me.Controls.Add(Me.btnOptionsClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TabCntrlOptions.ResumeLayout(False)
        Me.TbPgGlobal.ResumeLayout(False)
        Me.TbPgGlobal.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrckBrOptionsVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbPgNotification.ResumeLayout(False)
        Me.TbPgNotification.PerformLayout()
        CType(Me.NmrcUpDwnNotificationOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NmrcUpDwnNotificationTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbPgTime.ResumeLayout(False)
        Me.TbPgTime.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TbPgTimer.ResumeLayout(False)
        Me.TbPgTimer.PerformLayout()
        Me.TbPgReminder.ResumeLayout(False)
        Me.TbPgReminder.PerformLayout()
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
    Friend WithEvents TbPgTimer As System.Windows.Forms.TabPage
    Friend WithEvents ChckBxTimerHigh As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxClearSplit As System.Windows.Forms.CheckBox
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
    Friend WithEvents TbPgReminder As System.Windows.Forms.TabPage
    Friend WithEvents ChckBxReminderTimeCheck As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOptionsTestVolume As System.Windows.Forms.Button
    Friend WithEvents TrckBrOptionsVolume As System.Windows.Forms.TrackBar
End Class
