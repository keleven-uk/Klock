Public Class frmTextKlock

    Private Sub frmTextKlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        clearlabels()
        getFuzzyTime()

        lblIT.Enabled = True
        lblIS.Enabled = True

        tmrTextKlock.Enabled = True

        updateStatusBar()
    End Sub

    Private Sub frmTextKlock_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        tmrTextKlock.Enabled = False

        frmKlock.NtfyIcnKlock.Visible = False
        frmKlock.Visible = True

        frmKlock.TextKlockToolStripMenuItem.Checked = False
    End Sub

    Private Sub tmrTextKlock_Tick(sender As System.Object, e As System.EventArgs) Handles tmrTextKlock.Tick

        clearlabels()
        getFuzzyTime()

        lblIT.Enabled = True
        lblIS.Enabled = True

        updateStatusBar()
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns off"

        '                                               if running on battery, change status info colour to red as a warning.
        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = Color.Black
            StsLblDate.ForeColor = Color.Black
            StsLblKeys.ForeColor = Color.Black
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

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleepimg.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If
    End Sub

    Private Sub clearlabels()

        lbl1.Enabled = False
        lbl2.Enabled = False
        lbl3.Enabled = False
        lbl4.Enabled = False
        lbl5.Enabled = False
        lbl7.Enabled = False
        lblABOUT.Enabled = False
        lblAFTER.Enabled = False
        lblE.Enabled = False
        lblEIGHT.Enabled = False
        lblELEVEN.Enabled = False
        lblEVENING.Enabled = False
        lblFIVE.Enabled = False
        lblFIVEto.Enabled = False
        lblFOUR.Enabled = False
        lblHALF.Enabled = False
        lblIN.Enabled = False
        lblIT.Enabled = False
        lblISH.Enabled = False
        lblTWENTY.Enabled = False
        lblK.Enabled = False
        lblMIDNIGHT.Enabled = False
        lblNINE.Enabled = False
        lblNOON.Enabled = False
        lblONE.Enabled = False
        lblPAST.Enabled = False
        lblQUARTER.Enabled = False
        lblSEVEN.Enabled = False
        lblSIX.Enabled = False
        lblTEN.Enabled = False
        lblTENto.Enabled = False
        lblTHE.Enabled = False
        lblTHREE.Enabled = False
        lblTO.Enabled = False
        lblTWELVE.Enabled = False
        lblTWO.Enabled = False
        lblMORNING.Enabled = False

    End Sub

    Private Sub getFuzzyTime()
        '   returns the current [local] time as fuzzy time i.e. ten past three in the afternoon.

        Dim hours() As String = {"twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve"}
        Dim hour As Integer = Now.Hour
        Dim mins As Integer = Now.Minute
        Dim nrms As Integer = mins - (mins Mod 5)           '   gets nearest five minutes.
        Dim ampm As String = ""
        Dim sRtn As String = ""

        If hour < 12 Then                                   '   if hour less then 12, in the morning else afternoon
            ampm = "in the morning"
            lblIN.Enabled = True
            lblTHE.Enabled = True
            lblMORNING.Enabled = True
        Else
            ampm = "pm"
        End If

        If (mins Mod 5) > 2 Then nrms += 5                  '   closer to next five minutes, go to next.

        Select Case nrms
            Case 0
                sRtn = ""
            Case 5
                sRtn = "five past"
                lblFIVEto.Enabled = True
                lblPAST.Enabled = True
            Case 10
                sRtn = "ten past"
                lblTENto.Enabled = True
                lblPAST.Enabled = True
            Case 15
                sRtn = "quarter past"
                lblQUARTER.Enabled = True
                lblPAST.Enabled = True
            Case 20
                sRtn = "twenty past"
                lblTWENTY.Enabled = True
                lblPAST.Enabled = True
            Case 25
                sRtn = "twenty-five past"
                lblTWENTY.Enabled = True
                lblFIVEto.Enabled = True
                lblPAST.Enabled = True
            Case 30
                sRtn = "half past"
                lblHALF.Enabled = True
                lblPAST.Enabled = True
            Case 35
                sRtn = "twenty-five to"
                lblTWENTY.Enabled = True
                lblFIVEto.Enabled = True
                lblTO.Enabled = True
            Case 40
                sRtn = "twenty to"
                lblTWENTY.Enabled = True
                lblTO.Enabled = True
            Case 45
                sRtn = "quarter to"
                lblQUARTER.Enabled = True
                lblTO.Enabled = True
            Case 50
                sRtn = "ten to"
                lblTENto.Enabled = True
                lblTO.Enabled = True
            Case 55
                sRtn = "five to"
                lblFIVEto.Enabled = True
                lblTO.Enabled = True
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
            lblABOUT.Enabled = True
            lblNOON.Enabled = True
        ElseIf (hour = 0) And (sRtn = "") Then
            lblABOUT.Enabled = True
            lblMIDNIGHT.Enabled = True
        ElseIf (hour = 24) And (sRtn = "") Then
            lblABOUT.Enabled = True
            lblMIDNIGHT.Enabled = True
        Else
            If ampm = "pm" Then
                hour -= 12
                lblIN.Enabled = True
                lblTHE.Enabled = True
                If hour >= 5 Then                               '   if greater then five in the afternoon then evening.
                    ampm = "in the evening"
                    lblEVENING.Enabled = True
                Else
                    ampm = "in the afternoon"
                    lblAFTER.Enabled = True
                    lblNOON.Enabled = True
                End If
            End If

            If sRtn = "" Then lblABOUT.Enabled = True

            Select Case hour
                Case 0
                    lblTWELVE.Enabled = True
                Case 1
                    lblONE.Enabled = True
                Case 2
                    lblTWO.Enabled = True
                Case 3
                    lblTHREE.Enabled = True
                Case 4
                    lblFOUR.Enabled = True
                Case 5
                    lblFIVE.Enabled = True
                Case 6
                    lblSIX.Enabled = True
                Case 7
                    lblSEVEN.Enabled = True
                Case 8
                    lblEIGHT.Enabled = True
                Case 9
                    lblNINE.Enabled = True
                Case 10
                    lblTEN.Enabled = True
                Case 11
                    lblELEVEN.Enabled = True
                Case 12
                    lblTWELVE.Enabled = True
                Case Else

            End Select

            If sRtn = "" Then lblISH.Enabled = True
        End If
    End Sub

    Private Sub frmTextKlock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        '   Processes key presses at form level, before passed to components.
        '   Pressing F1, will open klock's help.
        '   Pressing alt + F2, will open the options screen.
        '   Pressing alt + F6, will close the text klock.
        '   Pressing alt + F7, will disable the monitor from going to sleep.
        '   Pressing alt + F8, will restore system settings for the monitor.


        Select Case e.KeyCode
            Case Keys.F1
                Help.ShowHelp(Me, frmKlock.HlpPrvdrKlock.HelpNamespace, HelpNavigator.TableOfContents)
                e.Handled = True
            Case Keys.F2 And (e.Alt)
                frmKlock.usrSettings.writeSettings()      '   save settings, not sure if anything has changed.
                frmOptions.ShowDialog()
                frmKlock.setSettings()
            Case Keys.F6 And (e.Alt)
                tmrTextKlock.Enabled = False
                frmKlock.NtfyIcnKlock.Visible = False
                frmKlock.Visible = True
                frmKlock.TextKlockToolStripMenuItem.Checked = False
                Close()
                e.Handled = True
            Case Keys.F7 And (e.Alt)
                KlockThings.KeepMonitorActive()
                frmKlock.usrSettings.usrDisableMonitorSleep = True
                e.Handled = True
            Case Keys.F8 And (e.Alt)
                frmKlock.usrSettings.usrDisableMonitorSleep = False
                KlockThings.RestoreMonitorSettings()
                e.Handled = True
        End Select

    End Sub
End Class