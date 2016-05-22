Imports System.Text
Imports System.Runtime.InteropServices 'APIs

Module KlockThings
    '
    '   A module of klock helper functions and procedures.
    '   placed here, to keep in one place and out of the way.
    '
    Dim rnd As New Random()

    '   -------------------------------------------------------- Idle Time ----------------------------------------------------------------------------
    '   used for idle time [includes structure]
    '   see https://social.msdn.microsoft.com/Forums/vstudio/en-US/031ea7a0-dafe-4738-a0ff-849ad514acea/stop-application-when-no-activity

    Private Declare Function GetTickCount Lib "kernel32" () As Int32
    Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean

    Private Structure LASTINPUTINFO
        Dim cbSize As Int32
        Dim dwTime As Int32
    End Structure

    Public Function idleTime() As String
        '   Returns the idle time of the system in a formatted string.
        '   i.e. time since the last keyboard / mouse input.

        Dim lii As LASTINPUTINFO

        lii.cbSize = Len(lii)
        GetLastInputInfo(lii)

        Dim hms = TimeSpan.FromMilliseconds(GetTickCount() - lii.dwTime)

        idleTime = String.Format("{0:00}:{1:00}:{2:00}", hms.Hours, hms.Minutes, hms.Seconds)
    End Function

    '   -------------------------------------------------------------- Monitor going to sleep ----------------------------------------------------------------------
    '   Preventing Your Monitor from Going to Sleep
    '   http://www.codeguru.com/columns/vb/preventing-your-monitor-from-going-to-sleep-with-visual-studio-2012.htm

    <FlagsAttribute()>
    Public Enum EXECUTION_STATE As UInteger ' Determine Monitor State
        ES_AWAYMODE_REQUIRED = &H40
        ES_CONTINUOUS = &H80000000UI
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
        ' Legacy flag, should not be used.
        ' ES_USER_PRESENT = 0x00000004
    End Enum

    'Enables an application to inform the system that it is in use, thereby preventing the system from entering sleep or turning off the display while the application is running.
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function SetThreadExecutionState(ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
    End Function

    'This function queries or sets system-wide parameters, and updates the user profile during the process.
    <DllImport("user32", EntryPoint:="SystemParametersInfo", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Function SystemParametersInfo(ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    End Function

    Private Const SPI_SETSCREENSAVETIMEOUT As Int32 = 15

    Public Sub KeepMonitorActive()

        SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED + EXECUTION_STATE.ES_CONTINUOUS) 'Do not Go To Sleep
        frmKlock.stsLbIdkeTime.ForeColor = Color.Blue
        frmSmallTextKlock.stsLbIdkeTime.ForeColor = Color.Blue
        frmBigTextKlock.stsLbIdkeTime.ForeColor = Color.Blue
        frmClipboardMonitor.stsLbIdkeTime.ForeColor = Color.Blue
        frmAnalogueKlock.ForeColor = Color.Blue
    End Sub

    Public Sub RestoreMonitorSettings()

        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS) 'Restore Previous Settings, i.e., Go To Sleep Again
        frmKlock.stsLbIdkeTime.ForeColor = Color.Black
        frmSmallTextKlock.stsLbIdkeTime.ForeColor = Color.Black
        frmBigTextKlock.stsLbIdkeTime.ForeColor = Color.LightGreen
        frmClipboardMonitor.stsLbIdkeTime.ForeColor = Color.Black
        frmAnalogueKlock.ForeColor = Color.Black
    End Sub

    '
    '------------------------------------------------------------------------------------------------- setTitletext ---------------------------------------------
    '
    Public Sub setTitleText()
        'Sets the title of the application according to which tab is open.

        Select Case frmKlock.TbCntrl.SelectedIndex
            Case 0                                              '   time tab
                frmKlock.Text = "Klock - Tells you the time :: " & frmKlock.displayOneTime.getTitle()
            Case 1                                              '   world klock tab
                frmKlock.Text = "Klock - Tells you the time around the World"
            Case 2                                              '   countdown tab
                frmKlock.Text = "Klock - Countdowns the time"
            Case 3                                              '   timer tab
                frmKlock.Text = "Klock - Measures the time"
            Case 4                                              '   reminder tab
                frmKlock.Text = "Klock - Reminds you of the time"
            Case 5                                              '   friends tab
                frmKlock.Text = "Klock - Reminds you of your friends"
            Case 6                                              '   events tab
                frmKlock.Text = "Klock - Reminds you of important events."
            Case 7                                              '   Memo tab
                frmKlock.Text = "Klock - Reminds you of Memoranda."
            Case 8                                              '   Conversions tab
                frmKlock.Text = "Klock - Helps with conversions :: " & frmKlock.CmbBxConvertTo.Text
            Case 9                                              '   Sayings tab
                frmKlock.Text = "Klock - Useful Sayings."
        End Select

        frmKlock.Text = frmKlock.Text & setExtaraTitletext()
    End Sub

    Public Function setExtaraTitletext(Optional ByVal CR As Boolean = False) As String
        '   Check to see if timer, countdown or reminder is running - if any are then add to title test.
        '   CR is an optional parameter - if True then add newlines.  Form title does not use newlines, but notifications does.

        Dim ExtaraTitletext As String = String.Empty

        If frmKlock.usrSettings.usrTimerAdd And frmKlock.tmrTimer.Enabled Then                  '   time is running
            ExtaraTitletext = ExtaraTitletext & " .:Timer:. " & If(frmKlock.usrSettings.usrTimerHigh, frmKlock.displayTimer.getHighElapsedTime(),
                                                                                                      frmKlock.displayTimer.getLowElapsedTime())
            If CR Then ExtaraTitletext += Environment.NewLine
        End If

        If frmKlock.usrSettings.usrCountdownAdd And frmKlock.tmrCountDown.Enabled Then          '   countdown is running.
            ExtaraTitletext = ExtaraTitletext & " .:Countdown:. " & minsToString(frmKlock.CountDownTime)
            If CR Then ExtaraTitletext += Environment.NewLine
        End If

        If frmKlock.usrSettings.usrReminderAdd And frmKlock.tmrReminder.Enabled Then            '   reminder is running
            ExtaraTitletext = ExtaraTitletext & " .:Reminder:. Reminder set for " & If(frmKlock.usrSettings.usrReminderTimeChecked,
                                                                                       frmKlock.ReminderDateTime.ToLongDateString & " @ " & frmKlock.ReminderDateTime.ToLongTimeString,
                                                                                       frmKlock.ReminderDateTime.ToLongDateString)
            If CR Then ExtaraTitletext += Environment.NewLine
        End If

        Return ExtaraTitletext
    End Function

    Public Sub setToolTip()
        '   Set the tool tip for any extra klocks, if running.

        Dim txt As String = setExtaraTitletext(True)

        If Len(txt) <> 0 Then '   are any extras running?  if so, set tool tip - but only if something to set.
            If frmAnalogueKlock.Visible Then frmAnalogueKlock.toTpAnalogKlock.SetToolTip(frmAnalogueKlock.analogueKlock, txt)
            If frmBigTextKlock.Visible Then frmBigTextKlock.toTpBigTextKlock.SetToolTip(frmBigTextKlock.pnlBigKlock, txt)
            If frmSmallTextKlock.Visible Then frmSmallTextKlock.toTpSmallTextKlock.SetToolTip(frmSmallTextKlock.pnlSmallKlock, txt)
            If frmBinaryKlock.Visible Then frmBinaryKlock.toTpBinaryKlock.SetToolTip(frmBinaryKlock.PctrBxBinaryKlock, txt)
        End If
    End Sub
    '
    ' -------------------------------------------------------------------------------------------- mins to string --------------------------------------------
    '
    Function minsToString(ByVal m As Integer) As String
        '   Reformat number of seconds in string in minutes and seconds [mm:ss].

        Dim hours As Integer
        Dim mins As Integer

        hours = m \ 60
        mins = m - (hours * 60)

        Return String.Format("{0:00}:{1:00}", hours, mins)
    End Function
    '
    ' -------------------------------------------------------------------------------------------- Easter dates ---------------------------------------------
    '
    Function easterDate(Year_of_easter As Integer) As DateTime
        '   Calculates the date of Easter Sunday for a given year.
        '   see http://aa.usno.navy.mil/faq/docs/easter.php

        Dim y As Integer = Year_of_easter
        Dim d As Integer = (((255 - 11 * (y Mod 19)) - 21) Mod 30) + 21
        Dim easter_date = New DateTime(y, 3, 1)
        easter_date = easter_date.AddDays(+d + (d > 48) + 6 - ((y + y \ 4 + d + (d > 48) + 1) Mod 7))
        Return (easter_date)
    End Function
    '
    ' -------------------------------------------------------------------------------------------- Hot Keys ----------------------------------------------
    '
    Public Sub HotKeys(ByVal e As System.Windows.Forms.KeyEventArgs, frm As Form)
        '   Pressing F1, will open klock's help.
        '   Pressing F2, will open a new sticky note.
        '   Pressing alt + F2, will open the options screen.
        '   Pressing alt + F3, will open the analogue klock.
        '   Pressing alt + F4, will open the small text klock.
        '   Pressing alt + F5, will open the big text klock.
        '   Pressing alt + F6, will open the binary klock.
        '   Pressing alt + F7, will close all child klock and return to main klock.
        '   Pressing alt + F8, will disable the monitor from going to sleep.
        '   Pressing alt + F9, will restore system settings for the monitor.
        '   Pressing alt + F10, will open the clipboard manager.
        '   Pressing alt + F12, will shown total number of friends.

        Select Case e.KeyCode
            Case Keys.F1
                Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
                e.Handled = True
            Case Keys.F2
                newStickyNote()
                e.Handled = True
            Case Keys.F2 And (e.Alt)
                frmKlock.usrSettings.writeSettings()        '   save settings, not sure if anything has changed.
                frmOptions.ShowDialog()
            Case Keys.F3 And (e.Alt)                        '   show analogue klock
                killChildKlocks(frm)
                frmKlock.Visible = False
                frmAnalogueKlock.Show()
                e.Handled = True
            Case Keys.F4 And (e.Alt)                        '   show small text klock
                killChildKlocks(frm)
                frmKlock.Visible = False
                frmSmallTextKlock.Show()
                e.Handled = True
            Case Keys.F5 And (e.Alt)                        '   show big text klock
                killChildKlocks(frm)
                frmKlock.Visible = False
                frmBigTextKlock.Show()
                e.Handled = True
            Case Keys.F6 And (e.Alt)                        '   show binary klock   
                killChildKlocks(frm)
                frmKlock.Visible = False
                frmBinaryKlock.Show()
                e.Handled = True
            Case Keys.F7 And (e.Alt)                        '   kill all child klocks  
                killChildKlocks(frm)
                e.Handled = True
            Case Keys.F8 And (e.Alt)                        '   disable monitor sleeping to true
                KlockThings.KeepMonitorActive()
                frmKlock.usrSettings.usrDisableMonitorSleep = True
                e.Handled = True
            Case Keys.F9 And (e.Alt)                        '   disable monitor sleeping to false
                frmKlock.usrSettings.usrDisableMonitorSleep = False
                KlockThings.RestoreMonitorSettings()
                e.Handled = True
            Case Keys.F10 And (e.Alt)                        '   show the clipboard manager.
                frmClipboardMonitor.Show()
            Case Keys.F12 And (e.Alt)                       '   display number of friends.
                '   MessageBox.Show(String.Format("The are {0} friends", Me.LstBxFriends.Items.Count.ToString))
                frmKlock.displayAction.DisplayReminder(String.Format("The are {0} friends", frmKlock.LstBxFriends.Items.Count.ToString), "G", "Friends")
                e.Handled = True
        End Select
    End Sub
    '
    ' -------------------------------------------------------------------------------------------- Klock not viable -----------------------------------------
    '
    Public Function klocksNotVisable()
        '   Should return true if none of the extra klocks are running.
        '   Should make the klocks run once.

        Return Not (frmAnalogueKlock.Visible Or frmSmallTextKlock.Visible Or frmBigTextKlock.Visible Or frmBinaryKlock.Visible)
    End Function
    '
    '-------------------------------------------------------------------------------------------- Kill all child klocks --------------------------------------
    '
    Private Sub killChildKlocks(frm As Form)
        '   If the frm is the main klock form then send to system tray, else clost the form.

        If frm.Name = "frmKlock" Then
            frmKlock.NtfyIcnKlock.Visible = True
            frmKlock.Visible = False
        Else
            frm.Close()
        End If
    End Sub
    '
    ' -------------------------------------------------------------------------------------------- load sayings ---------------------------------------------
    '
    Public Sub loadSayings()
        '   Loads all the text files in the sayings directory within the app directory

        Dim line As String = String.Empty
        Dim saying As New StringBuilder

        For Each fileName As String In System.IO.Directory.GetFiles(IO.Path.Combine(Application.StartupPath, "sayings"), "*.txt")
            Try
                Using wordreader As New System.IO.StreamReader(fileName)

                    While wordreader.Peek <> -1
                        line = wordreader.ReadLine.Trim()

                        If line = String.Empty Then
                            frmKlock.sayings.Add(saying.ToString)
                            saying.Clear()
                        Else
                            saying.AppendLine(line)
                        End If
                    End While

                    wordreader.Close()
                End Using
            Catch ex As Exception
                If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("KlockThings.loadSayings", ex)
                frmKlock.displayAction.DisplayReminder(ex.Message, "G", "ERROR :: KlockThings.loadWords")
            End Try
        Next

    End Sub
    '
    ' -------------------------------------------------------------------------------------------- random saying --------------------------------------------
    '
    Public Function randomSayings()
        '   return a random saying from all loaded sayings.

        Dim pos As Integer = rnd.Next(frmKlock.sayings.Count)

        Return frmKlock.sayings(pos)
    End Function
    '
    ' -------------------------------------------------------------------------------------------- load saying ---------------------------------------------
    '
    Public Sub LoadSaying()
        '   reload all saying text file.

        frmKlock.txtBxSayings.Text = randomSayings()
    End Sub

    '
    ' -------------------------------------------------------------------------------------------- status info ---------------------------------------------
    '
    Public Function statusInfo() As String
        '   generates the status bar info string according to state of keys.

        Dim strKey As New StringBuilder("cns off")

        If My.Computer.Keyboard.CapsLock Then strKey.Replace("c", "C")
        If My.Computer.Keyboard.NumLock Then strKey.Replace("n", "N")
        If My.Computer.Keyboard.ScrollLock Then strKey.Replace("s", "S")
        If HaveInternetConnection() Then strKey.Replace("off", "ON")

        Return strKey.ToString()
    End Function
    '
    ' -------------------------------------------------------------------------------------------- Have Internet --------------------------------------------
    '
    Public Function HaveInternetConnection() As Boolean
        '   Checks to see in connected to the internet by pinging a well know site.
        '   If checkInternet is set to false, in user settings, no check is made.
        '   NB if set to false - effectively shields klock from a valid internet connection.

        If Not frmKlock.usrSettings.usrCheckInternet Then Return False

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch ex As Exception
            If frmKlock.usrSettings.usrLogging Then frmKlock.errLogger.LogExceptionError("KlockThings.HaveInternetConnection", ex)
            Return False
        End Try

    End Function
    '
    ' -------------------------------------------------------------------------------------------- status date ---------------------------------------------
    '
    Public Function statusTime() As String
        '   Return system time in either 12/24 hour format.

        Return If(frmKlock.usrSettings.usrTimeSystem24Hour,
                String.Format("{0:HH:mm:ss}", System.DateTime.Now),
                String.Format("{0:hh:mm:ss tt}", System.DateTime.Now))
    End Function
    '
    ' -------------------------------------------------------------------------------------------- status date ---------------------------------------------
    '
    Public Sub newStickyNote()
        '   Create a new sticky note.

        Dim note As New frmStickyNote()

        note.Show()
    End Sub
End Module


