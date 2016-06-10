Public Class frmMemoPassword

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        '   Cancel button as been pressed, set appropriate result.

        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub frmMemoPassword_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        TxtBxMemoPassword.Select()
        TxtBxMemoPassword.Text = ""      '   clear text field at start.
    End Sub
    '   Simple form to collect password.

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        '   OK button as been pressed, set appropriate result.

        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class
