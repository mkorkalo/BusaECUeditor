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

Public Class Limiters

#Region "Variables"

    Dim _rpmConv As Long

#End Region

#Region "Form Events"

    Private Sub Limiters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        _rpmConv = 15000000

        If ReadFlashWord(&H29588 + 26) = Int(12900 * 2.56) + 1 Then
            C_TopSpeedLimiter.Checked = True
            C_TopSpeedLimiter.Text = "Top speed limiter removed"
        Else
            C_TopSpeedLimiter.Text = "Top speed restricted"
        End If

        If ReadFlashWord(&H29586) = &HFF Then
            C_Hardcut.Checked = True
            C_Hardcut.Text = "Fuel hardcut only"
        Else
            C_Hardcut.Checked = False
            C_Hardcut.Text = "Fuel softcut enabled"
        End If


        'populate RPM with initial value
        i = ReadFlashWord(&H29576) ' this is the reference RPM that is stored in the system
        i = Int(((_rpmConv / (i + 0))) + 1)
        i = CInt(i / 50) * 50 'the conversions are not exact, Round it up to the closest 50 to avoid confusion

        Me.C_RPM.Items.Add(i.ToString())

        i = 10500
        Do While i <= 11600 ' this is the maximum rpm allowed without rescaling the maps
            Me.C_RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        i = i - 50
        Me.C_RPM.Items.Add(i.ToString()) ' add maxrpm + 50, i.e. 11650

        Me.C_RPM.SelectedIndex = 0
        Me.C_RPM.Enabled = True

    End Sub

#End Region

#Region "Control Events"

    Private Sub C_RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_RPM.SelectedIndexChanged
        Dim i As Integer
        ' Set various RPM limits based on RPM value selected
        i = Val(C_RPM.Text)

        ' in case the selected RPM is higher than allowed then extend also gear specific limiters
        If i >= 11200 Then
            C_TopSpeedLimiter.Checked = True
        End If

        WriteFlashWord(&H29576 + 0, Int(((_rpmConv / (i + 0))) + 1))
        WriteFlashWord(&H29576 + 2, Int(((_rpmConv / (i + 50))) + 1))
        WriteFlashWord(&H29576 + 4, Int(((_rpmConv / (i + 100))) + 1))
        WriteFlashWord(&H29576 + 6, Int(((_rpmConv / (i + 150))) + 1))
        WriteFlashWord(&H29576 + 8, Int(((_rpmConv / (i - 100))) + 1))
        WriteFlashWord(&H29576 + 10, Int(((_rpmConv / (i + 0))) + 1))

    End Sub

    Private Sub C_TopSpeedLimiter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_TopSpeedLimiter.CheckedChanged
        If C_TopSpeedLimiter.Checked = True Then
            WriteFlashWord(&H29588 + 24, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H29588 + 26, Int(12900 * 2.56) + 1)
            ' change also gear specific limiters        
            WriteFlashWord(&H29588, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H29590, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H29598, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H295A0, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H2958A, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H29592, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H2959A, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H295A2, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 0, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 2, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 4, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 6, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 8, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 10, Int(12900 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 12, Int(12800 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 14, Int(12900 * 2.56) + 1)

            C_TopSpeedLimiter.Text = "Top speed limiter removed"
        Else
            '
            ' New, trying to add gear limts higher
            '
            'WriteFlashWord(&H29588 + 14, Int(11400 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 16, Int(11800 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 18, Int(11800 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 20, Int(12000 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 22, Int(11400 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 24, Int(11600 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 26, Int(11800 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 28, Int(12000 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 30, Int(10065 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 32, Int(10089 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 36, Int(11800 * 2.56) + 1)
            'WriteFlashWord(&H29588 + 40, Int(12000 * 2.56) + 1)
            '
            '            '
            WriteFlashWord(&H29588 + 24, Int(10065 * 2.56) + 1)
            WriteFlashWord(&H29588 + 26, Int(10089 * 2.56) + 1)
            ' change also gear specific limiters        
            WriteFlashWord(&H29588, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H29590, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H29598, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H295A0, Int(10065 * 2.56) + 1)
            WriteFlashWord(&H2958A, Int(10089 * 2.56) + 1)
            WriteFlashWord(&H29592, Int(11600 * 2.56) + 1)
            WriteFlashWord(&H2959A, Int(11600 * 2.56) + 1)
            WriteFlashWord(&H295A2, Int(11600 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 0, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 2, Int(11600 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 4, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 6, Int(11600 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 8, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 10, Int(11600 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 12, Int(11400 * 2.56) + 1)
            WriteFlashWord(&H295A8 + 14, Int(11600 * 2.56) + 1)

            C_TopSpeedLimiter.Text = "Top speed restricted"
        End If

    End Sub

    Private Sub C_Hardcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Hardcut.CheckedChanged
        If C_Hardcut.Checked = True Then
            WriteFlashWord(&H29586, &HFF)
            C_Hardcut.Text = "Fuel hardcut only"
        Else
            WriteFlashWord(&H29586, &H80)
            C_Hardcut.Text = "Fuel softcut enabled"
        End If

    End Sub

    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click

        Me.Close()

    End Sub

#End Region

End Class