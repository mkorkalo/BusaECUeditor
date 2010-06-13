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

Imports System.Text.RegularExpressions

Public Class userbikeinfo

    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click
        save_when_closing()
    End Sub
    Private Sub save_when_closing()
        infowrite(&H27000, C_engine.Text)
        infowrite(&H27010, C_model.Text)
        infowrite(&H27020, C_RWHP.Text)
        infowrite(&H27030, C_type.Text)
        infowrite(&H27040, C_exhaust.Text)
        infowrite(&H27050, C_head.Text)
        infowrite(&H27060, C_cams.Text)
        infowrite(&H27070, C_compression.Text)
        infowrite(&H27080, C_injectors.Text)
        infowrite(&H27090, C_fuelpressure.Text)
        infowrite(&H270A0, T_email.Text)
        infowrite(&H271A0, T_webpage.Text)
        infowrite(&H272A0, T_comments.Text)
        infowrite(&H273A0, My.Computer.Name())

        If validemail(T_email.Text) Then
            Me.Close()
        Else
            MsgBox("Enter a valid email for your map file")
        End If
    End Sub

    Private Function validemail(ByVal e As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(e, pattern)

        If emailAddressMatch.Success Then
            My.Settings.Item("emailaddr") = e
            Return (True)
        Else
            Return (False)
        End If

    End Function


    Private Sub infowrite(ByVal addr As Integer, ByVal str As String)
        Dim i As Integer
        Dim x As Integer
        Dim s As String
        Dim a As Integer
        Dim m As Integer

        i = Len(str)
        If addr <= &H27090 Then
            m = &HF
            If i > &HF Then i = &HF ' max str length 
        End If
        If addr = &H270A0 Then
            m = &HFF
            If i > &HFF Then i = &HFF ' max str length 

        End If
        If addr = &H271A0 Then
            m = &HFF
            If i > &HFF Then i = &HFF ' max str length 
        End If
        If addr = &H272A0 Then
            m = &HFF
            If i > &HFFF Then i = &HFFF ' max str length 
        End If
        If addr = &H273A0 Then
            m = &HF
            If i > &HF Then i = &HF ' max str length 
        End If


        For x = 0 To i
            If x < Len(str) Then
                s = Mid(str, x + 1, 1)
                a = Asc(s)
            Else
                a = 0
            End If
            writeflashbyte(addr + x, a)
        Next

        For x = i To m
            writeflashbyte(addr + x, &HFF)
        Next
    End Sub

    Private Sub userbikeinfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        C_engine.Text = inforead(&H27000)
        C_model.Text = inforead(&H27010)
        C_RWHP.Text = inforead(&H27020)
        C_type.Text = inforead(&H27030)
        C_exhaust.Text = inforead(&H27040)
        C_head.Text = inforead(&H27050)
        C_cams.Text = inforead(&H27060)
        C_compression.Text = inforead(&H27070)
        C_injectors.Text = inforead(&H27080)
        C_fuelpressure.Text = inforead(&H27090)
        T_email.Text = inforead(&H270A0)
        T_webpage.Text = inforead(&H271A0)
        T_comments.Text = inforead(&H272A0)

        ' if the computername from this map does not match with the computer name on the map
        ' then empty the email intormation
        If (inforead(&H273A0) <> My.Computer.Name()) Then
            T_email.Text = ""
        Else
            If T_email.Text = "" Then
                T_email.Text = My.Settings.Item("emailaddr")
            End If
        End If

    End Sub

    Public Function inforead(ByVal addr As Integer) As String
        Dim i As Integer
        Dim s As String
        Dim m As Integer

        If addr <= &H27090 Then
            m = &HF
        End If
        If addr = &H270A0 Then
            m = &HFF
        End If
        If addr = &H271A0 Then
            m = &HFF
        End If
        If addr = &H272A0 Then
            m = &HFF
        End If
        If addr = &H273A0 Then
            m = &HF
        End If

        s = ""
        For i = 0 To m
            If (readflashbyte(addr + i) < &HFF) And (readflashbyte(addr + i) > 0) Then
                s = s & Chr(readflashbyte(addr + i))
            End If
        Next

        Return (s)

    End Function

End Class