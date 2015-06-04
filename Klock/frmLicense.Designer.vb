<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicence
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLicence))
        Me.btnLecenseClose = New System.Windows.Forms.Button()
        Me.RchTxtBxLicense = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnLecenseClose
        '
        Me.btnLecenseClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLecenseClose.Location = New System.Drawing.Point(325, 227)
        Me.btnLecenseClose.Name = "btnLecenseClose"
        Me.btnLecenseClose.Size = New System.Drawing.Size(75, 23)
        Me.btnLecenseClose.TabIndex = 1
        Me.btnLecenseClose.Text = "Close"
        Me.btnLecenseClose.UseVisualStyleBackColor = True
        '
        'RchTxtBxLicense
        '
        Me.RchTxtBxLicense.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RchTxtBxLicense.Location = New System.Drawing.Point(12, 12)
        Me.RchTxtBxLicense.Name = "RchTxtBxLicense"
        Me.RchTxtBxLicense.ReadOnly = True
        Me.RchTxtBxLicense.Size = New System.Drawing.Size(388, 209)
        Me.RchTxtBxLicense.TabIndex = 2
        Me.RchTxtBxLicense.Text = ""
        '
        'frmLicence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 262)
        Me.Controls.Add(Me.RchTxtBxLicense)
        Me.Controls.Add(Me.btnLecenseClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLicence"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Licence"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLecenseClose As System.Windows.Forms.Button
    Friend WithEvents RchTxtBxLicense As System.Windows.Forms.RichTextBox
End Class
