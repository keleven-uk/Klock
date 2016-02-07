Public Class frmClipboardMonitor
    '   Manages the clipboard.
    '   When monitoring the clipboard is enabled 9in klock options], if something is copied to the clipboard
    '   is should be added to the list-box on this form.  Then any any entry ion the list-box can then be
    '   copied back to the clipboard and used in any applications.  In a effect, this remembers the clipboard history.

    '   The majority of the code is placed in frmKlock.  This is because it needs to hook the main appliction [klock]
    '   into the clipboard viewer chain.

    '   NB :: ONLY TEXT at mo.

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        '   Close button has been pressed.
        '   NB : does not disable clipboard monitoring.

        tmrClipboardMonitor.Enabled = False
        Close()
    End Sub

    Private Sub frmClipboardMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Start the time on form load.

        tmrClipboardMonitor.Enabled = True
        btnCopy.Enabled = False

        If frmKlock.usrSettings.usrClipboardMonitorSavePosition Then
            Top = frmKlock.usrSettings.usrClipboardMonitorTop
            Left = frmKlock.usrSettings.usrClipboardMonitorLeft
        End If
    End Sub

    Private Sub frmClipboardMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   Save form position, is enabled, on closing.

        If frmKlock.usrSettings.usrClipboardMonitorSavePosition Then
            frmKlock.usrSettings.usrClipboardMonitorTop = Top
            frmKlock.usrSettings.usrClipboardMonitorLeft = Left
        End If

        frmKlock.usrSettings.writeSettings()             '   save settings, not sure if anything has changed.
    End Sub

    Private Sub lstBxClipboardData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBxClipboardData.SelectedIndexChanged
        '   Only enable copy button, it there is items to copy.

        If lstBxClipboardData.Items.Count = 0 Then
            btnCopy.Enabled = False
        Else
            btnCopy.Enabled = True
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        '   Clears the data in the list-box.

        lstBxClipboardData.Items.Clear()
        btnCopy.Enabled = False
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        '   Copies the selected list-box entry to the clipboard.

        My.Computer.Clipboard.SetText(lstBxClipboardData.SelectedItem())
    End Sub

    Private Sub tmrClipboardMonitor_Tick(sender As Object, e As EventArgs) Handles tmrClipboardMonitor.Tick

        updateStatusBar()
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns off"

        '                                               if running on battery, change status info colour to red as a warning.
        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = Color.Black
            StsLblDate.ForeColor = Color.Black
            StsLblKeys.ForeColor = Color.Black
        Else
            stsLblTime.ForeColor = Color.Red
            StsLblDate.ForeColor = Color.Red
            StsLblKeys.ForeColor = Color.Red
        End If

        If My.Computer.Keyboard.CapsLock.ToString() Then strKey = Replace(strKey, "c", "C")
        If My.Computer.Keyboard.NumLock.ToString() Then strKey = Replace(strKey, "n", "N")
        If My.Computer.Keyboard.ScrollLock.ToString() Then strKey = Replace(strKey, "s", "S")
        If KlockThings.HaveInternetConnection() Then strKey = Replace(strKey, "off", "ON")

        stsLblTime.Text = If(frmKlock.usrSettings.usrTimeSystem24Hour, String.Format("{0:HH:mm:ss}", System.DateTime.Now), String.Format("{0:hh:mm:ss tt}", System.DateTime.Now))

        '   Me.stsLblTime.Text = Format(Now, "Long Time")
        StsLblDate.Text = Format(Now, "Long Date")
        StsLblKeys.Text = strKey

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If

    End Sub

End Class