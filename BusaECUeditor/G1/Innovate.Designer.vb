<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Innovate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Innovate))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.MTS1 = New AxMTSSDKLib.AxMTS
        Me.ConnectButton = New System.Windows.Forms.Button
        Me.Channelvalue = New System.Windows.Forms.Label
        Me.InputDetails = New System.Windows.Forms.Label
        Me.Portlist = New System.Windows.Forms.ComboBox
        Me.LED_AFR = New LxControl.LxLedControl
        CType(Me.MTS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LED_AFR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(212, 71)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(70, 26)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Close"
        '
        'MTS1
        '
        Me.MTS1.Enabled = True
        Me.MTS1.Location = New System.Drawing.Point(379, 12)
        Me.MTS1.Name = "MTS1"
        Me.MTS1.OcxState = CType(resources.GetObject("MTS1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MTS1.Size = New System.Drawing.Size(192, 192)
        Me.MTS1.TabIndex = 1
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(212, 39)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(70, 26)
        Me.ConnectButton.TabIndex = 3
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'Channelvalue
        '
        Me.Channelvalue.AutoSize = True
        Me.Channelvalue.Location = New System.Drawing.Point(12, 109)
        Me.Channelvalue.Name = "Channelvalue"
        Me.Channelvalue.Size = New System.Drawing.Size(72, 13)
        Me.Channelvalue.TabIndex = 4
        Me.Channelvalue.Text = "Channelvalue"
        '
        'InputDetails
        '
        Me.InputDetails.AutoSize = True
        Me.InputDetails.Location = New System.Drawing.Point(12, 135)
        Me.InputDetails.Name = "InputDetails"
        Me.InputDetails.Size = New System.Drawing.Size(61, 13)
        Me.InputDetails.TabIndex = 5
        Me.InputDetails.Text = "Inputdetails"
        '
        'Portlist
        '
        Me.Portlist.FormattingEnabled = True
        Me.Portlist.Location = New System.Drawing.Point(212, 12)
        Me.Portlist.Name = "Portlist"
        Me.Portlist.Size = New System.Drawing.Size(70, 21)
        Me.Portlist.TabIndex = 6
        '
        'LED_AFR
        '
        Me.LED_AFR.BackColor = System.Drawing.Color.Transparent
        Me.LED_AFR.BackColor_1 = System.Drawing.Color.Black
        Me.LED_AFR.BackColor_2 = System.Drawing.Color.DimGray
        Me.LED_AFR.BevelRate = 0.5!
        Me.LED_AFR.FadedColor = System.Drawing.Color.Black
        Me.LED_AFR.ForeColor = System.Drawing.Color.White
        Me.LED_AFR.HighlightOpaque = CType(50, Byte)
        Me.LED_AFR.Location = New System.Drawing.Point(12, 12)
        Me.LED_AFR.Name = "LED_AFR"
        Me.LED_AFR.Size = New System.Drawing.Size(182, 85)
        Me.LED_AFR.TabIndex = 61
        Me.LED_AFR.Text = "-"
        Me.LED_AFR.TextAlignment = LxControl.LxLedControl.Alignment.Right
        Me.LED_AFR.TotalCharCount = 4
        '
        'Innovate
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 159)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.LED_AFR)
        Me.Controls.Add(Me.Portlist)
        Me.Controls.Add(Me.InputDetails)
        Me.Controls.Add(Me.Channelvalue)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.MTS1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Innovate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Innovate AFR monitor"
        CType(Me.MTS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LED_AFR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents MTS1 As AxMTSSDKLib.AxMTS
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents Channelvalue As System.Windows.Forms.Label
    Friend WithEvents InputDetails As System.Windows.Forms.Label
    Friend WithEvents Portlist As System.Windows.Forms.ComboBox
    Friend WithEvents LED_AFR As LxControl.LxLedControl

End Class
