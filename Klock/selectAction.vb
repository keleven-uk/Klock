﻿Public Class selectAction

    ' used by PlaySound()
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
                        (ByVal lpstrCommand As String, ByVal lpstrReturnString As String,
                         ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    '   used by ScreenSaver()

    Private Declare Function GetDesktopWindow Lib "user32" () As Integer
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
    Const SC_SCREENSAVE As Integer = &HF140

    Const WM_SYSCOMMAND As Integer = &H112

    Public Sub New()

        MyBase.New()
    End Sub
    '   A class which just presents some enum's and procedures to perform certain actions.
    '   In a class, so they can be used in several place within the program.

    Enum ActionTypes            '   the types of action that can be performed.
        Sound
        Reminder
        System
        Command
        Speech
        ScreenSaver
    End Enum
    '                               Speech not handled in this class, just a place holder here.
    '                               Must be implanted in calling programme.

    Enum SystemTypes            '   the types of system action that can be performed.
        ShutDown
        Restart
        GUI
        LogOff
    End Enum

    Public Sub AbortSystemCommand()
        '   Allows a system command [above] to be aborted.

        Dim p As New ProcessStartInfo

        p.Arguments = "-a"

        Try
            p.FileName = "shutdown.exe"
            Process.Start(p)
        Catch ex As System.ComponentModel.Win32Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("selectActions.AbortSystemCommand", ex)
            DisplayReminder("Sorry, there seems to problems :: " & ex.Message, "G", "ERROR")
        End Try
    End Sub

    Public Sub DisplayEvent(ByVal e As Events)
        '   Display the event message
        '   Not used general sub above, pass in event object.

        Dim et As New eventThings

        Dim title As String = String.Empty
        Dim message As String = String.Empty

        '                                                   remember the event name is held in title case.
        If e.EventName = "btnEventNotificationTest" Then
            title = "Event Notification test"
            message = String.Format(" Opacity = {0}", frmKlock.usrSettings.usrEventNotificationOpacity)
        Else
            title = et.eventTitle(e)
            message = et.eventmessage(e)
        End If

        Dim Notification As New frmNotification(title, message, "E")

        Notification.Show()
    End Sub

    Public Sub DisplayReminder(message As String, mode As Char, title As String)
        '   Display the reminder message
        '   Use different timeout for General [Reminder] and Sayings notifications

        Select Case mode
            Case "G"
                Dim Notification As New frmNotification(title, message, "R")
                Notification.Show()
            Case "S"
                Dim Notification As New frmNotification(title, message, "S")
                Notification.Show()
        End Select
    End Sub

    Public Sub DoCommand(s As String)
        '   Performs the external command.
        '   If the file is executable it will be run.
        '   If the file has an association, the host will be run. i.e a .doc file will launch word.

        If s = String.Empty Then
            MessageBox.Show("Even Klock can't run with nowt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If My.Computer.FileSystem.FileExists(s) Then
                Try
                    Process.Start(s)
                Catch ex As System.ComponentModel.Win32Exception
                    If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("selectActions.DoCommand", ex)
                    DisplayReminder("Sorry, can not be executed :: " & ex.Message, "G", "ERROR")
                End Try
            Else
                DisplayReminder("Sorry, file seems to have gone away!!", "G", "ERROR")
            End If
        End If
    End Sub

    Public Sub DoSystemCommand(s As String)
        '   Perform the system command as set out in SystemTypes.

        Dim p As New ProcessStartInfo

        Select Case s
            Case SystemTypes.ShutDown
                If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.logMessage("selectAction.DoSystemCommand", " Shutdown System")
                frmKlock.Text = " Klock is Shutting Down PC"
                p.Arguments = "-s -t 10 -c ""Shutting Down PC In 10 Seconds"""
            Case SystemTypes.Restart
                If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.logMessage("selectAction.DoSystemCommand", " Restart System")
                frmKlock.Text = " Klock is Restarting PC"
                p.Arguments = "-r -t 10 -c ""Restarting Down PC in 10 Seconds"""
            Case SystemTypes.GUI
                If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.logMessage("selectAction.DoSystemCommand", " Shutdown GUI")
                frmKlock.Text = " Klock is Displaying GUI Interface"
                p.Arguments = "-i "
            Case SystemTypes.LogOff
                If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.logMessage("selectAction.DoSystemCommand", " Logoff System")
                frmKlock.Text = " Klock is Logging off Current User"
                p.Arguments = "-l - t 10 -c ""Logging off user in 10 Seconds by Klock"""
        End Select

        Try
            p.FileName = "shutdown.exe"
            Process.Start(p)
        Catch ex As System.ComponentModel.Win32Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("selectActions.ProcessStartInfo", ex)
            DisplayReminder("Sorry, there seems to problems :: " & ex.Message, "G", "ERROR")
        End Try
    End Sub

    Public Sub PlaySound(s As String)
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
            DisplayReminder("Sorry, sound file seems to have gone away!!" & vbCr & s, "G", "ERROR")
        End If      '   if My.Computer.FileSystem.FileExists(s)
    End Sub

    Public Sub ScreenSaver()
        '   call the currently selected screen saver i.e. in windows control panel.
        '   This works my using windows magic.

        Dim hWnd As Integer
        Dim rtn As Integer      '   always seems to be zero.

        hWnd = GetDesktopWindow()
        rtn = SendMessage(hWnd, WM_SYSCOMMAND, SC_SCREENSAVE, 0)
    End Sub

End Class
