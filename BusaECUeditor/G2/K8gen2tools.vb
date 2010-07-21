Imports System.Windows.Forms
Imports System.IO

Public Class K8gen2tools
    Dim ADJ As Integer = &H59DC0 '&HFF if shifter inactive, no code present else shifter active
    Dim TOOLSCODE As Integer = &H59E00
    Dim IDTAG As Integer = &H59DC0
    Dim TOOLSVERSION As Integer = 100
    Dim toolscodelenght As Integer = &H59FFF - &H59E00 - 1 'lenght of the shifter code in bytes for clearing the memory
    Dim initiating As Boolean = True

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub K8misctools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (ReadFlashByte(ADJ) = &HFF) Then
            C_tools_activation.Checked = False
        Else
            C_tools_activation.Checked = True
            'shifter_code_in_memory(True, shiftercodelenght)
            If (ReadFlashWord(IDTAG) <> TOOLSVERSION) Then
                MsgBox("Tools code incompatible with this version, please reactivate the code" & ReadFlashWord(IDTAG).ToString)
                C_tools_activation.Checked = False
            End If
        End If

    End Sub

    Private Sub C_tools_activation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_tools_activation.CheckedChanged
        If C_tools_activation.Checked Then
            C_tools_activation.Text = "Tools active"
            If (ReadFlashByte(ADJ) = &HFF) Then
                modify_original_ECU_code(True)
                tools_code_in_memory(True, toolscodelenght)
            End If
        Else
            C_tools_activation.Text = "Tools not active"
            modify_original_ECU_code(False)
            tools_code_in_memory(False, toolscodelenght)
        End If

    End Sub

    Private Sub modify_original_ECU_code(ByVal method As Boolean)
        Dim pcdisp As Integer
        Dim highbyte As Integer

        If method Then
            '
            ' Lets activate a branch to shifter code address and immediate return from there
            ' this modifies the programmingcode so that the ecu does a loop to the shifter code
            ' as part of each main loop
            '
            pcdisp = (TOOLSCODE - &H22A4) / 4
            highbyte = Int(pcdisp / &H10000)
            WriteFlashByte(&H22A4, &HFE) ' bl.l 
            WriteFlashByte(&H22A5, highbyte)
            WriteFlashWord(&H22A6, pcdisp - (highbyte * &H10000)) '         pcdisp
        Else
            '
            ' bring the ecu code back to original
            '
            WriteFlashWord(&H22A4, &HFE00)
            WriteFlashWord(&H22A6, &H44D6)

        End If
    End Sub
    Private Sub tools_code_in_memory(ByVal method As Boolean, ByVal lenght As Integer)
        Dim i As Integer
        Dim fs As FileStream
        Dim path As String = My.Application.Info.DirectoryPath & "\ecu.bin\gen2tools.bin"
        Dim b(1) As Byte

        If Not File.Exists(path) Then
            MsgBox("Tools code not found at: " & path, MsgBoxStyle.Critical)
            C_tools_activation.Checked = False
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

            If ReadFlashWord(IDTAG) <> TOOLSVERSION Then
                MsgBox("This tools code is not compatible with this ECUeditor version !!! " & ReadFlashWord(IDTAG).ToString)
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

End Class
