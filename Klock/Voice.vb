Public Class Voice
    '   A wrapper class around SAPI - Microsoft's speech API.

    '    When the class in created, the SPAI object is created, is successful voice.active will return True, if failed it return false.
    '   To produce speech, just pass a string to Voice.say


    Dim SAPI

    Public displayAction As selectAction

    Private _active As Boolean          '   holds if voice is active.

    Sub New()
        '   Created a new instance on the voice.
        '   This tries to create a SPAI objects.  _active is set accordingly.

        MyBase.New()

        displayAction = New selectAction        '   used to display error messages, if created.

        Try
            SAPI = CreateObject("SAPI.spvoice")
            Active() = True

        Catch ex As Exception                   '   something has gone wrong, display error and set active to false.
            displayAction.DisplayReminder("Voice Error :: Error with SAPI", ex.Message)
            Active() = False
        End Try
    End Sub

    Public Property Active() As Boolean
        '   Returns True if the voice is active i.e. created successfully.  Returns false otherwise.
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property

    Public Sub Say(ByVal s As String)
        '   Uses's the SAPI engine to speak the string s.

        If Active Then SAPI.Speak(s)
    End Sub
End Class
