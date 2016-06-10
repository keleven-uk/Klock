
'   A Sticky Note class
'   Holds the date for a single sticky note.

'   the <Serializable()> bit, allows it to be stored easily in a binary file.


Imports System.Net.Mime.MediaTypeNames

<Serializable()> Public Class stickyNote
    Private _body As String
    Private _header As String
    Private _height As Integer

    Private _id As Long
    Private _left As Integer
    Private _top As Integer
    Private _width As Integer

    Public Sub New()

        MyBase.New()
    End Sub

    Public Property noteBody() As String
        Get
            Return _body
        End Get
        Set(ByVal value As String)
            _body = value
        End Set
    End Property

    Public Property noteheader() As String
        Get
            Return _header
        End Get
        Set(ByVal value As String)
            _header = value
        End Set
    End Property

    Public Property noteHeight() As Integer
        Get
            Return _height
        End Get
        Set(ByVal value As Integer)
            _height = value
        End Set
    End Property

    Public Property noteID() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property

    Public Property noteLeft() As Integer
        Get
            Return _left
        End Get
        Set(ByVal value As Integer)
            _left = value
        End Set
    End Property

    Public Property noteTop() As Integer
        Get
            Return _top
        End Get
        Set(ByVal value As Integer)
            _top = value
        End Set
    End Property

    Public Property noteWidth() As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property
End Class
