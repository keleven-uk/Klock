Imports System.Runtime.InteropServices

Public Class frmNotification

    'The list of currently open Notification forms.
    Private Shared openForms As New List(Of frmNotification)

    'Indicates whether the form can receive focus or not.
    Private allowFocus As Boolean = False

    'The object that creates the sliding animation.
    Private animator As FormAnimator

    'The handle of the window that currently has focus.
    Private currentForegroundWindow As IntPtr

    Dim mode As String

    'Creates a new Notification form object that is displayed for the specified length of time.
    Public Sub New(ByVal message1 As String, ByVal message2 As String, ByVal mode As String)
        '   Mode can be either R for reminder, E for Event.
        '   Reminder are closed by the timer [using the value from the time out] - ** this is original code **
        '   Event are to be closed by buttons, only visible in event mode.

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Make sure the exit button is set properly
        btnExit.Image = My.Resources.btnHigh

        Width = 335

        Dim noOfLines = message2.Split(Environment.NewLine).Length      ' count lines by counting carriage returns.

        If noOfLines < 3 Then
            Height = 78
        Else
            Height = 44 + (noOfLines * 22)
            lblMessage2.Height = (noOfLines * 22)
        End If

        Select Case mode
            Case "R"            '   Reminder
                lifeTimer.Enabled = True
                '   set the for colour and opacity for the form {form opacity is 0 [0%] - 1.0 [100%]}
                BackColor = frmKlock.usrSettings.usrNotificationbackColour
                Opacity = frmKlock.usrSettings.usrNotificationOpacity / 100

                'Set the time for which the form should be displayed and the message to display in milliseconds.
                lifeTimer.Interval = frmKlock.usrSettings.usrNotificationTimeOut

                lblMessage1.Font = frmKlock.usrSettings.usrNotificationFont
                lblMessage1.ForeColor = frmKlock.usrSettings.usrNotificationFontColour
                lblMessage1.Text = message1

                lblMessage2.Font = frmKlock.usrSettings.usrNotificationFont
                lblMessage2.ForeColor = frmKlock.usrSettings.usrNotificationFontColour
                lblMessage2.Text = message2
            Case "S"            '   Saying
                'MessageBox.Show(message2 & " :: " & Len(message2).ToString & " :: " & noOfLines.ToString & " :: " & Height.ToString)
                lifeTimer.Enabled = True
                '   set the for colour and opacity for the form {form opacity is 0 [0%] - 1.0 [100%]}
                BackColor = frmKlock.usrSettings.usrSayingsbackColour
                Opacity = frmKlock.usrSettings.usrSayingsOpacity / 100

                'Set the time for which the form should be displayed and the message to display in milliseconds.
                lifeTimer.Interval = frmKlock.usrSettings.usrSayingsTimeOut

                lblMessage1.Font = frmKlock.usrSettings.usrSayingsFont
                lblMessage1.ForeColor = frmKlock.usrSettings.usrSayingsFontColour
                lblMessage1.Text = message1

                lblMessage2.Font = frmKlock.usrSettings.usrNotificationFont
                lblMessage2.ForeColor = frmKlock.usrSettings.usrNotificationFontColour
                lblMessage2.Text = message2
            Case "E"            '   Event

                lifeTimer.Enabled = False        '   is event - don't need timer.

                '   set the for colour and opacity for the form {form opacity is 0 [0%] - 1.0 [100%]}
                Opacity = frmKlock.usrSettings.usrEventNotificationOpacity / 100

                If message1.StartsWith("First") Then BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
                If message1.StartsWith("Second") Then BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
                If message1.StartsWith("Third") Then BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour

                btnExit.BackColor = BackColor

                lblMessage1.Font = frmKlock.usrSettings.usrEventNotificationFont
                lblMessage1.ForeColor = frmKlock.usrSettings.usrEventNotificationFontColour
                lblMessage1.Text = message1

                lblMessage2.Font = frmKlock.usrSettings.usrEventNotificationFont
                lblMessage2.ForeColor = frmKlock.usrSettings.usrEventNotificationFontColour
                lblMessage2.Text = message2
        End Select

        'Display the form by sliding up.
        animator = New FormAnimator(Me, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 500)
        'Me.animator = New FormAnimator(Me, FormAnimator.AnimationMethod.Slide, 500)
    End Sub

    'Displays the form.  Required to allow the form to determine the current foreground window before being displayed.
    Public Shadows Sub Show()
        'Determine the current foreground window so it can be reactivated each time this form tries to get the focus.
        currentForegroundWindow = GetForegroundWindow()

        MyBase.Show()
    End Sub

    'Gets the handle of the window that currently has focus.
    <DllImport("user32")>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    'Activates the specified window handle of the window to be focused.  Returns True if the window was focused; False otherwise.
    <DllImport("user32")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnExit_MouseDown(sender As System.Object, e As System.EventArgs) Handles btnExit.MouseDown
        btnExit.Image = My.Resources.btnClicked
    End Sub

    Private Sub btnExit_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnExit.MouseHover
        btnExit.Image = My.Resources.btnLow
    End Sub

    Private Sub btnExit_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.Image = My.Resources.btnHigh
    End Sub

    Private Sub lifeTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles lifeTimer.Tick
        'The form's lifetime has expired.
        Close()
    End Sub

    Private Sub NotificationForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Prevent the form taking focus when it is initially shown.
        If Not allowFocus Then
            'Activate the window that previously had the focus.
            SetForegroundWindow(currentForegroundWindow)
        End If
    End Sub

    Private Sub NotificationForm_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click, lblMessage1.Click, lblMessage2.Click
        Close()
    End Sub

    Private Sub NotificationForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Move down any open forms above this one.
        For Each openForm As frmNotification In frmNotification.openForms
            If openForm Is Me Then
                'The remaining forms are below this one.
                Exit For
            End If

            openForm.Top += Height + 5
        Next

        'Remove this form from the open form list.
        frmNotification.openForms.Remove(Me)
    End Sub

    Private Sub NotificationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the form just above the system tray.
        Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5)

        'Move each open form upwards to make room for this one.
        For Each openForm As frmNotification In frmNotification.openForms
            openForm.Top -= Height + 5
        Next

        'Add this form from the open form list.
        frmNotification.openForms.Add(Me)

        'Start counting down the form's lifetime [only if reminder].
        If mode = "R" Then lifeTimer.Start()
    End Sub

    Private Sub NotificationForm_MouseHover(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseHover, lblMessage1.MouseHover, lblMessage2.MouseHover

        For Each openForm As frmNotification In frmNotification.openForms
            If mode = "R" Then openForm.lifeTimer.Stop() '   timer only used for reminders.
        Next
    End Sub

    Private Sub NotificationForm_MouseLeave(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseLeave, lblMessage1.MouseLeave, lblMessage2.MouseHover

        For Each openForm As frmNotification In frmNotification.openForms
            If mode = "R" Then openForm.lifeTimer.Start() '   timer only used for reminders.
        Next
    End Sub

    Private Sub NotificationForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Once the animation has completed the form can receive focus.
        allowFocus = True

        'Close the form by sliding down.
        animator.Direction = FormAnimator.AnimationDirection.Down
    End Sub
End Class