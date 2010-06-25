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

Public Class BKingShifter

#Region "Variables"

    Dim _loading As Boolean
    Dim _ADJ As Integer = &H58400 '&HFF if shifter inactive, no code present else shifter active
    Dim _FUELCODE As Integer = &H58450
    Dim _IGNCODE As Integer = &H58700
    Dim _IDTAG As Integer = &H58400
    Dim _minKillActive As Integer = _ADJ + &H16
    Dim _killCountDelay As Integer = _ADJ + &H18
    Dim _shifter2Version As Integer = 203
    Dim _shifterCodeLength As Integer = &H58800 - &H58400 - 1 'length of the shifter code in bytes for clearing the memory
    Dim _timerConst = 1 / 1.28

#End Region

#Region "Form Events"

    Private Sub BKingShifter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _loading = True

        Dim i As Integer

        L_shifterver.Text = Str(_shifter2Version)

        If (readflashbyte(_ADJ) = &HFF) Then
            C_shifter_activation.Checked = False
            HideShifterSettings()
        Else
            C_shifter_activation.Checked = True
            ReadShifterSettings()
            ShifterCodeInMemory(True, _shifterCodeLength)

            If (readflashword(_IDTAG) <> _shifter2Version) Then
                MsgBox("Shifter code incompatible with this version, please reactivate the shifter on this map")
                C_shifter_activation.Checked = False
                HideShifterSettings()
            End If
        End If

        For i = 3 To 12
            C_killtime.Items.Add(Str(10 * i))
        Next

        _loading = False

    End Sub

    Private Sub BKingShifter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Chr(27) Then Me.Close()

        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
            PrintForm1.Print()
        End If

    End Sub

    Private Sub BKingShifter_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If C_shifter_activation.Checked = True Then

            writeflashword((_ADJ + 2), (Val(T_Gear1.Text)) / _timerConst)
            writeflashword((_ADJ + 4), (Val(T_Gear2.Text)) / _timerConst)
            writeflashword((_ADJ + 6), (Val(T_Gear3.Text)) / _timerConst)
            writeflashword((_ADJ + 8), (Val(T_Gear4.Text)) / _timerConst)
            writeflashword((_ADJ + 10), (Val(T_Gear5.Text)) / _timerConst)
            writeflashword((_ADJ + 12), (Val(T_Gear6.Text)) / _timerConst)

            writeflashword((_ADJ + 22), (Val(T_minkillactive.Text)))
            writeflashword((_ADJ + 24), (Val(T_killcountdelay.Text)))

        End If
    End Sub

#End Region

#Region "Control Events"

    Private Sub C_shifter_activation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_shifter_activation.CheckedChanged

        If C_shifter_activation.Checked Then

            C_shifter_activation.Text = "Shifter active"

            If (readflashbyte(_ADJ) = &HFF) Then
                ModifyOriginalECUCode(True)
                ShifterCodeInMemory(True, _shifterCodeLength)
            End If

            ReadShifterSettings()

        Else

            C_shifter_activation.Text = "Shifter not active"
            ModifyOriginalECUCode(False)
            ShifterCodeInMemory(False, _shifterCodeLength)
            HideShifterSettings()

        End If

    End Sub

    Private Sub C_killtime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_killtime.SelectedIndexChanged

        T_Gear1.Text = C_killtime.Text
        T_Gear2.Text = C_killtime.Text
        T_Gear3.Text = C_killtime.Text
        T_Gear4.Text = C_killtime.Text
        T_Gear5.Text = C_killtime.Text
        T_Gear6.Text = C_killtime.Text

    End Sub

    Private Sub T_minkillactive_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_minkillactive.TextChanged

        If Val(T_minkillactive.Text) > 50 Then
            T_minkillactive.Text = "50"
        End If

        If Val(T_minkillactive.Text) <= 1 Then
            T_minkillactive.Text = "1"
        End If

    End Sub

    Private Sub T_killcountdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_killcountdelay.TextChanged

        If Val(T_killcountdelay.Text) > 4000 Then
            T_killcountdelay.Text = "4000"
        End If

        If Val(T_killcountdelay.Text) <= 1 Then
            T_killcountdelay.Text = "1"
        End If

    End Sub

    Private Sub C_Fuelcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Fuelcut.CheckedChanged

        If C_Fuelcut.Checked Then
            C_Fuelcut.Text = "Fuelcut active"
            writeflashword(_ADJ + 26, 1)
        Else
            If Not C_igncut.Checked Then C_igncut.Checked = True
            C_Fuelcut.Text = "Fuelcut not active"
            writeflashword(_ADJ + 26, 0)
        End If

    End Sub

    Private Sub C_Igncut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_igncut.CheckedChanged

        If C_igncut.Checked Then
            C_igncut.Text = "Igncut active"
            writeflashword(_ADJ + 28, 1)
        Else
            If Not C_Fuelcut.Checked Then C_Fuelcut.Checked = True
            C_igncut.Text = "Igncut not active"
            writeflashword(_ADJ + 28, 0)
        End If

    End Sub

