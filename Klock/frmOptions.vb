Imports Shell32

Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    Public displayAction As selectAction


    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   When opened, set settings

        Dim tabs() As String = {"Fuzzy Time", "World Klock", "Count Down", "Timer", "Reminder", "Friends", "Events", "Memo", "Converter"}

        displayAction = New selectAction

        TxtBxArchiveFile.Text = "Klock.zip"
        LblOptionSavepath.Text = System.IO.Path.Combine(frmKlock.usrSettings.usrOptionsSavePath(), frmKlock.usrSettings.usrOptionsSaveFile())

        CmbBxDefaultTab.Items.AddRange(tabs)

        TabCntrlOptions.SelectedIndex = 1

        showArchiveButtons(False)
        setSettings()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------tab control ---------------------

    Private Sub TabCntrlOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCntrlOptions.SelectedIndexChanged
        '   actions depending upon which tab is chosen.

        Select Case TabCntrlOptions.SelectedIndex
            Case 0              '   Global options
                showArchiveButtons(False)
            Case 1              '   Notification options
                showArchiveButtons(False)
            Case 2              '   Time options
                showArchiveButtons(False)
            Case 3              '   Text Klock Options
                showArchiveButtons(False)
            Case 4              '   Text Klock Options
                showArchiveButtons(False)
            Case 5              '   Other Stuff options
                showArchiveButtons(False)
            Case 6              '   Archive options
                showArchiveButtons(True)
            Case 7              '   Events options
                showArchiveButtons(False)
            Case 8              '   Memo options
                showArchiveButtons(False)
        End Select
    End Sub

    Private Sub showArchiveButtons(ByVal b As Boolean)
        '   either show of hide the archive buttons.
        '   not enough space on tab for buttons.

        btnArchiveLoad.Visible = b
        btnArchiveSave.Visible = b
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        'frmKlock.usrSettings.readSettings()     '   re-read settings, so we are always working current.

        CmbBxDefaultTab.SelectedIndex = frmKlock.usrSettings.usrDefaultTab

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        BackColor = frmKlock.usrSettings.usrFormColour

        lblColour.Font = frmKlock.usrSettings.usrFormFont
        lblColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        lblFont.Font = frmKlock.usrSettings.usrFormFont
        lblFont.ForeColor = frmKlock.usrSettings.usrFormFontColour
        lblDefaultColour.Font = frmKlock.usrSettings.usrFormFont
        lblDefaultColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        TbPgGlobal.BackColor = frmKlock.usrSettings.usrFormColour

        ChckBxOptionsSavePos.Checked = frmKlock.usrSettings.usrSavePosition
        ChckBxOptionsRunOnStartup.Checked = frmKlock.usrSettings.usrRunOnStartup
        ChckBxOptionsStartupMinimised.Checked = frmKlock.usrSettings.usrStartMinimised

        TrckBrOptionsVolume.Minimum = 0
        TrckBrOptionsVolume.Maximum = 1000
        TrckBrOptionsVolume.TickFrequency = 100
        TrckBrOptionsVolume.Value = frmKlock.usrSettings.usrSoundVolume

        TxtBxOptionsSettingsFile.Text = If(frmKlock.usrSettings.usrFriendsFile = "", "Klock.xml", frmKlock.usrSettings.usrOptionsSaveFile)
        TxtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath

        '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

        CmbBxDefaultTimeFormat.SelectedIndex = frmKlock.usrSettings.usrTimeDefaultFormat
        CmbBxDefaultTimeTwoFormat.SelectedIndex = frmKlock.usrSettings.usrTimeTWODefaultFormat

        chckBxTimeTwoFormats.Checked = frmKlock.usrSettings.usrTimeTwoFormats
        chckBxIdleTime.Checked = frmKlock.usrSettings.usrTimeIdleTime

        chckBxTimeSwatch.Checked = frmKlock.usrSettings.usrTimeSwatchCentibeats
        ChckBxTimeNetSeconds.Checked = frmKlock.usrSettings.usrTimeNETSeconds
        ChckBxTimeHexIntuitor.Checked = frmKlock.usrSettings.usrTimeHexIntuitorFormat
        ChckBxTimeHourPips.Checked = frmKlock.usrSettings.usrTimeHourPips
        ChckBxTimeHourlyChimes.Checked = frmKlock.usrSettings.usrTimeHourChimes
        ChckBxTimeHalfChimes.Checked = frmKlock.usrSettings.usrTimeHalfChimes
        ChckBxTimeQuarterChimes.Checked = frmKlock.usrSettings.usrTimeQuarterChimes
        ChckBxTimeToast.Checked = frmKlock.usrSettings.usrTimeDisplayMinimised
        UpDwnTimeDisplay.Value = frmKlock.usrSettings.usrTimeDisplayMinutes
        ChckBxOptionsVoice.Checked = frmKlock.usrSettings.usrTimeVoiceMinimised
        UpDwnVoiceDisplay.Value = frmKlock.usrSettings.usrTimeVoiceMinutes

        UpDwnTimeDisplay.Enabled = frmKlock.usrSettings.usrTimeDisplayMinutes

        ChckBxTimeSystem24.Checked = frmKlock.usrSettings.usrTimeSystem24Hour
        ChckBxTimeSystem12.Checked = Not frmKlock.usrSettings.usrTimeSystem24Hour
        ChckBxTimeTimeOne24.Checked = frmKlock.usrSettings.usrTimeOne24Hour
        ChckBxTimeTimeOne12.Checked = Not frmKlock.usrSettings.usrTimeOne24Hour
        ChckBxTimeTimeTwo24.Checked = frmKlock.usrSettings.usrTimeTwo24Hour
        ChckBxTimeTimeTwo12.Checked = Not frmKlock.usrSettings.usrTimeTwo24Hour

        '-------------------------------------------------------------------------------------------------------- Text Klock --------------

        btnSmlTxtKlckFrClr.BackColor = frmKlock.usrSettings.usrSmallKlockForeColour
        btnSmlTxtKlckBckClr.BackColor = frmKlock.usrSettings.usrSmallKlockBackColour
        btnSmlTxtKlckOffClr.BackColor = frmKlock.usrSettings.usrSmallKlockOffColour

        btnBgTxtKlckFrClr.BackColor = frmKlock.usrSettings.usrBigKlockForeColour
        btnBgTxtKlckBckClr.BackColor = frmKlock.usrSettings.usrBigKlockBackColour
        btnBgTxtKlckOffClr.BackColor = frmKlock.usrSettings.usrBigKlockOffColour

        '-------------------------------------------------------------------------------------------------------- Analogue Klock ------------

        txtBxAnlgKlock.Text = frmKlock.usrSettings.usrAnalogueKlockText
        chckBxAnlgKlockTransparent.Checked = frmKlock.usrSettings.usrAnalogueKlcokTransparent
        chckBxAnlgKlockDate.Checked = frmKlock.usrSettings.usrAnalogueKlockShowDate
        chckBxAnlgKlockTime.Checked = frmKlock.usrSettings.usrAnalogueKlockShowTime
        btnAnlgKlockBackColour.BackColor = frmKlock.usrSettings.usrAnalogueKlockBackColour

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        ChckBxTimerHigh.Checked = frmKlock.usrSettings.usrTimerHigh
        ChckBxClearSplit.Checked = frmKlock.usrSettings.usrTimerClearSplit
        ChckBxTimerAdd.Checked = frmKlock.usrSettings.usrTimerAdd

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        ChckBxCountdownAdd.Checked = frmKlock.usrSettings.usrCountdownAdd

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        ChckBxReminderAdd.Checked = frmKlock.usrSettings.usrReminderAdd

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        ChckBxWorldKlockAdd.Checked = frmKlock.usrSettings.usrWorldKlockAdd

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        NmrcUpDwnNotificationTimeOut.Value = frmKlock.usrSettings.usrNotificationTimeOut / 1000
        NmrcUpDwnNotificationOpacity.Value = frmKlock.usrSettings.usrNotificationOpacity

        NmrcUpDwnEventNotificationOpacity.Value = frmKlock.usrSettings.usrEventNotificationOpacity

        PctrBxNotification.BackColor = frmKlock.usrSettings.usrNotificationbackColour
        PctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        PctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        PctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour

        '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------

        ChckBxDisableMonitorSleep.Checked = frmKlock.usrSettings.usrDisableMonitorSleep

        '-------------------------------------------------------------------------------------------------------- Internet Settings ------------

        ChckBxChckInternet.Checked = frmKlock.usrSettings.usrCheckInternet

        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        TxtBxOptionsFriendsFile.Text = If(frmKlock.usrSettings.usrFriendsFile = "", "Friends.bin", frmKlock.usrSettings.usrFriendsFile)

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        TxtBxOptionsEventsFile.Text = If(frmKlock.usrSettings.usrEventsFile = "", "Events.bin", frmKlock.usrSettings.usrEventsFile)

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        TxtBxOptionsMemoFile.Text = If(frmKlock.usrSettings.usrMemoFile = "", "Memo.bin", frmKlock.usrSettings.usrMemoFile)

        NmrcUpDwnFirstReminder.Value = frmKlock.usrSettings.usrEventsFirstReminder
        NmrcUpDwnSecondReminder.Value = frmKlock.usrSettings.usrEventsSecondReminder
        NmrcUpDwnThirdReminder.Value = frmKlock.usrSettings.usrEventsThirdReminder
        NmrcUpDwnEventsInterval.Value = frmKlock.usrSettings.usrEventsTimerInterval

        ChckBxMemoDefaultPassword.Checked = frmKlock.usrSettings.usrMemoUseDefaultPassword
        TxtBxMemoDefaultPassword.Text = frmKlock.usrSettings.usrMemoDefaultPassword

        NmrcUpDwnMemoDecrypt.Value = frmKlock.usrSettings.usrMemoDecyptTimeOut
    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        frmKlock.usrSettings.usrDefaultTab = CmbBxDefaultTab.SelectedIndex

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        frmKlock.usrSettings.usrSavePosition = ChckBxOptionsSavePos.Checked
        frmKlock.usrSettings.usrRunOnStartup = ChckBxOptionsRunOnStartup.Checked
        frmKlock.usrSettings.usrStartMinimised = ChckBxOptionsStartupMinimised.Checked

        If frmKlock.usrSettings.usrSavePosition Then
            frmKlock.usrSettings.usrFormTop = frmKlock.Top
            frmKlock.usrSettings.usrFormLeft = frmKlock.Left
        End If

        '-------------------------------------------------------------------------------------------------------- Time Settings --------------

        frmKlock.usrSettings.usrTimeDefaultFormat = CmbBxDefaultTimeFormat.SelectedIndex
        frmKlock.usrSettings.usrTimeTWODefaultFormat = CmbBxDefaultTimeTwoFormat.SelectedIndex

        frmKlock.usrSettings.usrTimeTwoFormats = chckBxTimeTwoFormats.Checked
        frmKlock.usrSettings.usrTimeIdleTime = chckBxIdleTime.Checked

        frmKlock.usrSettings.usrTimeSwatchCentibeats = chckBxTimeSwatch.Checked
        frmKlock.usrSettings.usrTimeNETSeconds = ChckBxTimeNetSeconds.Checked
        frmKlock.usrSettings.usrTimeHexIntuitorFormat = ChckBxTimeHexIntuitor.Checked
        frmKlock.usrSettings.usrTimeHourPips = ChckBxTimeHourPips.Checked
        frmKlock.usrSettings.usrTimeHourChimes = ChckBxTimeHourlyChimes.Checked
        frmKlock.usrSettings.usrTimeHalfChimes = ChckBxTimeHalfChimes.Checked
        frmKlock.usrSettings.usrTimeQuarterChimes = ChckBxTimeQuarterChimes.Checked
        frmKlock.usrSettings.usrTimeDisplayMinimised = ChckBxTimeToast.Checked
        frmKlock.usrSettings.usrTimeDisplayMinutes = UpDwnTimeDisplay.Value
        frmKlock.usrSettings.usrTimeVoiceMinimised = ChckBxOptionsVoice.Checked
        frmKlock.usrSettings.usrTimeVoiceMinutes = UpDwnVoiceDisplay.Value
        frmKlock.usrSettings.usrSoundVolume = TrckBrOptionsVolume.Value

        frmKlock.usrSettings.usrTimeSystem24Hour = ChckBxTimeSystem24.Checked
        frmKlock.usrSettings.usrTimeOne24Hour = ChckBxTimeTimeOne24.Checked
        frmKlock.usrSettings.usrTimeTwo24Hour = ChckBxTimeTimeTwo24.Checked

        '-------------------------------------------------------------------------------------------------------- Text Klock  Settings -------

        frmKlock.usrSettings.usrSmallKlockBackColour = btnSmlTxtKlckBckClr.BackColor
        frmKlock.usrSettings.usrSmallKlockForeColour = btnSmlTxtKlckFrClr.BackColor
        frmKlock.usrSettings.usrSmallKlockOffColour = btnSmlTxtKlckOffClr.BackColor

        frmKlock.usrSettings.usrBigKlockBackColour = btnBgTxtKlckBckClr.BackColor
        frmKlock.usrSettings.usrBigKlockForeColour = btnBgTxtKlckFrClr.BackColor
        frmKlock.usrSettings.usrBigKlockOffColour = btnBgTxtKlckOffClr.BackColor

        '-------------------------------------------------------------------------------------------------------- Analogue Klock  Settings ----

        frmKlock.usrSettings.usrAnalogueKlockText = txtBxAnlgKlock.Text
        frmKlock.usrSettings.usrAnalogueKlcokTransparent = chckBxAnlgKlockTransparent.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowDate = chckBxAnlgKlockDate.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowTime = chckBxAnlgKlockTime.Checked
        frmKlock.usrSettings.usrAnalogueKlockBackColour = btnAnlgKlockBackColour.BackColor

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        frmKlock.usrSettings.usrTimerHigh = ChckBxTimerHigh.Checked
        frmKlock.usrSettings.usrTimerClearSplit = ChckBxClearSplit.Checked
        frmKlock.usrSettings.usrTimerAdd = ChckBxTimerAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        frmKlock.usrSettings.usrCountdownAdd = ChckBxCountdownAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        frmKlock.usrSettings.usrReminderTimeChecked = ChckBxReminderTimeCheck.Checked
        frmKlock.usrSettings.usrReminderAdd = ChckBxReminderAdd.Checked

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        frmKlock.usrSettings.usrWorldKlockAdd = ChckBxWorldKlockAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        frmKlock.usrSettings.usrNotificationTimeOut = NmrcUpDwnNotificationTimeOut.Value * 1000
        frmKlock.usrSettings.usrNotificationOpacity = NmrcUpDwnNotificationOpacity.Value

        frmKlock.usrSettings.usrEventNotificationOpacity = NmrcUpDwnEventNotificationOpacity.Value

        '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------

        frmKlock.usrSettings.usrDisableMonitorSleep = ChckBxDisableMonitorSleep.Checked

        '-------------------------------------------------------------------------------------------------------- Internet Settings ------------

        frmKlock.usrSettings.usrCheckInternet = ChckBxChckInternet.Checked

        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        frmKlock.usrSettings.usrFriendsFile = TxtBxOptionsFriendsFile.Text

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        frmKlock.usrSettings.usrEventsFile = TxtBxOptionsEventsFile.Text

        frmKlock.usrSettings.usrEventsFirstReminder = NmrcUpDwnFirstReminder.Value
        frmKlock.usrSettings.usrEventsSecondReminder = NmrcUpDwnSecondReminder.Value
        frmKlock.usrSettings.usrEventsThirdReminder = NmrcUpDwnThirdReminder.Value
        frmKlock.usrSettings.usrEventsTimerInterval = NmrcUpDwnEventsInterval.Value

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        frmKlock.usrSettings.usrMemoFile = TxtBxOptionsMemoFile.Text
        frmKlock.usrSettings.usrMemoUseDefaultPassword = ChckBxMemoDefaultPassword.Checked
        frmKlock.usrSettings.usrMemoDefaultPassword = TxtBxMemoDefaultPassword.Text
        frmKlock.usrSettings.usrMemoDecyptTimeOut = NmrcUpDwnMemoDecrypt.Value


        frmKlock.usrSettings.writeSettings()
        frmKlock.setSettings()

        Close()
    End Sub

    '-----------------------------------------------------------Buttons---------------------------------------------------------------

    Private Sub btnOptionsCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsCancel.Click
        '   when cancelled, close but not save.

        Close()
    End Sub

    Private Sub btnSettingsReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettingsReset.Click
        '   re-write settings file with defaults.

        frmKlock.usrSettings.writeDefaultSettings()
        frmKlock.usrSettings.readSettings()
        setSettings()
        frmKlock.setSettings()
    End Sub

    '-----------------------------------------------------------Global---------------------------------------------------------------

    Private Sub btnOptionsFormColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrFormColour          '   current main form colour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormColour = ClrDlgFormColour.Color
            setSettings()
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
            setSettings()
        End If
    End Sub

    Private Sub btnDefaultColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        frmKlock.usrSettings.usrFormColour = frmOptions.DefaultBackColor
        frmKlock.usrSettings.usrFormFont = frmOptions.DefaultFont
        frmKlock.usrSettings.usrFormFontColour = frmOptions.DefaultForeColor

        setSettings()
    End Sub

    Private Sub ChckBxOptionsRunOnStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxOptionsRunOnStartup.CheckedChanged
        '   Sets or deletes the registry key required for running on windows start up.
        '   Only sets for current user.

        Try
            If ChckBxOptionsRunOnStartup.Checked Then
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            displayAction.DisplayReminder("Registry Error :: Cant write entry to Registry", ex.Message)
        End Try
    End Sub

    '-----------------------------------------------------------Time---------------------------------------------------------------

    Private Sub chckBxTimeTwoFormats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxTimeTwoFormats.CheckedChanged
        '   Only display two time default format if needed.

        lblTimeTwo.Enabled = chckBxTimeTwoFormats.Checked
        CmbBxDefaultTimeTwoFormat.Enabled = chckBxTimeTwoFormats.Checked
    End Sub

    Private Sub ChckBxTimeHourPips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeHourPips.CheckedChanged
        '   It the pips are selected, disable all chimes.

        If ChckBxTimeHourPips.Checked Then
            ChckBxTimeHourlyChimes.Enabled = False
            ChckBxTimeHourlyChimes.Checked = False
            ChckBxTimeHalfChimes.Enabled = False
            ChckBxTimeHalfChimes.Checked = False
            ChckBxTimeQuarterChimes.Enabled = False
            ChckBxTimeQuarterChimes.Checked = False
        Else
            ChckBxTimeHourlyChimes.Enabled = True
            ChckBxTimeHalfChimes.Enabled = True
            ChckBxTimeQuarterChimes.Enabled = True
        End If
    End Sub

    Private Sub ChckBxTimeHourlyChimes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeHourlyChimes.CheckedChanged
        '   if chimes are selected, disable the pips.

        If ChckBxTimeHourlyChimes.Checked Then
            ChckBxTimeHourPips.Enabled = False
            ChckBxTimeHourPips.Checked = False
            ChckBxTimeHalfChimes.Enabled = True
            ChckBxTimeQuarterChimes.Enabled = True
        Else
            ChckBxTimeHourPips.Enabled = True
            ChckBxTimeHalfChimes.Checked = False
            ChckBxTimeHalfChimes.Enabled = False
            ChckBxTimeQuarterChimes.Checked = False
            ChckBxTimeQuarterChimes.Enabled = False
        End If
    End Sub

    Private Sub ChckBxTimeSystem24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeSystem24.CheckedChanged

        ChckBxTimeSystem12.Checked = Not ChckBxTimeSystem24.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeOne24.CheckedChanged

        ChckBxTimeTimeOne12.Checked = Not ChckBxTimeTimeOne24.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeTwo24.CheckedChanged

        ChckBxTimeTimeTwo12.Checked = Not ChckBxTimeTimeTwo24.Checked
    End Sub

    Private Sub ChckBxTimeSystem12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeSystem12.CheckedChanged

        ChckBxTimeSystem24.Checked = Not ChckBxTimeSystem12.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeOne12.CheckedChanged

        ChckBxTimeTimeOne24.Checked = Not ChckBxTimeTimeOne12.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChckBxTimeTimeTwo12.CheckedChanged

        ChckBxTimeTimeTwo24.Checked = Not ChckBxTimeTimeTwo12.Checked
    End Sub

    Private Sub chckBxIdleTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxIdleTime.CheckedChanged

        frmKlock.DisplayIdleTime.Checked = chckBxIdleTime.Checked
    End Sub


    '-----------------------------------------------------------Text Klock---------------------------------------------------------------

    Private Sub btnSmlTxtKlckFrClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckFrClr.Click
        '   Sets the Fore colour for the small text klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockForeColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockForeColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnSmlTxtKlckBckClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckBckClr.Click
        '   Sets the Back colour for the small text klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockBackColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockBackColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnSmlTxtKlckOffClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckOffClr.Click
        '   Sets the Off colour for the small text klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockOffColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockOffColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckFrClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckFrClr.Click
        '   Sets the Fore colour for the Big text klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockForeColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockForeColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckBckClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckBckClr.Click
        '   Sets the Back colour for the Big text klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockBackColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockBackColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckOffClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckOffClr.Click
        '   Sets the Off colour for the Big text klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockOffColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockOffColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnResetSmallKlock_Click(sender As Object, e As EventArgs) Handles btnResetSmallKlock.Click

        frmKlock.usrSettings.usrSmallKlockBackColour = Color.Black
        frmKlock.usrSettings.usrSmallKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrSmallKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    Private Sub btnResetBigKlock_Click(sender As Object, e As EventArgs) Handles btnResetBigKlock.Click

        frmKlock.usrSettings.usrBigKlockBackColour = Color.Black
        frmKlock.usrSettings.usrBigKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrBigKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    '-----------------------------------------------------------Analogue Klock---------------------------------------------------------------

    Private Sub btnAnlgKlockBackColour_Click(sender As Object, e As EventArgs) Handles btnAnlgKlockBackColour.Click
        '   Sets the background colour for the analogue klock

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrAnalogueKlockBackColour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrAnalogueKlockBackColour = ClrDlgFormColour.Color
            btnAnlgKlockBackColour.BackColor = frmKlock.usrSettings.usrAnalogueKlockBackColour
            setSettings()
        End If
    End Sub

    Private Sub chckBxAnlgKlockTransparent_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockTransparent.CheckedChanged

        frmKlock.usrSettings.usrAnalogueKlcokTransparent = chckBxAnlgKlockTransparent.Checked
        btnAnlgKlockBackColour.Enabled = Not chckBxAnlgKlockTransparent.Checked
        lblAnlgKlockBackColour.Enabled = Not chckBxAnlgKlockTransparent.Checked
    End Sub

    Private Sub chckBxAnlgKlockDate_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockDate.CheckedChanged

        frmKlock.usrSettings.usrAnalogueKlockShowDate = chckBxAnlgKlockDate.Checked
    End Sub

    Private Sub chckBxAnlgKlockTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockTime.CheckedChanged

        frmKlock.usrSettings.usrAnalogueKlockShowTime = chckBxAnlgKlockTime.checked
    End Sub

    Private Sub cxtBxAnlgKlock_TextChanged(sender As Object, e As EventArgs) Handles txtBxAnlgKlock.TextChanged
        '   Sets the dial text for the analogue klock

        frmKlock.usrSettings.usrAnalogueKlockText = txtBxAnlgKlock.Text
    End Sub

    '-----------------------------------------------------------Notification---------------------------------------------------------------

    Private Sub btnNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationColour.Click
        '   Set the Notification main colour.

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrNotificationbackColour   '   current Notification colour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationbackColour = ClrDlgFormColour.Color
            PctrBxNotification.BackColor = frmKlock.usrSettings.usrNotificationbackColour
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        FntDlgFont.Font = frmKlock.usrSettings.usrNotificationFont                  '   current Notification font
        FntDlgFont.Color = frmKlock.usrSettings.usrNotificationFontColour           '   current Notification font colour

        If FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationFont = FntDlgFont.Font
            frmKlock.usrSettings.usrNotificationFontColour = FntDlgFont.Color
        End If
    End Sub

    Private Sub btnEventNotificationFontColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrNotificationTimeOut = NmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        frmKlock.usrSettings.usrNotificationOpacity = NmrcUpDwnNotificationOpacity.Value
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationTest.Click
        '   Display a test notification, showing the current notification opacity.

        displayAction.DisplayReminder("Notification Test", String.Format(" Opacity = {0}", frmKlock.usrSettings.usrNotificationOpacity))
    End Sub

    Private Sub btnEventNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventNotificationTest.Click
        '   Display a test event notification, showing the current event notification opacity.

        Dim ev As New Events

        ev.EventName = "btnEventNotificationTest"

        displayAction.DisplayEvent(ev)
    End Sub

    '-----------------------------------------------------------Event Notification--------------------------------------------------------------

    Private Sub btnEventNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventNotificationFont.Click
        '   Set the Event Notification main font.
        '   the font colour has to be handled separately.

        FntDlgFont.Font = frmKlock.usrSettings.usrEventNotificationFont                  '   current Event Notification font
        FntDlgFont.Color = frmKlock.usrSettings.usrEventNotificationFontColour           '   current Event Notification font colour

        If FntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrEventNotificationFont = FntDlgFont.Font
            frmKlock.usrSettings.usrEventNotificationFontColour = FntDlgFont.Color
        End If
    End Sub

    Private Sub btnFirstEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstEventNotificationColour.Click
        '   Set the First Event Notification main colour.

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrFirstEventNotificationbackColour   '   current First Event Notification colour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFirstEventNotificationbackColour = ClrDlgFormColour.Color
            PctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        End If
    End Sub

    Private Sub btnSecondEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondEventNotificationColour.Click
        '   Set the Second Event Notification main colour.

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrSecondEventNotificationbackColour   '   current Second Event Notification colour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSecondEventNotificationbackColour = ClrDlgFormColour.Color
            PctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        End If
    End Sub

    Private Sub btnThirdEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThirdEventNotificationColour.Click
        '   Set the Third Event Notification main colour.

        ClrDlgFormColour.Color = frmKlock.usrSettings.usrThirdEventNotificationbackColour   '   current Third Event Notification colour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrThirdEventNotificationbackColour = ClrDlgFormColour.Color
            PctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour
        End If
    End Sub

    Private Sub NmrcUpDwnEventNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmrcUpDwnEventNotificationOpacity.ValueChanged
        'Set the Opacity of the Event Notification.

        frmKlock.usrSettings.usrEventNotificationOpacity = NmrcUpDwnEventNotificationOpacity.Value
    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrckBrOptionsVolume.Scroll
        '   Set system volume.

        frmKlock.usrSettings.usrSoundVolume = TrckBrOptionsVolume.Value
    End Sub

    Private Sub btnOptionsTestVolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsTestVolume.Click
        '   Play a sound to test system volume.

        displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\halfchime.mp3"))
    End Sub

    Private Sub ChckBxTimeToast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimeToast.CheckedChanged
        '   If checkbox to enable notification message every nth minutes if checked, enables the minute counter.

        UpDwnTimeDisplay.Enabled = ChckBxTimeToast.Checked
    End Sub

    '---------------------------------------------------------- Monitor Options  ---------------------------------------------------------------

    Private Sub ChckBxDisableMonitorSleep_CheckedChanged(sender As Object, e As EventArgs) Handles ChckBxDisableMonitorSleep.CheckedChanged
        '   if checkbox is enabled, then disallow the monitor from going to sleep.
        '   other wise allow monitor to go to sleep as system [OS] default.

        If ChckBxDisableMonitorSleep.Checked Then
            frmKlock.usrSettings.usrDisableMonitorSleep = True
            KlockThings.KeepMonitorActive()
        Else
            frmKlock.usrSettings.usrDisableMonitorSleep = False
            KlockThings.RestoreMonitorSettings()
        End If
    End Sub
    '---------------------------------------------------------- Friends Options  ---------------------------------------------------------------

    Private Sub btnOptionsFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFriendsFile.Click
        '   Prompt user for the filename of the friends file - Default to friends.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = TxtBxOptionsFriendsDirectory.Text
        OpenFileDialog1.FileName = TxtBxOptionsFriendsFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxOptionsFriendsFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrFriendsFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Events Options  ---------------------------------------------------------------

    Private Sub btnOptionsEventsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsEventsFile.Click
        '   Prompt user for the filename of the Events file - Default to Events.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        OpenFileDialog1.FileName = TxtBxOptionsEventsFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxOptionsEventsFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrEventsFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Memo Options  ---------------------------------------------------------------

    Private Sub btnOptionsMemoFile_Click(sender As System.Object, e As System.EventArgs) Handles btnOptionsMemoFile.Click
        '   Prompt user for the filename of the Memo file - Default to memo.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        OpenFileDialog1.FileName = TxtBxOptionsMemoFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxOptionsMemoFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrMemoFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub ChckBxMemoDefaultPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxMemoDefaultPassword.CheckedChanged

        TxtBxMemoDefaultPassword.Enabled = ChckBxMemoDefaultPassword.Checked
        TxtBxMemoDefaultPassword.ReadOnly = ChckBxMemoDefaultPassword.Checked
        NmrcUpDwnMemoDecrypt.Enabled = ChckBxMemoDefaultPassword.Checked
    End Sub

    ' **************************************************************************************** Archive stuff ***************************

    Private Sub btnOptionsPathReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsPathReset.Click
        '   Reset the location of the data files to that of the system default data area [i.e. same as settings file].

        TxtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath
        TxtBxOptionsFriendsFile.Text = "Friends.bin"

        TxtBxOptionsEventsFile.Text = "Events.bin"
    End Sub

    Private Sub btnArchiveDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveDirectory.Click
        '   Prompt user for location of the Archive file.
        '   If file exists, enable load button.  Enable save button as well

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxArchiveDirectory.Text = FolderBrowserDialog1.SelectedPath

            btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(TxtBxArchiveDirectory.Text, TxtBxArchiveFile.Text)) Then
                btnArchiveLoad.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnArchiveFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveFile.Click
        '   Prompt user for file name of the Archive file.
        '   If file exists, enable load button.  Enable save button as well


        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = TxtBxArchiveDirectory.Text
        OpenFileDialog1.FileName = TxtBxArchiveFile.Text
        OpenFileDialog1.DefaultExt = ".zip"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TxtBxArchiveFile.Text = OpenFileDialog1.SafeFileName

            btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(TxtBxArchiveDirectory.Text, TxtBxArchiveFile.Text)) Then
                btnArchiveLoad.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnArchiveSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveSave.Click
        '   Saves the friends, events, memo & settings files to Archive [zip].
        '   If the achieve already exists, it will only be overwritten on user prompt.

        Dim zippath As String = System.IO.Path.Combine(TxtBxArchiveDirectory.Text, TxtBxArchiveFile.Text) '   path of destination zip file.
        Dim zipdir As String = frmKlock.usrSettings.usrOptionsSavePath                                          '   path of source directory.

        If My.Computer.FileSystem.FileExists(zippath) Then      '   file already exists, prompt user.
            Dim reply As MsgBoxResult

            reply = MsgBox("This will over write existing Archive file", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

            If reply = MsgBoxResult.No Then     '   Not to over write, exit sub.
                btnArchiveSave.Enabled = False
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
            displayAction.DisplayReminder("Saving File Okay", "Archiving Data Files Successful.")
        Catch ex As Exception
            displayAction.DisplayReminder("Saving File Error", "Error archiving Data Files. " & ex.Message)
        End Try
    End Sub

    Private Sub btnArchiveLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveLoad.Click
        '   Load the friends file from Archive.
        '   The file will only be overwritten, if it exists, on user prompt.
        '   If the path does not exist, it will be created.

        Dim zippath As String = System.IO.Path.Combine(TxtBxArchiveDirectory.Text, TxtBxArchiveFile.Text) '   path of source sip file.
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
            displayAction.DisplayReminder("Loading File Okay", "Loading Data Files Successful.")
        Catch ex As Exception
            displayAction.DisplayReminder("Loading File Error", "Error Loading Data Files. " & ex.Message)
        End Try
    End Sub

End Class