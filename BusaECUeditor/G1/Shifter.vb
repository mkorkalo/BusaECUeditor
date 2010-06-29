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

Imports System.Windows.Forms
Imports System.IO

Public Class Shifter

#Region "Variables"

    Dim _ADJ As Integer = &H15700 '&HFF if shifter inactive, no code present else shifter active
    Dim _FUELCODE As Integer = &H15800
    Dim _IGNCODE As Integer = &H157B0
    Dim _IDTAG As Integer = &H15740              'Ref Shifter2.c const_pgmid
    Dim _IGNCUT As Integer = _IDTAG + 2           'Ref Shifter2.c _IGNCUT
    Dim _FUELCUT As Integer = _IDTAG + 3          'Ref Shifter2.c _FUELCUT
    Dim _minKillActive As Integer = _ADJ + 22     'Ref Shifter2.c _minKillActive - Changed 11.8.2009 JaSa - orig value (10*2)
    Dim _killCountDelay As Integer = _ADJ + 24    'Ref Shifter2.c _killCountDelay Changed 11.8.2009 JaSa - orig value (11*2)
    Dim _SOLRPM12 As Integer = _ADJ + 28          'Ref Shifter2.c s_GEAR12 - Changed 11.8.2009 JaSa - orig value 26
    Dim _SOLRPM36 As Integer = _ADJ + 30          'Ref Shifter2.c s_GEAR3456 - Changed 11.8.2009 JaSa - orig value 28
    Dim _GEAR6KILL As Integer = _ADJ + 32         'Ref Shifter2.c - Changed 11.8.2009 JaSa - orig value 30
    Dim _SHIFTER2VERSION As Integer = 200        'changed 11.8.2009 JaSa - orig value 101
    Dim _shifterCodeLength As Integer = &H700    'lenght of the shifter code in bytes for clearing the memory
    Dim _timerConst = 2.56

#End Region

#Region "Form Events"

    Private Sub Shifter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer

        If (ReadFlashByte(_ADJ) = &HFF) Then
            C_ShifterActivation.Checked = False
            HideShifterSettings()
            L_Neutral.Text = "Using Neutral gear during shifter operation"
        Else
            C_ShifterActivation.Checked = True
            ReadShifterSettings()
            'ShifterCodeInMemory(True, _shifterCodeLength)
            L_Neutral.Text = "Using 6th gear during shifter operation"

            If (ReadFlashWord(_IDTAG) <> _SHIFTER2VERSION) Then
                MsgBox("Shifter code incompatible with this version, please reactivate the shifter on this map")
                C_ShifterActivation.Checked = False
                HideShifterSettings()
                L_Neutral.Text = "Using Neutral gear during shifter operation"
            End If
        End If



        For i = 3 To 12
            C_KillTime.Items.Add(Str(10 * i))
        Next
    End Sub

#End Region

