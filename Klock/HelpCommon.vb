Imports System.IO

Module HelpCommon
    '   A generic way of calling the Help form.

    '   The license used is the GNU General Public License V3.
    '   The history is the output of git log --stat [cleaned up]
    '   The licence.txt & history.txt are held has a embedded resource and read using a stream, see http://support.microsoft.com/kb/319291


    Public Sub displayInfo(ByVal mode As String)

        Select Case mode
            Case "Hel&p", "Help", "System.Windows.Forms.Button, Text: Help"
                Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
            Case "&License"
                frmHelp.Text = "License Info"
                loadtextFile("License.txt")
                frmHelp.ShowDialog()
            Case "&History"
                frmHelp.Text = "Klock History"
                loadtextFile("history.txt")
                frmHelp.ShowDialog()
            Case "&About"
                frmAbout.ShowDialog()
        End Select

    End Sub

    Private Sub loadtextFile(ByVal txtFle As String)
        '   Loads a named text file into the rich text box on frmHelp.

        Try
            Dim tfLines() As String = File.ReadAllLines(txtFle)             '   file to load

            For Each line As String In tfLines
                frmHelp.RchTxtBxLicense.AppendText(line & Environment.NewLine)
            Next

        Catch ex As Exception
            MessageBox.Show("File wasn't found!" & ex.Message, "Error")
        End Try
    End Sub
End Module
