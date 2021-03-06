Module CommonFunctions

#Region "Variables"

    Private Const _timerInterval As Integer = 250
    Private Const _maxDataLog As Integer = 40000

    Public Flash(262144 * 4) As Byte
    Public FlashCopy(262144 * 4) As Byte
    Public AdjustMap(9 * 9)
    Public ConfigBytes(256) As Integer

    Public BoostFuelMode As Integer = 0

    Public DataLog(CInt(1000 / TimerInterval * MaxDataLog), 16) As Integer
    Public DataLogPointer As Integer
    Public DataLogLength As Integer

    Private _rpm As Integer
    Private _tps As Integer
    Private _iap As Integer 'ambient - intake air pressure
    Private _oxy As Integer
    Private _clt As Integer
    Private _usr1 As Integer 'user can define this 1variable to be monitored
    Private _ramVarUsr1 As Integer ' index of the USR1 variable within RAM
    Private _fuel As Integer
    Private _ap As Integer ' Air pressure
    Private _ip As Integer 'intake air pressure
    Private _ign As Integer
    Private _duty As Integer
    Private _afr As Integer
    Private _ms As Integer
    Private _nt As Integer
    Private _clutch As Integer
    Private _pair As Integer
    Private _mode As Integer
    Private _gear As Integer
    Private _ho2 As Integer
    Private _batt As Integer
    Private _stp As Integer
    Private _iat As Integer
    Private _sAPabs As Integer
    Private _iAPabs As Integer
    Private _boost As Integer
    Private _dsm1 As Boolean

    Private _loopErrorCodes As Integer
    Private _blockPgm As Boolean
    Private _block0 As Boolean
    Private _block1 As Boolean
    Private _block2 As Boolean
    Private _block3 As Boolean
    Private _block4 As Boolean
    Private _block5 As Boolean
    Private _block6 As Boolean
    Private _block7 As Boolean
    Private _block8 As Boolean
    Private _block9 As Boolean
    Private _blockA As Boolean
    Private _blockB As Boolean
    Private _blockC As Boolean
    Private _blockD As Boolean
    Private _blockE As Boolean
    Private _blockF As Boolean

    Private _cc As Integer
    Private _rr As Integer
    Private _icc As Integer
    Private _irr As Integer

    Private _readProcessOnGoing As Boolean
    Private _fuelMapVisible As Boolean
    Private _ignitionMapVisible As Boolean
    Private _innovateVisible As Boolean

    Private _mapAddr1 As Integer
    Private _mapAddr2 As Integer
    Private _mapAddr3 As Integer
    Private _mapAddr4 As Integer
    Private _mapRows As Integer
    Private _mapColumns As Integer
    Private _rowSelected As Integer
    Private _mapVisible As String

    Private _ignMapAddrA As Integer
    Private _ignMapAddrB As Integer
    Private _ignMapRows As Integer
    Private _ignMapColumns As Integer
    Private _ignRowSelected As Integer
    Private _ignMapVisible As String

    Private _metric As Boolean
    Private _eCUVersion As String ' either gen1 or gen2 indicating which ecu version is under modification

    Public gixxer_modelname As String = "ecueditor.com for gixxer K8 "
    Public gixxer_injectorbalance_map_first As Integer = 0 '&H370648
    Public gixxer_injectorbalance_map_name As String = gixxer_modelname

    Public gixxer_shifter_ADJ As Integer = 0 '&H5D900
    Public gixxer_shifter_FUELCODE As Integer = 0 '&H5DA00
    Public gixxer_shifter_IGNCODE As Integer = 0 '&H5DE00
    Public gixxer_shifter_jmp_to_fuelcode As Integer = 0 '&H45A40
    Public gixxer_shifter_jmp_to_igncode As Integer = 0 '&H3B9C0
    Public gixxer_abc As Integer = 0 '&H220C4

    Public gixxer_STP_map_first_table As Long = 0 '&H59DD0
    Public gixxer_STP_map_first_table_fuel As Long = 0
    Public gixxer_STP_modelname As String = ""

    Public gixxer_fuelmap_map_first As Long = 0 '&H5A7F0
    Public gixxer_fuelmap_map_bikename As String = gixxer_modelname
    Public gixxer_ignition_rpm_limiter As Integer = 0 '&H60B2C
    Public gixxer_GPS_AD_sensor_address_in_ignition_shiftkill As Integer = 0 '&H3B4C1

    Public gixxer_fuel_limiter_by_gear As Integer = 0 '&H614C1
    Public gixxer_fuel_limiter_by_gear_softcut As Integer = 0 '&H614C4
    Public gixxer_RPM_limit_type1 As Integer = 0 '&H61372
    Public gixxer_fuel_limiter_softcut_or_hardcut As Integer = 0 '&H614BE
    Public gixxer_baseline As Integer = 0 '13450

    Public gixxer_ignition_map_first As Integer = 0 '&H5A3D8
    Public gixxer_ignition_map_name As String = ""
    Public gixxer_ignition_use_clutch_map As Integer = 0 '&H60B5C

    Public gixxer_msmode As Integer = 0 '&H6063A
    Public gixxer_coilfi As Integer = 0 '&H60BC1
    Public gixxer_fan As Integer = 0 '&H6296A
    Public gixxer_pair As Integer = 0 '&H62ABA
    Public gixxer_pairloop As Integer = 0 '&H56D5C
    Public gixxer_pairloop1 As Integer = 0 '&H56D5C
    Public gixxer_pairloop2 As Integer = 0 '&H56D5C
    Public gixxer_pairloop3 As Integer = 0 '&H56D5C

    Public gixxer_excva As Integer = 0 '&H6000D
    Public gixxer_excva_flag As Integer = 0 '&H60669
    Public gixxer_hoxflag As Integer = 0 '&H614D4
    Public gixxer_ecumode As Integer = 0 '&H604CF
    Public gixxer_ics1 As Integer = 0 '&H622EE
    Public gixxer_ics2 As Integer = 0 '&H6230A
    Public gixxer_ics3 As Integer = 0 '&H62296
    Public gixxer_hox1 As Integer = 0 '&H614D4
    Public gixxer_hox2 As Integer = 0 '&H62243
    Public gixxer_sdmap As Integer = 0 'gixxer_sdmap = &H5D840
    Public gixxer_sd1 As Integer = 0 '&H62AC1
    Public gixxer_sd2 As Integer = 0 '&H62ACF
    Public gixxer_sd3 As Integer = 0 '&H62AD2

    Public gixxer_GPS_voltage_raw As Integer = 0
    Public gixxer_set_ign_default As Integer = 0
    Public gixxerramair_columnheader As Integer = 0 ' &H7268E
    Public gixxerramair_map As Integer = 0 '&H72859

    Public gixxer_baud_rate As Integer
    Public gixxer_baud_rate_timer1 As Integer
    Public gixxer_baud_rate_timer2 As Integer

    Public gixxer_wideband1_original As Integer
    Public gixxer_wideband2_original As Integer
    Public gixxer_wideband3_original As Integer
    Public gixxer_wideband4_original As Integer

    Public gixxer_wideband1 As Integer
    Public gixxer_wideband2 As Integer

