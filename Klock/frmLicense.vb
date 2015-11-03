Imports System.IO
Imports System.Reflection

Public Class frmLicence

    '   Displays an Licence screen.       K. Scott    November 2012.

    '   The license used is the GNU General Public License V3.

    '   The licence.txt is held has a embedded resource and read using a stream in the form load.
    '   see http://support.microsoft.com/kb/319291



    Private Sub btnLecenseClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLecenseClose.Click
        Me.RchTxtBxLicense.Clear()
        Me.Close()
    End Sub

End Class