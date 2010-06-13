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
    Dim rpmconv As Long

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            writeflashword(&H29588 + 24, Int(12800 * 2.56) + 1)
            writeflashword(&H29588 + 26, Int(12900 * 2.56) + 1)
            ' change also gear specific limiters        
            writeflashword(&H29588, Int(12800 * 2.56) + 1)
            writeflashword(&H29590, Int(12800 * 2.56) + 1)
            writeflashword(&H29598, Int(12800 * 2.56) + 1)
            writeflashword(&H295A0, Int(12800 * 2.56) + 1)
            writeflashword(&H2958A, Int(12900 * 2.56) + 1)
            writeflashword(&H29592, Int(12900 * 2.56) + 1)
            writeflashword(&H2959A, Int(12900 * 2.56) + 1)
            writeflashword(&H295A2, Int(12900 * 2.56) + 1)
            writeflashword(&H295A8 + 0, Int(12800 * 2.56) + 1)
            writeflashword(&H295A8 + 2, Int(12900 * 2.56) + 1)
            writeflashword(&H295A8 + 4, Int(12800 * 2.56) + 1)
            writeflashword(&H295A8 + 6, Int(12900 * 2.56) + 1)
            writeflashword(&H295A8 + 8, Int(12800 * 2.56) + 1)
            writeflashword(&H295A8 + 10, Int(12900 * 2.56) + 1)
            writeflashword(&H295A8 + 12, Int(12800 * 2.56) + 1)
            writeflashword(&H295A8 + 14, Int(12900 * 2.56) + 1)

            CheckBox1.Text = "Top speed limiter removed"
        Else
            '
            ' New, trying to add gear limts higher
            '
            'writeflashword(&H29588 + 14, Int(11400 * 2.56) + 1)
            'writeflashword(&H29588 + 16, Int(11800 * 2.56) + 1)
            'writeflashword(&H29588 + 18, Int(11800 * 2.56) + 1)
            'writeflashword(&H29588 + 20, Int(12000 * 2.56) + 1)
            'writeflashword(&H29588 + 22, Int(11400 * 2.56) + 1)
            'writeflashword(&H29588 + 24, Int(11600 * 2.56) + 1)
            'writeflashword(&H29588 + 26, Int(11800 * 2.56) + 1)
            'writeflashword(&H29588 + 28, Int(12000 * 2.56) + 1)
            'writeflashword(&H29588 + 30, Int(10065 * 2.56) + 1)
            'writeflashword(&H29588 + 32, Int(10089 * 2.56) + 1)
            'writeflashword(&H29588 + 36, Int(11800 * 2.56) + 1)
            'writeflashword(&H29588 + 40, Int(12000 * 2.56) + 1)
            '
            '            '
            writeflashword(&H29588 + 24, Int(10065 * 2.56) + 1)
            writeflashword(&H29588 + 26, Int(10089 * 2.56) + 1)
            ' change also gear specific limiters        
            writeflashword(&H29588, Int(11400 * 2.56) + 1)
            writeflashword(&H29590, Int(11400 * 2.56) + 1)
            writeflashword(&H29598, Int(11400 * 2.56) + 1)
            writeflashword(&H295A0, Int(10065 * 2.56) + 1)
            writeflashword(&H2958A, Int(10089 * 2.56) + 1)
            writeflashword(&H29592, Int(11600 * 2.56) + 1)
            writeflashword(&H2959A, Int(11600 * 2.56) + 1)
            writeflashword(&H295A2, Int(11600 * 2.56) + 1)
            writeflashword(&H295A8 + 0, Int(11400 * 2.56) + 1)
            writeflashword(&H295A8 + 2, Int(11600 * 2.56) + 1)
            writeflashword(&H295A8 + 4, Int(11400 * 2.56) + 1)
            writeflashword(&H295A8 + 6, Int(11600 * 2.56) + 1)
            writeflashword(&H295A8 + 8, Int(11400 * 2.56) + 1)
            writeflashword(&H295A8 + 10, Int(11600 * 2.56) + 1)
            writeflashword(&H295A8 + 12, Int(11400 * 2.56) + 1)
            writeflashword(&H295A8 + 14, Int(11600 * 2.56) + 1)

            CheckBox1.Text = "Top speed restricted"
        End If

    End Sub

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM.SelectedIndexChanged
        Dim i As Integer
        ' Set various RPM limits based on RPM value selected
        i = Val(RPM.Text)

        ' in case the selected RPM is higher than allowed then extend also gear specific limiters
        If i >= 11200 Then
            CheckBox1.Checked = True
        End If

        writeflashword(&H29576 + 0, Int(((rpmconv / (i + 0))) + 1))
        writeflashword(&H29576 + 2, Int(((rpmconv / (i + 50))) + 1))
        writeflashword(&H29576 + 4, Int(((rpmconv / (i + 100))) + 1))
        writeflashword(&H29576 + 6, Int(((rpmconv / (i + 150))) + 1))
        writeflashword(&H29576 + 8, Int(((rpmconv / (i - 100))) + 1))
        writeflashword(&H29576 + 10, Int(((rpmconv / (i + 0))) + 1))

    End Sub

    Private Sub Limiters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        rpmconv = 15000000

        If readflashword(&H29588 + 26) = Int(12900 * 2.56) + 1 Then
            CheckBox1.Checked = True
            CheckBox1.Text = "Top speed limiter removed"
        Else
            CheckBox1.Text = "Top speed restricted"
        End If

        If readflashword(&H29586) = &HFF Then
            Hardcut.Checked = True
            Hardcut.Text = "Fuel hardcut only"
        Else
            Hardcut.Checked = False
            Hardcut.Text = "Fuel softcut enabled"
        End If


        'populate RPM with initial value
        i = readflashword(&H29576) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))) + 1)
        i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion

        Me.RPM.Items.Add(i.ToString())

        i = 10500
        Do While i <= 11600 ' this is the maximum rpm allowed without rescaling the maps
            Me.RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        i = i - 50
        Me.RPM.Items.Add(i.ToString()) ' add maxrpm + 50, i.e. 11650

        Me.RPM.SelectedIndex = 0
        Me.RPM.Enabled = True

    End Sub


    Private Sub Hardcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hardcut.CheckedChanged
        If Hardcut.Checked = True Then
            writeflashword(&H29586, &HFF)
            Hardcut.Text = "Fuel hardcut only"
        Else
            writeflashword(&H29586, &H80)
            Hardcut.Text = "Fuel softcut enabled"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class