#End Region

#Region "Properties"

    ReadOnly Property TimerInterval() As Integer
        Get
            Return _timerInterval
        End Get
    End Property

    ReadOnly Property MaxDataLog() As Integer
        Get
            Return _maxDataLog
        End Get
    End Property

    Public Property RPM() As Integer
        Get
            Return _rpm
        End Get

        Set(ByVal value As Integer)
            _rpm = value
        End Set
    End Property

    Public Property TPS() As Integer
        Get
            Return _tps
        End Get
        Set(ByVal value As Integer)
            _tps = value
        End Set
    End Property

    Public Property IAP() As Integer
        Get
            Return _iap
        End Get
        Set(ByVal value As Integer)
            _iap = value
        End Set
    End Property

    Public Property OXY() As Integer
        Get
            Return _oxy
        End Get
        Set(ByVal value As Integer)
            _oxy = value
        End Set
    End Property

    Public Property CLT() As Integer
        Get
            Return _clt
        End Get
        Set(ByVal value As Integer)
            _clt = value
        End Set
    End Property

    Public Property USR1() As Integer
        Get
            Return _usr1
        End Get
        Set(ByVal value As Integer)
            _usr1 = value
        End Set
    End Property

    Public Property RAMVAR_USR1() As Integer
        Get
            Return _ramVarUsr1
        End Get
        Set(ByVal value As Integer)
            _ramVarUsr1 = value
        End Set
    End Property

    Public Property Fuel() As Integer
        Get
            Return _fuel
        End Get
        Set(ByVal value As Integer)
            _fuel = value
        End Set
    End Property

    Public Property AP()
        Get
            Return _ap
        End Get
        Set(ByVal value)
            _ap = value
        End Set
    End Property

    Public Property IP() As Integer
        Get
            Return _ip
        End Get
        Set(ByVal value As Integer)
            _ip = value
        End Set
    End Property

    Public Property IGN() As Integer
        Get
            Return _ign
        End Get
        Set(ByVal value As Integer)
            _ign = value
        End Set
    End Property

    Public Property DUTY() As Integer
        Get
            Return _duty
        End Get
        Set(ByVal value As Integer)
            _duty = value
        End Set
    End Property

    Public Property AFR() As Integer
        Get
            Return _afr
        End Get
        Set(ByVal value As Integer)
            _afr = value
        End Set
    End Property

    Public Property MS() As Integer
        Get
            Return _ms
        End Get
        Set(ByVal value As Integer)
            _ms = value
        End Set
    End Property

    Public Property NT() As Integer
        Get
            Return _nt
        End Get
        Set(ByVal value As Integer)
            _nt = value
        End Set
    End Property

    Public Property CLUTCH() As Integer
        Get
            Return _clutch
        End Get
        Set(ByVal value As Integer)
            _clutch = value
        End Set
    End Property

    Public Property PAIR() As Integer
        Get
            Return _pair
        End Get
        Set(ByVal value As Integer)
            _pair = value
        End Set
    End Property

    Public Property MODE() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property

    Public Property Gear() As Integer
        Get
            Return _gear
        End Get
        Set(ByVal value As Integer)
            _gear = value
        End Set
    End Property

    Public Property HO2() As Integer
        Get
            Return _ho2
        End Get
        Set(ByVal value As Integer)
            _ho2 = value
        End Set
    End Property

    Public Property BATT() As Integer
        Get
            Return _batt
        End Get
        Set(ByVal value As Integer)
            _batt = value
        End Set
    End Property

    Public Property STP() As Integer
        Get
            Return _stp
        End Get
        Set(ByVal value As Integer)
            _stp = value
        End Set
    End Property

    Public Property IAT() As Integer
        Get
            Return _iat
        End Get
        Set(ByVal value As Integer)
            _iat = value
        End Set
    End Property

    Public Property SAPabs() As Integer
        Get
            Return _sAPabs
        End Get
        Set(ByVal value As Integer)
            _sAPabs = value
        End Set
    End Property

    Public Property IAPabs() As Integer
        Get
            Return _iAPabs
        End Get
        Set(ByVal value As Integer)
            _iAPabs = value
        End Set
    End Property

    Public Property BOOST() As Integer
        Get
            Return _boost
        End Get
        Set(ByVal value As Integer)
            _boost = value
        End Set
    End Property

    Public Property DSM1() As Integer
        Get
            Return _dsm1
        End Get
        Set(ByVal value As Integer)
            _dsm1 = value
        End Set
    End Property

    Public Property BlockPgm() As Boolean
        Get
            Return _blockPgm
        End Get
        Set(ByVal value As Boolean)
            _blockPgm = value
        End Set
    End Property

    Public Property Block0() As Boolean
        Get
            Return _block0
        End Get
        Set(ByVal value As Boolean)
            _block0 = value
        End Set
    End Property

    Public Property Block1() As Boolean
        Get
            Return _block1
        End Get
        Set(ByVal value As Boolean)
            _block1 = value
        End Set
    End Property

    Public Property Block2() As Boolean
        Get
            Return _block2
        End Get
        Set(ByVal value As Boolean)
            _block2 = value
        End Set
    End Property

    Public Property Block3() As Boolean
        Get
            Return _block3
        End Get
        Set(ByVal value As Boolean)
            _block3 = value
        End Set
    End Property

    Public Property Block4() As Boolean
        Get
            Return _block4
        End Get
        Set(ByVal value As Boolean)
            _block4 = value
        End Set
    End Property

    Public Property Block5() As Boolean
        Get
            Return _block5
        End Get
        Set(ByVal value As Boolean)
            _block5 = value
        End Set
    End Property

    Public Property Block6() As Boolean
        Get
            Return _block6
        End Get
        Set(ByVal value As Boolean)
            _block6 = value
        End Set
    End Property

    Public Property Block7() As Boolean
        Get
            Return _block7
        End Get
        Set(ByVal value As Boolean)
            _block7 = value
        End Set
    End Property

    Public Property Block8() As Boolean
        Get
            Return _block8
        End Get
        Set(ByVal value As Boolean)
            _block8 = value
        End Set
    End Property

    Public Property Block9() As Boolean
        Get
            Return _block9
        End Get
        Set(ByVal value As Boolean)
            _block9 = value
        End Set
    End Property

    Public Property BlockA() As Boolean
        Get
            Return _blockA
        End Get
        Set(ByVal value As Boolean)
            _blockA = value
        End Set
    End Property

    Public Property BlockB() As Boolean
        Get
            Return _blockB
        End Get
        Set(ByVal value As Boolean)
            _blockB = value
        End Set
    End Property

    Public Property BlockC() As Boolean
        Get
            Return _blockC
        End Get
        Set(ByVal value As Boolean)
            _blockC = value
        End Set
    End Property

    Public Property BlockD() As Boolean
        Get
            Return _blockD
        End Get
        Set(ByVal value As Boolean)
            _blockD = value
        End Set
    End Property

    Public Property BlockE() As Boolean
        Get
            Return _blockE
        End Get
        Set(ByVal value As Boolean)
            _blockE = value
        End Set
    End Property

    Public Property BlockF() As Boolean
        Get
            Return _blockF
        End Get
        Set(ByVal value As Boolean)
            _blockF = value
        End Set
    End Property

    Public Property CC() As Integer
        Get
            Return _cc
        End Get
        Set(ByVal value As Integer)
            _cc = value
        End Set
    End Property

    Public Property RR() As Integer
        Get
            Return _rr
        End Get
        Set(ByVal value As Integer)
            _rr = value
        End Set
    End Property

    Public Property ICC() As Integer
        Get
            Return _icc
        End Get
        Set(ByVal value As Integer)
            _icc = value
        End Set
    End Property

    Public Property IRR() As Integer
        Get
            Return _irr
        End Get
        Set(ByVal value As Integer)
            _irr = value
        End Set
    End Property

    Public Property ReadProcessOnGoing() As Boolean
        Get
            Return _readProcessOnGoing
        End Get
        Set(ByVal value As Boolean)
            _readProcessOnGoing = value
        End Set
    End Property

    Public Property FuelMapVisible() As Boolean
        Get
            Return _fuelMapVisible
        End Get
        Set(ByVal value As Boolean)
            _fuelMapVisible = value
        End Set
    End Property

    Public Property IgnitionMapVisible() As Boolean
        Get
            Return _ignitionMapVisible
        End Get
        Set(ByVal value As Boolean)
            _ignitionMapVisible = value
        End Set
    End Property

    Public Property InnovateMapVisible() As Boolean
        Get
            Return _innovateVisible
        End Get
        Set(ByVal value As Boolean)
            _innovateVisible = value
        End Set
    End Property

    Public Property MapAddr1() As Integer
        Get
            Return _mapAddr1
        End Get
        Set(ByVal value As Integer)
            _mapAddr1 = value
        End Set
    End Property

    Public Property MapAddr2() As Integer
        Get
            Return _mapAddr2
        End Get
        Set(ByVal value As Integer)
            _mapAddr2 = value
        End Set
    End Property

    Public Property MapAddr3() As Integer
        Get
            Return _mapAddr3
        End Get
        Set(ByVal value As Integer)
            _mapAddr3 = value
        End Set
    End Property

    Public Property MapAddr4() As Integer
        Get
            Return _mapAddr4
        End Get
        Set(ByVal value As Integer)
            _mapAddr4 = value
        End Set
    End Property

    Public Property MapRows() As Integer
        Get
            Return _mapRows
        End Get
        Set(ByVal value As Integer)
            _mapRows = value
        End Set
    End Property

    Public Property MapColumns() As Integer
        Get
            Return _mapColumns
        End Get
        Set(ByVal value As Integer)
            _mapColumns = value
        End Set
    End Property

    Public Property RowSelected() As Integer
        Get
            Return _rowSelected
        End Get
        Set(ByVal value As Integer)
            _rowSelected = value
        End Set
    End Property

    Public Property MapVisible() As String
        Get
            Return _mapVisible
        End Get
        Set(ByVal value As String)
            _mapVisible = value
        End Set
    End Property

    Public Property IgnMapAddrA() As Integer
        Get
            Return _ignMapAddrA
        End Get
        Set(ByVal value As Integer)
            _ignMapAddrA = value
        End Set
    End Property

    Public Property IgnMapAddrB() As Integer
        Get
            Return _ignMapAddrB
        End Get
        Set(ByVal value As Integer)
            _ignMapAddrB = value
        End Set
    End Property

    Public Property IgnMapRows() As Integer
        Get
            Return _ignMapRows
        End Get
        Set(ByVal value As Integer)
            _ignMapRows = value
        End Set
    End Property

    Public Property IgnMapColumns() As Integer
        Get
            Return _ignMapColumns
        End Get
        Set(ByVal value As Integer)
            _ignMapColumns = value
        End Set
    End Property

    Public Property IgnRowSelected() As Integer
        Get
            Return _ignRowSelected
        End Get
        Set(ByVal value As Integer)
            _ignRowSelected = value
        End Set
    End Property

    Public Property IgnMapVisible() As String
        Get
            Return _ignMapVisible
        End Get
        Set(ByVal value As String)
            _ignMapVisible = value
        End Set
    End Property

    Public Property ECUVersion() As String
        Get
            Return _eCUVersion
        End Get
        Set(ByVal value As String)
            _eCUVersion = value
        End Set
    End Property

    Public Property Metric() As Boolean
        Get
            Return _metric
        End Get
        Set(ByVal value As Boolean)
            _metric = value
        End Set
    End Property

    Public ReadOnly Property BaudRate() As Integer
        Get

            If ECUVersion = "bking" Then

                If ReadFlashByte(&H13429) < &H17 Then

                    Return 50000

                Else

                    Return 10400

                End If

            ElseIf ECUVersion = "gen2" Then

                If ReadFlashByte(&H13259) < &H17 Then

                    Return 50000

                Else

                    Return 10400

                End If

            ElseIf ECUVersion = "enginedata" Then

                Return 10400

            ElseIf ECUVersion = "gixxer" Then

                If gixxer_baud_rate > 0 Then
                    If ReadFlashByte(gixxer_baud_rate) = &H4 Then
                        Return 50000
                    End If
                End If

                Return 10400

            End If

        End Get
        
    End Property

