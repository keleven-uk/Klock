Imports System.Globalization


<Serializable()> Public Class clipItem
    Private _itemDateTime As String
    Private _itemText As String

    Private _itemType As String

    Public Sub New()

        MyBase.New()
    End Sub

    Public Property itemDateTime() As String
        Get
            Return _itemDateTime
        End Get
        Set(value As String)
            _itemDateTime = value
        End Set
    End Property

    Public Property itemText() As String
        Get
            Return _itemText
        End Get
        Set(value As String)
            _itemText = value
        End Set
    End Property

    Public Property itemType() As String
        Get
            Return _itemType
        End Get
        Set(value As String)
            _itemType = value
        End Set
    End Property

    Public ReadOnly Property itemTypeSize() As Integer
        Get
            Return 8
        End Get
    End Property

    Public Overrides Function toString() As String

        Dim first As String = itemType().PadRight(8, " ")
        Dim second As String = itemDateTime().PadRight(25, " ")
        Dim third As String = itemText()

        Return String.Format("{0}{1}{2}", first, second, third)
    End Function
End Class

