Public Class frmBinaryKlock

    '   Generates a small text screen which displays the current time from a seemingly random set of words.

    Dim drag As Boolean                     '   Global variables used to make the form drag-able.
    Dim mousex As Integer                   '
    Dim mousey As Integer                   '

    ' -------------------------------------------------------------------------------- procedures used to make form drag-able -----------------

    Private Sub PctrBxBinaryKlock_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, PctrBxBinaryKlock.MouseDown

        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub PctrBxBinaryKlock_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, PctrBxBinaryKlock.MouseMove

        If drag Then
            Top = Windows.Forms.Cursor.Position.Y - mousey
            Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub PctrBxBinaryKlock_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, PctrBxBinaryKlock.MouseUp

        drag = False
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

    Private Sub frmBinaryKlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   when the form loads set some global variables, turn on timer And load arrays.

        If frmKlock.usrSettings.usrBinaryKlockSavePosition Then
            Top = frmKlock.usrSettings.usrBinaryKlockTop
            Left = frmKlock.usrSettings.usrBinaryKlockLeft
        End If

        drag = False

        PctrBxBinaryKlock.BackColor = frmKlock.usrSettings.usrBinaryKlockBackColour

        tmrBinaryKlock.Enabled = True

        frmKlock.BinaryKlockToolStripMenuItem.Checked = True
    End Sub

    Private Sub frmBinaryKlock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '   When form is closed turn off timer and re-load main form.
        '   and save binary klock position if needed.

        If frmKlock.usrSettings.usrBinaryKlockSavePosition Then
            frmKlock.usrSettings.usrBinaryKlockTop = Top
            frmKlock.usrSettings.usrBinaryKlockLeft = Left
        End If

        tmrBinaryKlock.Enabled = False

        frmKlock.NtfyIcnKlock.Visible = False
        frmKlock.Visible = True

        frmKlock.BinaryKlockToolStripMenuItem.Checked = False
    End Sub

    Private Sub updateStatusBar(foreColour As Color, backColour As Color)
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        '    if running on battery, change status info colour to red as a warning.

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

    Private Sub tmrBinaryKlock_Tick(sender As Object, e As EventArgs) Handles tmrBinaryKlock.Tick
        '   on every second update things.

        Dim foreColour As Color = frmKlock.usrSettings.usrBinaryKlockForeColour
        Dim backColour As Color = frmKlock.usrSettings.usrBinaryKlockBackColour
        Dim offColour As Color = frmKlock.usrSettings.usrBinaryKlockOffColour

        updateStatusBar(foreColour, backColour)

        If frmKlock.usrSettings.usrBinaryUseBCD Then        '   depending upon option call BCD or true binary klock.
            bcdKlock(backColour, foreColour, offColour)
        Else
            binaryKlock(backColour, foreColour, offColour)
        End If
    End Sub


    Private Sub bcdKlock(backColour As Color, foreColour As Color, offColour As Color)
        '   Display a BCD klock.
        '   Each decimal number is converted into two binary strings, one for the tens and one for the units.
        '   A BCD pair is generated for hours, minutes and seconds by getBCDTime()
        '   An array if filled with getBCDTime.Split(":"), each slot is a binary string.

        '   The display is vertical.

        Dim timeArr() As String = getBCDTime.Split(":")

        Dim bcdYstart = 150
        Dim bcdSize = 35
        Dim bcdSpacing = 45
        Dim bcdX = 5
        Dim bcdY = bcdYstart

        Using bcdKlock As Graphics = PctrBxBinaryKlock.CreateGraphics()
            bcdKlock.Clear(backColour)
            For Each digit As String In timeArr
                bcdY = bcdYstart
                For Each bit As String In digit
                    If bit = "1" Then
                        Using brsh As SolidBrush = New SolidBrush(foreColour)
                            bcdKlock.FillEllipse(brsh, bcdX, bcdY, bcdSize, bcdSize)
                        End Using
                    Else
                        Using brsh As SolidBrush = New SolidBrush(offColour)
                            bcdKlock.FillEllipse(brsh, bcdX, bcdY, bcdSize, bcdSize)
                        End Using
                    End If
                    bcdY -= bcdSpacing
                Next
                bcdX += bcdSpacing
            Next
        End Using
    End Sub

    Private Sub binaryKlock(backColour As Color, foreColour As Color, offColour As Color)
        '   Display a True Binary klock.
        '   Each decimal number is converted into a binary string.
        '   A binary string is generated for hours, minutes and seconds by getbinaryTime()
        '   An array if filled with getbinaryTime.Split(":"), each slot is a binary string.

        '   The display is horizontal.

        Dim timeArr() As String = getbinaryTime.Split(":")

        Dim binarySize = 35
        Dim binarySpacing = 40
        Dim binaryX = 5
        Dim binaryY = 50

        Using binaryKlock As Graphics = PctrBxBinaryKlock.CreateGraphics()
            binaryKlock.Clear(backColour)
            For Each digit As String In timeArr
                binaryX = binarySpacing
                For Each bit As String In digit
                    If bit = "1" Then
                        Using brsh As SolidBrush = New SolidBrush(foreColour)
                            binaryKlock.FillEllipse(brsh, binaryX, binaryY, binarySize, binarySize)
                        End Using
                    Else
                        Using brsh As SolidBrush = New SolidBrush(offColour)
                            binaryKlock.FillEllipse(brsh, binaryX, binaryY, binarySize, binarySize)
                        End Using
                    End If
                    binaryX += binarySpacing
                Next
                binaryY += binarySpacing
            Next
        End Using
    End Sub

    Private Function getBCDTime() As String
        '   Returns current [local] time in Binary-Coded Decimal [base 2] format.
        '   This is only a binary representation of the current time.
        '   If below 9, still return a two bcd string i.e first digit is 0.
        '   NB \ is integer division.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim secs As Integer = Now.Second

        Dim codeHour As String = String.Format("{0}:{1}", Convert.ToString(hour \ 10, 2).PadLeft(2, "0"), Convert.ToString(hour Mod 10, 2).PadLeft(4, "0"))
        Dim codeMins As String = String.Format("{0}:{1}", Convert.ToString(mins \ 10, 2).PadLeft(3, "0"), Convert.ToString(mins Mod 10, 2).PadLeft(4, "0"))
        Dim codeSecs As String = String.Format("{0}:{1}", Convert.ToString(secs \ 10, 2).PadLeft(3, "0"), Convert.ToString(secs Mod 10, 2).PadLeft(4, "0"))

        Return String.Format("{0}:{1}:{2}", codeHour, codeMins, codeSecs)
    End Function

    Private Function getbinaryTime() As String
        '   Returns current [local] time in Binary [base 2] format.
        '   This is only a binary representation of the current time.
        '   NB \ is integer division.

        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim secs As Integer = Now.Second

        Dim codeHour As String = String.Format("{0}", Convert.ToString(hour, 2).PadLeft(6, "0"))
        Dim codeMins As String = String.Format("{0}", Convert.ToString(mins, 2).PadLeft(6, "0"))
        Dim codeSecs As String = String.Format("{0}", Convert.ToString(secs, 2).PadLeft(6, "0"))

        Return String.Format("{0}:{1}:{2}", codeHour, codeMins, codeSecs)
    End Function

    ' ------------------------------------------------------------------------------------------------------------------------- Context menu -----------------

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        '   Load the options screen.

        frmOptions.tbCntrlOptions.SelectedIndex = 6
        frmOptions.ShowDialog()
    End Sub

    Private Sub ReturnToKlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToKlockToolStripMenuItem.Click
        '   Close analogue klock and return to the main klock form.

        Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        '   Close both analogue and the main klock form.

        If frmKlock.usrSettings.usrRememberKlockMode Then        '   if desired, start in analogue klock next time.
            frmKlock.usrSettings.usrStartKlockMode = 4
        End If

        Close()
        frmKlock.Close()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        '   Display the help file.

        Help.ShowHelp(frmKlock, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        '   Display the about form.

        HelpCommon.displayInfo(sender.ToString)
    End Sub

    Private Sub PctrBxBinaryKlock_DoubleClick(sender As Object, e As EventArgs) Handles PctrBxBinaryKlock.DoubleClick
        '   A double click on the form [panel] calls close()

        Close()
    End Sub

    Private Sub NewStickyNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewStickyNoteToolStripMenuItem.Click
        '   Create a new sticky note.

        newStickyNote()
    End Sub

End Class