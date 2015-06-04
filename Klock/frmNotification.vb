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

    'Gets the handle of the window that currently has focus.
    <DllImport("user32")> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    'Activates the specified window handle of the window to be focused.  Returns True if the window was focused; False otherwise.
    <DllImport("user32")> _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    Dim mode As String

    'Creates a new Notification form object that is displayed for the specified length of time.
    Public Sub New(ByVal lifeTime As Integer, ByVal message1 As String, ByVal message2 As String, ByVal m As String)
        '   Mode can be either R for reminder, E for Event.
        '   Reminder are closed by the timer [using the value from the time out] - ** this is original code **
        '   Event are to be closed by buttons, only visible in event mode.

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mode = m

        'Make sure the exit button is set properly
        btnExit.Image = My.Resources.btnHigh

        Me.Width = 335
        Me.Height = 78

        If mode = "R" Then

            '   set the for colour and opacity for the form {form opacity is 0 [0%] - 1.0 [100%]}
            Me.BackColor = frmKlock.usrSettings.usrNotificationbackColour
            Me.Opacity = frmKlock.usrSettings.usrNotificationOpacity / 100

            'Set the time for which the form should be displayed and the message to display in milliseconds.
            Me.lifeTimer.Interval = lifeTime

            Me.lblMessage1.Font = frmKlock.usrSettings.usrNotificationFont
            Me.lblMessage1.ForeColor = frmKlock.usrSettings.usrNotificationFontColour
            Me.lblMessage1.Text = message1

            Me.lblMessage2.Font = frmKlock.usrSettings.usrNotificationFont
            Me.lblMessage2.ForeColor = frmKlock.usrSettings.usrNotificationFontColour
            Me.lblMessage2.Text = message2
        Else
            Me.lifeTimer.Enabled = False        '   is event - don't need timer.

            '   set the for colour and opacity for the form {form opacity is 0 [0%] - 1.0 [100%]}
            Me.Opacity = frmKlock.usrSettings.usrEventNotificationOpacity / 100

            If message1.StartsWith("First") Then Me.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
            If message1.StartsWith("Second") Then Me.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
            If message1.StartsWith("Third") Then Me.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour

            Me.btnExit.BackColor = Me.BackColor

            Me.lblMessage1.Font = frmKlock.usrSettings.usrEventNotificationFont
            Me.lblMessage1.ForeColor = frmKlock.usrSettings.usrEventNotificationFontColour
            Me.lblMessage1.Text = message1

            Me.lblMessage2.Font = frmKlock.usrSettings.usrEventNotificationFont
            Me.lblMessage2.ForeColor = frmKlock.usrSettings.usrEventNotificationFontColour
            Me.lblMessage2.Text = message2
        End If


        'Display the form by sliding up.
        Me.animator = New FormAnimator(Me, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 500)
        'Me.animator = New FormAnimator(Me, FormAnimator.AnimationMethod.Slide, 500)
    End Sub

    'Displays the form.  Required to allow the form to determine the current foreground window before being displayed.
    Public Shadows Sub Show()
        'Determine the current foreground window so it can be reactivated each time this form tries to get the focus.
        Me.currentForegroundWindow = GetForegroundWindow()

        MyBase.Show()
    End Sub

    Private Sub NotificationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the form just above the system tray.
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 5)

        'Move each open form upwards to make room for this one.
        For Each openForm As frmNotification In frmNotification.openForms
            openForm.Top -= Me.Height + 5
        Next

        'Add this form from the open form list.
        frmNotification.openForms.Add(Me)

        'Start counting down the form's lifetime [only if reminder].
        If mode = "R" Then Me.lifeTimer.Start()
    End Sub

    Private Sub NotificationForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Prevent the form taking focus when it is initially shown.
        If Not Me.allowFocus Then
            'Activate the window that previously had the focus.
            SetForegroundWindow(Me.currentForegroundWindow)
        End If
    End Sub

    Private Sub NotificationForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Once the animation has completed the form can receive focus.
        Me.allowFocus = True

        'Close the form by sliding down.
        Me.animator.Direction = FormAnimator.AnimationDirection.Down
    End Sub

    Private Sub NotificationForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Move down any open forms above this one.
        For Each openForm As frmNotification In frmNotification.openForms
            If openForm Is Me Then
                'The remaining forms are below this one.
                Exit For
            End If

            openForm.Top += Me.Height + 5
        Next

        'Remove this form from the open form list.
        frmNotification.openForms.Remove(Me)
    End Sub

    Private Sub lifeTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles lifeTimer.Tick
        'The form's lifetime has expired.
        Me.Close()
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

    Private Sub NotificationForm_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click, lblMessage1.Click, lblMessage2.Click
        Me.Close()
    End Sub

    Private Sub btnExit_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnExit.MouseHover
        btnExit.Image = My.Resources.btnLow
    End Sub

    Private Sub btnExit_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnExit.MouseLeave
        btnExit.Image = My.Resources.btnHigh
    End Sub

    Private Sub btnExit_MouseDown(sender As System.Object, e As System.EventArgs) Handles btnExit.MouseDown
        btnExit.Image = My.Resources.btnClicked
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class