#Region "Control Events"

    Private Sub C_ShifterActivation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ShifterActivation.CheckedChanged
        If C_ShifterActivation.Checked Then
            C_ShifterActivation.Text = "Shifter active"
            If (ReadFlashByte(_ADJ) = &HFF) Then
                ModifyOriginalECUCode(True)
                ShifterCodeInMemory(True, _shifterCodeLength)
            End If
            ReadShifterSettings()
        Else
            C_ShifterActivation.Text = "Shifter not active"
            ModifyOriginalECUCode(False)
            ShifterCodeInMemory(False, _shifterCodeLength)
            HideShifterSettings()
        End If
    End Sub

    Private Sub C_KillTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_KillTime.SelectedIndexChanged
        T_12000.Text = C_KillTime.Text
        T_11000.Text = C_KillTime.Text
        T_10000.Text = C_KillTime.Text
        T_9000.Text = C_KillTime.Text
        T_8000.Text = C_KillTime.Text
        T_7000.Text = C_KillTime.Text
        T_6000.Text = C_KillTime.Text
        T_5000.Text = C_KillTime.Text
        T_4000.Text = C_KillTime.Text
        T_3000.Text = C_KillTime.Text
        T_2000.Text = C_KillTime.Text               'Added 11.8.2009 JaSa

        WriteFlashWord((_ADJ), (Val(T_12000.Text) * 12) / _timerConst)
        WriteFlashWord((_ADJ + 2), (Val(T_11000.Text) * 11) / _timerConst)
        WriteFlashWord((_ADJ + 4), (Val(T_10000.Text) * 10) / _timerConst)
        WriteFlashWord((_ADJ + 6), (Val(T_9000.Text) * 9) / _timerConst)
        WriteFlashWord((_ADJ + 8), (Val(T_8000.Text) * 8) / _timerConst)
        WriteFlashWord((_ADJ + 10), (Val(T_7000.Text) * 7) / _timerConst)
        WriteFlashWord((_ADJ + 12), (Val(T_6000.Text) * 6) / _timerConst)
        WriteFlashWord((_ADJ + 14), (Val(T_5000.Text) * 5) / _timerConst)
        WriteFlashWord((_ADJ + 16), (Val(T_4000.Text) * 4) / _timerConst)
        WriteFlashWord((_ADJ + 18), (Val(T_3000.Text) * 3) / _timerConst)
        WriteFlashWord((_ADJ + 20), (Val(T_2000.Text) * 2) / _timerConst) 'Added 11.8.2009

    End Sub

    Private Sub B_Install_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Install.Click
        ShifterInstructions.Show()
    End Sub

    Private Sub C_Pair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Pair.CheckedChanged

        If C_Pair.Checked = True Then
            WriteFlashByte(&H665F, &H0)         'Pair set to no write to port
            C_Pair.Text = "PAIR as output control"
            C_PairRpm12.Enabled = True
            C_PairRpm36.Enabled = True

        Else
            WriteFlashByte(&H665F, &H3)         'Pair set to write to port
            C_Pair.Text = "PAIR normal operation"
            C_PairRpm12.Enabled = False
            C_PairRpm36.Enabled = False

        End If

    End Sub

    Private Sub C_FUELCUT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_FuelCut.CheckedChanged
        If C_FuelCut.Checked Then
            WriteFlashByte(_FUELCUT, 1)
        Else
            WriteFlashByte(_FUELCUT, 0)
            If C_IgnCut.Checked = False Then
                C_IgnCut.Checked = True
            End If

        End If
    End Sub

    Private Sub C_IGNCUT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_IgnCut.CheckedChanged
        If C_IgnCut.Checked Then
            WriteFlashByte(_IGNCUT, 1)
        Else
            WriteFlashByte(_IGNCUT, 0)
            If C_FuelCut.Checked = False Then
                C_FuelCut.Checked = True
            End If
        End If
    End Sub

    Private Sub C_PairRpm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_PairRpm12.SelectedIndexChanged
        WriteFlashWord(_SOLRPM12, Int(Val(C_PairRpm12.Text) * 2.56))
    End Sub

    Private Sub C_PairRpm36_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_PairRpm36.SelectedIndexChanged
        WriteFlashWord(_SOLRPM36, Int(Val(C_PairRpm36.Text) * 2.56))
    End Sub

    Private Sub C_6thGearKill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_6thGearKill.CheckedChanged
        If C_6thGearKill.Checked Then
            WriteFlashWord(_GEAR6KILL, 1)
            C_6thGearKill.Text = "No kill on 6th gear"
        Else
            WriteFlashWord(_GEAR6KILL, 0)
            C_6thGearKill.Text = "Allow gear changes on 6th (GPS fault between gears)"
        End If
    End Sub

    Private Sub T_KillCountDelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_KillCountDelay.TextChanged
        If Val(T_KillCountDelay.Text) > 4000 Then T_KillCountDelay.Text = "4000"
        If Val(T_KillCountDelay.Text) <= 1 Then T_KillCountDelay.Text = "1"
    End Sub

    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click
        If (ReadFlashByte(_ADJ) <> &HFF) Then
            WriteFlashWord((_ADJ), (Val(T_12000.Text) * 12) / _timerConst)
            WriteFlashWord((_ADJ + 2), (Val(T_11000.Text) * 11) / _timerConst)
            WriteFlashWord((_ADJ + 4), (Val(T_10000.Text) * 10) / _timerConst)
            WriteFlashWord((_ADJ + 6), (Val(T_9000.Text) * 9) / _timerConst)
            WriteFlashWord((_ADJ + 8), (Val(T_8000.Text) * 8) / _timerConst)
            WriteFlashWord((_ADJ + 10), (Val(T_7000.Text) * 7) / _timerConst)
            WriteFlashWord((_ADJ + 12), (Val(T_6000.Text) * 6) / _timerConst)
            WriteFlashWord((_ADJ + 14), (Val(T_5000.Text) * 5) / _timerConst)
            WriteFlashWord((_ADJ + 16), (Val(T_4000.Text) * 4) / _timerConst)
            WriteFlashWord((_ADJ + 18), (Val(T_3000.Text) * 3) / _timerConst)
            WriteFlashWord(_ADJ + 20, (Val(T_2000.Text) * 2) / _timerConst)     'Added 11.8.2009 JaSa

            WriteFlashWord(_minKillActive, Val(T_MinKillActive.Text))
            WriteFlashWord(_killCountDelay, Val(T_KillCountDelay.Text))
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

