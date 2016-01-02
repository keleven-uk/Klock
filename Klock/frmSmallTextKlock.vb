Public Class frmSmallTextKlock
    '   Generates a small text screen which displays the current time from a seemingly random set of words.

    Dim drag As Boolean                     '   Global variables used to make the form dragable.
    Dim mousex As Integer                   '
    Dim mousey As Integer                   '

    ' -------------------------------------------------------------------------------- procedures used to make form dragable -----------------

    Private Sub pnlSmallKlock_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, pnlSmallKlock.MouseDown

        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub pnlSmallKlock_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, pnlSmallKlock.MouseMove

        If drag Then
            Top = Windows.Forms.Cursor.Position.Y - mousey
            Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub pnlSmallKlock_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, pnlSmallKlock.MouseUp

        drag = False
    End Sub

    ' ------------------------------------------------------------------------------------------------- key down ----------------------------

    Private Sub frmTextKlock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        '   Processes key presses at form level, before passed to components.

        HotKeys(e)              '   in KlockThings.vb
    End Sub

    ' ------------------------------------------------------------------------------------------------- form load ----------------------------

    Private Sub frmTextKlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '   when the form loads set some global variables, turn on timer And load arrays.

        If frmKlock.usrSettings.usrSmallKlockSavePosition Then
            Top = frmKlock.usrSettings.usrSmallKlockTop
            Left = frmKlock.usrSettings.usrSmallKlockLeft
        End If

        drag = False

        StsStrpInfo.BackColor = frmKlock.usrSettings.usrSmallKlockBackColour
        stsLbIdkeTime.ForeColor = frmKlock.usrSettings.usrSmallKlockForeColour

        tmrTextKlock.Enabled = True

        setDisplay()
    End Sub

    Private Sub frmTextKlock_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If frmKlock.usrSettings.usrSmallKlockSavePosition Then
            frmKlock.usrSettings.usrSmallKlockTop = Top
            frmKlock.usrSettings.usrSmallKlockLeft = Left
        End If

        tmrTextKlock.Enabled = False

        frmKlock.NtfyIcnKlock.Visible = False
        frmKlock.Visible = True

        frmKlock.TextKlockToolStripMenuItem.Checked = False
    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click

        Close()
    End Sub

    Private Sub tmrTextKlock_Tick(sender As System.Object, e As System.EventArgs) Handles tmrTextKlock.Tick

        setDisplay()
    End Sub

    Private Sub setDisplay()
        '   Set the display to the current time in an appropriate colour.

        Dim foreColour As Color = frmKlock.usrSettings.usrSmallKlockForeColour
        Dim backColour As Color = frmKlock.usrSettings.usrSmallKlockBackColour
        Dim offColour As Color = frmKlock.usrSettings.usrSmallKlockOffColour

        clearlabels(foreColour, backColour, offColour)
        setTime(foreColour)
        updateStatusBar(foreColour)
    End Sub

    Private Sub updateStatusBar(foreColour As Color)
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns off"

        '                                               if running on battery, change status info colour to red as a warning.
        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = foreColour
            StsLblDate.ForeColor = foreColour
            StsLblKeys.ForeColor = foreColour
        Else
            stsLblTime.ForeColor = Color.Red
            StsLblDate.ForeColor = Color.Red
            StsLblKeys.ForeColor = Color.Red
        End If

        If My.Computer.Keyboard.CapsLock.ToString() Then strKey = Replace(strKey, "c", "C")
        If My.Computer.Keyboard.NumLock.ToString() Then strKey = Replace(strKey, "n", "N")
        If My.Computer.Keyboard.ScrollLock.ToString() Then strKey = Replace(strKey, "s", "S")
        If KlockThings.HaveInternetConnection() Then strKey = Replace(strKey, "off", "ON")

        If frmKlock.usrSettings.usrTimeSystem24Hour Then
            stsLblTime.Text = String.Format("{0:HH:mm:ss}", System.DateTime.Now)
        Else
            stsLblTime.Text = String.Format("{0:hh:mm:ss tt}", System.DateTime.Now)
        End If

        '   Me.stsLblTime.Text = Format(Now, "Long Time")
        StsLblDate.Text = Format(Now, "short Date")
        StsLblKeys.Text = strKey

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If
    End Sub

    Private Sub clearlabels(foreColour As Color, backColour As Color, offColour As Color)
        '   Clear all labels, in fact sets their colour to ListSlateGray.
        '   Set colour to LightGreen for labels that always on.

        Dim lbl As New Control

        pnlSmallKlock.BackColor = backColour

        For Each lbl In pnlSmallKlock.Controls     'if other then label appear on panel, then will have to check for this.
            'If (lbl.GetType() Is GetType(Label)) Then
            'lbl.Enabled = False
            lbl.ForeColor = offColour
            'End If
        Next

        lblIT.ForeColor = foreColour
        lblIS.ForeColor = foreColour
    End Sub

    Private Sub setTime(foreColour As Color)
        '   returns the current [local] time as fuzzy time i.e. ten past three in the afternoon.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim nrms As Integer = mins - (mins Mod 5)           '   gets nearest five minutes.
        Dim ampm As String = ""
        Dim sRtn As String = ""

        If hour < 12 Then                                   '   if hour less then 12, in the morning else afternoon
            ampm = "in the morning"
            lblIN.ForeColor = foreColour
            lblTHE.ForeColor = foreColour
            lblMORNING.ForeColor = foreColour
        Else
            ampm = "pm"
        End If

        If (mins Mod 5) > 2 Then nrms += 5                  '   closer to next five minutes, go to next.

        Select Case nrms
            Case 0
                sRtn = ""
            Case 5
                sRtn = "five past"
                lblFIVEto.ForeColor = foreColour
                lblPAST.ForeColor = foreColour
            Case 10
                sRtn = "ten past"
                lblTENto.ForeColor = foreColour
                lblPAST.ForeColor = foreColour
            Case 15
                sRtn = "quarter past"
                lblQUARTER.ForeColor = foreColour
                lblPAST.ForeColor = foreColour
            Case 20
                sRtn = "twenty past"
                lblTWENTY.ForeColor = foreColour
                lblPAST.ForeColor = foreColour
            Case 25
                sRtn = "twenty-five past"
                lblTWENTY.ForeColor = foreColour
                lblFIVEto.ForeColor = foreColour
                lblPAST.ForeColor = foreColour
            Case 30
                sRtn = "half past"
                lblHALF.ForeColor = foreColour
                lblPAST.ForeColor = foreColour
            Case 35
                sRtn = "twenty-five to"
                lblTWENTY.ForeColor = foreColour
                lblFIVEto.ForeColor = foreColour
                lblTO.ForeColor = foreColour
            Case 40
                sRtn = "twenty to"
                lblTWENTY.ForeColor = foreColour
                lblTO.ForeColor = foreColour
            Case 45
                sRtn = "quarter to"
                lblQUARTER.ForeColor = foreColour
                lblTO.ForeColor = foreColour
            Case 50
                sRtn = "ten to"
                lblTENto.ForeColor = foreColour
                lblTO.ForeColor = foreColour
            Case 55
                sRtn = "five to"
                lblFIVEto.ForeColor = foreColour
                lblTO.ForeColor = foreColour
            Case 60
                sRtn = ""
        End Select

        If nrms > 30 Then hour += 1

        '   generate output string according to the hour of the day.
        '   This looks more complicated then it should be, maybe separate if then's would be better and use exit sub's inside each.

        '   if the hour is 0 or 24 and no minutes - it must be midnight.
        '   if the hour is 12 and no minutes - it must be noon.

        '   if "pm" then afternoon, subtract 12 - only use 12 hour clock.

        If (hour = 12) And (sRtn = "") Then
            lblABOUT.ForeColor = foreColour
            lblNOON.ForeColor = foreColour
        ElseIf (hour = 0) And (sRtn = "") Then
            lblABOUT.ForeColor = foreColour
            lblMIDNIGHT.ForeColor = foreColour
        ElseIf (hour = 24) And (sRtn = "") Then
            lblABOUT.ForeColor = foreColour
            lblMIDNIGHT.ForeColor = foreColour
        Else
            If ampm = "pm" Then
                hour -= 12
                lblIN.ForeColor = foreColour
                lblTHE.ForeColor = foreColour
                If hour >= 5 Then                               '   if greater then five in the afternoon then evening.
                    ampm = "in the evening"
                    lblEVENING.ForeColor = foreColour
                Else
                    ampm = "in the afternoon"
                    lblAFTER.ForeColor = foreColour
                    lblNOON.ForeColor = foreColour
                End If
            End If

            If sRtn = "" Then lblABOUT.ForeColor = foreColour

            Select Case hour
                Case 0
                    lblTWELVE.ForeColor = foreColour
                Case 1
                    lblONE.ForeColor = foreColour
                Case 2
                    lblTWO.ForeColor = foreColour
                Case 3
                    lblTHREE.ForeColor = foreColour
                Case 4
                    lblFOUR.ForeColor = foreColour
                Case 5
                    lblFIVE.ForeColor = foreColour
                Case 6
                    lblSIX.ForeColor = foreColour
                Case 7
                    lblSEVEN.ForeColor = foreColour
                Case 8
                    lblEIGHT.ForeColor = foreColour
                Case 9
                    lblNINE.ForeColor = foreColour
                Case 10
                    lblTEN.ForeColor = foreColour
                Case 11
                    lblELEVEN.ForeColor = foreColour
                Case 12
                    lblTWELVE.ForeColor = foreColour
                Case Else

            End Select

            If sRtn = "" Then lblISH.ForeColor = foreColour
        End If
    End Sub




End Class