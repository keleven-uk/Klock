Public Class Voice
    '   A wrapper class arouunf SAPI - Microsoft's Speach API.

    '    When the class in created, the SPAI object is created, is successfull voice.actice will return Truw, if failed it return false.
    '   To produce speach, just pass a string to Voice.say


    Dim SAPI

    Public displayAction As selectAction

    Private _active As Boolean          '   holds if voice is active.


    Sub New()
        '   Created a new instance on the voice.
        '   This tries to creats a SPAI objects.  _active is set accordingly.

        MyBase.New()

        displayAction = New selectAction        '   used to display error messages, if created.

        Try
            SAPI = CreateObject("SAPI.spvoice")
            _active = True

        Catch ex As Exception                   '   something has gone wrong, display error and set active to false.
            Me.displayAction.DisplayReminder("Voice Error :: Error with SAPI", ex.Message)
            _active = False

        End Try
    End Sub



    Public Property Active() As Boolean
        '   Returns True if the voice is active i.e. created succesfully.  Returns false otherwise.
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property

    Public Sub Say(ByVal s As String)
        '   Useses the SAPI engine to speak the string s.

        If Me.Active Then SAPI.Speak(s)
    End Sub
End Class
