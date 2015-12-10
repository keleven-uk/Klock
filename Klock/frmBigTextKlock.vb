Public Class frmBigTextKlock
    '   Generates a big text screen which displays the current time and date from a seemingly random set of words.


    Dim lblArraySeconds(60) As Label        '   global array of text labels
    Dim lblArrayMiniutes(60) As Label       '
    Dim lblArrayHour(12) As Label           '
    Dim lblArrayMonth(12) As Label          '
    Dim lblArrayDayofMonth(31) As Label     '
    Dim lblArrayDayofWeek(7) As Label       '

    Dim drag As Boolean                     '   Global variables used to make the form dragable.
    Dim mousex As Integer                   '
    Dim mousey As Integer                   '


    ' -------------------------------------------------------------------------------- procedures used to make form dragable -----------------

    Private Sub pnlBigKlock_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, pnlBigKlock.MouseDown

        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub pnlBigKlock_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, pnlBigKlock.MouseMove

        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub pnlBigKlock_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, pnlBigKlock.MouseUp

        drag = False
    End Sub

    ' ------------------------------------------------------------------------------------------------- key down ----------------------------
    '
    Private Sub frmBigTextKlock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, pnlBigKlock.KeyDown
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

    ' ------------------------------------------------------------------------------------------------- form load ----------------------------
    Private Sub frmBigTextKlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   when the form loads set some global variables, turn on timer And load arrays.

        drag = False

        StsStrpInfo.BackColor = Color.FromKnownColor(KnownColor.Black)
        stsLbIdkeTime.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)

        tmrTextKlock.Enabled = True

        loadArraySeconds()
        loadArrayMinutes()
        loadArrayHour()
        loadArrayMonth()
        loadArrayDayofMonth()
        loadArrayDayofWeek()

        clearlabels()
        setTime()
        updateStatusBar()
    End Sub

    Private Sub frmBigTextKlock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        '   When form is closed turn off timer and re-load main form.

        tmrTextKlock.Enabled = False

        frmKlock.NtfyIcnKlock.Visible = False
        frmKlock.Visible = True

        frmKlock.TextKlockToolStripMenuItem.Checked = False
    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        '   The close label id clicked, close form.
        '   Used because form has no border and hence no close button of it's own.

        Close()
    End Sub

    Private Sub tmrTextKlock_Tick(sender As Object, e As EventArgs) Handles tmrTextKlock.Tick
        '   On every beat of the timer clear all the labels and set the time.

        clearlabels()
        setTime()
        updateStatusBar()
    End Sub

    Private Sub updateStatusBar()
        '    Updates the status bar - time, date and status of caps, scroll and num lock keys.

        Dim strKey As String = "cns off"

        '                                               if running on battery, change status info colour to red as a warning.
        If frmKlock.myManagedPower.powerSource().Contains("AC") Then
            stsLblTime.ForeColor = Color.LightGreen
            StsLblDate.ForeColor = Color.LightGreen
            StsLblKeys.ForeColor = Color.LightGreen
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
        StsLblDate.Text = Format(Now, "long Date")
        StsLblKeys.Text = strKey

        '   Works out idle time, but only if needed.  But, will display idle time if disabling monitor sleeping.

        If frmKlock.usrSettings.usrTimeIdleTime Or frmKlock.usrSettings.usrDisableMonitorSleep Then
            stsLbIdkeTime.Visible = True
            stsLbIdkeTime.Text = KlockThings.idleTime()
        Else
            stsLbIdkeTime.Visible = False
        End If
    End Sub

    Private Sub setTime()
        '   Set the time to now().
        '   highlights appropriate labels to represent the time in words, in fact sets their colour to LightGreen.

        Dim thisNow As DateTime = Now

        Dim DayOfWeek As Integer = thisNow.DayOfWeek
        Dim DayOfMonth As Integer = thisNow.Day
        Dim MonthOfYear As Integer = thisNow.Month
        Dim hourOfDay As Integer = thisNow.Hour
        Dim minutesOfDay As Integer = thisNow.Minute
        Dim secondOfDay As Integer = thisNow.Second
        Dim year As String = thisNow.Year.ToString

        lblYear.Text = year

        If IsNoon(thisNow) Then
            SetNoon()
        ElseIf IsMidnight(thisNow) Then
            SetMidnight()
        Else
            setDayofWeek(DayOfWeek)
            setDayOfMonth(DayOfMonth)
            setMonthOfYear(MonthOfYear)
            setHourOfDay(hourOfDay)
            setMinutesOfDay(minutesOfDay)
            setSecondsofDay(secondOfDay)
        End If
    End Sub

    Private Sub clearlabels()
        '   Clear all labels, in fact sets their colour to ListSlateGray.
        '   Set colour to LightGreen for labels that always on.

        Dim lbl As New Control

        pnlBigKlock.BackColor = Color.FromKnownColor(KnownColor.Black)

        For Each lbl In pnlBigKlock.Controls     'if other then label appear on panel, then will have to check for this.
            'If (lbl.GetType() Is GetType(Label)) Then
            'lbl.Enabled = False
            lbl.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
            'End If
        Next

        lblthe.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        lblOf.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        lblComer.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        lbloclock.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        lblYear.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        lblInThe.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)

    End Sub


    Private Sub setDayofWeek(DayOfWeek As Integer)
        '   Switch on the current day of the week.

        lblArrayDayofWeek(DayOfWeek).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
    End Sub

    Private Sub setDayOfMonth(DayOfMonth As Integer)
        '   Switch on the current day of the month.

        lblArrayDayofMonth(DayOfMonth).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
    End Sub


    Private Sub setMonthOfYear(MonthofYear As Integer)
        '   Switch on the current month of the year.

        lblArrayMonth(MonthofYear).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
    End Sub

    Private Sub setHourOfDay(hourOfDay As Integer)
        '   Switch on the current hour of the day.

        If hourOfDay < 13 Then
            lblAm.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        Else
            lblPm.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            hourOfDay -= 12
        End If

        If hourOfDay > 0 Then lblArrayHour(hourOfDay).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
    End Sub

    Private Sub setMinutesOfDay(minutesOfDay As Integer)
        '   Switch on the current minute of the day.

        If minutesOfDay = 1 Then
            lblAndMinutes.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblMinute.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblArrayMiniutes(minutesOfDay).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        ElseIf minutesOfDay > 1 And minutesOfDay < 60 Then
            lblAndMinutes.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblMinutes.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblArrayMiniutes(minutesOfDay).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        End If
    End Sub

    Private Sub setSecondsofDay(secondOfDay As Integer)
        '   Switch on the current second of the day.

        If secondOfDay = 1 Then
            lblAndSeconds.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblSecond.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblArraySeconds(secondOfDay).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        ElseIf secondOfDay > 1 And secondOfDay < 60 Then
            lblAndSeconds.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblSeconds.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
            lblArraySeconds(secondOfDay).ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
        End If
    End Sub

    Private Sub SetNoon()
        '   Switch on noon.

        lblComer.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lblAndSeconds.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lblAndMinutes.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lbloclock.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lblInThe.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)

        lblNoon.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
    End Sub

    Private Sub SetMidnight()
        '   Switch on the midnight.

        lblComer.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lblAndSeconds.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lblAndMinutes.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lbloclock.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)
        lblInThe.ForeColor = Color.FromKnownColor(KnownColor.LightSlateGray)

        lblMidnight.ForeColor = Color.FromKnownColor(KnownColor.LightGreen)
    End Sub

    Private Function IsNoon(ByVal value As DateTime) As Boolean
        '   Returns true if current time is noon.

        Return value.Hour = 12 And
            value.Minute = 0 And
            value.Second = 0
    End Function

    Private Function IsMidnight(ByVal value As DateTime) As Boolean
        '   Returns true if current time is midnight.

        Return value.Hour = 0 And
            value.Minute = 0 And
            value.Second = 0
    End Function


    '----------------------------------------------------------------------------Load Label Arrays -----------------------------
    '   maybe these should be loaded dynamically - TODO

    Private Sub loadArrayDayofWeek()

        lblArrayDayofWeek(0) = lblSunday
        lblArrayDayofWeek(1) = lblMonday
        lblArrayDayofWeek(2) = lblMonday
        lblArrayDayofWeek(3) = lblWednesday
        lblArrayDayofWeek(4) = lblThursday
        lblArrayDayofWeek(5) = lblFriday
        lblArrayDayofWeek(6) = lblSaturday
    End Sub

    Private Sub loadArrayDayofMonth()

        lblArrayDayofMonth(1) = lblFirstDay
        lblArrayDayofMonth(2) = lblSecondDay
        lblArrayDayofMonth(3) = lblThirdDay
        lblArrayDayofMonth(4) = lblFourthDay
        lblArrayDayofMonth(5) = lblFithDay
        lblArrayDayofMonth(6) = lblSixthDay
        lblArrayDayofMonth(7) = lblSeventhDay
        lblArrayDayofMonth(8) = lblEighthDay
        lblArrayDayofMonth(9) = lblNinthDay
        lblArrayDayofMonth(10) = lblTenthDay
        lblArrayDayofMonth(11) = lbleleventhDay
        lblArrayDayofMonth(12) = lblTwelfthDay
        lblArrayDayofMonth(13) = lblThirteenthDay
        lblArrayDayofMonth(14) = lblFourteenthDay
        lblArrayDayofMonth(15) = lblFifteenthDay
        lblArrayDayofMonth(16) = lblSixteenthDay
        lblArrayDayofMonth(17) = lblSeventeenthDay
        lblArrayDayofMonth(18) = lblEighteenthDay
        lblArrayDayofMonth(19) = lblNineteenthDay
        lblArrayDayofMonth(20) = lblTwentiethDay
        lblArrayDayofMonth(21) = lblTwentyFirstDay
        lblArrayDayofMonth(22) = lblTwentySecondDay
        lblArrayDayofMonth(23) = lblTwentyThirdDay
        lblArrayDayofMonth(24) = lblTwentyFourthDay
        lblArrayDayofMonth(25) = lblTwentyFifthDay
        lblArrayDayofMonth(26) = lblTwentySixthDay
        lblArrayDayofMonth(27) = lblTwentySeventhDay
        lblArrayDayofMonth(28) = lbltwentyEighthDay
        lblArrayDayofMonth(29) = lblTwentyNinthDay
        lblArrayDayofMonth(30) = lblthirtiethDay
        lblArrayDayofMonth(31) = lblThirtyFirstDay
    End Sub

    Private Sub loadArrayMonth()

        lblArrayMonth(1) = lblJanuary
        lblArrayMonth(2) = lblFebruary
        lblArrayMonth(3) = lblMarch
        lblArrayMonth(4) = lblApril
        lblArrayMonth(5) = lblMay
        lblArrayMonth(6) = lblJune
        lblArrayMonth(7) = lblJuly
        lblArrayMonth(8) = lblAugust
        lblArrayMonth(9) = lblSeptember
        lblArrayMonth(10) = lblOctober
        lblArrayMonth(11) = lblNovember
        lblArrayMonth(12) = lblDecember

    End Sub

    Private Sub loadArrayHour()

        lblArrayHour(1) = lblOneHour
        lblArrayHour(2) = lblTwoHour
        lblArrayHour(3) = lblThreeHour
        lblArrayHour(4) = lblFourHour
        lblArrayHour(5) = lblFiveHour
        lblArrayHour(6) = lblSixHour
        lblArrayHour(7) = lblSevenHour
        lblArrayHour(8) = lblEightHour
        lblArrayHour(9) = lblNineHour
        lblArrayHour(10) = lblTenHour
        lblArrayHour(11) = lblElevenHour
        lblArrayHour(12) = lblTwelveHour
    End Sub

    Private Sub loadArrayMinutes()

        lblArrayMiniutes(1) = lblOneMinute
        lblArrayMiniutes(2) = lblTwoMinutes
        lblArrayMiniutes(3) = lblThreeMinutes
        lblArrayMiniutes(4) = lblFourMinutes
        lblArrayMiniutes(5) = lblFiveMinutes
        lblArrayMiniutes(6) = lblSixMinutes
        lblArrayMiniutes(7) = lblSevenMinutes
        lblArrayMiniutes(8) = lblEightMinutes
        lblArrayMiniutes(9) = lblNineMinutes
        lblArrayMiniutes(10) = lblTenMinutes
        lblArrayMiniutes(11) = lblElevenMinutes
        lblArrayMiniutes(12) = lbltwelveMinutes
        lblArrayMiniutes(13) = lblThirteenMinutes
        lblArrayMiniutes(14) = lblFourteenMinutes
        lblArrayMiniutes(15) = lblFifteenMinutes
        lblArrayMiniutes(16) = lblSixteenMinutes
        lblArrayMiniutes(17) = lblSeventeenMinutes
        lblArrayMiniutes(18) = lblEighteenMinutes
        lblArrayMiniutes(19) = lblNineteenMinutes
        lblArrayMiniutes(20) = lblTwentyMinutes
        lblArrayMiniutes(21) = lblTwentyOneMinutes
        lblArrayMiniutes(22) = lblTwentyTwoMinutes
        lblArrayMiniutes(23) = lblTwentyThreeMinutes
        lblArrayMiniutes(24) = lblTwentyFourMinutes
        lblArrayMiniutes(25) = lblTwentyFiveMinutes
        lblArrayMiniutes(26) = lblTwentySixMinutes
        lblArrayMiniutes(27) = lblTwentySevenMinutes
        lblArrayMiniutes(28) = lbltwentyEightMinutes
        lblArrayMiniutes(29) = lblTwentyNineMinutes
        lblArrayMiniutes(30) = lblThirtyMinutes
        lblArrayMiniutes(31) = lblThirtyOneMinutes
        lblArrayMiniutes(32) = lblThirtyTwoMinutes
        lblArrayMiniutes(33) = lblThirtyThreeMinutes
        lblArrayMiniutes(34) = lblThirtyFourMinutes
        lblArrayMiniutes(35) = lblThirtyFiveMinutes
        lblArrayMiniutes(36) = lblThirtySixMinutes
        lblArrayMiniutes(37) = lblThirtySevenMinutes
        lblArrayMiniutes(38) = lblThirtyEightMinutes
        lblArrayMiniutes(39) = lblThirtyNineMinutes
        lblArrayMiniutes(40) = lblFortyMinutes
        lblArrayMiniutes(41) = lblFortyOneMinutes
        lblArrayMiniutes(42) = lblFortyTwoMinutes
        lblArrayMiniutes(43) = lblFortyThreeMinutes
        lblArrayMiniutes(44) = lblFortyFourMinutes
        lblArrayMiniutes(45) = lblFortyFiveMinutes
        lblArrayMiniutes(46) = lblFortySixMinutes
        lblArrayMiniutes(47) = lblFortySevenMinutes
        lblArrayMiniutes(48) = lblFortyEightMinutes
        lblArrayMiniutes(49) = lblFortyNineMinutes
        lblArrayMiniutes(50) = lblFiftyMinutes
        lblArrayMiniutes(51) = lblFiftyOneMinutes
        lblArrayMiniutes(52) = lblFiftyTwoMinutes
        lblArrayMiniutes(53) = lblFiftyThreeMinutes
        lblArrayMiniutes(54) = lblFiftyFourMinutes
        lblArrayMiniutes(55) = lblFiftyFiveMinutes
        lblArrayMiniutes(56) = lblFiftySixMinutes
        lblArrayMiniutes(57) = lblFiftySevenMinutes
        lblArrayMiniutes(58) = lblFiftyEightMinutes
        lblArrayMiniutes(59) = lblFiftyNineMinutes
    End Sub

    Private Sub loadArraySeconds()

        lblArraySeconds(1) = lblOneSecond
        lblArraySeconds(2) = lblTwoSeconds
        lblArraySeconds(3) = lblThreeSeconds
        lblArraySeconds(4) = lblFourSeconds
        lblArraySeconds(5) = lblFiveSeconds
        lblArraySeconds(6) = lblSixSeconds
        lblArraySeconds(7) = lblSevenSeconds
        lblArraySeconds(8) = lblEightSeconds
        lblArraySeconds(9) = lblNineSeconds
        lblArraySeconds(10) = lblTenSeconds
        lblArraySeconds(11) = lblElevenSeconds
        lblArraySeconds(12) = lbltwelveSeconds
        lblArraySeconds(13) = lblThirteenSeconds
        lblArraySeconds(14) = lblFourteenSeconds
        lblArraySeconds(15) = lblFifteenSeconds
        lblArraySeconds(16) = lblSixteenSeconds
        lblArraySeconds(17) = lblSeventeenSeconds
        lblArraySeconds(18) = lblEighteenSeconds
        lblArraySeconds(19) = lblNineteenSeconds
        lblArraySeconds(20) = lblTwentySeconds
        lblArraySeconds(21) = lblTwentyOneSeconds
        lblArraySeconds(22) = lblTwentyTwoSeconds
        lblArraySeconds(23) = lblTwentyThreeSeconds
        lblArraySeconds(24) = lblTwentyFourSeconds
        lblArraySeconds(25) = lblTwentyFiveSeconds
        lblArraySeconds(26) = lblTwentySixSeconds
        lblArraySeconds(27) = lblTwentySevenSeconds
        lblArraySeconds(28) = lblTwentyEightSeconds
        lblArraySeconds(29) = lblTwentyNineSeconds
        lblArraySeconds(30) = lblThirtySeconds
        lblArraySeconds(31) = lblThirtyOneSeconds
        lblArraySeconds(32) = lblThirtyTwoSeconds
        lblArraySeconds(33) = lblThirtyThreeSeconds
        lblArraySeconds(34) = lblThirtyFourSeconds
        lblArraySeconds(35) = lblThirtyFiveSeconds
        lblArraySeconds(36) = lblThirtySixSeconds
        lblArraySeconds(37) = lblThirtySevenSeconds
        lblArraySeconds(38) = lblThirtyEightSeconds
        lblArraySeconds(39) = lblThirtyNineSeconds
        lblArraySeconds(40) = lblFortySeconds
        lblArraySeconds(41) = lblFortyOneSeconds
        lblArraySeconds(42) = lblFortyTwoSeconds
        lblArraySeconds(43) = lblFortyThreeSeconds
        lblArraySeconds(44) = lblFortyFourSeconds
        lblArraySeconds(45) = lblFortyFiveSeconds
        lblArraySeconds(46) = lblFortySixSeconds
        lblArraySeconds(47) = lblFortySevenSeconds
        lblArraySeconds(48) = lblFortyEightSeconds
        lblArraySeconds(49) = lblFortyNineSeconds
        lblArraySeconds(50) = lblFiftySeconds
        lblArraySeconds(51) = lblFiftyOneSeconds
        lblArraySeconds(52) = lblFiftyTwoSeconds
        lblArraySeconds(53) = lblFiftyThreeSeconds
        lblArraySeconds(54) = lblFiftyFourSeconds
        lblArraySeconds(55) = lblFiftyFiveSeconds
        lblArraySeconds(56) = lblFiftySixSeconds
        lblArraySeconds(57) = lblFiftySevenSeconds
        lblArraySeconds(58) = lblFiftyEightSeconds
        lblArraySeconds(59) = lblFiftyNineSeconds
    End Sub


End Class