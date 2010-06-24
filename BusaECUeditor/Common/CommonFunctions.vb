Module CommonFunctions

#Region "Variables"

    Public Const _timerInterval As Integer = 250
    Public Const _maxDataLog As Integer = 4000

    Public _rpm As Integer
    Public _tps As Integer
    Public _iap As Integer 'ambient - intake air pressure
    Public _oxy As Integer
    Public _clt As Integer
    Public _usr1 As Integer 'user can define this 1variable to be monitored
    Public _ramVarUsr1 As Integer ' index of the USR1 variable within RAM
    Public _fuel As Integer
    Public _airPressure As Integer ' Air pressure
    Public _intakeAirPressure As Integer 'intake air pressure
    Public _ign As Integer
    Public _duty As Integer
    Public _afr As Integer
    Public MS As Integer
    Public NT As Integer
    Public CLUTCH As Integer
    Public PAIR As Integer
    Public MODE As Integer
    Public GEAR As Integer
    Public HO2 As Integer
    Public BATT As Integer
    Public STP As Integer
    Public IAT As Integer
    Public SAPabs As Integer
    Public IAPabs As Integer
    Public BOOST As Integer
    Public DSM1 As Boolean

    Public looperrorcodes As Integer
    Public block_pgm As Boolean
    Public block0, block1, block2, block3, block4, block5, block6, block7, block8, block9, blockA, blockB, blockC, blockD, blockE, blockF As Boolean

    Public cc As Integer
    Public rr As Integer
    Public icc As Integer
    Public irr As Integer

    Public readprocessongoing As Boolean
    Public fuelmapvisible As Boolean
    Public Ignitionmapvisible As Boolean
    Public innovatevisible As Boolean

    Public Flash(262144 * 4) As Byte
    Public FlashCopy(262144 * 4) As Byte
    Public Adjustmap(9 * 9)
    Public config_bytes(256) As Integer

    Public mapaddr_1 As Integer
    Public mapaddr_2 As Integer
    Public mapaddr_3 As Integer
    Public mapaddr_4 As Integer
    Public maprows As Integer
    Public mapcolumns As Integer
    Public rowselected As Integer
    Public mapvisible As String

    Public ignmapaddr_A As Integer
    Public ignmapaddr_B As Integer
    Public ignmaprows As Integer
    Public ignmapcolumns As Integer
    Public ignrowselected As Integer
    Public ignmapvisible As String

    Public datalog(CInt(1000 / timerinterval * maxdatalog), 16) As Integer
    Public datalogpointer As Integer
    Public dataloglenght As Integer

    Public metric As Boolean
    Public ECUversion As String ' either gen1 or gen2 indicating which ecu version is under modification

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

    Public Property AirPressure()
        Get
            Return _airPressure
        End Get
        Set(ByVal value)
            _airPressure = value
        End Set
    End Property

    Public Property IntakeAirPressure() As Integer
        Get
            Return _intakeAirPressure
        End Get
        Set(ByVal value As Integer)
            _intakeAirPressure = value
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
#End Region

#Region "Functions"

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

        If f > 5 Then
            istr = Format(f, "###")
        Else
            istr = Format(f, "#0.#")
        End If

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
        End Select

        If i < 0 Or i > maxi Then
            ErrorDialog.ShowDialog()
        Else
            tmp = Flash(i)
        End If

        Return (tmp)

    End Function

    Public Function ReadFlashBytecopy(ByVal i As Integer) As Integer
        Dim tmp As Integer
        Dim maxi As Integer

        Select Case ECUversion
            Case "gen1"
                maxi = 262144 - 1
            Case "gen2"
                maxi = (4 * 262144) - 1
            Case "bking"
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

        markblock(address)

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
                block0 = True
            Case 1
                block1 = True
            Case 2
                block2 = True
            Case 3
                block3 = True
            Case 4
                block4 = True
            Case 5
                block5 = True
            Case 6
                block6 = True
            Case 7
                block7 = True
            Case 8
                block8 = True
            Case 9
                block9 = True
            Case 10
                blockA = True
            Case 11
                blockB = True
            Case 12
                blockC = True
            Case 13
                blockD = True
            Case 14
                blockE = True
            Case 15
                blockF = True
            Case Else
                MsgBox("error in marking a block, programming may be unsuccesfull")
        End Select
    End Sub

    Public Function BlockChanged(ByVal b As Long) As Boolean

        ' This function is used to return true if the block has been changed
        Dim retval As Boolean

        retval = False

        If (b = 0) And (block0) Then retval = True
        If (b = 1) And (block1) Then retval = True
        If (b = 2) And (block2) Then retval = True
        If (b = 3) And (block3) Then retval = True
        If (b = 4) And (block4) Then retval = True
        If (b = 5) And (block5) Then retval = True
        If (b = 6) And (block6) Then retval = True
        If (b = 7) And (block7) Then retval = True
        If (b = 8) And (block8) Then retval = True
        If (b = 9) And (block9) Then retval = True
        If (b = 10) And (blockA) Then retval = True
        If (b = 11) And (blockB) Then retval = True
        If (b = 12) And (blockC) Then retval = True
        If (b = 13) And (blockD) Then retval = True
        If (b = 14) And (blockE) Then retval = True
        If (b = 15) And (blockF) Then retval = True

        Return retval

    End Function

    Public Sub ResetBlocks()
        '
        ' This sub is used for clearing all the block flags. E.g. after flashing or verify
        ' we know that this block has been flashed so it can be changed back to original
        '
        block0 = False
        block1 = False
        block2 = False
        block3 = False
        block4 = False
        block5 = False
        block6 = False
        block7 = False
        block8 = False
        block9 = False
        blockA = False
        blockB = False
        blockC = False
        blockD = False
        blockE = False
        blockF = False

    End Sub

#End Region

End Module
