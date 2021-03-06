﻿Public Class frmSmallTextKlock
    '   Generates a small text screen which displays the current time from a seemingly random set of words.

    Dim drag As Boolean                     '   Global variables used to make the form drag-able.
    Dim mousex As Integer                   '
    Dim mousey As Integer                   '

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        '   Display the about form.

        HelpCommon.displayInfo(sender.ToString)
    End Sub

    Private Sub clearlabels(foreColour As Color, backColour As Color, offColour As Color)
        '   Clear all labels, in fact sets their colour to ListSlateGray.
        '   Set colour to LightGreen for labels that always on.

        Dim lbl As New Control

        pnlSmallKlock.BackColor = backColour

        For Each lbl In pnlSmallKlock.Controls     'if other then label appear on panel, then will have to check for this.
            lbl.ForeColor = offColour
        Next

        lblIT.ForeColor = foreColour
        lblIS.ForeColor = foreColour
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        '   Close both small text and the main klock form.

        If frmKlock.usrSettings.usrRememberKlockMode Then        '   if desired, start in small text klock next time.
            frmKlock.usrSettings.usrStartKlockMode = 2
        End If

        Close()
        frmKlock.Close()
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

    ' ------------------------------------------------------------------------------------------------- key down ----------------------------

    Private Sub frmTextKlock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        '   Processes key presses at form level, before passed to components.

        '   Pressing F1, will open klock's help.
        '   Pressing alt + F2, will open the options screen.
        '   Pressing alt + F3, will open the analogue klock.
        '   Pressing alt + F4, will open the small text klock.
        '   Pressing alt + F5, will open the big text klock.
        '   Pressing alt + F6, will open the binary klock.
        '   Pressing alt + F7, will close all child klock and return to main klock.
        '   Pressing alt + F8, will disable the monitor from going to sleep.
        '   Pressing alt + F9, will restore system settings for the monitor.
        '   Pressing alt + F10, will open the clipboard manager.
        '   Pressing alt + F12, will shown total number of friends.

        HotKeys(e, Me)              '   in KlockThings.vb
    End Sub

    ' ------------------------------------------------------------------------------------------------- form load ----------------------------

    Private Sub frmTextKlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '   when the form loads set some global variables, turn on timer And load arrays.

        If frmKlock.usrSettings.usrSmallKlockSavePosition Then
            Top = frmKlock.usrSettings.usrSmallKlockTop
            Left = frmKlock.usrSettings.usrSmallKlockLeft
        End If

        drag = False

        tmrTextKlock.Enabled = True

        setDisplay()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        '   Display the help file.

        Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click

        Close()
    End Sub

    Private Sub NewStickyNoteToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NewStickyNoteToolStripMenuItem.Click
        '   Create a new sticky note.

        newStickyNote()
    End Sub

    ' ------------------------------------------------------------------------------------------------------------------------- Context menu -----------------


    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        '   Load the options screen.

        frmOptions.tbCntrlOptions.SelectedIndex = 5
        frmOptions.ShowDialog()
    End Sub

    ' -------------------------------------------------------------------------------- procedures used to make form drag-able -----------------

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

    Private Sub ReturnToKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToKlockToolStripMenuItem.Click
        '   Close small text klock and return to the main klock form.

        Close()
    End Sub

    Private Sub setDisplay()
        '   Set the display to the current time in an appropriate colour.

        Dim foreColour As Color = frmKlock.usrSettings.usrSmallKlockForeColour
        Dim backColour As Color = frmKlock.usrSettings.usrSmallKlockBackColour
        Dim offColour As Color = frmKlock.usrSettings.usrSmallKlockOffColour

        clearlabels(foreColour, backColour, offColour)
        setTime(foreColour)
        updateStatusBar(foreColour, backColour)
    End Sub

    Private Sub setTime(foreColour As Color)
        '   returns the current [local] time as fuzzy time i.e. ten past three in the afternoon.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim nrms As Integer = mins - (mins Mod 5)           '   gets nearest five minutes.
        Dim ampm As String = String.Empty
        Dim sRtn As String = String.Empty

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
                sRtn = String.Empty
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
                sRtn = String.Empty
        End Select

        If nrms > 30 Then hour += 1

        '   generate output string according to the hour of the day.
        '   This looks more complicated then it should be, maybe separate if then's would be better and use exit sub's inside each.

        '   if the hour is 0 or 24 and no minutes - it must be midnight.
        '   if the hour is 12 and no minutes - it must be noon.

        '   if "pm" then afternoon, subtract 12 - only use 12 hour clock.

        If (hour = 12) And (sRtn = String.Empty) Then
            lblABOUT.ForeColor = foreColour
            lblNOON.ForeColor = foreColour
        ElseIf (hour = 0) And (sRtn = String.Empty) Then
            lblABOUT.ForeColor = foreColour
            lblMIDNIGHT.ForeColor = foreColour
        ElseIf (hour = 24) And (sRtn = String.Empty) Then
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

            If sRtn = String.Empty Then lblABOUT.ForeColor = foreColour

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

            If sRtn = String.Empty Then lblISH.ForeColor = foreColour
        End If
    End Sub

    Private Sub tmrTextKlock_Tick(sender As System.Object, e As System.EventArgs) Handles tmrTextKlock.Tick

        setDisplay()
    End Sub

    Private Sub updateStatusBar(foreColour As Color, backColour As Color)
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        '                                               if running on battery, change status info colour to red as a warning.

        StsStrpInfo.BackColor = backColour

        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = foreColour
            StsLblDate.ForeColor = foreColour
            StsLblKeys.ForeColor = foreColour
        Else
            stsLblTime.ForeColor = Color.Red
            StsLblDate.ForeColor = Color.Red
            StsLblKeys.ForeColor = Color.Red
        End If

        stsLblTime.Text = statusTime()
        StsLblDate.Text = Format(Now, "short Date")
        StsLblKeys.Text = statusInfo()

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.ForeColor = foreColour
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = "Idle Time :: " & KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If
    End Sub
End Class