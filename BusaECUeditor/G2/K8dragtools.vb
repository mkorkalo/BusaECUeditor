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

Public Class K8dragtools
    Dim ADJ As Integer = &H5A000 '&HFF if dragtools inactive, no code present else dragtools active
    Dim dragtoolsCODE As Integer = &H5A100
    Dim IDTAG As Integer = &H5A000
    Dim dragtoolsVERSION As Integer = 100
    Dim dragtoolscodelenght As Integer = &H1000 'lenght of the dragtools code in bytes for clearing the memory
    Dim rpmconv As Long
    Dim addedrpm As Integer



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (ReadFlashByte(ADJ) <> &HFF) Then
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub K8dragtools_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case "p"
                printthis()
            Case "P"
                printthis()
            Case Chr(27)
                Me.Close()
        End Select


    End Sub

    Private Sub printthis()
        '
        '
        '

    End Sub

    Private Sub dragtools_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        L_dragtoolsver.Text = Str(dragtoolsVERSION)
        rpmconv = 3840000000 / &H100

        hide_settings()

        If (ReadFlashByte(ADJ) = &HFF) Then
            C_dragtools_activation.Checked = False
        Else
            C_dragtools_activation.Checked = True
            'dragtools_code_in_memory(True, dragtoolscodelenght)

            If (ReadFlashWord(IDTAG) <> dragtoolsVERSION) Then
                MsgBox("dragtools code incompatible with this version, please reactivate the dragtools on this map")
                C_dragtools_activation.Checked = False
            End If

        End If
        If C_dragtools_activation.Checked Then
            show_settings()
            generate_dragtools_table()
        End If
    End Sub
    Public Sub generate_dragtools_table()
        Dim i As Integer
        '
        'populate RPM RATES with initial value
        '
        i = ReadFlashWord(&H5A002) / 2.56 ' this is the reference that is stored in the system
        Me.C_GEAR1_RATE.Items.Add(i.ToString())
        i = 100
        Do While i < 5000 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.C_GEAR1_RATE.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.C_GEAR1_RATE.Items.Add(i.ToString())
        i = ReadFlashWord(&H5A004) / 2.56 ' this is the reference that is stored in the system
        Me.C_GEAR2_RATE.Items.Add(i.ToString())
        i = 100
        Do While i < 5000 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.C_GEAR2_RATE.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.C_GEAR2_RATE.Items.Add(i.ToString())
        i = ReadFlashWord(&H5A006) / 2.56 ' this is the reference that is stored in the system
        Me.C_GEAR36_RATE.Items.Add(i.ToString())
        i = 100
        Do While i < 5000 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.C_GEAR36_RATE.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.C_GEAR36_RATE.Items.Add(i.ToString())
        '
        ' Populate ignition retards with initial values
        '
        'populate RPM RATES with initial value
        i = ReadFlashWord(&H5A008) ' this is the reference that is stored in the system
        Me.C_GEAR1_RETARD.Items.Add(i.ToString())
        i = 0
        Do While i < 25 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.C_GEAR1_RETARD.Items.Add(i.ToString())
            i = i + 1
        Loop
        Me.C_GEAR1_RETARD.Items.Add(i.ToString())
        i = ReadFlashWord(&H5A00A) ' this is the reference RPM that is stored in the system
        Me.C_GEAR2_RETARD.Items.Add(i.ToString())
        i = 0
        Do While i < 25 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.C_GEAR2_RETARD.Items.Add(i.ToString())
            i = i + 1
        Loop
        Me.C_GEAR2_RETARD.Items.Add(i.ToString())
        i = ReadFlashWord(&H5A00C) ' this is the reference  that is stored in the system
        Me.C_GEAR36_RETARD.Items.Add(i.ToString())
        i = 0
        Do While i < 25 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.C_GEAR36_RETARD.Items.Add(i.ToString())
            i = i + 1
        Loop
        Me.C_GEAR36_RETARD.Items.Add(i.ToString())
        i = ReadFlashWord(&H5A00E) / 2.56 ' this is the reference  that is stored in the system
        Me.C_ACTIVATION.Items.Add(i.ToString())
        i = 3000
        Do While i < 8000
            Me.C_ACTIVATION.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.C_ACTIVATION.Items.Add(i.ToString())

        Me.C_GEAR1_RATE.SelectedIndex = 0
        Me.C_GEAR2_RATE.SelectedIndex = 0
        Me.C_GEAR36_RATE.SelectedIndex = 0
        Me.C_GEAR1_RETARD.SelectedIndex = 0
        Me.C_GEAR2_RETARD.SelectedIndex = 0
        Me.C_GEAR36_RETARD.SelectedIndex = 0
        Me.C_ACTIVATION.SelectedIndex = 0

        'populate NTCLT with initial value
        i = ReadFlashWord(&H60B30) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))))
        i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
        Me.NTCLT.Items.Add(i.ToString())
        i = 3000
        Do While i < 13500 ' this is the maximum rpm allowed, abovet this the ecu will set up flags that are not known
            Me.NTCLT.Items.Add(i.ToString())
            i = i + 100
        Loop
        Me.NTCLT.Items.Add(i.ToString())
        Me.NTCLT.SelectedIndex = 0
        Me.NTCLT.Enabled = True


    End Sub
    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        Dim pcdisp, blk As Integer

        If method Then
            '
            ' Lets activate a branch to dragtools code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the dragtools code
            ' as part of each main loop
            '
            ' main_calculations call to nullsub replaced with a call to dragtools module
            pcdisp = (dragtoolsCODE - &H32E70) / 4
            blk = 0
            If pcdisp > &HFFFF Then
                blk = Int(pcdisp / &H10000)
                pcdisp = pcdisp And &HFFFF
            End If
            WriteFlashByte(&H32E70, &HFE)
            WriteFlashByte(&H32E71, blk)
            WriteFlashWord(&H32E72, pcdisp)

            ' set ignition retard to read the dragtools module variable
            WriteFlashByte(&H33C36, &H68)
            WriteFlashByte(&H33C37, &H90)

            '
            ' For debugging lets change kwb packet 08 bytes to monitor rpm_rate
            '
            'WriteFlashByte(&H525C0, 0)
            'WriteFlashByte(&H525C0 + 1, &H80)
            'WriteFlashByte(&H525C0 + 2, &H68)
            'WriteFlashByte(&H525C0 + 3, &H8C)

            'WriteFlashByte(&H525C4, 0)
            'WriteFlashByte(&H525C4 + 1, &H80)
            'WriteFlashByte(&H525C4 + 2, &H68)
            'WriteFlashByte(&H525C4 + 3, &H8D)

            'WriteFlashByte(&H525C8, 0)
            'WriteFlashByte(&H525C8 + 1, &H80)
            'WriteFlashByte(&H525C8 + 2, &H68)
            'WriteFlashByte(&H525C8 + 3, &H84)

            'WriteFlashByte(&H525CC, 0)
            'WriteFlashByte(&H525CC + 1, &H80)
            'WriteFlashByte(&H525CC + 2, &H68)
            'WriteFlashByte(&H525CC + 3, &H85)

        Else
            '
            ' bring the ecu code back to original
            '
            ' AD_conversion loop no jump to separate code
            WriteFlashWord(&H32E70, &HFE00)
            WriteFlashWord(&H32E72, &H7A3F)

            ' set ignition retard to read the stock variable
            WriteFlashByte(&H33C36, &H63)
            WriteFlashByte(&H33C36, &HC7)

        End If
    End Sub
    Private Sub dragtools_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\dragtools.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("dragtools code not found at: " & path, MsgBoxStyle.Critical)
            C_dragtools_activation.Checked = False
        End If


        If method And File.Exists(path) Then
            '
            ' write the dragtools code into memory address from the .bin file
            '
            fs = File.OpenRead(path)

            i = 0
            Do While fs.Read(b, 0, 1) > 0
                WriteFlashByte(i + ADJ, b(0))
                i = i + 1
            Loop
            fs.Close()

            i = ReadFlashWord(IDTAG)

            If ReadFlashWord(IDTAG) <> dragtoolsVERSION Then
                MsgBox("This dragtools code is not compatible with this ECUeditor version !!!")
                For i = 0 To lenght
                    WriteFlashByte(i + ADJ, &HFF)
                Next
                Me.Close()
            End If
            ' generate_general_settings()
            ' generate_dragtools_table()
        Else
            ' reset the dragtools code in memory back to &HFF. Remember that &HFF is the default value after EPROM erase
            For i = 0 To lenght
                WriteFlashByte(i + ADJ, &HFF)
            Next
        End If
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Linklabel_program_homepage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Linklabel_program_homepage.LinkClicked
        System.Diagnostics.Process.Start("http://www.ecueditor.com")
    End Sub

    Private Sub C_dragtools_activation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_dragtools_activation.CheckedChanged
        If C_dragtools_activation.Checked Then
            C_dragtools_activation.Text = "Code active"
            If (ReadFlashByte(ADJ) = &HFF) Then
                modify_original_ECU_code(True)
                dragtools_code_in_memory(True, dragtoolscodelenght)
                generate_dragtools_table()
            End If
            show_settings()
        Else
            C_dragtools_activation.Text = "Code not active"
            modify_original_ECU_code(False)
            dragtools_code_in_memory(False, dragtoolscodelenght)
            hide_settings()
        End If

    End Sub

    Private Sub C_GEAR1_RATE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_GEAR1_RATE.SelectedIndexChanged
        WriteFlashWord(&H5A002, Int(Val(C_GEAR1_RATE.Text) * 2.56))
    End Sub

    Private Sub C_GEAR2_RATE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_GEAR2_RATE.SelectedIndexChanged
        WriteFlashWord(&H5A004, Int(Val(C_GEAR2_RATE.Text) * 2.56))
    End Sub

    Private Sub C_GEAR36_RATE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_GEAR36_RATE.SelectedIndexChanged
        WriteFlashWord(&H5A006, Int(Val(C_GEAR36_RATE.Text) * 2.56))
    End Sub

    Private Sub C_GEAR1_RETARD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_GEAR1_RETARD.SelectedIndexChanged
        WriteFlashWord(&H5A008, Val(C_GEAR1_RETARD.Text))
    End Sub

    Private Sub C_GEAR2_RETARD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_GEAR2_RETARD.SelectedIndexChanged
        WriteFlashWord(&H5A00A, Val(C_GEAR2_RETARD.Text))
    End Sub

    Private Sub C_GEAR36_RETARD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_GEAR36_RETARD.SelectedIndexChanged
        WriteFlashWord(&H5A00C, Val(C_GEAR36_RETARD.Text))
    End Sub


    Private Sub C_ACTIVATION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_ACTIVATION.SelectedIndexChanged
        WriteFlashWord(&H5A00E, Int(Val(C_ACTIVATION.Text) * 2.56))
    End Sub

    Private Sub NTCLT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NTCLT.SelectedIndexChanged
        Dim i As Integer
        Dim baseline As Integer

        '
        ' RPM/Fuel hard type 2, this is modified higher than stock as ecu default is not used in this case
        '
        baseline = 11300
        ' Set various RPM limits based on RPM value selected
        i = Val(NTCLT.Text)
        addedrpm = i - baseline ' we are just setting here the baseline

        WriteFlashWord(&H72A6C, Int((rpmconv / (addedrpm + (rpmconv / &H560))))) 'Cluched ignition limiter
        WriteFlashWord(&H72A6E, Int((rpmconv / (addedrpm + (rpmconv / &H554))))) 'Cluched ignition limiter

        '
        ' Make ignition limiter to skip GPS error and GPS neutral using &H80 value as raw gps information
        '
        WriteFlashByte(&H36E39 + 0, &H7)
        WriteFlashByte(&H36E39 + 1, &H2A)
        WriteFlashByte(&H36E39 + 2, &H93)

    End Sub

    Private Sub hide_settings()
        Dim i As Integer
        Dim baseline As Integer
        baseline = 11304

        G_slewrate.Hide()
        G_2step.Hide()

        '
        ' Remove settings 2 step limiter settings
        '
        i = ReadFlashWord(&H72A6E) ' this is the reference RPM that is stored in the system
        i = Int(((rpmconv / (i + 0))))
        i = CInt(i / 50) * 50 'the conversions are not exact, round it up to the closest 50 to avoid confusion
        addedrpm = i - baseline ' we are just setting here the baseline
        WriteFlashWord(&H72A6C, Int((rpmconv / (addedrpm + (rpmconv / &H51E))))) 'clutch limiter at 10901 modified to same as normal ignition limiter
        WriteFlashWord(&H72A6E, Int((rpmconv / (addedrpm + (rpmconv / &H50D))))) 'clutch limiter at 10997 modified to same as normal ignition limiter
        WriteFlashByte(&H36E39 + 0, &H80)
        WriteFlashByte(&H36E39 + 1, &H50)
        WriteFlashByte(&H36E39 + 2, &HB0)

    End Sub

    Private Sub show_settings()
        G_slewrate.Show()
        G_2step.Show()
    End Sub

End Class
