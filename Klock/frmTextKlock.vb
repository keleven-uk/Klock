Public Class frmTextKlock

    Private Sub frmTextKlock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.clearlabels()
        Me.getFuzzyTime()

        Me.lblIT.Enabled = True
        Me.lblIS.Enabled = True

        Me.tmrTextKlock.Enabled = True
    End Sub

    Private Sub frmTextKlock_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Me.tmrTextKlock.Enabled = False
    End Sub

    Private Sub tmrTextKlock_Tick(sender As System.Object, e As System.EventArgs) Handles tmrTextKlock.Tick

        Me.clearlabels()
        Me.getFuzzyTime()

        Me.lblIT.Enabled = True
        Me.lblIS.Enabled = True
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

        If hour < 12 Then     '   if hour less then 12, in the morning else afternoon
            ampm = "in the morning"
            Me.lblIN.Enabled = True
            Me.lblTHE.Enabled = True
            Me.lblMORNING.Enabled = True
        Else
            ampm = "pm"
        End If

        If (mins Mod 5) > 2 Then nrms += 5 '   closer to next five minutes, go to next.

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
        '   This looks more complicated then it should be, maybe sperate if then's would be better and use exit sub's inside each.

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
                If hour >= 5 Then   '   if greater then five in the afternoon then evening.
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
End Class