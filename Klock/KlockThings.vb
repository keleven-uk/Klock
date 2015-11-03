Imports System.Runtime.InteropServices 'APIs
Imports Microsoft.Win32         'For System Events

Module KlockThings
    '
    '   A module of klock helper functions and procedures.
    '   placed here, to keep in one place and out of the way.
    '


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
        '   Returns the idle time of the system in a formated string.
        '   i.e. time since the last keyboard / mouse input.

        Dim lii As LASTINPUTINFO

        lii.cbSize = Len(lii)
        GetLastInputInfo(lii)

        Dim hms = TimeSpan.FromMilliseconds(GetTickCount() - lii.dwTime)

        idleTime = String.Format("Idle Time :: {0:00}:{1:00}:{2:00}", hms.Hours, hms.Minutes, hms.Seconds)
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
        frmTextKlock.stsLbIdkeTime.ForeColor = Color.Blue
    End Sub

    Public Sub RestoreMonitorSettings()

        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS) 'Restore Previous Settings, ie, Go To Sleep Again
        frmKlock.stsLbIdkeTime.ForeColor = Color.Black
        frmTextKlock.stsLbIdkeTime.ForeColor = Color.Black
    End Sub

    '
    '------------------------------------------------------------------------------------------------- setTitletext ---------------------------------------------
    '
    Public Sub setTitleText()
        'Sets the title of the application according to whch tab is open.

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
        End Select
    End Sub

    '
    ' --------------------------------------------------------------------------------------------mins to string --------------------------------------------
    '
    Function minsToString(ByVal m As Integer) As String
        '   Reformat number of seconds in string in minutes and seconds [mm:ss].

        Dim hours As Integer
        Dim mins As Integer

        hours = m \ 60
        mins = m - (hours * 60)

        Return String.Format("{0:00}:{1:00}", hours, mins)
    End Function

    Function easterDate(Year_of_easter As Integer) As DateTime
        '   Calcultates the date of easter sunday fotr a given year.
        '   see http://aa.usno.navy.mil/faq/docs/easter.php

        Dim y As Integer = Year_of_easter
        Dim d As Integer = (((255 - 11 * (y Mod 19)) - 21) Mod 30) + 21
        Dim easter_date = New DateTime(y, 3, 1)
        easter_date = easter_date.AddDays(+d + (d > 48) + 6 - ((y + y \ 4 + d + (d > 48) + 1) Mod 7))
        Return (easter_date)
    End Function
End Module
