Public Class selectAction
    '   A class wich just presents some enum's and procedurs to perform certain actions.
    '   In a class, so they can be used in several place within the program.


    Enum ActionTypes            '   the types of action that can be performes.
        Sound
        Reminder
        System
        Command
    End Enum

    Enum SystemTypes            '   the types of system action that can be performed.
        ShutDown
        Restart
        GUI
        LogOff
    End Enum

    Public Sub PlaySound(ByVal s As String)
        '   play a sound file.   
        '   MUST BE OF TYPE .WAV

        If s.EndsWith(".wav") Then
            If My.Computer.FileSystem.FileExists(s) Then
                My.Computer.Audio.Play(s)
            Else
                MessageBox.Show("Sorry, sound file seems to have gone away!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If  '   If s.EndsWith(".wav")
        End If      '   if My.Computer.FileSystem.FileExists(s)
    End Sub

    Public Sub DisplayReminder(ByVal s As String)
        '   Display the reminder message
        '   TODO : a fancy notification.

        Dim Notification As New frmNotification(5000, "CountDown", s)

        Notification.Show()
    End Sub

    Public Sub DoSystemCommand(ByVal s As String)
        '   Perform the system command as set out in SystemTypes.

        Dim p As New ProcessStartInfo

        Select Case s
            Case SystemTypes.ShutDown
                frmKlock.Text = " Klock is Shutting Down PC"
                p.Arguments = "0 " & "-t 10 " & "-c ""Shutting Down PC in 10 Seconds"""
            Case SystemTypes.Restart
                frmKlock.Text = " Klock is Restsrting PC"
                p.Arguments = "-r " & "-t 10 " & "-c ""Restarting Down PC in 10 Seconds"""
            Case SystemTypes.GUI
                frmKlock.Text = " Klock is Displaying GUI Interface"
                p.Arguments = "-i "
            Case SystemTypes.LogOff
                frmKlock.Text = " Klock is Logging off Current User"
                p.Arguments = "-l " & "-t 10 " & "-c ""Logging off user in 10 Seconds by Klock"""
        End Select

        Try
            p.FileName = "shutdown.exe"
            Process.Start(p)
        Catch ex As System.ComponentModel.Win32Exception
            MessageBox.Show("Sorry, there seems to problems :: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Public Sub DoCommand(ByVal s As String)
        '   Performs the externam command.
        '   If the file is executable it will be run. 
        '   If the file has an association, the host will be run. i.e a .doc file will launch word.

        If s = String.Empty Then
            MessageBox.Show("Even Klock cant run with nowt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If My.Computer.FileSystem.FileExists(s) Then
                Try
                    Process.Start(s)
                Catch ex As System.ComponentModel.Win32Exception
                    MessageBox.Show("Sorry, can not be executed :: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Sorry, file seems to have gone away!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


End Class
