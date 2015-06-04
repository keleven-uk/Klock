Imports System.IO
Imports System.Reflection

Public Class frmLicence

    '   Displays an Licence screen.       K. Scott    November 2012.

    '   The license used is the GNU General Public License V3.

    '   The licence.txt is held has a embeded resource and read using a stream in the form load.
    '   see http://support.microsoft.com/kb/319291

    Dim _textStreamReader As StreamReader
    Dim _assembly As [Assembly]

    Private Sub btnLecenseClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLecenseClose.Click
        Close()
    End Sub

    Private Sub frmLicence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If RchTxtBxLicense.Lines.Count = 0 Then        '   only load text on first load

            Try
                _assembly = [Assembly].GetExecutingAssembly()
                _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream("Klock.License.txt"))

                Try
                    Do
                        RchTxtBxLicense.AppendText(_textStreamReader.ReadLine() & Environment.NewLine)
                    Loop Until _textStreamReader.Peek() = True
                Catch ex As Exception
                    MessageBox.Show("Error reading stream!" & ex.Message, "Error")
                End Try

            Catch ex As Exception
                MessageBox.Show("Resource wasn't found!" & ex.Message, "Error")
            End Try

        End If

    End Sub

End Class