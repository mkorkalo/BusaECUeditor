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

Imports System.Windows.Forms
Imports System.IO

Public Class GixxerShifter
 

    Dim IDTAG As Integer = gixxer_shifter_ADJ
    Dim minkillactive As Integer = gixxer_shifter_ADJ + &H16
    Dim killcountdelay As Integer = gixxer_shifter_ADJ + &H18
    Dim SHIFTER2VERSION As Integer = 100
    Dim shiftercodelenght As Integer = gixxer_shifter_IGNCODE + &H50 - gixxer_shifter_ADJ - 1 'lenght of the shifter code in bytes for clearing the memory, check this !!!
    Dim timerconst = 1 / 1.28
    Dim initiating As Boolean = True


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (ReadFlashByte(gixxer_shifter_ADJ) <> &HFF) Then
            WriteFlashWord((gixxer_shifter_ADJ + 2), (Val(T_12000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + 4), (Val(T_11000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + 6), (Val(T_10000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + 8), (Val(T_9000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + &HA), (Val(T_8000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + &HC), (Val(T_7000.Text)) / timerconst)
            WriteFlashWord(minkillactive, Val(T_minkillactive.Text))
            WriteFlashWord(killcountdelay, Val(T_killcountdelay.Text))

        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_shifter_activation.CheckedChanged
        If C_shifter_activation.Checked Then
            C_shifter_activation.Text = "Shifter active"
            If (ReadFlashByte(gixxer_shifter_ADJ) = &HFF) Then
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
            printthis()
        End If
    End Sub

    Private Sub shifter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        For i = 3 To 12
            C_killtime.Items.Add(Str(10 * i))
        Next

        initiating = False
        L_shifterver.Text = Str(SHIFTER2VERSION)
        P_shifterwiring.Image = Image.FromFile(".\gixxer\shifter.jpg")

        If (ReadFlashByte(gixxer_shifter_ADJ) = &HFF) Then
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
            pcdisp = (gixxer_shifter_FUELCODE - gixxer_shifter_jmp_to_fuelcode) / 4
            WriteFlashWord(gixxer_shifter_jmp_to_fuelcode, &HFF00) ' bra.l 
            WriteFlashWord(gixxer_shifter_jmp_to_fuelcode + 2, pcdisp) '         pcdisp
            '
            ' Ignition
            '
            pcdisp = (gixxer_shifter_IGNCODE - gixxer_shifter_jmp_to_igncode) / 4
            WriteFlashWord(gixxer_shifter_jmp_to_igncode, &HFF00) ' bra.l 
            WriteFlashWord(gixxer_shifter_jmp_to_igncode + 2, pcdisp) '         pcdisp

        Else
            '
            ' bring the ecu code back to original
            '
            WriteFlashWord(gixxer_shifter_jmp_to_fuelcode, &H4F10) ' addi sp, #0x10
            WriteFlashWord(gixxer_shifter_jmp_to_fuelcode + 2, &H1FCE) ' jmp lr
            '
            ' Ignition
            '
            WriteFlashWord(gixxer_shifter_jmp_to_igncode, &H4F10) ' addi sp, #0x10
            WriteFlashWord(gixxer_shifter_jmp_to_igncode + 2, &H1FCE) ' jmp lr

        End If
    End Sub
    Private Sub shifter_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\gixxershifter.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("Shifter code not found at: " & path, MsgBoxStyle.Critical)
            C_shifter_activation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the shifter code into memory address from the .bin file
            '
            WriteFlashByte(gixxer_shifter_ADJ, &H0)
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                Flash(i + gixxer_shifter_ADJ) = b(0)
                i = i + 1
            Loop
            fs.Close()

            If ReadFlashWord(IDTAG) <> SHIFTER2VERSION Then
                MsgBox("This shifter code is not compatible with this ECUeditor version !!! " & ReadFlashWord(IDTAG).ToString)
                For i = 0 To lenght
                    WriteFlashByte(i + gixxer_shifter_ADJ, &HFF)
                Next
                Me.Close()
            End If
        Else
            ' reset the shifter code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                WriteFlashByte(i + gixxer_shifter_ADJ, &HFF)
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
        T_12000.Text = Round5(ReadFlashWord(gixxer_shifter_ADJ + 2) * timerconst)
        T_11000.Text = Round5(ReadFlashWord(gixxer_shifter_ADJ + 4) * timerconst)
        T_10000.Text = Round5(ReadFlashWord(gixxer_shifter_ADJ + 6) * timerconst)
        T_9000.Text = Round5(ReadFlashWord(gixxer_shifter_ADJ + 8) * timerconst)
        T_8000.Text = Round5(ReadFlashWord(gixxer_shifter_ADJ + &HA) * timerconst)
        T_7000.Text = Round5(ReadFlashWord(gixxer_shifter_ADJ + &HC) * timerconst)

        'Dim i As Integer
        'i = ReadFlashWord(ADJ + 26)
        'i = ReadFlashWord(ADJ + 28)

        If ReadFlashWord(gixxer_shifter_ADJ + 26) = 1 Then
            C_Fuelcut.Checked = True
        Else
            C_Fuelcut.Checked = False
        End If
        If ReadFlashWord(gixxer_shifter_ADJ + 28) = 1 Then
            C_igncut.Checked = True
        Else
            C_igncut.Checked = False
        End If
        If ReadFlashByte(gixxer_shifter_ADJ + &H20) = 0 Then
            C_DSMactivation.Checked = False
            C_DSMactivation.Text = "Normal GPS resistor activation"
            WriteFlashByte(gixxer_shifter_ADJ + &H20, 0)
            G_DSMACTIVATION.Visible = False
            Me.Height = 613
        Else
            C_DSMactivation.Checked = True
            C_DSMactivation.Text = "DSM2 and resistor activation"
            G_DSMACTIVATION.Visible = True
            'If ReadFlashByte(&H72558) = &HFF Then
            ' K8Advsettings.Show()
            ' If K8Advsettings.C_ABCmode.Checked <> False Then
            '  K8Advsettings.C_ABCmode.Checked = False
            'End If
            'Me.Focus()
            'End If
            WriteFlashByte(gixxer_shifter_ADJ + &H20, 1) ' 1 = DSM2, 2 = DSM1
            Me.Height = 265
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
        RPM1.Visible = True

        'populate RPM with initial value
        populaterpm(ReadFlashWord(gixxer_shifter_ADJ + &HE), Me.RPM1) ' this is the reference RPM that is stored in the system
        populaterpm(ReadFlashWord(gixxer_shifter_ADJ + &H10), Me.RPM2) ' this is the reference RPM that is stored in the system
        populaterpm(ReadFlashWord(gixxer_shifter_ADJ + &H12), Me.RPM3) ' this is the reference RPM that is stored in the system
        populaterpm(ReadFlashWord(gixxer_shifter_ADJ + &H14), Me.RPM456) ' this is the reference RPM that is stored in the system



    End Sub

    Private Sub populaterpm(ByVal r As Integer, ByVal c As ComboBox)
        Dim i As Integer

        i = r / 2.56
        i = CInt(i / 50) * 50 'the conversions are not exact, Round it up to the closest 50 to avoid confusion
        c.Items.Add(i.ToString())
        i = 2000
        Do While i < 13000 ' this is the maximum rpm allowed 
            c.Items.Add(i.ToString())
            i = i + 100
        Loop
        c.Items.Add(i.ToString())
        c.SelectedIndex = 0
        c.Enabled = True

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

        RPM1.Visible = False
        G_DSMACTIVATION.Visible = False

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

            WriteFlashWord((gixxer_shifter_ADJ + 2), (Val(T_12000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + 4), (Val(T_11000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + 6), (Val(T_10000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + 8), (Val(T_9000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + &HA), (Val(T_8000.Text)) / timerconst)
            WriteFlashWord((gixxer_shifter_ADJ + &HC), (Val(T_7000.Text)) / timerconst)
        End If

    End Sub

    Private Sub T_killcountdelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_killcountdelay.TextChanged
        If Val(T_killcountdelay.Text) > 1000 Then T_killcountdelay.Text = "1000"
        If Val(T_killcountdelay.Text) <= 1 Then T_killcountdelay.Text = "1"
        WriteFlashWord(gixxer_shifter_ADJ + 24, Val(T_killcountdelay.Text))

    End Sub



    Private Sub C_Fuelcut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_Fuelcut.CheckedChanged
        If C_Fuelcut.Checked Then
            C_Fuelcut.Text = "Fuelcut active"
            WriteFlashWord(gixxer_shifter_ADJ + 26, 1)
        Else
            If Not C_igncut.Checked Then C_igncut.Checked = True
            C_Fuelcut.Text = "Fuelcut not active"
            WriteFlashWord(gixxer_shifter_ADJ + 26, 0)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_igncut.CheckedChanged
        If C_igncut.Checked Then
            C_igncut.Text = "Igncut active"
            WriteFlashWord(gixxer_shifter_ADJ + 28, 1)
        Else
            If Not C_Fuelcut.Checked Then C_Fuelcut.Checked = True
            C_igncut.Text = "Igncut not active"
            WriteFlashWord(gixxer_shifter_ADJ + 28, 0)
        End If
    End Sub


    Private Sub T_12000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_12000.TextChanged
        WriteFlashWord((gixxer_shifter_ADJ + 2), (Val(T_12000.Text)) / timerconst)
    End Sub

    Private Sub T_11000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_11000.TextChanged
        WriteFlashWord((gixxer_shifter_ADJ + 4), (Val(T_11000.Text)) / timerconst)
    End Sub

    Private Sub T_10000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_10000.TextChanged
        WriteFlashWord((gixxer_shifter_ADJ + 6), (Val(T_10000.Text)) / timerconst)
    End Sub

    Private Sub T_9000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_9000.TextChanged
        WriteFlashWord((gixxer_shifter_ADJ + 8), (Val(T_9000.Text)) / timerconst)
    End Sub

    Private Sub T_8000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_8000.TextChanged
        WriteFlashWord((gixxer_shifter_ADJ + &HA), (Val(T_8000.Text)) / timerconst)
    End Sub

    Private Sub T_7000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_7000.TextChanged
        WriteFlashWord((gixxer_shifter_ADJ + &HC), (Val(T_7000.Text)) / timerconst)
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    WriteFlashByte(&H525C5, &H80)
    '    WriteFlashByte(&H525C6, &H68)
    '    WriteFlashByte(&H525C7, &H65)
    'End Sub

    Private Sub CheckBox1_CheckedChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_DSMactivation.CheckedChanged
        If Not initiating Then

            If Not C_DSMactivation.Checked Then
                C_DSMactivation.Text = "Normal GPS resistor activation"
                P_shifterwiring.Image = Image.FromFile(".\gixxer\shifter.jpg")
                WriteFlashByte(gixxer_shifter_ADJ + &H20, 0)
                G_DSMACTIVATION.Visible = False
                Me.Height = 613
            Else
                C_DSMactivation.Text = "DSM2 and resistor activation"
                P_shifterwiring.Image = Image.FromFile(".\gixxer\shifter_DSM.jpg")
                '
                ' Not possible with Gixxer to disable ABC mode
                '
                '  If ReadFlashByte(&H72558) = &HFF Then
                ' K8Advsettings.Show()
                ' If K8Advsettings.C_ABCmode.Checked <> False Then
                ' K8Advsettings.C_ABCmode.Checked = False
                'End If
                'Me.Focus()
                'End If
                WriteFlashByte(gixxer_shifter_ADJ + &H20, 1) ' 1 = DSM2, 2 = DSM1
                G_DSMACTIVATION.Visible = True
                Me.Height = 613 'Me.Height = 263
            End If
        End If

    End Sub

    Private Sub RPM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM1.SelectedIndexChanged
        Dim i As Integer
        i = Val(RPM1.Text) * 2.56
        i = CInt(i / 50) * 50
        WriteFlashWord(gixxer_shifter_ADJ + &HE, i)
    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM456.SelectedIndexChanged
        Dim i As Integer
        i = Val(RPM456.Text) * 2.56
        i = CInt(i / 50) * 50
        WriteFlashWord(gixxer_shifter_ADJ + &H14, i)
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM3.SelectedIndexChanged
        Dim i As Integer
        i = Val(RPM3.Text) * 2.56
        i = CInt(i / 50) * 50
        WriteFlashWord(gixxer_shifter_ADJ + &H12, i)
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPM2.SelectedIndexChanged
        Dim i As Integer
        i = Val(RPM2.Text) * 2.56
        i = CInt(i / 50) * 50
        WriteFlashWord(gixxer_shifter_ADJ + &H10, i)
    End Sub

    Private Sub T_minkillactive_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_minkillactive.TextChanged
        If Val(T_minkillactive.Text) > 100 Then T_minkillactive.Text = "100"
        If Val(T_minkillactive.Text) <= 1 Then T_minkillactive.Text = "1"
        WriteFlashWord(gixxer_shifter_ADJ + 22, Val(T_minkillactive.Text))
    End Sub
End Class
