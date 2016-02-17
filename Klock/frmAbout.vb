Imports Klock.frmKlock

Public Class frmAbout

    '   Displays an About screen.       K. Scott    November 2012

    '   The relevant information is displayed when the form is loaded.
    '   Disk space and memory usage are displayed every second and can be either
    '   displayed in text or as a bar chart, depending upon a checkbox.

    Private Sub btnAboutClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAboutClose.Click
        '   switch off timer when finished.

        tmrAbout.Enabled = False
        Close()
    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '   switch on timer and display static text when form loads.

        tmrAbout.Enabled = True

        lblVersion.Text = "Klock Version :: " & My.Application.Info.Version.ToString()
        lblCopyright.Text = My.Application.Info.Copyright
        lblDescription.Text = My.Application.Info.Description
        lblTitle.Text = My.Application.Info.Title

        lblOSFullNameValue.Text = My.Computer.Info.OSFullName
        lblUserNameValue.Text = My.User.Name
        lblComputerNameValue.Text = My.Computer.Name
        lblNetworkAvailableValue.Text = My.Computer.Network.IsAvailable.ToString()
        lblProcessorNameValue.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\Hardware\DESCRIPTION\System\CentralProcessor\0", "Identifier", "")
    End Sub

    Sub updateTextInfo()
        '   displays disk and memory usage in text.

        Dim cdrive As System.IO.DriveInfo

        cdrive = My.Computer.FileSystem.GetDriveInfo("c:\")

        lblDriveSizeValue.Text = Format(cdrive.TotalSize, "##,##0") & " \ " & Format(cdrive.AvailableFreeSpace, "##,##0")

        lblPhysicalMemoryValue.Text = Format(My.Computer.Info.TotalPhysicalMemory, "##,##0") & " \ " & Format(My.Computer.Info.AvailablePhysicalMemory, "##,##0")
        lblVirtualMemoryValue.Text = Format(My.Computer.Info.TotalVirtualMemory, "##,##0") & " \ " & Format(My.Computer.Info.AvailableVirtualMemory, "##,##0")
    End Sub

    Sub updateBarInfo()
        '   Display disk and memory usage has a progress bar.

        Dim cdrive As System.IO.DriveInfo

        cdrive = My.Computer.FileSystem.GetDriveInfo("c:\")

        PrgrsBrDriveSize.Maximum = 100
        PrgrsBrDriveSize.Value = cdrive.AvailableFreeSpace / cdrive.TotalSize * 100

        PrgrsBrPhysicalMemory.Maximum = 100
        PrgrsBrPhysicalMemory.Value = My.Computer.Info.AvailablePhysicalMemory / My.Computer.Info.TotalPhysicalMemory * 100

        PrgrsBrVirtualMemory.Maximum = 100
        PrgrsBrVirtualMemory.Value = My.Computer.Info.AvailableVirtualMemory / My.Computer.Info.TotalVirtualMemory * 100
    End Sub

    Sub enableText(ByVal b As Boolean)
        ' enable / disable text disk and memory usage labels

        lblDriveSizeValue.Visible = b
        lblDriveSizeValue.Enabled = b
        lblPhysicalMemoryValue.Visible = b
        lblPhysicalMemoryValue.Enabled = b
        lblVirtualMemoryValue.Visible = b
        lblVirtualMemoryValue.Enabled = b
    End Sub

    Sub enableBar(ByVal b As Boolean)
        '   enable / disable disk and memory usage progress bars.

        PrgrsBrDriveSize.Visible = b
        PrgrsBrDriveSize.Enabled = b
        PrgrsBrPhysicalMemory.Visible = b
        PrgrsBrPhysicalMemory.Enabled = b
        PrgrsBrVirtualMemory.Visible = b
        PrgrsBrVirtualMemory.Enabled = b
    End Sub

    Private Sub tmrAbout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAbout.Tick
        '   Called every second, updates dynamic text in real time.

        lblAppRunTimeValue.Text = getUpTime("A")
        lblSystemUpTimeValue.Text = getUpTime("S")

        If ChckBxAbtSwap.Checked Then
            enableBar(False)
            enableText(True)
            updateTextInfo()
        Else
            enableText(False)
            enableBar(True)
            updateBarInfo()
        End If
    End Sub

    Private Sub btnAboutMSinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAboutMSinfo.Click
        '   load ms info

        Try
            Shell("msinfo32.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            Try                         '   if fails, try hard coded location [I think for windows XP]
                Shell("C:\Program Files\Common Files\Microsoft Shared\MSInfo\msinfo32.exe", AppWinStyle.NormalFocus)
            Catch ex1 As Exception
                MessageBox.Show("Cannot find MSinfo! " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Try
    End Sub

    Function getUpTime(ByVal type As Char) As String
        '   Determines the up time of either System or Application - depending on argument S or A.

        Dim noTicks As Double = If(type = "A", My.Computer.Clock.TickCount - frmKlock.startTime, Environment.TickCount)
        Dim noDays As Integer
        Dim noHours As Integer
        Dim noMin As Integer
        Dim noSec As Integer

        noTicks = noTicks / 1000
        noDays = Int(noTicks / 86400)               '   no of days
        noTicks = noTicks - (noDays * 86400)
        noHours = Int(noTicks / 3600)               '   no of hours
        noTicks = noTicks - (noHours * 3600)
        noMin = Int(noTicks / 60)                   '   no of mins
        noTicks = noTicks - (noMin * 60)
        noSec = noTicks                             '   no of secs

        Return String.Format("{0} days  {1:00} hrs  {2:00} mins  {3:00} secs", noDays, noHours, noMin, noSec)
    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class