﻿Imports System.Globalization

Module InfoCommon
    '   A generic way of calling the Info form.

    Sub displayInfo(ByVal mode As String)
        '   Calls the info form and populates the labels depending upon how it called.

        Dim currentYear As Integer = frmInfo.NmrcUpDwnYear.Value

        Select Case mode
            Case "Daylight Saving"
                updateDaylightSaving(currentYear)
            Case "Easter Dates"
                updateEasteDates(currentYear)
            Case "Lent Dates"
                updateLentDates(currentYear)
            Case "Current Culture"
            Case "Culture"                  '   seems to have changed in windows 10
                frmInfo.NmrcUpDwnYear.Visible = False
                frmInfo.Label6.Visible = False
                frmInfo.CmbBxTimeServers.Visible = False
                frmInfo.BtnQueryServer.Visible = False
                frmInfo.ChckBxSynchKlock.Visible = False

                frmInfo.Text = "Info - Current Culture"
                frmInfo.GroupBox1.Text = "Current Culture"

                frmInfo.Label1.Text = "Current Culture Name : " & CultureInfo.CurrentCulture.EnglishName
                frmInfo.Label2.Text = "Three Letter ISO Name : " & CultureInfo.CurrentCulture.ThreeLetterISOLanguageName
                frmInfo.Label3.Text = "Full Date Time Pattern : " & CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern
                frmInfo.Label4.Text = "Currency Symbol : " & CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol
                frmInfo.Label5.Text = "First Day of the Week : " & CultureInfo.CurrentCulture.DateTimeFormat.DayNames(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            Case "Operating System"
                frmInfo.NmrcUpDwnYear.Visible = False
                frmInfo.Label6.Visible = False
                frmInfo.CmbBxTimeServers.Visible = False
                frmInfo.BtnQueryServer.Visible = False
                frmInfo.ChckBxSynchKlock.Visible = False

                frmInfo.Text = "Info - Operating System"
                frmInfo.GroupBox1.Text = "Operating System"

                frmInfo.Label1.Text = "Computer Name : " & My.Computer.Name.ToString
                frmInfo.Label2.Text = String.Empty
                frmInfo.Label3.Text = "OS Full Name : " & My.Computer.Info.OSFullName
                frmInfo.Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
                frmInfo.Label5.Text = "OS Version : " & My.Computer.Info.OSVersion
            Case "Power Source"
                frmInfo.NmrcUpDwnYear.Visible = False
                frmInfo.Label6.Visible = False
                frmInfo.CmbBxTimeServers.Visible = False
                frmInfo.BtnQueryServer.Visible = False
                frmInfo.ChckBxSynchKlock.Visible = False

                frmInfo.Text = "Info - Power Source"
                frmInfo.GroupBox1.Text = "Power Source"

                frmInfo.Label1.Text = frmKlock.myManagedPower.powerSource()
                frmInfo.Label2.Text = String.Empty
                frmInfo.Label3.Text = frmKlock.myManagedPower.powerStatus()
                frmInfo.Label4.Text = frmKlock.myManagedPower.chargingStatus()
                frmInfo.Label5.Text = String.Empty

                frmInfo.TmrInfo.Enabled = True      '   switch on timer.
            Case "Internet Time"

                frmInfo.NmrcUpDwnYear.Visible = False
                frmInfo.Label6.Visible = False
                frmInfo.CmbBxTimeServers.Visible = True
                frmInfo.CmbBxTimeServers.SelectedIndex = 0
                frmInfo.BtnQueryServer.Visible = True
                frmInfo.ChckBxSynchKlock.Visible = True

                frmInfo.Text = "Info - Internet Time"
                frmInfo.GroupBox1.Text = "Internet Time"

                frmInfo.Label1.Text = String.Empty
                frmInfo.Label2.Text = String.Empty
                frmInfo.Label3.Text = String.Empty
                frmInfo.Label4.Text = String.Empty
                frmInfo.Label5.Text = String.Empty

        End Select

        frmInfo.ShowDialog()
    End Sub


    Sub queryServer()
        '   receives the time info from an internet time server.
        '   See SNTBClient.vb for details and credits.

        Dim sntpTime As InternetTime.SNTPClient

        sntpTime = New InternetTime.SNTPClient(frmInfo.CmbBxTimeServers.SelectedItem)
        sntpTime.Connect(frmInfo.ChckBxSynchKlock.Checked)

        frmInfo.Text = "Info - Internet Time"
        frmInfo.GroupBox1.Text = "Internet Time"

        frmInfo.Label1.Text = sntpTime.ToString
        frmInfo.Label2.Text = String.Empty
        frmInfo.Label3.Text = String.Empty
        frmInfo.Label4.Text = String.Empty
        frmInfo.Label5.Text = String.Empty
    End Sub

    Sub updateDaylightSaving(ByVal currentYear As Integer)
        '   Updates the form with the daylight saving info for current date in the current year.
        '   NB : current year can be selected from the form, so could be different from the year in current date.

        ' Get the local time zone and the current date.
        Dim currentDate As Date = Date.Now

        Dim localZone As TimeZone = TimeZone.CurrentTimeZone
        Dim daylight As DaylightTime = localZone.GetDaylightChanges(currentYear)

        frmInfo.NmrcUpDwnYear.Visible = True
        frmInfo.Label6.Visible = True
        frmInfo.CmbBxTimeServers.Visible = False
        frmInfo.BtnQueryServer.Visible = False
        frmInfo.ChckBxSynchKlock.Visible = False

        frmInfo.NmrcUpDwnYear.Value = currentYear
        frmInfo.Text = "Info - Daylight Saving"

        frmInfo.GroupBox1.Text = If(localZone.IsDaylightSavingTime(currentDate), "Summer Time", "Winter Time")

        frmInfo.Label1.Text = "Standard Time Name : " & localZone.StandardName
        frmInfo.Label2.Text = "Daylight Saving Time : " & localZone.DaylightName
        frmInfo.Label3.Text = "Daylight saving time for " & currentYear
        frmInfo.Label4.Text = String.Format(" Move the clocks forward {0} Hour on {1} at {2}", daylight.Delta.Hours, daylight.Start.ToLongDateString, daylight.Start.ToShortTimeString)
        frmInfo.Label5.Text = String.Format(" Move the clocks back {0} Hour on {1} at {2}", daylight.Delta.Hours, daylight.End.ToLongDateString, daylight.End.ToShortTimeString)
    End Sub

    Sub updateEasteDates(ByVal currentYear As Integer)
        '   Updates the form with the Easter dates for the current year.
        '   NB : current year can be selected from the form, so could be different from the year in current date.


        frmInfo.NmrcUpDwnYear.Visible = True
        frmInfo.NmrcUpDwnYear.Value = currentYear
        frmInfo.Label6.Visible = True
        frmInfo.CmbBxTimeServers.Visible = False
        frmInfo.BtnQueryServer.Visible = False
        frmInfo.ChckBxSynchKlock.Visible = False

        frmInfo.Text = "Info - Easter Dates"
        frmInfo.GroupBox1.Text = "Easter Dates"

        frmInfo.Label1.Text = String.Empty
        frmInfo.Label2.Text = "Easter Dates - " & currentYear
        frmInfo.Label3.Text = String.Format("Good Friday   : {0}", KlockThings.easterDate(currentYear).AddDays(-2).ToLongDateString)
        frmInfo.Label4.Text = String.Format("Easter Sunday : {0}", KlockThings.easterDate(currentYear).ToLongDateString)
        frmInfo.Label5.Text = String.Format("Easter Monday : {0}", KlockThings.easterDate(currentYear).AddDays(+1).ToLongDateString)
    End Sub

    Sub updateInfo(ByVal mode As String, ByVal year As Integer)
        '   Calls the info form and populates the labels depending upon how it called.
        '   This is only called for Daylight Saving and Easter Dates, if the year has been changed.

        Select Case mode
            Case "Daylight Saving", "Summer Time", "Winter Time"
                updateDaylightSaving(year)
            Case "Easter Dates"
                updateEasteDates(year)
            Case "Lent Dates"
                updateLentDates(year)
        End Select

    End Sub


    Sub updateLentDates(ByVal currentYear As Integer)
        '   Updates the form with the lent dates for the current year.
        '   lent start on Ash Wednesday, which is 46 days before Easter Sunday.
        '   NB : current year can be selected from the form, so could be different from the year in current date.

        frmInfo.NmrcUpDwnYear.Visible = True
        frmInfo.NmrcUpDwnYear.Value = currentYear
        frmInfo.Label6.Visible = False
        frmInfo.CmbBxTimeServers.Visible = False
        frmInfo.BtnQueryServer.Visible = False
        frmInfo.ChckBxSynchKlock.Visible = False

        frmInfo.Text = "Info - Lent Dates"
        frmInfo.GroupBox1.Text = "Lent Dates"

        frmInfo.Label1.Text = String.Empty
        frmInfo.Label2.Text = "Lent Dates - " & currentYear
        frmInfo.Label3.Text = String.Format("Lent Starts [Ash Wednesday] : {0}", KlockThings.easterDate(currentYear).AddDays(-46).ToLongDateString)
        frmInfo.Label4.Text = String.Format("Lent Ends   [Easter Sunday] : {0}", KlockThings.easterDate(currentYear).ToLongDateString)
        frmInfo.Label5.Text = ""
    End Sub

End Module
