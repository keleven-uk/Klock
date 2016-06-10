Module OptionThings

    Public Sub checkPicture()
        '   Sets if a background image is displayed in analogue Klock.

        frmKlock.usrSettings.usrAnalogueKlockDisplayPicture = frmOptions.chckBxAnlgKlockDisplayPicture.Checked

        If frmOptions.chckBxAnlgKlockDisplayPicture.Checked Then
            frmOptions.pctrBxAnlgKlockPicture.Enabled = True
            frmOptions.btnAnlgKlockPictureLocation.Enabled = True
            frmOptions.txtBxAnlgKlockPictureLocation.Enabled = True
            frmOptions.txtBxAnlgKlockPictureLocation.Text = frmKlock.usrSettings.usrAnalogueKlockPicture

            If My.Computer.FileSystem.FileExists(frmKlock.usrSettings.usrAnalogueKlockPicture) Then
                frmOptions.pctrBxAnlgKlockPicture.ImageLocation = frmKlock.usrSettings.usrAnalogueKlockPicture
                frmOptions.pctrBxAnlgKlockPicture.Load()
            End If
        Else
            frmOptions.pctrBxAnlgKlockPicture.Enabled = False
            frmOptions.btnAnlgKlockPictureLocation.Enabled = False
            frmOptions.txtBxAnlgKlockPictureLocation.Enabled = False
            frmOptions.txtBxAnlgKlockPictureLocation.Text = String.Empty
            frmOptions.pctrBxAnlgKlockPicture.ImageLocation = String.Empty
            frmOptions.pctrBxAnlgKlockPicture.Image = Nothing
        End If
    End Sub

    Public Function fileExists(file As String) As Boolean
        '   Checks if a file exists, if it does prompt the user.
        '   returns false if file exits and user says no to overwrite
        '   returns true if either file does not exist or file does and user says yes to overwrite.

        If My.Computer.FileSystem.FileExists(file) Then      '   file already exists, prompt user.
            Dim reply As MsgBoxResult

            reply = MsgBox("This will over write existing file : " & file.ToString, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "WARNING")

            Return If(reply = MsgBoxResult.No, False, True)
        Else
            Return True
        End If
    End Function

    Public Sub loadSettings()

        frmKlock.usrSettings.usrDefaultTab = frmOptions.cmbBxDefaultTab.SelectedIndex
        frmKlock.usrSettings.usrStartKlockMode = frmOptions.cmbBxDefaultMode.SelectedIndex

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        frmKlock.usrSettings.usrSavePosition = frmOptions.chckBxOptionsSavePos.Checked
        frmKlock.usrSettings.usrRunOnStartup = frmOptions.chckBxOptionsRunOnStartup.Checked
        frmKlock.usrSettings.usrStartMinimised = frmOptions.chckBxOptionsStartupMinimised.Checked
        frmKlock.usrSettings.usrRememberKlockMode = frmOptions.chckBxOptionsRememberKlockMode.Checked

        If frmKlock.usrSettings.usrSavePosition Then
            frmKlock.usrSettings.usrFormTop = frmKlock.Top
            frmKlock.usrSettings.usrFormLeft = frmKlock.Left
        End If

        '-------------------------------------------------------------------------------------------------------- Time Settings --------------

        frmKlock.usrSettings.usrTimeDefaultFormat = frmOptions.cmbBxDefaultTimeFormat.SelectedIndex
        frmKlock.usrSettings.usrTimeTWODefaultFormat = frmOptions.cmbBxDefaultTimeTwoFormat.SelectedIndex

        frmKlock.usrSettings.usrTimeTwoFormats = frmOptions.chckBxTimeTwoFormats.Checked
        frmKlock.usrSettings.usrTimeIdleTime = frmOptions.chckBxIdleTime.Checked

        frmKlock.usrSettings.usrTimeSwatchCentibeats = frmOptions.chckBxTimeSwatch.Checked
        frmKlock.usrSettings.usrTimeNETSeconds = frmOptions.chckBxTimeNetSeconds.Checked
        frmKlock.usrSettings.usrTimeHexIntuitorFormat = frmOptions.chckBxTimeHexIntuitor.Checked
        frmKlock.usrSettings.usrTimeHourPips = frmOptions.chckBxTimeHourPips.Checked
        frmKlock.usrSettings.usrTimeHourChimes = frmOptions.chckBxTimeHourlyChimes.Checked
        frmKlock.usrSettings.usrTimeHalfChimes = frmOptions.chckBxTimeHalfChimes.Checked
        frmKlock.usrSettings.usrTimeQuarterChimes = frmOptions.chckBxTimeQuarterChimes.Checked
        frmKlock.usrSettings.usrTimeDisplayMinimised = frmOptions.chckBxTimeToast.Checked
        frmKlock.usrSettings.usrTimeDisplayMinutes = frmOptions.upDwnTimeDisplay.Value
        frmKlock.usrSettings.usrTimeVoiceMinimised = frmOptions.chckBxOptionsVoice.Checked
        frmKlock.usrSettings.usrTimeVoiceMinutes = frmOptions.upDwnVoiceDisplay.Value
        frmKlock.usrSettings.usrSoundVolume = frmOptions.trckBrOptionsVolume.Value

        frmKlock.usrSettings.usrTimeSystem24Hour = frmOptions.chckBxTimeSystem24.Checked
        frmKlock.usrSettings.usrTimeOne24Hour = frmOptions.chckBxTimeTimeOne24.Checked
        frmKlock.usrSettings.usrTimeTwo24Hour = frmOptions.chckBxTimeTimeTwo24.Checked

        '-------------------------------------------------------------------------------------------------------- Sticky Notes ------------

        frmKlock.usrSettings.usrStickyNoteBackColour = frmOptions.btnStckyNtkBgClr.BackColor
        frmKlock.usrSettings.usrStickyNoteForeColour = frmOptions.btnStckyNtkFrClr.BackColor

        frmKlock.usrSettings.usrStickyNoteAllowFadeOut = frmOptions.ChckBxAllowStckyNtfadeOut.Checked

        frmKlock.usrSettings.usrStickyNoteMaxOpacity = frmOptions.NmrcUpDwnStkyNtMaxOpacity.Value
        frmKlock.usrSettings.usrStickyNoteMinOpacity = frmOptions.NmrcUpDwnStkyNtMinOpacity.Value
        frmKlock.usrSettings.usrStickyNoteStpOpacity = frmOptions.NmrcUpDwnStkyNtfadeOutStep.Value

        '-------------------------------------------------------------------------------------------------------- Text Klock  Settings -------

        frmKlock.usrSettings.usrSmallKlockSavePosition = frmOptions.chckBxSmlTxKlockSavePos.Checked
        frmKlock.usrSettings.usrSmallKlockBackColour = frmOptions.btnSmlTxtKlckBckClr.BackColor
        frmKlock.usrSettings.usrSmallKlockForeColour = frmOptions.btnSmlTxtKlckFrClr.BackColor
        frmKlock.usrSettings.usrSmallKlockOffColour = frmOptions.btnSmlTxtKlckOffClr.BackColor

        frmKlock.usrSettings.usrBigKlockSavePosition = frmOptions.chckBxBgTxKlockSavePos.Checked
        frmKlock.usrSettings.usrBigKlockBackColour = frmOptions.btnBgTxtKlckBckClr.BackColor
        frmKlock.usrSettings.usrBigKlockForeColour = frmOptions.btnBgTxtKlckFrClr.BackColor
        frmKlock.usrSettings.usrBigKlockOffColour = frmOptions.btnBgTxtKlckOffClr.BackColor

        '-------------------------------------------------------------------------------------------------------- Binary  Settings -----------

        frmKlock.usrSettings.usrBinaryKlockSavePosition = frmOptions.chckBxBnryKlockSavePos.Checked
        frmKlock.usrSettings.usrBinaryKlockBackColour = frmOptions.btnBnryKlckBckClr.BackColor
        frmKlock.usrSettings.usrBinaryKlockForeColour = frmOptions.btnBnryKlckFrClr.BackColor
        frmKlock.usrSettings.usrBinaryKlockOffColour = frmOptions.btnBnryKlckOffClr.BackColor
        frmKlock.usrSettings.usrBinaryUseBCD = If(frmOptions.RdBtnBCD.Checked, True, False)
        '-------------------------------------------------------------------------------------------------------- Analogue Klock  Settings ----

        frmKlock.usrSettings.usrAnalogueKlockSavePosition = frmOptions.chckBxAnlgKlockSavePos.Checked
        frmKlock.usrSettings.usrAnalogueKlockSizePosition = frmOptions.chckBxAnlgKlockSaveSize.Checked
        frmKlock.usrSettings.usrAnalogueKlockText = frmOptions.txtBxAnlgKlock.Text
        frmKlock.usrSettings.usrAnalogueKlcokTransparent = frmOptions.chckBxAnlgKlockTransparent.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowDate = frmOptions.chckBxAnlgKlockDate.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowTime = frmOptions.chckBxAnlgKlockTime.Checked
        frmKlock.usrSettings.usrAnalogueKlockShowIdleTime = frmOptions.chckBxAnlgKlockIdleTime.Checked
        frmKlock.usrSettings.usrAnalogueKlockBackColour = frmOptions.btnAnlgKlockBackColour.BackColor
        frmKlock.usrSettings.usrAnalogueKlockDisplayPicture = frmOptions.chckBxAnlgKlockDisplayPicture.Checked
        'frmKlock.usrSettings.usrAnalogueKlockPicture = txtBxAnlgKlockPictureLocation.Text      ' already set to full path name.

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        frmKlock.usrSettings.usrTimerHigh = frmOptions.chckBxTimerHigh.Checked
        frmKlock.usrSettings.usrTimerClearSplit = frmOptions.chckBxClearSplit.Checked
        frmKlock.usrSettings.usrTimerAdd = frmOptions.chckBxTimerAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        frmKlock.usrSettings.usrCountdownAdd = frmOptions.chckBxCountdownAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        frmKlock.usrSettings.usrReminderTimeChecked = frmOptions.chckBxReminderTimeCheck.Checked
        frmKlock.usrSettings.usrReminderAdd = frmOptions.chckBxReminderAdd.Checked

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        frmKlock.usrSettings.usrWorldKlockAdd = frmOptions.chckBxWorldKlockAdd.Checked

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        frmKlock.usrSettings.usrSayingsDisplay = frmOptions.ChckBxSayings.Checked

        frmKlock.usrSettings.usrNotificationTimeOut = frmOptions.nmrcUpDwnNotificationTimeOut.Value * 1000
        frmKlock.usrSettings.usrSayingsTimeOut = frmOptions.nmrcUpDwnSayingNotificationTimeOut.Value * 1000
        frmKlock.usrSettings.usrSayingsDisplayTime = frmOptions.nmrcUpDwnSayingDisplay.Value                   '   held in minutes

        frmKlock.usrSettings.usrNotificationOpacity = frmOptions.nmrcUpDwnNotificationOpacity.Value
        frmKlock.usrSettings.usrEventNotificationOpacity = frmOptions.nmrcUpDwnEventNotificationOpacity.Value
        frmKlock.usrSettings.usrSayingsOpacity = frmOptions.nmrcUpDwnSayingNotificationOpacity.Value

        '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------

        frmKlock.usrSettings.usrDisableMonitorSleep = frmOptions.chckBxDisableMonitorSleep.Checked

        '-------------------------------------------------------------------------------------------------------- Internet Settings ------------

        frmKlock.usrSettings.usrCheckInternet = frmOptions.chckBxChckInternet.Checked

        '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --

        frmKlock.usrSettings.usrClipboardMonitor = frmOptions.chckBxClipboardMonitor.Checked
        frmKlock.usrSettings.usrClipboardMonitorSavePosition = frmOptions.chckBxClipboardSavePos.Checked
        frmKlock.usrSettings.usrClipboardMonitorSaveCSV = frmOptions.chckBxClipboardSaveCSV.Checked

        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        frmKlock.usrSettings.usrFriendsFile = frmOptions.txtBxOptionsFriendsFile.Text

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        frmKlock.usrSettings.usrEventsFile = frmOptions.txtBxOptionsEventsFile.Text

        frmKlock.usrSettings.usrEventsFirstReminder = frmOptions.nmrcUpDwnFirstReminder.Value
        frmKlock.usrSettings.usrEventsSecondReminder = frmOptions.nmrcUpDwnSecondReminder.Value
        frmKlock.usrSettings.usrEventsThirdReminder = frmOptions.nmrcUpDwnThirdReminder.Value
        frmKlock.usrSettings.usrEventsTimerInterval = frmOptions.nmrcUpDwnEventsInterval.Value                   '   held in minutes

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        frmKlock.usrSettings.usrMemoFile = frmOptions.txtBxOptionsMemoFile.Text
        frmKlock.usrSettings.usrMemoUseDefaultPassword = frmOptions.chckBxMemoDefaultPassword.Checked
        frmKlock.usrSettings.usrMemoDefaultPassword = frmOptions.txtBxMemoDefaultPassword.Text
        frmKlock.usrSettings.usrMemoDecyptTimeOut = frmOptions.nmrcUpDwnMemoDecrypt.Value

        '-------------------------------------------------------------------------------------------------------- Logging Settings ----------

        frmKlock.usrSettings.usrLogging = frmOptions.ChckBxLoging.Checked
        frmKlock.usrSettings.usrLogDaysKeep = frmOptions.nmrcUpDwnLogDaysKeep.Value
    End Sub

    Public Sub poolForLogs()
        '   Pool the chosen directory for log files.
        '   At the moment that is .log files in application data directory.

        frmOptions.lstBxLogFiles.Items.Clear()

        For i As Integer = 0 To frmKlock.errLogger.poolLogs().Count - 1
            frmOptions.lstBxLogFiles.Items.Add(frmKlock.errLogger.poolLogs(i))
        Next
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        frmOptions.cmbBxDefaultTab.SelectedIndex = frmKlock.usrSettings.usrDefaultTab
        frmOptions.cmbBxDefaultMode.SelectedIndex = frmKlock.usrSettings.usrStartKlockMode

        '-------------------------------------------------------------------------------------------------------- Global Settings -------------
        frmOptions.BackColor = frmKlock.usrSettings.usrFormColour

        frmOptions.lblColour.Font = frmKlock.usrSettings.usrFormFont
        frmOptions.lblColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        frmOptions.lblFont.Font = frmKlock.usrSettings.usrFormFont
        frmOptions.lblFont.ForeColor = frmKlock.usrSettings.usrFormFontColour
        frmOptions.lblDefaultColour.Font = frmKlock.usrSettings.usrFormFont
        frmOptions.lblDefaultColour.ForeColor = frmKlock.usrSettings.usrFormFontColour
        frmOptions.tbPgGlobal.BackColor = frmKlock.usrSettings.usrFormColour

        frmOptions.chckBxOptionsSavePos.Checked = frmKlock.usrSettings.usrSavePosition
        frmOptions.chckBxOptionsRunOnStartup.Checked = frmKlock.usrSettings.usrRunOnStartup
        frmOptions.chckBxOptionsStartupMinimised.Checked = frmKlock.usrSettings.usrStartMinimised
        frmOptions.chckBxOptionsRememberKlockMode.Checked = frmKlock.usrSettings.usrRememberKlockMode

        frmOptions.trckBrOptionsVolume.Minimum = 0
        frmOptions.trckBrOptionsVolume.Maximum = 1000
        frmOptions.trckBrOptionsVolume.TickFrequency = 100
        frmOptions.trckBrOptionsVolume.Value = frmKlock.usrSettings.usrSoundVolume

        frmOptions.txtBxOptionsSettingsFile.Text = If(frmKlock.usrSettings.usrFriendsFile = "", "Klock.xml", frmKlock.usrSettings.usrOptionsSaveFile)
        frmOptions.txtBxOptionsFriendsDirectory.Text = frmKlock.usrSettings.usrOptionsSavePath

        '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

        frmOptions.cmbBxDefaultTimeFormat.SelectedIndex = frmKlock.usrSettings.usrTimeDefaultFormat
        frmOptions.cmbBxDefaultTimeTwoFormat.SelectedIndex = frmKlock.usrSettings.usrTimeTWODefaultFormat

        frmOptions.chckBxTimeTwoFormats.Checked = frmKlock.usrSettings.usrTimeTwoFormats
        frmOptions.chckBxIdleTime.Checked = frmKlock.usrSettings.usrTimeIdleTime

        frmOptions.chckBxTimeSwatch.Checked = frmKlock.usrSettings.usrTimeSwatchCentibeats
        frmOptions.chckBxTimeNetSeconds.Checked = frmKlock.usrSettings.usrTimeNETSeconds
        frmOptions.chckBxTimeHexIntuitor.Checked = frmKlock.usrSettings.usrTimeHexIntuitorFormat
        frmOptions.chckBxTimeHourPips.Checked = frmKlock.usrSettings.usrTimeHourPips
        frmOptions.chckBxTimeHourlyChimes.Checked = frmKlock.usrSettings.usrTimeHourChimes
        frmOptions.chckBxTimeHalfChimes.Checked = frmKlock.usrSettings.usrTimeHalfChimes
        frmOptions.chckBxTimeQuarterChimes.Checked = frmKlock.usrSettings.usrTimeQuarterChimes
        frmOptions.chckBxTimeToast.Checked = frmKlock.usrSettings.usrTimeDisplayMinimised
        frmOptions.upDwnTimeDisplay.Value = frmKlock.usrSettings.usrTimeDisplayMinutes
        frmOptions.chckBxOptionsVoice.Checked = frmKlock.usrSettings.usrTimeVoiceMinimised
        frmOptions.upDwnVoiceDisplay.Value = frmKlock.usrSettings.usrTimeVoiceMinutes

        frmOptions.upDwnTimeDisplay.Enabled = frmKlock.usrSettings.usrTimeDisplayMinutes

        frmOptions.chckBxTimeSystem24.Checked = frmKlock.usrSettings.usrTimeSystem24Hour
        frmOptions.chckBxTimeSystem12.Checked = Not frmKlock.usrSettings.usrTimeSystem24Hour
        frmOptions.chckBxTimeTimeOne24.Checked = frmKlock.usrSettings.usrTimeOne24Hour
        frmOptions.chckBxTimeTimeOne12.Checked = Not frmKlock.usrSettings.usrTimeOne24Hour
        frmOptions.chckBxTimeTimeTwo24.Checked = frmKlock.usrSettings.usrTimeTwo24Hour
        frmOptions.chckBxTimeTimeTwo12.Checked = Not frmKlock.usrSettings.usrTimeTwo24Hour

        '-------------------------------------------------------------------------------------------------------- Sticky Notes ------------

        frmOptions.btnStckyNtkBgClr.BackColor = frmKlock.usrSettings.usrStickyNoteBackColour
        frmOptions.btnStckyNtkFrClr.BackColor = frmKlock.usrSettings.usrStickyNoteForeColour

        frmOptions.ChckBxAllowStckyNtfadeOut.Checked = frmKlock.usrSettings.usrStickyNoteAllowFadeOut

        frmOptions.NmrcUpDwnStkyNtMaxOpacity.Value = frmKlock.usrSettings.usrStickyNoteMaxOpacity
        frmOptions.NmrcUpDwnStkyNtMinOpacity.Value = frmKlock.usrSettings.usrStickyNoteMinOpacity
        frmOptions.NmrcUpDwnStkyNtfadeOutStep.Value = frmKlock.usrSettings.usrStickyNoteStpOpacity

        '-------------------------------------------------------------------------------------------------------- Text Klock --------------

        frmOptions.chckBxSmlTxKlockSavePos.Checked = frmKlock.usrSettings.usrSmallKlockSavePosition
        frmOptions.btnSmlTxtKlckFrClr.BackColor = frmKlock.usrSettings.usrSmallKlockForeColour
        frmOptions.btnSmlTxtKlckBckClr.BackColor = frmKlock.usrSettings.usrSmallKlockBackColour
        frmOptions.btnSmlTxtKlckOffClr.BackColor = frmKlock.usrSettings.usrSmallKlockOffColour

        frmOptions.chckBxBgTxKlockSavePos.Checked = frmKlock.usrSettings.usrBigKlockSavePosition
        frmOptions.btnBgTxtKlckFrClr.BackColor = frmKlock.usrSettings.usrBigKlockForeColour
        frmOptions.btnBgTxtKlckBckClr.BackColor = frmKlock.usrSettings.usrBigKlockBackColour
        frmOptions.btnBgTxtKlckOffClr.BackColor = frmKlock.usrSettings.usrBigKlockOffColour

        '-------------------------------------------------------------------------------------------------------- Binary  Settings -----------

        frmOptions.chckBxBnryKlockSavePos.Checked = frmKlock.usrSettings.usrBinaryKlockSavePosition
        frmOptions.btnBnryKlckBckClr.BackColor = frmKlock.usrSettings.usrBinaryKlockBackColour
        frmOptions.btnBnryKlckFrClr.BackColor = frmKlock.usrSettings.usrBinaryKlockForeColour
        frmOptions.btnBnryKlckOffClr.BackColor = frmKlock.usrSettings.usrBinaryKlockOffColour
        frmOptions.RdBtnBCD.Checked = frmKlock.usrSettings.usrBinaryUseBCD
        frmOptions.RdBtnBinary.Checked = Not frmKlock.usrSettings.usrBinaryUseBCD
        '-------------------------------------------------------------------------------------------------------- Analogue Klock ------------

        frmOptions.chckBxAnlgKlockSavePos.Checked = frmKlock.usrSettings.usrAnalogueKlockSavePosition
        frmOptions.chckBxAnlgKlockSaveSize.Checked = frmKlock.usrSettings.usrAnalogueKlockSizePosition
        frmOptions.txtBxAnlgKlock.Text = frmKlock.usrSettings.usrAnalogueKlockText
        frmOptions.chckBxAnlgKlockTransparent.Checked = frmKlock.usrSettings.usrAnalogueKlcokTransparent
        frmOptions.chckBxAnlgKlockDate.Checked = frmKlock.usrSettings.usrAnalogueKlockShowDate
        frmOptions.chckBxAnlgKlockTime.Checked = frmKlock.usrSettings.usrAnalogueKlockShowTime
        frmOptions.chckBxAnlgKlockIdleTime.Checked = frmKlock.usrSettings.usrAnalogueKlockShowIdleTime
        frmOptions.btnAnlgKlockBackColour.BackColor = frmKlock.usrSettings.usrAnalogueKlockBackColour
        frmOptions.chckBxAnlgKlockDisplayPicture.Checked = frmKlock.usrSettings.usrAnalogueKlockDisplayPicture
        frmOptions.txtBxAnlgKlockPictureLocation.Text = frmKlock.usrSettings.usrAnalogueKlockPicture

        '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

        frmOptions.chckBxTimerHigh.Checked = frmKlock.usrSettings.usrTimerHigh
        frmOptions.chckBxClearSplit.Checked = frmKlock.usrSettings.usrTimerClearSplit
        frmOptions.chckBxTimerAdd.Checked = frmKlock.usrSettings.usrTimerAdd

        '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

        frmOptions.chckBxCountdownAdd.Checked = frmKlock.usrSettings.usrCountdownAdd

        '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

        frmOptions.chckBxReminderAdd.Checked = frmKlock.usrSettings.usrReminderAdd

        '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

        frmOptions.chckBxWorldKlockAdd.Checked = frmKlock.usrSettings.usrWorldKlockAdd

        '-------------------------------------------------------------------------------------------------------- Notification Settings -------

        frmOptions.ChckBxSayings.Checked = frmKlock.usrSettings.usrSayingsDisplay

        frmOptions.nmrcUpDwnNotificationTimeOut.Value = frmKlock.usrSettings.usrNotificationTimeOut / 1000
        frmOptions.nmrcUpDwnSayingNotificationTimeOut.Value = frmKlock.usrSettings.usrSayingsTimeOut / 1000
        frmOptions.nmrcUpDwnSayingDisplay.Value = frmKlock.usrSettings.usrSayingsDisplayTime                   '   held in minutes

        frmOptions.nmrcUpDwnNotificationOpacity.Value = frmKlock.usrSettings.usrNotificationOpacity
        frmOptions.nmrcUpDwnEventNotificationOpacity.Value = frmKlock.usrSettings.usrEventNotificationOpacity
        frmOptions.nmrcUpDwnSayingNotificationOpacity.Value = frmKlock.usrSettings.usrSayingsOpacity

        '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------

        frmOptions.chckBxDisableMonitorSleep.Checked = frmKlock.usrSettings.usrDisableMonitorSleep

        '-------------------------------------------------------------------------------------------------------- Internet Settings ------------

        frmOptions.chckBxChckInternet.Checked = frmKlock.usrSettings.usrCheckInternet

        '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --

        frmOptions.chckBxClipboardMonitor.Checked = frmKlock.usrSettings.usrClipboardMonitor
        frmOptions.chckBxClipboardSavePos.Checked = frmKlock.usrSettings.usrClipboardMonitorSavePosition
        frmOptions.chckBxClipboardSaveCSV.Checked = frmKlock.usrSettings.usrClipboardMonitorSaveCSV

        '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

        frmOptions.txtBxOptionsFriendsFile.Text = If(frmKlock.usrSettings.usrFriendsFile = "", "Friends.bin", frmKlock.usrSettings.usrFriendsFile)

        '-------------------------------------------------------------------------------------------------------- Events Settings ------------

        frmOptions.txtBxOptionsEventsFile.Text = If(frmKlock.usrSettings.usrEventsFile = "", "Events.bin", frmKlock.usrSettings.usrEventsFile)

        frmOptions.nmrcUpDwnFirstReminder.Value = frmKlock.usrSettings.usrEventsFirstReminder
        frmOptions.nmrcUpDwnSecondReminder.Value = frmKlock.usrSettings.usrEventsSecondReminder
        frmOptions.nmrcUpDwnThirdReminder.Value = frmKlock.usrSettings.usrEventsThirdReminder
        frmOptions.nmrcUpDwnEventsInterval.Value = frmKlock.usrSettings.usrEventsTimerInterval                   '   held in minutes

        frmOptions.pctrBxFirstEvent.BackColor = frmKlock.usrSettings.usrFirstEventNotificationbackColour
        frmOptions.pctrBxSecondEvent.BackColor = frmKlock.usrSettings.usrSecondEventNotificationbackColour
        frmOptions.pctrBxThirdEvent.BackColor = frmKlock.usrSettings.usrThirdEventNotificationbackColour

        '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

        frmOptions.txtBxOptionsMemoFile.Text = If(frmKlock.usrSettings.usrMemoFile = "", "Memo.bin", frmKlock.usrSettings.usrMemoFile)

        frmOptions.chckBxMemoDefaultPassword.Checked = frmKlock.usrSettings.usrMemoUseDefaultPassword
        frmOptions.txtBxMemoDefaultPassword.Text = frmKlock.usrSettings.usrMemoDefaultPassword

        frmOptions.nmrcUpDwnMemoDecrypt.Value = frmKlock.usrSettings.usrMemoDecyptTimeOut

        '-------------------------------------------------------------------------------------------------------- Logging Settings ----------

        frmOptions.ChckBxLoging.Checked = frmKlock.usrSettings.usrLogging
        frmOptions.nmrcUpDwnLogDaysKeep.Value = frmKlock.usrSettings.usrLogDaysKeep
        frmOptions.lblLogFilePath.Text = "Log File Location : " & frmKlock.usrSettings.usrLogFilePath
    End Sub
End Module
