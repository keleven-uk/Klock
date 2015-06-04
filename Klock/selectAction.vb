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
        Hibernate
        LogOff
    End Enum

    Public Sub PlaySound(ByVal s As String)
        '   play a sound file.   
        '   MUST BE OF TYPE .WAV

        If s.EndsWith(".wav") Then
            My.Computer.Audio.Play(s)
        End If
    End Sub

    Public Sub DisplayReminder(ByVal s As String)
        '   Display the reminder message
        '   TODO : a fancy notification.

        MessageBox.Show(s)
    End Sub

    Public Sub DoSystemCommand(ByVal s As String)
        '   Perform the system command as set out in SystemTypes.

        Dim p As New ProcessStartInfo

        Select Case s
            Case SystemTypes.ShutDown
                p.Arguments = "0" & "-t 10" & "-c 'Shutting Down PC in 10 Seconds'"
            Case SystemTypes.Restart
                p.Arguments = "-r" & "-t 10" & "-c 'Restarting Down PC in 10 Seconds'"
            Case SystemTypes.Hibernate
                p.Arguments = "-h" & "-t 10" & "-c 'Hibernate PC in 10 Seconds by Klock'"
            Case SystemTypes.LogOff
                p.Arguments = "-l" & "-t 10" & "-c 'Logging off user in 10 Seconds by Klock'"
        End Select

        p.FileName = "shutdown"

        Process.Start(p)

    End Sub

    Public Sub DoCommand(ByVal S As String)
        '   Performs the externam command.
        '   If the file is executable it will be run. 
        '   If the file has an association, the host will be run. i.e a .doc file will launch word.
        '   No error checking is performed [yet]

        Dim p As New ProcessStartInfo

        If S = String.Empty Then
            MessageBox.Show("Even Klock cant run with nowt!!")
        Else
            p.Arguments = S
            p.FileName = "cmd"

            Process.Start(p)
        End If
    End Sub


End Class
