Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            '   Should run if a unhandled exception is raised, it should be logged and the user informed.

            Try
                frmKlock.errLogger.LogExceptionError("KlockThings.loadSayings", e.Exception)
                e.ExitApplication = MessageBox.Show(e.Exception.Message & vbCrLf & "Continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No
            Catch ex As Exception
                e.ExitApplication = MessageBox.Show(e.Exception.Message & vbCrLf & "Continue?", "Continue? [could not log]", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No
            End Try
        End Sub

    End Class
End Namespace
