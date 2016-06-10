Public Class frmInfo

    '   A display form used to display information to the user.
    '   Currently Daylight Saving, Current Culture, Operating System & Power Source

    '   Called from module InfoCommon.vb


    Private Sub btnInfoClose_Click(sender As System.Object, e As System.EventArgs) Handles btnInfoClose.Click
        '   If the timer is enabled, switch off on close.

        If TmrInfo.Enabled Then TmrInfo.Enabled = False

        Close()
    End Sub

    Private Sub BtnQueryServer_Click(sender As Object, e As EventArgs) Handles BtnQueryServer.Click
        '   Calls the query server routine.  Get the time from an internet time server.

        queryServer()
    End Sub

    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   set the year to current year on form load.

        NmrcUpDwnYear.Value = Now().Year
    End Sub

    Private Sub NmrcUpDwnYear_ValueChanged(sender As Object, e As EventArgs) Handles NmrcUpDwnYear.ValueChanged
        '   If the year has been changed update the data on the form.

        updateInfo(GroupBox1.Text, NmrcUpDwnYear.Value)
    End Sub

    Private Sub TmrInfo_Tick(sender As Object, e As System.EventArgs) Handles TmrInfo.Tick
        '   if the form is loaded as power source, the timer will have been enabled.
        '   So, every six seconds update the labels with the status of the power source.


        Select Case Text
            Case "Info - Power Source"
                Label1.Text = frmKlock.myManagedPower.powerSource()
                Label2.Text = ""
                Label3.Text = frmKlock.myManagedPower.powerStatus()
                Label4.Text = frmKlock.myManagedPower.chargingStatus()
                Label5.Text = ""

            Case Else

        End Select
    End Sub
End Class