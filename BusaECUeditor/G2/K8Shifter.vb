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

Public Class K8shifter
    Dim ADJ As Integer = &H55400 '&HFF if shifter inactive, no code present else shifter active
    Dim FUELCODE As Integer = &H55450
    Dim IGNCODE As Integer = &H55730
    Dim IDTAG As Integer = &H55400
    Dim minkillactive As Integer = ADJ + &H16
    Dim killcountdelay As Integer = ADJ + &H18
    Dim SHIFTER2VERSION As Integer = 204
    Dim shiftercodelenght As Integer = &H55800 - &H55400 - 1 'lenght of the shifter code in bytes for clearing the memory
    Dim timerconst = 1 / 1.28
    Dim initiating As Boolean = True


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (ReadFlashByte(ADJ) <> &HFF) Then
            WriteFlashWord((ADJ + 2), (Val(T_12000.Text)) / timerconst)
            WriteFlashWord((ADJ + 4), (Val(T_11000.Text)) / timerconst)
            WriteFlashWord((ADJ + 6), (Val(T_10000.Text)) / timerconst)
            WriteFlashWord((ADJ + 8), (Val(T_9000.Text)) / timerconst)
            WriteFlashWord((ADJ + &HA), (Val(T_8000.Text)) / timerconst)
            WriteFlashWord((ADJ + &HC), (Val(T_7000.Text)) / timerconst)
            WriteFlashWord(minkillactive, Val(T_minkillactive.Text))
            WriteFlashWord(killcountdelay, Val(T_killcountdelay.Text))

        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_shifter_activation.CheckedChanged
        If C_shifter_activation.Checked Then
            C_shifter_activation.Text = "Shifter active"
            If (ReadFlashByte(ADJ) = &HFF) Then
                modify_original_ECU_code(True)
                shifter_code_in_memory(True, shiftercodelenght)
            End If
            read_shifter_settings()
        Else
            C_shifter_activation.Text = "Shifter not active"
            modify_original_ECU_code(False)
            shifter_code_in_memory(False, shiftercodelenght)
            hide_shifter_settings()
        End If
    End Sub

    Private Sub K8shifter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
        If e.KeyChar = "P" Or e.KeyChar = "p" Then
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
            PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
            PrintForm1.Print()
        End If
    End Sub

    Private Sub shifter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        For i = 3 To 12
            C_killtime.Items.Add(Str(10 * i))
        Next

        initiating = False
        L_shifterver.Text = Str(SHIFTER2VERSION)

        If (ReadFlashByte(ADJ) = &HFF) Then
            C_shifter_activation.Checked = False
            hide_shifter_settings()
        Else
            C_shifter_activation.Checked = True
            read_shifter_settings()
            'shifter_code_in_memory(True, shiftercodelenght)
            If (ReadFlashWord(IDTAG) <> SHIFTER2VERSION) Then
                MsgBox("Shifter code incompatible with this version, please reactivate the shifter on this map " & ReadFlashWord(IDTAG).ToString)
                C_shifter_activation.Checked = False
                hide_shifter_settings()
            End If
        End If



    End Sub

    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        Dim pcdisp As Integer

        If method Then
            '
            ' Lets activate a branch to shifter code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the shifter code
            ' as part of each main loop
            '
            pcdisp = (FUELCODE - &H408EC) / 4
            WriteFlashWord(&H408EC, &HFF00) ' bra.l 
            WriteFlashWord(&H408EE, pcdisp) '         pcdisp
            WriteFlashByte(&H1C77B, &H1F) ' sensor low limit
            WriteFlashByte(&H1D123, &H2C) ' sensor low limit
            '
            ' Ignition
            '
            pcdisp = (IGNCODE - &H37330) / 4
            WriteFlashWord(&H37330, &HFF00) ' bra.l 
            WriteFlashWord(&H37332, pcdisp) '         pcdisp

        Else
            '
            ' bring the ecu code back to original
            '
            WriteFlashWord(&H408EC, &H4F10) ' addi sp, #0x10
            WriteFlashWord(&H408EE, &H1FCE) ' jmp lr
            WriteFlashByte(&H1C77B, &H1F) ' sensor low limit
            WriteFlashByte(&H1D123, &H2C) ' sensor low limit
            '
            ' Ignition
            '
            WriteFlashWord(&H37330, &H4F10) ' addi sp, #0x10
            WriteFlashWord(&H37332, &H1FCE) ' jmp lr

        End If
    End Sub
    Private Sub shifter_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\shiftergen2.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("Shifter code not found at: " & path, MsgBoxStyle.Critical)
            C_shifter_activation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the shifter code into memory address from the .bin file
            '
            WriteFlashByte(ADJ, &H0)
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                Flash(i + ADJ) = b(0)
                i = i + 1
            Loop
            fs.Close()

            If ReadFlashWord(IDTAG) <> SHIFTER2VERSION Then
                MsgBox("This shifter code is not compatible with this ECUeditor version !!! " & ReadFlashWord(IDTAG).ToString)
                For i = 0 To lenght
                    WriteFlashByte(i + ADJ, &HFF)
                Next
                Me.Close()
            End If
        Else
            ' reset the shifter code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                WriteFlashByte(i + ADJ, &HFF)
            Next
        End If
    End Sub
    Private Sub read_shifter_settings()

        Dim i As Integer

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
        T_12000.Text = Round5(ReadFlashWord(ADJ + 2) * timerconst)
        T_11000.Text = Round5(ReadFlashWord(ADJ + 4) * timerconst)
        T_10000.Text = Round5(ReadFlashWord(ADJ + 6) * timerconst)
        T_9000.Text = Round5(ReadFlashWord(ADJ + 8) * timerconst)
        T_8000.Text = Round5(ReadFlashWord(ADJ + &HA) * timerconst)
        T_7000.Text = Round5(ReadFlashWord(ADJ + &HC) * timerconst)

        'Dim i As Integer
        'i = ReadFlashWord(ADJ + 26)
        'i = ReadFlashWord(ADJ + 28)

        If ReadFlashWord(ADJ + 26) = 1 Then
            C_Fuelcut.Checked = True
        Else
            C_Fuelcut.Checked = False
        End If
        If ReadFlashWord(ADJ + 28) = 1 Then
            C_igncut.Checked = True
        Else
            C_igncut.Checked = False
        End If
        If ReadFlashByte(&H55420) = 0 Then
            C_DSMactivation.Checked = False
            C_DSMactivation.Text = "Normal GPS resistor activation"
        Else
            C_DSMactivation.Checked = True
            C_DSMactivation.Text = "GPS resistor and DSM2 activation"
        End If

        L_minkillactive.Visible = True
        L_killcountdelay.Visible = True
        T_minkillactive.Visible = True
        T_killcountdelay.Visible = True
        T_minkillactive.Text = ReadFlashWord(minkillactive)
        T_killcountdelay.Text = ReadFlashWord(killcountdelay)
        C_killtime.Enabled = True
        C_Fuelcut.Visible = True
        C_igncut.Visible = True
        C_DSMactivation.Visible = True
        RPM.Visible = True

        'populate RPM with initial value
        i = ReadFlashWord(&H5540E) ' this is the reference RPM that is stored in the system
        i = i / 2.56
        i = CInt(i / 50) * 50 'the conversions are not exact, Round it up to the closest 50 to avoid confusion

        Me.RPM.Items.Add(i.ToString())

        i = 2000
        Do While i < 13000 ' this is the maximum rpm allowed 
            Me.RPM.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.RPM.Items.Add(i.ToString())

        Me.RPM.SelectedIndex = 0
        Me.RPM.Enabled = True

    End Sub

    Private Sub hide_shifter_settings()


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
        C_killtime.Enabled = False

        T_minkillactive.Visible = False
        T_killcountdelay.Visible = False
        L_minkillactive.Visible = False
        L_killcountdelay.Visible = False
        C_Fuelcut.Visible = False
        C_igncut.Visible = False

        C_DSMactivation.Visible = False

        RPM.Visible = False

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_killtime.SelectedIndexChanged
        If Not initiating Then
            T_12000.Text = C_killtime.Text
            T_11000.Text = C_killtime.Text
            T_10000.Text = C_killtime.Text
            T_9000.Text = C_killtime.Text
            T_8000.Text = C_killtime.Text
            T_7000.Text = C_killtime.Text
            T_6000.Text = C_killtime.Text
            T_5000.Text = C_killtime.Text
            T_4000.Text = C_killtime.Text
            T_3000.Text = C_killtime.Text

            WriteFlashWord((ADJ + 2), (Val(T_12000.Text)) / timerconst)
            WriteFlashWord((ADJ + 4), (Val(T_11000.Text)) / timerconst)
            WriteFlashWord((ADJ + 6), (Val(T_10000.Text)) / timerconst)
            WriteFlashWord((ADJ + 8), (Val(T_9000.Text)) / timerconst)
            WriteFlashWord((ADJ + &HA), (Val(T_8000.Text)) / timerconst)
            WriteFlashWord((ADJ + &HC), (Val(T_7000.Text)) / timerconst)
        End If

    End Sub

    Private Sub T_killcountdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_killcountdelay.TextChanged
        If Val(T_killcountdelay.Text) > 4000 Then T_killcountdelay.Text = "4000"
        If Val(T_killcountdelay.Text) <= 1 Then T_killcountdelay.Text = "1"
    End Sub



    Private Sub C_Fuelcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Fuelcut.CheckedChanged
        If C_Fuelcut.Checked Then
            C_Fuelcut.Text = "Fuelcut active"
            WriteFlashWord(ADJ + 26, 1)
        Else
            If Not C_igncut.Checked Then C_igncut.Checked = True
            C_Fuelcut.Text = "Fuelcut not active"
            WriteFlashWord(ADJ + 26, 0)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_igncut.CheckedChanged
        If C_igncut.Checked Then
            C_igncut.Text = "Igncut active"
            WriteFlashWord(ADJ + 28, 1)
        Else
            If Not C_Fuelcut.Checked Then C_Fuelcut.Checked = True
            C_igncut.Text = "Igncut not active"
            WriteFlashWord(ADJ + 28, 0)
        End If
    End Sub


    Private Sub T_12000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_12000.TextChanged
        WriteFlashWord((ADJ + 2), (Val(T_12000.Text)) / timerconst)
    End Sub

    Private Sub T_11000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_11000.TextChanged
        WriteFlashWord((ADJ + 4), (Val(T_11000.Text)) / timerconst)
    End Sub

    Private Sub T_10000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_10000.TextChanged
        WriteFlashWord((ADJ + 6), (Val(T_10000.Text)) / timerconst)
    End Sub

    Private Sub T_9000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_9000.TextChanged
        WriteFlashWord((ADJ + 8), (Val(T_9000.Text)) / timerconst)
    End Sub

    Private Sub T_8000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_8000.TextChanged
        WriteFlashWord((ADJ + &HA), (Val(T_8000.Text)) / timerconst)
    End Sub

    Private Sub T_7000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_7000.TextChanged
        WriteFlashWord((ADJ + &HC), (Val(T_7000.Text)) / timerconst)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WriteFlashByte(&H525C5, &H80)
        WriteFlashByte(&H525C6, &H68)
        WriteFlashByte(&H525C7, &H65)
    End Sub

    Private Sub CheckBox1_CheckedChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_DSMactivation.CheckedChanged
        If Not C_DSMactivation.Checked Then
            C_DSMactivation.Text = "Normal GPS resistor activation"
            WriteFlashByte(&H55420, 0)
        Else
            If Not C_DSMactivation.Checked Then C_Fuelcut.Checked = True
            C_DSMactivation.Text = "GPS resistor and DSM2 activation"
            K8Advsettings.C_ABCmode.Checked = False
            WriteFlashByte(&H55420, 1) ' 1 = DSM2, 2 = DSM1
        End If

    End Sub

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM.SelectedIndexChanged
        Dim i As Integer
        i = Val(RPM.Text) * 2.56
        i = CInt(i / 50) * 50
        WriteFlashWord(&H5540E, i)
    End Sub
End Class
