Imports System.IO
Imports System.Reflection

Public Class frmHelp
   
    '   Displays an Help screen.       K. Scott    November 2012

    '   The help.txt is held has a embedded resource and read using a stream in the form load.
    '   see http://support.microsoft.com/kb/319291

    Dim _textStreamReader As StreamReader
    Dim _assembly As [Assembly]

    Private Sub btnHelpClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelpClose.Click
        Me.Close()
    End Sub

    Private Sub frmHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.RchTxtBxHelp.Lines.Count = 0 Then        '   only load text on first load
            Try
                _assembly = [Assembly].GetExecutingAssembly()
                _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream("Klock.Help.txt"))

                Try
                    Do
                        Me.RchTxtBxHelp.AppendText(_textStreamReader.ReadLine() & Environment.NewLine)
                    Loop Until _textStreamReader.Peek() = True
                Catch ex As Exception
                    MessageBox.Show("Error reading stream!  " & ex.Message, "Error")
                End Try

            Catch ex As Exception
                MessageBox.Show("Resource wasn't found!  " & ex.Message, "Error")
            End Try

        End If
    End Sub
End Class