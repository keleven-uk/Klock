Imports Shell32
Imports System.Environment

Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    Public displayAction As selectAction


    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   When opened, set settings

        Dim tabs() As String = {"Fuzzy Time", "World Klock", "Count Down", "Timer", "Reminder", "Friends", "Events", "Memo", "Converter"}
        Dim mode() As String = {"Klock", "Analogue Klock", "Small Text Klock", "Big text Klock"}

        cmbBxDefaultTab.Items.AddRange(tabs)
        cmbBxDefaultMode.Items.AddRange(mode)

        '   Only allow to select start up mode, if klock not starting minimised.
        If chckBxOptionsStartupMinimised.Checked Then
            chckBxOptionsRememberKlockMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
            cmbBxDefaultMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
        Else
            cmbBxDefaultMode.Enabled = chckBxOptionsRememberKlockMode.Checked
        End If

        displayAction = New selectAction

        txtBxArchiveFile.Text = "Klock.zip"
        lblOptionSavepath.Text = System.IO.Path.Combine(frmKlock.usrSettings.usrOptionsSavePath(), frmKlock.usrSettings.usrOptionsSaveFile())

        checkPicture()

        showArchiveButtons(False)
        setSettings()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------tab control ---------------------

    Private Sub TabCntrlOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCntrlOptions.SelectedIndexChanged
        '   actions depending upon which tab is chosen.

        Select Case tbCntrlOptions.SelectedIndex
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

        cmbBxDefaultTab.SelectedIndex = frmKlock.usrSettings.usrDefaultTab
        cmbBxDefaultMode.SelectedIndex = frmKlock.usrSettings.usrStartKlockMode

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        BackColor = frmKlock.usrSettings.usrFormColour

        lblColour.Font = frmKlock.usrSettings.usrFormFont
        lblColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        lblFont.Font = frmKlock.usrSettings.usrFormFont
        lblFont.ForeColor = frmKlock.usrSettings.usrFormFontColour
        lblDefaultColour.Font = frmKlock.usrSettings.usrFormFont
        lblDefaultColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        tbPgGlobal.BackColor = frmKlock.usrSettings.usrFormColour

        chckBxOptionsSavePos.Checked = frmKlock.usrSettings.usrSavePosition
        chckBxOptionsRunOnStartup.Checked = frmKlock.usrSettings.usrRunOnStartup
        chckBxOptionsStartupMinimised.Checked = frmKlock.usrSettings.usrStartMinimised
        chckBxOptionsRememberKlockMode.Checked = frmKlock.usrSettings.usrRememberKlockMode

        trckBrOptionsVolume.Minimum = 0
        trckBrOptionsVolume.Maximum = 1000
        trckBrOptionsVolume.TickFrequency = 100
        trckBrOptionsVolume.Value = frmKlock.usrSettings.usrSoundVolume

        txtBxOptionsSettingsFile.Text = If(frmKlock.usrSettings.usrFriendsFile = "", "Klock.xml", frmKlock.usrSettings.usrOptionsSaveFile)
        txtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath

        '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

        cmbBxDefaultTimeFormat.SelectedIndex = frmKlock.usrSettings.usrTimeDefaultFormat
        cmbBxDefaultTimeTwoFormat.SelectedIndex = frmKlock.usrSettings.usrTimeTWODefaultFormat

        chckBxTimeTwoFormats.Checked = frmKlock.usrSettings.usrTimeTwoFormats
        chckBxIdleTime.Checked = frmKlock.usrSettings.usrTimeIdleTime

        chckBxTimeSwatch.Checked = frmKlock.usrSettings.usrTimeSwatchCentibeats
        chckBxTimeNetSeconds.Checked = frmKlock.usrSettings.usrTimeNETSeconds
        chckBxTimeHexIntuitor.Checked = frmKlock.usrSettings.usrTimeHexIntuitorFormat
        chckBxTimeHourPips.Checked = frmKlock.usrSettings.usrTimeHourPips
        chckBxTimeHourlyChimes.Checked = frmKlock.usrSettings.usrTimeHourChimes
        chckBxTimeHalfChimes.Checked = frmKlock.usrSettings.usrTimeHalfChimes
        chckBxTimeQuarterChimes.Checked = frmKlock.usrSettings.usrTimeQuarterChimes
        chckBxTimeToast.Checked = frmKlock.usrSettings.usrTimeDisplayMinimised
        upDwnTimeDisplay.Value = frmKlock.usrSettings.usrTimeDisplayMinutes
        chckBxOptionsVoice.Checked = frmKlock.usrSettings.usrTimeVoiceMinimised
        upDwnVoiceDisplay.Value = frmKlock.usrSettings.usrTimeVoiceMinutes

        upDwnTimeDisplay.Enabled = frmKlock.usrSettings.usrTimeDisplayMinutes

        chckBxTimeSystem24.Checked = frmKlock.usrSettings.usrTimeSystem24Hour
        chckBxTimeSystem12.Checked = Not frmKlock.usrSettings.usrTimeSystem24Hour
        chckBxTimeTimeOne24.Checked = frmKlock.usrSettings.usrTimeOne24Hour
        chckBxTimeTimeOne12.Checked = Not frmKlock.usrSettings.usrTimeOne24Hour
        chckBxTimeTimeTwo24.Checked = frmKlock.usrSettings.usrTimeTwo24Hour
        chckBxTimeTimeTwo12.Checked = Not frmKlock.usrSettings.usrTimeTwo24Hour

        '-------------------------------------------------------------------------------------------------------- Text Klock --------------

        chckBxSmlTxKlockSavePos.Checked = frmKlock.usrSettings.usrSmallKlockSavePosition
        btnSmlTxtKlckFrClr.BackColor = frmKlock.usrSettings.usrSmallKlockForeColour
        btnSmlTxtKlckBckClr.BackColor = frmKlock.usrSettings.usrSmallKlockBackColour
        btnSmlTxtKlckOffClr.BackColor = frmKlock.usrSettings.usrSmallKlockOffColour

        chckBxBgTxKlockSavePos.Checked = frmKlock.usrSettings.usrBigKlockSavePosition
        btnBgTxtKlckFrClr.BackColor = frmKlock.usrSettings.usrBigKlockForeColour
        btnBgTxtKlckBckClr.BackColor = frmKlock.usrSettings.usrBigKlockBackColour
        btnBgTxtKlckOffClr.BackColor = frmKlock.usrSettings.usrBigKlockOffColour

        '-------------------------------------------------------------------------------------------------------- Analogue Klock ------------

        chckBxAnlgKlockSavePos.Checked = frmKlock.usrSettings.usrAnalogueKlockSavePosition
        chckBxAnlgKlockSaveSize.Checked = frmKlock.usrSettings.usrAnalogueKlockSizePosition
        txtBxAnlgKlock.Text = frmKlock.usrSettings.usrAnalogueKlockText
        chckBxAnlgKlockTransparent.Checked = frmKlock.usrSettings.usrAnalogueKlcokTransparent
        chckBxAnlgKlockDate.Checked = frmKlock.usrSettings.usrAnalogueKlockShowDate
        chckBxAnlgKlockTime.Checked = frmKlock.usrSettings.usrAnalogueKlockShowTime
        chckBxAnlgKlockIdleTime.Checked = frmKlock.usrSettings.usrAnalogueKlockShowIdleTime
        btnAnlgKlockBackColour.BackColor = frmKlock.usrSettings.usrAnalogueKlockBackColour
        chckBxAnlgKlockDisplayPicture.Checked = frmKlock.usrSettings.usrAnalogueKlockDisplayPicture
        txtBxAnlgKlockPictureLocation.Text = frmKlock.usrSettings.usrAnalogueKlockPicture

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        chckBxTimerHigh.Checked = frmKlock.usrSettings.usrTimerHigh
        chckBxClearSplit.Checked = frmKlock.usrSettings.usrTimerClearSplit
        chckBxTimerAdd.Checked = frmKlock.usrSettings.usrTimerAdd

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        chckBxCountdownAdd.Checked = frmKlock.usrSettings.usrCountdownAdd

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        chckBxReminderAdd.Checked = frmKlock.usrSettings.usrReminderAdd

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        chckBxWorldKlockAdd.Checked = frmKlock.usrSettings.usrWorldKlockAdd

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        ChckBxSayings.Checked = frmKlock.usrSettings.usrSayingsDisplay

        nmrcUpDwnNotificationTimeOut.Value = frmKlock.usrSettings.usrNotificationTimeOut / 1000
        nmrcUpDwnSayingNotificationTimeOut.Value = frmKlock.usrSettings.usrSayingsTimeOut / 1000
        nmrcUpDwnSayingDisplay.Value = frmKlock.usrSettings.usrSayingsDisplayTime                   '   held in minutes

        nmrcUpDwnNotificationOpacity.Value = frmKlock.usrSettings.usrNotificationOpacity
        nmrcUpDwnEventNotificationOpacity.Value = frmKlock.usrSettings.usrEventNotificationOpacity
        nmrcUpDwnSayingNotificationOpacity.Value = frmKlock.usrSettings.usrSayingsOpacity

        '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------

        chckBxDisableMonitorSleep.Checked = frmKlock.usrSettings.usrDisableMonitorSleep

        '-------------------------------------------------------------------------------------------------------- Internet Settings ------------

        chckBxChckInternet.Checked = frmKlock.usrSettings.usrCheckInternet

        '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --

        chckBxClipboardMonitor.Checked = frmKlock.usrSettings.usrClipboardMonitor
        chckBxClipboardSavePos.Checked = frmKlock.usrSettings.usrClipboardMonitorSavePosition
        chckBxClipboardSaveCSV.Checked = frmKlock.usrSettings.usrClipboardMonitorSaveCSV
        chckBxClipboardSavePos.Enabled = chckBxClipboardMonitor.Checked
        chckBxClipboardSaveCSV.Enabled = chckBxClipboardMonitor.Checked

        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        txtBxOptionsFriendsFile.Text = If(frmKlock.usrSettings.usrFriendsFile = "", "Friends.bin", frmKlock.usrSettings.usrFriendsFile)

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        txtBxOptionsEventsFile.Text = If(frmKlock.usrSettings.usrEventsFile = "", "Events.bin", frmKlock.usrSettings.usrEventsFile)

        nmrcUpDwnFirstReminder.Value = frmKlock.usrSettings.usrEventsFirstReminder
        nmrcUpDwnSecondReminder.Value = frmKlock.usrSettings.usrEventsSecondReminder
        nmrcUpDwnThirdReminder.Value = frmKlock.usrSettings.usrEventsThirdReminder
        nmrcUpDwnEventsInterval.Value = frmKlock.usrSettings.usrEventsTimerInterval                   '   held in minutes

        pctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        pctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        pctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        txtBxOptionsMemoFile.Text = If(frmKlock.usrSettings.usrMemoFile = "", "Memo.bin", frmKlock.usrSettings.usrMemoFile)

        chckBxMemoDefaultPassword.Checked = frmKlock.usrSettings.usrMemoUseDefaultPassword
        txtBxMemoDefaultPassword.Text = frmKlock.usrSettings.usrMemoDefaultPassword

        nmrcUpDwnMemoDecrypt.Value = frmKlock.usrSettings.usrMemoDecyptTimeOut
    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        frmKlock.usrSettings.usrDefaultTab = cmbBxDefaultTab.SelectedIndex
        frmKlock.usrSettings.usrStartKlockMode = cmbBxDefaultMode.SelectedIndex

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        frmKlock.usrSettings.usrSavePosition = chckBxOptionsSavePos.Checked
        frmKlock.usrSettings.usrRunOnStartup = chckBxOptionsRunOnStartup.Checked
        frmKlock.usrSettings.usrStartMinimised = chckBxOptionsStartupMinimised.Checked
        frmKlock.usrSettings.usrRememberKlockMode = chckBxOptionsRememberKlockMode.Checked

        If frmKlock.usrSettings.usrSavePosition Then
            frmKlock.usrSettings.usrFormTop = frmKlock.Top
            frmKlock.usrSettings.usrFormLeft = frmKlock.Left
        End If

        '-------------------------------------------------------------------------------------------------------- Time Settings --------------

        frmKlock.usrSettings.usrTimeDefaultFormat = cmbBxDefaultTimeFormat.SelectedIndex
        frmKlock.usrSettings.usrTimeTWODefaultFormat = cmbBxDefaultTimeTwoFormat.SelectedIndex

        frmKlock.usrSettings.usrTimeTwoFormats = chckBxTimeTwoFormats.Checked
        frmKlock.usrSettings.usrTimeIdleTime = chckBxIdleTime.Checked

        frmKlock.usrSettings.usrTimeSwatchCentibeats = chckBxTimeSwatch.Checked
        frmKlock.usrSettings.usrTimeNETSeconds = chckBxTimeNetSeconds.Checked
        frmKlock.usrSettings.usrTimeHexIntuitorFormat = chckBxTimeHexIntuitor.Checked
        frmKlock.usrSettings.usrTimeHourPips = chckBxTimeHourPips.Checked
        frmKlock.usrSettings.usrTimeHourChimes = chckBxTimeHourlyChimes.Checked
        frmKlock.usrSettings.usrTimeHalfChimes = chckBxTimeHalfChimes.Checked
        frmKlock.usrSettings.usrTimeQuarterChimes = chckBxTimeQuarterChimes.Checked
        frmKlock.usrSettings.usrTimeDisplayMinimised = chckBxTimeToast.Checked
        frmKlock.usrSettings.usrTimeDisplayMinutes = upDwnTimeDisplay.Value
        frmKlock.usrSettings.usrTimeVoiceMinimised = chckBxOptionsVoice.Checked
        frmKlock.usrSettings.usrTimeVoiceMinutes = upDwnVoiceDisplay.Value
        frmKlock.usrSettings.usrSoundVolume = trckBrOptionsVolume.Value

        frmKlock.usrSettings.usrTimeSystem24Hour = chckBxTimeSystem24.Checked
        frmKlock.usrSettings.usrTimeOne24Hour = chckBxTimeTimeOne24.Checked
        frmKlock.usrSettings.usrTimeTwo24Hour = chckBxTimeTimeTwo24.Checked

        '-------------------------------------------------------------------------------------------------------- Text Klock  Settings -------

        frmKlock.usrSettings.usrSmallKlockSavePosition = chckBxSmlTxKlockSavePos.Checked
        frmKlock.usrSettings.usrSmallKlockBackColour = btnSmlTxtKlckBckClr.BackColor
        frmKlock.usrSettings.usrSmallKlockForeColour = btnSmlTxtKlckFrClr.BackColor
        frmKlock.usrSettings.usrSmallKlockOffColour = btnSmlTxtKlckOffClr.BackColor

        frmKlock.usrSettings.usrBigKlockSavePosition = chckBxBgTxKlockSavePos.Checked
        frmKlock.usrSettings.usrBigKlockBackColour = btnBgTxtKlckBckClr.BackColor
        frmKlock.usrSettings.usrBigKlockForeColour = btnBgTxtKlckFrClr.BackColor
        frmKlock.usrSettings.usrBigKlockOffColour = btnBgTxtKlckOffClr.BackColor

        '-------------------------------------------------------------------------------------------------------- Analogue Klock  Settings ----

        frmKlock.usrSettings.usrAnalogueKlockSavePosition = chckBxAnlgKlockSavePos.Checked
        frmKlock.usrSettings.usrAnalogueKlockSizePosition = chckBxAnlgKlockSaveSize.Checked
        frmKlock.usrSettings.usrAnalogueKlockText = txtBxAnlgKlock.Text
        frmKlock.usrSettings.usrAnalogueKlcokTransparent = chckBxAnlgKlockTransparent.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowDate = chckBxAnlgKlockDate.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowTime = chckBxAnlgKlockTime.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowIdleTime = chckBxAnlgKlockIdleTime.Checked
        frmKlock.usrSettings.usrAnalogueKlockBackColour = btnAnlgKlockBackColour.BackColor
        frmKlock.usrSettings.usrAnalogueKlockDisplayPicture = chckBxAnlgKlockDisplayPicture.Checked
        'frmKlock.usrSettings.usrAnalogueKlockPicture = txtBxAnlgKlockPictureLocation.Text      ' already set to full path name.

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        frmKlock.usrSettings.usrTimerHigh = chckBxTimerHigh.Checked
        frmKlock.usrSettings.usrTimerClearSplit = chckBxClearSplit.Checked
        frmKlock.usrSettings.usrTimerAdd = chckBxTimerAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        frmKlock.usrSettings.usrCountdownAdd = chckBxCountdownAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        frmKlock.usrSettings.usrReminderTimeChecked = chckBxReminderTimeCheck.Checked
        frmKlock.usrSettings.usrReminderAdd = chckBxReminderAdd.Checked

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        frmKlock.usrSettings.usrWorldKlockAdd = chckBxWorldKlockAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        frmKlock.usrSettings.usrSayingsDisplay = ChckBxSayings.Checked

        frmKlock.usrSettings.usrNotificationTimeOut = nmrcUpDwnNotificationTimeOut.Value * 1000
        frmKlock.usrSettings.usrSayingsTimeOut = nmrcUpDwnSayingNotificationTimeOut.Value * 1000
        frmKlock.usrSettings.usrSayingsDisplayTime = nmrcUpDwnSayingDisplay.Value                   '   held in minutes

        frmKlock.usrSettings.usrNotificationOpacity = nmrcUpDwnNotificationOpacity.Value
        frmKlock.usrSettings.usrEventNotificationOpacity = nmrcUpDwnEventNotificationOpacity.Value
        frmKlock.usrSettings.usrSayingsOpacity = nmrcUpDwnSayingNotificationOpacity.Value

        '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------

        frmKlock.usrSettings.usrDisableMonitorSleep = chckBxDisableMonitorSleep.Checked

        '-------------------------------------------------------------------------------------------------------- Internet Settings ------------

        frmKlock.usrSettings.usrCheckInternet = chckBxChckInternet.Checked
        '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --

        frmKlock.usrSettings.usrClipboardMonitor = chckBxClipboardMonitor.Checked
        frmKlock.usrSettings.usrClipboardMonitorSavePosition = chckBxClipboardSavePos.Checked
        frmKlock.usrSettings.usrClipboardMonitorSaveCSV = chckBxClipboardSaveCSV.Checked
        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        frmKlock.usrSettings.usrFriendsFile = txtBxOptionsFriendsFile.Text

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        frmKlock.usrSettings.usrEventsFile = txtBxOptionsEventsFile.Text

        frmKlock.usrSettings.usrEventsFirstReminder = nmrcUpDwnFirstReminder.Value
        frmKlock.usrSettings.usrEventsSecondReminder = nmrcUpDwnSecondReminder.Value
        frmKlock.usrSettings.usrEventsThirdReminder = nmrcUpDwnThirdReminder.Value
        frmKlock.usrSettings.usrEventsTimerInterval = nmrcUpDwnEventsInterval.Value                   '   held in minutes

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        frmKlock.usrSettings.usrMemoFile = txtBxOptionsMemoFile.Text
        frmKlock.usrSettings.usrMemoUseDefaultPassword = chckBxMemoDefaultPassword.Checked
        frmKlock.usrSettings.usrMemoDefaultPassword = txtBxMemoDefaultPassword.Text
        frmKlock.usrSettings.usrMemoDecyptTimeOut = nmrcUpDwnMemoDecrypt.Value

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

        clrDlgFormColour.Color = frmKlock.usrSettings.usrFormColour          '   current main form colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrFormFont                  '   current main form font
        fntDlgFont.Color = frmKlock.usrSettings.usrFormFontColour            '   current main form font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFormFont = fntDlgFont.Font
            frmKlock.usrSettings.usrFormFontColour = fntDlgFont.Color
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

    Private Sub ChckBxOptionsRunOnStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxOptionsRunOnStartup.CheckedChanged
        '   Sets or deletes the registry key required for running on windows start up.
        '   Only sets for current user.

        Try
            If chckBxOptionsRunOnStartup.Checked Then
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            End If
        Catch ex As Exception
            displayAction.DisplayReminder("Registry Error :: Cant write entry to Registry", ex.Message, "G")
        End Try
    End Sub

    Private Sub chckBxOptionsStartupMinimised_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxOptionsStartupMinimised.CheckedChanged
        '   Only allow to select start up mode, if klock not starting minimised.

        chckBxOptionsRememberKlockMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
        cmbBxDefaultMode.Enabled = Not chckBxOptionsStartupMinimised.Checked
    End Sub

    Private Sub chckBxOptionsRememberKlockMode_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxOptionsRememberKlockMode.CheckedChanged

        cmbBxDefaultMode.Enabled = chckBxOptionsRememberKlockMode.Checked
    End Sub
    '-----------------------------------------------------------Time---------------------------------------------------------------

    Private Sub chckBxTimeTwoFormats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxTimeTwoFormats.CheckedChanged
        '   Only display two time default format if needed.

        lblTimeTwo.Enabled = chckBxTimeTwoFormats.Checked
        cmbBxDefaultTimeTwoFormat.Enabled = chckBxTimeTwoFormats.Checked
    End Sub

    Private Sub ChckBxTimeHourPips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxTimeHourPips.CheckedChanged
        '   It the pips are selected, disable all chimes.

        If chckBxTimeHourPips.Checked Then
            chckBxTimeHourlyChimes.Enabled = False
            chckBxTimeHourlyChimes.Checked = False
            chckBxTimeHalfChimes.Enabled = False
            chckBxTimeHalfChimes.Checked = False
            chckBxTimeQuarterChimes.Enabled = False
            chckBxTimeQuarterChimes.Checked = False
        Else
            chckBxTimeHourlyChimes.Enabled = True
            chckBxTimeHalfChimes.Enabled = True
            chckBxTimeQuarterChimes.Enabled = True
        End If
    End Sub

    Private Sub ChckBxTimeHourlyChimes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxTimeHourlyChimes.CheckedChanged
        '   if chimes are selected, disable the pips.

        If chckBxTimeHourlyChimes.Checked Then
            chckBxTimeHourPips.Enabled = False
            chckBxTimeHourPips.Checked = False
            chckBxTimeHalfChimes.Enabled = True
            chckBxTimeQuarterChimes.Enabled = True
        Else
            chckBxTimeHourPips.Enabled = True
            chckBxTimeHalfChimes.Checked = False
            chckBxTimeHalfChimes.Enabled = False
            chckBxTimeQuarterChimes.Checked = False
            chckBxTimeQuarterChimes.Enabled = False
        End If
    End Sub

    Private Sub ChckBxTimeSystem24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chckBxTimeSystem24.CheckedChanged

        chckBxTimeSystem12.Checked = Not chckBxTimeSystem24.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chckBxTimeTimeOne24.CheckedChanged

        chckBxTimeTimeOne12.Checked = Not chckBxTimeTimeOne24.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chckBxTimeTimeTwo24.CheckedChanged

        chckBxTimeTimeTwo12.Checked = Not chckBxTimeTimeTwo24.Checked
    End Sub

    Private Sub ChckBxTimeSystem12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chckBxTimeSystem12.CheckedChanged

        chckBxTimeSystem24.Checked = Not chckBxTimeSystem12.Checked
    End Sub

    Private Sub ChckBxTimeTimeOne12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chckBxTimeTimeOne12.CheckedChanged

        chckBxTimeTimeOne24.Checked = Not chckBxTimeTimeOne12.Checked
    End Sub

    Private Sub ChckBxTimeTimeTwo12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chckBxTimeTimeTwo12.CheckedChanged

        chckBxTimeTimeTwo24.Checked = Not chckBxTimeTimeTwo12.Checked
    End Sub

    Private Sub chckBxIdleTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxIdleTime.CheckedChanged
        '   Sets options for display idle time.
        '   Is selected, then select to display on analogue klock.

        frmKlock.DisplayIdleTime.Checked = chckBxIdleTime.Checked

        If chckBxIdleTime.Checked Then
            frmKlock.usrSettings.usrAnalogueKlockShowIdleTime = True
            chckBxAnlgKlockIdleTime.Checked = True
            chckBxAnlgKlockTime.Checked = True
        End If
    End Sub


    '-----------------------------------------------------------Text Klock---------------------------------------------------------------

    Private Sub btnSmlTxtKlckFrClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckFrClr.Click
        '   Sets the Fore colour for the small text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockForeColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockForeColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnSmlTxtKlckBckClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckBckClr.Click
        '   Sets the Back colour for the small text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockBackColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnSmlTxtKlckOffClr_Click(sender As Object, e As EventArgs) Handles btnSmlTxtKlckOffClr.Click
        '   Sets the Off colour for the small text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSmallKlockOffColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSmallKlockOffColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckFrClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckFrClr.Click
        '   Sets the Fore colour for the Big text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockForeColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockForeColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckBckClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckBckClr.Click
        '   Sets the Back colour for the Big text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockBackColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnBgTxtKlckOffClr_Click(sender As Object, e As EventArgs) Handles btnBgTxtKlckOffClr.Click
        '   Sets the Off colour for the Big text klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrBigKlockOffColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrBigKlockOffColour = clrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnResetSmallKlock_Click(sender As Object, e As EventArgs) Handles btnResetSmallKlock.Click
        '   reset colours for small klock.

        frmKlock.usrSettings.usrSmallKlockBackColour = Color.Black
        frmKlock.usrSettings.usrSmallKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrSmallKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    Private Sub btnResetBigKlock_Click(sender As Object, e As EventArgs) Handles btnResetBigKlock.Click
        '   reset colours for big klock.

        frmKlock.usrSettings.usrBigKlockBackColour = Color.Black
        frmKlock.usrSettings.usrBigKlockForeColour = Color.LightGreen
        frmKlock.usrSettings.usrBigKlockOffColour = Color.LightSlateGray

        setSettings()
    End Sub

    '-----------------------------------------------------------Analogue Klock---------------------------------------------------------------

    Private Sub btnAnlgKlockBackColour_Click(sender As Object, e As EventArgs) Handles btnAnlgKlockBackColour.Click
        '   Sets the background colour for the analogue klock

        clrDlgFormColour.Color = frmKlock.usrSettings.usrAnalogueKlockBackColour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrAnalogueKlockBackColour = clrDlgFormColour.Color
            btnAnlgKlockBackColour.BackColor = frmKlock.usrSettings.usrAnalogueKlockBackColour
            setSettings()
        End If
    End Sub

    Private Sub chckBxAnlgKlockTransparent_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockTransparent.CheckedChanged
        '   Make the analogue klock transparent.

        frmKlock.usrSettings.usrAnalogueKlcokTransparent = chckBxAnlgKlockTransparent.Checked
        btnAnlgKlockBackColour.Enabled = Not chckBxAnlgKlockTransparent.Checked
        lblAnlgKlockBackColour.Enabled = Not chckBxAnlgKlockTransparent.Checked

    End Sub

    Private Sub chckBxAnlgKlockDate_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockDate.CheckedChanged
        '   Display the date on the analogue klocks dial.

        frmKlock.usrSettings.usrAnalogueKlockShowDate = chckBxAnlgKlockDate.Checked
    End Sub

    Private Sub chckBxAnlgKlockTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockTime.CheckedChanged
        '   Display the digital time on the analogue klocks dial.

        frmKlock.usrSettings.usrAnalogueKlockShowTime = chckBxAnlgKlockTime.Checked
    End Sub

    Private Sub chckBxAnlgKlockIdleTime_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockIdleTime.CheckedChanged

        frmKlock.usrSettings.usrAnalogueKlockShowIdleTime = chckBxAnlgKlockIdleTime.Checked
    End Sub

    Private Sub cxtBxAnlgKlock_TextChanged(sender As Object, e As EventArgs) Handles txtBxAnlgKlock.TextChanged
        '   Sets the dial text for the analogue klock

        frmKlock.usrSettings.usrAnalogueKlockText = txtBxAnlgKlock.Text
    End Sub

    Private Sub chckBxAnlgKlockDisplayPicture_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxAnlgKlockDisplayPicture.CheckedChanged
        '   Sets if a background image is displayed.

        checkPicture()
        frmAnalogueKlock.analogueKlockRefresh()
    End Sub

    Private Sub checkPicture()
        '   Sets if a background image is displayed.

        frmKlock.usrSettings.usrAnalogueKlockDisplayPicture = chckBxAnlgKlockDisplayPicture.Checked

        If chckBxAnlgKlockDisplayPicture.Checked Then
            pctrBxAnlgKlockPicture.Enabled = True
            btnAnlgKlockPictureLocation.Enabled = True
            txtBxAnlgKlockPictureLocation.Enabled = True
            txtBxAnlgKlockPictureLocation.Text = frmKlock.usrSettings.usrAnalogueKlockPicture

            If My.Computer.FileSystem.FileExists(frmKlock.usrSettings.usrAnalogueKlockPicture) Then
                pctrBxAnlgKlockPicture.ImageLocation = frmKlock.usrSettings.usrAnalogueKlockPicture
                pctrBxAnlgKlockPicture.Load()
            End If
        Else
            pctrBxAnlgKlockPicture.Enabled = False
            btnAnlgKlockPictureLocation.Enabled = False
            txtBxAnlgKlockPictureLocation.Enabled = False
            txtBxAnlgKlockPictureLocation.Text = String.Empty
            pctrBxAnlgKlockPicture.ImageLocation = String.Empty
            pctrBxAnlgKlockPicture.Image = Nothing
        End If
    End Sub

    Private Sub btnAnlgKlockPictureLocation_Click(sender As Object, e As EventArgs) Handles btnAnlgKlockPictureLocation.Click
        '   Load the background image for analogue klock.

        OpenFileDialog1.InitialDirectory = System.IO.Path.Combine(Application.StartupPath, "images")
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxAnlgKlockPictureLocation.Text = OpenFileDialog1.SafeFileName

            If My.Computer.FileSystem.FileExists(OpenFileDialog1.FileName) Then
                frmKlock.usrSettings.usrAnalogueKlockPicture = OpenFileDialog1.FileName
                pctrBxAnlgKlockPicture.ImageLocation = OpenFileDialog1.FileName
                pctrBxAnlgKlockPicture.Load()
                frmAnalogueKlock.analogueKlockRefresh()
            End If
        End If
    End Sub

    '-----------------------------------------------------------Notification---------------------------------------------------------------

    Private Sub btnNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationColour.Click
        '   Set the Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrNotificationbackColour   '   current Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationbackColour = clrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationFont.Click
        '   Set the Notification main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrNotificationFont                  '   current Notification font
        fntDlgFont.Color = frmKlock.usrSettings.usrNotificationFontColour           '   current Notification font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrNotificationFont = fntDlgFont.Font
            frmKlock.usrSettings.usrNotificationFontColour = fntDlgFont.Color
        End If
    End Sub


    Private Sub NmrcUpDwnNotificationTimeOut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nmrcUpDwnNotificationTimeOut.ValueChanged
        '   set the time out value of the Notification.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrNotificationTimeOut = nmrcUpDwnNotificationTimeOut.Value * 1000
    End Sub

    Private Sub NmrcUpDwnNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nmrcUpDwnNotificationOpacity.ValueChanged
        'Set the Opacity of the Notification.

        frmKlock.usrSettings.usrNotificationOpacity = nmrcUpDwnNotificationOpacity.Value
    End Sub

    Private Sub btnNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotificationTest.Click
        '   Display a test notification, showing the current notification opacity.

        displayAction.DisplayReminder("Notification Test", String.Format(" Opacity = {0}", frmKlock.usrSettings.usrNotificationOpacity), "G")
    End Sub

    '-------------------------------------------------------------- Sayings ------------------------------------------------------------------

    Private Sub ChckBxSayings_CheckedChanged(sender As Object, e As EventArgs) Handles ChckBxSayings.CheckedChanged
        '   determines if sayings are to be used.
        '   if not, disable all sayings options.
        '   Also, set time to state of checkbox.  i.e. if checked start timer.

        lblSayings1.Enabled = ChckBxSayings.Checked
        btnSayingNotificationColour.Enabled = ChckBxSayings.Checked
        lblSayings2.Enabled = ChckBxSayings.Checked
        btnSayingNotificationFont.Enabled = ChckBxSayings.Checked
        lblSayings3.Enabled = ChckBxSayings.Checked
        nmrcUpDwnSayingDisplay.Enabled = ChckBxSayings.Checked
        lblSayings4.Enabled = ChckBxSayings.Checked
        nmrcUpDwnSayingNotificationTimeOut.Enabled = ChckBxSayings.Checked
        lblSayings5.Enabled = ChckBxSayings.Checked
        nmrcUpDwnSayingNotificationOpacity.Enabled = ChckBxSayings.Checked
        btnSayingNotificationTest.Enabled = ChckBxSayings.Checked

        frmKlock.tmrSayings.Interval = nmrcUpDwnSayingDisplay.Value * 1000
        frmKlock.tmrSayings.Enabled = ChckBxSayings.Checked
    End Sub

    Private Sub btnSayingNotificationColour_Click(sender As Object, e As EventArgs) Handles btnSayingNotificationColour.Click
        '   Set the Sayings main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSayingsbackColour   '   current Sayings colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSayingsbackColour = clrDlgFormColour.Color
        End If
    End Sub

    Private Sub btnSayingNotificationFont_Click(sender As Object, e As EventArgs) Handles btnSayingNotificationFont.Click
        '   Set the Sayings main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrSayingsFont                  '   current Sayings font
        fntDlgFont.Color = frmKlock.usrSettings.usrSayingsFontColour           '   current Sayings font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSayingsFont = fntDlgFont.Font
            frmKlock.usrSettings.usrSayingsFontColour = fntDlgFont.Color
        End If
    End Sub

    Private Sub nmrcUpDwnSayingNotificationTimeOut_ValueChanged(sender As Object, e As EventArgs) Handles nmrcUpDwnSayingNotificationTimeOut.ValueChanged
        '   set the time out value of the Sayings.
        '   The value is displayed in seconds and set in millisecond's..

        frmKlock.usrSettings.usrSayingsTimeOut = nmrcUpDwnSayingNotificationTimeOut.Value * 1000
    End Sub

    Private Sub nmrcUpDwnSayingNotificationOpacity_ValueChanged(sender As Object, e As EventArgs) Handles nmrcUpDwnSayingNotificationOpacity.ValueChanged
        'Set the Opacity of the Sayings.

        frmKlock.usrSettings.usrSayingsOpacity = nmrcUpDwnSayingNotificationOpacity.Value
    End Sub

    Private Sub btnSayingNotificationTest_Click(sender As Object, e As EventArgs) Handles btnSayingNotificationTest.Click
        '   Display a test Sayings, showing the current Sayings opacity.

        displayAction.DisplayReminder("Sayings Test", String.Format(" Opacity = {0}", frmKlock.usrSettings.usrSayingsOpacity), "S")
    End Sub

    '-----------------------------------------------------------Event Notification--------------------------------------------------------------

    Private Sub btnEventNotificationFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventNotificationFont.Click
        '   Set the Event Notification main font.
        '   the font colour has to be handled separately.

        fntDlgFont.Font = frmKlock.usrSettings.usrEventNotificationFont                  '   current Event Notification font
        fntDlgFont.Color = frmKlock.usrSettings.usrEventNotificationFontColour           '   current Event Notification font colour

        If fntDlgFont.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrEventNotificationFont = fntDlgFont.Font
            frmKlock.usrSettings.usrEventNotificationFontColour = fntDlgFont.Color
        End If
    End Sub

    Private Sub btnFirstEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstEventNotificationColour.Click
        '   Set the First Event Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrFirstEventNotificationbackColour   '   current First Event Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrFirstEventNotificationbackColour = clrDlgFormColour.Color
            pctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        End If
    End Sub

    Private Sub btnSecondEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondEventNotificationColour.Click
        '   Set the Second Event Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrSecondEventNotificationbackColour   '   current Second Event Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrSecondEventNotificationbackColour = clrDlgFormColour.Color
            pctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        End If
    End Sub

    Private Sub btnThirdEventNotificationColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThirdEventNotificationColour.Click
        '   Set the Third Event Notification main colour.

        clrDlgFormColour.Color = frmKlock.usrSettings.usrThirdEventNotificationbackColour   '   current Third Event Notification colour
        If clrDlgFormColour.ShowDialog() = DialogResult.OK Then
            frmKlock.usrSettings.usrThirdEventNotificationbackColour = clrDlgFormColour.Color
            pctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour
        End If
    End Sub

    Private Sub NmrcUpDwnEventNotificationOpacity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nmrcUpDwnEventNotificationOpacity.ValueChanged
        'Set the Opacity of the Event Notification.

        frmKlock.usrSettings.usrEventNotificationOpacity = nmrcUpDwnEventNotificationOpacity.Value
    End Sub

    Private Sub btnEventNotificationTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEventNotificationTest.Click
        '   Display a test event notification, showing the current event notification opacity.

        Dim ev As New Events

        ev.EventName = "btnEventNotificationTest"

        displayAction.DisplayEvent(ev)
    End Sub

    '---------------------------------------------------------- Sound Volume ---------------------------------------------------------------

    Private Sub TrckBrOptionsVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trckBrOptionsVolume.Scroll
        '   Set system volume.

        frmKlock.usrSettings.usrSoundVolume = trckBrOptionsVolume.Value
    End Sub

    Private Sub btnOptionsTestVolume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsTestVolume.Click
        '   Play a sound to test system volume.

        displayAction.PlaySound(System.IO.Path.Combine(Application.StartupPath, "Sounds\halfchime.mp3"))
    End Sub

    Private Sub ChckBxTimeToast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxTimeToast.CheckedChanged
        '   If checkbox to enable notification message every nth minutes if checked, enables the minute counter.

        upDwnTimeDisplay.Enabled = chckBxTimeToast.Checked
    End Sub

    '---------------------------------------------------------- Monitor Options  ---------------------------------------------------------------

    Private Sub ChckBxDisableMonitorSleep_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxDisableMonitorSleep.CheckedChanged
        '   if checkbox is enabled, then disallow the monitor from going to sleep.
        '   other wise allow monitor to go to sleep as system [OS] default.

        If chckBxDisableMonitorSleep.Checked Then
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
        OpenFileDialog1.InitialDirectory = txtBxOptionsFriendsDirectory.Text
        OpenFileDialog1.FileName = txtBxOptionsFriendsFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxOptionsFriendsFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrFriendsFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Events Options  ---------------------------------------------------------------

    Private Sub btnOptionsEventsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsEventsFile.Click
        '   Prompt user for the filename of the Events file - Default to Events.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        OpenFileDialog1.FileName = txtBxOptionsEventsFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxOptionsEventsFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrEventsFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    '---------------------------------------------------------- Memo Options  ---------------------------------------------------------------

    Private Sub btnOptionsMemoFile_Click(sender As System.Object, e As System.EventArgs) Handles btnOptionsMemoFile.Click
        '   Prompt user for the filename of the Memo file - Default to memo.bin

        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = frmKlock.usrSettings.usrOptionsSavePath
        OpenFileDialog1.FileName = txtBxOptionsMemoFile.Text

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxOptionsMemoFile.Text = OpenFileDialog1.SafeFileName
            frmKlock.usrSettings.usrMemoFile = OpenFileDialog1.SafeFileName
        End If
    End Sub

    Private Sub ChckBxMemoDefaultPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckBxMemoDefaultPassword.CheckedChanged

        txtBxMemoDefaultPassword.Enabled = chckBxMemoDefaultPassword.Checked
        txtBxMemoDefaultPassword.ReadOnly = chckBxMemoDefaultPassword.Checked
        nmrcUpDwnMemoDecrypt.Enabled = chckBxMemoDefaultPassword.Checked
    End Sub

    ' **************************************************************************************** Archive stuff ***************************

    Private Sub btnOptionsPathReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsPathReset.Click
        '   Reset the location of the data files to that of the system default data area [i.e. same as settings file].

        txtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath
        txtBxOptionsFriendsFile.Text = "Friends.bin"

        txtBxOptionsEventsFile.Text = "Events.bin"
    End Sub

    Private Sub btnArchiveDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveDirectory.Click
        '   Prompt user for location of the Archive file.
        '   If file exists, enable load button.  Enable save button as well

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtBxArchiveDirectory.Text = FolderBrowserDialog1.SelectedPath

            btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text)) Then
                btnArchiveLoad.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnArchiveFriendsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveFile.Click
        '   Prompt user for file name of the Archive file.
        '   If file exists, enable load button.  Enable save button as well


        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.InitialDirectory = txtBxArchiveDirectory.Text
        OpenFileDialog1.FileName = txtBxArchiveFile.Text
        OpenFileDialog1.DefaultExt = ".zip"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtBxArchiveFile.Text = OpenFileDialog1.SafeFileName

            btnArchiveSave.Enabled = True

            If My.Computer.FileSystem.FileExists(System.IO.Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text)) Then
                btnArchiveLoad.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnArchiveSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveSave.Click
        '   Saves the friends, events, memo & settings files to Archive [zip].
        '   If the achieve already exists, it will only be overwritten on user prompt.

        Dim zippath As String = System.IO.Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text) '   path of destination zip file.
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
            displayAction.DisplayReminder("Saving File Okay", "Archiving Data Files Successful.", "G")
        Catch ex As Exception
            displayAction.DisplayReminder("Saving File Error", "Error archiving Data Files. " & ex.Message, "G")
        End Try
    End Sub

    Private Sub btnArchiveLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveLoad.Click
        '   Load the friends file from Archive.
        '   The file will only be overwritten, if it exists, on user prompt.
        '   If the path does not exist, it will be created.

        Dim zippath As String = System.IO.Path.Combine(txtBxArchiveDirectory.Text, txtBxArchiveFile.Text) '   path of source sip file.
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
            displayAction.DisplayReminder("Loading File Okay", "Loading Data Files Successful.", "G")
        Catch ex As Exception
            displayAction.DisplayReminder("Loading File Error", "Error Loading Data Files. " & ex.Message, "G")
        End Try
    End Sub


    ' ********************************************************************************** Clipboard monitor stuff ***************************

    Private Sub ChckBxClipboardMonitor_CheckedChanged(sender As Object, e As EventArgs) Handles chckBxClipboardMonitor.CheckedChanged
        '   Determines if clipboard monitor is active.

        frmKlock.usrSettings.usrClipboardMonitor = chckBxClipboardMonitor.Checked
        chckBxClipboardSavePos.Enabled = chckBxClipboardMonitor.Checked
        chckBxClipboardSaveCSV.Enabled = chckBxClipboardMonitor.Checked
    End Sub
End Class