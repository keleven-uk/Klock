Imports System.Windows.Forms

Public Class frmMemoPassword
    '   Simple form to collect password.

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        '   OK button as been pressed, set appropriate result.

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        '   Cancel button as been pressed, set appropriate result.

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmMemoPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TxtBxMemoPassword.Focus()
        Me.TxtBxMemoPassword.Text = ""      '   clear text field at start.
    End Sub
End Class
