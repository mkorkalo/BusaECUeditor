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

Public Class AcceptTerms

#Region "Form Events"

    Private Sub AcceptTerms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TopMost = True

    End Sub

#End Region

#Region "Control Events"

    Private Sub B_Yes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Yes.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        main.Visible = True
        Me.Close()

    End Sub

    Private Sub B_No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_No.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        My.Settings.Item("Userlic") = Str(0)
        End

    End Sub

#End Region

End Class
