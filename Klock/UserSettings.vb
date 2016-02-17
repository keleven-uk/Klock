Imports System
Imports System.IO
Imports System.Xml
Imports System.Environment
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

'When you're writing .NET code, it's recommended that you use the functions explicitly designed for this purpose, 
'rather than relying on environment variables such as %appdata%.

'You're looking for the Environment.GetFolderPath method, which returns the path to the special folder that you specify from the 
'Environment.SpecialFolder enumeration.

'The Application Data folder is represented by the Environment.SpecialFolder.ApplicationData value. This is, as you requested, 
'the roaming application data folder. If you do not need the data you save to roam across multiple machines and would prefer that it 
'stays local to only one, you should use the Environment.SpecialFolder.LocalApplicationData value.



Public Class UserSettings

    '   local versions of the user settings.
    '   NB : important to set default on all user settings will be used if not present in xml file.
    '-------------------------------------------------------------------------------------------------------- Global Settings -------------
    Private _usrDefaultTab As Integer = 0
    Private _usrFormColour As Color = Color.LightGray
    Private _usrFormFont As Font = frmOptions.DefaultFont
    Private _usrFormFontColour As Color = Color.Black
    Private _usrFormTop As Integer = 100
    Private _usrFormLeft As Integer = 100
    Private _usrSavePosition As Boolean = True
    Private _usrStartMinimised As Boolean = False
    Private _usrRunOnStartup As Boolean = False
    Private _usrSoundVolume As Integer = 10
    Private _usrOptionsSavePath As String = System.IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "klock")
    Private _usrOptionsSaveFile As String = "klock.xml"
    '-------------------------------------------------------------------------------------------------------- Time Settings ---------------
    Private _usrTimeDefaultFormat As Integer = 0
    Private _usrTimeTwoDefaultFormat As Integer = 1
    Private _usrTimeTwoFormats As Boolean = False
    Private _usrTimeIdleTime As Boolean = False
    Private _usrTimeSystem24Hour As Boolean = True
    Private _usrTimeOne24Hour As Boolean = True
    Private _usrTimeTwo24Hour As Boolean = True
    Private _usrTimeSwatchCentibeats As Boolean = False
    Private _usrTimeNETSeconds As Boolean = False
    Private _usrTimeHexIntuitorFormat As Boolean = False
    Private _usrTimeHourPips As Boolean = True
    Private _usrTimeHourChimes As Boolean = False
    Private _usrTimeHalfChimes As Boolean = False
    Private _usrTimeQuarterChimes As Boolean = False
    Private _usrTimeThreeQuartersChimes As Boolean = False
    Private _usrTimeDisplayMinimised As Boolean = False         '   Notification to tell time if klock in system tray
    Private _usrTimeDisplayMinutes As Integer = 15
    Private _usrTimeVoiceMinimised As Boolean = False           '   Voice to tell time if klock in system tray
    Private _usrTimeVoiceMinutes As Integer = 15
    '-------------------------------------------------------------------------------------------------------- Big Klock Settings ----------
    Private _usrBigKlockTop As Integer = 100
    Private _usrBigKlockLeft As Integer = 100
    Private _usrBigKlockSavePosition As Boolean = True
    Private _usrBigKlockBackColour As Color = Color.Black
    Private _usrBigKlockForeColour As Color = Color.LightGreen
    Private _usrBigKlockOffColour As Color = Color.LightSlateGray
    '-------------------------------------------------------------------------------------------------------- Small Klock Settings --------
    Private _usrSmallKlockTop As Integer = 100
    Private _usrSmallKlockLeft As Integer = 100
    Private _usrSmallKlockSavePosition As Boolean = True
    Private _usrSmallKlockBackColour As Color = Color.Black
    Private _usrSmallKlockForeColour As Color = Color.LightGreen
    Private _usrSmallKlockOffColour As Color = Color.LightSlateGray
    '------------------------------------------------------------------------------------------------------- analogue Klock Settings -----
    Private _usrAnalogueKlockTop As Integer = 100
    Private _usrAnalogueKlockLeft As Integer = 100
    Private _usrAnalogueKlockSavePosition As Boolean = True
    Private _usrAnalogueKlockText As String = "Klock"
    Private _usrAnalogueKlcokTransparent As Boolean = False
    Private _usrAnalogueKlockShowDate As Boolean = True
    Private _usrAnalogueKlockShowTime As Boolean = True
    Private _usrAnalogueKlockBackColour As Color = Color.LightSlateGray
    Private _usrAnalogueKlockDisplayPicture As Boolean = False
    Private _usrAnalogueKlockPicture As String = ""
    '-------------------------------------------------------------------------------------------------------- Timer Settings --------------
    Private _usrTimerHigh As Boolean = False
    Private _usrTimerClearSplit As Boolean = False
    Private _usrTimerAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------
    Private _usrCountdownAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------
    Private _usrReminderTimeChecked As Boolean = False
    Private _usrReminderAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- World Klock Settings --------
    Private _usrWorldKlockAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Notification Settings -------
    Private _usrNotificationbackColour As Color = Color.LightGray
    Private _usrNotificationFont As Font = frmOptions.DefaultFont
    Private _usrNotificationFontColour As Color = Color.Black
    Private _usrNotificationTimeOut As Integer = 5000
    Private _usrNotificationOpacity As Integer = 80
    '-------------------------------------------------------------------------------------------------------- Sayings Settings ------------
    Private _usrSayingsDisplay As Boolean = True
    Private _usrSayingsbackColour As Color = Color.LightGray
    Private _usrSayingsFont As Font = frmOptions.DefaultFont
    Private _usrSayingsFontColour As Color = Color.Black
    Private _usrSayingsDisplayTime As Integer = 20                  '   held in minutes
    Private _usrSayingsTimeOut As Integer = 5000
    Private _usrSayingsOpacity As Integer = 80
    '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------
    Private _usrDisableMonitorSleep As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Internet Settings -----------
    Private _usrCheckInternet As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --
    Private _usrClipboardMonitor As Boolean = False
    Private _usrClipboardMonitorSavePosition As Boolean = True
    Private _usrClipboardMonitorTop As Integer = 100
    Private _usrClipboardMonitorLeft As Integer = 100
    Private _usrClipboardSavePath As String = System.IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "Klock\Clipsave")
    '-------------------------------------------------------------------------------------------------------- Friends Settings ------------
    Private _usrFriendsFile As String = "Friends.bin"
    '-------------------------------------------------------------------------------------------------------- Events Settings ------------
    Private _usrEventsFile As String = "Events.bin"

    Private _usrEventNotificationFont As Font = frmOptions.DefaultFont
    Private _usrEventNotificationFontColour As Color = Color.Black
    Private _usrFirstEventNotificationbackColour As Color = Color.FromArgb(242, 255, 198, 255)
    Private _usrSecondEventNotificationbackColour As Color = Color.FromArgb(255, 255, 183, 255)
    Private _usrThirdEventNotificationbackColour As Color = Color.FromArgb(255, 168, 168, 255)

    Private _usrEventsFirstReminder As Integer = 31
    Private _usrEventsSecondReminder As Integer = 7
    Private _usrEventsThirdReminder As Integer = 1

    Private _usrEventNotificationOpacity As Integer = 80
    Private _usrEventsTimerInterval As Integer = 60                  '   held in minutes
    '-------------------------------------------------------------------------------------------------------- Memo Settings -------------
    Private _usrMemoFile As String = "Memo.bin"

    Private _usrMemoUseDefaultPassword As Boolean = False
    Private _usrMemoDefaultPassword As String = "klock"
    Private _usrMemoDecyptTimeOut As Integer = 30

    '   run on set up - blank at the moment.
    Public Sub New()

        MyBase.New()

        checkDataFile()             '   checks for settings file, if not present - will create.
        checkVersion()              '   checks version of settings file, if different from app - then write default settings file.
    End Sub


    '   Getters and setters for each of the user settings.
    '-------------------------------------------------------------------------------------------------------- Global Settings -------------
    Public Property usrDefaultTab() As Integer
        Get
            Return _usrDefaultTab
        End Get
        Set(ByVal value As Integer)
            _usrDefaultTab = value
        End Set
    End Property

    Public Property usrFormColour() As Color
        Get
            Return _usrFormColour
        End Get
        Set(ByVal value As Color)
            _usrFormColour = value
        End Set
    End Property

    Public Property usrFormFont() As Font
        Get
            Return _usrFormFont
        End Get
        Set(ByVal value As Font)
            _usrFormFont = value
        End Set
    End Property

    Public Property usrFormFontColour() As Color
        Get
            Return _usrFormFontColour
        End Get
        Set(ByVal value As Color)
            _usrFormFontColour = value
        End Set
    End Property

    Public Property usrFormTop() As Integer
        Get
            Return _usrFormTop
        End Get
        Set(ByVal value As Integer)
            _usrFormTop = value
        End Set
    End Property

    Public Property usrFormLeft() As Integer
        Get
            Return _usrFormLeft
        End Get
        Set(ByVal value As Integer)
            _usrFormLeft = value
        End Set
    End Property

    Public Property usrSavePosition() As Boolean
        Get
            Return _usrSavePosition
        End Get
        Set(ByVal value As Boolean)
            _usrSavePosition = value
        End Set
    End Property

    Public Property usrStartMinimised() As Boolean
        Get
            Return _usrStartMinimised
        End Get
        Set(ByVal value As Boolean)
            _usrStartMinimised = value
        End Set
    End Property

    Public Property usrRunOnStartup() As Boolean
        Get
            Return _usrRunOnStartup
        End Get
        Set(ByVal value As Boolean)
            _usrRunOnStartup = value
        End Set
    End Property

    Public Property usrSoundVolume() As Integer
        Get
            Return _usrSoundVolume
        End Get
        Set(ByVal value As Integer)
            _usrSoundVolume = value
        End Set
    End Property

    Public ReadOnly Property usrOptionsSavePath() As String     '   returns path to save settings file - read-only
        Get
            Return _usrOptionsSavePath
        End Get
    End Property

    Public ReadOnly Property usrOptionsSaveFile() As String     '   returns path to save settings file - read-only
        Get
            Return _usrOptionsSaveFile
        End Get
    End Property

    '-------------------------------------------------------------------------------------------------------- Time Settings ---------------
    Public Property usrTimeDefaultFormat() As Integer
        Get
            Return _usrTimeDefaultFormat
        End Get
        Set(ByVal value As Integer)
            _usrTimeDefaultFormat = value
        End Set
    End Property

    Public Property usrTimeTWODefaultFormat() As Integer
        Get
            Return _usrTimeTwoDefaultFormat
        End Get
        Set(ByVal value As Integer)
            _usrTimeTwoDefaultFormat = value
        End Set
    End Property

    Public Property usrTimeTwoFormats() As Boolean
        Get
            Return _usrTimeTwoFormats
        End Get
        Set(ByVal value As Boolean)
            _usrTimeTwoFormats = value
        End Set
    End Property

    Public Property usrTimeIdleTime() As Boolean
        Get
            Return _usrTimeIdleTime
        End Get
        Set(ByVal value As Boolean)
            _usrTimeIdleTime = value
        End Set
    End Property

    Public Property usrTimeSystem24Hour() As Boolean
        Get
            Return _usrTimeSystem24Hour
        End Get
        Set(ByVal value As Boolean)
            _usrTimeSystem24Hour = value
        End Set
    End Property

    Public Property usrTimeOne24Hour() As Boolean
        Get
            Return _usrTimeOne24Hour
        End Get
        Set(ByVal value As Boolean)
            _usrTimeOne24Hour = value
        End Set
    End Property

    Public Property usrTimeTwo24Hour() As Boolean
        Get
            Return _usrTimeTwo24Hour
        End Get
        Set(ByVal value As Boolean)
            _usrTimeTwo24Hour = value
        End Set
    End Property

    Public Property usrTimeSwatchCentibeats() As Boolean
        Get
            Return _usrTimeSwatchCentibeats
        End Get
        Set(ByVal value As Boolean)
            _usrTimeSwatchCentibeats = value
        End Set
    End Property

    Public Property usrTimeNETSeconds() As Boolean
        Get
            Return _usrTimeNETSeconds
        End Get
        Set(ByVal value As Boolean)
            _usrTimeNETSeconds = value
        End Set
    End Property

    Public Property usrTimeHexIntuitorFormat() As Boolean
        Get
            Return _usrTimeHexIntuitorFormat
        End Get
        Set(ByVal value As Boolean)
            _usrTimeHexIntuitorFormat = value
        End Set
    End Property

    Public Property usrTimeHourPips() As Boolean
        Get
            Return _usrTimeHourPips
        End Get
        Set(ByVal value As Boolean)
            _usrTimeHourPips = value
        End Set
    End Property

    Public Property usrTimeHourChimes() As Boolean
        Get
            Return _usrTimeHourChimes
        End Get
        Set(ByVal value As Boolean)
            _usrTimeHourChimes = value
        End Set
    End Property

    Public Property usrTimeHalfChimes() As Boolean
        Get
            Return _usrTimeHalfChimes
        End Get
        Set(ByVal value As Boolean)
            _usrTimeHalfChimes = value
        End Set
    End Property

    Public Property usrTimeQuarterChimes() As Boolean
        Get
            Return _usrTimeQuarterChimes
        End Get
        Set(ByVal value As Boolean)
            _usrTimeQuarterChimes = value
        End Set
    End Property

    Public Property usrTimeThreeQuartersChimes() As Boolean
        Get
            Return _usrTimeThreeQuartersChimes
        End Get
        Set(ByVal value As Boolean)
            _usrTimeThreeQuartersChimes = value
        End Set
    End Property

    Public Property usrTimeDisplayMinimised() As Boolean
        Get
            Return _usrTimeDisplayMinimised
        End Get
        Set(ByVal value As Boolean)
            _usrTimeDisplayMinimised = value
        End Set
    End Property

    Public Property usrTimeDisplayMinutes() As Integer
        Get
            Return _usrTimeDisplayMinutes
        End Get
        Set(ByVal value As Integer)
            _usrTimeDisplayMinutes = value
        End Set
    End Property

    Public Property usrTimeVoiceMinimised() As Boolean
        Get
            Return _usrTimeVoiceMinimised
        End Get
        Set(ByVal value As Boolean)
            _usrTimeVoiceMinimised = value
        End Set
    End Property

    Public Property usrTimeVoiceMinutes() As Integer
        Get
            Return _usrTimeVoiceMinutes
        End Get
        Set(ByVal value As Integer)
            _usrTimeVoiceMinutes = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Big Klock Settings --------------

    Public Property usrBigKlockTop() As Integer
        Get
            Return _usrBigKlockTop
        End Get
        Set(ByVal value As Integer)
            _usrBigKlockTop = value
        End Set
    End Property

    Public Property usrBigKlockLeft() As Integer
        Get
            Return _usrBigKlockLeft
        End Get
        Set(ByVal value As Integer)
            _usrBigKlockLeft = value
        End Set
    End Property

    Public Property usrBigKlockSavePosition() As Boolean
        Get
            Return _usrBigKlockSavePosition
        End Get
        Set(ByVal value As Boolean)
            _usrBigKlockSavePosition = value
        End Set
    End Property

    Public Property usrBigKlockBackColour() As Color
        Get
            Return _usrBigKlockBackColour
        End Get
        Set(ByVal value As Color)
            _usrBigKlockBackColour = value
        End Set
    End Property

    Public Property usrBigKlockForeColour() As Color
        Get
            Return _usrBigKlockForeColour
        End Get
        Set(ByVal value As Color)
            _usrBigKlockForeColour = value
        End Set
    End Property

    Public Property usrBigKlockOffColour() As Color
        Get
            Return _usrBigKlockOffColour
        End Get
        Set(ByVal value As Color)
            _usrBigKlockOffColour = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Small Klock Settings ------------

    Public Property usrSmallKlockTop() As Integer
        Get
            Return _usrSmallKlockTop
        End Get
        Set(ByVal value As Integer)
            _usrSmallKlockTop = value
        End Set
    End Property

    Public Property usrSmallKlockLeft() As Integer
        Get
            Return _usrSmallKlockLeft
        End Get
        Set(ByVal value As Integer)
            _usrSmallKlockLeft = value
        End Set
    End Property

    Public Property usrSmallKlockSavePosition() As Boolean
        Get
            Return _usrSmallKlockSavePosition
        End Get
        Set(ByVal value As Boolean)
            _usrSmallKlockSavePosition = value
        End Set
    End Property

    Public Property usrSmallKlockBackColour() As Color
        Get
            Return _usrSmallKlockBackColour
        End Get
        Set(ByVal value As Color)
            _usrSmallKlockBackColour = value
        End Set
    End Property

    Public Property usrSmallKlockForeColour() As Color
        Get
            Return _usrSmallKlockForeColour
        End Get
        Set(ByVal value As Color)
            _usrSmallKlockForeColour = value
        End Set
    End Property

    Public Property usrSmallKlockOffColour() As Color
        Get
            Return _usrSmallKlockOffColour
        End Get
        Set(ByVal value As Color)
            _usrSmallKlockOffColour = value
        End Set
    End Property

    '------------------------------------------------------------------------------------------------------- analogue Klock Settings -----

    Public Property usrAnalogueKlockTop() As Integer
        Get
            Return _usrAnalogueKlockTop
        End Get
        Set(ByVal value As Integer)
            _usrAnalogueKlockTop = value
        End Set
    End Property

    Public Property usrAnalogueKlockLeft() As Integer
        Get
            Return _usrAnalogueKlockLeft
        End Get
        Set(ByVal value As Integer)
            _usrAnalogueKlockLeft = value
        End Set
    End Property

    Public Property usrAnalogueKlockSavePosition() As Boolean
        Get
            Return _usrAnalogueKlockSavePosition
        End Get
        Set(ByVal value As Boolean)
            _usrAnalogueKlockSavePosition = value
        End Set
    End Property

    Public Property usrAnalogueKlockText() As String
        Get
            Return _usrAnalogueKlockText
        End Get
        Set(ByVal value As String)
            _usrAnalogueKlockText = value
        End Set
    End Property

    Public Property usrAnalogueKlcokTransparent() As Boolean
        Get
            Return _usrAnalogueKlcokTransparent
        End Get
        Set(ByVal value As Boolean)
            _usrAnalogueKlcokTransparent = value
        End Set
    End Property

    Public Property usrAnalogueKlockShowDate() As Boolean
        Get
            Return _usrAnalogueKlockShowDate
        End Get
        Set(ByVal value As Boolean)
            _usrAnalogueKlockShowDate = value
        End Set
    End Property

    Public Property usrAnalogueKlockShowTime() As Boolean
        Get
            Return _usrAnalogueKlockShowTime
        End Get
        Set(ByVal value As Boolean)
            _usrAnalogueKlockShowTime = value
        End Set
    End Property

    Public Property usrAnalogueKlockDisplayPicture() As Boolean
        Get
            Return _usrAnalogueKlockDisplayPicture
        End Get
        Set(ByVal value As Boolean)
            _usrAnalogueKlockDisplayPicture = value
        End Set
    End Property

    Public Property usrAnalogueKlockPicture() As String
        Get
            Return _usrAnalogueKlockPicture
        End Get
        Set(ByVal value As String)
            _usrAnalogueKlockPicture = value
        End Set
    End Property

    Public Property usrAnalogueKlockBackColour() As Color
        Get
            Return _usrAnalogueKlockBackColour
        End Get
        Set(ByVal value As Color)
            _usrAnalogueKlockBackColour = value
        End Set
    End Property
    '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

    Public Property usrTimerHigh() As Boolean
        Get
            Return _usrTimerHigh
        End Get
        Set(ByVal value As Boolean)
            _usrTimerHigh = value
        End Set
    End Property

    Public Property usrTimerClearSplit() As Boolean
        Get
            Return _usrTimerClearSplit
        End Get
        Set(ByVal value As Boolean)
            _usrTimerClearSplit = value
        End Set
    End Property

    Public Property usrTimerAdd() As Boolean
        Get
            Return _usrTimerAdd
        End Get
        Set(ByVal value As Boolean)
            _usrTimerAdd = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

    Public Property usrCountdownAdd() As Boolean
        Get
            Return _usrCountdownAdd
        End Get
        Set(ByVal value As Boolean)
            _usrCountdownAdd = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------

    Public Property usrReminderTimeChecked() As Boolean
        Get
            Return _usrReminderTimeChecked
        End Get
        Set(ByVal value As Boolean)
            _usrReminderTimeChecked = value
        End Set
    End Property

    Public Property usrReminderAdd() As Boolean
        Get
            Return _usrReminderAdd
        End Get
        Set(ByVal value As Boolean)
            _usrReminderAdd = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- World Klock Settings --------

    Public Property usrWorldKlockAdd() As Boolean
        Get
            Return _usrWorldKlockAdd
        End Get
        Set(ByVal value As Boolean)
            _usrWorldKlockAdd = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Notification Settings -------

    Public Property usrNotificationbackColour() As Color
        Get
            Return _usrNotificationbackColour
        End Get
        Set(ByVal value As Color)
            _usrNotificationbackColour = value
        End Set
    End Property

    Public Property usrNotificationFont() As Font
        Get
            Return _usrNotificationFont
        End Get
        Set(ByVal value As Font)
            _usrNotificationFont = value
        End Set
    End Property

    Public Property usrNotificationFontColour() As Color
        Get
            Return _usrNotificationFontColour
        End Get
        Set(ByVal value As Color)
            _usrNotificationFontColour = value
        End Set
    End Property

    Public Property usrNotificationTimeOut() As Integer
        Get
            Return _usrNotificationTimeOut
        End Get
        Set(ByVal value As Integer)
            _usrNotificationTimeOut = value
        End Set
    End Property

    Public Property usrNotificationOpacity() As Integer
        Get
            Return _usrNotificationOpacity
        End Get
        Set(ByVal value As Integer)
            _usrNotificationOpacity = value
        End Set
    End Property

    '------------------------------------------------------------------------------------------------------- Event Notification Settings -------

    Public Property usrEventNotificationFont() As Font
        Get
            Return _usrEventNotificationFont
        End Get
        Set(ByVal value As Font)
            _usrEventNotificationFont = value
        End Set
    End Property

    Public Property usrEventNotificationFontColour() As Color
        Get
            Return _usrEventNotificationFontColour
        End Get
        Set(ByVal value As Color)
            _usrEventNotificationFontColour = value
        End Set
    End Property

    Public Property usrFirstEventNotificationbackColour() As Color
        Get
            Return _usrFirstEventNotificationbackColour
        End Get
        Set(ByVal value As Color)
            _usrFirstEventNotificationbackColour = value
        End Set
    End Property

    Public Property usrSecondEventNotificationbackColour() As Color
        Get
            Return _usrSecondEventNotificationbackColour
        End Get
        Set(ByVal value As Color)
            _usrSecondEventNotificationbackColour = value
        End Set
    End Property

    Public Property usrThirdEventNotificationbackColour() As Color
        Get
            Return _usrThirdEventNotificationbackColour
        End Get
        Set(ByVal value As Color)
            _usrThirdEventNotificationbackColour = value
        End Set
    End Property

    Public Property usrEventNotificationOpacity() As Integer
        Get
            Return _usrEventNotificationOpacity
        End Get
        Set(ByVal value As Integer)
            _usrEventNotificationOpacity = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Sayings Settings -------
    Public Property usrSayingsDisplay() As Boolean
        Get
            Return _usrSayingsDisplay
        End Get
        Set(ByVal value As Boolean)
            _usrSayingsDisplay = value
        End Set
    End Property

    Public Property usrSayingsbackColour() As Color
        Get
            Return _usrSayingsbackColour
        End Get
        Set(ByVal value As Color)
            _usrSayingsbackColour = value
        End Set
    End Property

    Public Property usrSayingsFont() As Font
        Get
            Return _usrSayingsFont
        End Get
        Set(ByVal value As Font)
            _usrSayingsFont = value
        End Set
    End Property

    Public Property usrSayingsFontColour() As Color
        Get
            Return _usrSayingsFontColour
        End Get
        Set(ByVal value As Color)
            _usrSayingsFontColour = value
        End Set
    End Property

    Public Property usrSayingsDisplayTime() As Integer
        Get
            Return _usrSayingsDisplayTime
        End Get
        Set(ByVal value As Integer)
            _usrSayingsDisplayTime = value
        End Set
    End Property

    Public Property usrSayingsTimeOut() As Integer
        Get
            Return _usrSayingsTimeOut
        End Get
        Set(ByVal value As Integer)
            _usrSayingsTimeOut = value
        End Set
    End Property

    Public Property usrSayingsOpacity() As Integer
        Get
            Return _usrSayingsOpacity
        End Get
        Set(ByVal value As Integer)
            _usrSayingsOpacity = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------
    Public Property usrDisableMonitorSleep() As Boolean
        Get
            Return _usrDisableMonitorSleep
        End Get
        Set(ByVal value As Boolean)
            _usrDisableMonitorSleep = value
        End Set
    End Property
    '-------------------------------------------------------------------------------------------------------- Internet Settings ------------
    Public Property usrCheckInternet() As Boolean
        Get
            Return _usrCheckInternet
        End Get
        Set(ByVal value As Boolean)
            _usrCheckInternet = value
        End Set
    End Property
    '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --
    Public Property usrClipboardMonitor() As Boolean
        Get
            Return _usrClipboardMonitor
        End Get
        Set(ByVal value As Boolean)
            _usrClipboardMonitor = value
        End Set
    End Property

    Public Property usrClipboardMonitorSavePosition() As Boolean
        Get
            Return _usrClipboardMonitorSavePosition
        End Get
        Set(ByVal value As Boolean)
            _usrClipboardMonitorSavePosition = value
        End Set
    End Property

    Public Property usrClipboardMonitorTop() As Integer
        Get
            Return _usrClipboardMonitorTop
        End Get
        Set(ByVal value As Integer)
            _usrClipboardMonitorTop = value
        End Set
    End Property

    Public Property usrClipboardMonitorLeft() As Integer
        Get
            Return _usrClipboardMonitorLeft
        End Get
        Set(ByVal value As Integer)
            _usrClipboardMonitorLeft = value
        End Set
    End Property

    Public ReadOnly Property usrClipboardSavePath() As String     '   returns path to save settings file - read-only
        Get
            Return _usrClipboardSavePath
        End Get
    End Property

    '------------------------------------------------------------------------------------------------------ Friends Settings ------------

    Public Property usrFriendsFile() As String
        Get
            Return _usrFriendsFile
        End Get
        Set(ByVal value As String)
            _usrFriendsFile = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Events Settings ------------

    Public Property usrEventsFile() As String
        Get
            Return _usrEventsFile
        End Get
        Set(ByVal value As String)
            _usrEventsFile = value
        End Set
    End Property

    Public Property usrEventsFirstReminder() As Integer
        Get
            Return _usrEventsFirstReminder
        End Get
        Set(ByVal value As Integer)
            _usrEventsFirstReminder = value
        End Set
    End Property

    Public Property usrEventsSecondReminder() As Integer
        Get
            Return _usrEventsSecondReminder
        End Get
        Set(ByVal value As Integer)
            _usrEventsSecondReminder = value
        End Set
    End Property

    Public Property usrEventsThirdReminder() As Integer
        Get
            Return _usrEventsThirdReminder
        End Get
        Set(ByVal value As Integer)
            _usrEventsThirdReminder = value
        End Set
    End Property

    Public Property usrEventsTimerInterval() As Integer
        Get
            Return _usrEventsTimerInterval
        End Get
        Set(ByVal value As Integer)
            _usrEventsTimerInterval = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Memo Settings ------------

    Public Property usrMemoDefaultPassword() As String
        Get
            Return _usrMemoDefaultPassword
        End Get
        Set(ByVal value As String)
            _usrMemoDefaultPassword = value
        End Set
    End Property

    Public Property usrMemoUseDefaultPassword() As Boolean
        Get
            Return _usrMemoUseDefaultPassword
        End Get
        Set(ByVal value As Boolean)
            _usrMemoUseDefaultPassword = value
        End Set
    End Property

    Public Property usrMemoFile() As String
        Get
            Return _usrMemoFile
        End Get
        Set(ByVal value As String)
            _usrMemoFile = value
        End Set
    End Property

    Public Property usrMemoDecyptTimeOut() As Integer
        Get
            Return _usrMemoDecyptTimeOut
        End Get
        Set(ByVal value As Integer)
            _usrMemoDecyptTimeOut = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- file methods ------------

    Public Sub writeSettings()
        '   Writes all settings out to a XML file.  
        '   This is run if the xml if not present [i.e. first run of the app] and if versions have changed.  
        '   This produces the default settings file, on subsequent loading, the settings files should already exist.
        '   NB: no spaces in titles please [thinks they become attributes].
        '   NB: The tag <%= switches you to VB, and the %> tag switches you back to XML.

        Dim xmlSettings = <klock Version=<%= My.Application.Info.Version.ToString() %>>
                              <Global>
                                  <DefaultTab><%= usrDefaultTab() %></DefaultTab>
                                  <FormColour>
                                      <FormColourR><%= usrFormColour().R %></FormColourR>
                                      <FormColourG><%= usrFormColour().G %></FormColourG>
                                      <FormColourB><%= usrFormColour().B %></FormColourB>
                                      <FormColourA><%= usrFormColour().A %></FormColourA>
                                  </FormColour>
                                  <FormFont>
                                      <FormFontName><%= usrFormFont().Name %></FormFontName>
                                      <FormFontSize><%= usrFormFont().Size %></FormFontSize>
                                      <FormFontStyle><%= 0 %></FormFontStyle>
                                  </FormFont>
                                  <FormFontColour>
                                      <FormFontColourR><%= usrFormFontColour().R %></FormFontColourR>
                                      <FormFontColourG><%= usrFormFontColour().G %></FormFontColourG>
                                      <FormFontColourB><%= usrFormFontColour().B %></FormFontColourB>
                                      <FormFontColourA><%= usrFormFontColour().A %></FormFontColourA>
                                  </FormFontColour>
                                  <FormTop><%= usrFormTop() %></FormTop>
                                  <Formleft><%= usrFormLeft() %></Formleft>
                                  <SavePosition><%= usrSavePosition() %></SavePosition>
                                  <StartMinimised><%= usrStartMinimised() %></StartMinimised>
                                  <RunOnStartup><%= usrRunOnStartup() %></RunOnStartup>
                                  <SoundVolume><%= usrSoundVolume() %></SoundVolume>
                                  <usrOptionsSavePath><%= usrOptionsSavePath() %></usrOptionsSavePath>
                              </Global>
                              <Time>
                                  <TimeDefaultFormat><%= usrTimeDefaultFormat() %></TimeDefaultFormat>
                                  <TimeTwoDefaultFormat><%= usrTimeTWODefaultFormat() %></TimeTwoDefaultFormat>
                                  <TimeTwoFormats><%= usrTimeTwoFormats() %></TimeTwoFormats>
                                  <TimeIdleTime><%= usrTimeIdleTime() %></TimeIdleTime>
                                  <TimeSystem24Hour><%= usrTimeSystem24Hour() %></TimeSystem24Hour>
                                  <TimeOne24Hour><%= usrTimeOne24Hour() %></TimeOne24Hour>
                                  <TimeTwo24Hour><%= usrTimeTwo24Hour() %></TimeTwo24Hour>
                                  <TimeSwatchCentibeats><%= usrTimeSwatchCentibeats() %></TimeSwatchCentibeats>
                                  <TimeNETSeconds><%= usrTimeNETSeconds() %></TimeNETSeconds>
                                  <TimeHexIntuitorFormat><%= usrTimeHexIntuitorFormat() %></TimeHexIntuitorFormat>
                                  <TimeHourPips><%= usrTimeHourPips() %></TimeHourPips>
                                  <TimeHourChimes><%= usrTimeHourChimes() %></TimeHourChimes>
                                  <TimeHalfChimes><%= usrTimeHalfChimes() %></TimeHalfChimes>
                                  <TimeQuarterChimes><%= usrTimeQuarterChimes() %></TimeQuarterChimes>
                                  <TimeDisplayMinimised><%= usrTimeDisplayMinimised() %></TimeDisplayMinimised>
                                  <TimeDisplayMinutes><%= usrTimeDisplayMinutes() %></TimeDisplayMinutes>
                                  <TimeVoiceMinimised><%= usrTimeVoiceMinimised() %></TimeVoiceMinimised>
                                  <TimeVoiceMinutes><%= usrTimeVoiceMinutes() %></TimeVoiceMinutes>
                              </Time>
                              <BigKlock>
                                  <BigKlockTop><%= usrBigKlockTop() %></BigKlockTop>
                                  <BigKlockLeft><%= usrBigKlockLeft() %></BigKlockLeft>
                                  <BigKlockSavePosition><%= usrBigKlockSavePosition() %></BigKlockSavePosition>
                                  <BigKlockBackColourR><%= usrBigKlockBackColour().R %></BigKlockBackColourR>
                                  <BigKlockBackColourG><%= usrBigKlockBackColour().G %></BigKlockBackColourG>
                                  <BigKlockBackColourB><%= usrBigKlockBackColour().B %></BigKlockBackColourB>
                                  <BigKlockBackColourA><%= usrBigKlockBackColour().A %></BigKlockBackColourA>
                                  <BigKlockForeColourR><%= usrBigKlockForeColour().R %></BigKlockForeColourR>
                                  <BigKlockForeColourG><%= usrBigKlockForeColour().G %></BigKlockForeColourG>
                                  <BigKlockForeColourB><%= usrBigKlockForeColour().B %></BigKlockForeColourB>
                                  <BigKlockForeColourA><%= usrBigKlockForeColour().A %></BigKlockForeColourA>
                                  <BigKlockOffColourR><%= usrBigKlockOffColour().R %></BigKlockOffColourR>
                                  <BigKlockOffColourG><%= usrBigKlockOffColour().G %></BigKlockOffColourG>
                                  <BigKlockOffColourB><%= usrBigKlockOffColour().B %></BigKlockOffColourB>
                                  <BigKlockOffColourA><%= usrBigKlockOffColour().A %></BigKlockOffColourA>
                              </BigKlock>
                              <SmallKlock>
                                  <SmallKlockTop><%= usrSmallKlockTop() %></SmallKlockTop>
                                  <SmallKlockLeft><%= usrSmallKlockLeft() %></SmallKlockLeft>
                                  <SmallKlockSavePosition><%= usrSmallKlockSavePosition() %></SmallKlockSavePosition>
                                  <SmallKlockBackColourR><%= usrSmallKlockBackColour().R %></SmallKlockBackColourR>
                                  <SmallKlockBackColourG><%= usrSmallKlockBackColour().G %></SmallKlockBackColourG>
                                  <SmallKlockBackColourB><%= usrSmallKlockBackColour().B %></SmallKlockBackColourB>
                                  <SmallKlockBackColourA><%= usrSmallKlockBackColour().A %></SmallKlockBackColourA>
                                  <SmallKlockForeColourR><%= usrSmallKlockForeColour().R %></SmallKlockForeColourR>
                                  <SmallKlockForeColourG><%= usrSmallKlockForeColour().G %></SmallKlockForeColourG>
                                  <SmallKlockForeColourB><%= usrSmallKlockForeColour().B %></SmallKlockForeColourB>
                                  <SmallKlockForeColourA><%= usrSmallKlockForeColour().A %></SmallKlockForeColourA>
                                  <SmallKlockOffColourR><%= usrSmallKlockOffColour().R %></SmallKlockOffColourR>
                                  <SmallKlockOffColourG><%= usrSmallKlockOffColour().G %></SmallKlockOffColourG>
                                  <SmallKlockOffColourB><%= usrSmallKlockOffColour().B %></SmallKlockOffColourB>
                                  <SmallKlockOffColourA><%= usrSmallKlockOffColour().A %></SmallKlockOffColourA>
                              </SmallKlock>
                              <AnalogueKlock>
                                  <AnalogueKlockTop><%= usrAnalogueKlockTop() %></AnalogueKlockTop>
                                  <AnalogueKlockLeft><%= usrAnalogueKlockLeft() %></AnalogueKlockLeft>
                                  <AnalogueKlockSavePosition><%= usrAnalogueKlockSavePosition() %></AnalogueKlockSavePosition>
                                  <AnalogueKlockText><%= usrAnalogueKlockText() %></AnalogueKlockText>
                                  <AnalogueKlcokTransparent><%= usrAnalogueKlcokTransparent() %></AnalogueKlcokTransparent>
                                  <AnalogueKlockShowDate><%= usrAnalogueKlockShowDate() %></AnalogueKlockShowDate>
                                  <AnalogueKlockShowTime><%= usrAnalogueKlockShowTime() %></AnalogueKlockShowTime>
                                  <AnalogueKlockBackColourR><%= usrAnalogueKlockBackColour().R %></AnalogueKlockBackColourR>
                                  <AnalogueKlockBackColourG><%= usrAnalogueKlockBackColour().G %></AnalogueKlockBackColourG>
                                  <AnalogueKlockBackColourB><%= usrAnalogueKlockBackColour().B %></AnalogueKlockBackColourB>
                                  <AnalogueKlockBackColourA><%= usrAnalogueKlockBackColour().A %></AnalogueKlockBackColourA>
                                  <AnalogueKlockDisplayPicture><%= usrAnalogueKlockDisplayPicture() %></AnalogueKlockDisplayPicture>
                                  <AnalogueKlockPicture><%= usrAnalogueKlockPicture() %></AnalogueKlockPicture>
                              </AnalogueKlock>
                              <Timer>
                                  <TimerHigh><%= usrTimerHigh() %></TimerHigh>
                                  <TimerClearSplit><%= usrTimerClearSplit() %></TimerClearSplit>
                                  <TimerAdd><%= usrTimerAdd() %></TimerAdd>
                              </Timer>
                              <Countdown>
                                  <CountdownAdd><%= usrCountdownAdd() %></CountdownAdd>
                              </Countdown>
                              <Reminder>
                                  <ReminderTimeChecked><%= usrReminderTimeChecked() %></ReminderTimeChecked>
                                  <ReminderAdd><%= usrReminderAdd() %></ReminderAdd>
                              </Reminder>
                              <WorldKlock>
                                  <WorldKlockAdd><%= usrWorldKlockAdd() %></WorldKlockAdd>
                              </WorldKlock>
                              <Notification>
                                  <NotificationColour>
                                      <NotificationColourR><%= usrNotificationbackColour().R %></NotificationColourR>
                                      <NotificationColourG><%= usrNotificationbackColour().G %></NotificationColourG>
                                      <NotificationColourB><%= usrNotificationbackColour().B %></NotificationColourB>
                                      <NotificationColourA><%= usrNotificationbackColour().A %></NotificationColourA>
                                  </NotificationColour>
                                  <NotificationFont>
                                      <NotificationFontName><%= usrNotificationFont().Name %></NotificationFontName>
                                      <NotificationFontSize><%= usrNotificationFont().Size %></NotificationFontSize>
                                      <NotificationFontStyle><%= 0 %></NotificationFontStyle>
                                  </NotificationFont>
                                  <NotificationFontColour>
                                      <NotificationFontColourR><%= usrNotificationFontColour().R %></NotificationFontColourR>
                                      <NotificationFontColourG><%= usrNotificationFontColour().G %></NotificationFontColourG>
                                      <NotificationFontColourB><%= usrNotificationFontColour().B %></NotificationFontColourB>
                                      <NotificationFontColourA><%= usrNotificationFontColour().A %></NotificationFontColourA>
                                  </NotificationFontColour>
                                  <NotificationTimeOut><%= usrNotificationTimeOut() %></NotificationTimeOut>
                                  <NotificationOpacity><%= usrNotificationOpacity() %></NotificationOpacity>
                              </Notification>
                              <Sayings>
                                  <SayingsDisplay><%= usrSayingsDisplay() %></SayingsDisplay>
                                  <SayingsColour>
                                      <SayingsColourR><%= usrSayingsbackColour().R %></SayingsColourR>
                                      <SayingsColourG><%= usrSayingsbackColour().G %></SayingsColourG>
                                      <SayingsColourB><%= usrSayingsbackColour().B %></SayingsColourB>
                                      <SayingsColourA><%= usrSayingsbackColour().A %></SayingsColourA>
                                  </SayingsColour>
                                  <SayingsFont>
                                      <SayingsFontName><%= usrSayingsFont().Name %></SayingsFontName>
                                      <SayingsFontSize><%= usrSayingsFont().Size %></SayingsFontSize>
                                      <SayingsFontStyle><%= 0 %></SayingsFontStyle>
                                  </SayingsFont>
                                  <SayingsFontColour>
                                      <SayingsFontColourR><%= usrSayingsFontColour().R %></SayingsFontColourR>
                                      <SayingsFontColourG><%= usrSayingsFontColour().G %></SayingsFontColourG>
                                      <SayingsFontColourB><%= usrSayingsFontColour().B %></SayingsFontColourB>
                                      <SayingsFontColourA><%= usrSayingsFontColour().A %></SayingsFontColourA>
                                  </SayingsFontColour>
                                  <SayingsDisplayTime><%= usrSayingsDisplayTime() %></SayingsDisplayTime>
                                  <SayingsTimeOut><%= usrSayingsTimeOut() %></SayingsTimeOut>
                                  <SayingsOpacity><%= usrSayingsOpacity() %></SayingsOpacity>
                              </Sayings>
                              <Monitor>
                                  <DisableMonitorSleep><%= usrDisableMonitorSleep() %></DisableMonitorSleep>
                              </Monitor>
                              <Internet>
                                  <CheckInternet><%= usrCheckInternet() %></CheckInternet>
                              </Internet>
                              <Clipboard>
                                  <ClipboardMonitor><%= usrClipboardMonitor() %></ClipboardMonitor>
                                  <ClipboardMonitorSavePosition><%= usrClipboardMonitorSavePosition() %></ClipboardMonitorSavePosition>
                                  <ClipboardMonitorTop><%= usrClipboardMonitorTop() %></ClipboardMonitorTop>
                                  <ClipboardMonitorLeft><%= usrClipboardMonitorLeft() %></ClipboardMonitorLeft>
                              </Clipboard>
                              <Friends>
                                  <FriendsFileName><%= usrFriendsFile() %></FriendsFileName>
                              </Friends>
                              <Events>
                                  <EventsFileName><%= usrEventsFile() %></EventsFileName>
                                  <EventsFirstReminder><%= usrEventsFirstReminder() %></EventsFirstReminder>
                                  <EventsSecondReminder><%= usrEventsSecondReminder() %></EventsSecondReminder>
                                  <EventsThirdReminder><%= usrEventsThirdReminder() %></EventsThirdReminder>
                                  <EventsTimerInterval><%= usrEventsTimerInterval() %></EventsTimerInterval>
                                  <EventNotificationFont>
                                      <EventNotificationFontName><%= usrEventNotificationFont().Name %></EventNotificationFontName>
                                      <EventNotificationFontSize><%= usrEventNotificationFont().Size %></EventNotificationFontSize>
                                      <EventNotificationFontStyle><%= 0 %></EventNotificationFontStyle>
                                  </EventNotificationFont>
                                  <EventNotificationFontColour>
                                      <EventNotificationFontColourR><%= usrEventNotificationFontColour().R %></EventNotificationFontColourR>
                                      <EventNotificationFontColourG><%= usrEventNotificationFontColour().G %></EventNotificationFontColourG>
                                      <EventNotificationFontColourB><%= usrEventNotificationFontColour().B %></EventNotificationFontColourB>
                                      <EventNotificationFontColourA><%= usrEventNotificationFontColour().A %></EventNotificationFontColourA>
                                  </EventNotificationFontColour>
                                  <FirstEventNotificationColour>
                                      <FirstEventNotificationColourR><%= usrFirstEventNotificationbackColour().R %></FirstEventNotificationColourR>
                                      <FirstEventNotificationColourG><%= usrFirstEventNotificationbackColour().G %></FirstEventNotificationColourG>
                                      <FirstEventNotificationColourB><%= usrFirstEventNotificationbackColour().B %></FirstEventNotificationColourB>
                                      <FirstEventNotificationColourA><%= usrFirstEventNotificationbackColour().A %></FirstEventNotificationColourA>
                                  </FirstEventNotificationColour>
                                  <SecondEventNotificationColour>
                                      <SecondEventNotificationColourR><%= usrSecondEventNotificationbackColour().R %></SecondEventNotificationColourR>
                                      <SecondEventNotificationColourG><%= usrSecondEventNotificationbackColour().G %></SecondEventNotificationColourG>
                                      <SecondEventNotificationColourB><%= usrSecondEventNotificationbackColour().B %></SecondEventNotificationColourB>
                                      <SecondEventNotificationColourA><%= usrSecondEventNotificationbackColour().A %></SecondEventNotificationColourA>
                                  </SecondEventNotificationColour>
                                  <ThirdEventNotificationColour>
                                      <ThirdEventNotificationColourR><%= usrThirdEventNotificationbackColour().R %></ThirdEventNotificationColourR>
                                      <ThirdEventNotificationColourG><%= usrThirdEventNotificationbackColour().G %></ThirdEventNotificationColourG>
                                      <ThirdEventNotificationColourB><%= usrThirdEventNotificationbackColour().B %></ThirdEventNotificationColourB>
                                      <ThirdEventNotificationColourA><%= usrThirdEventNotificationbackColour().A %></ThirdEventNotificationColourA>
                                  </ThirdEventNotificationColour>
                                  <EventNotificationOpacity><%= usrEventNotificationOpacity() %></EventNotificationOpacity>
                              </Events>
                              <Memo>
                                  <MemoFileName><%= usrMemoFile() %></MemoFileName>
                                  <MemoUseDefaultPassword><%= usrMemoUseDefaultPassword() %></MemoUseDefaultPassword>
                                  <MemoDefaultPassword><%= usrMemoDefaultPassword() %></MemoDefaultPassword>
                                  <MemoDecyptTimeOut><%= usrMemoDecyptTimeOut() %></MemoDecyptTimeOut>
                              </Memo>
                          </klock>

        xmlSettings.Save(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile()))
    End Sub

    Public Sub writeDefaultSettings()
        '   Writes all default settings out to a XML file.  
        '   This is run on demand.

        Dim xmlSettings = <klock Version=<%= My.Application.Info.Version.ToString() %>>
                              <Global>
                                  <DefaultTab>0</DefaultTab>
                                  <FormColour>
                                      <FormColourR>240</FormColourR>
                                      <FormColourG>240</FormColourG>
                                      <FormColourB>240</FormColourB>
                                      <FormColourA>255</FormColourA>
                                  </FormColour>
                                  <FormFont>
                                      <FormFontName>Microsoft Sans Serif</FormFontName>
                                      <FormFontSize>8.25</FormFontSize>
                                      <FormFontStyle>0</FormFontStyle>
                                  </FormFont>
                                  <FormFontColour>
                                      <FormFontColourR>0</FormFontColourR>
                                      <FormFontColourG>0</FormFontColourG>
                                      <FormFontColourB>0</FormFontColourB>
                                      <FormFontColourA>255</FormFontColourA>
                                  </FormFontColour>
                                  <FormTop>100</FormTop>
                                  <Formleft>100</Formleft>
                                  <SavePosition>False</SavePosition>
                                  <StartMinimised>False</StartMinimised>
                                  <RunOnStartup>False</RunOnStartup>
                                  <SoundVolume>100</SoundVolume>
                                  <usrOptionsSavePath><%= usrOptionsSavePath() %></usrOptionsSavePath>
                              </Global>
                              <Time>
                                  <TimeDefaultFormat>0</TimeDefaultFormat>
                                  <TimeTwoDefaultFormat>1</TimeTwoDefaultFormat>
                                  <TimeTwoFormats>False</TimeTwoFormats>
                                  <TimeIdleTime>False</TimeIdleTime>
                                  <TimeSystem24Hour>True</TimeSystem24Hour>
                                  <TimeOne24Hour>True</TimeOne24Hour>
                                  <TimeTwo24Hour>True</TimeTwo24Hour>
                                  <TimeSwatchCentibeats>False</TimeSwatchCentibeats>
                                  <TimeNETSeconds>False</TimeNETSeconds>
                                  <TimeHexIntuitorFormat>False</TimeHexIntuitorFormat>
                                  <TimeHourPips>False</TimeHourPips>
                                  <TimeHourChimes>False</TimeHourChimes>
                                  <TimeHalfChimes>False</TimeHalfChimes>
                                  <TimeQuarterChimes>False</TimeQuarterChimes>
                                  <TimeDisplayMinimised>False</TimeDisplayMinimised>
                                  <TimeDisplayMinutes>15</TimeDisplayMinutes>
                                  <TimeVoiceMinimised>False</TimeVoiceMinimised>
                                  <TimeVoiceMinutes>15</TimeVoiceMinutes>
                              </Time>
                              <BigKlock>
                                  <BigKlockTop>100</BigKlockTop>
                                  <BigKlockLeft>100</BigKlockLeft>
                                  <BigKlockSavePosition>True</BigKlockSavePosition>
                                  <BigKlockBackColourR>0</BigKlockBackColourR>
                                  <BigKlockBackColourG>0</BigKlockBackColourG>
                                  <BigKlockBackColourB>0</BigKlockBackColourB>
                                  <BigKlockBackColourA>255</BigKlockBackColourA>
                                  <BigKlockForeColourR>144</BigKlockForeColourR>
                                  <BigKlockForeColourG>144</BigKlockForeColourG>
                                  <BigKlockForeColourB>238</BigKlockForeColourB>
                                  <BigKlockForeColourA>255</BigKlockForeColourA>
                                  <BigKlockOffColourR>119</BigKlockOffColourR>
                                  <BigKlockOffColourG>136</BigKlockOffColourG>
                                  <BigKlockOffColourB>153</BigKlockOffColourB>
                                  <BigKlockOffColourA>255</BigKlockOffColourA>
                              </BigKlock>
                              <SmallKlock>
                                  <SmallKlockTop>100</SmallKlockTop>
                                  <SmallKlockLeft>100</SmallKlockLeft>
                                  <SmallKlockSavePosition>True</SmallKlockSavePosition>
                                  <SmallKlockBackColourR>0</SmallKlockBackColourR>
                                  <SmallKlockBackColourG>0</SmallKlockBackColourG>
                                  <SmallKlockBackColourB>0</SmallKlockBackColourB>
                                  <SmallKlockBackColourA>255</SmallKlockBackColourA>
                                  <SmallKlockForeColourR>144</SmallKlockForeColourR>
                                  <SmallKlockForeColourG>144</SmallKlockForeColourG>
                                  <SmallKlockForeColourB>238</SmallKlockForeColourB>
                                  <SmallKlockForeColourA>255</SmallKlockForeColourA>
                                  <SmallKlockOffColourR>119</SmallKlockOffColourR>
                                  <SmallKlockOffColourG>136</SmallKlockOffColourG>
                                  <SmallKlockOffColourB>153</SmallKlockOffColourB>
                                  <SmallKlockOffColourA>255</SmallKlockOffColourA>
                              </SmallKlock>
                              <AnalogueKlock>
                                  <AnalogueKlockTop>100</AnalogueKlockTop>
                                  <AnalogueKlockLeft>100</AnalogueKlockLeft>
                                  <AnalogueKlockSavePosition>True</AnalogueKlockSavePosition>
                                  <AnalogueKlockText>Klock</AnalogueKlockText>
                                  <AnalogueKlcokTransparent>False</AnalogueKlcokTransparent>
                                  <AnalogueKlockShowDate>True</AnalogueKlockShowDate>
                                  <AnalogueKlockShowTime>True</AnalogueKlockShowTime>
                                  <AnalogueKlockBackColourR>119</AnalogueKlockBackColourR>
                                  <AnalogueKlockBackColourG>136</AnalogueKlockBackColourG>
                                  <AnalogueKlockBackColourB>153</AnalogueKlockBackColourB>
                                  <AnalogueKlockBackColourA>255</AnalogueKlockBackColourA>
                                  <AnalogueKlockDisplayPicture>False</AnalogueKlockDisplayPicture>
                                  <AnalogueKlockPicture></AnalogueKlockPicture>
                              </AnalogueKlock>
                              <Timer>
                                  <TimerHigh>False</TimerHigh>
                                  <TimerClearSplit>False</TimerClearSplit>
                                  <TimerAdd>False</TimerAdd>
                              </Timer>
                              <Countdown>
                                  <CountdownAdd>False</CountdownAdd>
                              </Countdown>
                              <Reminder>
                                  <ReminderTimeChecked>False</ReminderTimeChecked>
                                  <ReminderAdd>False</ReminderAdd>
                              </Reminder>
                              <WorldKlock>
                                  <WorldKlockAdd>False</WorldKlockAdd>
                              </WorldKlock>
                              <Notification>
                                  <NotificationColour>
                                      <NotificationColourR>240</NotificationColourR>
                                      <NotificationColourG>240</NotificationColourG>
                                      <NotificationColourB>240</NotificationColourB>
                                      <NotificationColourA>255</NotificationColourA>
                                  </NotificationColour>
                                  <NotificationFont>
                                      <NotificationFontName>Microsoft Sans Serif</NotificationFontName>
                                      <NotificationFontSize>8.25</NotificationFontSize>
                                      <NotificationFontStyle>0</NotificationFontStyle>
                                  </NotificationFont>
                                  <NotificationFontColour>
                                      <NotificationFontColourR>0</NotificationFontColourR>
                                      <NotificationFontColourG>0</NotificationFontColourG>
                                      <NotificationFontColourB>0</NotificationFontColourB>
                                      <NotificationFontColourA>255</NotificationFontColourA>
                                  </NotificationFontColour>
                                  <NotificationTimeOut>5000</NotificationTimeOut>
                                  <NotificationOpacity>80</NotificationOpacity>
                              </Notification>
                              <Sayings>
                                  <SayingsDisplay>True</SayingsDisplay>
                                  <SayingsColour>
                                      <SayingsColourR>240</SayingsColourR>
                                      <SayingsColourG>240</SayingsColourG>
                                      <SayingsColourB>240</SayingsColourB>
                                      <SayingsColourA>255</SayingsColourA>
                                  </SayingsColour>
                                  <SayingsFont>
                                      <SayingsFontName>Microsoft Sans Serif</SayingsFontName>
                                      <SayingsFontSize>8.25</SayingsFontSize>
                                      <SayingsFontStyle>0</SayingsFontStyle>
                                  </SayingsFont>
                                  <SayingsFontColour>
                                      <SayingsFontColourR>0</SayingsFontColourR>
                                      <SayingsFontColourG>0</SayingsFontColourG>
                                      <SayingsFontColourB>0</SayingsFontColourB>
                                      <SayingsFontColourA>255</SayingsFontColourA>
                                  </SayingsFontColour>
                                  <SayingsDisplayTime>60000</SayingsDisplayTime>
                                  <SayingsTimeOut>5000</SayingsTimeOut>
                                  <SayingsOpacity>80</SayingsOpacity>
                              </Sayings>
                              <Monitor>
                                  <DisableMonitorSleep>False</DisableMonitorSleep>
                              </Monitor>
                              <Internet>
                                  <CheckInternet>False</CheckInternet>
                              </Internet>
                              <Clipboard>
                                  <ClipboardMonitor>false</ClipboardMonitor>
                                  <ClipboardMonitorSavePosition>True</ClipboardMonitorSavePosition>
                                  <ClipboardMonitorTop>100</ClipboardMonitorTop>
                                  <ClipboardMonitorLeft>100</ClipboardMonitorLeft>
                              </Clipboard>
                              <Friends>
                                  <FriendsDirectory><%= usrOptionsSavePath() %></FriendsDirectory>
                                  <FriendsFileName>Friends.bin</FriendsFileName>
                              </Friends>
                              <Events>
                                  <EventsDirectory><%= usrOptionsSavePath() %></EventsDirectory>
                                  <EventsFileName>Events.bin</EventsFileName>
                                  <EventsFirstReminder>7</EventsFirstReminder>
                                  <EventsSecondReminder>5</EventsSecondReminder>
                                  <EventsThirdReminder>1</EventsThirdReminder>
                                  <EventsTimerInterval>60</EventsTimerInterval>
                                  <EventNotificationFont>
                                      <EventNotificationFontName>Microsoft Sans Serif</EventNotificationFontName>
                                      <EventNotificationFontSize>8.25</EventNotificationFontSize>
                                      <EventNotificationFontStyle>0</EventNotificationFontStyle>
                                  </EventNotificationFont>
                                  <EventNotificationFontColour>
                                      <EventNotificationFontColourR>128</EventNotificationFontColourR>
                                      <EventNotificationFontColourG>255</EventNotificationFontColourG>
                                      <EventNotificationFontColourB>255</EventNotificationFontColourB>
                                      <EventNotificationFontColourA>255</EventNotificationFontColourA>
                                  </EventNotificationFontColour>
                                  <FirstEventNotificationColour>
                                      <FirstEventNotificationColourR>242</FirstEventNotificationColourR>
                                      <FirstEventNotificationColourG>255</FirstEventNotificationColourG>
                                      <FirstEventNotificationColourB>198</FirstEventNotificationColourB>
                                      <FirstEventNotificationColourA>255</FirstEventNotificationColourA>
                                  </FirstEventNotificationColour>
                                  <SecondEventNotificationColour>
                                      <SecondEventNotificationColourR>255</SecondEventNotificationColourR>
                                      <SecondEventNotificationColourG>255</SecondEventNotificationColourG>
                                      <SecondEventNotificationColourB>183</SecondEventNotificationColourB>
                                      <SecondEventNotificationColourA>255</SecondEventNotificationColourA>
                                  </SecondEventNotificationColour>
                                  <ThirdEventNotificationColour>
                                      <ThirdEventNotificationColourR>255</ThirdEventNotificationColourR>
                                      <ThirdEventNotificationColourG>168</ThirdEventNotificationColourG>
                                      <ThirdEventNotificationColourB>168</ThirdEventNotificationColourB>
                                      <ThirdEventNotificationColourA>255</ThirdEventNotificationColourA>
                                  </ThirdEventNotificationColour>
                                  <EventNotificationOpacity>80</EventNotificationOpacity>
                              </Events>
                              <Memo>
                                  <MemoFileName><%= usrMemoFile() %></MemoFileName>
                                  <MemoUseDefaultPassword>False</MemoUseDefaultPassword>
                                  <MemoDefaultPassword>klock</MemoDefaultPassword>
                                  <MemoDecyptTimeOut>30</MemoDecyptTimeOut>
                              </Memo>
                          </klock>

        xmlSettings.Save(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile()))
    End Sub

    Public Sub readSettings()
        '   Read in the settings from the XML file.
        '   Uses LINQ to XMP, apparently
        '   Need to read each node [element] in order and level, the value is then converted to the desired type..

        Dim r, g, b, a As Byte
        Dim name As String
        Dim size As Single
        Dim style As FontStyle
        Dim version As String

        Try
            Dim elem As XElement = XElement.Load(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile()))

            version = elem.Attribute("Version").Value.ToString

            '-------------------------------------------------------------------------------------------------------- Global Settings -------------
            Dim glbl = elem.Element("Global")

            usrDefaultTab = CType(readElement(glbl, "DefaultTab", usrDefaultTab()), Integer)

            Dim frmClr = glbl.Element("FormColour")
            r = CType(readElement(frmClr, "FormColourR", usrFormColour().R), Byte)
            g = CType(readElement(frmClr, "FormColourG", usrFormColour().G), Byte)
            b = CType(readElement(frmClr, "FormColourB", usrFormColour().B), Byte)
            a = CType(readElement(frmClr, "FormColourA", usrFormColour().A), Byte)
            usrFormColour = Color.FromArgb(a, r, g, b)

            Dim fnt = glbl.Element("FormFont")
            name = readElement(fnt, "FormFontName", usrFormFont().Name)       '   already a string
            size = CType(readElement(fnt, "FormFontSize", usrFormFont().Size), Single)
            style = CType(readElement(fnt, "FormFontStyle", 0), FontStyle)
            usrFormFont() = New Font(name, size, style)

            Dim frmFntClr = glbl.Element("FormFontColour")
            r = CType(readElement(frmFntClr, "FormFontColourR", usrFormFontColour().R), Byte)
            g = CType(readElement(frmFntClr, "FormFontColourG", usrFormFontColour().G), Byte)
            b = CType(readElement(frmFntClr, "FormFontColourB", usrFormFontColour().B), Byte)
            a = CType(readElement(frmFntClr, "FormFontColourA", usrFormFontColour().A), Byte)
            usrFormFontColour = Color.FromArgb(a, r, g, b)

            usrFormTop = CType(readElement(glbl, "FormTop", usrFormTop()), Integer)
            usrFormLeft = CType(readElement(glbl, "Formleft", usrFormLeft()), Integer)
            usrSavePosition = CType(readElement(glbl, "SavePosition", usrSavePosition()), Boolean)
            usrStartMinimised = CType(readElement(glbl, "StartMinimised", usrStartMinimised()), Boolean)
            usrRunOnStartup = CType(readElement(glbl, "RunOnStartup", usrRunOnStartup()), Boolean)
            usrSoundVolume = CType(readElement(glbl, "SoundVolume", usrSoundVolume()), Integer)

            '-------------------------------------------------------------------------------------------------------- Time Settings ---------------
            Dim tm = elem.Element("Time")

            usrTimeDefaultFormat = CType(readElement(tm, "TimeDefaultFormat", usrTimeDefaultFormat()), Integer)
            usrTimeTWODefaultFormat = CType(readElement(tm, "TimeTwoDefaultFormat", usrTimeTWODefaultFormat()), Integer)
            usrTimeTwoFormats = CType(readElement(tm, "TimeTwoFormats", usrTimeTwoFormats()), Boolean)
            usrTimeIdleTime = CType(readElement(tm, "TimeIdleTime", usrTimeIdleTime()), Boolean)
            usrTimeSystem24Hour = CType(readElement(tm, "TimeSystem24Hour", usrTimeSystem24Hour()), Boolean)
            usrTimeOne24Hour = CType(readElement(tm, "TimeOne24Hour", usrTimeOne24Hour()), Boolean)
            usrTimeTwo24Hour = CType(readElement(tm, "TimeTwo24Hour", usrTimeTwo24Hour()), Boolean)
            usrTimeSwatchCentibeats = CType(readElement(tm, "TimeSwatchCentibeats", usrTimeSwatchCentibeats()), Boolean)
            usrTimeNETSeconds = CType(readElement(tm, "TimeNETSeconds", usrTimeNETSeconds()), Boolean)
            usrTimeHexIntuitorFormat = CType(readElement(tm, "TimeHexIntuitorFormat", usrTimeHexIntuitorFormat()), Boolean)
            usrTimeHourPips = CType(readElement(tm, "TimeHourPips", usrTimeHourPips()), Boolean)
            usrTimeHourChimes = CType(readElement(tm, "TimeHourChimes", usrTimeHourChimes()), Boolean)
            usrTimeHalfChimes = CType(readElement(tm, "TimeHalfChimes", usrTimeHalfChimes()), Boolean)
            usrTimeQuarterChimes = CType(readElement(tm, "TimeQuarterChimes", usrTimeQuarterChimes()), Boolean)
            usrTimeDisplayMinimised = CType(readElement(tm, "TimeDisplayMinimised", usrTimeDisplayMinimised()), Boolean)
            usrTimeDisplayMinutes = CType(readElement(tm, "TimeDisplayMinutes", usrTimeDisplayMinutes()), Integer)
            usrTimeVoiceMinimised = CType(readElement(tm, "TimeVoiceMinimised", usrTimeVoiceMinutes()), Boolean)
            usrTimeVoiceMinutes = CType(readElement(tm, "TimeVoiceMinutes", usrTimeVoiceMinutes()), Integer)

            '-------------------------------------------------------------------------------------------------------- Big Klock Settings ----------

            Dim bgklck = elem.Element("BigKlock")

            usrBigKlockTop = CType(readElement(bgklck, "BigKlockTop", usrBigKlockTop()), Integer)
            usrBigKlockLeft = CType(readElement(bgklck, "BigKlockLeft", usrBigKlockLeft()), Integer)
            usrBigKlockSavePosition = CType(readElement(bgklck, "BigKlockSavePosition", usrBigKlockSavePosition()), Boolean)

            r = CType(readElement(bgklck, "BigKlockBackColourR", usrBigKlockBackColour().R), Byte)
            g = CType(readElement(bgklck, "BigKlockBackColourG", usrBigKlockBackColour().G), Byte)
            b = CType(readElement(bgklck, "BigKlockBackColourB", usrBigKlockBackColour().B), Byte)
            a = CType(readElement(bgklck, "BigKlockBackColourA", usrBigKlockBackColour().A), Byte)
            usrBigKlockBackColour = Color.FromArgb(a, r, g, b)

            r = CType(readElement(bgklck, "BigKlockForeColourR", usrBigKlockForeColour().R), Byte)
            g = CType(readElement(bgklck, "BigKlockForeColourG", usrBigKlockForeColour().G), Byte)
            b = CType(readElement(bgklck, "BigKlockForeColourB", usrBigKlockForeColour().B), Byte)
            a = CType(readElement(bgklck, "BigKlockForeColourA", usrBigKlockForeColour().A), Byte)
            usrBigKlockForeColour = Color.FromArgb(a, r, g, b)

            r = CType(readElement(bgklck, "BigKlockOffColourR", usrBigKlockOffColour().R), Byte)
            g = CType(readElement(bgklck, "BigKlockOffColourG", usrBigKlockOffColour().G), Byte)
            b = CType(readElement(bgklck, "BigKlockOffColourB", usrBigKlockOffColour().B), Byte)
            a = CType(readElement(bgklck, "BigKlockOffColourA", usrBigKlockOffColour().A), Byte)
            usrBigKlockOffColour = Color.FromArgb(a, r, g, b)

            '-------------------------------------------------------------------------------------------------------- Small Klock Settings ---------

            Dim smlklck = elem.Element("SmallKlock")

            usrSmallKlockTop = CType(readElement(smlklck, "SmallKlockTop", usrSmallKlockTop()), Integer)
            usrSmallKlockLeft = CType(readElement(smlklck, "SmallKlockLeft", usrSmallKlockLeft()), Integer)
            usrSmallKlockSavePosition = CType(readElement(smlklck, "SmallKlockSavePosition", usrSmallKlockSavePosition()), Boolean)

            r = CType(readElement(smlklck, "SmallKlockBackColourR", usrSmallKlockBackColour().R), Byte)
            g = CType(readElement(smlklck, "SmallKlockBackColourG", usrSmallKlockBackColour().G), Byte)
            b = CType(readElement(smlklck, "SmallKlockBackColourB", usrSmallKlockBackColour().B), Byte)
            a = CType(readElement(smlklck, "SmallKlockBackColourA", usrSmallKlockBackColour().A), Byte)
            usrSmallKlockBackColour = Color.FromArgb(a, r, g, b)

            r = CType(readElement(smlklck, "SmallKlockForeColourR", usrSmallKlockForeColour().R), Byte)
            g = CType(readElement(smlklck, "SmallKlockForeColourG", usrSmallKlockForeColour().G), Byte)
            b = CType(readElement(smlklck, "SmallKlockForeColourB", usrSmallKlockForeColour().B), Byte)
            a = CType(readElement(smlklck, "SmallKlockForeColourA", usrSmallKlockForeColour().A), Byte)
            usrSmallKlockForeColour = Color.FromArgb(a, r, g, b)

            r = CType(readElement(smlklck, "SmallKlockOffColourR", usrSmallKlockOffColour().R), Byte)
            g = CType(readElement(smlklck, "SmallKlockOffColourG", usrSmallKlockOffColour().G), Byte)
            b = CType(readElement(smlklck, "SmallKlockOffColourB", usrSmallKlockOffColour().B), Byte)
            a = CType(readElement(smlklck, "SmallKlockOffColourA", usrSmallKlockOffColour().A), Byte)
            usrSmallKlockOffColour = Color.FromArgb(a, r, g, b)

            '------------------------------------------------------------------------------------------------------- analogue Klock Settings -----

            Dim anlklck = elem.Element("AnalogueKlock")

            usrAnalogueKlockTop = CType(readElement(anlklck, "AnalogueKlockTop", usrAnalogueKlockTop()), Integer)
            usrAnalogueKlockLeft = CType(readElement(anlklck, "AnalogueKlockLeft", usrAnalogueKlockLeft()), Integer)
            usrAnalogueKlockSavePosition = CType(readElement(anlklck, "AnalogueKlockSavePosition", usrAnalogueKlockSavePosition()), Boolean)
            usrAnalogueKlockText = readElement(anlklck, "AnalogueKlockText", usrAnalogueKlockText())
            usrAnalogueKlcokTransparent = CType(readElement(anlklck, "AnalogueKlcokTransparent", usrAnalogueKlcokTransparent()), Boolean)
            usrAnalogueKlockShowDate = CType(readElement(anlklck, "AnalogueKlockShowDate", usrAnalogueKlockShowDate()), Boolean)
            usrAnalogueKlockShowTime = CType(readElement(anlklck, "AnalogueKlockShowTime", usrAnalogueKlockShowTime()), Boolean)

            r = CType(readElement(anlklck, "AnalogueKlockBackColourR", usrAnalogueKlockBackColour().R), Byte)
            g = CType(readElement(anlklck, "AnalogueKlockBackColourG", usrAnalogueKlockBackColour().G), Byte)
            b = CType(readElement(anlklck, "AnalogueKlockBackColourB", usrAnalogueKlockBackColour().B), Byte)
            a = CType(readElement(anlklck, "AnalogueKlockBackColourA", usrAnalogueKlockBackColour().A), Byte)
            usrAnalogueKlockBackColour = Color.FromArgb(a, r, g, b)

            usrAnalogueKlockDisplayPicture = CType(readElement(anlklck, "AnalogueKlockDisplayPicture", usrAnalogueKlockDisplayPicture()), Boolean)
            usrAnalogueKlockPicture = readElement(anlklck, "AnalogueKlockPicture", usrAnalogueKlockPicture())       '   already a string

            '-------------------------------------------------------------------------------------------------------- Timer Settings --------------
            Dim tmr = elem.Element("Timer")

            usrTimerHigh = CType(readElement(tmr, "TimerHigh", usrTimerHigh()), Boolean)
            usrTimerClearSplit = CType(readElement(tmr, "TimerClearSplit", usrTimerClearSplit()), Boolean)
            usrTimerAdd = CType(readElement(tmr, "TimerAdd", usrTimerAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------
            Dim cntDwn = elem.Element("Countdown")

            usrCountdownAdd = CType(readElement(cntDwn, "CountdownAdd", usrCountdownAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Reminder Settings ----------
            Dim rmndr = elem.Element("Reminder")

            usrReminderTimeChecked = CType(readElement(rmndr, "ReminderTimeChecked", usrReminderTimeChecked()), Boolean)
            usrReminderAdd = CType(readElement(rmndr, "ReminderAdd", usrReminderAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- World Klock Settings ----------
            Dim wrldKlck = elem.Element("WorldKlock")

            usrWorldKlockAdd = CType(readElement(wrldKlck, "WorldKlockAdd", usrWorldKlockAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Notification Settings -------
            Dim ntfctn = elem.Element("Notification")

            Dim ntfctnClr = ntfctn.Element("NotificationColour")
            r = CType(readElement(ntfctnClr, "NotificationColourR", usrNotificationbackColour().R), Byte)
            g = CType(readElement(ntfctnClr, "NotificationColourG", usrNotificationbackColour().G), Byte)
            b = CType(readElement(ntfctnClr, "NotificationColourB", usrNotificationbackColour().B), Byte)
            a = CType(readElement(ntfctnClr, "NotificationColourA", usrNotificationbackColour().A), Byte)
            usrNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim ntfctnFnt = ntfctn.Element("NotificationFont")
            name = readElement(ntfctnFnt, "NotificationFontName", usrNotificationFont().Name)       '   already a string
            size = CType(readElement(ntfctnFnt, "NotificationFontSize", usrNotificationFont().Size), Single)
            style = CType(readElement(ntfctnFnt, "NotificationFontStyle", 0), FontStyle)
            usrNotificationFont() = New Font(name, size, style)

            Dim ntfctnFntClr = ntfctn.Element("NotificationFontColour")
            r = CType(readElement(ntfctnFntClr, "NotificationFontColourR", usrNotificationFontColour().R), Byte)
            g = CType(readElement(ntfctnFntClr, "NotificationFontColourG", usrNotificationFontColour().G), Byte)
            b = CType(readElement(ntfctnFntClr, "NotificationFontColourB", usrNotificationFontColour().B), Byte)
            a = CType(readElement(ntfctnFntClr, "NotificationFontColourA", usrNotificationFontColour().A), Byte)
            usrNotificationFontColour = Color.FromArgb(a, r, g, b)

            usrNotificationTimeOut = CType(readElement(ntfctn, "NotificationTimeOut", usrNotificationTimeOut()), Integer)
            usrNotificationOpacity = CType(readElement(ntfctn, "NotificationOpacity", usrNotificationOpacity()), Integer)

            '-------------------------------------------------------------------------------------------------------- Sayings Settings -------

            Dim syng = elem.Element("Sayings")

            Dim syngClr = syng.Element("SayingsColour")
            r = CType(readElement(syngClr, "SayingsColourR", usrSayingsbackColour().R), Byte)
            g = CType(readElement(syngClr, "SayingsColourG", usrSayingsbackColour().G), Byte)
            b = CType(readElement(syngClr, "SayingsColourB", usrSayingsbackColour().B), Byte)
            a = CType(readElement(syngClr, "SayingsColourA", usrSayingsbackColour().A), Byte)
            usrSayingsbackColour = Color.FromArgb(a, r, g, b)

            Dim syngFnt = syng.Element("SayingsFont")
            name = readElement(syngFnt, "SayingsFontName", usrSayingsFont().Name)       '   already a string
            size = CType(readElement(syngFnt, "SayingsFontSize", usrSayingsFont().Size), Single)
            style = CType(readElement(syngFnt, "SayingsFontStyle", 0), FontStyle)
            usrSayingsFont() = New Font(name, size, style)

            Dim syngFntClr = syng.Element("SayingsFontColour")
            r = CType(readElement(syngFntClr, "SayingsFontColourR", usrSayingsFontColour().R), Byte)
            g = CType(readElement(syngFntClr, "SayingsFontColourG", usrSayingsFontColour().G), Byte)
            b = CType(readElement(syngFntClr, "SayingsFontColourB", usrSayingsFontColour().B), Byte)
            a = CType(readElement(syngFntClr, "SayingsFontColourA", usrSayingsFontColour().A), Byte)
            usrSayingsFontColour = Color.FromArgb(a, r, g, b)

            usrSayingsDisplay = CType(readElement(syng, "SayingsDisplay", usrSayingsDisplay()), Boolean)
            usrSayingsDisplayTime = CType(readElement(syng, "SayingsDisplayTime", usrSayingsDisplayTime()), Integer)
            usrSayingsTimeOut = CType(readElement(syng, "SayingsTimeOut", usrSayingsTimeOut()), Integer)
            usrSayingsOpacity = CType(readElement(syng, "SayingsOpacity", usrSayingsOpacity()), Integer)

            '-------------------------------------------------------------------------------------------------------- Monitor Settings ------------
            Dim mntr = elem.Element("Monitor")

            usrDisableMonitorSleep = CType(readElement(mntr, "DisableMonitorSleep", usrDisableMonitorSleep()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Internet Settings ------------
            Dim intrnt = elem.Element("Internet")

            usrCheckInternet = CType(readElement(intrnt, "CheckInternet", usrCheckInternet()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Clipboard Monitor Settings --
            Dim clpbrd = elem.Element("Clipboard")

            usrClipboardMonitor = CType(readElement(clpbrd, "ClipboardMonitor", usrClipboardMonitor()), Boolean)
            usrClipboardMonitorSavePosition = CType(readElement(clpbrd, "ClipboardMonitorSavePosition", usrClipboardMonitorSavePosition()), Boolean)
            usrClipboardMonitorTop = CType(readElement(clpbrd, "ClipboardMonitorTop", usrClipboardMonitorTop()), Integer)
            usrClipboardMonitorLeft = CType(readElement(clpbrd, "ClipboardMonitorLeft", usrClipboardMonitorLeft()), Integer)
            '-------------------------------------------------------------------------------------------------------- Friends Settings ------------
            '   values are strings, so need to convert.
            Dim frnds = elem.Element("Friends")

            usrFriendsFile = readElement(frnds, "FriendsFileName", usrFriendsFile())

            '-------------------------------------------------------------------------------------------------------- Events Settings ------------
            '   values are strings, so need to convert.
            Dim evnts = elem.Element("Events")

            usrEventsFile = readElement(evnts, "EventsFileName", usrEventsFile())

            usrEventsFirstReminder = CType(readElement(evnts, "EventsFirstReminder", usrEventsFirstReminder()), Integer)
            usrEventsSecondReminder = CType(readElement(evnts, "EventsSecondReminder", usrEventsSecondReminder()), Integer)
            usrEventsThirdReminder = CType(readElement(evnts, "EventsThirdReminder", usrEventsThirdReminder()), Integer)
            usrEventsTimerInterval = CType(readElement(evnts, "EventsTimerInterval", usrEventsTimerInterval()), Integer)

            Dim entfctnFnt = evnts.Element("EventNotificationFont")
            name = readElement(entfctnFnt, "EventNotificationFontName", usrEventNotificationFont().Name)       '   already a string
            size = CType(readElement(entfctnFnt, "EventNotificationFontSize", usrEventNotificationFont().Size), Single)
            style = CType(readElement(entfctnFnt, "EventNotificationFontStyle", 0), FontStyle)
            usrEventNotificationFont() = New Font(name, size, style)

            Dim entfctnFntClr = evnts.Element("EventNotificationFontColour")
            r = CType(readElement(entfctnFntClr, "EventNotificationFontColourR", usrEventNotificationFontColour().R), Byte)
            g = CType(readElement(entfctnFntClr, "EventNotificationFontColourG", usrEventNotificationFontColour().G), Byte)
            b = CType(readElement(entfctnFntClr, "EventNotificationFontColourB", usrEventNotificationFontColour().B), Byte)
            a = CType(readElement(entfctnFntClr, "EventNotificationFontColourA", usrEventNotificationFontColour().A), Byte)
            usrEventNotificationFontColour = Color.FromArgb(a, r, g, b)

            Dim fentfctnClr = evnts.Element("FirstEventNotificationColour")
            r = CType(readElement(fentfctnClr, "FirstEventNotificationColourR", usrFirstEventNotificationbackColour().R), Byte)
            g = CType(readElement(fentfctnClr, "FirstEventNotificationColourG", usrFirstEventNotificationbackColour().G), Byte)
            b = CType(readElement(fentfctnClr, "FirstEventNotificationColourB", usrFirstEventNotificationbackColour().B), Byte)
            a = CType(readElement(fentfctnClr, "FirstEventNotificationColourA", usrFirstEventNotificationbackColour().A), Byte)
            usrFirstEventNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim sentfctnClr = evnts.Element("SecondEventNotificationColour")
            r = CType(readElement(sentfctnClr, "SecondEventNotificationColourR", usrSecondEventNotificationbackColour().R), Byte)
            g = CType(readElement(sentfctnClr, "SecondEventNotificationColourG", usrSecondEventNotificationbackColour().G), Byte)
            b = CType(readElement(sentfctnClr, "SecondEventNotificationColourB", usrSecondEventNotificationbackColour().B), Byte)
            a = CType(readElement(sentfctnClr, "SecondEventNotificationColourA", usrSecondEventNotificationbackColour().A), Byte)
            usrSecondEventNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim tentfctnClr = evnts.Element("ThirdEventNotificationColour")
            r = CType(readElement(tentfctnClr, "ThirdEventNotificationColourR", usrThirdEventNotificationbackColour().R), Byte)
            g = CType(readElement(tentfctnClr, "ThirdEventNotificationColourG", usrThirdEventNotificationbackColour().G), Byte)
            b = CType(readElement(tentfctnClr, "ThirdEventNotificationColourB", usrThirdEventNotificationbackColour().B), Byte)
            a = CType(readElement(tentfctnClr, "ThirdEventNotificationColourA", usrThirdEventNotificationbackColour().A), Byte)
            usrThirdEventNotificationbackColour = Color.FromArgb(a, r, g, b)

            usrEventNotificationOpacity = CType(readElement(evnts, "EventNotificationOpacity", usrEventNotificationOpacity()), Integer)

            '-------------------------------------------------------------------------------------------------------- Memo Settings ------------
            '   values are strings, so need to convert.
            Dim memo = elem.Element("Memo")

            usrMemoFile = readElement(memo, "MemoFileName", usrMemoFile())
            usrMemoUseDefaultPassword = CType(readElement(memo, "MemoUseDefaultPassword", usrMemoUseDefaultPassword()), Boolean)
            usrMemoDefaultPassword = readElement(memo, "MemoDefaultPassword", usrMemoDefaultPassword())
            usrMemoDecyptTimeOut = CType(readElement(memo, "MemoDecyptTimeOut", usrMemoDecyptTimeOut()), Integer)

        Catch ex As Exception
            MessageBox.Show("Error reading stream!  " & ex.Message, "Error")
        End Try
    End Sub

    Private Function readElement(ByVal g As XElement, ByVal s As String, ByVal d As String) As String
        '   From a given node element [g], tries to read a child element [s].
        '   If found, then return the elements value.
        '   if not found, return the default [d]

        Dim r As String = ""

        Try
            r = g.Element(s).Value
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("ERROR :: " & g.ToString & " :: " & s & " :::", ex.Message, "G")
            r = d
        End Try

        Return r
    End Function

    Private Sub checkDataFile()
        '   Checks for data directory in usrOptionsSavepath(), if not create it.
        '   Checks for settings file in above directory, if not there create it.
        '   will this create errors.

        If Not My.Computer.FileSystem.DirectoryExists(usrOptionsSavePath()) Then
            My.Computer.FileSystem.CreateDirectory(usrOptionsSavePath())
        End If

        If Not My.Computer.FileSystem.FileExists(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile())) Then
            writeDefaultSettings()
        End If
    End Sub

    Private Sub checkVersion()
        '   checks version of settings file, if different from app - then write default settings file.

        Dim version As String

        Try
            Dim elem As XElement = XElement.Load(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile()))

            Version = elem.Attribute("Version").Value.ToString

            '   If version has changed, some settings might need to be added [will have been set to default].
            If version <> My.Application.Info.Version.ToString() Then
                writeDefaultSettings()
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading version!  " & ex.Message, "Error")
        End Try

    End Sub
End Class

