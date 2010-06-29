Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace ldGuage
Public Delegate Sub DeflectionChangedEventHandler(ByVal sender As Object, ByVal e As EventArgs)

	''' <summary>
	''' Summary description for UserControl1.
	''' </summary>
	<DefaultEventAttribute("DeflectionChanged")> _
	Public Class ldGuage : Inherits System.Windows.Forms.Control

		''' <summary>
		''' Required designer variable.
		''' </summary>

        Private components As System.ComponentModel.Container = Nothing

        Public Event DeflectionChanged As DeflectionChangedEventHandler

        Public Event InTheRed As DeflectionChangedEventHandler

		Public Event OutOfTheRed As DeflectionChangedEventHandler

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
			Me.BackColor = Color.Black
			Me.SetStyle(ControlStyles.ResizeRedraw, True)
			Me.SetStyle(ControlStyles.DoubleBuffer, True)
			Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
			Me.SetStyle(ControlStyles.UserPaint, True)
			Me.Font = New System.Drawing.Font("Bitstream Vera Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.deflection_Renamed = 0
			Me.redZone_Renamed = 60
			Me.range_Renamed = 100
			Me.Height = 100
			Me.Width = 100
			Me.ncolor = Color.Orange
			Me.rcolor = Color.Red
			Me.ForeColor = Color.Lime


		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
        End Sub

        <CategoryAttribute("Behavior"), DescriptionAttribute("Deflection of the needle.")> _
        Public Property Deflection() As Single
            Get
                Return deflection_Renamed
            End Get
            Set(ByVal Value As Single)
                deflection_Renamed = Value
                Me.Refresh()
                If Not Me.DeflectionChangedEvent Is Nothing Then
                    RaiseEvent DeflectionChanged(Me, New EventArgs)
                End If
                If deflection_Renamed >= redZone_Renamed Then
                    If (Not inTheRed1) Then
                        inTheRed1 = True
                        If Not InTheRedEvent Is Nothing Then
                            RaiseEvent InTheRed(Me, New EventArgs)
                        End If
                    End If
                Else
                    If inTheRed1 Then
                        inTheRed1 = False
                        If Not OutOfTheRedEvent Is Nothing Then
                            RaiseEvent OutOfTheRed(Me, New EventArgs)
                        End If
                    End If
                End If
            End Set
        End Property

        <CategoryAttribute("Behavior"), DescriptionAttribute("Range of the red zone.")> _
        Public Property RedZone() As Single
            Get
                Return redZone_Renamed
            End Get
            Set(ByVal Value As Single)
                redZone_Renamed = Value
                Me.Refresh()
            End Set
        End Property

        <CategoryAttribute("Behavior"), DescriptionAttribute("Range of the meter.")> _
        Public Property Range() As Single
            Get
                Return range_Renamed
            End Get
            Set(ByVal Value As Single)
                range_Renamed = Value
                Me.Refresh()
            End Set
        End Property

        <CategoryAttribute("Appearance"), DescriptionAttribute("Color of the needle")> _
        Public Property Needle_Color() As Color
            Get
                Return ncolor
            End Get
            Set(ByVal Value As Color)
                ncolor = Value
                Me.Refresh()
            End Set
        End Property

        <CategoryAttribute("Appearance"), DescriptionAttribute("Color of the ticks in the red zone")> _
        Public Property RedZone_Color() As Color
            Get
                Return rcolor
            End Get
            Set(ByVal Value As Color)
                rcolor = Value
                Me.Refresh()
            End Set
        End Property

#Region "Component Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
        End Sub
#End Region

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim shorter As Integer
            Dim divisor As Single = range_Renamed / 260
            Dim g As Graphics = e.Graphics
            Dim needlePen As Pen = New Pen(ncolor, 2)
            Dim rzPen As Pen = New Pen(rcolor)
            Dim txtPen As Pen = New Pen(Me.ForeColor)
            Dim txtBrush As SolidBrush = New SolidBrush(Me.ForeColor)
            Dim txtRedBrush As SolidBrush = New SolidBrush(Me.rcolor)
            If Me.ClientRectangle.Width < Me.ClientRectangle.Height Then
                shorter = Me.ClientRectangle.Width
            Else
                shorter = Me.ClientRectangle.Height
            End If
            Dim center As Integer = shorter / 2
            'rectangle for center arc
            Dim rec As Rectangle = New Rectangle(center * 8 / 10, center * 8 / 10, center * 4 / 10, center * 4 / 10)
            'Shape of meter
            Dim gP As GraphicsPath = New GraphicsPath
            gP.AddEllipse(0, 0, shorter, shorter)

            Me.Region = New Region(gP)
            'Draw tick marks
            g.DrawArc(txtPen, rec, 140, 260)
            For i As Integer = 0 To 260 Step 26
                Dim matrix As Matrix = New Matrix
                Dim temp As Single
                temp = shorter * 9 / 10
                matrix.RotateAt(i + 50, New PointF(center, center))
                g.Transform = matrix
                If i > redZone_Renamed / divisor Then
                    g.DrawLine(rzPen, center, temp, center, shorter)
                Else
                    g.DrawLine(txtPen, center, temp, center, shorter)
                End If
            Next i
            ' Draw Numbers
            For i As Integer = 0 To 260 Step 26
                Dim matrix As Matrix = New Matrix
                matrix.RotateAt(i - 132, New PointF(center, center))
                g.Transform = matrix
                If (CInt(i * divisor)) < redZone_Renamed Then
                    g.DrawString((CInt(i * divisor)).ToString(), Me.Font, txtBrush, center - 5, center * 3 / 10, StringFormat.GenericTypographic)
                Else
                    g.DrawString((CInt(i * divisor)).ToString(), Me.Font, txtRedBrush, center - 5, center * 3 / 10, StringFormat.GenericTypographic)
                End If
            Next i
            'Draw Needle
            Dim m As Matrix = New Matrix
            Dim temp1 As Single
            temp1 = center * 12 / 10
            Dim temp2 As Single
            temp2 = shorter * 8 / 10
            m.RotateAt(Me.deflection_Renamed / divisor + 50, New PointF(center, center))
            g.Transform = m
            g.DrawLine(needlePen, center, temp1, center, temp2)
            'base.OnPaint (e);
        End Sub

        Private deflection_Renamed As Single

        Private range_Renamed As Single

        Private redZone_Renamed As Single

        Private ncolor, rcolor As Color

        Private inTheRed1 As Boolean

    End Class

End Namespace


