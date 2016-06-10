'   A Memo class.
'   Holds the data for an event and the functions to expose them.

'   the <Serializable()> bit, allows it to be stored easily in a binary file.
'   the tostring function allows it to be stored in a list-box.

<Serializable()> Public Class Memo


    Private _memoName As String
    Private _memoPassword As String
    Private _memoSecret As Boolean
    Private _memoText As String

    Public Sub New()

        MyBase.New()
    End Sub

    Public Property memoName() As String
        Get
            Return _memoName
        End Get
        Set(ByVal value As String)
            _memoName = value
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

    Public Property memoSecret() As Boolean
        Get
            Return _memoSecret
        End Get
        Set(ByVal value As Boolean)
            _memoSecret = value
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

    Public Overrides Function ToString() As String

        Dim first As String = memoName().PadRight(14, " ")

        Return String.Format("{0}", first)
    End Function

End Class
