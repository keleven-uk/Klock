Public Class frmOptions

    '   Displays an Options screen.       K. Scott    November 2012

    '   The settings are saved using applications settings, automatically handeled bu
    '   the program.  A save is called when form is closed.

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   When opened, set settings

        setSettings()
    End Sub

    Sub setSettings()
        '   Apply the current settings.

        Me.BackColor = My.Settings.usrFormColour

        lblColour.Font = My.Settings.usrFormFont
        lblColour.ForeColor = My.Settings.usrFormFontColour

        lblFont.Font = My.Settings.usrFormFont
        lblFont.ForeColor = My.Settings.usrFormFontColour

        lblDefaultColour.Font = My.Settings.usrFormFont
        lblDefaultColour.ForeColor = My.Settings.usrFormFontColour

        ChckBxOptionsSavePos.Checked = My.Settings.usrSavePos
        ChckBxOptionsSavePos.Font = My.Settings.usrFormFont
        ChckBxOptionsSavePos.ForeColor = My.Settings.usrFormFontColour

        ChckBxTimerHigh.Checked = My.Settings.usrTimerHigh
        ChckBxClearSplit.Checked = My.Settings.usrTimerClearSplit

        TbPgGlobal.BackColor = My.Settings.usrFormColour
        TbPgCountDown.BackColor = My.Settings.usrFormColour
        TbPgTimer.BackColor = My.Settings.usrFormColour

    End Sub

    ' ************************************************************************************* global options *****************************

    Private Sub btnOptionsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsClose.Click
        '    When closed, save settings.

        My.Settings.usrSavePos = ChckBxOptionsSavePos.Checked
        My.Settings.Save()
        Close()
    End Sub



    Private Sub btnOptionsFormColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormColour.Click
        '   Set the form main colour.

        ClrDlgFormColour.Color = My.Settings.usrFormColour          '   current main form colour
        If ClrDlgFormColour.ShowDialog() = DialogResult.OK Then
            My.Settings.usrFormColour = ClrDlgFormColour.Color
            setSettings()
        End If
    End Sub

    Private Sub btnOptionsFormFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionsFormFont.Click
        '   Set the form main font.
        '   the font colour has to be handled seperately.

        FntDlgFont.Font  = My.Settings.usrFormFont                  '   current main form font
        FntDlgFont.Color = My.Settings.usrFormFontColour            '   current main form font colour
        
       If FntDlgFont.ShowDialog() = DialogResult.OK Then
            My.Settings.usrFormFont       = FntDlgFont.Font
            My.Settings.usrFormFontColour = FntDlgFont.Color
            setSettings()
        End If
    End Sub

    Private Sub ChckBxOptionsSavePos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxOptionsSavePos.CheckedChanged
        '   If option is checked, save form position.

        If ChckBxOptionsSavePos.Checked Then
            My.Settings.usrFormTop = Me.Top
            My.Settings.usrFormLeft = Me.Left
        End If
    End Sub

Private Sub btnDefaultColour_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnDefaultColour.Click
        '   reset all colours and font changes back to form defaults.

        My.Settings.usrFormColour = frmOptions.DefaultBackColor 
        My.Settings.usrFormFont = frmOptions.DefaultFont  
        My.Settings.usrFormFontColour = frmOptions.DefaultForeColor 

        setSettings()
End Sub

    ' ************************************************************************************* timer options *****************************

    Private Sub ChckBxTimerHigh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxTimerHigh.CheckedChanged
        If ChckBxTimerHigh.Checked Then
            My.Settings.usrTimerHigh = True
        Else
            My.Settings.usrTimerHigh = False
        End If
    End Sub

    Private Sub ChckBxClearSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckBxClearSplit.CheckedChanged
        If ChckBxClearSplit.Checked Then
            My.Settings.usrTimerClearSplit = True
        Else
            My.Settings.usrTimerClearSplit = False
        End If
    End Sub

End Class