Imports System.Environment
Imports System.IO

Public Class Logger
    '   A Simple logging class.
    '
    '   provides two methods, one function and Three options.
    '
    '   useLoggin - True of false - is logging in use.
    '   logDaysKeep - The number of days to keep log files.  Default is 10.
    '   logFilepath - A place to keep the log files.  Default is in the data folder of the application and the filename is made up of the date.
    '
    '   logMessage() - Add a simple message to the logfile in the form of location, text
    '   LogExceptionErro() - Add an entry to the log file for an exception in the form of location, exception.
    '
    '   poolLogs() - returns a arraylist of all log files in the logFilepath directory.
    '                Deletes all log files that are over logDaysKeep days old.



    Private _useLogging As Boolean = True
    Private _logdaysKeep As Integer = 10

    Private _logFilePath As String = System.IO.Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "log_" & DateTime.Now.ToString("ddMMyyyy") & ".log")

    '--------------------------------------------------------------------------------------------------- Properties ------------

    Public Property useLogging() As Boolean
        Get
            Return _useLogging
        End Get
        Set(ByVal value As Boolean)
            _useLogging = value
        End Set
    End Property

    Public Property logdaysKeep() As Integer
        Get
            Return _logdaysKeep
        End Get
        Set(ByVal value As Integer)
            _logdaysKeep = value
        End Set
    End Property

    Public Property logFilePath() As String
        Get
            Return _logFilePath
        End Get
        Set(ByVal value As String)
            _logFilePath = value
        End Set
    End Property

    Public Sub New()

        MyBase.New()
    End Sub

    '--------------------------------------------------------------------------------------------------- Logging methods ------------

    Public Sub logMessage(location As String, m As String)
        '   Add a simple message to the logfile in the form of location, text
        '   Adds the current date and time to the beginning of the entry.

        Dim lgDate As String = String.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
        Dim procID As String = Process.GetCurrentProcess.Id.ToString()

        writeMessage(String.Format("{0} : {1} : {2} : {3}", procID, lgDate, location, m))
    End Sub


    Public Sub LogExceptionError(location As String, ex As Exception)
        '   Add an entry to the log file for an exception in the form of location, exception.
        '   Adds the current date and time to the beginning of the entry.

        Dim message As String = String.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
        Dim procID As String = Process.GetCurrentProcess.Id.ToString()

        message += Environment.NewLine
        message += "-----------------------------------------------------------"
        message += Environment.NewLine
        message += String.Format("Process ID : {0}{1}", procID, Environment.NewLine)
        message += String.Format("Location   : {0}{1}", location, Environment.NewLine)
        message += String.Format("Message    : {0}{1}", ex.Message, Environment.NewLine)
        message += String.Format("StackTrace : {0}{1}", ex.StackTrace, Environment.NewLine)
        message += String.Format("Source     : {0}{1}", ex.Source, Environment.NewLine)
        message += String.Format("TargetSite : {0}{1}", ex.TargetSite.ToString(), Environment.NewLine)
        message += "-----------------------------------------------------------"
        message += Environment.NewLine

        writeMessage(message)

    End Sub

    Public Function poolLogs() As List(Of String)
        '   returns a arraylist of all log files in the logFilepath directory.
        '   Deletes all log files that are over logDaysKeep days old.


        Dim rtnList As New List(Of String)()

        For Each file As String In My.Computer.FileSystem.GetFiles(Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "klock"))

            If file.EndsWith(".log") And My.Computer.FileSystem.FileExists(file) Then

                Try
                    Dim information As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(file)
                    Dim fdate As Date = information.CreationTime

                    If Now.Subtract(fdate).TotalDays < logdaysKeep() Then       '   if file is younger then permitted
                        rtnList.Add(file)                                       '   add file to list.
                    Else                                                        '   else
                        If frmKlock.usrSettings.usrLogging Then logMessage("Logger.poolLogs", "Deleting log file : " & file)
                        My.Computer.FileSystem.DeleteFile(file)                 '   delete file. 
                    End If
                Catch ex As Exception
                    LogExceptionError("Logger.poolLogs()", ex)
                End Try
            End If
        Next

        Return rtnList
    End Function


    Private Sub writeMessage(m As String)
        '   A private sub that actually writes to the file.
        '   A new file will be created if not present.
        '   Therefore a new file should be created each day, if the date is in the filename.

        Dim path As String = logFilePath()

        Try
            Using writer As New StreamWriter(path, True)
                writer.WriteLine(m)
                writer.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
