Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    '   The settings are saved using applications settings, automatically handeled bu
    '   the program.  A save is called when form is closed.

    Public displayAction As selectAction

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   When opened, set settings

        displayAction = New selectAction

        setSettings()
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        Me.BackColor = My.Settings.usrFormColour

        Me.lblColour.Font = My.Settings.usrFormFont
        Me.lblColour.ForeColor = My.Settings.usrFormFontColour

        Me.lblFont.Font = My.Settings.usrFormFont
        Me.lblFont.ForeColor = My.Settings.usrFormFontColour

        Me.lblDefaultColour.Font = My.Settings.usrFormFont
        Me.lblDefaultColour.ForeColor = My.Settings.usrFormFontColour

        Me.TbPgGlobal.BackColor = My.Settings.usrFormColour
        Me.TbPgTime.BackColor = My.Settings.usrFormColour
        Me.TbPgTimer.BackColor = My.Settings.usrFormColour

        Me.ChckBxOptionsSavePos.Checked = My.Settings.usrSavePos
        Me.ChckBxOptionsSavePos.Font = My.Settings.usrFormFont
        Me.ChckBxOptionsSavePos.ForeColor = My.Settings.usrFormFontColour

        Me.ChckBxTimerHigh.Checked = My.Settings.usrTimerHigh
        Me.ChckBxClearSplit.Checked = My.Settings.usrTimerClearSplit

        Me.chckBxTimeSwatch.Checked = My.Settings.usrTimeSwatchCentibeats
        Me.ChckBxTimeNetSeconds.Checked = My.Settings.usrTimeNETSeconds
        Me.ChckBxTimeHourPips.Checked = My.Settings.usrTimeHourPips
        Me.ChckBxTimeHourlyChimes.Checked = My.Settings.usrTimeHourlyChimes
        Me.ChckBxTimeHalfChimes.Checked = My.Settings.usrTimeHalfChimes
        Me.ChckBxTimeQuarterChimes.Checked = My.Settings.usrTimeQuarterChimes
        Me.ChckBxTimeToast.Checked = My.Settings.usrTimeDisplayMinimised

        Me.ChckBxReminderTimeCheck.Checked = My.Settings.usrReminderTimeChecked

        Me.NmrcUpDwnNotificationTimeOut.Value = My.Settings.usrNotificationTimeOut / 1000
        Me.NmrcUpDwnNotificationOpacity.Value = My.Settings.usrNotificationOpacity

        Me.TrckBrOptionsVolume.Minimum = 0
        Me.TrckBrOptionsVolume.Maximum = 1000
        Me.TrckBrOptionsVolume.TickFrequency = 100
        Me.TrckBrOptionsVolume.Value = My.Settings.usrSoundVolume

    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        My.Settings.usrSavePos = Me.ChckBxOptionsSavePos.Checked

        If My.Settings.usrSavePos Then
            My.Settings.usrFormTop = frmKlock.Top
            My.Settings.usrFormLeft = frmKlock.Left
        End If

        My.Settings.usrTimerHigh = Me.ChckBxTimerHigh.Checked
        My.Settings.usrTimerClearSplit = Me.ChckBxClearSplit.Checked

        My.Settings.usrTimeSwatchCentibeats = Me.chckBxTimeSwatch.Checked
        My.Settings.usrTimeNETSeconds = Me.ChckBxTimeNetSeconds.Checked
        My.Settings.usrTimeHourPips = Me.ChckBxTimeHourPips.Checked
        My.Settings.usrTimeHourlyChimes = Me.ChckBxTimeHourlyChimes.Checked
        My.Settings.usrTimeHalfChimes = Me.ChckBxTimeHalfChimes.Checked
        My.Settings.usrTimeQuarterChimes = Me.ChckBxTimeQuarterChimes.Checked
        My.Settings.usrTimeThreeQuarterChimes = Me.ChckBxTimeQuarterChimes.Checked
        My.Settings.usrTimeDisplayMinimised = Me.ChckBxTimeToast.Checked

        My.Settings.usrReminderTimeChecked = Me.ChckBxReminderTimeCheck.Checked

        My.Settings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

        My.Settings.Save()

        Me.Close()
    End Sub

    Private Sub btnOptionsCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsCancel.Click
        '   when canceled, close but not save.

        Me.Close()
    End Sub


    Private Sub btnOptionsFormColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        Me.ClrDlgFormColour.Color = My.Settings.usrFormColour          '   current main form colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            My.Settings.usrFormColour = Me.ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled separately.

        FntDlgFont.Font  = My.Settings.usrFormFont                  '   current main form font
        FntDlgFont.Color = My.Settings.usrFormFontColour            '   current main form font colour
        
       If FntDlgFont.ShowDialog() = DialogResult.OK Then
            My.Settings.usrFormFont       = FntDlgFont.Font
            My.Settings.usrFormFontColour = FntDlgFont.Color
            setSettings()
        End If
    End Sub

    Private Sub ChckBxOptionsSavePos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxOptionsSavePos.CheckedChanged
        '   If option is checked, save form position.

    End Sub

