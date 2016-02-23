'Imports System
'Imports System.Collections.Generic
'Imports System.ComponentModel
'Imports System.Data
'Imports System.Drawing
'Imports System.Text
'Imports System.Windows.Forms
'Imports System.Net
'Imports System.Net.Sockets
'Imports System.Threading

Imports System.Runtime.InteropServices 'APIs
'Imports Microsoft.Win32         'For System Events

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
    ' -------------------------------------------------------------------------------------------- Have Internet --------------------------------------------
    '
    Public Function HaveInternetConnection() As Boolean
        '   Checks to see in connected to the internet by pinging a well know site.
        '   If checkInternet is set to false, in user settings, no check is made.
        '   NB if set to false - effectively shields klock from a valid internet connection.

        If Not frmKlock.usrSettings.usrCheckInternet Then Return False

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function
    '
    ' -------------------------------------------------------------------------------------------- Hot Keys ----------------------------------------------
    '
    Public Sub HotKeys(ByVal e As System.Windows.Forms.KeyEventArgs)
        '   Pressing F1, will open klock's help.
        '   Pressing alt + F2, will open the options screen.
        '   Pressing alt + F5, will open the text klock.
        '   Pressing alt + F7, will disable the monitor from going to sleep.
        '   Pressing alt + F8, will restore system settings for the monitor.
        '   Pressing alt + F12, will shown total number of friends.

        Select Case e.KeyCode
            Case Keys.F1
                Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
                e.Handled = True
            Case Keys.F2 And (e.Alt)
                frmKlock.usrSettings.writeSettings()        '   save settings, not sure if anything has changed.
                frmOptions.ShowDialog()
            Case Keys.F3 And (e.Alt)                        '   show analogue klock
                If klocksNotVisable() Then
                    frmKlock.NtfyIcnKlock.Visible = True
                    frmKlock.Visible = False
                    frmAnalogueKlock.Show()
                End If
                e.Handled = True
            Case Keys.F4 And (e.Alt)                        '   show small text klock
                If klocksNotVisable() Then
                    frmKlock.NtfyIcnKlock.Visible = True
                    frmKlock.Visible = False
                    frmSmallTextKlock.Show()
                End If
                e.Handled = True
            Case Keys.F5 And (e.Alt)                        '   show big text klock
                If klocksNotVisable() Then
                    frmKlock.NtfyIcnKlock.Visible = True
                    frmKlock.Visible = False
                    frmBigTextKlock.Show()
                End If
                e.Handled = True
            Case Keys.F6 And (e.Alt)                        '   
                If frmSmallTextKlock.Visible Then frmSmallTextKlock.Close()
                If frmBigTextKlock.Visible Then frmBigTextKlock.Close()
                If frmAnalogueKlock.visible Then frmAnalogueKlock.close()
            Case Keys.F7 And (e.Alt)                        '   disable monitor sleeping to true
                KlockThings.KeepMonitorActive()
                frmKlock.usrSettings.usrDisableMonitorSleep = True
                e.Handled = True
            Case Keys.F8 And (e.Alt)                        '   disable monitor sleeping to false
                frmKlock.usrSettings.usrDisableMonitorSleep = False
                KlockThings.RestoreMonitorSettings()
                e.Handled = True
            Case Keys.F12 And (e.Alt)                       '   display number of friends.
                '   MessageBox.Show(String.Format("The are {0} friends", Me.LstBxFriends.Items.Count.ToString))
                frmKlock.displayAction.DisplayReminder("Friends", String.Format("The are {0} friends", frmKlock.LstBxFriends.Items.Count.ToString), "G")
                e.Handled = True
        End Select
    End Sub
    '
    ' -------------------------------------------------------------------------------------------- Klock not viable -----------------------------------------
    '
    Private Function klocksNotVisable()
        '   Should return true if none of the extra klocks are running.
        '   Should make the klocks run once.

        Return Not (frmAnalogueKlock.Visible Or frmSmallTextKlock.Visible Or frmBigTextKlock.Visible)
    End Function
    '
    ' -------------------------------------------------------------------------------------------- load sayings ---------------------------------------------
    '
    Public Sub loadSayings()
        '   Loads all the text files in the sayings directory within the app directory

        Dim line As String = ""
        Dim saying As String = ""
        Dim count As Integer = 0

        For Each fileName As String In System.IO.Directory.GetFiles(IO.Path.Combine(Application.StartupPath, "sayings"), "*.txt")
            Try
                Using wordreader As New System.IO.StreamReader(fileName)

                    While wordreader.Peek <> -1
                        line = wordreader.ReadLine.Trim()

                        If line = "" Then
                            frmKlock.sayings.Add(saying)
                            saying = ""
                        Else
                            saying += line & System.Environment.NewLine
                        End If
                    End While

                    wordreader.Close()
                End Using
            Catch ex As Exception
                frmKlock.displayAction.DisplayReminder("ERROR :: KlockThings.loadWords", ex.Message, "G")
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
    ' -------------------------------------------------------------------------------------------- items forecolour ----------------------------------------
    '
    Public Function itemForecolor(type As String) As Color
        '   Returns a colour for use in the clipboard history fore colour.
        '   used in frmClipboardMonitor.addToList()

        Select Case type                                        '   set up text colour depending on object type
            Case "Text"
                Return Color.Red
            Case "UNI"
                Return Color.DeepPink
            Case "RTF"
                Return Color.BurlyWood
            Case "HTML"
                Return Color.DarkSlateBlue
            Case "CSVL"
                Return Color.Firebrick
            Case "File"
                Return Color.Blue
            Case "Dir"
                Return Color.LightBlue
            Case "Audio"
                Return Color.DarkGoldenrod
            Case "Image"
                Return Color.Green
            Case "Error"
                Return Color.DarkOrange
            Case Else
                '   probably error, ignore
        End Select
    End Function
    '
    ' -------------------------------------------------------------------------------------------- status info ---------------------------------------------
    '
    Public Function statusInfo() As String
        '   generates the status bar info string according to state of keys.

        Dim strKey As String = "cns off"

        If My.Computer.Keyboard.CapsLock.ToString() Then strKey = Replace(strKey, "c", "C")
        If My.Computer.Keyboard.NumLock.ToString() Then strKey = Replace(strKey, "n", "N")
        If My.Computer.Keyboard.ScrollLock.ToString() Then strKey = Replace(strKey, "s", "S")
        If KlockThings.HaveInternetConnection() Then strKey = Replace(strKey, "off", "ON")

        Return strKey
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
End Module