#End Region

#Region "Functions"

    Public Sub printthis()

    End Sub

    Public Function FastMode() As Boolean

        If readflashlongword(&H51F10) = &H536C4 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function CalcTPS(ByVal i As Integer) As String

        '  Used by gen1 and gen2 enginedata
        Dim f As Decimal
        Dim istr As String
        istr = ""

        f = (((i - 55) / (256 - 55)) * 125)
        If f > 100 Then f = 100

        istr = Format(f, "#0.0")

        Return (istr)

    End Function

    Public Function CalcTPSToVal(ByVal s As String) As Integer
        Dim f As Decimal
        Dim ir As String

        ir = 0
        f = Val(s)

        ir = ((f / 125) * (256 - 55)) + 55

        If ir < 0 Then ir = 0
        Return (ir)

    End Function

    Public Function CalcK8IAP(ByVal i As Integer) As String
        Dim f As Decimal
        Dim istr As String
        istr = ""

        f = i / 450
        'f = (i / 4) * 0.136

        If f >= 10 Then
            istr = Format(f, "###")
        Else
            istr = Format(f, "#0.#")
        End If

        Return (istr)

    End Function

    Public Function CalcK8TPS(ByVal i As Integer) As String
        '
        ' Used by map conversions
        '
        Dim f As Decimal
        Dim istr As String
        istr = ""

        f = (((i - &H3700) / (&HFFFF - &H3700)) * 125)
        If f > 100 Then f = 100

        If f > 5 Then
            istr = Format(f, "###")
        Else
            istr = Format(f, "#0.#")
        End If

        Return (istr)

    End Function

    Public Function CalcTPSDec(ByVal i As Integer) As Decimal
        Dim a As Decimal
        a = ((((i - 55) / (256 - 55)) * 125))
        If a <= 5 Then
            a = CInt(a * 10)
            a = a / 10
        End If
        If a > 100 Then a = 100
        Return (a)
    End Function

    Public Function Rows() As Integer
        Return (9)
    End Function

    Public Function Columns() As Integer
        Return (9)
    End Function

    Public Function ReadFlashWord(ByVal i As Integer) As Long
        Dim tmp As Long
        Dim maxi As Long

        Select Case ECUversion
            Case "gen1"
                maxi = 262144 - 1
            Case "gen2"
                maxi = (4 * 262144) - 1
            Case "bking"
                maxi = (4 * 262144) - 1
            Case "gixxer"
                maxi = (4 * 262144) - 1
        End Select


        If i < 0 Or i > maxi Then
            ErrorDialog.ShowDialog()
        Else
            tmp = (Flash(i) * 256) + Flash(i + 1)
        End If

        Return (tmp)

    End Function

    Public Function ReadFlashWordCopy(ByVal i As Integer) As Integer
        Dim tmp As Integer
        Dim maxi As Integer

        Select Case ECUversion
            Case "gen1"
                maxi = 262144 - 1
            Case "gen2"
                maxi = (4 * 262144) - 1
            Case "bking"
                maxi = (4 * 262144) - 1
            Case "gixxer"
                maxi = (4 * 262144) - 1
        End Select

        If i < 0 Or i > maxi Then
            ErrorDialog.ShowDialog()
        Else
            tmp = (FlashCopy(i) * 256) + FlashCopy(i + 1)
        End If

        Return (tmp)

    End Function

    Public Function ReadFlashByte(ByVal i As Integer) As Integer
        Dim tmp As Integer
        Dim maxi As Integer

        Select Case ECUversion
            Case "gen1"
                maxi = 262144 - 1
            Case "gen2"
                maxi = (4 * 262144) - 1
            Case "bking"
                maxi = (4 * 262144) - 1
            Case "gixxer"
                maxi = (4 * 262144) - 1
        End Select

        If i < 0 Or i > maxi Then
            ErrorDialog.ShowDialog()
        Else
            tmp = Flash(i)
        End If

        Return (tmp)

    End Function

    Public Function ReadFlashByteCopy(ByVal i As Integer) As Integer
        Dim tmp As Integer
        Dim maxi As Integer

        Select Case ECUversion
            Case "gen1"
                maxi = 262144 - 1
            Case "gen2"
                maxi = (4 * 262144) - 1
            Case "bking"
                maxi = (4 * 262144) - 1
            Case "gixxer"
                maxi = (4 * 262144) - 1
        End Select


        If i < 0 Or i > maxi Then
            ErrorDialog.ShowDialog()
        Else
            tmp = FlashCopy(i)
        End If

        Return (tmp)

    End Function

    Public Sub WriteFlashWord(ByVal address As Integer, ByVal word As Integer)
        Dim tmp As Byte
        Dim i As Integer

        i = Int(word / 256)
        If i > 255 Or i < 0 Then
            ErrorDialog.ShowDialog()
        Else
            tmp = i
            Flash(address) = tmp
        End If


        i = word - (tmp * 256)
        If i > 255 Or i < 0 Then
            ErrorDialog.ShowDialog()
        Else
            tmp = i
            Flash(address + 1) = tmp
        End If

        markblock(address)

    End Sub

    Public Sub WriteFlashByte(ByVal address As Integer, ByVal b As Integer)

        If b > 255 Or b < 0 Then
            ErrorDialog.ShowDialog()
        Else
            Flash(address) = b
        End If

        markblock(address)

    End Sub

    Public Sub WriteAddressOffset(ByVal address As Integer, ByVal location As Integer)

        Dim offset As Integer
        Dim hexString As String

        offset = (location - address) / 4
        hexString = String.Format("{0:x2}", offset)

        While hexString.Length < 8
            If offset > 0 Then
                hexString = "0" & hexString
            Else
                hexString = "F" + hexString
            End If
        End While

        WriteFlashByte(address + 1, Convert.ToByte(hexString.Substring(2, 2), 16))
        WriteFlashByte(address + 2, Convert.ToByte(hexString.Substring(4, 2), 16))
        WriteFlashByte(address + 3, Convert.ToByte(hexString.Substring(6, 2), 16))
        
    End Sub

    Public Function ReadFlashLongWord(ByVal address As Long)
        Dim tmp As Long
        tmp = ReadFlashWord(address)
        tmp = tmp * 65536
        tmp = tmp + ReadFlashWord(address + 2)

        Return tmp

    End Function

    Public Sub WriteFlashLongWord(ByVal address As Integer, ByVal longword As Int64)
        Dim i As Int64
        Dim a, b, c, d As Int64

        a = Int(longword / (&HFFFFFF + 1))
        WriteFlashByte(address, a)
        i = a * (&HFFFFFF + 1)
        i = longword - i
        b = Int(i / (&HFFFF + 1))
        WriteFlashByte(address + 1, b)
        i = (a * (&HFFFFFF + 1)) + (b * (&HFFFF + 1))
        i = longword - i
        c = Int(i / (&HFF + 1))
        WriteFlashByte(address + 2, c)
        i = (a * (&HFFFFFF + 1)) + (b * (&HFFFF + 1)) + (c * (&HFF + 1))
        i = longword - i
        d = Int(i)
        WriteFlashByte(address + 3, d)

        MarkBlock(address)

    End Sub

    Public Function Round(ByVal i As Integer) As String
        i = CInt(i / 10) * 10
        Return (Str(i))
    End Function

    Public Function Round5(ByVal i As Integer) As String
        i = CInt(i / 5) * 5
        Return (Str(i))
    End Function

    Private Sub MarkBlock(ByVal a As Long)
        '
        ' This function marks a block changed when doing any writes to flash
        '

        Dim b As Long
        b = Int(a / &H10000)

        Select Case b
            Case 0
                Block0 = True
            Case 1
                Block1 = True
            Case 2
                Block2 = True
            Case 3
                Block3 = True
            Case 4
                Block4 = True
            Case 5
                Block5 = True
            Case 6
                Block6 = True
            Case 7
                Block7 = True
            Case 8
                Block8 = True
            Case 9
                Block9 = True
            Case 10
                BlockA = True
            Case 11
                BlockB = True
            Case 12
                BlockC = True
            Case 13
                BlockD = True
            Case 14
                BlockE = True
            Case 15
                BlockF = True
            Case Else
                MsgBox("error in marking a block, programming may be unsuccesfull")
        End Select
    End Sub

    Public Function BlockChanged(ByVal b As Long) As Boolean

        ' This function is used to return true if the block has been changed
        Dim retval As Boolean

        retval = False

        If (b = 0) And (Block0) Then retval = True
        If (b = 1) And (Block1) Then retval = True
        If (b = 2) And (Block2) Then retval = True
        If (b = 3) And (Block3) Then retval = True
        If (b = 4) And (Block4) Then retval = True
        If (b = 5) And (Block5) Then retval = True
        If (b = 6) And (Block6) Then retval = True
        If (b = 7) And (Block7) Then retval = True
        If (b = 8) And (Block8) Then retval = True
        If (b = 9) And (Block9) Then retval = True
        If (b = 10) And (BlockA) Then retval = True
        If (b = 11) And (BlockB) Then retval = True
        If (b = 12) And (BlockC) Then retval = True
        If (b = 13) And (BlockD) Then retval = True
        If (b = 14) And (BlockE) Then retval = True
        If (b = 15) And (BlockF) Then retval = True

        Return retval

    End Function

    Public Sub ResetBlocks()
        '
        ' This sub is used for clearing all the block flags. E.g. after flashing or verify
        ' we know that this block has been flashed so it can be changed back to original
        '
        Block0 = False
        Block1 = False
        Block2 = False
        Block3 = False
        Block4 = False
        Block5 = False
        Block6 = False
        Block7 = False
        Block8 = False
        Block9 = False
        BlockA = False
        BlockB = False
        BlockC = False
        BlockD = False
        BlockE = False
        BlockF = False

    End Sub

    Public Sub HandleException(ByRef ex As Exception)

        MessageBox.Show("The following error occured, if this continues please report this error on the Hayabusa ECU Hacking Board http://www.activeboard.com/forum.spark?aBID=99460&subForumID=469024&p=2" & Environment.NewLine & Environment.NewLine & ex.Message & Environment.NewLine & ex.StackTrace, "Ecu Editor Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

#End Region

End Module
