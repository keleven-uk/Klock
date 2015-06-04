Public Class Timer
    '   A wrapper class for the native stopwatch class.
    '
    '   Three procedures are exposed to start, stop and clear the stopwatch.
    '   Two [read only] properties are exposed to read the elapsed time.
    '       getHighElapsedTime, returns the elapsed time to the milliseconds - HH:MM:SS:MS
    '       hetLowElapsedTime, returns the elapsed time to the second - HH:MM:SS



    Private stopWatch As New Stopwatch()

    Public ReadOnly Property getHighElapsedTime() As String
        '   Returns the elapsed time to the milliseconds - HH:MM:SS:MS
        Get
            Dim ts As TimeSpan = stopWatch.Elapsed
            Return String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds)
        End Get
    End Property

    Public ReadOnly Property getLowElapsedTime() As String
        '   Returns the elapsed time to the second - HH:MM:SS
        Get
            Dim ts As TimeSpan = stopWatch.Elapsed
            Return String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds)
        End Get
    End Property

    Public Sub startStopWatch()
        '   Starts or restart the stopwatch

        stopWatch.Start()
    End Sub

    Public Sub stopStopWatch()
        '   Stops the stopwatch

        stopWatch.Stop()
    End Sub

    Public Sub clearStopWatch()
        '   Clears the stopwatch

        stopWatch.Reset()
    End Sub

End Class


