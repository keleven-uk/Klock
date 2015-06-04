Imports System.Globalization

Module InfoCommon
    '   A generic way of calling the Info form.

    Sub displayInfo(ByVal mode As String)
        '   Calls the info form and populates the labels depending upon how it called.

        Select Case mode
            Case "Daylight Saving"
                ' Get the local time zone and the current  year.
                Dim localZone As TimeZone = TimeZone.CurrentTimeZone
                Dim currentDate As DateTime = DateTime.Now
                Dim currentYear As Integer = currentDate.Year
                Dim daylight As DaylightTime = localZone.GetDaylightChanges(currentYear)

                frmInfo.Text = "Info - Daylight Saving"

                If localZone.IsDaylightSavingTime(currentDate) Then
                    frmInfo.GroupBox1.Text = "Summer Time"
                Else
                    frmInfo.GroupBox1.Text = "Winter Time"
                End If

                frmInfo.Label1.Text = "Standard Time Name : " & localZone.StandardName
                frmInfo.Label2.Text = "Daylight Saving Time : " & localZone.DaylightName
                frmInfo.Label3.Text = "Daylight saving time for " & currentYear
                frmInfo.Label4.Text = String.Format(" Move the clocks forward {0} Hour on {1} at {2}", daylight.Delta.Hours, daylight.Start.ToLongDateString, daylight.Start.ToShortTimeString)
                frmInfo.Label5.Text = String.Format(" Move the clocks back {0} Hour on {1} at {2}", daylight.Delta.Hours, daylight.End.ToLongDateString, daylight.End.ToShortTimeString)
            Case "Current Culture"
                frmInfo.Text = "Info - Current Culture"
                frmInfo.GroupBox1.Text = "Current Culture"

                frmInfo.Label1.Text = "Current Culture Name : " & CultureInfo.CurrentCulture.EnglishName
                frmInfo.Label2.Text = "Three Letter ISO Name : " & CultureInfo.CurrentCulture.ThreeLetterISOLanguageName
                frmInfo.Label3.Text = "Full Date Time Pattern : " & CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern
                frmInfo.Label4.Text = "Currency Symbol : " & CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol
                frmInfo.Label5.Text = "First Day of the Week : " & CultureInfo.CurrentCulture.DateTimeFormat.DayNames(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            Case "Operating System"
                frmInfo.Text = "Info - Operating System"
                frmInfo.GroupBox1.Text = "Operating System"

                frmInfo.Label1.Text = "Computer Name : " & My.Computer.Name.ToString
                frmInfo.Label2.Text = ""
                frmInfo.Label3.Text = "OS Full Name : " & My.Computer.Info.OSFullName
                frmInfo.Label4.Text = "OS Platform : " & My.Computer.Info.OSPlatform
                frmInfo.Label5.Text = "OS Version : " & My.Computer.Info.OSVersion
            Case "Power Source"
                frmInfo.Text = "Info - Power Source"
                frmInfo.GroupBox1.Text = "Power Source"

                frmInfo.Label1.Text = frmKlock.myManagedPower.powerSource()
                frmInfo.Label2.Text = ""
                frmInfo.Label3.Text = frmKlock.myManagedPower.powerStatus()
                frmInfo.Label4.Text = frmKlock.myManagedPower.chargingStatus()
                frmInfo.Label5.Text = ""

                frmInfo.TmrInfo.Enabled = True      '   switch on timer.
        End Select

        frmInfo.ShowDialog()
    End Sub

End Module
