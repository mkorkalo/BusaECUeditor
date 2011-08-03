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

Public Class UserBikeInfo

#Region "Form Events"

    Private Sub UserBikeInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        C_Engine.Text = inforead(&H27000)
        C_Model.Text = inforead(&H27010)
        C_RWHP.Text = inforead(&H27020)
        C_Type.Text = inforead(&H27030)
        C_Exhaust.Text = inforead(&H27040)
        C_Head.Text = inforead(&H27050)
        C_Cams.Text = inforead(&H27060)
        C_Compression.Text = inforead(&H27070)
        C_Injectors.Text = inforead(&H27080)
        C_FuelPressure.Text = inforead(&H27090)
        T_Email.Text = inforead(&H270A0)
        T_Webpage.Text = inforead(&H271A0)
        T_Comments.Text = inforead(&H272A0)

        ' if the computername from this map does not match with the computer name on the map
        ' then empty the email intormation
        If (inforead(&H273A0) <> My.Computer.Name()) Then
            T_Email.Text = ""
        Else
            If T_Email.Text = "" Then
                T_Email.Text = My.Settings.Item("emailaddr")
            End If
        End If

    End Sub

#End Region

#Region "Control Events"

    Private Sub B_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Close.Click
        SaveWhenClosing()

    End Sub

#End Region

#Region "Functions"

    Private Sub SaveWhenClosing()

        InfoWrite(&H27000, C_Engine.Text)
        InfoWrite(&H27010, C_Model.Text)
        InfoWrite(&H27020, C_RWHP.Text)
        InfoWrite(&H27030, C_Type.Text)
        InfoWrite(&H27040, C_Exhaust.Text)
        InfoWrite(&H27050, C_Head.Text)
        InfoWrite(&H27060, C_Cams.Text)
        InfoWrite(&H27070, C_Compression.Text)
        InfoWrite(&H27080, C_Injectors.Text)
        InfoWrite(&H27090, C_FuelPressure.Text)
        InfoWrite(&H270A0, T_Email.Text)
        InfoWrite(&H271A0, T_Webpage.Text)
        InfoWrite(&H272A0, T_Comments.Text)
        InfoWrite(&H273A0, My.Computer.Name())

        If ValidEmail(T_Email.Text) Then
            Me.Close()
        Else
            MsgBox("Enter a valid email for your map file")
        End If
    End Sub

    Private Function ValidEmail(ByVal e As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(e, pattern)

        If emailAddressMatch.Success Then
            My.Settings.Item("emailaddr") = e
            Return (True)
        Else
            Return (False)
        End If

    End Function

    Private Sub InfoWrite(ByVal addr As Integer, ByVal str As String)
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
            WriteFlashByte(addr + x, a)
        Next

        For x = i To m
            WriteFlashByte(addr + x, &HFF)
        Next
    End Sub

    Public Function InfoRead(ByVal addr As Integer) As String
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
            If (ReadFlashByte(addr + i) < &HFF) And (ReadFlashByte(addr + i) > 0) Then
                s = s & Chr(ReadFlashByte(addr + i))
            End If
        Next

        Return (s)

    End Function

#End Region

End Class