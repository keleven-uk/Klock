Imports System.Globalization

<Serializable()> Public Class Memo


    Private _memoName As String
    Private _memoText As String
    Private _memoSecret As Boolean
    Private _memoPassword As String


    Public Overrides Function ToString() As String

        Dim first As String = Me.memoName().PadRight(14, " ")

        Return String.Format("{0}", first)
    End Function

    Public Property memoName() As String
        Get
            Return _memoName
        End Get
        Set(ByVal value As String)
            _memoName = value
        End Set
    End Property

    Public Property memoText() As String
        Get
            Return _memoText
        End Get
        Set(ByVal value As String)
            _memoText = value
        End Set
    End Property

    Public Property memoSecret() As Boolean
        Get
            Return _memoSecret
        End Get
        Set(ByVal value As Boolean)
            _memoSecret = value
        End Set
    End Property

    Public Property memoPassword() As String
        Get
            Return _memoPassword
        End Get
        Set(ByVal value As String)
            _memoPassword = value
        End Set
    End Property

End Class
