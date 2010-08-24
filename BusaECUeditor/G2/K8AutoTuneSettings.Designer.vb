﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class K8AutoTuneSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(K8AutoTuneSettings))
        Me.NUD_AutoTuneMinAvgAFR = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NUD_AutoTuneMaxAvgAFR = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.NUD_AutoTuneMaxPercentageFuelMapChange = New System.Windows.Forms.NumericUpDown
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.B_Ok = New System.Windows.Forms.Button
        Me.B_Cancel = New System.Windows.Forms.Button
        CType(Me.NUD_AutoTuneMinAvgAFR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMaxAvgAFR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMaxPercentageFuelMapChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_AutoTuneMinNumberLoggedValuesInCell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NUD_AutoTuneMinAvgAFR
        '
        Me.NUD_AutoTuneMinAvgAFR.DecimalPlaces = 1
        Me.NUD_AutoTuneMinAvgAFR.Location = New System.Drawing.Point(241, 10)
        Me.NUD_AutoTuneMinAvgAFR.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.NUD_AutoTuneMinAvgAFR.Name = "NUD_AutoTuneMinAvgAFR"
        Me.NUD_AutoTuneMinAvgAFR.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMinAvgAFR.TabIndex = 0
        Me.NUD_AutoTuneMinAvgAFR.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Minimum Avg AFR Value"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Maximum Avg AFR Value"
        '
        'NUD_AutoTuneMaxAvgAFR
        '
        Me.NUD_AutoTuneMaxAvgAFR.DecimalPlaces = 1
        Me.NUD_AutoTuneMaxAvgAFR.Location = New System.Drawing.Point(241, 34)
        Me.NUD_AutoTuneMaxAvgAFR.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.NUD_AutoTuneMaxAvgAFR.Minimum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NUD_AutoTuneMaxAvgAFR.Name = "NUD_AutoTuneMaxAvgAFR"
        Me.NUD_AutoTuneMaxAvgAFR.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMaxAvgAFR.TabIndex = 3
        Me.NUD_AutoTuneMaxAvgAFR.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Max % Change in Fuel Map"
        '
        'NUD_AutoTuneMaxPercentageFuelMapChange
        '
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.Location = New System.Drawing.Point(241, 59)
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.Name = "NUD_AutoTuneMaxPercentageFuelMapChange"
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMaxPercentageFuelMapChange.TabIndex = 5
        '
        'NUD_AutoTuneMinNumberLoggedValuesInCell
        '
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.Location = New System.Drawing.Point(241, 84)
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.Name = "NUD_AutoTuneMinNumberLoggedValuesInCell"
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.Size = New System.Drawing.Size(60, 20)
        Me.NUD_AutoTuneMinNumberLoggedValuesInCell.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Min Number of Logged AFR Values In Cell"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(349, 74)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(7, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 94)
        Me.Panel1.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.B_Cancel)
        Me.Panel2.Controls.Add(Me.B_Ok)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMinAvgAFR)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMinNumberLoggedValuesInCell)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMaxAvgAFR)
        Me.Panel2.Controls.Add(Me.NUD_AutoTuneMaxPercentageFuelMapChange)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(7, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(404, 115)
        Me.Panel2.TabIndex = 10
        '
        'B_Ok
        '
        Me.B_Ok.Location = New System.Drawing.Point(322, 10)
        Me.B_Ok.Name = "B_Ok"
        Me.B_Ok.Size = New System.Drawing.Size(75, 23)
        Me.B_Ok.TabIndex = 8
        Me.B_Ok.Text = "Ok"
        Me.B_Ok.UseVisualStyleBackColor = True
        '
        'B_Cancel
        '
        Me.B_Cancel.Location = New System.Drawing.Point(322, 37)
        Me.B_Cancel.Name = "B_Cancel"
        Me.B_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.B_Cancel.TabIndex = 9
        Me.B_Cancel.Text = "Cancel"
        Me.B_Cancel.UseVisualStyleBackColor = True
        '
        'K8AutoTuneSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 236)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "K8AutoTuneSettings"
        Me.Text = "K8 Auto Tune Settings"
        CType(Me.NUD_AutoTuneMinAvgAFR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMaxAvgAFR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMaxPercentageFuelMapChange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_AutoTuneMinNumberLoggedValuesInCell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NUD_AutoTuneMinAvgAFR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneMaxAvgAFR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NUD_AutoTuneMaxPercentageFuelMapChange As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_AutoTuneMinNumberLoggedValuesInCell As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents B_Cancel As System.Windows.Forms.Button
    Friend WithEvents B_Ok As System.Windows.Forms.Button
End Class
