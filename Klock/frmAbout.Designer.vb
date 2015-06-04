<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnAboutClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblOSFullNameValue = New System.Windows.Forms.Label()
        Me.lblUserNameValue = New System.Windows.Forms.Label()
        Me.lblComputerNameValue = New System.Windows.Forms.Label()
        Me.lblNetworkAvailableValue = New System.Windows.Forms.Label()
        Me.lblProcessorNameValue = New System.Windows.Forms.Label()
        Me.lblComputerName = New System.Windows.Forms.Label()
        Me.lblProcessorName = New System.Windows.Forms.Label()
        Me.PrgrsBrVirtualMemory = New System.Windows.Forms.ProgressBar()
        Me.PrgrsBrPhysicalMemory = New System.Windows.Forms.ProgressBar()
        Me.PrgrsBrDriveSize = New System.Windows.Forms.ProgressBar()
        Me.lblVirtualMemoryValue = New System.Windows.Forms.Label()
        Me.lblPhysicalMemoryValue = New System.Windows.Forms.Label()
        Me.lblDriveSizeValue = New System.Windows.Forms.Label()
        Me.lblDriveSize = New System.Windows.Forms.Label()
        Me.lblNetworkAvailable = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblVirtualMemory = New System.Windows.Forms.Label()
        Me.lblPhysicalMemory = New System.Windows.Forms.Label()
        Me.lblOSFullName = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tmrAbout = New System.Windows.Forms.Timer(Me.components)
        Me.ChckBxAbtSwap = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblSystemUpTimeValue = New System.Windows.Forms.Label()
        Me.lblAppRunTimeValue = New System.Windows.Forms.Label()
        Me.lblSystemUpTime = New System.Windows.Forms.Label()
        Me.lblAppRunTime = New System.Windows.Forms.Label()
        Me.btnAboutMSinfo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(98, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(103, 39)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Klock"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(88, 58)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(122, 20)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "A Clock with a K"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblCopyright.Location = New System.Drawing.Point(49, 91)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(200, 20)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "Kevin Scott (c) 2012 - 2014"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblEmail.Location = New System.Drawing.Point(71, 128)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(157, 20)
        Me.lblEmail.TabIndex = 3
        Me.lblEmail.Text = "klock@keleven.co.uk"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblVersion.Location = New System.Drawing.Point(6, 164)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(81, 13)
        Me.lblVersion.TabIndex = 4
        Me.lblVersion.Text = "Klock Version ::"
        '
        'btnAboutClose
        '
        Me.btnAboutClose.Location = New System.Drawing.Point(236, 479)
        Me.btnAboutClose.Name = "btnAboutClose"
        Me.btnAboutClose.Size = New System.Drawing.Size(75, 23)
        Me.btnAboutClose.TabIndex = 1
        Me.btnAboutClose.Text = "Close"
        Me.btnAboutClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblOSFullNameValue)
        Me.GroupBox1.Controls.Add(Me.lblUserNameValue)
        Me.GroupBox1.Controls.Add(Me.lblComputerNameValue)
        Me.GroupBox1.Controls.Add(Me.lblNetworkAvailableValue)
        Me.GroupBox1.Controls.Add(Me.lblProcessorNameValue)
        Me.GroupBox1.Controls.Add(Me.lblComputerName)
        Me.GroupBox1.Controls.Add(Me.lblProcessorName)
        Me.GroupBox1.Controls.Add(Me.PrgrsBrVirtualMemory)
        Me.GroupBox1.Controls.Add(Me.PrgrsBrPhysicalMemory)
        Me.GroupBox1.Controls.Add(Me.PrgrsBrDriveSize)
        Me.GroupBox1.Controls.Add(Me.lblVirtualMemoryValue)
        Me.GroupBox1.Controls.Add(Me.lblPhysicalMemoryValue)
        Me.GroupBox1.Controls.Add(Me.lblDriveSizeValue)
        Me.GroupBox1.Controls.Add(Me.lblDriveSize)
        Me.GroupBox1.Controls.Add(Me.lblNetworkAvailable)
        Me.GroupBox1.Controls.Add(Me.lblUserName)
        Me.GroupBox1.Controls.Add(Me.lblVirtualMemory)
        Me.GroupBox1.Controls.Add(Me.lblPhysicalMemory)
        Me.GroupBox1.Controls.Add(Me.lblOSFullName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 193)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Details"
        '
        'lblOSFullNameValue
        '
        Me.lblOSFullNameValue.AutoSize = True
        Me.lblOSFullNameValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSFullNameValue.Location = New System.Drawing.Point(111, 25)
        Me.lblOSFullNameValue.Name = "lblOSFullNameValue"
        Me.lblOSFullNameValue.Size = New System.Drawing.Size(53, 13)
        Me.lblOSFullNameValue.TabIndex = 18
        Me.lblOSFullNameValue.Text = "OS Name"
        '
        'lblUserNameValue
        '
        Me.lblUserNameValue.AutoSize = True
        Me.lblUserNameValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserNameValue.Location = New System.Drawing.Point(111, 45)
        Me.lblUserNameValue.Name = "lblUserNameValue"
        Me.lblUserNameValue.Size = New System.Drawing.Size(60, 13)
        Me.lblUserNameValue.TabIndex = 17
        Me.lblUserNameValue.Text = "User Name"
        '
        'lblComputerNameValue
        '
        Me.lblComputerNameValue.AutoSize = True
        Me.lblComputerNameValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputerNameValue.Location = New System.Drawing.Point(111, 65)
        Me.lblComputerNameValue.Name = "lblComputerNameValue"
        Me.lblComputerNameValue.Size = New System.Drawing.Size(83, 13)
        Me.lblComputerNameValue.TabIndex = 16
        Me.lblComputerNameValue.Text = "Computer Name"
        '
        'lblNetworkAvailableValue
        '
        Me.lblNetworkAvailableValue.AutoSize = True
        Me.lblNetworkAvailableValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetworkAvailableValue.Location = New System.Drawing.Point(111, 85)
        Me.lblNetworkAvailableValue.Name = "lblNetworkAvailableValue"
        Me.lblNetworkAvailableValue.Size = New System.Drawing.Size(93, 13)
        Me.lblNetworkAvailableValue.TabIndex = 15
        Me.lblNetworkAvailableValue.Text = "Network Available"
        '
        'lblProcessorNameValue
        '
        Me.lblProcessorNameValue.AutoSize = True
        Me.lblProcessorNameValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessorNameValue.Location = New System.Drawing.Point(111, 105)
        Me.lblProcessorNameValue.Name = "lblProcessorNameValue"
        Me.lblProcessorNameValue.Size = New System.Drawing.Size(82, 13)
        Me.lblProcessorNameValue.TabIndex = 14
        Me.lblProcessorNameValue.Text = "ProcessorName"
        '
        'lblComputerName
        '
        Me.lblComputerName.AutoSize = True
        Me.lblComputerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputerName.Location = New System.Drawing.Point(6, 65)
        Me.lblComputerName.Name = "lblComputerName"
        Me.lblComputerName.Size = New System.Drawing.Size(83, 13)
        Me.lblComputerName.TabIndex = 13
        Me.lblComputerName.Text = "Computer Name"
        '
        'lblProcessorName
        '
        Me.lblProcessorName.AutoSize = True
        Me.lblProcessorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblProcessorName.Location = New System.Drawing.Point(5, 105)
        Me.lblProcessorName.Name = "lblProcessorName"
        Me.lblProcessorName.Size = New System.Drawing.Size(85, 13)
        Me.lblProcessorName.TabIndex = 12
        Me.lblProcessorName.Text = "Processor Name"
        '
        'PrgrsBrVirtualMemory
        '
        Me.PrgrsBrVirtualMemory.Location = New System.Drawing.Point(111, 171)
        Me.PrgrsBrVirtualMemory.Name = "PrgrsBrVirtualMemory"
        Me.PrgrsBrVirtualMemory.Size = New System.Drawing.Size(182, 10)
        Me.PrgrsBrVirtualMemory.TabIndex = 11
        '
        'PrgrsBrPhysicalMemory
        '
        Me.PrgrsBrPhysicalMemory.Location = New System.Drawing.Point(111, 152)
        Me.PrgrsBrPhysicalMemory.Name = "PrgrsBrPhysicalMemory"
        Me.PrgrsBrPhysicalMemory.Size = New System.Drawing.Size(182, 10)
        Me.PrgrsBrPhysicalMemory.TabIndex = 10
        '
        'PrgrsBrDriveSize
        '
        Me.PrgrsBrDriveSize.Location = New System.Drawing.Point(111, 133)
        Me.PrgrsBrDriveSize.Name = "PrgrsBrDriveSize"
        Me.PrgrsBrDriveSize.Size = New System.Drawing.Size(182, 10)
        Me.PrgrsBrDriveSize.TabIndex = 9
        '
        'lblVirtualMemoryValue
        '
        Me.lblVirtualMemoryValue.AutoSize = True
        Me.lblVirtualMemoryValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblVirtualMemoryValue.Location = New System.Drawing.Point(111, 171)
        Me.lblVirtualMemoryValue.Name = "lblVirtualMemoryValue"
        Me.lblVirtualMemoryValue.Size = New System.Drawing.Size(0, 13)
        Me.lblVirtualMemoryValue.TabIndex = 8
        '
        'lblPhysicalMemoryValue
        '
        Me.lblPhysicalMemoryValue.AutoSize = True
        Me.lblPhysicalMemoryValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblPhysicalMemoryValue.Location = New System.Drawing.Point(111, 152)
        Me.lblPhysicalMemoryValue.Name = "lblPhysicalMemoryValue"
        Me.lblPhysicalMemoryValue.Size = New System.Drawing.Size(0, 13)
        Me.lblPhysicalMemoryValue.TabIndex = 7
        '
        'lblDriveSizeValue
        '
        Me.lblDriveSizeValue.AutoSize = True
        Me.lblDriveSizeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblDriveSizeValue.Location = New System.Drawing.Point(111, 133)
        Me.lblDriveSizeValue.Name = "lblDriveSizeValue"
        Me.lblDriveSizeValue.Size = New System.Drawing.Size(0, 13)
        Me.lblDriveSizeValue.TabIndex = 6
        '
        'lblDriveSize
        '
        Me.lblDriveSize.AutoSize = True
        Me.lblDriveSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblDriveSize.Location = New System.Drawing.Point(6, 130)
        Me.lblDriveSize.Name = "lblDriveSize"
        Me.lblDriveSize.Size = New System.Drawing.Size(52, 13)
        Me.lblDriveSize.TabIndex = 5
        Me.lblDriveSize.Text = "DriveSize"
        '
        'lblNetworkAvailable
        '
        Me.lblNetworkAvailable.AutoSize = True
        Me.lblNetworkAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblNetworkAvailable.Location = New System.Drawing.Point(6, 85)
        Me.lblNetworkAvailable.Name = "lblNetworkAvailable"
        Me.lblNetworkAvailable.Size = New System.Drawing.Size(90, 13)
        Me.lblNetworkAvailable.TabIndex = 4
        Me.lblNetworkAvailable.Text = "NetworkAvailable"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblUserName.Location = New System.Drawing.Point(6, 45)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(57, 13)
        Me.lblUserName.TabIndex = 3
        Me.lblUserName.Text = "UserName"
        '
        'lblVirtualMemory
        '
        Me.lblVirtualMemory.AutoSize = True
        Me.lblVirtualMemory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblVirtualMemory.Location = New System.Drawing.Point(6, 171)
        Me.lblVirtualMemory.Name = "lblVirtualMemory"
        Me.lblVirtualMemory.Size = New System.Drawing.Size(73, 13)
        Me.lblVirtualMemory.TabIndex = 2
        Me.lblVirtualMemory.Text = "VirtualMemory"
        '
        'lblPhysicalMemory
        '
        Me.lblPhysicalMemory.AutoSize = True
        Me.lblPhysicalMemory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblPhysicalMemory.Location = New System.Drawing.Point(6, 149)
        Me.lblPhysicalMemory.Name = "lblPhysicalMemory"
        Me.lblPhysicalMemory.Size = New System.Drawing.Size(83, 13)
        Me.lblPhysicalMemory.TabIndex = 1
        Me.lblPhysicalMemory.Text = "PhysicalMemory"
        '
        'lblOSFullName
        '
        Me.lblOSFullName.AutoSize = True
        Me.lblOSFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblOSFullName.Location = New System.Drawing.Point(6, 25)
        Me.lblOSFullName.Name = "lblOSFullName"
        Me.lblOSFullName.Size = New System.Drawing.Size(53, 13)
        Me.lblOSFullName.TabIndex = 0
        Me.lblOSFullName.Text = "OS Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTitle)
        Me.GroupBox2.Controls.Add(Me.lblVersion)
        Me.GroupBox2.Controls.Add(Me.lblEmail)
        Me.GroupBox2.Controls.Add(Me.lblCopyright)
        Me.GroupBox2.Controls.Add(Me.lblDescription)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 190)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Application Details"
        '
        'tmrAbout
        '
        '
        'ChckBxAbtSwap
        '
        Me.ChckBxAbtSwap.AutoSize = True
        Me.ChckBxAbtSwap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.ChckBxAbtSwap.Location = New System.Drawing.Point(23, 485)
        Me.ChckBxAbtSwap.Name = "ChckBxAbtSwap"
        Me.ChckBxAbtSwap.Size = New System.Drawing.Size(47, 17)
        Me.ChckBxAbtSwap.TabIndex = 6
        Me.ChckBxAbtSwap.Text = "Text"
        Me.ChckBxAbtSwap.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblSystemUpTimeValue)
        Me.GroupBox3.Controls.Add(Me.lblAppRunTimeValue)
        Me.GroupBox3.Controls.Add(Me.lblSystemUpTime)
        Me.GroupBox3.Controls.Add(Me.lblAppRunTime)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 407)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(299, 66)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Time"
        '
        'lblSystemUpTimeValue
        '
        Me.lblSystemUpTimeValue.AutoSize = True
        Me.lblSystemUpTimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemUpTimeValue.Location = New System.Drawing.Point(111, 38)
        Me.lblSystemUpTimeValue.Name = "lblSystemUpTimeValue"
        Me.lblSystemUpTimeValue.Size = New System.Drawing.Size(49, 13)
        Me.lblSystemUpTimeValue.TabIndex = 3
        Me.lblSystemUpTimeValue.Text = "00:00:00"
        '
        'lblAppRunTimeValue
        '
        Me.lblAppRunTimeValue.AutoSize = True
        Me.lblAppRunTimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppRunTimeValue.Location = New System.Drawing.Point(111, 16)
        Me.lblAppRunTimeValue.Name = "lblAppRunTimeValue"
        Me.lblAppRunTimeValue.Size = New System.Drawing.Size(49, 13)
        Me.lblAppRunTimeValue.TabIndex = 2
        Me.lblAppRunTimeValue.Text = "00:00:00"
        '
        'lblSystemUpTime
        '
        Me.lblSystemUpTime.AutoSize = True
        Me.lblSystemUpTime.Location = New System.Drawing.Point(6, 38)
        Me.lblSystemUpTime.Name = "lblSystemUpTime"
        Me.lblSystemUpTime.Size = New System.Drawing.Size(84, 13)
        Me.lblSystemUpTime.TabIndex = 1
        Me.lblSystemUpTime.Text = "System Up Time"
        '
        'lblAppRunTime
        '
        Me.lblAppRunTime.AutoSize = True
        Me.lblAppRunTime.Location = New System.Drawing.Point(6, 16)
        Me.lblAppRunTime.Name = "lblAppRunTime"
        Me.lblAppRunTime.Size = New System.Drawing.Size(75, 13)
        Me.lblAppRunTime.TabIndex = 0
        Me.lblAppRunTime.Text = "App Run Time"
        '
        'btnAboutMSinfo
        '
        Me.btnAboutMSinfo.Location = New System.Drawing.Point(155, 479)
        Me.btnAboutMSinfo.Name = "btnAboutMSinfo"
        Me.btnAboutMSinfo.Size = New System.Drawing.Size(75, 23)
        Me.btnAboutMSinfo.TabIndex = 8
        Me.btnAboutMSinfo.Text = "MSinfo"
        Me.btnAboutMSinfo.UseVisualStyleBackColor = True
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 514)
        Me.Controls.Add(Me.btnAboutMSinfo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ChckBxAbtSwap)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAboutClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnAboutClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPhysicalMemory As System.Windows.Forms.Label
    Friend WithEvents lblOSFullName As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblVirtualMemory As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblNetworkAvailable As System.Windows.Forms.Label
    Friend WithEvents lblDriveSize As System.Windows.Forms.Label
    Friend WithEvents tmrAbout As System.Windows.Forms.Timer
    Friend WithEvents ChckBxAbtSwap As System.Windows.Forms.CheckBox
    Friend WithEvents lblVirtualMemoryValue As System.Windows.Forms.Label
    Friend WithEvents lblPhysicalMemoryValue As System.Windows.Forms.Label
    Friend WithEvents lblDriveSizeValue As System.Windows.Forms.Label
    Friend WithEvents PrgrsBrVirtualMemory As System.Windows.Forms.ProgressBar
    Friend WithEvents PrgrsBrPhysicalMemory As System.Windows.Forms.ProgressBar
    Friend WithEvents PrgrsBrDriveSize As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcessorName As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSystemUpTime As System.Windows.Forms.Label
    Friend WithEvents lblAppRunTime As System.Windows.Forms.Label
    Friend WithEvents btnAboutMSinfo As System.Windows.Forms.Button
    Friend WithEvents lblComputerName As System.Windows.Forms.Label
    Friend WithEvents lblSystemUpTimeValue As System.Windows.Forms.Label
    Friend WithEvents lblAppRunTimeValue As System.Windows.Forms.Label
    Friend WithEvents lblProcessorNameValue As System.Windows.Forms.Label
    Friend WithEvents lblNetworkAvailableValue As System.Windows.Forms.Label
    Friend WithEvents lblComputerNameValue As System.Windows.Forms.Label
    Friend WithEvents lblUserNameValue As System.Windows.Forms.Label
    Friend WithEvents lblOSFullNameValue As System.Windows.Forms.Label
End Class
