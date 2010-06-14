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
    Dim IGNCODE As Integer = &H55700
    Dim IDTAG As Integer = &H55400
    Dim minkillactive As Integer = ADJ + &H16
    Dim killcountdelay As Integer = ADJ + &H18
    Dim SHIFTER2VERSION As Integer = 203
    Dim shiftercodelenght As Integer = &H55800 - &H55400 - 1 'lenght of the shifter code in bytes for clearing the memory
    Dim timerconst = 1 / 1.28
    Dim initiating As Boolean = True


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (readflashbyte(ADJ) <> &HFF) Then
            writeflashword((ADJ + 2), (Val(T_12000.Text)) / timerconst)
            writeflashword((ADJ + 4), (Val(T_11000.Text)) / timerconst)
            writeflashword((ADJ + 6), (Val(T_10000.Text)) / timerconst)
            writeflashword((ADJ + 8), (Val(T_9000.Text)) / timerconst)
            writeflashword((ADJ + &HA), (Val(T_8000.Text)) / timerconst)
            writeflashword((ADJ + &HC), (Val(T_7000.Text)) / timerconst)
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

        If (readflashbyte(ADJ) = &HFF) Then
            C_shifter_activation.Checked = False
            hide_shifter_settings()
        Else
            C_shifter_activation.Checked = True
            read_shifter_settings()
            'shifter_code_in_memory(True, shiftercodelenght)
            If (readflashword(IDTAG) <> SHIFTER2VERSION) Then
                MsgBox("Shifter code incompatible with this version, please reactivate the shifter on this map")
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
            writeflashword(&H408EC, &HFF00) ' bra.l 
            writeflashword(&H408EE, pcdisp) '         pcdisp
            writeflashbyte(&H1C77B, &H1F) ' sensor low limit
            writeflashbyte(&H1D123, &H2C) ' sensor low limit
            '
            ' Ignition
            '
            pcdisp = (IGNCODE - &H37330) / 4
            writeflashword(&H37330, &HFF00) ' bra.l 
            writeflashword(&H37332, pcdisp) '         pcdisp

        Else
            '
            ' bring the ecu code back to original
            '
            writeflashword(&H408EC, &H4F10) ' addi sp, #0x10
            writeflashword(&H408EE, &H1FCE) ' jmp lr
            writeflashbyte(&H1C77B, &H1F) ' sensor low limit
            writeflashbyte(&H1D123, &H2C) ' sensor low limit
            '
            ' Ignition
            '
            writeflashword(&H37330, &H4F10) ' addi sp, #0x10
            writeflashword(&H37332, &H1FCE) ' jmp lr

        End If
    End Sub
    Private Sub shifter_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\shiftergen2.bin"
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
        T_12000.Text = round5(readflashword(ADJ + 2) * timerconst)
        T_11000.Text = round5(readflashword(ADJ + 4) * timerconst)
        T_10000.Text = round5(readflashword(ADJ + 6) * timerconst)
        T_9000.Text = round5(readflashword(ADJ + 8) * timerconst)
        T_8000.Text = round5(readflashword(ADJ + &HA) * timerconst)
        T_7000.Text = round5(readflashword(ADJ + &HC) * timerconst)

        'Dim i As Integer
        'i = readflashword(ADJ + 26)
        'i = readflashword(ADJ + 28)

        If readflashword(ADJ + 26) = 1 Then
            C_Fuelcut.Checked = True
        Else
            C_Fuelcut.Checked = False
        End If
        If readflashword(ADJ + 28) = 1 Then
            C_igncut.Checked = True
        Else
            C_igncut.Checked = False
        End If

        L_minkillactive.Visible = True
        L_killcountdelay.Visible = True
        T_minkillactive.Visible = True
        T_killcountdelay.Visible = True
        T_minkillactive.Text = readflashword(minkillactive)
        T_killcountdelay.Text = readflashword(killcountdelay)
        C_killtime.Enabled = True
        C_Fuelcut.Visible = True
        C_igncut.Visible = True


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

            writeflashword((ADJ + 2), (Val(T_12000.Text)) / timerconst)
            writeflashword((ADJ + 4), (Val(T_11000.Text)) / timerconst)
            writeflashword((ADJ + 6), (Val(T_10000.Text)) / timerconst)
            writeflashword((ADJ + 8), (Val(T_9000.Text)) / timerconst)
            writeflashword((ADJ + &HA), (Val(T_8000.Text)) / timerconst)
            writeflashword((ADJ + &HC), (Val(T_7000.Text)) / timerconst)
        End If

    End Sub

    Private Sub T_killcountdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_killcountdelay.TextChanged
        If Val(T_killcountdelay.Text) > 4000 Then T_killcountdelay.Text = "4000"
        If Val(T_killcountdelay.Text) <= 1 Then T_killcountdelay.Text = "1"
    End Sub



    Private Sub C_Fuelcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Fuelcut.CheckedChanged
        If C_Fuelcut.Checked Then
            C_Fuelcut.Text = "Fuelcut active"
            writeflashword(ADJ + 26, 1)
        Else
            If Not C_igncut.Checked Then C_igncut.Checked = True
            C_Fuelcut.Text = "Fuelcut not active"
            writeflashword(ADJ + 26, 0)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_igncut.CheckedChanged
        If C_igncut.Checked Then
            C_igncut.Text = "Igncut active"
            writeflashword(ADJ + 28, 1)
        Else
            If Not C_Fuelcut.Checked Then C_Fuelcut.Checked = True
            C_igncut.Text = "Igncut not active"
            writeflashword(ADJ + 28, 0)
        End If
    End Sub

  
    Private Sub T_12000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_12000.TextChanged
        writeflashword((ADJ + 2), (Val(T_12000.Text)) / timerconst)
    End Sub

    Private Sub T_11000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_11000.TextChanged
        writeflashword((ADJ + 4), (Val(T_11000.Text)) / timerconst)
    End Sub

    Private Sub T_10000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_10000.TextChanged
        writeflashword((ADJ + 6), (Val(T_10000.Text)) / timerconst)
    End Sub

    Private Sub T_9000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_9000.TextChanged
        writeflashword((ADJ + 8), (Val(T_9000.Text)) / timerconst)
    End Sub

    Private Sub T_8000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_8000.TextChanged
        writeflashword((ADJ + &HA), (Val(T_8000.Text)) / timerconst)
    End Sub

    Private Sub T_7000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_7000.TextChanged
        writeflashword((ADJ + &HC), (Val(T_7000.Text)) / timerconst)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        writeflashbyte(&H525C5, &H80)
        writeflashbyte(&H525C6, &H68)
        writeflashbyte(&H525C7, &H65)
    End Sub
End Class
