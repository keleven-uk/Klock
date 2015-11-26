Imports System.IO
Imports System.Reflection

Public Class frmHelp

    '   Displays an Licence screen.       K. Scott    November 2012.

    '   The license used is the GNU General Public License V3.


    Private Sub btnLecenseClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLecenseClose.Click
        RchTxtBxLicense.Clear()
        Close()
    End Sub

End Class