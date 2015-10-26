Public Class UserFonts
    '   tries to pick the correct font width for a given string.

    Public TEXT_WIDTH1 As Single = 400          '   the width bands to determine which font [below] to use - time labels.
    Public TEXT_WIDTH2 As Single = 500          '
    Public TEXT_WIDTH3 As Single = 580          '

    Dim txtLrgFont As New Font("Lucida Calligraphy", 17, FontStyle.Regular)     '   large font.
    Dim txtBigFont As New Font("Lucida Calligraphy", 16, FontStyle.Regular)     '   big font.
    Dim txtSmlFont As New Font("Lucida Calligraphy", 15, FontStyle.Regular)     '   small font.
    Dim txtTnyFont As New Font("Lucida Calligraphy", 14, FontStyle.Regular)     '   tiny font.

    Dim pfc As New System.Drawing.Text.PrivateFontCollection()

    Public Sub New()
        '   at start, load the required fonts.

        MyBase.New()

        Try
            pfc.AddFontFile(System.IO.Path.Combine(Application.StartupPath, "fonts\Semaphore.ttf"))
            pfc.AddFontFile(System.IO.Path.Combine(Application.StartupPath, "fonts\NancyBlackett.ttf"))
            pfc.AddFontFile(System.IO.Path.Combine(Application.StartupPath, "fonts\BrailleLatin.ttf"))
            pfc.AddFontFile(System.IO.Path.Combine(Application.StartupPath, "fonts\BarCode39.ttf"))
        Catch ex As Exception
            frmKlock.displayAction.DisplayReminder("Font ERROR :: cannot find font file", ex.Message)
        End Try
    End Sub

    Public Function getFont(tmStr As String, mode As String, g As Graphics) As Font
        '   tries to match the width to the string.
        '   if mode is one listed, return the matching font.

        Dim rtnFont As Font = txtBigFont

        If mode = "Time as Semaphore" Then
            rtnFont = New Font(pfc.Families(3), 24, FontStyle.Regular)
        ElseIf mode = "Time as Nancy Blackett Semaphore" Then
            rtnFont = New Font(pfc.Families(2), 24, FontStyle.Regular)
        ElseIf mode = "Time as Braille" Then
            rtnFont = New Font(pfc.Families(1), 26, FontStyle.Regular)
        ElseIf mode = "Time in a Barcode" Then
            rtnFont = New Font(pfc.Families(0), 26, FontStyle.Regular)
        Else                                                                '   text is either time in words or a remionder countdown text.
            Dim textSize = g.MeasureString(tmStr, txtBigFont)

            Select Case textSize.Width
                Case TEXT_WIDTH1 To TEXT_WIDTH2             '   400 to 500
                    rtnFont = txtBigFont
                Case TEXT_WIDTH2 To TEXT_WIDTH3             '   500 to 580
                    rtnFont = txtSmlFont
                Case Is > TEXT_WIDTH3                       '   > 580
                    rtnFont = txtTnyFont
                Case Else                                   '   < 400
                    rtnFont = txtLrgFont
            End Select
        End If

        Return rtnFont
    End Function

End Class
