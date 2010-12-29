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

Public Class K8dragtools
    Dim ADJ As Integer = &H5A000 '&HFF if dragtools inactive, no code present else dragtools active
    Dim dragtoolsCODE As Integer = &H5A100
    Dim IDTAG As Integer = &H5A000
    Dim dragtoolsVERSION As Integer = 100
    Dim dragtoolscodelenght As Integer = &H1000 'lenght of the dragtools code in bytes for clearing the memory


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
        PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 10
        PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 10
        PrintForm1.Print()
    End Sub

    Private Sub dragtools_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        L_dragtoolsver.Text = Str(dragtoolsVERSION)

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
            'generate_general_settings()
            'generate_dragtools_table()
        End If
    End Sub
    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        Dim pcdisp, blk As Integer

        If method Then
            '
            ' Lets activate a branch to dragtools code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the dragtools code
            ' as part of each main loop
            '
            ' AD_conversion loop no jump to separate code
            pcdisp = (dragtoolsCODE - &H41D8) / 4
            blk = 0
            If pcdisp > &HFFFF Then
                blk = Int(pcdisp / &H10000)
                pcdisp = pcdisp And &HFFFF
            End If
            WriteFlashByte(&H41D8, &HFE)
            WriteFlashByte(&H41D9, blk)
            WriteFlashWord(&H41DA, pcdisp)
            'cylinder 1 
            WriteFlashWord(&H41408, &H6400) ' ldi R4, 0
            WriteFlashWord(&H413E2, &H6818)
            WriteFlashWord(&H41460, &H4400) ' + 0
            WriteFlashWord(&H41462, &H5446) ' << 5
            'cylinder 2 
            WriteFlashWord(&H414D8, &H6400)
            WriteFlashWord(&H414B2, &H6818)
            WriteFlashWord(&H41530, &H4400) ' + 0
            WriteFlashWord(&H41532, &H5446) ' << 5
            'cylinder 3 
            WriteFlashWord(&H415A8, &H6400)
            WriteFlashWord(&H41582, &H6818)
            WriteFlashWord(&H41600, &H4400) ' + 0
            WriteFlashWord(&H41602, &H5446) ' << 5
            'cylinder 4 
            WriteFlashWord(&H41678, &H6400)
            WriteFlashWord(&H41652, &H6818)
            WriteFlashWord(&H416D0, &H4400) ' + 0
            WriteFlashWord(&H416D2, &H5446) ' << 5

            ' set ignition retard to read the dragtools module variable
            WriteFlashByte(&H33C22, &H68)
            WriteFlashByte(&H33C23, &H56)


        Else
            '
            ' bring the ecu code back to original
            '
            ' AD_conversion loop no jump to separate code
            WriteFlashWord(&H41D8, &HFE00)
            WriteFlashWord(&H41DA, &HBAC9)
            'cylinder 1 
            WriteFlashWord(&H41408, &H4400)
            WriteFlashWord(&H413E2, &H652A)
            WriteFlashWord(&H41460, &H4480)
            WriteFlashWord(&H41462, &H5442)
            'cylinder 2 
            WriteFlashWord(&H414D8, &H4400)
            WriteFlashWord(&H414B2, &H652B)
            WriteFlashWord(&H41530, &H4480)
            WriteFlashWord(&H41532, &H5442)
            'cylinder 3 
            WriteFlashWord(&H415A8, &H4400)
            WriteFlashWord(&H41582, &H652C)
            WriteFlashWord(&H41600, &H4480)
            WriteFlashWord(&H41602, &H5442)
            'cylinder 4 
            WriteFlashWord(&H41678, &H4400)
            WriteFlashWord(&H41652, &H652D)
            WriteFlashWord(&H416D0, &H4480)
            WriteFlashWord(&H416D2, &H5442)

            ' set ignition retard to read the stock variable
            WriteFlashByte(&H33C22, &H63)
            WriteFlashByte(&H33C23, &HA2)

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



    Private Sub B_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintForm1.Print()
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
                ' generate_map_table()
            End If
            'read_dragtools_settings()
        Else
            C_dragtools_activation.Text = "Code not active"
            modify_original_ECU_code(False)
            dragtools_code_in_memory(False, dragtoolscodelenght)
            'hide_boostfuel_settings()
        End If

    End Sub
End Class
