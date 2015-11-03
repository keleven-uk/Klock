Imports System.IO
Imports System.Reflection

Module HelpCommon
    '   A generic way of calling the Help form.

    '   The license used is the GNU General Public License V3.
    '   The history is the output of git log --stat [cleaned up]
    '   The licence.txt & history.txt are held has a embedded resource and read using a stream, see http://support.microsoft.com/kb/319291


    Sub displayInfo(ByVal mode As String)

        frmKlock.HlpPrvdrKlock.HelpNamespace = System.IO.Path.Combine(Application.StartupPath, "klock.chm") '   set up help location

        Select Case mode
            Case "Hel&p", "Help", "System.Windows.Forms.Button, Text: Help"
                Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
            Case "&License"
                frmLicence.Text = "License Info"
                loadStream("Klock.License.txt")
                frmLicence.ShowDialog()
            Case "&History"
                frmLicence.Text = "Klock History"
                loadStream("Klock.history.txt")
                frmLicence.ShowDialog()
            Case "&About"
                frmAbout.ShowDialog()
        End Select

    End Sub

    Sub loadStream(ByVal stream As String)

        Dim _textStreamReader As StreamReader
        Dim _assembly As [Assembly]

        If frmLicence.RchTxtBxLicense.Lines.Count = 0 Then        '   only load text on first load

            Try
                _assembly = [Assembly].GetExecutingAssembly()
                _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream(stream))

                Try
                    Do
                        frmLicence.RchTxtBxLicense.AppendText(_textStreamReader.ReadLine() & Environment.NewLine)
                    Loop Until _textStreamReader.Peek() = True
                Catch ex As Exception
                    MessageBox.Show("Error reading stream!" & ex.Message, "Error")
                End Try

            Catch ex As Exception
                MessageBox.Show("Resource wasn't found!" & ex.Message, "Error")
            End Try

        End If
    End Sub

End Module
