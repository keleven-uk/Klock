Imports System.IO

Public Class selectAgent

    Const AGENT As String = "Agent"

    Private _agentActive As Boolean = False
    Private _agentList As New List(Of String)

    ' *************************************************************************************** constructor ***********************

    Sub New()
        MyBase.New()
        Me.agentActive = Me.loadAgents()
    End Sub

    Public Property agentActive() As Boolean
        ' will show weather agents are active and can be used.

        Get
            Return _agentActive
        End Get
        Set(ByVal value As Boolean)
            _agentActive = value
        End Set
    End Property

    Public ReadOnly Property agentList() As List(Of String)
        ' returns a list of installed agents, if any.

        Get
            Return _agentList
        End Get
    End Property

    Public ReadOnly Property agentNumber() As Integer
        ' returns the number of agents - the list count.

        Get
            Return _agentList.Count
        End Get
    End Property

    Public Function loadAgents() As Boolean

        Dim agentPath As String = "C:\Windows\msagent\chars"
        Dim fileNme As String = ""

        _agentList.Clear()

        If My.Computer.FileSystem.DirectoryExists(agentPath) Then
            For Each pathNme As String In Directory.GetFiles(agentPath, "*.acs", SearchOption.AllDirectories)
                fileNme = Path.GetFileNameWithoutExtension(pathNme)
                _agentList.Add(fileNme)
            Next
            loadAgents = True
        Else
            loadAgents = False
        End If
    End Function



    Public Function loadAgent(name As String) As Boolean

        Dim flag As Boolean = False

        Try
            frmKlock.AxCntrlAgnts.Characters.Load(AGENT, name & ".acs")
            flag = True
        Catch ex As Exception
            flag = False
        End Try

        loadAgent = flag
    End Function

    Public Sub closeAgent()
        '   Tries to unload the agent character, ignores any errors.

        Try
            frmKlock.AxCntrlAgnts.Characters.Unload(AGENT)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub doAction(s As String)

        Dim screenX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim screenY As Integer = My.Computer.Screen.WorkingArea.Height

        With (frmKlock.AxCntrlAgnts)

            .Characters(AGENT).Left = screenX - .Characters(AGENT).Width
            .Characters(AGENT).Top = screenY - .Characters(AGENT).Height

            .Characters(AGENT).Show(False)

            .Characters(AGENT).Play("Greet")
            .Characters(AGENT).Play("Announce")
            .Characters(AGENT).Speak(s)
            .Characters(AGENT).Play("Wave")

            .Characters(AGENT).Hide()
        End With
    End Sub

End Class