#Region "Functions"

    Private Sub ModifyOriginalECUCode(ByVal method As Boolean)
        If method Then
            WriteFlashLongWord(&HE46C, _FUELCODE)    '@r3, jsraddr to shifter code which includes jsr to original code
            WriteFlashWord(&HE28C, &H432B)              '0100001100101011 jmp @r3
            WriteFlashByte(&H7E5B, &H40)                 'Threshold for low voltage 6th map raised to same as limiter
            L_Neutral.Text = "Using 6th gear during shifter operation"
            WriteFlashWord(&H12F96, &H432B)        '0100001100101011 jmp @r3
            WriteFlashLongWord(&H13080, _IGNCODE)    'IGN code start addr

        Else
            WriteFlashLongWord(&HE46C, &H11E90)         '@r3, original ecu code
            WriteFlashWord(&HE28C, &H430B)              '0100001100001011 jsr @r3
            WriteFlashByte(&H7E5B, &H2C)                 'Threshold for low voltage 6th map set to original
            L_Neutral.Text = "Using Neutral gear during shifter operation"
            WriteFlashWord(&H12F96, &H430B)         '0100001100001011 jsr @r3
            WriteFlashLongWord(&H13080, &HB078)     'Original IGN code start addr

        End If
    End Sub

    Private Sub ShifterCodeInMemory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\shifter2.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("Shifter code not found at: " & path, MsgBoxStyle.Critical)
            C_ShifterActivation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the shifter code into memory address from the .bin file
            '
            WriteFlashByte(_ADJ, &H0)
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                Flash(i + _ADJ) = b(0)
                i = i + 1
            Loop
            fs.Close()

            If ReadFlashWord(_IDTAG) <> _SHIFTER2VERSION Then
                MsgBox("This shifter code is not compatible with this ECUeditor version !!!")
                For i = 0 To lenght
                    WriteFlashByte(i + _ADJ, &HFF)
                Next
                Me.Close()
            End If
        Else
            ' reset the shifter code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                WriteFlashByte(i + _ADJ, &HFF)
            Next
        End If
    End Sub

    Private Sub ReadShifterSettings()

        Dim i As Integer

        L12.Visible = True
        L11.Visible = True
        L10.Visible = True
        L9.Visible = True
        L8.Visible = True
        L7.Visible = True
        L6.Visible = True
        L5.Visible = True
        L4.Visible = True
        L3.Visible = True
        L2.Visible = True                                               'Added 11.8.2009 JaSa

        T_12000.Visible = True
        T_11000.Visible = True
        T_10000.Visible = True
        T_9000.Visible = True
        T_8000.Visible = True
        T_7000.Visible = True
        T_6000.Visible = True
        T_5000.Visible = True
        T_4000.Visible = True
        T_3000.Visible = True
        T_2000.Visible = True                                           'Added 11.8.2009 JaSa

        T_12000.Text = Round5(ReadFlashWord(_ADJ + 0) / 12 * _timerConst)
        T_11000.Text = Round5(ReadFlashWord(_ADJ + 2) / 11 * _timerConst)
        T_10000.Text = Round5(ReadFlashWord(_ADJ + 4) / 10 * _timerConst)
        T_9000.Text = Round5(ReadFlashWord(_ADJ + 6) / 9 * _timerConst)
        T_8000.Text = Round5(ReadFlashWord(_ADJ + 8) / 8 * _timerConst)
        T_7000.Text = Round5(ReadFlashWord(_ADJ + 10) / 7 * _timerConst)
        T_6000.Text = Round5(ReadFlashWord(_ADJ + 12) / 6 * _timerConst)
        T_5000.Text = Round5(ReadFlashWord(_ADJ + 14) / 5 * _timerConst)
        T_4000.Text = Round5(ReadFlashWord(_ADJ + 16) / 4 * _timerConst)
        T_3000.Text = Round5(ReadFlashWord(_ADJ + 18) / 3 * _timerConst)
        T_2000.Text = Round5(ReadFlashWord(_ADJ + 20) / 2 * _timerConst)  'Added 11.8.2009 JaSa

        L_MinKillActive.Visible = True
        L_KillCountDelay.Visible = True
        T_MinKillActive.Visible = True
        T_KillCountDelay.Visible = True
        T_MinKillActive.Text = ReadFlashWord(_minKillActive)
        T_KillCountDelay.Text = ReadFlashWord(_killCountDelay)
        C_KillTime.Enabled = True
        C_Pair.Enabled = True

        C_FuelCut.Enabled = True
        C_IgnCut.Enabled = True

        If ReadFlashByte(_FUELCUT) = 1 Then
            C_FuelCut.Checked = True
        End If

        If ReadFlashByte(_IGNCUT) = 1 Then
            C_IgnCut.Checked = True
        End If

        If ReadFlashByte(&H665F) = 0 Then
            C_Pair.Checked = True
            C_Pair.Text = "PAIR as output control"
            C_PairRpm12.Enabled = True
            C_PairRpm36.Enabled = True

        Else
            C_Pair.Text = "PAIR normal operation"
            C_PairRpm12.Enabled = False
            C_PairRpm36.Enabled = False

        End If

        If C_PairRpm12.Items.Count() = 0 Then
            C_PairRpm12.Items.Add(Int(ReadFlashWord(_SOLRPM12) / 2.56))
            For i = 8000 To 12000 Step 100
                C_PairRpm12.Items.Add(Int(i))
            Next
            C_PairRpm12.SelectedIndex = 0
        End If

        If C_PairRpm36.Items.Count() = 0 Then
            C_PairRpm36.Items.Add(Int(ReadFlashWord(_SOLRPM36) / 2.56))
            For i = 9000 To 12000 Step 100
                C_PairRpm36.Items.Add(Int(i))
            Next
            C_PairRpm36.SelectedIndex = 0
        End If


        C_6thGearKill.Enabled = True
        If ReadFlashWord(_GEAR6KILL) = 1 Then
            C_6thGearKill.Checked = True
        Else
            C_6thGearKill.Text = "Allow gear changes on 6th (GPS fault between gears)"
        End If

    End Sub

    Private Sub HideShifterSettings()

        L12.Visible = False
        L11.Visible = False
        L10.Visible = False
        L9.Visible = False
        L8.Visible = False
        L7.Visible = False
        L6.Visible = False
        L5.Visible = False
        L4.Visible = False
        L3.Visible = False
        L2.Visible = False        'Added 11.9.2009 JaSa

        T_12000.Visible = False
        T_11000.Visible = False
        T_10000.Visible = False
        T_9000.Visible = False
        T_8000.Visible = False
        T_7000.Visible = False
        T_6000.Visible = False
        T_5000.Visible = False
        T_4000.Visible = False
        T_3000.Visible = False
        T_2000.Visible = False    'Added 11.9.2009 JaSa

        C_KillTime.Enabled = False

        C_FuelCut.Enabled = False
        C_IgnCut.Enabled = False
        C_Pair.Enabled = False

        C_6thGearKill.Enabled = False

        C_PairRpm12.Enabled = False
        C_PairRpm36.Enabled = False

        T_MinKillActive.Visible = False
        T_KillCountDelay.Visible = False
        L_MinKillActive.Visible = False
        L_KillCountDelay.Visible = False

    End Sub

#End Region

End Class
