Public Class frmInfo

    '   A display form used to display information to the user.
    '   Currently Daylight Saving, Current Culture, Operating System & Power Source

    '   Called from module InfoCommon.vb


    Private Sub btnInfoClose_Click(sender As System.Object, e As System.EventArgs) Handles btnInfoClose.Click
        '   If the timer is enabled, switch off on close.

        If Me.TmrInfo.Enabled Then Me.TmrInfo.Enabled = False

        Me.Close()
    End Sub

    Private Sub TmrInfo_Tick(sender As System.Object, e As System.EventArgs) Handles TmrInfo.Tick
        '   if the form is loaded as power source, the timer will have been enabled.
        '   So, every six seconds update the labels with the status of the power source.


        Select Case Me.Text
            Case "Info - Power Source"
                Me.Label1.Text = frmKlock.myManagedPower.powerSource()
                Me.Label2.Text = ""
                Me.Label3.Text = frmKlock.myManagedPower.powerStatus()
                Me.Label4.Text = frmKlock.myManagedPower.chargingStatus()
                Me.Label5.Text = ""

            Case Else

        End Select

    End Sub

    Private Sub NmrcUpDwnYear_ValueChanged(sender As Object, e As EventArgs) Handles NmrcUpDwnYear.ValueChanged
        '   If the year has been changed update the data on the form.

        InfoCommon.updateInfo(Me.GroupBox1.Text, Me.NmrcUpDwnYear.Value)
    End Sub

    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   set the year to current year on form load.

        Me.NmrcUpDwnYear.Value = Now().Year
    End Sub

    Private Sub BtnQueryServer_Click(sender As Object, e As EventArgs) Handles BtnQueryServer.Click
        '   Calls the query server routine.  Get the time from an internet time server.

        InfoCommon.queryServer()
    End Sub
End Class