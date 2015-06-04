Public Class selectAction
    '   A class which just presents some enum's and procedures to perform certain actions.
    '   In a class, so they can be used in several place within the program.


    Enum ActionTypes            '   the types of action that can be performed.
        Sound
        Reminder
        System
        Command
        Speach      '   not handled in this class, must be coded on calling programm.
    End Enum

    Enum SystemTypes            '   the types of system action that can be performed.
        ShutDown
        Restart
        GUI
        LogOff
    End Enum

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
                        (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, _
                         ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer


    Public Sub PlaySound(ByVal s As String)
        '   play a sound file.  Uses some fancy code of www.vbforums.com, allows volume to be changed.   
        '   When using multimedia API (e.g. mciSendString) calls to play multimedia files, 
        '   the API call may fail if the path or file name in the command string has embedded spaces.
        '   To work around the long file name limitation use quotes around the path and file name.

        If My.Computer.FileSystem.FileExists(s) Then
            mciSendString("close myAudio", Nothing, 0, 0)

            Dim fileName1 As String = s
            mciSendString("open " & """" & fileName1 & """" & " type mpegvideo alias myAudio", Nothing, 0, 0)
            mciSendString("play myAudio", Nothing, 0, 0)

            'min Volume is 1, max Volume is 1000
            Dim Volume As Integer = frmKlock.usrSettings.usrSoundVolume
            mciSendString("setaudio myAudio volume to " & Volume, Nothing, 0, 0)

        Else
            DisplayReminder("ERROR", "Sorry, sound file seems to have gone away!!")
        End If      '   if My.Computer.FileSystem.FileExists(s)
    End Sub

    Public Sub DisplayReminder(ByVal t As String, ByVal m As String)
        '   Display the reminder message

        Dim Notification As New frmNotification(frmKlock.usrSettings.usrNotificationTimeOut, t, m)

        Notification.Show()
    End Sub

    Public Sub DoSystemCommand(ByVal s As String)
        '   Perform the system command as set out in SystemTypes.

        Dim p As New ProcessStartInfo

        Select Case s
            Case SystemTypes.ShutDown
                frmKlock.Text = " Klock is Shutting Down PC"
                p.Arguments = "-s " & "-t 10 " & "-c ""Shutting Down PC in 10 Seconds"""
            Case SystemTypes.Restart
                frmKlock.Text = " Klock is Restarting PC"
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
            DisplayReminder("ERROR", "Sorry, there seems to problems :: " & ex.Message)
        End Try


    End Sub

    Public Sub AbortSystemCommand()
        '   Allows a system command [above] to be aborted.

        Dim p As New ProcessStartInfo

        p.Arguments = "-a "

        Try
            p.FileName = "shutdown.exe"
            Process.Start(p)
        Catch ex As System.ComponentModel.Win32Exception
            DisplayReminder("ERROR", "Sorry, there seems to problems :: " & ex.Message)
        End Try

    End Sub

    Public Sub DoCommand(ByVal s As String)
        '   Performs the external command.
        '   If the file is executable it will be run. 
        '   If the file has an association, the host will be run. i.e a .doc file will launch word.

        If s = String.Empty Then
            MessageBox.Show("Even Klock cant run with nowt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If My.Computer.FileSystem.FileExists(s) Then
                Try
                    Process.Start(s)
                Catch ex As System.ComponentModel.Win32Exception
                    DisplayReminder("ERROR", "Sorry, can not be executed :: " & ex.Message)
                End Try
            Else
                DisplayReminder("ERROR", "Sorry, file seems to have gone away!!")
            End If
        End If
    End Sub

End Class
