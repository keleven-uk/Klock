Public Class frmTextKlock

    Private Sub frmTextKlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.clearlabels()
        Me.getFuzzyTime()

        Me.lblIT.Enabled = True
        Me.lblIS.Enabled = True

        Me.tmrTextKlock.Enabled = True

        Me.updateStatusBar()
    End Sub

    Private Sub frmTextKlock_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Me.tmrTextKlock.Enabled = False

        frmKlock.NtfyIcnKlock.Visible = False
        frmKlock.Visible = True

        frmKlock.TextKlockToolStripMenuItem.Checked = False
    End Sub

    Private Sub tmrTextKlock_Tick(sender As System.Object, e As System.EventArgs) Handles tmrTextKlock.Tick

        Me.clearlabels()
        Me.getFuzzyTime()

        Me.lblIT.Enabled = True
        Me.lblIS.Enabled = True

        Me.updateStatusBar()
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns off"

        '                                               if running on battery, change status info colour to red as a warning.
        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            Me.stsLblTime.ForeColor = Color.Black
            Me.StsLblDate.ForeColor = Color.Black
            Me.StsLblKeys.ForeColor = Color.Black
        Else
            Me.stsLblTime.ForeColor = Color.Red
            Me.StsLblDate.ForeColor = Color.Red
            Me.StsLblKeys.ForeColor = Color.Red
        End If

        If My.Computer.Keyboard.CapsLock.ToString() Then strKey = Replace(strKey, "c", "C")
        If My.Computer.Keyboard.NumLock.ToString() Then strKey = Replace(strKey, "n", "N")
        If My.Computer.Keyboard.ScrollLock.ToString() Then strKey = Replace(strKey, "s", "S")
        If KlockThings.HaveInternetConnection() Then strKey = Replace(strKey, "off", "ON")

        If frmKlock.usrSettings.usrTimeSystem24Hour Then
            Me.stsLblTime.Text = String.Format("{0:HH:mm:ss}", System.DateTime.Now)
        Else
            Me.stsLblTime.Text = String.Format("{0:hh:mm:ss tt}", System.DateTime.Now)
        End If

        '   Me.stsLblTime.Text = Format(Now, "Long Time")
        Me.StsLblDate.Text = Format(Now, "short Date")
        Me.StsLblKeys.Text = strKey

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleepimg.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            Me.stsLbIdkeTime.Visible = True
            Me.stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            Me.stsLbIdkeTime.Visible = False
        End If
    End Sub

    Private Sub clearlabels()

        Me.lbl1.Enabled = False
        Me.lbl2.Enabled = False
        Me.lbl3.Enabled = False
        Me.lbl4.Enabled = False
        Me.lbl5.Enabled = False
        Me.lbl7.Enabled = False
        Me.lblABOUT.Enabled = False
        Me.lblAFTER.Enabled = False
        Me.lblE.Enabled = False
        Me.lblEIGHT.Enabled = False
        Me.lblELEVEN.Enabled = False
        Me.lblEVENING.Enabled = False
        Me.lblFIVE.Enabled = False
        Me.lblFIVEto.Enabled = False
        Me.lblFOUR.Enabled = False
        Me.lblHALF.Enabled = False
        Me.lblIN.Enabled = False
        Me.lblIT.Enabled = False
        Me.lblISH.Enabled = False
        Me.lblTWENTY.Enabled = False
        Me.lblK.Enabled = False
        Me.lblMIDNIGHT.Enabled = False
        Me.lblNINE.Enabled = False
        Me.lblNOON.Enabled = False
        Me.lblONE.Enabled = False
        Me.lblPAST.Enabled = False
        Me.lblQUARTER.Enabled = False
        Me.lblSEVEN.Enabled = False
        Me.lblSIX.Enabled = False
        Me.lblTEN.Enabled = False
        Me.lblTENto.Enabled = False
        Me.lblTHE.Enabled = False
        Me.lblTHREE.Enabled = False
        Me.lblTO.Enabled = False
        Me.lblTWELVE.Enabled = False
        Me.lblTWO.Enabled = False
        Me.lblMORNING.Enabled = False

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
            Me.lblIN.Enabled = True
            Me.lblTHE.Enabled = True
            Me.lblMORNING.Enabled = True
        Else
            ampm = "pm"
        End If

        If (mins Mod 5) > 2 Then nrms += 5                  '   closer to next five minutes, go to next.

        Select Case nrms
            Case 0
                sRtn = ""
            Case 5
                sRtn = "five past"
                Me.lblFIVEto.Enabled = True
                Me.lblPAST.Enabled = True
            Case 10
                sRtn = "ten past"
                Me.lblTENto.Enabled = True
                Me.lblPAST.Enabled = True
            Case 15
                sRtn = "quarter past"
                Me.lblQUARTER.Enabled = True
                Me.lblPAST.Enabled = True
            Case 20
                sRtn = "twenty past"
                Me.lblTWENTY.Enabled = True
                Me.lblPAST.Enabled = True
            Case 25
                sRtn = "twenty-five past"
                Me.lblTWENTY.Enabled = True
                Me.lblFIVEto.Enabled = True
                Me.lblPAST.Enabled = True
            Case 30
                sRtn = "half past"
                Me.lblHALF.Enabled = True
                Me.lblPAST.Enabled = True
            Case 35
                sRtn = "twenty-five to"
                Me.lblTWENTY.Enabled = True
                Me.lblFIVEto.Enabled = True
                Me.lblTO.Enabled = True
            Case 40
                sRtn = "twenty to"
                Me.lblTWENTY.Enabled = True
                Me.lblTO.Enabled = True
            Case 45
                sRtn = "quarter to"
                Me.lblQUARTER.Enabled = True
                Me.lblTO.Enabled = True
            Case 50
                sRtn = "ten to"
                Me.lblTENto.Enabled = True
                Me.lblTO.Enabled = True
            Case 55
                sRtn = "five to"
                Me.lblFIVEto.Enabled = True
                Me.lblTO.Enabled = True
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
            Me.lblABOUT.Enabled = True
            Me.lblNOON.Enabled = True
        ElseIf (hour = 0) And (sRtn = "") Then
            Me.lblABOUT.Enabled = True
            Me.lblMIDNIGHT.Enabled = True
        ElseIf (hour = 24) And (sRtn = "") Then
            Me.lblABOUT.Enabled = True
            Me.lblMIDNIGHT.Enabled = True
        Else
            If ampm = "pm" Then
                hour -= 12
                Me.lblIN.Enabled = True
                Me.lblTHE.Enabled = True
                If hour >= 5 Then                               '   if greater then five in the afternoon then evening.
                    ampm = "in the evening"
                    Me.lblEVENING.Enabled = True
                Else
                    ampm = "in the afternoon"
                    Me.lblAFTER.Enabled = True
                    Me.lblNOON.Enabled = True
                End If
            End If

            If sRtn = "" Then lblABOUT.Enabled = True

            Select Case hour
                Case 0
                    Me.lblTWELVE.Enabled = True
                Case 1
                    Me.lblONE.Enabled = True
                Case 2
                    Me.lblTWO.Enabled = True
                Case 3
                    Me.lblTHREE.Enabled = True
                Case 4
                    Me.lblFOUR.Enabled = True
                Case 5
                    Me.lblFIVE.Enabled = True
                Case 6
                    Me.lblSIX.Enabled = True
                Case 7
                    Me.lblSEVEN.Enabled = True
                Case 8
                    Me.lblEIGHT.Enabled = True
                Case 9
                    Me.lblNINE.Enabled = True
                Case 10
                    Me.lblTEN.Enabled = True
                Case 11
                    Me.lblELEVEN.Enabled = True
                Case 12
                    Me.lblTWELVE.Enabled = True
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
                Me.tmrTextKlock.Enabled = False
                frmKlock.NtfyIcnKlock.Visible = False
                frmKlock.Visible = True
                frmKlock.TextKlockToolStripMenuItem.Checked = False
                Me.Close()
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