Imports Shell32

Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    Public displayAction As selectAction


    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   When opened, set settings

        Dim tabs() As String = {"Fuzzy Time", "World Klock", "Count Down", "Timer", "Reminder", "Friends", "Events", "Memo"}

        displayAction = New selectAction

        Me.TxtBxArchiveFile.Text = "Klock.zip"
        Me.LblOptionSavepath.Text = System.IO.Path.Combine(frmKlock.usrSettings.usrOptionsSavePath(), frmKlock.usrSettings.usrOptionsSaveFile())

        Me.CmbBxDefaultTab.Items.AddRange(tabs)
        Me.CmbBxDefaultTab.SelectedIndex = frmKlock.usrSettings.usrDefaultTab

        Me.TabCntrlOptions.SelectedIndex = 0

        Me.showArchiveButtons(False)
        Me.setSettings()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------tab control ---------------------

    Private Sub TabCntrlOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCntrlOptions.SelectedIndexChanged
        '   actions depending upon which tab is chosen.

        Select Case Me.TabCntrlOptions.SelectedIndex
            Case 0              '   Global options
                Me.showArchiveButtons(False)
            Case 1              '   Notification options
                Me.showArchiveButtons(False)
            Case 2              '   Time options
                Me.showArchiveButtons(False)
            Case 3              '   Other Stuff options
                Me.showArchiveButtons(False)
            Case 4              '   Archive options
                Me.showArchiveButtons(True)
            Case 5              '   Events
                Me.showArchiveButtons(False)
            Case 6              '   Memo
                Me.showArchiveButtons(False)
        End Select
    End Sub

    Private Sub showArchiveButtons(ByVal b As Boolean)
        '   either show of hide the archive buttons.
        '   not enough space on tab for buttons.

        Me.btnArchiveLoad.Visible = b
        Me.btnArchiveSave.Visible = b
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        frmKlock.usrSettings.readSettings()     '   re-read settings, so we are always working current.

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        Me.BackColor = frmKlock.usrSettings.usrFormColour

        Me.lblColour.Font = frmKlock.usrSettings.usrFormFont
        Me.lblColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        Me.lblFont.Font = frmKlock.usrSettings.usrFormFont
        Me.lblFont.ForeColor = frmKlock.usrSettings.usrFormFontColour
        Me.lblDefaultColour.Font = frmKlock.usrSettings.usrFormFont
        Me.lblDefaultColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        Me.TbPgGlobal.BackColor = frmKlock.usrSettings.usrFormColour

        Me.ChckBxOptionsSavePos.Checked = frmKlock.usrSettings.usrSavePosition
        Me.ChckBxOptionsRunOnStartup.Checked = frmKlock.usrSettings.usrRunOnStartup
        Me.ChckBxOptionsStartupMinimised.Checked = frmKlock.usrSettings.usrStartMinimised

        Me.TrckBrOptionsVolume.Minimum = 0
        Me.TrckBrOptionsVolume.Maximum = 1000
        Me.TrckBrOptionsVolume.TickFrequency = 100
        Me.TrckBrOptionsVolume.Value = frmKlock.usrSettings.usrSoundVolume

        Me.TxtBxOptionsSettingsFile.Text = IIf(frmKlock.usrSettings.usrFriendsFile = "", "Klock.xml", frmKlock.usrSettings.usrOptionsSaveFile)
        Me.TxtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath

        '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

        Me.CmbBxDefaultTimeFormat.SelectedIndex = frmKlock.usrSettings.usrTimeDefaultFormat
        Me.CmbBxDefaultTimeTwoFormat.SelectedIndex = frmKlock.usrSettings.usrTimeTWODefaultFormat

        Me.chckBxTimeTwoFormats.Checked = frmKlock.usrSettings.usrTimeTwoFormats

        Me.chckBxTimeSwatch.Checked = frmKlock.usrSettings.usrTimeSwatchCentibeats
        Me.ChckBxTimeNetSeconds.Checked = frmKlock.usrSettings.usrTimeNETSeconds
        Me.ChckBxTimeHexIntuitor.Checked = frmKlock.usrSettings.usrTimeHexIntuitorFormat
        Me.ChckBxTimeHourPips.Checked = frmKlock.usrSettings.usrTimeHourPips
        Me.ChckBxTimeHourlyChimes.Checked = frmKlock.usrSettings.usrTimeHourChimes
        Me.ChckBxTimeHalfChimes.Checked = frmKlock.usrSettings.usrTimeHalfChimes
        Me.ChckBxTimeQuarterChimes.Checked = frmKlock.usrSettings.usrTimeQuarterChimes
        Me.ChckBxTimeToast.Checked = frmKlock.usrSettings.usrTimeDisplayMinimised
        Me.UpDwnTimeDisplay.Value = frmKlock.usrSettings.usrTimeDisplayMinutes
        Me.ChckBxOptionsVoice.Checked = frmKlock.usrSettings.usrTimeVoiceMinimised
        Me.UpDwnVoiceDisplay.Value = frmKlock.usrSettings.usrTimeVoiceMinutes

        Me.UpDwnTimeDisplay.Enabled = frmKlock.usrSettings.usrTimeDisplayMinutes

        Me.ChckBxTimeSystem24.Checked = frmKlock.usrSettings.usrTimeSystem24Hour
        Me.ChckBxTimeSystem12.Checked = Not frmKlock.usrSettings.usrTimeSystem24Hour
        Me.ChckBxTimeTimeOne24.Checked = frmKlock.usrSettings.usrTimeOne24Hour
        Me.ChckBxTimeTimeOne12.Checked = Not frmKlock.usrSettings.usrTimeOne24Hour
        Me.ChckBxTimeTimeTwo24.Checked = frmKlock.usrSettings.usrTimeTwo24Hour
        Me.ChckBxTimeTimeTwo12.Checked = Not frmKlock.usrSettings.usrTimeTwo24Hour

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        Me.ChckBxTimerHigh.Checked = frmKlock.usrSettings.usrTimerHigh
        Me.ChckBxClearSplit.Checked = frmKlock.usrSettings.usrTimerClearSplit
        Me.ChckBxTimerAdd.Checked = frmKlock.usrSettings.usrTimerAdd

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        Me.ChckBxCountdownAdd.Checked = frmKlock.usrSettings.usrCountdownAdd

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        Me.ChckBxReminderAdd.Checked = frmKlock.usrSettings.usrReminderAdd

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        Me.ChckBxWorldKlockAdd.Checked = frmKlock.usrSettings.usrWorldKlockAdd

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        Me.NmrcUpDwnNotificationTimeOut.Value = frmKlock.usrSettings.usrNotificationTimeOut / 1000
        Me.NmrcUpDwnNotificationOpacity.Value = frmKlock.usrSettings.usrNotificationOpacity

        Me.NmrcUpDwnEventNotificationOpacity.Value = frmKlock.usrSettings.usrEventNotificationOpacity

        Me.PctrBxNotification.BackColor = frmKlock.usrSettings.usrNotificationbackColour
        Me.PctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        Me.PctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        Me.PctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour
        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        Me.TxtBxOptionsFriendsFile.Text = IIf(frmKlock.usrSettings.usrFriendsFile = "", "Friends.bin", frmKlock.usrSettings.usrFriendsFile)

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        Me.TxtBxOptionsEventsFile.Text = IIf(frmKlock.usrSettings.usrEventsFile = "", "Events.bin", frmKlock.usrSettings.usrEventsFile)

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        Me.TxtBxOptionsMemoFile.Text = IIf(frmKlock.usrSettings.usrMemoFile = "", "Memo.bin", frmKlock.usrSettings.usrMemoFile)

        Me.NmrcUpDwnFirstReminder.Value = frmKlock.usrSettings.usrEventsFirstReminder
        Me.NmrcUpDwnSecondReminder.Value = frmKlock.usrSettings.usrEventsSecondReminder
        Me.NmrcUpDwnThirdReminder.Value = frmKlock.usrSettings.usrEventsThirdReminder
        Me.NmrcUpDwnEventsInterval.Value = frmKlock.usrSettings.usrEventsTimerInterval

        Me.ChckBxMemoDefaultPassword.Checked = frmKlock.usrSettings.usrMemoUseDefaultPassword
        Me.TxtBxMemoDefaultPassword.Text = frmKlock.usrSettings.usrMemoDefaultPassword

        Me.NmrcUpDwnMemoDecrypt.Value = frmKlock.usrSettings.usrMemoDecyptTimeOut
    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        frmKlock.usrSettings.usrSavePosition = Me.ChckBxOptionsSavePos.Checked
        frmKlock.usrSettings.usrRunOnStartup = Me.ChckBxOptionsRunOnStartup.Checked
        frmKlock.usrSettings.usrStartMinimised = Me.ChckBxOptionsStartupMinimised.Checked

        If frmKlock.usrSettings.usrSavePosition Then
            frmKlock.usrSettings.usrFormTop = frmKlock.Top
            frmKlock.usrSettings.usrFormLeft = frmKlock.Left
        End If

        '-------------------------------------------------------------------------------------------------------- Time Settings --------------

        frmKlock.usrSettings.usrTimeDefaultFormat = Me.CmbBxDefaultTimeFormat.SelectedIndex
        frmKlock.usrSettings.usrTimeTWODefaultFormat = Me.CmbBxDefaultTimeTwoFormat.SelectedIndex

        frmKlock.usrSettings.usrTimeTwoFormats = Me.chckBxTimeTwoFormats.Checked

        frmKlock.usrSettings.usrTimeSwatchCentibeats = Me.chckBxTimeSwatch.Checked
        frmKlock.usrSettings.usrTimeNETSeconds = Me.ChckBxTimeNetSeconds.Checked
        frmKlock.usrSettings.usrTimeHexIntuitorFormat = Me.ChckBxTimeHexIntuitor.Checked
        frmKlock.usrSettings.usrTimeHourPips = Me.ChckBxTimeHourPips.Checked
        frmKlock.usrSettings.usrTimeHourChimes = Me.ChckBxTimeHourlyChimes.Checked
        frmKlock.usrSettings.usrTimeHalfChimes = Me.ChckBxTimeHalfChimes.Checked
        frmKlock.usrSettings.usrTimeQuarterChimes = Me.ChckBxTimeQuarterChimes.Checked
        frmKlock.usrSettings.usrTimeDisplayMinimised = Me.ChckBxTimeToast.Checked
        frmKlock.usrSettings.usrTimeDisplayMinutes = Me.UpDwnTimeDisplay.Value
        frmKlock.usrSettings.usrTimeVoiceMinimised = Me.ChckBxOptionsVoice.Checked
        frmKlock.usrSettings.usrTimeVoiceMinutes = Me.UpDwnVoiceDisplay.Value
        frmKlock.usrSettings.usrSoundVolume = Me.TrckBrOptionsVolume.Value

        frmKlock.usrSettings.usrTimeSystem24Hour = Me.ChckBxTimeSystem24.Checked
        frmKlock.usrSettings.usrTimeOne24Hour = Me.ChckBxTimeTimeOne24.Checked
        frmKlock.usrSettings.usrTimeTwo24Hour = Me.ChckBxTimeTimeTwo24.Checked

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        frmKlock.usrSettings.usrTimerHigh = Me.ChckBxTimerHigh.Checked
        frmKlock.usrSettings.usrTimerClearSplit = Me.ChckBxClearSplit.Checked
        frmKlock.usrSettings.usrTimerAdd = Me.ChckBxTimerAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        frmKlock.usrSettings.usrCountdownAdd = Me.ChckBxCountdownAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        frmKlock.usrSettings.usrReminderTimeChecked = Me.ChckBxReminderTimeCheck.Checked
        frmKlock.usrSettings.usrReminderAdd = Me.ChckBxReminderAdd.Checked

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        frmKlock.usrSettings.usrWorldKlockAdd = Me.ChckBxWorldKlockAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        frmKlock.usrSettings.usrNotificationTimeOut = Me.NmrcUpDwnNotificationTimeOut.Value * 1000
        frmKlock.usrSettings.usrNotificationOpacity = Me.NmrcUpDwnNotificationOpacity.Value

        frmKlock.usrSettings.usrEventNotificationOpacity = Me.NmrcUpDwnEventNotificationOpacity.Value

        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        frmKlock.usrSettings.usrFriendsFile = Me.TxtBxOptionsFriendsFile.Text

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        frmKlock.usrSettings.usrEventsFile = Me.TxtBxOptionsEventsFile.Text

        frmKlock.usrSettings.usrEventsFirstReminder = Me.NmrcUpDwnFirstReminder.Value
        frmKlock.usrSettings.usrEventsSecondReminder = Me.NmrcUpDwnSecondReminder.Value
        frmKlock.usrSettings.usrEventsThirdReminder = Me.NmrcUpDwnThirdReminder.Value
        frmKlock.usrSettings.usrEventsTimerInterval = Me.NmrcUpDwnEventsInterval.Value

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        frmKlock.usrSettings.usrMemoFile = Me.TxtBxOptionsMemoFile.Text
        frmKlock.usrSettings.usrMemoUseDefaultPassword = Me.ChckBxMemoDefaultPassword.Checked
        frmKlock.usrSettings.usrMemoDefaultPassword = Me.TxtBxMemoDefaultPassword.Text
        frmKlock.usrSettings.usrMemoDecyptTimeOut = Me.NmrcUpDwnMemoDecrypt.Value


        frmKlock.usrSettings.writeSettings()
        frmKlock.setSettings()

        Me.Close()
    End Sub

    '-----------------------------------------------------------Buttons---------------------------------------------------------------

    Private Sub btnOptionsCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsCancel.Click
        '   when cancelled, close but not save.

        Me.Close()
    End Sub

    Private Sub btnSettingsReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettingsReset.Click
        '   re-write settings file with defaults.

        frmKlock.usrSettings.writeDefaultSettings()
        frmKlock.usrSettings.readSettings()
        Me.setSettings()
        frmKlock.setSettings()
    End Sub

    '-----------------------------------------------------------Global---------------------------------------------------------------

    Private Sub CmbBxDefaultTab_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbBxDefaultTab.SelectedIndexChanged
        '   If a new default tab is selected, do the update stuff.

        frmKlock.usrSettings.usrDefaultTab = Me.CmbBxDefaultTab.SelectedIndex

    End Sub


    Private Sub btnOptionsFormColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrFormColour          '   current main form colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormColour = Me.ClrDlgFormColour.Color
            Me.setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled separately.

        FntDlgFont.Font = frmKlock.usrSettings.usrFormFont                  '   current main form font
        FntDlgFont.Color = frmKlock.usrSettings.usrFormFontColour            '   current main form font colour

        If FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormFont = FntDlgFont.Font
            frmKlock.usrSettings.usrFormFontColour = FntDlgFont.Color
            Me.setSettings()
        End If
    End Sub

    Private Sub btnDefaultColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        frmKlock.usrSettings.usrFormColour = frmOptions.DefaultBackColor
        frmKlock.usrSettings.usrFormFont = frmOptions.DefaultFont
        frmKlock.usrSettings.usrFormFontColour = frmOptions.DefaultForeColor

        Me.setSettings()
    End Sub

    Private Sub ChckBxOptionsRunOnStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxOptionsRunOnStartup.CheckedChanged
        '   Sets or deletes the registry key required for running on windows start up.
        '   Only sets for current user.

        Try
            If Me.ChckBxOptionsRunOnStartup.Checked Then
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Registry Error :: Cant write entry to Registry", ex.Message)
        End Try
    End Sub

    '-----------------------------------------------------------Time---------------------------------------------------------------

    Private Sub chckBxTimeTwoFormats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxTimeTwoFormats.CheckedChanged
        '   Only disply two time default format if needed.

        Me.lblTimeTwo.Enabled = Me.chckBxTimeTwoFormats.Checked
        Me.CmbBxDefaultTimeTwoFormat.Enabled = Me.chckBxTimeTwoFormats.Checked
    End Sub

    Private Sub ChckBxTimeHourPips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeHourPips.CheckedChanged
        '   It the pips are selected, disable all chimes.

        If Me.ChckBxTimeHourPips.Checked Then
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

    Private Sub ChckBxTimeHourlyChimes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeHourlyChimes.CheckedChanged
        '   if chimes are selected, disable the pips.

        If Me.ChckBxTimeHourlyChimes.Checked Then
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

    Private Sub ChckBxTimeSystem24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeSystem24.CheckedChanged

        Me.ChckBxTimeSystem12.Checked = Not Me.ChckBxTimeSystem24.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeOne24.CheckedChanged

        Me.ChckBxTimeTimeOne12.Checked = Not Me.ChckBxTimeTimeOne24.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeTwo24.CheckedChanged

        Me.ChckBxTimeTimeTwo12.Checked = Not Me.ChckBxTimeTimeTwo24.Checked
    End Sub

    Private Sub ChckBxTimeSystem12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeSystem12.CheckedChanged

        Me.ChckBxTimeSystem24.Checked = Not Me.ChckBxTimeSystem12.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeOne12.CheckedChanged

        Me.ChckBxTimeTimeOne24.Checked = Not Me.ChckBxTimeTimeOne12.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeTwo12.CheckedChanged

        Me.ChckBxTimeTimeTwo24.Checked = Not Me.ChckBxTimeTimeTwo12.Checked
    End Sub

    '-----------------------------------------------------------Notification---------------------------------------------------------------

    Private Sub btnNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationColour.Click
        '   Set the Notification main colour.

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrNotificationbackColour   '   current Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationbackColour = Me.ClrDlgFormColour.Color
            Me.PctrBxNotification.BackColor = frmKlock.usrSettings.usrNotificationbackColour
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        Me.FntDlgFont.Font = frmKlock.usrSettings.usrNotificationFont                  '   current Notification font
        Me.FntDlgFont.Color = frmKlock.usrSettings.usrNotificationFontColour           '   current Notification font colour

        If Me.FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationFont = Me.FntDlgFont.Font
            frmKlock.usrSettings.usrNotificationFontColour = Me.FntDlgFont.Color
        End If
    End Sub

    Private Sub btnEventNotificationFontColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrNotificationTimeOut = Me.NmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        frmKlock.usrSettings.usrNotificationOpacity = Me.NmrcUpDwnNotificationOpacity.Value
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationTest.Click
        '   Display a test notification, showing the current notification opacity.

        Me.displayAction.DisplayReminder("Notification Test", String.Format(" Opacity = {0}", frmKlock.usrSettings.usrNotificationOpacity))
    End Sub

    Private Sub btnEventNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventNotificationTest.Click
        '   Display a test event notification, showing the current event notification opacity.

        Dim ev As New Events

        ev.EventName = "btnEventNotificationTest"

        Me.displayAction.DisplayEvent(ev)
    End Sub

    '-----------------------------------------------------------Event Notification--------------------------------------------------------------

    Private Sub btnEventNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventNotificationFont.Click
        '   Set the Event Notification main font.
        '   the font colour has to be handled separately.

        Me.FntDlgFont.Font = frmKlock.usrSettings.usrEventNotificationFont                  '   current Event Notification font
        Me.FntDlgFont.Color = frmKlock.usrSettings.usrEventNotificationFontColour           '   current Event Notification font colour

        If Me.FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrEventNotificationFont = Me.FntDlgFont.Font
            frmKlock.usrSettings.usrEventNotificationFontColour = Me.FntDlgFont.Color
        End If
    End Sub

    Private Sub btnFirstEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstEventNotificationColour.Click
        '   Set the First Event Notification main colour.

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrFirstEventNotificationbackColour   '   current First Event Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFirstEventNotificationbackColour = Me.ClrDlgFormColour.Color
            Me.PctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        End If
    End Sub

    Private Sub btnSecondEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondEventNotificationColour.Click
        '   Set the Second Event Notification main colour.

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrSecondEventNotificationbackColour   '   current Second Event Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSecondEventNotificationbackColour = Me.ClrDlgFormColour.Color
            Me.PctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        End If
    End Sub

    Private Sub btnThirdEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThirdEventNotificationColour.Click
        '   Set the Third Event Notification main colour.

        Me.ClrDlgFormColour.Color = frmKlock.usrSettings.usrThirdEventNotificationbackColour   '   current Third Event Notification colour
        If Me.ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrThirdEventNotificationbackColour = Me.ClrDlgFormColour.Color
            Me.PctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour
        End If
    End Sub

    Private Sub NmrcUpDwnEventNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnEventNotificationOpacity.ValueChanged
        'Set the Opacity of the Event Notification.

        frmKlock.usrSettings.usrEventNotificationOpacity = Me.NmrcUpDwnEventNotificationOpacity.Value
    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrckBrOptionsVolume.Scroll
        '   Set system volume.

        frmKlock.usrSettings.usrSoundVolume = Me.TrckBrOptionsVolume.Value
    End Sub

    Private Sub btnOptionsTestVolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsTestVolume.Click
        '   Play a sound to test system volume.

        Me.displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\halfchime.mp3"))
    End Sub

    Private Sub ChckBxTimeToast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeToast.CheckedChanged
        '   If checkbox to enable notification message every nth minutes if checked, enables the minute counter.

        Me.UpDwnTimeDisplay.Enabled = Me.ChckBxTimeToast.Checked
    End Sub

    '---------------------------------------------------------- Friends Options  ---------------------------------------------------------------

    Private Sub btnOptionsFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsFile.Click
        '   Prompt user for the filename of the friends file - Default to friends.bin

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = Me.TxtBxOptionsFriendsDirectory.Text
        Me.OpenFileDialog1.FileName = Me.TxtBxOptionsFriendsFile.Text

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsFriendsFile.Text = Me.OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrFriendsFile = Me.OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Events Options  ---------------------------------------------------------------

    Private Sub btnOptionsEventsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsEventsFile.Click
        '   Prompt user for the filename of the Events file - Default to Events.bin

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        Me.OpenFileDialog1.FileName = Me.TxtBxOptionsEventsFile.Text

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsEventsFile.Text = Me.OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrEventsFile = Me.OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Memo Options  ---------------------------------------------------------------

    Private Sub btnOptionsMemoFile_Click(sender As System.Object, e As System.EventArgs) Handles btnOptionsMemoFile.Click
        '   Prompt user for the filename of the Memo file - Default to memo.bin

        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        Me.OpenFileDialog1.FileName = Me.TxtBxOptionsMemoFile.Text

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxOptionsMemoFile.Text = Me.OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrMemoFile = Me.OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub ChckBxMemoDefaultPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxMemoDefaultPassword.CheckedChanged

        Me.TxtBxMemoDefaultPassword.Enabled = Me.ChckBxMemoDefaultPassword.Checked
        Me.TxtBxMemoDefaultPassword.ReadOnly = Me.ChckBxMemoDefaultPassword.Checked
        Me.NmrcUpDwnMemoDecrypt.Enabled = Me.ChckBxMemoDefaultPassword.Checked
    End Sub

    ' **************************************************************************************** Archive stuff ***************************

    Private Sub btnOptionsPathReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsPathReset.Click
        '   Reset the location of the data files to that of the system default data area [i.e. same as settings file].

        Me.TxtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath
        Me.TxtBxOptionsFriendsFile.Text = "Friends.bin"

        Me.TxtBxOptionsEventsFile.Text = "Events.bin"
    End Sub

    Private Sub btnArchiveDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveDirectory.Click
        '   Prompt user for location of the Archive file.
        '   If file exists, enable load button.  Enable save button as well

        If Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxArchiveDirectory.Text = Me.FolderBrowserDialog1.SelectedPath

            Me.btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(Me.TxtBxArchiveDirectory.Text, Me.TxtBxArchiveFile.Text)) Then
                Me.btnArchiveLoad.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnArchiveFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveFile.Click
        '   Prompt user for file name of the Archive file.
        '   If file exists, enable load button.  Enable save button as well


        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.InitialDirectory = Me.TxtBxArchiveDirectory.Text
        Me.OpenFileDialog1.FileName = Me.TxtBxArchiveFile.Text
        Me.OpenFileDialog1.DefaultExt = ".zip"

        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.TxtBxArchiveFile.Text = Me.OpenFileDialog1.SafeFileName

            Me.btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(Me.TxtBxArchiveDirectory.Text, Me.TxtBxArchiveFile.Text)) Then
                Me.btnArchiveLoad.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnArchiveSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveSave.Click
        '   Saves the friends file to Archive [zip].
        '   If the achieve already exists, it will only be overwritten on user prompt.

        Dim zippath As String = System.IO.Path.Combine(Me.TxtBxArchiveDirectory.Text, Me.TxtBxArchiveFile.Text) '   path of destination zip file.
        Dim zipdir As String = frmKlock.usrSettings.usrOptionsSavePath                                          '   path of source directory.

        If My.Computer.FileSystem.FileExists(zippath) Then      '   file already exists, prompt user.
            Dim reply As MsgBoxResult

            reply = MsgBox("This will over write existing Archive file", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

            If reply = MsgBoxResult.No Then     '   Not to over write, exit sub.
                Me.btnArchiveSave.Enabled = False
                Exit Sub
            End If
        End If

        '1) Lets create an empty Zip File .
        'The following data represents an empty zip file .

        Dim startBuffer() As Byte = {80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        ' Data for an empty zip file .
        FileIO.FileSystem.WriteAllBytes(zippath, startBuffer, False)

        'We have successfully made the empty zip file .

        '2) Use the Shell32 to zip your files .
        ' Declare new shell class
        Dim sc As New Shell32.Shell()
        'Declare the folder which contains the files you want to zip .
        Dim input As Shell32.Folder = sc.NameSpace(zipdir)
        'Declare  your created empty zip file as folder  .
        Dim output As Shell32.Folder = sc.NameSpace(zippath)
        'Copy the files into the empty zip file using the CopyHere command .

        Try
            output.CopyHere(input.Items, 4)                                     '   save Archive
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Saving File Error", "Error archiving Friends File. " & ex.Message)
        End Try
    End Sub

    Private Sub btnArchiveLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveLoad.Click
        '   Load the friends file from Archive.
        '   The file will only be overwritten, if it exists, on user prompt.
        '   If the path does not exist, it will be created.

        Dim zippath As String = System.IO.Path.Combine(Me.TxtBxArchiveDirectory.Text, Me.TxtBxArchiveFile.Text) '   path of source sip file.
        Dim zipdir As String = frmKlock.usrSettings.usrOptionsSavePath                                          '   path of destination directory.

        Dim sc As New Shell32.Shell()

        If Not My.Computer.FileSystem.DirectoryExists(zipdir) Then
            My.Computer.FileSystem.CreateDirectory(zipdir)
        End If

        'Declare the folder where the files will be extracted
        Dim output As Shell32.Folder = sc.NameSpace(zipdir)
        'Declare your input zip file as folder  .
        Dim input As Shell32.Folder = sc.NameSpace(zippath)
        'Extract the files from the zip file using the CopyHere command .

        Try                                           '   catch extract error, if any.
            output.CopyHere(input.Items, 4)
            frmKlock.reloadFriends = True             '   set to re-load friends file.
        Catch ex As Exception
            Me.displayAction.DisplayReminder("Loading File Error", "Error archiving Friends File. " & ex.Message)
        End Try
    End Sub

End Class