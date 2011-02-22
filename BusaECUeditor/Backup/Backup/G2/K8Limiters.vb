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
            writeflashbyte(&H73B4A, &H0) 'fuel limiter by gear 
            writeflashbyte(&H73B4B, &H0) 'fuel limiter by gear softcut
            writeflashbyte(&H72A88, &H0) 'ignition limiter by gear, not active by default 
            C_gearlimiter.Text = "Gear limiters removed"
        Else
            '
            ' Write default values
            '
            writeflashbyte(&H73B4A, &H80) 'fuel limiter by gear 
            writeflashbyte(&H73B4B, &H80) 'fuel limiter by gear softcut
            writeflashbyte(&H72A88, &H0) 'ignition limiter by gear, not active by default 
            C_gearlimiter.Text = "Gear limiters active"

        End If

    End Sub

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM.SelectedIndexChanged
        Dim i As Integer
        Dim baseline As Integer

        baseline = 11304
        ' Set various RPM limits based on RPM value selected
        i = Val(RPM.Text)
        addedrpm = i - baseline ' we are just setting here the baseline

        If i >= 11500 Then
            C_gearlimiter.Checked = True
        End If

        '
        ' Fuel limiters
        '

        ' Type 0 - set by fuel config const, no fuelcut
        ' Type 1 - softcut
        ' Type 2 - hardcut
        ' Type 3 - GPS error or clutch
        ' Type 4 - limp mode, errorcode present - do not set with ecueditor
        ' Type 5 - limp mode, errorcode present - do not set with ecueditor
        ' Type 6 - normal running, but errorcode present
        '
        ' RPM/Fuel soft type 1, the softcut hits earlier than hardcut. Abosolute limiter at hard cut limit.
        '
        writeflashword(&H739E6, Int((rpmconv / (addedrpm + (rpmconv / &H554)) + 1)))
        writeflashword(&H739E8, Int((rpmconv / (addedrpm + (rpmconv / &H547)) + 1)))
        writeflashword(&H739EA, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        WriteFlashWord(&H739EC, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1))) ' 11304rpm
        '
        ' RPM/Fuel hard type 2, this is modified higher than stock as ecu default is not used in this case
        '
        WriteFlashWord(&H739EE, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        WriteFlashWord(&H739F0, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))
        '
        ' RPM/Fuel soft hard type 3 neutral, this is modified to be same as type2
        '
        WriteFlashWord(&H739F2, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        WriteFlashWord(&H739F4, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))
        '
        ' RPM limiter type 6, this is the limiter when FI light is on but still running normally
        '
        writeflashword(&H739FE, Int((rpmconv / (addedrpm + (rpmconv / &H554)) + 1)))
        writeflashword(&H73A00, Int((rpmconv / (addedrpm + (rpmconv / &H547)) + 1)))
        writeflashword(&H73A02, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        writeflashword(&H73A04, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))

        '
        ' RPM/Ignition limiters, these are set to around 150rpm higher than fuel limiters
        '
        writeflashword(&H72A68, Int((rpmconv / (addedrpm + (rpmconv / &H51E)) + 1))) 'normal limiter 11450rpm
        WriteFlashWord(&H72A6A, Int((rpmconv / (addedrpm + (rpmconv / &H50D)) + 1))) 'normal limiter 11601rpm
        If ReadFlashWord(&H5A000) = &HFF Then WriteFlashWord(&H72A6C, Int((rpmconv / (addedrpm + (rpmconv / &H51E)) + 1))) 'clutch limiter at 10901 modified to same as normal ignition limiter
        If ReadFlashWord(&H5A000) = &HFF Then WriteFlashWord(&H72A6E, Int((rpmconv / (addedrpm + (rpmconv / &H50D)) + 1))) 'clutch limiter at 10997 modified to same as normal ignition limiter
        WriteFlashWord(&H72A74, Int((rpmconv / (addedrpm + (rpmconv / &H51E)) + 1))) 'On TPS < 2.5% limiter 11450rpm - a bit unsure about condition triggering this one
        WriteFlashWord(&H72A76, Int((rpmconv / (addedrpm + (rpmconv / &H50D)) + 1))) 'On TPS < 2.5%  limiter 11601rpm - a bit unsure about condition triggering this one

        '
        ' This is GPS raw value that is set to default in case the dragtools module is not used
        '
        If ReadFlashWord(&H5A000) <> &HFF Then
            WriteFlashByte(&H36E39 + 0, &H80)
            WriteFlashByte(&H36E39 + 1, &H50)
            WriteFlashByte(&H36E39 + 2, &HB0)
        End If

    End Sub

    Private Sub K8Limiters_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
            PrintForm1.Print()
        End If
    End Sub

    Public Sub Limiters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        rpmconv = 3840000000 / &H100

        '
        ' Determine if gear limiters are on or off
        '
        i = readflashbyte(&H73B4A)
        If readflashbyte(&H73B4A) <> &H80 Then
            C_gearlimiter.Checked = True
            C_gearlimiter.Text = "Gear limiters removed"
        Else
            C_gearlimiter.Checked = False
            C_gearlimiter.Text = "Gear limiters on"
        End If

        '
        ' Determine if softcut is on or off
        '
        If readflashbyte(&H73B43) = &HFF Then
            Hardcut.Checked = True
            Hardcut.Text = "Fuel hardcut only"
        Else
            Hardcut.Checked = False
            Hardcut.Text = "Fuel softcut enabled"
        End If


        'populate RPM with initial value
        i = readflashword(&H739EC) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))) + 1)
        i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
        Me.RPM.Items.Add(i.ToString())
        i = 10000
        Do While i < 13500 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.RPM.Items.Add(i.ToString())


        Me.RPM.SelectedIndex = 0
        Me.RPM.Enabled = True

    End Sub


    Private Sub Hardcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hardcut.CheckedChanged
        If Hardcut.Checked = True Then
            writeflashbyte(&H73B43, &HFF)
            Hardcut.Text = "Fuel hardcut only"
        Else
            writeflashbyte(&H73B43, &H80)
            Hardcut.Text = "Fuel softcut enabled"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class