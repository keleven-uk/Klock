Imports System.Globalization

'   An Event class.
'   Holds the data for an event and the functions to expose them.

'   the <Serializable()> bit, allows it to be stored easily in a binary file.
'   the tostring function allows it to be stored in a list-box.


'   An event can [has] to one of EventTypes.

<Serializable()> Public Class Events
    '

    Enum EventTypes
        Birthday
        Anniversary
        Holiday
        Motor
        Appointment
        Meeting
        OneOffEvent
        TODO
        Other
    End Enum

    Private _eName As String
    Private _eType As Integer
    Private _eDate As String
    Private _eNotes As String
    Private _eFirstReminder As Boolean
    Private _eSecondReminder As Boolean
    Private _eThirdReminder As Boolean


    Public Sub New()

        MyBase.New()
    End Sub

    Public Overrides Function ToString() As String

        Dim first As String = EventName().PadRight(14, " ")

        Return String.Format("{0:000} {1}", DaysToGo(), first)
    End Function

    Public Function DaysToGo() As Integer
        '   returns the interval to the event in days.

        Dim e As Date = EventDate

        Dim ed = e.Day
        Dim em = e.Month
        Dim ey = Now().Year

        If em < Now().Month Then ey += 1
        If em = Now().Month And ed < Now.Day Then ey += 1

        Dim dd As New Date(ey, em, ed)

        Dim d As Double = DateDiff(DateInterval.Day, Now(), dd) + 1

        Return d
    End Function

    Public Function NoOfYears() As Integer
        '   returns the number of years for the event - mainly used for Birthdays and Anniversaries.

        Dim e As Date = EventDate
        Dim dd As Double = 0
        Dim ey = e.Year

        If ey < Now().Year Then dd = DateDiff(DateInterval.Year, e, Now())

        Return dd
    End Function

    Public Property EventName() As String
        Get
            Return _eName
        End Get
        Set(ByVal value As String)
            _eName = value
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

    Public Property EventNotes() As String
        Get
            Return _eNotes
        End Get
        Set(ByVal value As String)
            _eNotes = value
        End Set
    End Property

    Public Property EventFirstReminder() As Boolean
        Get
            Return _eFirstReminder
        End Get
        Set(ByVal value As Boolean)
            _eFirstReminder = value
        End Set
    End Property

    Public Property EventSecondreminder() As Boolean
        Get
            Return _eSecondreminder
        End Get
        Set(ByVal value As Boolean)
            _eSecondreminder = value
        End Set
    End Property

    Public Property EventThirdReminder() As Boolean
        Get
            Return _eThirdReminder
        End Get
        Set(ByVal value As Boolean)
            _eThirdReminder = value
        End Set
    End Property

End Class
