<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotification
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
        Me.lblMessage1 = New System.Windows.Forms.Label()
        Me.lifeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblMessage2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMessage1
        '
        Me.lblMessage1.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage1.Name = "lblMessage1"
        Me.lblMessage1.Size = New System.Drawing.Size(178, 28)
        Me.lblMessage1.TabIndex = 0
        Me.lblMessage1.Text = "Message will appear here"
        Me.lblMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lifeTimer
        '
        '
        'lblMessage2
        '
        Me.lblMessage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage2.Location = New System.Drawing.Point(60, 39)
        Me.lblMessage2.Name = "lblMessage2"
        Me.lblMessage2.Size = New System.Drawing.Size(265, 28)
        Me.lblMessage2.TabIndex = 1
        Me.lblMessage2.Text = "Twelve minutes past eleven in the evening111111111"
        Me.lblMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Klock.My.Resources.Resources.klock
        Me.PictureBox1.Location = New System.Drawing.Point(12, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.ForeColor = System.Drawing.Color.Transparent
        Me.btnExit.Image = Global.Klock.My.Resources.Resources.btnHigh
        Me.btnExit.Location = New System.Drawing.Point(315, 0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(18, 18)
        Me.btnExit.TabIndex = 3
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'frmNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 76)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblMessage2)
        Me.Controls.Add(Me.lblMessage1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNotification"
        Me.Opacity = 0.1R
        Me.ShowInTaskbar = False
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblMessage1 As System.Windows.Forms.Label
    Private WithEvents lifeTimer As System.Windows.Forms.Timer
    Private WithEvents lblMessage2 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
