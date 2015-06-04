Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml

Public Class UserSettings

    Private DATAPATH As String = Application.StartupPath & "\Data\Klock.xml"        '   Hard wired, for now.

    '-------------------------------------------------------------------------------------------------------- Global Settings -------------
    Private _usrFormColour As Color = frmOptions.DefaultBackColor
    Private _usrFormFont As Font = frmOptions.DefaultFont
    Private _usrFormFontColour As Color = Color.Black
    Private _usrFormTop As Integer = 100
    Private _usrFormLeft As Integer = 100
    Private _usrSavePosition As Boolean = False
    Private _usrStartMinimised As Boolean = False
    Private _usrRunOnStartup As Boolean = False
    Private _usrSoundVolume As Integer = 100
    '-------------------------------------------------------------------------------------------------------- Timer Settings --------------
    Private _usrTimerHigh As Boolean = False
    Private _usrTimerClearSplit As Boolean = False
    Private _usrTimerAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Time Settings ---------------
    Private _usrTimeTwoFormats As Boolean = False
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
    '-------------------------------------------------------------------------------------------------------- Reminder Settings -----------
    Private _usrReminderTimeChecked As Boolean = False
    Private _usrReminderAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------
    Private _usrCountdownAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- World Klock Settings --------
    Private _usrWorldKlockAdd As Boolean = False
    '-------------------------------------------------------------------------------------------------------- Notification Settings -------
    Private _usrNotificationbackColour As Color = Color.Gray
    Private _usrNotificationFont As Font = frmOptions.DefaultFont
    Private _usrNotificationFontColour As Color = Color.Black
    Private _usrNotificationTimeOut As Integer = 5000
    Private _usrNotificationOpacity As Integer = 80
    '-------------------------------------------------------------------------------------------------------- Friends Settings ------------
    Private _usrFriendsDirectory As String = Application.StartupPath & "\Data\"
    Private _usrFrinedsFile As String = "Friends.bin"

    Public Sub New()

        MyBase.New()
    End Sub

    '-------------------------------------------------------------------------------------------------------- Global Settings -------------

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

    '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

    Public Property usrTimeTwoFormats() As Boolean
        Get
            Return _usrTimeTwoFormats
        End Get
        Set(ByVal value As Boolean)
            _usrTimeTwoFormats = value
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

    '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

    Public Property usrCountdownAdd() As Boolean
        Get
            Return _usrCountdownAdd
        End Get
        Set(ByVal value As Boolean)
            _usrCountdownAdd = value
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

    '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

    Public Property usrFriendsDirectory() As String
        Get
            Return _usrFriendsDirectory
        End Get
        Set(ByVal value As String)
            _usrFriendsDirectory = value
        End Set
    End Property

    Public Property usrFrinedsFile() As String
        Get
            Return _usrFrinedsFile
        End Get
        Set(ByVal value As String)
            _usrFrinedsFile = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------- Setting Methods ------------

    Public Sub writeSettings()
        '   Writes all settings out to a XML file.  This should only be used once, on first up.  
        '   This produces the default settings file, on subsequent loading, the settings files should already exist.
        '   NB: no spaces in titles please [thinks they become attributes].
        '   NB: The tag <%= switches you to VB, and the %> tag switches you back to XML.

        Dim xmlSettings = <klock>
                              <Global>
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
                                  <formleft><%= usrFormLeft() %></formleft>
                                  <SavePosition><%= usrSavePosition() %></SavePosition>
                                  <StartMinimised><%= usrStartMinimised() %></StartMinimised>
                                  <RunOnStartup><%= usrRunOnStartup() %></RunOnStartup>
                                  <SoundVolume><%= usrSoundVolume() %></SoundVolume>
                              </Global>
                              <Time>
                                  <TimeTwoFormats><%= usrTimeTwoFormats() %></TimeTwoFormats>
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
                                  <FriendsDirectory><%= usrFriendsDirectory() %></FriendsDirectory>
                                  <FriendsFileName><%= usrFrinedsFile() %></FriendsFileName>
                              </Friends>
                          </klock>

        xmlSettings.Save(DATAPATH)

    End Sub

    Public Sub readSettings()
        '   Read in the settings from the XML file.
        '   Uses LINQ to XMP, apparently
        '   Need to read each node [element] in order and level, the value is then converted to the desired type..

        Dim r, g, b, a As Byte
        Dim name As String
        Dim size As Single
        Dim style As FontStyle

        checkDataFile()         '   check data directory exists, if not create.

        Try
            Dim elem As XElement = XElement.Load(DATAPATH)

            '-------------------------------------------------------------------------------------------------------- Global Settings -------------

            Dim glbl = elem.Element("Global")

            Dim frmClr = glbl.Element("FormColour")
            r = CType(frmClr.Element("FormColourR").Value, Byte)
            g = CType(frmClr.Element("FormColourG").Value, Byte)
            b = CType(frmClr.Element("FormColourB").Value, Byte)
            a = CType(frmClr.Element("FormColourA").Value, Byte)
            Me.usrFormColour = Color.FromArgb(a, r, g, b)

            Dim fnt = glbl.Element("FormFont")
            name = CType(fnt.Element("FormFontName").Value, String)
            size = CType(fnt.Element("FormFontSize").Value, Single)
            style = CType(fnt.Element("FormFontStyle").Value, FontStyle)
            Me.usrFormFont() = New Font(name, size, style)

            Dim frmFntClr = glbl.Element("FormFontColour")
            r = CType(frmFntClr.Element("FormFontColourR").Value, Byte)
            g = CType(frmFntClr.Element("FormFontColourG").Value, Byte)
            b = CType(frmFntClr.Element("FormFontColourB").Value, Byte)
            a = CType(frmFntClr.Element("FormFontColourA").Value, Byte)
            Me.usrFormFontColour = Color.FromArgb(a, r, g, b)

            Me.usrFormTop = CType(glbl.Element("FormTop").Value, Integer)
            Me.usrFormLeft = CType(glbl.Element("formleft").Value, Integer)
            Me.usrSavePosition = CType(glbl.Element("SavePosition").Value, Boolean)
            Me.usrStartMinimised = CType(glbl.Element("StartMinimised").Value, Boolean)
            Me.usrRunOnStartup = CType(glbl.Element("RunOnStartup").Value, Boolean)
            Me.usrSoundVolume = CType(glbl.Element("SoundVolume").Value, Integer)

            '-------------------------------------------------------------------------------------------------------- Time Settings ---------------

            Dim tm = elem.Element("Time")
            Me.usrTimeTwoFormats = CType(tm.Element("TimeTwoFormats").Value, Boolean)
            Me.usrTimeSwatchCentibeats = CType(tm.Element("TimeSwatchCentibeats").Value, Boolean)
            Me.usrTimeNETSeconds = CType(tm.Element("TimeNETSeconds").Value, Boolean)
            Me.usrTimeHexIntuitorFormat = CType(tm.Element("TimeHexIntuitorFormat").Value, Boolean)
            Me.usrTimeHourPips = CType(tm.Element("TimeHourPips").Value, Boolean)
            Me.usrTimeHourChimes = CType(tm.Element("TimeHourChimes").Value, Boolean)
            Me.usrTimeHalfChimes = CType(tm.Element("TimeHalfChimes").Value, Boolean)
            Me.usrTimeQuarterChimes = CType(tm.Element("TimeQuarterChimes").Value, Boolean)
            Me.usrTimeDisplayMinimised = CType(tm.Element("TimeDisplayMinimised").Value, Boolean)
            Me.usrTimeDisplayMinutes = CType(tm.Element("TimeDisplayMinutes").Value, Integer)
            Me.usrTimeVoiceMinimised = CType(tm.Element("TimeVoiceMinimised").Value, Boolean)
            Me.usrTimeVoiceMinutes = CType(tm.Element("TimeVoiceMinutes").Value, Integer)
            '-------------------------------------------------------------------------------------------------------- Timer Settings --------------

            Dim tmr = elem.Element("Timer")
            Me.usrTimerHigh = CType(tmr.Element("TimerHigh").Value, Boolean)
            Me.usrTimerClearSplit = CType(tmr.Element("TimerClearSplit").Value, Boolean)
            Me.usrTimerAdd = CType(tmr.Element("TimerAdd").Value, Boolean)

            'Me.usrCountdownAdd = CType(elem.Element("CountdownAdd").Value, Boolean)

            '-------------------------------------------------------------------------------------------------------- Countdown Settings ----------

            Dim wrldKlck = elem.Element("WorldKlock")
            Me.usrWorldKlockAdd = CType(wrldKlck.Element("WorldKlockAdd").Value, Boolean)

            '-------------------------------------------------------------------------------------------------------- Notification Settings -------

            Dim ntfctn = elem.Element("Notification")

            Dim ntfctnClr = ntfctn.Element("NotificationColour")
            r = CType(ntfctnClr.Element("NotificationColourR").Value, Byte)
            g = CType(ntfctnClr.Element("NotificationColourG").Value, Byte)
            b = CType(ntfctnClr.Element("NotificationColourB").Value, Byte)
            a = CType(ntfctnClr.Element("NotificationColourA").Value, Byte)
            Me.usrNotificationbackColour = Color.FromArgb(a, r, g, b)

            Dim ntfctnFnt = ntfctn.Element("NotificationFont")
            name = CType(ntfctnFnt.Element("NotificationFontName").Value, String)
            size = CType(ntfctnFnt.Element("NotificationFontSize").Value, Single)
            style = CType(ntfctnFnt.Element("NotificationFontStyle").Value, FontStyle)
            Me.usrNotificationFont() = New Font(name, size, style)

            Dim ntfctnFntClr = ntfctn.Element("NotificationFontColour")
            r = CType(ntfctnFntClr.Element("NotificationFontColourR").Value, Byte)
            g = CType(ntfctnFntClr.Element("NotificationFontColourG").Value, Byte)
            b = CType(ntfctnFntClr.Element("NotificationFontColourB").Value, Byte)
            a = CType(ntfctnFntClr.Element("NotificationFontColourA").Value, Byte)
            Me.usrNotificationFontColour = Color.FromArgb(a, r, g, b)

            Me.usrNotificationTimeOut = CType(ntfctn.Element("NotificationTimeOut").Value, Integer)
            Me.usrNotificationOpacity = CType(ntfctn.Element("NotificationOpacity").Value, Integer)

            '-------------------------------------------------------------------------------------------------------- Friends Settings ------------

            Dim frnds = elem.Element("Friends")
            Me.usrFriendsDirectory = CType(frnds.Element("FriendsDirectory").Value, String)
            Me.usrFrinedsFile = CType(frnds.Element("FriendsFileName").Value, String)


        Catch ex As Exception
            MessageBox.Show("Error reading stream!  " & ex.Message, "Error")
        End Try
        

    End Sub

    Private Sub checkDataFile()
        '   Checks for data director in application start up directory, is not create it.
        '   For now this is hard wired [may also be used for the Friends data file, but this is user selectable].

        If Not My.Computer.FileSystem.FileExists(DATAPATH) Then
            Me.writeSettings()
        End If
    End Sub
End Class