Private Sub btnDefaultColour_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        My.Settings.usrFormColour = frmOptions.DefaultBackColor 
        My.Settings.usrFormFont = frmOptions.DefaultFont  
        My.Settings.usrFormFontColour = frmOptions.DefaultForeColor 

        setSettings()
End Sub

    '-----------------------------------------------------------Time---------------------------------------------------------------

    Private Sub ChckBxTimeHourPips_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeHourPips.CheckedChanged

        If ChckBxTimeHourPips.Checked Then
            Me.ChckBxTimeHourlyChimes.Enabled = False
            Me.ChckBxTimeHourlyChimes.Checked = False
            Me.ChckBxTimeHalfChimes.Enabled = False
            Me.ChckBxTimeHalfChimes.Checked = False
            Me.ChckBxTimeQuarterChimes.Enabled = False
            Me.ChckBxTimeQuarterChimes.Checked = False
        Else
            Me.ChckBxTimeHourlyChimes.Enabled = True
            Me.ChckBxTimeHalfChimes.Enabled = True
            Me.ChckBxTimeQuarterChimes.Enabled = True
        End If
    End Sub

    Private Sub ChckBxTimeHourlyChimes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeHourlyChimes.CheckedChanged

        If ChckBxTimeHourlyChimes.Checked Then
            Me.ChckBxTimeHourPips.Enabled = False
            Me.ChckBxTimeHourPips.Checked = False
            Me.ChckBxTimeHalfChimes.Enabled = True
            Me.ChckBxTimeQuarterChimes.Enabled = True
        Else
            Me.ChckBxTimeHourPips.Enabled = True
            Me.ChckBxTimeHalfChimes.Checked = False
            Me.ChckBxTimeHalfChimes.Enabled = False
            Me.ChckBxTimeQuarterChimes.Checked = False
            Me.ChckBxTimeQuarterChimes.Enabled = False
        End If
    End Sub


    '-----------------------------------------------------------Notification---------------------------------------------------------------

    Private Sub btnNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationColour.Click
        '   Set the Notification main colour.

        Me.ClrDlgFormColour.Color = My.Settings.usrNotificationBackColour   '   current Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            My.Settings.usrNotificationBackColour = Me.ClrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        Me.FntDlgFont.Font = My.Settings.usrNotificationFont                  '   current Notification font
        Me.FntDlgFont.Color = My.Settings.usrNotificationFontColour           '   current Notification font colour

        If Me.FntDlgFont.ShowDialog() = DialogResult.OK Then
            My.Settings.usrNotificationFont = Me.FntDlgFont.Font
            My.Settings.usrNotificationFontColour = Me.FntDlgFont.Color
        End If
    End Sub

    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        My.Settings.usrNotificationTimeOut = Me.NmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        My.Settings.usrNotificationOpacity = Me.NmrcUpDwnNotificationOpacity.Value
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationTest.Click
        showNotification("Test", "Notification Test")
    End Sub

    Private Sub showNotification(ByVal header As String, ByVal message As String)

        Dim Notification As New frmNotification(My.Settings.usrNotificationTimeOut, header, String.Format(" Opacity = {0}", My.Settings.usrNotificationOpacity))

        Notification.Show()

    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(sender As System.Object, e As System.EventArgs) Handles TrckBrOptionsVolume.Scroll

        My.Settings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

    End Sub

    Private Sub btnOptionsTestVolume_Click(sender As System.Object, e As System.EventArgs) Handles btnOptionsTestVolume.Click

        displayAction.PlaySound(Application.StartupPath & "\Sounds\halfchime.wav")

    End Sub
End Class