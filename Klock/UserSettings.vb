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
    Private _usrSavePosition As Boolean = False
    Private _usrStartMinimised As Boolean = False
    Private _usrRunOnStartup As Boolean = False
    Private _usrSoundVolume As Integer = 10
    Private _usrOptionsSavePath As String = System.IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "klock")
    Private _usrOptionsSaveFile As String = "klock.xml"
    '-------------------------------------------------------------------------------------------------------- Time Settings ---------------
    Private _usrTimeDefaultFormat As Integer = 0
    Private _usrTimeTwoDefaultFormat As Integer = 1
    Private _usrTimeTwoFormats As Boolean = False
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
    Private _usrTimeDisplayMinimised As Boolean = False
    Private _usrTimeDisplayMinutes As Integer = 15
    Private _usrTimeVoiceMinimised As Boolean = False
    Private _usrTimeVoiceMinutes As Integer = 15
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
    Private _usrEventsTimerInterval As Integer = 60
    '-------------------------------------------------------------------------------------------------------- Memo Settings -------------
    Private _usrMemoFile As String = "Memo.bin"

    Private _usrMemoUseDefaultPassword As Boolean = False
    Private _usrMemoAllowEmptyPassword As Boolean = False
    Private _usrMemoDefaultPassword As String = "klock"
    Private _usrMemoDecyptTimeOut As Integer = 30

    '   run on set up - blank at the moment.
    Public Sub New()

        MyBase.New()

        checkDataFile()         '   check data directory exists, if not create.
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
    Public Property usrTimeTWODefaultFormat() As Integer
        Get
            Return _usrTimeTwoDefaultFormat
        End Get
        Set(ByVal value As Integer)
            _usrTimeTwoDefaultFormat = value
        End Set
    End Property

    Public Property usrTimeDefaultFormat() As Integer
        Get
            Return _usrTimeDefaultFormat
        End Get
        Set(ByVal value As Integer)
            _usrTimeDefaultFormat = value
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

    '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

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

    Public Property usrMemoAllowEmptyPassword() As Boolean
        Get
            Return _usrMemoAllowEmptyPassword
        End Get
        Set(ByVal value As Boolean)
            _usrMemoAllowEmptyPassword = value
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
                                  <TimeSystem24Hour><%= usrTimeSystem24Hour() %></TimeSystem24Hour>
                                  <TimeOne24Hour><%= usrTimeOne24Hour() %></TimeOne24Hour>
                                  <TimeTimeTwo24Hour><%= usrTimeTwo24Hour() %></TimeTimeTwo24Hour>
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
                                  <MemoAllowEmptyPassword><%= usrMemoAllowEmptyPassword() %></MemoAllowEmptyPassword>
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
                                  <SavePosition>false</SavePosition>
                                  <StartMinimised>false</StartMinimised>
                                  <RunOnStartup>false</RunOnStartup>
                                  <SoundVolume>100</SoundVolume>
                                  <usrOptionsSavePath><%= usrOptionsSavePath() %></usrOptionsSavePath>
                              </Global>
                              <Time>
                                  <TimeDefaultFormat>0</TimeDefaultFormat>
                                  <TimeTwoDefaultFormat>1</TimeTwoDefaultFormat>
                                  <TimeTwoFormats>false</TimeTwoFormats>
                                  <TimeSystem24Hour>true</TimeSystem24Hour>
                                  <TimeOne24Hour>true</TimeOne24Hour>
                                  <TimeTwo24Hour>true</TimeTwo24Hour>
                                  <TimeSwatchCentibeats>false</TimeSwatchCentibeats>
                                  <TimeNETSeconds>false</TimeNETSeconds>
                                  <TimeHexIntuitorFormat>false</TimeHexIntuitorFormat>
                                  <TimeHourPips>false</TimeHourPips>
                                  <TimeHourChimes>false</TimeHourChimes>
                                  <TimeHalfChimes>false</TimeHalfChimes>
                                  <TimeQuarterChimes>false</TimeQuarterChimes>
                                  <TimeDisplayMinimised>false</TimeDisplayMinimised>
                                  <TimeDisplayMinutes>15</TimeDisplayMinutes>
                                  <TimeVoiceMinimised>false</TimeVoiceMinimised>
                                  <TimeVoiceMinutes>15</TimeVoiceMinutes>
                              </Time>
                              <Timer>
                                  <TimerHigh>false</TimerHigh>
                                  <TimerClearSplit>false</TimerClearSplit>
                                  <TimerAdd>false</TimerAdd>
                              </Timer>
                              <Countdown>
                                  <CountdownAdd>false</CountdownAdd>
                              </Countdown>
                              <Reminder>
                                  <ReminderTimeChecked>false</ReminderTimeChecked>
                                  <ReminderAdd>false</ReminderAdd>
                              </Reminder>
                              <WorldKlock>
                                  <WorldKlockAdd>false</WorldKlockAdd>
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
                                  <MemoUseDefaultPassword>false</MemoUseDefaultPassword>
                                  <MemoAllowEmptyPassword>false</MemoAllowEmptyPassword>
                                  <MemoDefaultPassword>"klock"</MemoDefaultPassword>
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

        Me.checkDataFile()

        Try
            Dim elem As XElement = XElement.Load(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile()))

            version = elem.Attribute("Version").Value.ToString

            '-------------------------------------------------------------------------------------------------------- Global Settings -------------

            Dim glbl = elem.Element("Global")

            Me.usrDefaultTab = CType(readElement(glbl, "DefaultTab", usrDefaultTab()), Integer)

            Dim frmClr = glbl.Element("FormColour")
            r = CType(readElement(frmClr, "FormColourR", usrFormColour().R), Byte)
            g = CType(readElement(frmClr, "FormColourG", usrFormColour().G), Byte)
            b = CType(readElement(frmClr, "FormColourB", usrFormColour().B), Byte)
            a = CType(readElement(frmClr, "FormColourA", usrFormColour().A), Byte)
            Me.usrFormColour = Color.FromArgb(a, r, g, b)

            Dim fnt = glbl.Element("FormFont")
            name = readElement(fnt, "FormFontName", usrFormFont().Name)       '   already a string
            size = CType(readElement(fnt, "FormFontSize", usrFormFont().Size), Single)
            style = CType(readElement(fnt, "FormFontStyle", 0), FontStyle)
            Me.usrFormFont() = New Font(name, size, style)

            Dim frmFntClr = glbl.Element("FormFontColour")
            r = CType(readElement(frmFntClr, "FormFontColourR", usrFormFontColour().R), Byte)
            g = CType(readElement(frmFntClr, "FormFontColourG", usrFormFontColour().G), Byte)
            b = CType(readElement(frmFntClr, "FormFontColourB", usrFormFontColour().B), Byte)
            a = CType(readElement(frmFntClr, "FormFontColourA", usrFormFontColour().A), Byte)
            Me.usrFormFontColour = Color.FromArgb(a, r, g, b)

            Me.usrFormTop = CType(readElement(glbl, "FormTop", usrFormTop()), Integer)
            Me.usrFormLeft = CType(readElement(glbl, "Formleft", usrFormLeft()), Integer)
            Me.usrSavePosition = CType(readElement(glbl, "SavePosition", usrSavePosition()), Boolean)
            Me.usrStartMinimised = CType(readElement(glbl, "StartMinimised", usrStartMinimised()), Boolean)
            Me.usrRunOnStartup = CType(readElement(glbl, "RunOnStartup", usrRunOnStartup()), Boolean)
            Me.usrSoundVolume = CType(readElement(glbl, "SoundVolume", usrSoundVolume()), Integer)

            '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

            Dim tm = elem.Element("Time")
            Me.usrTimeDefaultFormat = CType(readElement(tm, "TimeDefaultFormat", usrTimeDefaultFormat()), Integer)
            Me.usrTimeTWODefaultFormat = CType(readElement(tm, "TimeTwoDefaultFormat", usrTimeTWODefaultFormat()), Integer)
            Me.usrTimeTwoFormats = CType(readElement(tm, "TimeTwoFormats", usrTimeTwoFormats()), Boolean)
            Me.usrTimeSystem24Hour = CType(readElement(tm, "TimeSystem24Hour", usrTimeSystem24Hour()), Boolean)
            Me.usrTimeOne24Hour = CType(readElement(tm, "TimeOne24Hour", usrTimeOne24Hour()), Boolean)
            Me.usrTimeTwo24Hour = CType(readElement(tm, "TimeTwo24Hour", usrTimeTwo24Hour()), Boolean)
            Me.usrTimeSwatchCentibeats = CType(readElement(tm, "TimeSwatchCentibeats", usrTimeSwatchCentibeats()), Boolean)
            Me.usrTimeNETSeconds = CType(readElement(tm, "TimeNETSeconds", usrTimeNETSeconds()), Boolean)
            Me.usrTimeHexIntuitorFormat = CType(readElement(tm, "TimeHexIntuitorFormat", usrTimeHexIntuitorFormat()), Boolean)
            Me.usrTimeHourPips = CType(readElement(tm, "TimeHourPips", usrTimeHourPips()), Boolean)
            Me.usrTimeHourChimes = CType(readElement(tm, "TimeHourChimes", usrTimeHourChimes()), Boolean)
            Me.usrTimeHalfChimes = CType(readElement(tm, "TimeHalfChimes", usrTimeHalfChimes()), Boolean)
            Me.usrTimeQuarterChimes = CType(readElement(tm, "TimeQuarterChimes", usrTimeQuarterChimes()), Boolean)
            Me.usrTimeDisplayMinimised = CType(readElement(tm, "TimeDisplayMinimised", usrTimeDisplayMinimised()), Boolean)
            Me.usrTimeDisplayMinutes = CType(readElement(tm, "TimeDisplayMinutes", usrTimeDisplayMinutes()), Integer)
            Me.usrTimeVoiceMinimised = CType(readElement(tm, "TimeVoiceMinimised", usrTimeDisplayMinutes()), Boolean)
            Me.usrTimeVoiceMinutes = CType(readElement(tm, "TimeVoiceMinutes", usrTimeVoiceMinutes()), Integer)
            '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

            Dim tmr = elem.Element("Timer")
            Me.usrTimerHigh = CType(readElement(tmr, "TimerHigh", usrTimerHigh()), Boolean)
            Me.usrTimerClearSplit = CType(readElement(tmr, "TimerClearSplit", usrTimerClearSplit()), Boolean)
            Me.usrTimerAdd = CType(readElement(tmr, "TimerAdd", usrTimerAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

            Dim cntDwn = elem.Element("Countdown")
            Me.usrCountdownAdd = CType(readElement(cntDwn, "CountdownAdd", usrCountdownAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Reminder Settings ----------

            Dim rmndr = elem.Element("Reminder")

            Me.usrReminderTimeChecked = CType(readElement(rmndr, "ReminderTimeChecked", usrReminderTimeChecked()), Boolean)
            Me.usrReminderAdd = CType(readElement(rmndr, "ReminderAdd", usrReminderAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- World Klock Settings ----------

            Dim wrldKlck = elem.Element("WorldKlock")
            Me.usrWorldKlockAdd = CType(readElement(wrldKlck, "WorldKlockAdd", usrWorldKlockAdd()), Boolean)

            '-------------------------------------------------------------------------------------------------------- Notification Settings -------

            Dim ntfctn = elem.Element("Notification")

            Dim ntfctnClr = ntfctn.Element("NotificationColour")
            r = CType(readElement(ntfctnClr, "NotificationColourR", usrNotificationbackColour().R), Byte)
            g = CType(readElement(ntfctnClr, "NotificationColourG", usrNotificationbackColour().G), Byte)
            b = CType(readElement(ntfctnClr, "NotificationColourB", usrNotificationbackColour().B), Byte)
            a = CType(readElement(ntfctnClr, "NotificationColourA", usrNotificationbackColour().A), Byte)
            Me.usrNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim ntfctnFnt = ntfctn.Element("NotificationFont")
            name = readElement(ntfctnFnt, "NotificationFontName", usrNotificationFont().Name)       '   already a string
            size = CType(readElement(ntfctnFnt, "NotificationFontSize", usrNotificationFont().Size), Single)
            style = CType(readElement(ntfctnFnt, "NotificationFontStyle", 0), FontStyle)
            Me.usrNotificationFont() = New Font(name, size, style)

            Dim ntfctnFntClr = ntfctn.Element("NotificationFontColour")
            r = CType(readElement(ntfctnFntClr, "NotificationFontColourR", usrNotificationFontColour().R), Byte)
            g = CType(readElement(ntfctnFntClr, "NotificationFontColourG", usrNotificationFontColour().G), Byte)
            b = CType(readElement(ntfctnFntClr, "NotificationFontColourB", usrNotificationFontColour().B), Byte)
            a = CType(readElement(ntfctnFntClr, "NotificationFontColourA", usrNotificationFontColour().A), Byte)
            Me.usrNotificationFontColour = Color.FromArgb(a, r, g, b)

            Me.usrNotificationTimeOut = CType(readElement(ntfctn, "NotificationTimeOut", usrNotificationTimeOut()), Integer)
            Me.usrNotificationOpacity = CType(readElement(ntfctn, "NotificationOpacity", usrNotificationOpacity()), Integer)

            '-------------------------------------------------------------------------------------------------------- Friends Settings ------------
            '   values are strings, so need to convert.

            Dim frnds = elem.Element("Friends")
            Me.usrFriendsFile = readElement(frnds, "FriendsFileName", usrFriendsFile())

            '-------------------------------------------------------------------------------------------------------- Events Settings ------------
            '   values are strings, so need to convert.

            Dim evnts = elem.Element("Events")
            Me.usrEventsFile = readElement(evnts, "EventsFileName", usrEventsFile())

            Me.usrEventsFirstReminder = CType(readElement(evnts, "EventsFirstReminder", usrEventsFirstReminder()), Integer)
            Me.usrEventsSecondReminder = CType(readElement(evnts, "EventsSecondReminder", usrEventsSecondReminder()), Integer)
            Me.usrEventsThirdReminder = CType(readElement(evnts, "EventsThirdReminder", usrEventsThirdReminder()), Integer)
            Me.usrEventsTimerInterval = CType(readElement(evnts, "EventsTimerInterval", usrEventsTimerInterval()), Integer)

            Dim entfctnFnt = evnts.Element("EventNotificationFont")
            name = readElement(entfctnFnt, "EventNotificationFontName", usrEventNotificationFont().Name)       '   already a string
            size = CType(readElement(entfctnFnt, "EventNotificationFontSize", usrEventNotificationFont().Size), Single)
            style = CType(readElement(entfctnFnt, "EventNotificationFontStyle", 0), FontStyle)
            Me.usrEventNotificationFont() = New Font(name, size, style)

            Dim entfctnFntClr = evnts.Element("EventNotificationFontColour")
            r = CType(readElement(entfctnFntClr, "EventNotificationFontColourR", usrEventNotificationFontColour().R), Byte)
            g = CType(readElement(entfctnFntClr, "EventNotificationFontColourG", usrEventNotificationFontColour().G), Byte)
            b = CType(readElement(entfctnFntClr, "EventNotificationFontColourB", usrEventNotificationFontColour().B), Byte)
            a = CType(readElement(entfctnFntClr, "EventNotificationFontColourA", usrEventNotificationFontColour().A), Byte)
            Me.usrEventNotificationFontColour = Color.FromArgb(a, r, g, b)

            Dim fentfctnClr = evnts.Element("FirstEventNotificationColour")
            r = CType(readElement(fentfctnClr, "FirstEventNotificationColourR", usrFirstEventNotificationbackColour().R), Byte)
            g = CType(readElement(fentfctnClr, "FirstEventNotificationColourG", usrFirstEventNotificationbackColour().G), Byte)
            b = CType(readElement(fentfctnClr, "FirstEventNotificationColourB", usrFirstEventNotificationbackColour().B), Byte)
            a = CType(readElement(fentfctnClr, "FirstEventNotificationColourA", usrFirstEventNotificationbackColour().A), Byte)
            Me.usrFirstEventNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim sentfctnClr = evnts.Element("SecondEventNotificationColour")
            r = CType(readElement(sentfctnClr, "SecondEventNotificationColourR", usrSecondEventNotificationbackColour().R), Byte)
            g = CType(readElement(sentfctnClr, "SecondEventNotificationColourG", usrSecondEventNotificationbackColour().G), Byte)
            b = CType(readElement(sentfctnClr, "SecondEventNotificationColourB", usrSecondEventNotificationbackColour().B), Byte)
            a = CType(readElement(sentfctnClr, "SecondEventNotificationColourA", usrSecondEventNotificationbackColour().A), Byte)
            Me.usrSecondEventNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim tentfctnClr = evnts.Element("ThirdEventNotificationColour")
            r = CType(readElement(tentfctnClr, "ThirdEventNotificationColourR", usrThirdEventNotificationbackColour().R), Byte)
            g = CType(readElement(tentfctnClr, "ThirdEventNotificationColourG", usrThirdEventNotificationbackColour().G), Byte)
            b = CType(readElement(tentfctnClr, "ThirdEventNotificationColourB", usrThirdEventNotificationbackColour().B), Byte)
            a = CType(readElement(tentfctnClr, "ThirdEventNotificationColourA", usrThirdEventNotificationbackColour().A), Byte)
            Me.usrThirdEventNotificationbackColour = Color.FromArgb(a, r, g, b)

            Me.usrEventNotificationOpacity = CType(readElement(evnts, "EventNotificationOpacity", usrEventNotificationOpacity()), Integer)
            '-------------------------------------------------------------------------------------------------------- Memo Settings ------------
            '   values are strings, so need to convert.

            Dim memo = elem.Element("Memo")
            Me.usrMemoFile = readElement(memo, "MemoFileName", usrMemoFile())
            Me.usrMemoUseDefaultPassword = CType(readElement(memo, "MemoUseDefaultPassword", usrMemoUseDefaultPassword()), Boolean)
            Me.usrMemoAllowEmptyPassword = CType(readElement(memo, "MemoAllowEmptyPassword", usrMemoAllowEmptyPassword()), Boolean)
            Me.usrMemoDefaultPassword = readElement(memo, "MemoDefaultPassword", usrMemoDefaultPassword())
            Me.usrMemoDecyptTimeOut = CType(readElement(memo, "MemoDecyptTimeOut", usrMemoDecyptTimeOut()), Integer)

            '   If version has changed, some settings might need to be added [will have been set to default].
            If version <> My.Application.Info.Version.ToString() Then
                Me.writeSettings()
            End If

        Catch ex As Exception
            MessageBox.Show("Error reading stream!  " & ex.Message, "Error")
        End Try
    End Sub

    Private Function readElement(ByVal g As XElement, ByVal s As String, ByVal d As String) As String
        '   From a given node element [g], tries to read a child element [s].
        '   If found, then return the elements value.
        '   if not found, return the default [d]

        Dim r As String = ""

        '   frmKlock.displayAction.DisplayReminder("ERROR", s)

        Try
            r = g.Element(s).Value
        Catch ex As Exception
            r = d
        End Try

        readElement = r
    End Function

    Private Sub checkDataFile()
        '   Checks for data directory in usrOptionsSavepath(), if not create it.
        '   Checks for settings file in above directory, if not there create it.

        If Not My.Computer.FileSystem.DirectoryExists(usrOptionsSavePath()) Then
            My.Computer.FileSystem.CreateDirectory(usrOptionsSavePath())
        End If

        If Not My.Computer.FileSystem.FileExists(System.IO.Path.Combine(usrOptionsSavePath(), usrOptionsSaveFile())) Then
            Me.writeDefaultSettings()
        End If
    End Sub
End Class

