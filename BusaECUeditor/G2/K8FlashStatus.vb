Imports System.Windows.Forms

Public Class K8FlashStatus

    Dim _closedStatus As Boolean

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Property ClosedStatus() As Boolean
        Get
            Return _closedStatus
        End Get
        Set(value As Boolean)
            _closedStatus = value
        End Set
    End Property

    Public Property CloseEnabled() As Boolean
        Get
            Return btnClose.Enabled
        End Get
        Set(value As Boolean)
            btnClose.Enabled = value
            lblClose.Visible = value
        End Set
    End Property

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        _closedStatus = True
    End Sub

    Private Sub K8FlashStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CloseEnabled = False
    End Sub
End Class
