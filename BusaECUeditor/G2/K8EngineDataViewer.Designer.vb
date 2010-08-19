<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8EngineDataViewer
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
        Me.LV_ValueDetails = New System.Windows.Forms.ListView
        Me.Column1 = New System.Windows.Forms.ColumnHeader
        Me.Column2 = New System.Windows.Forms.ColumnHeader
        Me.L_MinTPS = New System.Windows.Forms.Label
        Me.N_MinTPS = New System.Windows.Forms.NumericUpDown
        Me.B_BOOST_RPM = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.B_IAP_RPM = New System.Windows.Forms.Button
        Me.B_TPS_RPM = New System.Windows.Forms.Button
        Me.LB_Values = New System.Windows.Forms.ListBox
        Me.G_FuelMap = New System.Windows.Forms.DataGridView
        Me.B_LoadDataFile = New System.Windows.Forms.Button
        Me.L_FileName = New System.Windows.Forms.Label
        Me.L_DataCount = New System.Windows.Forms.Label
        Me.C_WidebandO2Sensor = New System.Windows.Forms.CheckBox
        Me.B_DataFilters = New System.Windows.Forms.Button
        CType(Me.N_MinTPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.G_FuelMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LV_ValueDetails
        '
        Me.LV_ValueDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Column1, Me.Column2})
        Me.LV_ValueDetails.Location = New System.Drawing.Point(897, 303)
        Me.LV_ValueDetails.Name = "LV_ValueDetails"
        Me.LV_ValueDetails.Size = New System.Drawing.Size(168, 382)
        Me.LV_ValueDetails.TabIndex = 21
        Me.LV_ValueDetails.UseCompatibleStateImageBehavior = False
        Me.LV_ValueDetails.View = System.Windows.Forms.View.Details
        '
        'Column1
        '
        Me.Column1.Text = "Name"
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.Text = "Value"
        Me.Column2.Width = 90
        '
        'L_MinTPS
        '
        Me.L_MinTPS.AutoSize = True
        Me.L_MinTPS.Location = New System.Drawing.Point(967, 9)
        Me.L_MinTPS.Name = "L_MinTPS"
        Me.L_MinTPS.Size = New System.Drawing.Size(37, 13)
        Me.L_MinTPS.TabIndex = 20
        Me.L_MinTPS.Text = "TPS >"
        Me.L_MinTPS.Visible = False
        '
        'N_MinTPS
        '
        Me.N_MinTPS.Location = New System.Drawing.Point(1010, 7)
        Me.N_MinTPS.Name = "N_MinTPS"
        Me.N_MinTPS.Size = New System.Drawing.Size(52, 20)
        Me.N_MinTPS.TabIndex = 19
        Me.N_MinTPS.Value = New Decimal(New Integer() {11, 0, 0, 0})
        Me.N_MinTPS.Visible = False
        '
        'B_BOOST_RPM
        '
        Me.B_BOOST_RPM.Location = New System.Drawing.Point(888, 4)
        Me.B_BOOST_RPM.Name = "B_BOOST_RPM"
        Me.B_BOOST_RPM.Size = New System.Drawing.Size(75, 23)
        Me.B_BOOST_RPM.TabIndex = 18
        Me.B_BOOST_RPM.Text = "Boost"
        Me.B_BOOST_RPM.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'B_IAP_RPM
        '
        Me.B_IAP_RPM.Location = New System.Drawing.Point(807, 4)
        Me.B_IAP_RPM.Name = "B_IAP_RPM"
        Me.B_IAP_RPM.Size = New System.Drawing.Size(75, 23)
        Me.B_IAP_RPM.TabIndex = 17
        Me.B_IAP_RPM.Text = "IAP/RPM"
        Me.B_IAP_RPM.UseVisualStyleBackColor = True
        '
        'B_TPS_RPM
        '
        Me.B_TPS_RPM.Location = New System.Drawing.Point(726, 4)
        Me.B_TPS_RPM.Name = "B_TPS_RPM"
        Me.B_TPS_RPM.Size = New System.Drawing.Size(75, 23)
        Me.B_TPS_RPM.TabIndex = 16
        Me.B_TPS_RPM.Text = "TPS/RPM"
        Me.B_TPS_RPM.UseVisualStyleBackColor = True
        '
        'LB_Values
        '
        Me.LB_Values.FormattingEnabled = True
        Me.LB_Values.Location = New System.Drawing.Point(897, 33)
        Me.LB_Values.Name = "LB_Values"
        Me.LB_Values.Size = New System.Drawing.Size(168, 264)
        Me.LB_Values.TabIndex = 15
        '
        'G_FuelMap
        '
        Me.G_FuelMap.AllowUserToAddRows = False
        Me.G_FuelMap.AllowUserToDeleteRows = False
        Me.G_FuelMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.G_FuelMap.Location = New System.Drawing.Point(5, 58)
        Me.G_FuelMap.Name = "G_FuelMap"
        Me.G_FuelMap.Size = New System.Drawing.Size(886, 624)
        Me.G_FuelMap.TabIndex = 14
        '
        'B_LoadDataFile
        '
        Me.B_LoadDataFile.Location = New System.Drawing.Point(5, 4)
        Me.B_LoadDataFile.Name = "B_LoadDataFile"
        Me.B_LoadDataFile.Size = New System.Drawing.Size(99, 23)
        Me.B_LoadDataFile.TabIndex = 13
        Me.B_LoadDataFile.Text = "Load Data File"
        Me.B_LoadDataFile.UseVisualStyleBackColor = True
        '
        'L_FileName
        '
        Me.L_FileName.AutoSize = True
        Me.L_FileName.Location = New System.Drawing.Point(110, 9)
        Me.L_FileName.Name = "L_FileName"
        Me.L_FileName.Size = New System.Drawing.Size(10, 13)
        Me.L_FileName.TabIndex = 22
        Me.L_FileName.Text = "-"
        '
        'L_DataCount
        '
        Me.L_DataCount.Location = New System.Drawing.Point(536, 7)
        Me.L_DataCount.Name = "L_DataCount"
        Me.L_DataCount.Size = New System.Drawing.Size(184, 18)
        Me.L_DataCount.TabIndex = 23
        Me.L_DataCount.Text = "-"
        Me.L_DataCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'C_WidebandO2Sensor
        '
        Me.C_WidebandO2Sensor.AutoSize = True
        Me.C_WidebandO2Sensor.Location = New System.Drawing.Point(5, 33)
        Me.C_WidebandO2Sensor.Name = "C_WidebandO2Sensor"
        Me.C_WidebandO2Sensor.Size = New System.Drawing.Size(128, 17)
        Me.C_WidebandO2Sensor.TabIndex = 24
        Me.C_WidebandO2Sensor.Text = "Wideband O2 Sensor"
        Me.C_WidebandO2Sensor.UseVisualStyleBackColor = True
        '
        'B_DataFilters
        '
        Me.B_DataFilters.Location = New System.Drawing.Point(129, 29)
        Me.B_DataFilters.Name = "B_DataFilters"
        Me.B_DataFilters.Size = New System.Drawing.Size(75, 23)
        Me.B_DataFilters.TabIndex = 25
        Me.B_DataFilters.Text = "Data Filters"
        Me.B_DataFilters.UseVisualStyleBackColor = True
        '
        'K8EngineDataViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 694)
        Me.Controls.Add(Me.B_DataFilters)
        Me.Controls.Add(Me.C_WidebandO2Sensor)
        Me.Controls.Add(Me.L_DataCount)
        Me.Controls.Add(Me.L_FileName)
        Me.Controls.Add(Me.LV_ValueDetails)
        Me.Controls.Add(Me.L_MinTPS)
        Me.Controls.Add(Me.N_MinTPS)
        Me.Controls.Add(Me.B_BOOST_RPM)
        Me.Controls.Add(Me.B_IAP_RPM)
        Me.Controls.Add(Me.B_TPS_RPM)
        Me.Controls.Add(Me.LB_Values)
        Me.Controls.Add(Me.G_FuelMap)
        Me.Controls.Add(Me.B_LoadDataFile)
        Me.Name = "K8EngineDataViewer"
        Me.Text = "K8 Engine Data Viewer"
        CType(Me.N_MinTPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.G_FuelMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LV_ValueDetails As System.Windows.Forms.ListView
    Friend WithEvents Column1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Column2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents L_MinTPS As System.Windows.Forms.Label
    Friend WithEvents N_MinTPS As System.Windows.Forms.NumericUpDown
    Friend WithEvents B_BOOST_RPM As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents B_IAP_RPM As System.Windows.Forms.Button
    Friend WithEvents B_TPS_RPM As System.Windows.Forms.Button
    Friend WithEvents LB_Values As System.Windows.Forms.ListBox
    Friend WithEvents G_FuelMap As System.Windows.Forms.DataGridView
    Friend WithEvents B_LoadDataFile As System.Windows.Forms.Button
    Friend WithEvents L_FileName As System.Windows.Forms.Label
    Friend WithEvents L_DataCount As System.Windows.Forms.Label
    Friend WithEvents C_WidebandO2Sensor As System.Windows.Forms.CheckBox
    Friend WithEvents B_DataFilters As System.Windows.Forms.Button
End Class
