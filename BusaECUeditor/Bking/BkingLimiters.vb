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

Public Class BKingLimiters

#Region "Variables"

    Dim _rpmConv As Long
    Dim _addedRpm As Integer

#End Region

#Region "Form Events"

    Private Sub BKingLimiters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        _rpmConv = 15000000

        '
        '
        ' Determine if 6th gear limiter is stock
        '
        If ReadFlashword(&H74AAA) = &H5654 Then
            C_6gear.Text = "5-6th gear limiter as stock"
            C_6gear.Checked = False
        Else
            C_6gear.Text = "5-6th gear deristricted"
            C_6gear.Checked = True
        End If

        'populate RPM with initial value
        i = ReadFlashword(&H74A80) ' this is the reference RPM that is stored in the system
        i = Int(((_rpmConv / (i + 0))) + 1)
        i = CInt(i / 50) * 50 'the conversions are not exact, Round it up to the closest 50 to avoid confusion

        Me.RPM.Items.Add(i.ToString())

        i = 10300
        Do While i < 12000 ' this is the maximum rpm allowed as exceeding this requires setting more limiters
            Me.RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.RPM.Items.Add(i.ToString())

        Me.RPM.SelectedIndex = 0
        Me.RPM.Enabled = True


    End Sub

    Private Sub BKingLimiters_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            '
            '
            '
        End If
    End Sub

#End Region

#Region "Control Events"

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM.SelectedIndexChanged
        Dim i As Integer
        Dim baseline As Integer

        baseline = 11103
        ' Set various RPM limits based on RPM value selected
        i = Val(RPM.Text)
        _addedRpm = i - baseline ' we are just setting here the baseline

        '
        ' RPM/Fuel soft hard type 1
        '
        writeflashword(&H74A7A, Int((_rpmConv / (_addedRpm + (_rpmConv / &H56D)) + 1)))
        writeflashword(&H74A7C, Int((_rpmConv / (_addedRpm + (_rpmConv / &H560)) + 1)))
        writeflashword(&H74A7E, Int((_rpmConv / (_addedRpm + (_rpmConv / &H553)) + 1)))
        writeflashword(&H74A80, Int((_rpmConv / (_addedRpm + (_rpmConv / &H547)) + 1)))
        '
        ' RPM/Fuel soft hard type 2, this is modified higher than stock as stock is not used
        '
        writeflashword(&H74A82, Int((_rpmConv / (_addedRpm + (_rpmConv / &H57A)) + 1)))
        writeflashword(&H74A84, Int((_rpmConv / (_addedRpm + (_rpmConv / &H56D)) + 1)))
        '
        ' RPM/Fuel soft hard type 3 neutral
        '
        writeflashword(&H74A86, Int((_rpmConv / (_addedRpm + (_rpmConv / &H594)) + 1)))
        writeflashword(&H74A88, Int((_rpmConv / (_addedRpm + (_rpmConv / &H587)) + 1)))
        '
        ' RPM/Ignition
        '
        writeflashword(&H74358, Int((_rpmConv / (_addedRpm + (_rpmConv / &H524)) + 1)))
        writeflashword(&H7435A, Int((_rpmConv / (_addedRpm + (_rpmConv / &H518)) + 1)))
        writeflashword(&H7435C, Int((_rpmConv / (_addedRpm + (_rpmConv / &H560)) + 1)))
        writeflashword(&H7435E, Int((_rpmConv / (_addedRpm + (_rpmConv / &H554)) + 1)))


    End Sub

    Private Sub C_6gear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_6gear.CheckedChanged
        If C_6gear.Checked = True Then
            '
            ' gear modeA compensation 5&6 as 4th, 0x80 only
            '
            writeflashword(&H54FEC + 2, &H7988) 'gear5ms0modeA
            writeflashword(&H54FF8 + 2, &H7988) 'gear5ms1modeA
            writeflashword(&H55004 + 2, &H7988) 'gear6ms0modeA
            writeflashword(&H55010 + 2, &H7988) 'gear6ms1modeA
            '
            ' Opening STP 5&6 gear using gear4 values
            '
            writeflashword(&H54340 + 2, &H5CA0) 'gear5ms0modeA
            writeflashword(&H5434C + 2, &H5E44) 'gear5ms1modeA
            writeflashword(&H54358 + 2, &H5CA0) 'gear6ms0modeA
            writeflashword(&H54364 + 2, &H5E44) 'gear6ms1modeA
            '
            ' Limiters
            '
            writeflashword(&H74AA2, &H7DA7)
            writeflashword(&H74AA4, &H7FA7)
            writeflashword(&H74AA6, &H81A7)
            writeflashword(&H74AA8, &H83A7)
            writeflashword(&H74AAA, &H7DA7)
            writeflashword(&H74AAC, &H7FA7)
            writeflashword(&H74AAE, &H81A7)
            writeflashword(&H74AB0, &H83A7)
            C_6gear.Text = "5-6th gear using gear4 values"
        Else
            '
            ' gear modeA compensation 5&6 stock
            '
            writeflashword(&H54FEC + 2, &H799C) 'gear5ms0modeA
            writeflashword(&H54FF8 + 2, &H7B40) 'gear5ms1modeA
            writeflashword(&H55004 + 2, &H79B0) 'gear6ms0modeA
            writeflashword(&H55010 + 2, &H7B54) 'gear6ms1modeA
            '
            ' STP, 5&6 geat stock
            '
            writeflashword(&H54340 + 2, &H5CB0) 'gear5ms0modeA
            writeflashword(&H5434C + 2, &H5E58) 'gear5ms1modeA
            writeflashword(&H54358 + 2, &H5CC8) 'gear6ms0modeA
            writeflashword(&H54364 + 2, &H5E6C) 'gear6ms1modeA
            '
            ' Limiters
            '
            writeflashword(&H74AA2, &H5E0F)
            writeflashword(&H74AA4, &H5E8F)
            writeflashword(&H74AA6, &H6080)
            writeflashword(&H74AA8, &H608F)
            writeflashword(&H74AAA, &H5654)
            writeflashword(&H74AAC, &H56D7)
            writeflashword(&H74AAE, &H5857)
            writeflashword(&H74AB0, &H58D7)
            C_6gear.Text = "5-6th gear limiter as stock"
        End If
    End Sub

#End Region

End Class