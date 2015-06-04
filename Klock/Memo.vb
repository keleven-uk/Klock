Imports System.Globalization

<Serializable()> Public Class Memo


    Private _memoName As String
    Private _memoText As String
    Private _memoSecret As String
    Private _memoPassword As String


    Public Overrides Function ToString() As String

        Dim first As String = Me.memoName().PadRight(14, " ")
        Dim second As String = Me.memoText().PadRight(10, " ")

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

    Public Property memoSecret() As String
        Get
            Return _memoSecret
        End Get
        Set(ByVal value As String)
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
