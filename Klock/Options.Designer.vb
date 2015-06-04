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
        Me.TabCntrlKlock = New System.Windows.Forms.TabControl()
        Me.TbPgGlobal = New System.Windows.Forms.TabPage()
        Me.TbPgTime = New System.Windows.Forms.TabPage()
        Me.chckBxTimeSwatch = New System.Windows.Forms.CheckBox()
        Me.TbPgTimer = New System.Windows.Forms.TabPage()
        Me.ChckBxClearSplit = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimerHigh = New System.Windows.Forms.CheckBox()
        Me.ChckBxTimeNetSeconds = New System.Windows.Forms.CheckBox()
        Me.TabCntrlKlock.SuspendLayout()
        Me.TbPgGlobal.SuspendLayout()
        Me.TbPgTime.SuspendLayout()
        Me.TbPgTimer.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOptionsClose
        '
        Me.btnOptionsClose.Location = New System.Drawing.Point(461, 313)
        Me.btnOptionsClose.Name = "btnOptionsClose"
        Me.btnOptionsClose.Size = New System.Drawing.Size(75, 23)
        Me.btnOptionsClose.TabIndex = 0
        Me.btnOptionsClose.Text = "Close"
        Me.btnOptionsClose.UseVisualStyleBackColor = True
        '
        'btnOptionsFormColour
        '
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
        Me.lblColour.Location = New System.Drawing.Point(16, 22)
        Me.lblColour.Name = "lblColour"
        Me.lblColour.Size = New System.Drawing.Size(129, 13)
        Me.lblColour.TabIndex = 2
        Me.lblColour.Text = "Change Form Main Colour"
        '
        'btnOptionsFormFont
        '
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
        Me.lblDefaultColour.Location = New System.Drawing.Point(16, 104)
        Me.lblDefaultColour.Name = "lblDefaultColour"
        Me.lblDefaultColour.Size = New System.Drawing.Size(120, 13)
        Me.lblDefaultColour.TabIndex = 7
        Me.lblDefaultColour.Text = "Reset to default Colours"
        '
        'TabCntrlKlock
        '
        Me.TabCntrlKlock.Controls.Add(Me.TbPgGlobal)
        Me.TabCntrlKlock.Controls.Add(Me.TbPgTime)
        Me.TabCntrlKlock.Controls.Add(Me.TbPgTimer)
        Me.TabCntrlKlock.Location = New System.Drawing.Point(12, 12)
        Me.TabCntrlKlock.Name = "TabCntrlKlock"
        Me.TabCntrlKlock.SelectedIndex = 0
        Me.TabCntrlKlock.Size = New System.Drawing.Size(524, 285)
        Me.TabCntrlKlock.TabIndex = 8
        '
        'TbPgGlobal
        '
        Me.TbPgGlobal.BackColor = System.Drawing.SystemColors.Control
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
        Me.TbPgGlobal.Size = New System.Drawing.Size(516, 259)
        Me.TbPgGlobal.TabIndex = 0
        Me.TbPgGlobal.Text = "Global"
        '
        'TbPgTime
        '
        Me.TbPgTime.BackColor = System.Drawing.SystemColors.Control
        Me.TbPgTime.Controls.Add(Me.ChckBxTimeNetSeconds)
        Me.TbPgTime.Controls.Add(Me.chckBxTimeSwatch)
        Me.TbPgTime.Location = New System.Drawing.Point(4, 22)
        Me.TbPgTime.Name = "TbPgTime"
        Me.TbPgTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TbPgTime.Size = New System.Drawing.Size(516, 259)
        Me.TbPgTime.TabIndex = 1
        Me.TbPgTime.Text = "Time"
        '
        'chckBxTimeSwatch
        '
        Me.chckBxTimeSwatch.AutoSize = True
        Me.chckBxTimeSwatch.Location = New System.Drawing.Point(22, 25)
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
        Me.TbPgTimer.Size = New System.Drawing.Size(516, 259)
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
        'ChckBxTimeNetSeconds
        '
        Me.ChckBxTimeNetSeconds.AutoSize = True
        Me.ChckBxTimeNetSeconds.Location = New System.Drawing.Point(16, 48)
        Me.ChckBxTimeNetSeconds.Name = "ChckBxTimeNetSeconds"
        Me.ChckBxTimeNetSeconds.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChckBxTimeNetSeconds.Size = New System.Drawing.Size(194, 17)
        Me.ChckBxTimeNetSeconds.TabIndex = 1
        Me.ChckBxTimeNetSeconds.Text = "New Earth Time to display Seconds"
        Me.ChckBxTimeNetSeconds.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 356)
        Me.Controls.Add(Me.TabCntrlKlock)
        Me.Controls.Add(Me.btnOptionsClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TabCntrlKlock.ResumeLayout(False)
        Me.TbPgGlobal.ResumeLayout(False)
        Me.TbPgGlobal.PerformLayout()
        Me.TbPgTime.ResumeLayout(False)
        Me.TbPgTime.PerformLayout()
        Me.TbPgTimer.ResumeLayout(False)
        Me.TbPgTimer.PerformLayout()
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
    Friend WithEvents TabCntrlKlock As System.Windows.Forms.TabControl
    Friend WithEvents TbPgGlobal As System.Windows.Forms.TabPage
    Friend WithEvents TbPgTime As System.Windows.Forms.TabPage
    Friend WithEvents TbPgTimer As System.Windows.Forms.TabPage
    Friend WithEvents ChckBxTimerHigh As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxClearSplit As System.Windows.Forms.CheckBox
    Friend WithEvents chckBxTimeSwatch As System.Windows.Forms.CheckBox
    Friend WithEvents ChckBxTimeNetSeconds As System.Windows.Forms.CheckBox
End Class
