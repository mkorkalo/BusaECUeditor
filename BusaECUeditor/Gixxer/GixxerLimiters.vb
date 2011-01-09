'
'    This file is part of ecueditor - Hayabusa ECUeditor
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

Public Class GixxerLimiters
    Dim rpmconv As Long
    Dim addedrpm As Integer

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_gearlimiter.CheckedChanged
        ' petrik, modified for K8
        If C_gearlimiter.Checked = True Then
            '
            ' Write limiters off values
            '
            WriteFlashByte(&H614C1, &H0) 'fuel limiter by gear 
            WriteFlashByte(&H614C4, &H0) 'fuel limiter by gear softcut
            C_gearlimiter.Text = "Gear limiters removed"
        Else
            '
            ' Write default values
            '
            WriteFlashByte(&H614C1, &H80) 'fuel limiter by gear 
            WriteFlashByte(&H614C4, &H80) 'fuel limiter by gear softcut
            C_gearlimiter.Text = "Gear limiters on"

        End If

    End Sub

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM.SelectedIndexChanged
        Dim i As Integer
        Dim baseline As Integer

        baseline = 13450
        ' Set various RPM limits based on RPM value selected
        i = Val(RPM.Text)
        addedrpm = i - baseline ' we are just setting here the baseline

        If i >= 13500 Then
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
        WriteFlashWord(&H61372, Int((rpmconv / (addedrpm + (rpmconv / &H45D)))))
        WriteFlashWord(&H61374, Int((rpmconv / (addedrpm + (rpmconv / &H45B)))))
        WriteFlashWord(&H61376, Int((rpmconv / (addedrpm + (rpmconv / &H459)))))
        WriteFlashWord(&H61378, Int((rpmconv / (addedrpm + (rpmconv / &H457))))) ' 11304rpm
        '
        ' RPM/Fuel hard type 2, this is modified higher than stock as ecu default is not used in this case
        '
        WriteFlashWord(&H6137A, Int((rpmconv / (addedrpm + (rpmconv / &H46C)))))
        WriteFlashWord(&H6137C, Int((rpmconv / (addedrpm + (rpmconv / &H468)))))
        '
        ' RPM/Fuel soft hard type 3 neutral, this is modified to be same as type2
        '
        WriteFlashWord(&H6137E, Int((rpmconv / (addedrpm + (rpmconv / &H48F)))))
        WriteFlashWord(&H61380, Int((rpmconv / (addedrpm + (rpmconv / &H48B)))))
        '
        ' RPM limiter type 6, this is the limiter when FI light is on but still running normally
        '
        'Not present in Gixxer ?
        '
        'writeflashword(&H739FE, Int((rpmconv / (addedrpm + (rpmconv / &H554)) + 1)))
        'writeflashword(&H73A00, Int((rpmconv / (addedrpm + (rpmconv / &H547)) + 1)))
        'writeflashword(&H73A02, Int((rpmconv / (addedrpm + (rpmconv / &H53B)) + 1)))
        'writeflashword(&H73A04, Int((rpmconv / (addedrpm + (rpmconv / &H52F)) + 1)))

        '
        ' RPM/Ignition limiters, these are set to around 150rpm higher than fuel limiters
        '
        WriteFlashWord(&H60B2C, Int((rpmconv / (addedrpm + (rpmconv / &H44B))))) 'normal limiter
        WriteFlashWord(&H60B2E, Int((rpmconv / (addedrpm + (rpmconv / &H447))))) 'normal limiter
        WriteFlashWord(&H60B30, Int((rpmconv / (addedrpm + (rpmconv / &H47D))))) 'clutch limiter
        WriteFlashWord(&H60B32, Int((rpmconv / (addedrpm + (rpmconv / &H479))))) 'clutch limiter
        WriteFlashWord(&H60B38, Int((rpmconv / (addedrpm + (rpmconv / &H3EF))))) 'On TPS limiter a bit unsure about condition triggering this one
        WriteFlashWord(&H60B3A, Int((rpmconv / (addedrpm + (rpmconv / &H3E8))))) 'On TPS limiter  a bit unsure about condition triggering this one


    End Sub

    Private Sub K8Limiters_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            '
            '
            '
        End If
        If e.KeyChar = Chr(9) Then
            WriteFlashByte(&H604CF, 0)
            MsgBox("Special function accepted")
        End If
    End Sub

    Private Sub Limiters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        rpmconv = 3840000000 / &H100

        '
        ' Determine if gear limiters are on or off
        '
        If ReadFlashByte(&H614C1) <> &H80 Then
            C_gearlimiter.Checked = True
            C_gearlimiter.Text = "Gear limiters removed"
        Else
            C_gearlimiter.Checked = False
            C_gearlimiter.Text = "Gear limiters on"
        End If

        '
        ' Determine if softcut is on or off
        '
        If ReadFlashByte(&H614BE) = &HFF Then
            Hardcut.Checked = True
            Hardcut.Text = "Fuel hardcut only"
        Else
            Hardcut.Checked = False
            Hardcut.Text = "Fuel softcut enabled"
        End If


        'populate RPM with initial value
        i = ReadFlashWord(&H61372) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))) + 1)
        i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
        Me.RPM.Items.Add(i.ToString())
        i = 10000
        Do While i < 15500 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.RPM.Items.Add(i.ToString())

        


        Me.RPM.SelectedIndex = 0
        Me.RPM.Enabled = True
       

    End Sub


    Private Sub Hardcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hardcut.CheckedChanged
        If Hardcut.Checked = True Then
            WriteFlashByte(&H614BE, &HFF)
            Hardcut.Text = "Fuel hardcut only"
        Else
            WriteFlashByte(&H614BE, &H80)
            Hardcut.Text = "Fuel softcut enabled"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    
   
End Class