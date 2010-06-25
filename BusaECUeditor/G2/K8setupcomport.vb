Imports System.Windows.Forms
'Imports System.Management ' required by WMI queries
Imports System.IO.Ports

Public Class K8setupcomport
    Public Declare Function FT_GetModemStatus Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByRef modstat As Integer) As Integer
    Public Declare Function FT_SetRts Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_ClrRts Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_SetBreakOn Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_SetBreakOff Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_Open Lib "FTD2XX.DLL" (ByVal iDevice As Integer, ByRef lnghandle As Integer) As Integer
    Public Declare Function FT_GetNumberOfDevices Lib "FTD2XX.DLL" Alias "FT_ListDevices" (ByRef lngNumberofdevices As Integer, ByVal pvarg2 As String, ByVal lngflags As Integer) As Integer
    Public Declare Function FT_ListDevices Lib "FTD2XX.DLL" (ByRef lngNumberofdevices As Integer, ByVal pvarg2 As String, ByVal lngflags As Integer) As Integer
    Public Declare Function FT_Close Lib "FTD2XX.DLL" (ByVal lnghandle As Integer) As Integer
    Public Declare Function FT_GetComPortNumber Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByRef portnumber As Integer) As Integer
    Public Declare Function FT_SetBaudRate Lib "FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngBaudRate As Integer) As Integer
    Public Declare Function FT_Write_Bytes Lib "FTD2XX.DLL" Alias "FT_Write" (ByVal lngHandle As Integer, ByRef lpvBuffer As Byte, ByVal lngBufferSize As Integer, ByRef lngBytesWritten As Integer) As Integer
    Public Declare Function FT_Read_Bytes Lib "FTD2XX.DLL" Alias "FT_Read" (ByVal lngHandle As Integer, ByRef lpvBuffer As Byte, ByVal lngBufferSize As Integer, ByRef lngBytesReturned As Integer) As Integer
    Public Declare Function FT_GetStatus Lib "FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lngamountInRxQueue As Integer, ByRef lngAmountInTxQueue As Integer, ByRef lngEventStatus As Integer) As Integer
    Public Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
    Public Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
    Public Declare Function FT_SetDataCharacteristics Lib "FTD2XX.DLL" (ByVal lnghandle As Integer, ByVal uWordLength As Byte, ByVal uStopBits As Byte, ByVal uParity As Byte) As Integer
    Public Declare Function FT_SetTimeouts Lib "FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal rxTimeout As Integer, ByVal txTimeout As Integer) As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub K8setupcomport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim j As Integer
        Dim s As String
        Dim pvs As String
        'Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName WHERE InstanceName LIKE 'FTDI%'")
        Dim OKtoactivate As Boolean
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String

 
        RPM = 0

        j = 0
        i = 1
        pvs = ""
        s = My.Settings.Item("ComPort")
        Try

            j = -1
            i = 0
            ComboBox_Serialport.Items.Clear()

            For Each port In ports
                ComboBox_Serialport.Items.Add(port)
                If port = s Then
                    j = i
                End If
                i = i + 1
            Next port

        Catch ex As Exception
            MessageBox.Show("An error occurred while searching valid COM ports " & ex.Message)
            OKtoactivate = False
        End Try
        If j >= 0 Then
            ComboBox_Serialport.SelectedIndex = j
            'If j = 1 Then OKtoactivate = True ' only one FTDI comport found, ok to activate
            OKtoactivate = True ' only one FTDI comport found, ok to activate
        Else
            OKtoactivate = False
            MsgBox("Interface needs to be set. Select the correct com port on the following engine data monitoring screen. ", MsgBoxStyle.Information)
        End If


    End Sub

    
    Private Sub ComboBox_Serialport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Serialport.SelectedIndexChanged
        Dim comportnum As Integer

        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
                SerialPort1.PortName = ComboBox_Serialport.Text
                SerialPort1.Open()
            Else
                SerialPort1.PortName = ComboBox_Serialport.Text
                SerialPort1.Open()
                SerialPort1.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
        My.Settings.Item("ComPort") = ComboBox_Serialport.Text
        comportnum = Val(Mid$(SerialPort1.PortName, 4))   ' com port address for FTDI driver
        If ((comportnum < 0) Or (comportnum > 8)) Then MsgBox("USB FTDI COMport is non existing or out of range, program may not work")

    End Sub

End Class
