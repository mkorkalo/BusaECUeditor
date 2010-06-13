<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.Button_fuelmap = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Enginedata = New System.Windows.Forms.Button
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewK8ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewStockBkingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewStockBkingUSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenComparemapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProgramInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HomepageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InstallFTDIDriversToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetupCOMPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FlashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerifyChecksumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerifyECUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FullEraseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FlashTheECUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.B_limiters = New System.Windows.Forms.Button
        Me.B_FlashECU = New System.Windows.Forms.Button
        Me.Button_Ignitionmap = New System.Windows.Forms.Button
        Me.B_miscsettings = New System.Windows.Forms.Button
        Me.L_File = New System.Windows.Forms.Label
        Me.L_Comparefile = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.B_shifter = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ECUID = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Hayabusa = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.Linklabel_program_homepage = New System.Windows.Forms.LinkLabel
        Me.MenuStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_fuelmap
        '
        Me.Button_fuelmap.Enabled = False
        Me.Button_fuelmap.Location = New System.Drawing.Point(285, 36)
        Me.Button_fuelmap.Name = "Button_fuelmap"
        Me.Button_fuelmap.Size = New System.Drawing.Size(86, 44)
        Me.Button_fuelmap.TabIndex = 10
        Me.Button_fuelmap.Text = "Edit Fuel map(s)"
        Me.ToolTip1.SetToolTip(Me.Button_fuelmap, "EDIT Fuelmaps")
        Me.Button_fuelmap.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Enginedata
        '
        Me.Enginedata.Location = New System.Drawing.Point(377, 36)
        Me.Enginedata.Name = "Enginedata"
        Me.Enginedata.Size = New System.Drawing.Size(86, 44)
        Me.Enginedata.TabIndex = 20
        Me.Enginedata.Text = "Connect for engine data"
        Me.ToolTip1.SetToolTip(Me.Enginedata, "Connect to engine data  - requires the interface cable")
        Me.Enginedata.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem1, Me.UpdatesToolStripMenuItem, Me.SetupToolStripMenuItem, Me.FlashToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(474, 24)
        Me.MenuStrip.TabIndex = 21
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.NewK8ToolStripMenuItem, Me.NewStockBkingToolStripMenuItem, Me.NewStockBkingUSToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.OpenComparemapToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.NewToolStripMenuItem.Text = "New/Stock K2-K7"
        '
        'NewK8ToolStripMenuItem
        '
        Me.NewK8ToolStripMenuItem.Name = "NewK8ToolStripMenuItem"
        Me.NewK8ToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.NewK8ToolStripMenuItem.Text = "New/Stock K8-.."
        '
        'NewStockBkingToolStripMenuItem
        '
        Me.NewStockBkingToolStripMenuItem.Name = "NewStockBkingToolStripMenuItem"
        Me.NewStockBkingToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.NewStockBkingToolStripMenuItem.Text = "New/Stock Bking (EU/AU)"
        '
        'NewStockBkingUSToolStripMenuItem
        '
        Me.NewStockBkingUSToolStripMenuItem.Name = "NewStockBkingUSToolStripMenuItem"
        Me.NewStockBkingUSToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.NewStockBkingUSToolStripMenuItem.Text = "New/Stock Bking (US)"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'OpenComparemapToolStripMenuItem
        '
        Me.OpenComparemapToolStripMenuItem.Name = "OpenComparemapToolStripMenuItem"
        Me.OpenComparemapToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.OpenComparemapToolStripMenuItem.Text = "Set comparemap"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramInfoToolStripMenuItem, Me.VersionToolStripMenuItem})
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'ProgramInfoToolStripMenuItem
        '
        Me.ProgramInfoToolStripMenuItem.Name = "ProgramInfoToolStripMenuItem"
        Me.ProgramInfoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ProgramInfoToolStripMenuItem.Text = "Program info"
        '
        'VersionToolStripMenuItem
        '
        Me.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
        Me.VersionToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.VersionToolStripMenuItem.Text = "Version"
        '
        'UpdatesToolStripMenuItem
        '
        Me.UpdatesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomepageToolStripMenuItem})
        Me.UpdatesToolStripMenuItem.Name = "UpdatesToolStripMenuItem"
        Me.UpdatesToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.UpdatesToolStripMenuItem.Text = "Updates"
        '
        'HomepageToolStripMenuItem
        '
        Me.HomepageToolStripMenuItem.Name = "HomepageToolStripMenuItem"
        Me.HomepageToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.HomepageToolStripMenuItem.Text = "Program update homepage"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallFTDIDriversToolStripMenuItem, Me.SetupCOMPortToolStripMenuItem})
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.SetupToolStripMenuItem.Text = "Setup"
        '
        'InstallFTDIDriversToolStripMenuItem
        '
        Me.InstallFTDIDriversToolStripMenuItem.Name = "InstallFTDIDriversToolStripMenuItem"
        Me.InstallFTDIDriversToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.InstallFTDIDriversToolStripMenuItem.Text = "Install COM port drivers"
        '
        'SetupCOMPortToolStripMenuItem
        '
        Me.SetupCOMPortToolStripMenuItem.Name = "SetupCOMPortToolStripMenuItem"
        Me.SetupCOMPortToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SetupCOMPortToolStripMenuItem.Text = "Setup COM port"
        '
        'FlashToolStripMenuItem
        '
        Me.FlashToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerifyChecksumToolStripMenuItem, Me.VerifyECUToolStripMenuItem, Me.FullEraseToolStripMenuItem, Me.FlashTheECUToolStripMenuItem})
        Me.FlashToolStripMenuItem.Name = "FlashToolStripMenuItem"
        Me.FlashToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.FlashToolStripMenuItem.Text = "Flash"
        '
        'VerifyChecksumToolStripMenuItem
        '
        Me.VerifyChecksumToolStripMenuItem.Name = "VerifyChecksumToolStripMenuItem"
        Me.VerifyChecksumToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.VerifyChecksumToolStripMenuItem.Text = "Verify Checksum"
        '
        'VerifyECUToolStripMenuItem
        '
        Me.VerifyECUToolStripMenuItem.Name = "VerifyECUToolStripMenuItem"
        Me.VerifyECUToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.VerifyECUToolStripMenuItem.Text = "Verify ECU"
        '
        'FullEraseToolStripMenuItem
        '
        Me.FullEraseToolStripMenuItem.Name = "FullEraseToolStripMenuItem"
        Me.FullEraseToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.FullEraseToolStripMenuItem.Text = "Full Erase"
        '
        'FlashTheECUToolStripMenuItem
        '
        Me.FlashTheECUToolStripMenuItem.Name = "FlashTheECUToolStripMenuItem"
        Me.FlashTheECUToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.FlashTheECUToolStripMenuItem.Text = "Flash the ECU"
        '
        'B_limiters
        '
        Me.B_limiters.Location = New System.Drawing.Point(285, 135)
        Me.B_limiters.Name = "B_limiters"
        Me.B_limiters.Size = New System.Drawing.Size(86, 43)
        Me.B_limiters.TabIndex = 23
        Me.B_limiters.Text = "Edit Limiters"
        Me.ToolTip1.SetToolTip(Me.B_limiters, "Edit RPM limiters, set top speed limiter on/off")
        Me.B_limiters.UseVisualStyleBackColor = True
        '
        'B_FlashECU
        '
        Me.B_FlashECU.Location = New System.Drawing.Point(285, 184)
        Me.B_FlashECU.Name = "B_FlashECU"
        Me.B_FlashECU.Size = New System.Drawing.Size(86, 44)
        Me.B_FlashECU.TabIndex = 24
        Me.B_FlashECU.Text = "Flash the ECU"
        Me.ToolTip1.SetToolTip(Me.B_FlashECU, "Flash the active map in memory to the ECU." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Requires a programming interface sw" & _
                "hitch.")
        Me.B_FlashECU.UseVisualStyleBackColor = True
        '
        'Button_Ignitionmap
        '
        Me.Button_Ignitionmap.Location = New System.Drawing.Point(285, 86)
        Me.Button_Ignitionmap.Name = "Button_Ignitionmap"
        Me.Button_Ignitionmap.Size = New System.Drawing.Size(86, 43)
        Me.Button_Ignitionmap.TabIndex = 25
        Me.Button_Ignitionmap.Text = "Edit Ignition map(s)"
        Me.ToolTip1.SetToolTip(Me.Button_Ignitionmap, "Edit Ignition maps")
        Me.Button_Ignitionmap.UseVisualStyleBackColor = True
        '
        'B_miscsettings
        '
        Me.B_miscsettings.Location = New System.Drawing.Point(377, 86)
        Me.B_miscsettings.Name = "B_miscsettings"
        Me.B_miscsettings.Size = New System.Drawing.Size(86, 43)
        Me.B_miscsettings.TabIndex = 26
        Me.B_miscsettings.Text = "Advanced settings"
        Me.ToolTip1.SetToolTip(Me.B_miscsettings, "Set various advanced settings including" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fuel pressure, activation of window swit" & _
                "ch solenoid etc...")
        Me.B_miscsettings.UseVisualStyleBackColor = True
        '
        'L_File
        '
        Me.L_File.AutoSize = True
        Me.L_File.Location = New System.Drawing.Point(67, 26)
        Me.L_File.Name = "L_File"
        Me.L_File.Size = New System.Drawing.Size(127, 13)
        Me.L_File.TabIndex = 28
        Me.L_File.Text = "File not yet opened          "
        Me.ToolTip1.SetToolTip(Me.L_File, "Name of the open map file")
        '
        'L_Comparefile
        '
        Me.L_Comparefile.AutoSize = True
        Me.L_Comparefile.Location = New System.Drawing.Point(67, 51)
        Me.L_Comparefile.Name = "L_Comparefile"
        Me.L_Comparefile.Size = New System.Drawing.Size(127, 13)
        Me.L_Comparefile.TabIndex = 29
        Me.L_Comparefile.Text = "File not yet opened          "
        Me.ToolTip1.SetToolTip(Me.L_Comparefile, resources.GetString("L_Comparefile.ToolTip"))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Filename"
        Me.ToolTip1.SetToolTip(Me.Label2, "Name of the open map file")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Compare"
        Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'B_shifter
        '
        Me.B_shifter.Location = New System.Drawing.Point(377, 135)
        Me.B_shifter.Name = "B_shifter"
        Me.B_shifter.Size = New System.Drawing.Size(86, 43)
        Me.B_shifter.TabIndex = 32
        Me.B_shifter.Text = "Shifter"
        Me.ToolTip1.SetToolTip(Me.B_shifter, "Activate shifter module and set shifter kill time." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Requires shifter hardware bei" & _
                "ng connected")
        Me.B_shifter.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.L_File)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.L_Comparefile)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 73)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Map file Info"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ECUID)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Hayabusa)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 77)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bike info"
        '
        'ECUID
        '
        Me.ECUID.AutoSize = True
        Me.ECUID.Location = New System.Drawing.Point(67, 51)
        Me.ECUID.Name = "ECUID"
        Me.ECUID.Size = New System.Drawing.Size(16, 13)
        Me.ECUID.TabIndex = 23
        Me.ECUID.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Model"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ECU ID"
        '
        'Hayabusa
        '
        Me.Hayabusa.AutoSize = True
        Me.Hayabusa.Location = New System.Drawing.Point(67, 21)
        Me.Hayabusa.Name = "Hayabusa"
        Me.Hayabusa.Size = New System.Drawing.Size(55, 13)
        Me.Hayabusa.TabIndex = 12
        Me.Hayabusa.Text = "Hayabusa"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 344)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(487, 83)
        Me.WebBrowser1.TabIndex = 36
        Me.WebBrowser1.Url = New System.Uri("http://www.dolphinwebdevelopment.com/dolphin-web/dolphin/banner_blue.gif", System.UriKind.Absolute)
        '
        'Linklabel_program_homepage
        '
        Me.Linklabel_program_homepage.ActiveLinkColor = System.Drawing.Color.DimGray
        Me.Linklabel_program_homepage.AutoSize = True
        Me.Linklabel_program_homepage.LinkColor = System.Drawing.Color.Black
        Me.Linklabel_program_homepage.Location = New System.Drawing.Point(18, 215)
        Me.Linklabel_program_homepage.Name = "Linklabel_program_homepage"
        Me.Linklabel_program_homepage.Size = New System.Drawing.Size(215, 13)
        Me.Linklabel_program_homepage.TabIndex = 37
        Me.Linklabel_program_homepage.TabStop = True
        Me.Linklabel_program_homepage.Text = "Click here to visit: http//www.ecueditor.com"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(474, 240)
        Me.Controls.Add(Me.Linklabel_program_homepage)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.B_shifter)
        Me.Controls.Add(Me.B_miscsettings)
        Me.Controls.Add(Me.Button_Ignitionmap)
        Me.Controls.Add(Me.B_FlashECU)
        Me.Controls.Add(Me.B_limiters)
        Me.Controls.Add(Me.Enginedata)
        Me.Controls.Add(Me.Button_fuelmap)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "main"
        Me.Text = "Hayabusa ECUeditor.com for K2-K7, K8-.. , BKing (by PetriK) - testversion"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_fuelmap As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Enginedata As System.Windows.Forms.Button
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents B_limiters As System.Windows.Forms.Button
    Friend WithEvents B_FlashECU As System.Windows.Forms.Button
    Friend WithEvents HomepageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button_Ignitionmap As System.Windows.Forms.Button
    Friend WithEvents B_miscsettings As System.Windows.Forms.Button
    Friend WithEvents OpenComparemapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents L_File As System.Windows.Forms.Label
    Friend WithEvents L_Comparefile As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents B_shifter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Hayabusa As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgramInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewK8ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents SetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstallFTDIDriversToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupCOMPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlashToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerifyChecksumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerifyECUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullEraseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlashTheECUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewStockBkingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewStockBkingUSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Linklabel_program_homepage As System.Windows.Forms.LinkLabel
    Friend WithEvents ECUID As System.Windows.Forms.Label

End Class
