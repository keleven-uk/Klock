<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeHelp
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
        Me.btnTimeHelpClose = New System.Windows.Forms.Button()
        Me.WbBrwsrTimeHelp = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'btnTimeHelpClose
        '
        Me.btnTimeHelpClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTimeHelpClose.Location = New System.Drawing.Point(325, 227)
        Me.btnTimeHelpClose.Name = "btnTimeHelpClose"
        Me.btnTimeHelpClose.Size = New System.Drawing.Size(75, 23)
        Me.btnTimeHelpClose.TabIndex = 0
        Me.btnTimeHelpClose.Text = "Close"
        Me.btnTimeHelpClose.UseVisualStyleBackColor = True
        '
        'WbBrwsrTimeHelp
        '
        Me.WbBrwsrTimeHelp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WbBrwsrTimeHelp.Location = New System.Drawing.Point(12, 12)
        Me.WbBrwsrTimeHelp.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WbBrwsrTimeHelp.Name = "WbBrwsrTimeHelp"
        Me.WbBrwsrTimeHelp.Size = New System.Drawing.Size(388, 209)
        Me.WbBrwsrTimeHelp.TabIndex = 1
        Me.WbBrwsrTimeHelp.WebBrowserShortcutsEnabled = False
        '
        'frmTimeHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 262)
        Me.Controls.Add(Me.WbBrwsrTimeHelp)
        Me.Controls.Add(Me.btnTimeHelpClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimeHelp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Time Help"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTimeHelpClose As System.Windows.Forms.Button
    Friend WithEvents WbBrwsrTimeHelp As System.Windows.Forms.WebBrowser
End Class
