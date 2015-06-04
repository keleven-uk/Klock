Public Class frmInfo

    Public Const POWER As String = "Info - Power Source"

    Public myManagedPower As ManagedPower       '   instance of managed Power

    Private Sub btnInfoClose_Click(sender As System.Object, e As System.EventArgs) Handles btnInfoClose.Click

        If Me.TmrInfo.Enabled Then Me.TmrInfo.Enabled = False

        Me.Close()
    End Sub

    Private Sub frmInfo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '   if loaded as power source, switch on timer

        If Me.Text = POWER Then
            Me.myManagedPower = New ManagedPower            '   system power source
            Me.TmrInfo.Enabled = True
        End If
    End Sub

    Private Sub TmrInfo_Tick(sender As System.Object, e As System.EventArgs) Handles TmrInfo.Tick
        '   if the form is loaded as power source, the timer will have been enabled.
        '   So, every six seconds update the labels with the status of the power source.

        Me.Label1.Text = Me.myManagedPower.powerSource()
        Me.Label2.Text = ""
        Me.Label3.Text = Me.myManagedPower.powerStatus()
        Me.Label4.Text = Me.myManagedPower.chargingStatus()
        Me.Label5.Text = ""
    End Sub
End Class