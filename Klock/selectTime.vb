Public Class selectTime
    '   A class wich allows the cuurent time to be displayes in various formats.
    '   The formats are held in the enum TimeTypes, these are exported.

    '   TimeType is set to the desired time format [from TimeTypes]
    '   getTime is then called and this will return the current time is the desired time format.


    Enum TimeTypes                  '   types of time format available :: new ones add in here.
        FuzzyTime
        LocalTime
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

    Private Function getNetTime() As String

        Dim totalMilliseconds = DateTime.Now.Millisecond


        Dim deg As Int64 = 0
        Dim min As Integer = 0
        Dim sec As Integer = 0

        deg = 0


        'min = ((Now.Millisecond) - (deg * 240000)) \ 4000
        'sec = ((Now.Millisecond) - (deg * 240000) - (min * 4)) * 15

        getNetTime = String.Format("{0} deg {1} min {2} sec", totalMilliseconds, min, sec)

    End Function

End Class
