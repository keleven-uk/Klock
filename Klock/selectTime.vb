Public Class selectTime
    '   A class wich allows the cuurent time to be displayes in various formats.
    '   The formats are held in the enum TimeTypes, these are exported.

    '   TimeType is set to the desired time format [from TimeTypes]
    '   getTime is then called and this will return the current time is the desired time format.


    Enum TimeTypes                  '   types of time format available :: new ones add in here.
        FuzzyTime
        LocalTime
        UTC
        Swatch
        Julian
        DecimalTime
        Net
    End Enum

    Private innerTime As String     '   local version of re-formated time.
    Private TimeType As String      '   local version of desired time format

    ' *************************************************************************************** constructor ***********************

    Sub New()
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
                Case TimeTypes.Swatch
                    innerTime = getSwatchTime()
                Case TimeTypes.Julian
                    innerTime = getJulianTime()
                Case TimeTypes.DecimalTime
                    innerTime = getDecimalTime()
                Case TimeTypes.Net
                    innerTime = getNetTime()
            End Select

            Return innerTime
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


        Dim hours() As String = {"twelve", "one", "two", "three", "four", "five", "siz", "seven", "eight", "nine", "ten", "eleven", "twelve"}
        Dim hour As Integer
        Dim mins As Integer
        Dim nrms As Integer
        Dim ampm As String = ""
        Dim sRtn As String = ""

        hour = Now.Hour
        mins = Now.Minute

        If hour < 12 Then
            ampm = " in the morning"
        Else
            ampm = "pm"
        End If

        nrms = mins - (mins Mod 5)          '   gets nearest five minutes.

        If (mins Mod 5) > 2 Then            '   closer to next fivew minutes, go to next.
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

        If (hour = 12) And (nrms = 0) Then      '   fix for noon.
            ampm = "noon"
        End If

        If ampm = "pm" Then
            hour -= 12
            If hour >= 5 Then
                ampm = " in the evening"
            Else
                ampm = " in the afternoon"
            End If
        End If

        getFuzzyTime = sRtn + hours(hour) + ampm
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
        Dim noOfSeconds As Integer
        Dim noOfBeats As Double
        Dim noOfCentibeats As Double

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
        '   New Earth Time [or NET] splits the day into 260 degrees. each degree is
        '    further split into 60 minutes and further into 60 seconds.
        '
        '    Only returns NET time in NET 15 second intervals [equals 1 normal second]  }


        Dim NowTime As DateTime = Now
        Dim noOfMilliSeconds As Integer = (NowTime.Hour * 3600000) + (NowTime.Minute * 60000) + (NowTime.Second * 1000) + NowTime.Millisecond
        Dim noOfSeconds As Integer = (NowTime.Hour * 3600) + (NowTime.Minute * 60) + (NowTime.Second)

        Dim deg As Int64 = 0
        Dim min As Integer = 0
        Dim sec As Integer = 0

        If My.Settings.usrTimeNETSeconds Then
            deg = Math.Floor(noOfMilliSeconds / 240000)
            min = ((noOfMilliSeconds) - (deg * 240000)) \ 4000
            sec = ((noOfMilliSeconds) - (deg * 240000) - (min * 4000)) \ 100
        Else
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
        Dim a As Double
        Dim y As Double
        Dim m As Double
        Dim jt As Double

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

        Dim NowTime As DateTime = Now
        Dim noOfSeconds As Integer = (NowTime.Hour * 3600) + (NowTime.Minute * 60) + (NowTime.Second)
        Dim NoOfDecSecs As Integer

        Dim hrs As Integer
        Dim mins As Integer
        Dim secs As Integer

        NoOfDecSecs = noOfSeconds * (100000 / 84600)

        hrs = Math.Floor(NoOfDecSecs / 10000)
        mins = Math.Floor((NoOfDecSecs - (hrs * 10000)) / 100)
        secs = (NoOfDecSecs - (hrs * 10000) - (mins * 100))

        getDecimalTime = String.Format("{0:00} {1:00} {2:00}", hrs, mins, secs)

    End Function

End Class
