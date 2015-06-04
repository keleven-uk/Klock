Imports System.Globalization

<Serializable()> Public Class Events
    ' 

    Enum EventTypes
        Birthdays
        Anniversaries
        Holidays
        Motor
        Appointment
        Meeting
        OneOffEvent
        Other
    End Enum

    Enum Eventsperiods
        Yearly
        Monthly
        Weekly
    End Enum



    ' Creates a TextInfo based on the "en-GB" culture.
    Private myTI As TextInfo = New CultureInfo("en-GB", False).TextInfo

    Private _eName As String
    Private _eType As Integer
    Private _eDate As String
    Private _eTime As String
    Private _eRecuring As Boolean
    Private _ePeriod As Integer
    Private _eNotes As String

    Public Overrides Function ToString() As String

        Dim first As String = Me.Eventname().PadRight(14, " ")
        Dim second As String = Me.EventDate().PadRight(10, " ")

        Return String.Format("{0}{1}", first, second)

    End Function


    Public Property EventName() As String
        Get
            Return _eName
        End Get
        Set(ByVal value As String)
            _eName = Trim(myTI.ToTitleCase(value))
        End Set
    End Property

    Public Property EventType() As Integer
        Get
            Return _eType
        End Get
        Set(ByVal value As Integer)
            _eType = value
        End Set
    End Property

    Public Property EventDate() As String
        Get
            Return _eDate
        End Get
        Set(ByVal value As String)
            _eDate = value
        End Set
    End Property

    Public Property EventTime() As String
        Get
            Return _eTime
        End Get
        Set(ByVal value As String)
            _eTime = value
        End Set
    End Property

    Public Property EventRecuring() As Boolean
        Get
            Return _eRecuring
        End Get
        Set(ByVal value As Boolean)
            _eRecuring = value
        End Set
    End Property

    Public Property EventPeriod() As Integer
        Get
            Return _ePeriod
        End Get
        Set(ByVal value As Integer)
            _ePeriod = value
        End Set
    End Property

    Public Property EventNotes() As String
        Get
            Return _eNotes
        End Get
        Set(ByVal value As String)
            _eNotes = value
        End Set
    End Property
End Class
