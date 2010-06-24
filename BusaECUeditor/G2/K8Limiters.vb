'
'    This file is part of BusaECUeditor - Hayabusa ECUeditor
'
'    Hayabusa ECUeditor is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Hayabusa ECUeditor is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with Hayabusa ECUeditor.  If not, see <http://www.gnu.org/licenses/>.
'
'    Notice: Please note that under GPL if you use this program or parts of it
'    you are obliged to distribute your software including source code
'    under this same license for free. For more information see paragraph 5
'    of the GNU licence.
'

Public Class K8Limiters
    Dim rpmconv As Long
    Dim addedrpm As Integer

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_gearlimiter.CheckedChanged
        ' petrik, modified for K8
        If C_gearlimiter.Checked = True Then
            '
            ' Write limiters off values
            '
            WriteFlashByte(&H73B4A, &H0) 'fuel limiter by gear 
            WriteFlashByte(&H73B4B, &H0) 'fuel limiter by gear softcut
            WriteFlashByte(&H72A88, &H0) 'ignition limiter by gear 
            C_gearlimiter.Text = "Gear limiters removed"
        Else
            '
            ' Write default values
            '
            WriteFlashByte(&H73B4A, &H80) 'fuel limiter by gear 
            WriteFlashByte(&H73B4B, &H80) 'fuel limiter by gear softcut
            WriteFlashByte(&H72A88, &H0) 'ignition limiter by gear 
            C_gearlimiter.Text = "Gear limiters on"

        End If

    End Sub

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM.SelectedIndexChanged
        Dim i As Integer
        Dim baseline As Integer

        baseline = 11304
        ' Set various RPM limits based on RPM value selected
        i = Val(RPM.Text)
        addedrpm = i - baseline ' we are just setting here the baseline

        If i > 11500 Then
            C_gearlimiter.Checked = True
        End If

        '
        ' RPM/Fuel soft hard type 1
        '
        WriteFlashWord(&H739E6, Int((rpmconv / (addedrpm + (rpmconv / &H554)) + 1)))
        WriteFlashWord(&H739E8, Int((rpmconv / (addedrpm + (rpmconv / &H547)) + 1)))
        WriteFlashWord(&H739EA, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        WriteFlashWord(&H739EC, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))
        '
        ' RPM/Fuel soft hard type 2, this is modified higher than stock as stock is not used
        '
        WriteFlashWord(&H739EE, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        WriteFlashWord(&H739F0, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))
        '
        ' RPM/Fuel soft hard type 3 neutral
        '
        WriteFlashWord(&H739F2, Int((rpmconv / (addedrpm + (rpmconv / &H594)) + 1)))
        WriteFlashWord(&H739F4, Int((rpmconv / (addedrpm + (rpmconv / &H587)) + 1)))
        '
        ' RPM/Ignition
        '
        WriteFlashWord(&H72A68, Int((rpmconv / (addedrpm + (rpmconv / &H51E)) + 1)))
        WriteFlashWord(&H72A6A, Int((rpmconv / (addedrpm + (rpmconv / &H50D)) + 1)))
        WriteFlashWord(&H72A6C, Int((rpmconv / (addedrpm + (rpmconv / &H560)) + 1)))
        WriteFlashWord(&H72A6E, Int((rpmconv / (addedrpm + (rpmconv / &H554)) + 1)))
        '
        ' RPM limiter type 4
        '
        WriteFlashWord(&H739FE, Int((rpmconv / (addedrpm + (rpmconv / &H554)) + 1)))
        WriteFlashWord(&H73A00, Int((rpmconv / (addedrpm + (rpmconv / &H547)) + 1)))
        WriteFlashWord(&H73A02, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        WriteFlashWord(&H73A04, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))


    End Sub

    Private Sub K8Limiters_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
            PrintForm1.Print()
        End If
    End Sub

    Private Sub Limiters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        rpmconv = 15000000

        '
        ' Determine if gear limiters are on or off
        '
        i = ReadFlashByte(&H73B4A)
        If ReadFlashByte(&H73B4A) <> &H80 Then
            C_gearlimiter.Checked = True
            C_gearlimiter.Text = "Gear limiters removed"
        Else
            C_gearlimiter.Checked = False
            C_gearlimiter.Text = "Gear limiters on"
        End If

        '
        ' Determine if softcut is on or off
        '
        If ReadFlashByte(&H73B43) = &HFF Then
            Hardcut.Checked = True
            Hardcut.Text = "Fuel hardcut only"
        Else
            Hardcut.Checked = False
            Hardcut.Text = "Fuel softcut enabled"
        End If


        'populate RPM with initial value
        i = ReadFlashWord(&H739EC) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))) + 1)
        i = CInt(i / 50) * 50 'the conversions are not exact, Round it up to the closest 50 to avoid confusion

        Me.RPM.Items.Add(i.ToString())

        i = 10600
        Do While i < 13000 ' this is the maximum rpm allowed 
            Me.RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.RPM.Items.Add(i.ToString())

        Me.RPM.SelectedIndex = 0
        Me.RPM.Enabled = True

    End Sub


    Private Sub Hardcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hardcut.CheckedChanged
        If Hardcut.Checked = True Then
            WriteFlashByte(&H73B43, &HFF)
            Hardcut.Text = "Fuel hardcut only"
        Else
            WriteFlashByte(&H73B43, &H80)
            Hardcut.Text = "Fuel softcut enabled"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class