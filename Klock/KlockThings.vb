Imports System.Runtime.InteropServices 'APIs
Imports Microsoft.Win32         'For System Events

Module KlockThings

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

    '   -------------------------------------------------------------- Monito going to sleep ----------------------------------------------------------------------
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
        frmKlock.usrSettings.usrDisableMonitorSleep = True
    End Sub

    Public Sub RestoreMonitorSettings()

        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS) 'Restore Previous Settings, ie, Go To Sleep Again
        frmKlock.stsLbIdkeTime.ForeColor = Color.Black
        frmKlock.usrSettings.usrDisableMonitorSleep = False
    End Sub



End Module
