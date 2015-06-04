Public Class selectTime
    '   A class which allows the current time to be displays in various formats.
    '   The formats are held in the enum TimeTypes, these are exported.

    '   TimeType is set to the desired time format [from TimeTypes]
    '   getTime is then called and this will return the current time is the desired time format.


    Enum TimeTypes                  '   types of time format available :: new ones add in here.
        FuzzyTime
        LocalTime
        UTC
        SwatchTime
        JulianTime
        DecimalTime
        NetTime
    End Enum

    Private innerTime As String     '   local version of reformatted time.
    Private TimeType As String      '   local version of desired time format
    Private clockTick As Integer


    ' *************************************************************************************** constructor ***********************

    Sub New()
        MyBase.New()
        setType = TimeTypes.FuzzyTime
    End Sub
    ' *************************************************************************************** time properties *******************

    Public ReadOnly Property getTime() As String
        '   returns local time in desired time format. [read only]

        Get
            Select Case TimeType
                Case TimeTypes.FuzzyTime
                    innerTime = getFuzzyTime()
                Case TimeTypes.LocalTime
                    innerTime = getLocalTime()
                Case TimeTypes.UTC
                    innerTime = getUTCTime()
                Case TimeTypes.SwatchTime
                    innerTime = getSwatchTime()
                Case TimeTypes.JulianTime
                    innerTime = getJulianTime()
                Case TimeTypes.DecimalTime
                    innerTime = getDecimalTime()
                Case TimeTypes.NetTime
                    innerTime = getNetTime()
            End Select

            Return innerTime
        End Get
    End Property

    Public ReadOnly Property getClockTick()
        Get
            Select Case TimeType
                Case TimeTypes.FuzzyTime
                    clockTick = 1000
                Case TimeTypes.LocalTime
                    clockTick = 1000
                Case TimeTypes.UTC
                    clockTick = 1000
                Case TimeTypes.SwatchTime
                    clockTick = 1000
                Case TimeTypes.JulianTime
                    clockTick = 1000
                Case TimeTypes.DecimalTime
                    clockTick = 1000
                Case TimeTypes.NetTime
                    clockTick = 1000
            End Select

            Return clockTick
        End Get
    End Property

    Public Property setType() As String
        '   used to set desired time format.

        Set(ByVal value As String)
            TimeType = value
        End Set
        Get
            Return TimeType
        End Get
    End Property


    ' ***************************************************************************************** time types **********************

    Private Function getFuzzyTime() As String
        '   returns the time as a string, depending on the value of displayFuzzy.

        '   displayFuzzy set to True  :: getTime returns time as five past ten.
        '   displayFuzzy set to False :: getTime returns time as 10:05:00.


        Dim hours() As String = {"twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}
        Dim hour As Integer = 0
        Dim mins As Integer = 0
        Dim nrms As Integer = 0
        Dim ampm As String = ""
        Dim sRtn As String = ""

        hour = Now.Hour
        mins = Now.Minute

        ampm = IIf(hour < 12, " in the morning", "pm")      '   if hour less then 12, in the morning else afternoon

        nrms = mins - (mins Mod 5)                          '   gets nearest five minutes.

        If (mins Mod 5) > 2 Then                            '   closer to next five minutes, go to next.
            nrms += 5
        End If


        Select Case nrms
            Case 0
                sRtn = ""
            Case 5
                sRtn = "five past "
            Case 10
                sRtn = "ten past "
            Case 15
                sRtn = "quarter past "
            Case 20
                sRtn = "twenty past "
            Case 25
                sRtn = "twenty-five past "
            Case 30
                sRtn = "half past "
            Case 35
                sRtn = "twenty-five to "
            Case 40
                sRtn = "twenty to "
            Case 45
                sRtn = "quarter to "
            Case 50
                sRtn = "ten to "
            Case 55
                sRtn = "five to "
            Case 60
                sRtn = ""
        End Select

        If nrms > 30 Then
            hour += 1
        End If

        If (hour = 12) And (sRtn = "") Then      '   fix for noon.
            ampm = " Noon"
        ElseIf (hour = 24) And (sRtn = "") Then
            ampm = " Midnight"
        End If

        If ampm = "pm" Then
            hour -= 12
            ampm = IIf(hour >= 5, " in the evening", " in the afternoon")   '   if greater then five in the afternoon then evening.
        End If

        If sRtn = "" Then
            getFuzzyTime = "about " + hours(hour) + "ish" + ampm
        Else
            getFuzzyTime = sRtn + hours(hour) + ampm
        End If

    End Function

    Private Function getLocalTime() As String
        '   returns local time

        getLocalTime = Now.ToLocalTime.ToLongTimeString
    End Function

    Private Function getUTCTime() As String
        getUTCTime = Now.ToUniversalTime.ToLongTimeString
    End Function

    Private Function getSwatchTime() As String
        '   returns Swatch Time.
        '   Swatch time is made up of 1000 beats per day i.e. 1 beat = 86.4 seconds.
        '   This is then encoded into a string. 

        Dim UTCplus1 As DateTime = Now.ToUniversalTime.AddHours(1)
        Dim noOfSeconds As Integer = 0
        Dim noOfBeats As Double = 0
        Dim noOfCentibeats As Double = 0

        noOfSeconds = (UTCplus1.Hour * 3600) + (UTCplus1.Minute * 60) + (UTCplus1.Second)
        noOfBeats = noOfSeconds * 0.01157    ' 1000 beats per day

        If My.Settings.usrTimeSwatchCentibeats Then
            noOfCentibeats = noOfSeconds Mod 86.4
            getSwatchTime = String.Format("@ {0:###}.{1:00} BMT", noOfBeats, noOfCentibeats)
        Else
            getSwatchTime = String.Format("@ {0:###} BMT", noOfBeats)
        End If
    End Function

    Private Function getNetTime() As String
        '    New Earth Time [or NET] splits the day into 260 degrees. each degree is
        '    further split into 60 minutes and further into 60 seconds.
        '
        '    Only returns NET time in NET 15 second intervals [equals 1 normal second]  }

        Dim deg As Int64 = 0
        Dim min As Integer = 0
        Dim sec As Integer = 0

        If My.Settings.usrTimeNETSeconds Then
            Dim noOfMilliSeconds As Integer = MilliSecondOfTheDay()

            deg = Math.Floor(noOfMilliSeconds / 240000)
            min = ((noOfMilliSeconds) - (deg * 240000)) \ 4000
            sec = ((noOfMilliSeconds) - (deg * 240000) - (min * 4000)) \ 100
        Else
            Dim noOfSeconds As Integer = MilliSecondOfTheDay() / 1000

            deg = Math.Floor(noOfSeconds / 240)
            min = ((noOfSeconds) - (deg * 240)) \ 4
            sec = ((noOfSeconds) - (deg * 240) - (min * 4)) * 15
        End If

        getNetTime = String.Format("{0} deg {1} min {2} sec", deg, min, sec)

    End Function

    Private Function getJulianTime() As String
        '   returns Julian Date Time.
        '   Formulae pinched from http://en.wikipedia.org/wiki/Julian_day 

        Dim UTC As DateTime = Now.ToUniversalTime
        Dim a As Double = 0
        Dim y As Double = 0
        Dim m As Double = 0
        Dim jt As Double = 0

        a = (14 - UTC.Month) / 12
        y = UTC.Year + 4800 - a
        m = UTC.Month + (12 * a) - 3

        jt = UTC.Day + ((153 * m + 2) / 5) + (365 * y) + (y / 4) - (y / 100) + (y / 400) - 32045
        jt = jt + ((UTC.Hour - 12) / 24) + (UTC.Minute / 1440) + (UTC.Second / 86400)

        getJulianTime = String.Format("{0:#######.#######}", jt)

    End Function

    Private Function getDecimalTime() As String
        '   Returns the current [local] time in decimal notation.
        '   The day is divided into 10 hours, each hour is then split into 100 minutes of 100 seconds.  

        Dim noOfSeconds As Integer = MilliSecondOfTheDay() / 1000
        Dim NoOfDecSecs As Integer = 0

        Dim hrs As Integer = 0
        Dim mins As Integer = 0
        Dim secs As Integer = 0

        NoOfDecSecs = noOfSeconds * (100000 / 84600)

        hrs = Math.Floor(NoOfDecSecs / 10000)
        mins = Math.Floor((NoOfDecSecs - (hrs * 10000)) / 100)
        secs = (NoOfDecSecs - (hrs * 10000) - (mins * 100))

        getDecimalTime = String.Format("{0:00} {1:00} {2:00}", hrs, mins, secs)

    End Function

    Private Function MilliSecondOfTheDay() As Integer


        Dim ts As New TimeSpan(0, Now.Hour, Now.Minute, Now.Second, Now.Millisecond)

        MilliSecondOfTheDay = ts.TotalMilliseconds
    End Function


End Class