#End Region

#Region "Functions"

    Private Sub ModifyOriginalECUCode(ByVal method As Boolean)
        Dim pcdisp As Integer

        If method Then
            ' Lets activate a branch to shifter code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the shifter code
            ' as part of each main loop
            pcdisp = (_FUELCODE - &H43130) / 4
            writeflashword(&H43130, &HFF00) ' bra.l 
            writeflashword(&H43132, pcdisp) ' pcdisp

            ' Ignition
            pcdisp = (_IGNCODE - &H39C98) / 4
            writeflashword(&H39C98, &HFF00) ' bra.l 
            writeflashword(&H39C9A, pcdisp) ' pcdisp

        Else
            ' bring the ecu code back to original
            writeflashword(&H43130, &H4F10) ' addi sp, #0x10
            writeflashword(&H43132, &H1FCE) ' jmp lr

            ' Ignition
            writeflashword(&H39C98, &H4F10) ' addi sp, #0x10
            writeflashword(&H39C9A, &H1FCE) ' jmp lr

        End If
    End Sub

    Private Sub ShifterCodeInMemory(ByVal method As Boolean, ByVal length As Integer)

        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\shifterbking.bin"

        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("Shifter code not found at: " & path, MsgBoxStyle.Critical)
            C_shifter_activation.Checked = False
        End If

        If method And File.Exists(path) Then

            ' write the shifter code into memory address from the .bin file
            writeflashbyte(_ADJ, &H0)
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                Flash(i + _ADJ) = b(0)
                i = i + 1
            Loop

            fs.Close()

            If readflashword(_IDTAG) <> _shifter2Version Then
                MsgBox("This shifter code is not compatible with this ECUeditor version !!!")
                For i = 0 To length
                    writeflashbyte(i + _ADJ, &HFF)
                Next
                Me.Close()
            End If
        Else
            ' reset the shifter code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To length
                writeflashbyte(i + _ADJ, &HFF)
            Next
        End If
    End Sub

    Private Sub ReadShifterSettings()

        T_Gear1.Visible = True
        T_Gear2.Visible = True
        T_Gear3.Visible = True
        T_Gear4.Visible = True
        T_Gear5.Visible = True
        T_Gear6.Visible = True

        L_minkillactive.Visible = True
        L_killcountdelay.Visible = True
        T_minkillactive.Visible = True
        T_killcountdelay.Visible = True
        C_killtime.Enabled = True
        C_Fuelcut.Visible = True
        C_igncut.Visible = True

        T_Gear1.Text = round5(readflashword(_ADJ + 2) * _timerConst)
        T_Gear2.Text = round5(readflashword(_ADJ + 4) * _timerConst)
        T_Gear3.Text = round5(readflashword(_ADJ + 6) * _timerConst)
        T_Gear4.Text = round5(readflashword(_ADJ + 8) * _timerConst)
        T_Gear5.Text = round5(readflashword(_ADJ + 10) * _timerConst)
        T_Gear6.Text = round5(readflashword(_ADJ + 12) * _timerConst)

        If readflashword(_ADJ + 26) = 1 Then
            C_Fuelcut.Checked = True
        Else
            C_Fuelcut.Checked = False
        End If

        If readflashword(_ADJ + 28) = 1 Then
            C_igncut.Checked = True
        Else
            C_igncut.Checked = False
        End If

        T_minkillactive.Text = readflashword(_minKillActive)
        T_killcountdelay.Text = readflashword(_killCountDelay)

    End Sub

    Private Sub HideShifterSettings()

        T_Gear1.Visible = False
        T_Gear2.Visible = False
        T_Gear3.Visible = False
        T_Gear4.Visible = False
        T_Gear5.Visible = False
        T_Gear6.Visible = False

        C_killtime.Enabled = False

        T_minkillactive.Visible = False
        T_killcountdelay.Visible = False
        L_minkillactive.Visible = False
        L_killcountdelay.Visible = False
        C_Fuelcut.Visible = False
        C_igncut.Visible = False

    End Sub

#End Region

End Class