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

Public Class shifter
    Dim ADJ As Integer = &H15700 '&HFF if shifter inactive, no code present else shifter active
    Dim FUELCODE As Integer = &H15800
    Dim IGNCODE As Integer = &H157B0
    Dim IDTAG As Integer = &H15740              'Ref Shifter2.c const_pgmid
    Dim IGNCUT As Integer = IDTAG + 2           'Ref Shifter2.c igncut
    Dim FUELCUT As Integer = IDTAG + 3          'Ref Shifter2.c fuelcut
    Dim minkillactive As Integer = ADJ + 22     'Ref Shifter2.c minkillactive - Changed 11.8.2009 JaSa - orig value (10*2)
    Dim killcountdelay As Integer = ADJ + 24    'Ref Shifter2.c killcountdelay Changed 11.8.2009 JaSa - orig value (11*2)
    Dim SOLRPM12 As Integer = ADJ + 28          'Ref Shifter2.c s_GEAR12 - Changed 11.8.2009 JaSa - orig value 26
    Dim SOLRPM36 As Integer = ADJ + 30          'Ref Shifter2.c s_GEAR3456 - Changed 11.8.2009 JaSa - orig value 28
    Dim GEAR6KILL As Integer = ADJ + 32         'Ref Shifter2.c - Changed 11.8.2009 JaSa - orig value 30
    Dim SHIFTER2VERSION As Integer = 200        'changed 11.8.2009 JaSa - orig value 101
    Dim shiftercodelenght As Integer = &H700    'lenght of the shifter code in bytes for clearing the memory
    Dim timerconst = 2.56


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If (readflashbyte(ADJ) <> &HFF) Then
            writeflashword((ADJ), (Val(T_12000.Text) * 12) / timerconst)
            writeflashword((ADJ + 2), (Val(T_11000.Text) * 11) / timerconst)
            writeflashword((ADJ + 4), (Val(T_10000.Text) * 10) / timerconst)
            writeflashword((ADJ + 6), (Val(T_9000.Text) * 9) / timerconst)
            writeflashword((ADJ + 8), (Val(T_8000.Text) * 8) / timerconst)
            writeflashword((ADJ + 10), (Val(T_7000.Text) * 7) / timerconst)
            writeflashword((ADJ + 12), (Val(T_6000.Text) * 6) / timerconst)
            writeflashword((ADJ + 14), (Val(T_5000.Text) * 5) / timerconst)
            writeflashword((ADJ + 16), (Val(T_4000.Text) * 4) / timerconst)
            writeflashword((ADJ + 18), (Val(T_3000.Text) * 3) / timerconst)
            writeflashword(ADJ + 20, (Val(T_2000.Text) * 2) / timerconst)     'Added 11.8.2009 JaSa

            writeflashword(minkillactive, Val(T_minkillactive.Text))
            writeflashword(killcountdelay, Val(T_killcountdelay.Text))
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_shifter_activation.CheckedChanged
        If C_shifter_activation.Checked Then
            C_shifter_activation.Text = "Shifter active"
            If (readflashbyte(ADJ) = &HFF) Then
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

    Private Sub shifter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer

        If (readflashbyte(ADJ) = &HFF) Then
            C_shifter_activation.Checked = False
            hide_shifter_settings()
            L_Neutral.Text = "Using Neutral gear during shifter operation"
        Else
            C_shifter_activation.Checked = True
            read_shifter_settings()
            'shifter_code_in_memory(True, shiftercodelenght)
            L_Neutral.Text = "Using 6th gear during shifter operation"

            If (readflashword(IDTAG) <> SHIFTER2VERSION) Then
                MsgBox("Shifter code incompatible with this version, please reactivate the shifter on this map")
                C_shifter_activation.Checked = False
                hide_shifter_settings()
                L_Neutral.Text = "Using Neutral gear during shifter operation"
            End If
        End If



            For i = 3 To 12
                C_killtime.Items.Add(Str(10 * i))
            Next
    End Sub

    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        If method Then
            writeflashlongword(&HE46C, FUELCODE)    '@r3, jsraddr to shifter code which includes jsr to original code
            writeflashword(&HE28C, &H432B)              '0100001100101011 jmp @r3
            writeflashbyte(&H7E5B, &H40)                 'Threshold for low voltage 6th map raised to same as limiter
            L_Neutral.Text = "Using 6th gear during shifter operation"
            writeflashword(&H12F96, &H432B)        '0100001100101011 jmp @r3
            writeflashlongword(&H13080, IGNCODE)    'IGN code start addr

        Else
            writeflashlongword(&HE46C, &H11E90)         '@r3, original ecu code
            writeflashword(&HE28C, &H430B)              '0100001100001011 jsr @r3
            writeflashbyte(&H7E5B, &H2C)                 'Threshold for low voltage 6th map set to original
            L_Neutral.Text = "Using Neutral gear during shifter operation"
            writeflashword(&H12F96, &H430B)         '0100001100001011 jsr @r3
            writeflashlongword(&H13080, &HB078)     'Original IGN code start addr

        End If
    End Sub
    Private Sub shifter_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\G1\shifter2.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("Shifter code not found at: " & path, MsgBoxStyle.Critical)
            C_shifter_activation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the shifter code into memory address from the .bin file
            '
            writeflashbyte(ADJ, &H0)
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                Flash(i + ADJ) = b(0)
                i = i + 1
            Loop
            fs.Close()

            If readflashword(IDTAG) <> SHIFTER2VERSION Then
                MsgBox("This shifter code is not compatible with this ECUeditor version !!!")
                For i = 0 To lenght
                    writeflashbyte(i + ADJ, &HFF)
                Next
                Me.Close()
            End If
        Else
            ' reset the shifter code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                writeflashbyte(i + ADJ, &HFF)
            Next
        End If
    End Sub
    Private Sub read_shifter_settings()

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

        T_12000.Text = round5(readflashword(ADJ + 0) / 12 * timerconst)
        T_11000.Text = round5(readflashword(ADJ + 2) / 11 * timerconst)
        T_10000.Text = round5(readflashword(ADJ + 4) / 10 * timerconst)
        T_9000.Text = round5(readflashword(ADJ + 6) / 9 * timerconst)
        T_8000.Text = round5(readflashword(ADJ + 8) / 8 * timerconst)
        T_7000.Text = round5(readflashword(ADJ + 10) / 7 * timerconst)
        T_6000.Text = round5(readflashword(ADJ + 12) / 6 * timerconst)
        T_5000.Text = round5(readflashword(ADJ + 14) / 5 * timerconst)
        T_4000.Text = round5(readflashword(ADJ + 16) / 4 * timerconst)
        T_3000.Text = round5(readflashword(ADJ + 18) / 3 * timerconst)
        T_2000.Text = round5(readflashword(ADJ + 20) / 2 * timerconst)  'Added 11.8.2009 JaSa

        L_minkillactive.Visible = True
        L_killcountdelay.Visible = True
        T_minkillactive.Visible = True
        T_killcountdelay.Visible = True
        T_minkillactive.Text = readflashword(minkillactive)
        T_killcountdelay.Text = readflashword(killcountdelay)
        C_killtime.Enabled = True
        C_pair.Enabled = True

        C_fuelcut.Enabled = True
        C_Igncut.Enabled = True

        If readflashbyte(FUELCUT) = 1 Then
            C_fuelcut.Checked = True
        End If

        If readflashbyte(IGNCUT) = 1 Then
            C_Igncut.Checked = True
        End If

        If readflashbyte(&H665F) = 0 Then
            C_pair.Checked = True
            C_pair.Text = "PAIR as output control"
            C_pairrpm12.Enabled = True
            C_pairrpm36.Enabled = True

        Else
            C_pair.Text = "PAIR normal operation"
            C_pairrpm12.Enabled = False
            C_pairrpm36.Enabled = False

        End If

        If C_pairrpm12.Items.Count() = 0 Then
            C_pairrpm12.Items.Add(Int(readflashword(SOLRPM12) / 2.56))
            For i = 8000 To 12000 Step 100
                C_pairrpm12.Items.Add(Int(i))
            Next
            C_pairrpm12.SelectedIndex = 0
        End If

        If C_pairrpm36.Items.Count() = 0 Then
            C_pairrpm36.Items.Add(Int(readflashword(SOLRPM36) / 2.56))
            For i = 9000 To 12000 Step 100
                C_pairrpm36.Items.Add(Int(i))
            Next
            C_pairrpm36.SelectedIndex = 0
        End If


        C_6thGearKill.Enabled = True
        If readflashword(GEAR6KILL) = 1 Then
            C_6thGearKill.Checked = True
        Else
            C_6thGearKill.Text = "Allow gear changes on 6th (GPS fault between gears)"
        End If

    End Sub

    Private Sub hide_shifter_settings()

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

        C_killtime.Enabled = False

        C_fuelcut.Enabled = False
        C_Igncut.Enabled = False
        C_pair.Enabled = False

        C_6thGearKill.Enabled = False

        C_pairrpm12.Enabled = False
        C_pairrpm36.Enabled = False

        T_minkillactive.Visible = False
        T_killcountdelay.Visible = False
        L_minkillactive.Visible = False
        L_killcountdelay.Visible = False

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_killtime.SelectedIndexChanged
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
        T_2000.Text = C_killtime.Text               'Added 11.8.2009 JaSa

        writeflashword((ADJ), (Val(T_12000.Text) * 12) / timerconst)
        writeflashword((ADJ + 2), (Val(T_11000.Text) * 11) / timerconst)
        writeflashword((ADJ + 4), (Val(T_10000.Text) * 10) / timerconst)
        writeflashword((ADJ + 6), (Val(T_9000.Text) * 9) / timerconst)
        writeflashword((ADJ + 8), (Val(T_8000.Text) * 8) / timerconst)
        writeflashword((ADJ + 10), (Val(T_7000.Text) * 7) / timerconst)
        writeflashword((ADJ + 12), (Val(T_6000.Text) * 6) / timerconst)
        writeflashword((ADJ + 14), (Val(T_5000.Text) * 5) / timerconst)
        writeflashword((ADJ + 16), (Val(T_4000.Text) * 4) / timerconst)
        writeflashword((ADJ + 18), (Val(T_3000.Text) * 3) / timerconst)
        writeflashword((ADJ + 20), (Val(T_2000.Text) * 2) / timerconst) 'Added 11.8.2009

    End Sub

    Private Sub B_install_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_install.Click
        Shifter_Instructions.Show()
    End Sub


    Private Sub C_pair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_pair.CheckedChanged

        If C_pair.Checked = True Then
            writeflashbyte(&H665F, &H0)         'Pair set to no write to port
            C_pair.Text = "PAIR as output control"
            C_pairrpm12.Enabled = True
            C_pairrpm36.Enabled = True

        Else
            writeflashbyte(&H665F, &H3)         'Pair set to write to port
            C_pair.Text = "PAIR normal operation"
            C_pairrpm12.Enabled = False
            C_pairrpm36.Enabled = False

        End If

    End Sub

    Private Sub C_fuelcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_fuelcut.CheckedChanged
        If C_fuelcut.Checked Then
            writeflashbyte(FUELCUT, 1)
        Else
            writeflashbyte(FUELCUT, 0)
            If C_Igncut.Checked = False Then
                C_Igncut.Checked = True
            End If

        End If
    End Sub

    Private Sub C_Igncut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Igncut.CheckedChanged
        If C_Igncut.Checked Then
            writeflashbyte(IGNCUT, 1)
        Else
            writeflashbyte(IGNCUT, 0)
            If C_fuelcut.Checked = False Then
                C_fuelcut.Checked = True
            End If
        End If
    End Sub

    Private Sub C_pairrpm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_pairrpm12.SelectedIndexChanged
        writeflashword(SOLRPM12, Int(Val(C_pairrpm12.Text) * 2.56))
    End Sub

    Private Sub C_pairrpm36_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_pairrpm36.SelectedIndexChanged
        writeflashword(SOLRPM36, Int(Val(C_pairrpm36.Text) * 2.56))
    End Sub

    Private Sub C_6thGearKill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_6thGearKill.CheckedChanged
        If C_6thGearKill.Checked Then
            writeflashword(GEAR6KILL, 1)
            C_6thGearKill.Text = "No kill on 6th gear"
        Else
            writeflashword(GEAR6KILL, 0)
            C_6thGearKill.Text = "Allow gear changes on 6th (GPS fault between gears)"
        End If
    End Sub

    
    Private Sub T_killcountdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_killcountdelay.TextChanged
        If Val(T_killcountdelay.Text) > 4000 Then T_killcountdelay.Text = "4000"
        If Val(T_killcountdelay.Text) <= 1 Then T_killcountdelay.Text = "1"
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class
