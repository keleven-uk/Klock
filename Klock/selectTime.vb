Public Class selectTime
    '   A class which allows the current time to be displays in various formats.
    '   The formats are held in the enum TimeTypes, these are exported.

    '   TimeType is set to the desired time format [from TimeTypes]
    '   getTime is then called and this will return the current time is the desired time format.

    '   set constants up for code type - so can't get them wrong!!
    Const MORSE As String = "Morse"
    Const BRAILLE As String = "Braille"

    Enum TimeTypes                  '   types of time format available :: new ones add in here.
        FuzzyTime
        LocalTime
        WordsTime
        UTC
        SwatchTime
        JulianTime
        DecimalTime
        FlowTime
        NetTime
        MetricTime
        UnixTime
        RomanTime
        MorseTime
        BrailleTime
        TrueHexTime
        BinaryTime
        OctTime
        HexTime
        PercentTime
        MarsSolDate
        CoordinatedMarsTime
    End Enum

    Private innerTime As String     '   local version of reformatted time.
    Private use24Hour As Boolean    '   local version of use 24 hour.
    Private TimeType As String      '   local version of desired time format
    Private TimeTitle As String     '   local version of the fancy time title
    Private clockTick As Integer

    '   globally declare arrays, so can be used by more then one sub and also not re-created every call of the sub.

    Public hours() As String = {"twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}
    Public units() As String = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}
    Public tens() As String = {"zero", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"}

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
                Case TimeTypes.WordsTime
                    innerTime = getwordsTime()
                Case TimeTypes.UTC
                    innerTime = getUTCTime()
                Case TimeTypes.SwatchTime
                    innerTime = getSwatchTime()
                Case TimeTypes.JulianTime
                    innerTime = getJulianTime()
                Case TimeTypes.DecimalTime
                    innerTime = getDecimalTime()
                Case TimeTypes.FlowTime
                    innerTime = getFlowTime()
                Case TimeTypes.NetTime
                    innerTime = getNetTime()
                Case TimeTypes.MetricTime
                    innerTime = getMetricTime()
                Case TimeTypes.UnixTime
                    innerTime = getUnixTime()
                Case TimeTypes.RomanTime
                    innerTime = getRomanTime()
                Case TimeTypes.MorseTime
                    innerTime = getCodeTime(MORSE)
                Case TimeTypes.BrailleTime
                    innerTime = getCodeTime(BRAILLE)
                Case TimeTypes.TrueHexTime
                    innerTime = getTrueHexTime()
                Case TimeTypes.BinaryTime
                    innerTime = getBinaryTime()
                Case TimeTypes.OctTime
                    innerTime = getOctTime()
                Case TimeTypes.HexTime
                    innerTime = getHexTime()
                Case TimeTypes.PercentTime
                    innerTime = getPercentTime()
                Case TimeTypes.MarsSolDate
                    innerTime = getMarsSolDate()
                Case TimeTypes.CoordinatedMarsTime
                    innerTime = getCoordinatedMarsTime()
            End Select

            Return innerTime
        End Get
    End Property

    Public ReadOnly Property getTitle() As String
        '   Returns a fancy title for the chosen time format. [read only]

        Get
            Select Case TimeType
                Case TimeTypes.FuzzyTime
                    TimeTitle = "Fuzzy Time"
                Case TimeTypes.LocalTime
                    TimeTitle = "Local Time"
                Case TimeTypes.WordsTime
                    TimeTitle = "Time in Words"
                Case TimeTypes.UTC
                    TimeTitle = "Univarsal Current Time"
                Case TimeTypes.SwatchTime
                    TimeTitle = "Swatch Time"
                Case TimeTypes.JulianTime
                    TimeTitle = "Julian Date"
                Case TimeTypes.DecimalTime
                    TimeTitle = "Decimal Time"
                Case TimeTypes.FlowTime
                    TimeTitle = "Flow Time"
                Case TimeTypes.NetTime
                    TimeTitle = "New Earth Time"
                Case TimeTypes.MetricTime
                    TimeTitle = "Metric Time"
                Case TimeTypes.UnixTime
                    TimeTitle = "Unix Time"
                Case TimeTypes.RomanTime
                    TimeTitle = "Time as Roman Numerals"
                Case TimeTypes.MorseTime
                    TimeTitle = "Time as Morse Code"
                Case TimeTypes.BrailleTime
                    TimeTitle = "Time as Braille"
                Case TimeTypes.TrueHexTime
                    TimeTitle = "Time as True Hexdecimal [i.e. 16 hours]"
                Case TimeTypes.BinaryTime
                    TimeTitle = "Time as Binary [base 2] format"
                Case TimeTypes.OctTime
                    TimeTitle = "Time as octal [base 8] format"
                Case TimeTypes.HexTime
                    TimeTitle = "Time as Hexdecimal [base 16] format"
                Case TimeTypes.PercentTime
                    TimeTitle = "Time as a percent of the day"
                Case TimeTypes.MarsSolDate
                    TimeTitle = "Mars Sol Date"
                Case TimeTypes.CoordinatedMarsTime
                    TimeTitle = "Coordinated Mars Time"
            End Select

            Return TimeTitle
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

    Public Property set24Hour() As String
        '   used to set desired time format.

        Set(ByVal value As String)
            use24Hour = value
        End Set
        Get
            Return use24Hour
        End Get
    End Property
    ' ***************************************************************************************** time types **********************

    Private Function getFuzzyTime() As String
        '   returns the current [local] time as fuzzy time i.e. ten past three in the afternoon.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim nrms As Integer = mins - (mins Mod 5)           '   gets nearest five minutes.
        Dim ampm As String = ""
        Dim sRtn As String = ""

        ampm = IIf(hour < 12, "in the morning", "pm")      '   if hour less then 12, in the morning else afternoon

        If (mins Mod 5) > 2 Then nrms += 5 '   closer to next five minutes, go to next.

        Select Case nrms
            Case 0
                sRtn = ""
            Case 5
                sRtn = "five past"
            Case 10
                sRtn = "ten past"
            Case 15
                sRtn = "quarter past"
            Case 20
                sRtn = "twenty past"
            Case 25
                sRtn = "twenty-five past"
            Case 30
                sRtn = "half past"
            Case 35
                sRtn = "twenty-five to"
            Case 40
                sRtn = "twenty to"
            Case 45
                sRtn = "quarter to"
            Case 50
                sRtn = "ten to"
            Case 55
                sRtn = "five to"
            Case 60
                sRtn = ""
        End Select

        If nrms > 30 Then hour += 1

        '   generate output string according to the hour of the day.
        '   This looks more complicated then it should be, maybe sperate if then's would be better and use exit sub's inside each.

        '   if the hour is 0 or 24 and no minutes - it must be midnight.
        '   if the hour is 12 and no minutes - it must be noon.

        '   if "pm" then afternoon, subtract 12 - only use 12 hour clock.

        If (hour = 12) And (sRtn = "") Then
            getFuzzyTime = "about Noon"
        ElseIf (hour = 0) And (sRtn = "") Then
            getFuzzyTime = "about Midnight"
        ElseIf (hour = 24) And (sRtn = "") Then
            getFuzzyTime = "about Midnight"
        Else
            If ampm = "pm" Then
                hour -= 12
                ampm = IIf(hour >= 5, "in the evening", "in the afternoon")   '   if greater then five in the afternoon then evening.
            End If

            If sRtn = "" Then
                getFuzzyTime = String.Format("about {0} ish {1}", hours(hour), ampm)
            Else
                getFuzzyTime = String.Format("{0} {1} {2}", sRtn, hours(hour), ampm)
            End If
        End If
    End Function

    Private Function getLocalTime() As String
        '   returns local time

        If Me.use24Hour Then
            getLocalTime = String.Format("{0:HH:mm:ss}", System.DateTime.Now.ToLocalTime)
        Else
            getLocalTime = String.Format("{0:hh:mm:ss tt}", System.DateTime.Now.ToLocalTime)
        End If

    End Function

    Private Function getwordsTime() As String


        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim ampm As String = ""
        Dim pasTo As String = "past"

        ampm = IIf(hour < 12, "in the morning", "pm")      '   if hour less then 12, in the morning else afternoon

        If mins > 30 Then            '   past the half hour - minuted to the hour.
            hour += 1
            pasTo = "to"
            mins = 60 - mins
        End If


        '   generate output string according to the hour of the day.
        '   This looks more complicated then it should be, maybe sperate if then's would be better and use exit sub's inside each.

        '   if "pm" then afternoon, subtract 12 - only use 12 hour clock.

        If ampm = "pm" Then
            hour -= 12
            ampm = IIf(hour >= 5, "in the evening", "in the afternoon")   '   if greater then five in the afternoon then evening.
        End If

        Dim minsStr As String = ""

        Select Case mins
            Case 0
                minsStr = String.Format("{0} o'clock {1}", hours(hour), ampm)
            Case 1 To 9
                minsStr = String.Format("{0} minutes {1} {2} {3}", units(mins), pasTo, hours(hour), ampm)
            Case 10 To 20
                minsStr = String.Format("{0} minutes {1} {2} {3}", tens(mins - 9), pasTo, hours(hour), ampm)
            Case 21 To 29
                Dim minsTens As Integer = Math.Floor(mins / 10)
                Dim minsUnits As Integer = mins - (minsTens * 10)
                minsStr = String.Format("twenty{0} minutes {1} {2} {3}", units(minsUnits), pasTo, hours(hour), ampm)
            Case Else
                minsStr = String.Format("thirty minutes {1} {2} {3}", minsStr, pasTo, hours(hour), ampm)
        End Select

        getwordsTime = minsStr
    End Function

    Private Function getUTCTime() As String
        '   returns current [local] time as a Univarsal Current Time.

        If Me.use24Hour Then
            getUTCTime = String.Format("{0:HH:mm:ss}", System.DateTime.Now.ToUniversalTime.ToLongTimeString)
        Else
            getUTCTime = String.Format("{0:hh:mm:ss tt}", System.DateTime.Now.ToUniversalTime.ToLongTimeString)
        End If
    End Function

    Private Function getSwatchTime() As String
        '   returns UTC time as Swatch Time.
        '   Swatch time is made up of 1000 beats per day i.e. 1 beat = 86.4 seconds.
        '   This is then encoded into a string.

        Dim UTCplus1 As DateTime = Now.ToUniversalTime.AddHours(1)
        Dim noOfSeconds As Integer = (UTCplus1.Hour * 3600) + (UTCplus1.Minute * 60) + (UTCplus1.Second)
        Dim noOfBeats As Double = noOfSeconds * 0.01157    ' 1000 beats per day
        Dim noOfCentibeats As Double = 0

        If frmKlock.usrSettings.usrTimeSwatchCentibeats Then
            noOfCentibeats = noOfSeconds Mod 86.4
            getSwatchTime = String.Format("@ {0:###}.{1:00} BMT", noOfBeats, noOfCentibeats)
        Else
            getSwatchTime = String.Format("@ {0:###} BMT", noOfBeats)
        End If
    End Function

    Private Function getNetTime() As String
        '    Returns UTC time as New Earth Time.
        '    New Earth Time [or NET] splits the day into 260 degrees. each degree is
        '    further split into 60 minutes and further into 60 seconds.
        '
        '    Only returns NET time in NET 15 second intervals [equals 1 normal second]  }

        Dim deg As Int64 = 0
        Dim min As Integer = 0
        Dim sec As Integer = 0

        If frmKlock.usrSettings.usrTimeNETSeconds Then
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
        '   returns UTC time as a Julian Date Time.
        '   Formulae pinched from http://en.wikipedia.org/wiki/Julian_day

        Dim UTC As DateTime = Now.ToUniversalTime
        Dim a As Double = (14 - UTC.Month) / 12
        Dim y As Double = UTC.Year + 4800 - a
        Dim m As Double = UTC.Month + (12 * a) - 3
        Dim jt As Double = 0

        jt = UTC.Day + ((153 * m + 2) / 5) + (365 * y) + (y / 4) - (y / 100) + (y / 400) - 32045
        jt = jt + ((UTC.Hour - 12) / 24) + (UTC.Minute / 1440) + (UTC.Second / 86400)

        getJulianTime = String.Format("{0:#######.#######}", jt)
    End Function

    Private Function getDecimalTime() As String
        '   Returns the current [local] time in decimal notation.
        '   The day is divided into 10 hours, each hour is then split into 100 minutes of 100 seconds.

        Dim noOfSeconds As Integer = MilliSecondOfTheDay() / 1000
        Dim NoOfDecSecs As Integer = noOfSeconds * (100000 / 84600)

        Dim hrs As Integer = Math.Floor(NoOfDecSecs / 10000)
        Dim mins As Integer = Math.Floor((NoOfDecSecs - (hrs * 10000)) / 100)
        Dim secs As Integer = (NoOfDecSecs - (hrs * 10000) - (mins * 100))

        getDecimalTime = String.Format("{0:00} {1:00} {2:00}", hrs, mins, secs)
    End Function

    Private Function getTrueHexTime() As String
        '   Returns the current [local] time in Hexdecimal time.
        '   The day is divided in 10 (sixteen) hexadecimal hours, each hour in 100 (two hundred and fifty-six)
        '   hexadecimal minutes and each minute in 10 (sixteen) hexadecimal seconds.

        Dim noOfSeconds As Integer = MilliSecondOfTheDay() / 1000
        Dim noOfHexSecs As Integer = Math.Round(noOfSeconds * (65536 / 84600)) '    a Hexadecimal second is larger then a normal second

        Dim hrs As Integer = Math.Floor(noOfHexSecs / 4096)
        Dim min As Integer = Math.Floor((noOfHexSecs - (hrs * 4096)) / 16)
        Dim sec As Integer = noOfHexSecs Mod 16

        If frmKlock.usrsettings.usrTimeHexIntuitorFormat Then
            getTrueHexTime = String.Format("{0}_{1}_{2}", hrs.ToString("X"), min.ToString("X"), sec.ToString("X"))
        Else
            getTrueHexTime = String.Format(".{0}{1}{2}", hrs.ToString("X"), min.ToString("X"), sec.ToString("X"))
        End If
    End Function

    Private Function getBinaryTime() As String
        '   Returns current [local] time in binary [base 2] format.
        '   This is only a binary representation of the current time.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim secs As Integer = Now.Second

        getBinaryTime = String.Format("{0}:{1}:{2}", Convert.ToString(hour, 2), Convert.ToString(mins, 2), Convert.ToString(secs, 2))
    End Function

    Private Function getOctTime() As String
        '   Returns current [local] time in octal [base 8] format.
        '   This is only a octal representation of the current time.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim secs As Integer = Now.Second

        getOctTime = String.Format("{0}:{1}:{2}", Convert.ToString(hour, 8).PadLeft(2, "0"c), Convert.ToString(mins, 8).PadLeft(2, "0"c), Convert.ToString(secs, 8).PadLeft(2, "0"c))
    End Function

    Private Function getHexTime() As String
        '   Returns current [local] time in hex [base 16] format.
        '   This is only a hex representation of the current time.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim secs As Integer = Now.Second

        getHexTime = String.Format("{0}:{1}:{2}", Convert.ToString(hour, 16).PadLeft(2, "0"c), Convert.ToString(mins, 16).PadLeft(2, "0"c), Convert.ToString(secs, 16).PadLeft(2, "0"c))
    End Function

    Private Function getMetricTime() As String
        '   Returns the current [local] time in Metric time.
        '   Metric time is the measure of time interval using the metric system, which defines the second as the base unit of time,
        '   and multiple and submultiple units formed with metric prefixes, such as kiloseconds and milliseconds.
        '   Only Kiloseconds are used here.

        Dim noOfSeconds As Integer = MilliSecondOfTheDay() / 1000

        Dim noOfK As Double = noOfSeconds / 1000

        getMetricTime = String.Format("{0:##.000} Kiloseconds", noOfK)
    End Function

    Private Function getUnixTime() As String
        '   Returns UTC in Unix time.
        '   Unix time, or POSIX time, is a system for describing instants in time, defined as the number of seconds
        '   elapsed since midnight Coordinated Universal Time (UTC) of Thursday, January 1, 1970

        Dim tday As Date = Now.ToUniversalTime()
        Dim epoc As Date = #1/1/1970#
        Dim secs As Integer = tday.Subtract(epoc).TotalSeconds

        getUnixTime = String.Format("{0}", secs)
    End Function

    Private Function getRomanTime() As String
        '   Returns the current [local] time in Roman numerals.

        Dim hours As Integer = Now().Hour
        Dim mins As Integer = Now().Minute
        Dim secs As Integer = Now().Second

        getRomanTime = String.Format("{0} {1} {2}", Me.toRoman(hours), Me.toRoman(mins), Me.toRoman(secs))
    End Function

    Private Function toRoman(time As Integer) As String
        '   given an input integer, returns the Roman numeral equivalent.
        '   NB : only number 0 -> 60.
        '   This maybe could be written better!!!!

        Dim result As String = ""

        Do
            Select Case time
                Case 50 To 60
                    result = result & "L"
                    time = (time - 50)
                Case 40 To 49
                    result = result & "XL"
                    time = (time - 40)
                Case 10 To 39
                    result = result & "X"
                    time = (time - 10)
                Case Is = 9
                    result = result & "IX"
                    time = (time - 9)
                Case 5 To 8
                    result = result & "V"
                    time = (time - 5)
                Case Is = 4
                    result = result & "IV"
                    time = (time - 4)
                Case 1 To 3
                    result = result & "I"
                    time = (time - 1)
            End Select
        Loop Until time < 1

        toRoman = result
    End Function

    Private Function getCodeTime(code As String) As String
        '   Returns the current [local] time with each digit represented by a different encoding.
        '   code = "MORSE"   - returns time in morse code.
        '   code = "BRAILLE" - returns time in braille.

        Dim hours As Integer = Now().Hour
        Dim mins As Integer = Now().Minute
        Dim secs As Integer = Now().Second

        Dim codeHours As String = ""
        Dim codeMins As String = ""
        Dim codeSecs As String = ""

        If hours < 9 Then
            codeHours = toCode(hours, code)
        Else
            codeHours = String.Format("{0} {1}", toCode(Int(hours / 10), code), toCode(hours Mod 10, code))
        End If

        If mins < 9 Then
            codeMins = toCode(mins, code)
        Else
            codeMins = String.Format("{0} {1}", toCode(Int(mins / 10), code), toCode(mins Mod 10, code))
        End If

        If secs < 9 Then
            codeSecs = toCode(secs, code)
        Else
            codeSecs = String.Format("{0} {1}", toCode(Int(secs / 10), code), toCode(secs Mod 10, code))
        End If

        getCodeTime = String.Format("{0}  {1}  {2} ", codeHours, codeMins, codeSecs)
    End Function

    Private Function toCode(time As String, code As String) As String
        '   code = "MORSE"   - returns string in morse code.
        '   code = "BRAILLE" - returns string in braille.

        Dim result As String = ""

        Select Case time
            Case 1
                result = IIf(code = MORSE, "·----", ChrW(10241))
            Case 2
                result = IIf(code = MORSE, "··---", ChrW(10243))
            Case 3
                result = IIf(code = MORSE, "···--", ChrW(10249))
            Case 4
                result = IIf(code = MORSE, "····-", ChrW(10265))
            Case 5
                result = IIf(code = MORSE, "·····", ChrW(10257))
            Case 6
                result = IIf(code = MORSE, "-····", ChrW(10251))
            Case 7
                result = IIf(code = MORSE, "--···", ChrW(10267))
            Case 8
                result = IIf(code = MORSE, "---··", ChrW(10259))
            Case 9
                result = IIf(code = MORSE, "----·", ChrW(10250))
            Case 0
                result = IIf(code = MORSE, "-----", ChrW(10266))
        End Select

        toCode = result

    End Function

    Private Function getMarsSolDate()
        '   Returns the current [UTC] time as Mars Sol Date - as http://jtauber.github.io/mars-clock/
        '   Strange :: DateDiff seems to use American dates and not English [unlike my computer and me].

        Dim noOfDays As Double = DateDiff(DateInterval.Second, #1/6/2000#, Now.ToUniversalTime) / 86400

        getMarsSolDate = String.Format("{0:##.00000}", (((noOfDays) / 1.027491252) + 44796.0 - 0.00096))
    End Function

    Private Function getCoordinatedMarsTime()
        '   Returns the current [UTC] time as Coordinated Mars Time - as http://jtauber.github.io/mars-clock/
        '   Strange :: DateDiff seems to use American dates and not English [unlike my computer and me].

        Dim marsSolDate As Double = DateDiff(DateInterval.Second, #1/6/2000#, Now.ToUniversalTime) / 86400

        marsSolDate = (marsSolDate / 1.027491252) + 44796.0 - 0.00096

        Dim mtc As Double = (24 * marsSolDate) Mod 24

        Dim hour As Integer = Int(mtc)
        Dim min As Double = (mtc - hour) * 60
        Dim secs As Integer = (min - Int(min)) * 60

        getCoordinatedMarsTime = String.Format("{0:00}:{1:00}:{2:00}", hour, min, secs)
    End Function

    Private Function getPercentTime()
        '   Returns the current [local] time as a percent of the day.
        '   See http://raywinstead.com/metricclock.shtml

        Dim noOfSeconds As Integer = MilliSecondOfTheDay() / 1000
        Dim percentSeconds As Double = noOfSeconds / 86400 * 100

        getPercentTime = String.Format("{0:0#.0000 PMH}", percentSeconds)
    End Function

    Private Function getFlowTime()
        '   Returns the current [local] time as Flow Time.
        '   Flow Time still divides the day into 24 hours, but each hour is divided into 100 minutes of 100 seconds.
        '   A Quick conversion is takes 2/3 of the minute [or second] and add it to it's self.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute * (5 / 3)
        Dim secs As Integer = Now.Second * (5 / 3)

        getFlowTime = String.Format("{0:00}:{1:00}:{2:00}", hour, mins, secs)
    End Function

    Private Function MilliSecondOfTheDay() As Integer
        '   Returns the total number of milliseconds since midnight.

        Dim ts As New TimeSpan(0, Now.Hour, Now.Minute, Now.Second, Now.Millisecond)

        MilliSecondOfTheDay = ts.TotalMilliseconds

    End Function

End Class
