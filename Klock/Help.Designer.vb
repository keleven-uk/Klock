<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHelp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHelp))
        Me.btnHelpClose = New System.Windows.Forms.Button()
        Me.RchTxtBxHelp = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnHelpClose
        '
        Me.btnHelpClose.Location = New System.Drawing.Point(325, 227)
        Me.btnHelpClose.Name = "btnHelpClose"
        Me.btnHelpClose.Size = New System.Drawing.Size(75, 23)
        Me.btnHelpClose.TabIndex = 0
        Me.btnHelpClose.Text = "Close"
        Me.btnHelpClose.UseVisualStyleBackColor = True
        '
        'RchTxtBxHelp
        '
        Me.RchTxtBxHelp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RchTxtBxHelp.Location = New System.Drawing.Point(12, 12)
        Me.RchTxtBxHelp.Name = "RchTxtBxHelp"
        Me.RchTxtBxHelp.ReadOnly = True
        Me.RchTxtBxHelp.Size = New System.Drawing.Size(382, 203)
        Me.RchTxtBxHelp.TabIndex = 1
        Me.RchTxtBxHelp.Text = ""
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 256)
        Me.Controls.Add(Me.RchTxtBxHelp)
        Me.Controls.Add(Me.btnHelpClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(422, 294)
        Me.Name = "frmHelp"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Help"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHelpClose As System.Windows.Forms.Button
    Friend WithEvents RchTxtBxHelp As System.Windows.Forms.RichTextBox
End Class
