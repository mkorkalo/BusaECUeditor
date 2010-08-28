Imports System.IO
Imports System.Drawing
Imports System.Text

Public Class K8EngineDataViewer

    Private _filePath As String
    Private _tpsList As List(Of Double) = New List(Of Double)
    Private _iapList As List(Of Double) = New List(Of Double)
    Private _rpmList As List(Of Integer) = New List(Of Integer)
    Private _boostList As List(Of Integer) = New List(Of Integer)
    Private _boostRPMList As List(Of Integer) = New List(Of Integer)

    Private _tpsValues(,) As List(Of LogValue)
    Private _iapValues(,) As List(Of LogValue)
    Private _boostValues(,) As List(Of LogValue)

    Private _tpsTargetAFR(,) As Double
    Private _iapTargetAFR(,) As Double
    Private _boostTargetAFR(,) As Double

    Private _tpsPercentageMapDelta(,) As Double
    Private _iapPercentageMapDelta(,) As Double
    Private _boostPercentageMapDelta(,) As Double

    Private _loading As Boolean = True
    Private _mapLoading As Boolean = False
    Private _cltAbove80 As Boolean = False
    Private _mapType As Integer = 1
    Private _fileType As Integer = 0

    Private _autoTunedTPS = False
    Private _autoTunedIAP = False
    Private _autoTunedBoost = False


    Private Sub K8EngineDataViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        C_WidebandO2Sensor.Checked = My.Settings.WidebandO2Sensor

        _tpsList.Add(0)
        _tpsList.Add(0.6)
        _tpsList.Add(1.2)
        _tpsList.Add(1.9)
        _tpsList.Add(2.5)
        _tpsList.Add(3.1)
        _tpsList.Add(3.7)
        _tpsList.Add(4.4)
        _tpsList.Add(6)
        _tpsList.Add(7)
        _tpsList.Add(8)
        _tpsList.Add(9)
        _tpsList.Add(11)
        _tpsList.Add(16)
        _tpsList.Add(21)
        _tpsList.Add(25)
        _tpsList.Add(30)
        _tpsList.Add(40)
        _tpsList.Add(50)
        _tpsList.Add(60)
        _tpsList.Add(70)
        _tpsList.Add(90)
        _tpsList.Add(100)

        _iapList.Add(68)
        _iapList.Add(59)
        _iapList.Add(50)
        _iapList.Add(41)
        _iapList.Add(39)
        _iapList.Add(36)
        _iapList.Add(34)
        _iapList.Add(32)
        _iapList.Add(30)
        _iapList.Add(27)
        _iapList.Add(25)
        _iapList.Add(23)
        _iapList.Add(20)
        _iapList.Add(18)
        _iapList.Add(14)
        _iapList.Add(11)
        _iapList.Add(9.1)
        _iapList.Add(6.8)
        _iapList.Add(4.6)
        _iapList.Add(2.3)
        _iapList.Add(0)


        For rpm As Integer = 800 To 5200 Step 200
            _rpmList.Add(rpm)
        Next

        For rpm As Integer = 5600 To 16000 Step 400
            _rpmList.Add(rpm)
        Next

        _boostList.Add(0)
        _boostList.Add(1)
        _boostList.Add(2)
        _boostList.Add(3)
        _boostList.Add(4)
        _boostList.Add(6)
        _boostList.Add(8)
        _boostList.Add(10)
        _boostList.Add(11)
        _boostList.Add(12)
        _boostList.Add(14)
        _boostList.Add(15)
        _boostList.Add(17)
        _boostList.Add(19)
        _boostList.Add(22)
        _boostList.Add(24)

        _boostRPMList.Add(4000)
        _boostRPMList.Add(5000)
        _boostRPMList.Add(5500)
        _boostRPMList.Add(6000)
        _boostRPMList.Add(6500)
        _boostRPMList.Add(7000)
        _boostRPMList.Add(7500)
        _boostRPMList.Add(8000)
        _boostRPMList.Add(8500)
        _boostRPMList.Add(9000)
        _boostRPMList.Add(9500)
        _boostRPMList.Add(10000)
        _boostRPMList.Add(10500)
        _boostRPMList.Add(11000)
        _boostRPMList.Add(11500)
        _boostRPMList.Add(12000)

        ReDim _tpsValues(_tpsList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _tpsList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _tpsValues(xindex, yindex) = New List(Of LogValue)

            Next
        Next

        ReDim _iapValues(_iapList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _iapList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _iapValues(xindex, yindex) = New List(Of LogValue)

            Next
        Next

        ReDim _boostValues(_boostList.Count, _boostRPMList.Count)

        For xindex As Integer = 0 To _boostList.Count - 1 Step 1
            For yindex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                _boostValues(xindex, yindex) = New List(Of LogValue)

            Next
        Next


        ReDim _tpsTargetAFR(_tpsList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _tpsList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _tpsTargetAFR(xindex, yindex) = 12.8

            Next
        Next

        ReDim _iapTargetAFR(_iapList.Count, _rpmList.Count)

        For xindex As Integer = 0 To _iapList.Count - 1 Step 1
            For yindex As Integer = 0 To _rpmList.Count - 1 Step 1

                _iapTargetAFR(xindex, yindex) = 14.7

            Next
        Next

        ReDim _boostTargetAFR(_boostList.Count, _boostRPMList.Count)

        For xindex As Integer = 0 To _boostList.Count - 1 Step 1
            For yindex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                _boostTargetAFR(xindex, yindex) = 12

            Next
        Next

    End Sub

    Private ReadOnly Property SelectedMapString() As String
        Get

            If R_TPSRPM.Checked Then
                Return "TPS/RPM"
            ElseIf R_IAPRPM.Checked Then
                Return "IAP/RPM"
            ElseIf R_BOOSTRPM.Checked Then
                Return "Boost/RPM"
            End If

            Return ""

        End Get
    End Property
    Private Sub B_LoadDataFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_LoadDataFile.Click

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "*Raw.csv|*Raw.csv"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            _fileType = 1
            _filePath = OpenFileDialog1.FileName
            OpenFile(_filePath)

        End If

    End Sub

    Public Sub ClearData()

        _cltAbove80 = False

        For x As Integer = 0 To _tpsValues.GetLength(0) - 1
            For y As Integer = 0 To _tpsValues.GetLength(1) - 1
                If _tpsValues(x, y) Is Nothing = False Then

                    _tpsValues(x, y).Clear()
                End If
            Next
        Next

        For x As Integer = 0 To _iapValues.GetLength(0) - 1
            For y As Integer = 0 To _iapValues.GetLength(1) - 1
                If _iapValues(x, y) Is Nothing = False Then
                    _iapValues(x, y).Clear()
                End If
            Next
        Next

        For x As Integer = 0 To _boostValues.GetLength(0) - 1
            For y As Integer = 0 To _boostValues.GetLength(1) - 1
                If _boostValues(x, y) Is Nothing = False Then
                    _boostValues(x, y).Clear()
                End If
            Next
        Next

    End Sub

    Public Sub OpenFile(ByVal filePath As String)

        _filePath = filePath
        OpenFile()

    End Sub

    Public Sub OpenFile()

        If String.IsNullOrEmpty(_filePath) = False Then

            L_FileName.Text = _filePath

            Dim reader As TextReader = New StreamReader(_filePath)

            Dim lineCount As Integer
            Dim nextLine As String = reader.ReadLine()

            While String.IsNullOrEmpty(nextLine) = False

                Dim values As String()
                values = nextLine.Split(",")
                nextLine = reader.ReadLine()
                lineCount = lineCount + 1

                If lineCount > 1 Then

                    Dim logValue As New LogValue

                    logValue.LogTime = values(0)
                    logValue.RPM = values(1)
                    logValue.TPS = K8EngineDataLogger.CalcTPS(values(2))
                    logValue.IAP = K8EngineDataLogger.CalcPressure(values(13)) - K8EngineDataLogger.CalcPressure(values(12))
                    logValue.H02 = values(4)
                    logValue.WIDEBAND = values(5)

                    If C_WidebandO2Sensor.Checked Then
                        logValue.AFR = K8EngineDataLogger.CalcWidebandAFR(values(5))
                    Else
                        logValue.AFR = K8EngineDataLogger.CalcAFR(values(4))
                    End If

                    logValue.IGN = K8EngineDataLogger.CalcIgnDeg(values(6))
                    logValue.STP = K8EngineDataLogger.CalcSTP(values(7))
                    logValue.GEAR = values(8)
                    logValue.CLUTCH = values(9)
                    logValue.NT = Boolean.Parse(values(10))
                    logValue.BOOST = K8EngineDataLogger.CalcBoost(values(11))
                    logValue.IP = K8EngineDataLogger.CalcPressure(values(12))
                    logValue.AP = K8EngineDataLogger.CalcPressure(values(13))
                    logValue.CLT = K8EngineDataLogger.CalcTemp(values(14))
                    logValue.IAT = K8EngineDataLogger.CalcTemp(values(15))
                    logValue.BATT = K8EngineDataLogger.CalcBatt(values(16))
                    logValue.PAIR = K8EngineDataLogger.CalcPair(values(17))
                    logValue.FUEL1 = values(18)
                    logValue.FUEL2 = values(19)
                    logValue.FUEL3 = values(20)
                    logValue.FUEL4 = values(21)

                    If values(23) > 10 And values(23) < 20 Then
                        logValue.MTS_AFR = values(23)
                    End If

                    If CheckEngineDataFilter(logValue) = True Then

                        Dim tpsIndex As Integer
                        Dim iapIndex As Integer
                        Dim rpmIndex As Integer
                        Dim boostIndex As Integer = -1
                        Dim boostRPMIndex As Integer = -1

                        If logValue.RPM > _rpmList(_rpmList.Count - 1) Then

                            rpmIndex = -1

                        Else

                            For index As Integer = 0 To _rpmList.Count - 1 Step 1

                                If logValue.RPM <= _rpmList(index) + (_rpmList(index + 1) - _rpmList(index)) / 2 Then
                                    rpmIndex = index
                                    Exit For
                                End If

                            Next

                        End If

                        If logValue.TPS >= 99 Then
                            tpsIndex = _tpsList.Count - 1
                        ElseIf logValue.TPS >= 80 Then
                            tpsIndex = _tpsList.Count - 2
                        Else
                            For index As Integer = 0 To _tpsList.Count - 1 Step 1

                                If logValue.TPS <= _tpsList(index) + (_tpsList(index + 1) - _tpsList(index)) / 2 Then
                                    tpsIndex = index
                                    Exit For
                                End If

                            Next
                        End If

                        If logValue.IAP > _iapList(0) Then

                            iapIndex = -1

                        ElseIf logValue.IAP > 62.5 Then

                            iapIndex = 0

                        Else
                            For index As Integer = _iapList.Count - 1 To 0 Step -1

                                If logValue.IAP <= _iapList(index) + (_iapList(index - 1) - _iapList(index)) / 2 Then
                                    iapIndex = index
                                    Exit For
                                End If

                            Next

                        End If

                        For index As Integer = 0 To _boostList.Count - 1

                            If logValue.BOOST <= _boostList(index) + 0.5 Then

                                boostIndex = index
                                Exit For

                            End If

                        Next

                        If boostIndex = -1 Then
                            boostIndex = _boostList.Count - 1
                        End If

                        For index As Integer = 1 To _boostRPMList.Count - 1

                            If logValue.RPM <= _boostRPMList(index) Then

                                boostRPMIndex = index
                                Exit For

                            End If

                        Next

                        If logValue.TPS < 11 And iapIndex > -1 And rpmIndex > -1 Then

                            _iapValues(iapIndex, rpmIndex).Add(logValue)

                        End If

                        If rpmIndex > -1 Then

                            _tpsValues(tpsIndex, rpmIndex).Add(logValue)

                        End If

                        If boostRPMIndex > -1 Then

                            _boostValues(boostIndex, boostRPMIndex).Add(logValue)

                        End If

                    End If

                End If

            End While

            reader.Close()

            ShowMap()

        End If

    End Sub

    Public Function CheckEngineDataFilter(ByRef logValue As LogValue)

        If My.Settings.FilterCLT80 = True Then
            If logValue.CLT > 80 Then
                _cltAbove80 = True
            ElseIf _cltAbove80 = False Then
                Return False
            End If
        End If

        If My.Settings.FilterClutchIn = True Then
            If logValue.CLUTCH = "In" Then
                Return False
            End If
        End If

        If My.Settings.FilterGearNeutral = True Then
            If logValue.NT = True Then
                Return False
            End If
        End If

        If logValue.AFR < My.Settings.FilterAFRLessThan Then
            Return False
        End If

        If logValue.AFR > My.Settings.FilterAFRGreaterThan Then
            Return False
        End If

        Return True

    End Function

    Public Function CheckAutoTuneFilter(ByVal avgAfr As Double, ByRef percentageChange As Double, ByVal dataPoints As Integer) As Boolean

        If avgAfr > My.Settings.AutoTuneMaxAvgAFR Then
            Return False
        ElseIf avgAfr < My.Settings.AutoTuneMinAvgAFR Then
            Return False
        ElseIf dataPoints < My.Settings.AutoTuneMinNumberLoggedValuesInCell Then
            Return False
        ElseIf percentageChange > My.Settings.AutoTuneMaxPercentageFuelMapChange Then
            percentageChange = My.Settings.AutoTuneMaxPercentageFuelMapChange
        ElseIf percentageChange < -My.Settings.AutoTuneMaxPercentageFuelMapChange Then
            percentageChange = -My.Settings.AutoTuneMaxPercentageFuelMapChange
        End If

        Return True

    End Function

    Public Function CalculateAvgAFR(ByVal values As List(Of LogValue), ByRef dataCount As Integer) As Double

        Dim totalAfr As Double = 0
        Dim totalCount As Double = 0
        Dim avgAfr As Double

        For Each value As LogValue In values

            Dim afr As Double = 0

            If value.AFR > 0 Then
                dataCount = dataCount + 1
                totalAfr = totalAfr + value.AFR
                totalCount = totalCount + 1
            End If

        Next

        If totalCount > 0 Then

            avgAfr = totalAfr / totalCount

        End If

        Return avgAfr

    End Function

    Public Function GetCellColor(ByVal percentage As Double) As Color

        Try

            If percentage > My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Return Color.FromArgb(255, 0, 0)

            ElseIf percentage > 0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Dim greenValue As Integer = (My.Settings.AutoTuneMaxPercentageFuelMapChange - percentage) / My.Settings.AutoTuneMaxPercentageFuelMapChange * 255
                Return Color.FromArgb(255, greenValue, 0)

            ElseIf percentage <= 0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange And percentage >= -0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Return Color.White

            ElseIf percentage < -0.1 * My.Settings.AutoTuneMaxPercentageFuelMapChange And percentage > -My.Settings.AutoTuneMaxPercentageFuelMapChange Then

                Dim greenValue As Integer = (My.Settings.AutoTuneMaxPercentageFuelMapChange + percentage) / My.Settings.AutoTuneMaxPercentageFuelMapChange * 255
                Return Color.FromArgb(0, greenValue, 255)

            Else

                Return Color.FromArgb(0, 0, 255)

            End If

        Catch ex As Exception
            Dim mess As String = ex.Message

        End Try

    End Function

    Public Function GetCellForeColor(ByVal percentage As Double) As Color

        If percentage < -0.35 * My.Settings.AutoTuneMaxPercentageFuelMapChange Then

            Return Color.FromArgb(192, 192, 192)

        Else

            Return Color.Black

        End If

    End Function

    Public Sub OpenInnovateFile(ByVal filePath As String)

        If String.IsNullOrEmpty(filePath) = False Then

            L_FileName.Text = _filePath

            Dim reader As TextReader = New StreamReader(filePath)

            Dim lineCount As Integer
            Dim nextLine As String = reader.ReadLine()
            nextLine = reader.ReadLine()
            nextLine = reader.ReadLine()
            nextLine = reader.ReadLine()

            While String.IsNullOrEmpty(nextLine) = False

                Dim values As String()
                values = nextLine.Split(",")
                nextLine = reader.ReadLine()
                lineCount = lineCount + 1

                If lineCount > 1 Then

                    Dim logValue As New LogValue()
                    logValue.LogTime = values(0)
                    logValue.RPM = values(6)
                    logValue.TPS = values(7)
                    logValue.IAP = values(9) * -6.8947572931683609
                    logValue.AFR = values(1)
                    logValue.BOOST = values(9)

                    Dim tpsIndex As Integer
                    Dim iapIndex As Integer
                    Dim rpmIndex As Integer
                    Dim boostIndex As Integer = -1
                    Dim boostRPMIndex As Integer = -1

                    If logValue.RPM > _rpmList(_rpmList.Count - 1) Then

                        rpmIndex = -1

                    Else

                        For index As Integer = 0 To _rpmList.Count - 1 Step 1

                            If logValue.RPM <= _rpmList(index) + (_rpmList(index + 1) - _rpmList(index)) / 2 Then
                                rpmIndex = index
                                Exit For
                            End If

                        Next

                    End If

                    If logValue.TPS >= 99 Then
                        tpsIndex = _tpsList.Count - 1
                    ElseIf logValue.TPS >= 80 Then
                        tpsIndex = _tpsList.Count - 2
                    Else
                        For index As Integer = 0 To _tpsList.Count - 1 Step 1

                            If logValue.TPS <= _tpsList(index) + (_tpsList(index + 1) - _tpsList(index)) / 2 Then
                                tpsIndex = index
                                Exit For
                            End If

                        Next
                    End If

                    If logValue.IAP > _iapList(0) Then

                        iapIndex = -1

                    ElseIf logValue.IAP > 62.5 Then

                        iapIndex = 0

                    Else
                        For index As Integer = _iapList.Count - 1 To 0 Step -1

                            If logValue.IAP <= _iapList(index) + (_iapList(index - 1) - _iapList(index)) / 2 Then
                                iapIndex = index
                                Exit For
                            End If

                        Next

                    End If

                    For index As Integer = 0 To _boostList.Count - 1

                        If logValue.BOOST <= _boostList(index) + 0.5 Then

                            boostIndex = index
                            Exit For

                        End If

                    Next

                    If boostIndex = -1 Then
                        boostIndex = _boostList.Count - 1
                    End If

                    For index As Integer = 1 To _boostRPMList.Count - 1

                        If logValue.RPM <= _boostRPMList(index) Then

                            boostRPMIndex = index
                            Exit For

                        End If

                    Next

                    If logValue.TPS < 11 And iapIndex > -1 And rpmIndex > -1 Then

                        _iapValues(iapIndex, rpmIndex).Add(logValue)

                    End If

                    If rpmIndex > -1 Then

                        _tpsValues(tpsIndex, rpmIndex).Add(logValue)

                    End If

                    If boostRPMIndex > -1 Then

                        _boostValues(boostIndex, boostRPMIndex).Add(logValue)

                    End If
                End If
            End While

            reader.Close()

            ShowMap()

        End If

    End Sub

    Private Sub ShowTPSHeaders()

        G_FuelMap.RowCount = _rpmList.Count
        G_FuelMap.ColumnCount = _tpsList.Count

        For index As Integer = 0 To _tpsList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0.0"
            G_FuelMap.Columns.Item(index).HeaderText() = _tpsList(index)
            G_FuelMap.Columns(index).Width = 35

        Next

        G_FuelMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        For index As Integer = 0 To _rpmList.Count - 1 Step 1

            G_FuelMap.Rows.Item(index).HeaderCell.Value = _rpmList(index).ToString()
            G_FuelMap.Rows.Item(index).Height = 15

        Next

    End Sub

    Private Sub ShowIAPHeaders()

        G_FuelMap.RowCount = _rpmList.Count
        G_FuelMap.ColumnCount = _iapList.Count

        For index As Integer = 0 To _iapList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0.0"
            G_FuelMap.Columns.Item(index).HeaderText() = _iapList(index)
            G_FuelMap.Columns(index).Width = 35

        Next

        G_FuelMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        For index As Integer = 0 To _rpmList.Count - 1 Step 1

            G_FuelMap.Rows.Item(index).HeaderCell.Value = _rpmList(index).ToString()
            G_FuelMap.Rows.Item(index).Height = 15

        Next

    End Sub

    Private Sub ShowBoostHeaders()

        G_FuelMap.RowCount = _boostRPMList.Count
        G_FuelMap.ColumnCount = _boostList.Count

        For index As Integer = 0 To _boostList.Count - 1 Step 1

            G_FuelMap.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            G_FuelMap.Columns(index).DefaultCellStyle.Format = "0.0"
            G_FuelMap.Columns.Item(index).HeaderText() = _boostList(index)
            G_FuelMap.Columns(index).Width = 35

        Next

        G_FuelMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

        For index As Integer = 0 To _boostRPMList.Count - 1 Step 1

            G_FuelMap.Rows.Item(index).HeaderCell.Value = _boostRPMList(index).ToString()
            G_FuelMap.Rows.Item(index).Height = 15

        Next

    End Sub

    Private Sub ShowLoggedTPSValues()

        ShowTPSHeaders()

        Dim dataCount As Integer

        For tpsIndex As Integer = 0 To _tpsList.Count - 1 Step 1
            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                G_FuelMap.Item(tpsIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(tpsIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(tpsIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(tpsIndex, rpmIndex)) / avgAfr * 100)

                    G_FuelMap.Item(tpsIndex, rpmIndex).Value = avgAfr
                    G_FuelMap.Item(tpsIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(tpsIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowLoggedIAPValues()

        ShowIAPHeaders()

        Dim dataCount As Integer

        For iapIndex As Integer = 0 To _iapList.Count - 1 Step 1
            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                G_FuelMap.Item(iapIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(iapIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(iapIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _iapTargetAFR(iapIndex, rpmIndex)) / avgAfr * 100)

                    G_FuelMap.Item(iapIndex, rpmIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(iapIndex, rpmIndex).Value = avgAfr.ToString("0.00")
                    G_FuelMap.Item(iapIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(iapIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowLoggedBoostValues()

        ShowBoostHeaders()

        Dim dataCount As Integer

        For boostIndex As Integer = 0 To _boostList.Count - 1 Step 1
            For rpmIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                G_FuelMap.Item(boostIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(boostIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_boostValues(boostIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _boostTargetAFR(boostIndex, rpmIndex)) / avgAfr * 100)

                    G_FuelMap.Item(boostIndex, rpmIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    G_FuelMap.Item(boostIndex, rpmIndex).Value = avgAfr.ToString("0.00")
                    G_FuelMap.Item(boostIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.Item(boostIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                End If

            Next

        Next

        L_FileName.Text = _filePath & " Data Samples: " + dataCount.ToString()

    End Sub

    Private Sub ShowTargetTPSValues()

        ShowTPSHeaders()

        For xindex As Integer = 0 To _tpsList.Count - 1
            For yindex As Integer = 0 To _rpmList.Count - 1

                G_FuelMap.Item(xindex, yindex).Value = _tpsTargetAFR(xindex, yindex)

            Next
        Next

    End Sub

    Private Sub ShowTargetIAPValues()

        ShowIAPHeaders()

        For xindex As Integer = 0 To _iapList.Count - 1
            For yindex As Integer = 0 To _rpmList.Count - 1

                G_FuelMap.Item(xindex, yindex).Value = _iapTargetAFR(xindex, yindex)

            Next
        Next

    End Sub

    Private Sub ShowTargetBoostValues()

        ShowBoostHeaders()

        For xindex As Integer = 0 To _boostList.Count - 1
            For yindex As Integer = 0 To _boostRPMList.Count - 1

                G_FuelMap.Item(xindex, yindex).Value = _boostTargetAFR(xindex, yindex)

            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeTPSValues()

        ShowTPSHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For tpsIndex As Integer = 0 To _tpsList.Count - 1 Step 1
            If _tpsList(tpsIndex) >= 11 Then

                For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                    dataCount = 0
                    G_FuelMap.Item(tpsIndex, rpmIndex).Style.BackColor = Color.White
                    G_FuelMap.Item(tpsIndex, rpmIndex).Style.ForeColor = Color.Black

                    Dim avgAfr As Double = CalculateAvgAFR(_tpsValues(tpsIndex, rpmIndex), dataCount)

                    If avgAfr > 0 Then

                        percentageChange = AutoTuneCorrection((avgAfr - _tpsTargetAFR(tpsIndex, rpmIndex)) / avgAfr * 100)

                        If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                            G_FuelMap.Item(tpsIndex, rpmIndex).Value = percentageChange
                            G_FuelMap.Item(tpsIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                            G_FuelMap.Item(tpsIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                        End If
                    End If
                Next

            End If
        Next

    End Sub

    Private Sub ShowPercentageMapChangeIAPValues()

        ShowIAPHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For iapIndex As Integer = 0 To _iapList.Count - 1 Step 1

            For rpmIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(iapIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(iapIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_iapValues(iapIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    percentageChange = AutoTuneCorrection((avgAfr - _iapTargetAFR(iapIndex, rpmIndex)) / avgAfr * 100)

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(iapIndex, rpmIndex).Value = percentageChange
                        G_FuelMap.Item(iapIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(iapIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)
                    Else

                        G_FuelMap.Item(iapIndex, rpmIndex).Value = ""

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub ShowPercentageMapChangeBoostValues()

        ShowBoostHeaders()

        Dim percentageChange As Double
        Dim dataCount As Integer

        For boostIndex As Integer = 0 To _boostList.Count - 1 Step 1
            For rpmIndex As Integer = 0 To _boostRPMList.Count - 1 Step 1

                dataCount = 0
                G_FuelMap.Item(boostIndex, rpmIndex).Style.BackColor = Color.White
                G_FuelMap.Item(boostIndex, rpmIndex).Style.ForeColor = Color.Black

                Dim avgAfr As Double = CalculateAvgAFR(_boostValues(boostIndex, rpmIndex), dataCount)

                If avgAfr > 0 Then

                    percentageChange = AutoTuneCorrection((avgAfr - _boostTargetAFR(boostIndex, rpmIndex)) / avgAfr * 100)

                    If CheckAutoTuneFilter(avgAfr, percentageChange, dataCount) Then

                        G_FuelMap.Item(boostIndex, rpmIndex).Value = percentageChange
                        G_FuelMap.Item(boostIndex, rpmIndex).Style.BackColor = GetCellColor(percentageChange)
                        G_FuelMap.Item(boostIndex, rpmIndex).Style.ForeColor = GetCellForeColor(percentageChange)

                    End If
                End If
            Next
        Next

    End Sub

    Private Sub G_FuelMap_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellContentClick

        If e.RowIndex > -1 And e.ColumnIndex > -1 Then

            Dim values As List(Of LogValue) = New List(Of LogValue)

            If _mapType = 1 Then
                values = _tpsValues(e.ColumnIndex, e.RowIndex)
            ElseIf _mapType = 2 Then
                values = _iapValues(e.ColumnIndex, e.RowIndex)
            ElseIf _mapType = 3 Then
                values = _boostValues(e.ColumnIndex, e.RowIndex)
            End If

            LB_Values.DataSource = values
            L_CellDataCount.Text = values.Count.ToString()

        End If
    End Sub

    Private Sub ClearMap()

        If G_FuelMap.RowCount = 0 Or G_FuelMap.ColumnCount = 0 Then

            Return

        End If

        For x As Integer = 0 To G_FuelMap.ColumnCount - 1
            For y As Integer = 0 To G_FuelMap.RowCount - 1
                G_FuelMap.Item(x, y).Value = ""
                G_FuelMap.Item(x, y).Style.BackColor = Color.White
                G_FuelMap.Item(x, y).Style.ForeColor = Color.Black
            Next
        Next

    End Sub

    Private Sub G_FuelMap_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellClick

        G_FuelMap_CellContentClick(sender, e)

    End Sub

    Private Sub N_MinTPS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles N_MinTPS.ValueChanged

        If _loading = False Then

            My.Settings.MinTPS = N_MinTPS.Value
            My.Settings.Save()

            ShowLoggedBoostValues()

        End If

    End Sub

    Private Sub LB_Values_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_Values.SelectedIndexChanged

        Dim logValue As LogValue = LB_Values.SelectedItem

        LV_ValueDetails.Items.Clear()

        If logValue Is Nothing = False Then

            Dim item As New ListViewItem("Log Time", 0)
            item.SubItems.Add(logValue.LogTime)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("RPM", 0)
            item.SubItems.Add(logValue.RPM)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("TPS", 0)
            item.SubItems.Add(logValue.TPS)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IAP", 0)
            item.SubItems.Add(logValue.IAP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("AFR", 0)
            item.SubItems.Add(logValue.AFR.ToString("0.00"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("H02", 0)
            item.SubItems.Add(logValue.H02)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("Wideband", 0)
            item.SubItems.Add(logValue.WIDEBAND)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("MTS AFR", 0)
            item.SubItems.Add(logValue.MTS_AFR)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IGN", 0)
            item.SubItems.Add(logValue.IGN)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("STP", 0)
            item.SubItems.Add(logValue.STP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("GEAR", 0)
            item.SubItems.Add(logValue.GEAR)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("Clutch", 0)
            item.SubItems.Add(logValue.CLUTCH)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("BOOST", 0)
            item.SubItems.Add(logValue.BOOST.ToString("0.0"))
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IP", 0)
            item.SubItems.Add(logValue.IP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("AP", 0)
            item.SubItems.Add(logValue.AP)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("CLT", 0)
            item.SubItems.Add(logValue.CLT)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("IAT", 0)
            item.SubItems.Add(logValue.IAT)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("BATT", 0)
            item.SubItems.Add(logValue.BATT)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL1", 0)
            item.SubItems.Add(logValue.FUEL1)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL2", 0)
            item.SubItems.Add(logValue.FUEL2)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL3", 0)
            item.SubItems.Add(logValue.FUEL3)
            LV_ValueDetails.Items.Add(item)

            item = New ListViewItem("FUEL4", 0)
            item.SubItems.Add(logValue.FUEL4)
            LV_ValueDetails.Items.Add(item)

        End If

    End Sub

    Private Sub C_WidebandO2Sensor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C_WidebandO2Sensor.CheckedChanged

        My.Settings.WidebandO2Sensor = C_WidebandO2Sensor.Checked
        My.Settings.Save()

    End Sub

    Private Sub B_DataFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DataFilters.Click

        K8EngineDataFilter.ShowDialog()
        ShowMap()

    End Sub

    Private Sub R_LoggedAFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_LoggedAFR.CheckedChanged

        ShowMap()

        SetAutoTuneButton()

        B_LoadTargetAFR.Visible = False
        B_SaveTargetAFR.Visible = False

    End Sub

    Private Sub R_TargetAFR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_TargetAFR.CheckedChanged

        ShowMap()

        SetAutoTuneButton()

        B_LoadTargetAFR.Visible = True
        B_SaveTargetAFR.Visible = True

    End Sub

    Private Sub R_PercentageMapChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_PercentageMapChange.CheckedChanged

        ShowMap()

        SetAutoTuneButton()

        B_LoadTargetAFR.Visible = False
        B_SaveTargetAFR.Visible = False

    End Sub

    Private Sub SetAutoTuneButton()

        If R_PercentageMapChange.Checked = True Then
            B_AutoTune.Visible = True
        Else
            B_AutoTune.Visible = False
        End If

        If R_TPSRPM.Checked Then
            If _autoTunedTPS = False Then
                B_AutoTune.Enabled = True
            Else
                B_AutoTune.Enabled = False
            End If
        End If

        If R_IAPRPM.Checked Then
            If _autoTunedIAP = False Then
                B_AutoTune.Enabled = True
            Else
                B_AutoTune.Enabled = False
            End If
        End If

        If R_BOOSTRPM.Checked Then
            If _autoTunedBoost = False Then
                B_AutoTune.Enabled = False
            Else
                B_AutoTune.Enabled = False
            End If
        End If

    End Sub

    Private Sub ShowMap()

        _mapLoading = True

        ClearMap()

        If R_LoggedAFR.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditProgrammatically

            If _mapType = 1 Then
                ShowLoggedTPSValues()
            ElseIf _mapType = 2 Then
                ShowLoggedIAPValues()
            ElseIf _mapType = 3 Then
                ShowLoggedBoostValues()
            End If

        ElseIf R_TargetAFR.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            If _mapType = 1 Then
                ShowTargetTPSValues()
            ElseIf _mapType = 2 Then
                ShowTargetIAPValues()
            ElseIf _mapType = 3 Then
                ShowTargetBoostValues()
            End If

        ElseIf R_PercentageMapChange.Checked = True Then

            G_FuelMap.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            If _mapType = 1 Then
                ShowPercentageMapChangeTPSValues()
            ElseIf _mapType = 2 Then
                ShowPercentageMapChangeIAPValues()
            ElseIf _mapType = 3 Then
                ShowPercentageMapChangeBoostValues()
            End If

        End If

        _mapLoading = False

    End Sub

    Private Sub B_AutoTuneSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_AutoTuneSettings.Click

        K8AutoTuneSettings.ShowDialog()
        ShowMap()

    End Sub

    Private Sub B_SaveTargetAFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_SaveTargetAFR.Click

        Try

            SaveFileDialog1.Filter = ".tafr|*.tafr"

            If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Using textFile As System.IO.TextWriter = New StreamWriter(SaveFileDialog1.FileName)

                    For yIndex As Integer = 0 To _rpmList.Count - 1 Step 1

                        Dim stringBuilder As New StringBuilder()

                        For xIndex As Integer = 0 To _tpsList.Count - 1 Step 1

                            stringBuilder.Append(_tpsTargetAFR(xIndex, yIndex).ToString("0.0"))

                            If xIndex < _tpsList.Count - 1 Then
                                stringBuilder.Append("|")
                            End If
                        Next

                        textFile.WriteLine(stringBuilder.ToString())
                    Next

                    For yIndex As Integer = 0 To _rpmList.Count - 1
                        Dim stringBuilder As New StringBuilder()
                        For xIndex As Integer = 0 To _iapList.Count - 1

                            stringBuilder.Append(_iapTargetAFR(xIndex, yIndex).ToString("0.0"))

                            If xIndex < _iapList.Count - 1 Then
                                stringBuilder.Append("|")
                            End If
                        Next

                        textFile.WriteLine(stringBuilder.ToString())
                    Next

                    For yIndex As Integer = 0 To _boostRPMList.Count - 1
                        Dim stringBuilder As New StringBuilder()
                        For xIndex As Integer = 0 To _boostList.Count - 1

                            stringBuilder.Append(_boostTargetAFR(xIndex, yIndex).ToString("0.0"))

                            If xIndex < _boostList.Count - 1 Then
                                stringBuilder.Append("|")
                            End If
                        Next

                        textFile.WriteLine(stringBuilder.ToString())

                    Next

                    textFile.Close()

                End Using

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace, "ECU Editor Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub B_LoadTargetAFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_LoadTargetAFR.Click

        Try

            OpenFileDialog1.Filter = ".tafr|*.tafr"

            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Using textFile As System.IO.TextReader = New StreamReader(OpenFileDialog1.FileName)

                    Dim line As String = textFile.ReadLine()
                    Dim tpsRPMIndex As Integer = 0
                    Dim iapRPMIndex As Integer = 0
                    Dim boostRPMIndex As Integer = 0

                    While String.IsNullOrEmpty(line) = False

                        Dim values As String() = line.Split("|")

                        If values.Length = 23 Then

                            For index As Integer = 0 To values.Length - 1 Step 1
                                Dim value As Double = 0

                                If Double.TryParse(values(index), value) Then
                                    _tpsTargetAFR(index, tpsRPMIndex) = value
                                End If
                            Next

                            tpsRPMIndex = tpsRPMIndex + 1

                        End If

                        If values.Length = 21 Then

                            For index As Integer = 0 To values.Length - 1 Step 1
                                Dim value As Double = 0

                                If Double.TryParse(values(index), value) Then
                                    _iapTargetAFR(index, iapRPMIndex) = value
                                End If
                            Next

                            iapRPMIndex = iapRPMIndex + 1

                        End If

                        If values.Length = 16 Then

                            For index As Integer = 0 To values.Length - 1 Step 1
                                Dim value As Double = 0

                                If Double.TryParse(values(index), value) Then
                                    _boostTargetAFR(index, boostRPMIndex) = value
                                End If
                            Next

                            boostRPMIndex = boostRPMIndex + 1

                        End If

                        line = textFile.ReadLine()

                    End While

                    textFile.Close()

                End Using

            End If

            ShowMap()

        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace, "ECU Editor Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub G_FuelMap_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles G_FuelMap.CellValueChanged

        If e.ColumnIndex < 0 Or e.RowIndex < 0 Or _mapLoading = True Then
            Return
        End If

        If R_TargetAFR.Checked = True Then

            Dim value As Double = 0

            If Double.TryParse(G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), value) = True Then

                If _mapType = 1 Then
                    _tpsTargetAFR(e.ColumnIndex, e.RowIndex) = value
                ElseIf _mapType = 2 Then
                    _iapTargetAFR(e.ColumnIndex, e.RowIndex) = value
                ElseIf _mapType = 3 Then
                    _boostTargetAFR(e.ColumnIndex, e.RowIndex) = value
                End If
            Else

                If _mapType = 1 Then
                    G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value = _tpsTargetAFR(e.ColumnIndex, e.RowIndex)
                ElseIf _mapType = 2 Then
                    G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value = _iapTargetAFR(e.ColumnIndex, e.RowIndex)
                ElseIf _mapType = 3 Then
                    G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value = _iapTargetAFR(e.ColumnIndex, e.RowIndex)
                End If

            End If

        ElseIf R_PercentageMapChange.Checked = True Then

            Dim value As Double = 0

            If Double.TryParse(G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Value.ToString(), value) = True Then

                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = GetCellColor(value)
                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.ForeColor = GetCellForeColor(value)

            Else

                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = GetCellColor(0)
                G_FuelMap.Item(e.ColumnIndex, e.RowIndex).Style.ForeColor = GetCellForeColor(0)

            End If
        End If

    End Sub

    Private Sub G_FuelMap_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles G_FuelMap.KeyDown

        If R_TargetAFR.Checked = True Or R_PercentageMapChange.Checked = True Then

            If (e.Control = True And e.KeyCode = Keys.V) Then
                Dim rowIndex As Integer
                Dim lines As String()
                Dim columnStartIndex As Integer

                rowIndex = Integer.MaxValue
                columnStartIndex = Integer.MaxValue

                For Each cell As DataGridViewCell In G_FuelMap.SelectedCells()
                    If cell.RowIndex < rowIndex Then
                        rowIndex = cell.RowIndex
                    End If

                    If cell.ColumnIndex < columnStartIndex Then
                        columnStartIndex = cell.ColumnIndex
                    End If
                Next

                rowIndex = G_FuelMap.CurrentCell.RowIndex

                lines = Clipboard.GetText().Split(ControlChars.CrLf)

                For Each line As String In lines
                    Dim columnIndex As Integer
                    Dim values As String()

                    values = line.Split(ControlChars.Tab)
                    columnIndex = columnStartIndex

                    For Each value As String In values
                        value = Replace(value, ControlChars.Lf, "") ' removing extra LF - issue 38
                        If columnIndex < G_FuelMap.ColumnCount And rowIndex < G_FuelMap.RowCount Then
                            If IsNumeric(value) Then
                                G_FuelMap(columnIndex, rowIndex).Value = value
                            End If
                        End If

                        columnIndex = columnIndex + 1
                    Next

                    rowIndex = rowIndex + 1
                Next

            End If
        End If
    End Sub

    Private Sub R_TPSRPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_TPSRPM.CheckedChanged

        If R_TPSRPM.Checked = True Then

            L_MinTPS.Visible = False
            N_MinTPS.Visible = False

            _mapType = 1
            ShowMap()

            SetAutoTuneButton()

        End If

    End Sub

    Private Sub R_IAPRPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_IAPRPM.CheckedChanged

        If R_IAPRPM.Checked = True Then

            L_MinTPS.Visible = False
            N_MinTPS.Visible = False

            _mapType = 2
            ShowMap()

            SetAutoTuneButton()

        End If

    End Sub

    Private Sub R_BOOSTRPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_BOOSTRPM.CheckedChanged

        If R_BOOSTRPM.Checked = True Then

            L_MinTPS.Visible = True
            N_MinTPS.Visible = True
            N_MinTPS.Value = My.Settings.MinTPS

            _mapType = 3
            ShowMap()

            SetAutoTuneButton()

        End If

    End Sub

    Private Sub B_AutoTune_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_AutoTune.Click

        Dim message As String = "You are about to apply the % Map Changes to the " & SelectedMapString & " fuel map." & Environment.NewLine & "Click OK to continue"

        If MessageBox.Show(message, "ECU Editor Auto Tune", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

            Dim value As Double = 0

            If R_TPSRPM.Checked = True Then

                AutoTuneTPSFuelMap()
                _autoTunedTPS = True

            ElseIf R_IAPRPM.Checked = True Then

                AutoTuneIAPFuelMap()
                _autoTunedIAP = True

            ElseIf R_BOOSTRPM.Checked = True Then

                AutoTuneBoostFuelMap()
                _autoTunedBoost = True

            End If

            message = "% Map Changes have been applied to " & SelectedMapString & " fuel map." & Environment.NewLine & "Click OK to continue"
            MessageBox.Show(message, "ECU Editor Auto Tune", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            B_AutoTune.Enabled = False

        End If

    End Sub

    Public Sub AutoTuneTPSFuelMap()

        Dim mapStructureTable As Integer
        Dim cylinder As Integer = 0        ' 0,1,2,3
        Dim ms01 As Integer = 0            ' 0,1
        Dim modeabc As Integer = 0
        Dim copyToMap As Long = 0
        Dim editingMap As Integer = 0
        Dim mapNumberOfColumns As Integer = 0
        Dim mapNumberOfRows As Integer = 0
        Dim autoTunePercentage As Double = 0
        Dim currentValue As Integer = 0
        Dim newValue As Integer = 0

        If ECUVersion = "gen2" Then
            mapStructureTable = &H52304
        ElseIf ECUVersion = "bking" Then
            mapStructureTable = &H54EB4
        End If

        editingMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
        mapNumberOfColumns = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
        mapNumberOfRows = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

        For columnIndex As Integer = 0 To _tpsList.Count - 1
            If _tpsList(columnIndex) >= 11 Then

                For rowIndex As Integer = 0 To _rpmList.Count - 1
                    If Double.TryParse(G_FuelMap.Item(columnIndex, rowIndex).Value, autoTunePercentage) = True Then

                        currentValue = ReadFlashWord(editingMap + (2 * (columnIndex + (rowIndex * mapNumberOfColumns))))
                        newValue = currentValue * (1 + autoTunePercentage / 100)

                        For cylinder = 0 To 3
                            For ms01 = 0 To 0
                                copyToMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                                WriteFlashWord(copyToMap + (2 * (columnIndex + (rowIndex * mapNumberOfColumns))), newValue)
                            Next
                        Next

                    End If
                Next

            End If
        Next

    End Sub

    Public Sub AutoTuneIAPFuelMap()

        Try

            Dim mapStructureTable As Integer
            Dim mapStructureTable2 As Integer
            Dim cylinder As Integer = 0        ' 0,1,2,3
            Dim ms01 As Integer = 0            ' 0,1
            Dim modeabc As Integer = 0
            Dim copyToMap As Long = 0
            Dim copyToMap2 As Long = 0
            Dim editingMap As Integer = 0
            Dim mapNumberOfColumns As Integer = 0
            Dim mapNumberOfRows As Integer = 0
            Dim autoTunePercentage As Double = 0
            Dim currentValue As Integer = 0
            Dim newValue As Integer = 0

            If ECUVersion = "gen2" Then
                mapStructureTable = &H52244
                mapStructureTable2 = &H522A4
            ElseIf ECUVersion = "bking" Then
                mapStructureTable = &H54DF4
                mapStructureTable2 = &H54E54
            End If

            editingMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
            mapNumberOfColumns = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 1)
            mapNumberOfRows = ReadFlashByte(ReadFlashLongWord(mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4) + 2)

            For columnIndex As Integer = 0 To _iapList.Count - 1
                For rowIndex As Integer = 0 To _rpmList.Count - 1
                    If Double.TryParse(G_FuelMap.Item(columnIndex, rowIndex).Value, autoTunePercentage) = True Then

                        currentValue = ReadFlashWord(editingMap + (2 * (columnIndex + (rowIndex * mapNumberOfColumns))))
                        newValue = currentValue * (1 + autoTunePercentage / 100)

                        For cylinder = 0 To 3
                            For ms01 = 0 To 1
                                copyToMap = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                                WriteFlashWord(copyToMap + (2 * (columnIndex + (rowIndex * mapNumberOfColumns))), newValue)

                                copyToMap2 = ReadFlashLongWord(ReadFlashLongWord((mapStructureTable2 + ((cylinder * 6) + (3 * ms01) + modeabc) * 4)) + 12)
                                WriteFlashWord(copyToMap2 + (2 * (columnIndex + (rowIndex * mapNumberOfColumns))), newValue)
                            Next
                        Next

                    End If
                Next
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message & Environment.NewLine & ex.StackTrace)

        End Try
    End Sub

    Public Sub AutoTuneBoostFuelMap()

    End Sub

    Public Function AutoTuneCorrection(ByVal percentageChange As Double) As Double

        Dim value As Double = Math.Abs(percentageChange)

        If value < 5 Then
            percentageChange = 0.75 * percentageChange
        ElseIf value >= 5 And value < 10 Then
            percentageChange = 0.725 * percentageChange
        ElseIf value >= 10 And value < 15 Then
            percentageChange = 0.7 * percentageChange
        ElseIf value >= 15 Then
            percentageChange = 0.675 * percentageChange
        End If

        Return percentageChange

    End Function

    Private Sub LB_Values_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LB_Values.KeyDown

        If (e.Control = True And e.KeyCode = Keys.D) Then

            Dim values As List(Of LogValue) = New List(Of LogValue)

            If _mapType = 1 Then
                values = _tpsValues(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)
            ElseIf _mapType = 2 Then
                values = _iapValues(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)
            ElseIf _mapType = 3 Then
                values = _boostValues(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)
            End If

            values.Remove(LB_Values.SelectedItem)

            LB_Values.DataSource = Nothing
            LB_Values.DataSource = values
            L_CellDataCount.Text = values.Count.ToString()

            G_FuelMap.CurrentCell.Style.BackColor = Color.White
            G_FuelMap.CurrentCell.Style.ForeColor = Color.Black

            Dim dataCount As Integer
            Dim avgAfr As Decimal = CalculateAvgAFR(values, dataCount)

            If R_LoggedAFR.Checked Then

                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)) / avgAfr * 100)

                    G_FuelMap.CurrentCell.Value = avgAfr
                    G_FuelMap.CurrentCell.Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.CurrentCell.Style.ForeColor = GetCellForeColor(percentageChange)
                Else
                    G_FuelMap.CurrentCell.Value = ""
                End If

            ElseIf R_PercentageMapChange.Checked = True Then
                If avgAfr > 0 Then

                    Dim percentageChange As Double = AutoTuneCorrection((avgAfr - _tpsTargetAFR(G_FuelMap.CurrentCell.ColumnIndex, G_FuelMap.CurrentCell.RowIndex)) / avgAfr * 100)
                    G_FuelMap.CurrentCell.Value = percentageChange
                    G_FuelMap.CurrentCell.Style.BackColor = GetCellColor(percentageChange)
                    G_FuelMap.CurrentCell.Style.ForeColor = GetCellForeColor(percentageChange)
                Else
                    G_FuelMap.CurrentCell.Value = ""
                End If
            End If

        End If

    End Sub
End Class