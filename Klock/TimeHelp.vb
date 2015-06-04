Public Class TimeHelp

    Private Sub btnTimeHelpClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeHelpClose.Click
        '   Close help form when clicked.

        Me.Close()
    End Sub

    Private Sub frmTimeHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   loads the specified help into the web browser, only for time one [the top time display].
        '   The help files are expected to be in a HELP folder contained within the application start up folder.
        '   The help files are expected to be names after theentry in the class selectTime, ended in .html


        Dim names = System.Enum.GetNames(GetType(selectTime.TimeTypes))             '   loads names of time types into a array.
        Dim title As String = names(frmKlock.CmbBxTimeOne.SelectedIndex)            '   extracts the desired title - as main form combo box.
        Dim fname As String = Application.StartupPath & "\Help\" & title & ".html"  '   generated file name

        Me.Text = frmKlock.displayOneTime.getTitle() & " Help"                      '   sets form title appropiately.

        If My.Computer.FileSystem.FileExists(fname) Then
            Me.WbBrwsrTimeHelp.Url = New Uri(fname)                                 '   Load file.
        End If

    End Sub
End Class