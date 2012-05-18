;****************************************************************************
; COPYRIGHT(C) 2004 RENESAS TECHNOLOGY CORPORATION AND RENESAS SOLUTIONS
; CORPORATION ALL RIGHTS RESERVED
;
; start.ms : cc32R startup and low-level-sample program
;
;    [ Contents ]
;        (1) Sample startup routine.
;        (2) Stack memory area
;        (3) Sample low-level routine.
;        (4) Reset vector area
;
;    [ NOTES ]
;      * This startup sample never set addresses for all sections,
;        expect RI (Reset Vector Table) section, then you have to
;        set address by -SEC option by lnk32R (M32R linker) .
;
;****************************************************************************

;---------------------------------------------------------------------------
;  HEAPSIZE definition
;---------------------------------------------------------------------------
                .MACRO          HEAPSIZE_DEF
HEAPSIZE        .EQU            \&__HEAPSIZE__
                .ENDM
                HEAPSIZE_DEF

;---------------------------------------------------------------------------
;  STACKSIZE definition
;---------------------------------------------------------------------------
                .MACRO          STACKSIZE_DEF
USTACKSIZE      .EQU            \&__USTACKSIZE__
ISTACKSIZE      .EQU            \&__ISTACKSIZE__
                .ENDM
                STACKSIZE_DEF

;----------------------------------------------------------------------------
;                STANDARDLIB definition
;----------------------------------------------------------------------------
                .MACRO          STANDARDLIB_DEF
STANDARDLIB     .ASSIGNC        "\&__STANDARD_IO__"
                .ENDM
                STANDARDLIB_DEF

;---------------------------------------------------------------------------
;  (1) Startup routine
;---------------------------------------------------------------------------
                .export         STARTUP
                .export         HALT
                .AIF            \&STANDARDLIB
                .import         $_100_C_cpp_main
                .AELSE
                .import         $main
                .AENDI
                .import         __TOP_B, __END_B
                .import         __TOP_D, __END_D
                .import         __TOP_COMMON, __END_COMMON
                .import         __TOP_ROM_D, __END_ROM_D
                .section        P,code,align=4
                ;
                ; Initialize PSW control-register.
                ;
STARTUP:        LDI             R0, #128
                MVTC            R0, PSW
                ;
                ; Setting the user and interrupt stack.
                ;
                SETH            R0, #HIGH(USTACK_BOTTOM)
                OR3             R0, R0, #LOW(USTACK_BOTTOM)
                MVTC            R0, SPU
                SETH            R0, #HIGH(ISTACK_BOTTOM)
                OR3             R0, R0, #LOW(ISTACK_BOTTOM)
                MVTC            R0, SPI
                ;
                ; Clear the B section to zero.
                ;
                SETH            R0,#HIGH(__TOP_B)
                OR3             R0, R0, #LOW(__TOP_B)
                SETH            R1,#HIGH(__END_B)
                OR3             R1, R1, #LOW(__END_B)
                LDI             R2, #0
LOOP1:          CMP             R0, R1
                BNC             SKIP1
                STB             R2, @R0
                ADDI            R0, #1
                BRA             LOOP1
SKIP1:
                ;
                ; Clear the COMMON section to zero.
                ;
                SETH            R0,#HIGH(__TOP_COMMON)
                OR3             R0, R0, #LOW(__TOP_COMMON)
                SETH            R1,#HIGH(__END_COMMON)
                OR3             R1, R1, #LOW(__END_COMMON)
                LDI             R2, #0
LOOP2:          CMP             R0, R1
                BNC             SKIP2
                STB             R2, @R0
                ADDI            R0, #1
                BRA             LOOP2
SKIP2:
                ;
                ; Transfer the data in the ROM_D section in ROM area
                ; to the RAM area.
                ;
                SETH            R1, #HIGH(__TOP_ROM_D)
                OR3             R1, R1, #LOW(__TOP_ROM_D)
                SETH            R2, #HIGH(__TOP_D)
                OR3             R2, R2, #LOW(__TOP_D)
                SETH            R3, #HIGH(__END_ROM_D)
                OR3             R3, R3, #LOW(__END_ROM_D)
LOOP3:          CMP             R1, R3
                BNC             SKIP3
                LDB             R0, @R1
                STB             R0, @R2
                ADDI            R1, #1
                ADDI            R2, #1
                BRA             LOOP3
SKIP3:
                ;
                ; Jump to the C standard initialize routine.
                ;
                .AIF            \&STANDARDLIB
                SETH            R0, #HIGH($_100_C_cpp_main)
                OR3             R0, R0, #LOW($_100_C_cpp_main)
                JL              R0
                .AELSE
                SETH            R0, #HIGH($main)
                OR3             R0, R0, #LOW($main)
                JL              R0
                .AENDI
                ;
                ; End of program ( infinity loop )
                ;
HALT:           BRA             HALT

                .section        C,data,align=4
                .section        ROM_D,data,align=4
                .section        CTOR,data,align=4
                .section        VTBL,data,align=4

;---------------------------------------------------------------------------
;  (2) Sample low-level routine.
;---------------------------------------------------------------------------
                .export         $_exit
                .export         $_get_core
                .export         $write
                .export         $_rel_core
                .export         $_strerror
                .export         $close
                .export         $getuniqnum
                .export         $lseek
                .export         $open
                .export         $read
                .export         $getenv
                .export         $raise
                .export         $remove
                .section        P,code,align=4
                ;
                ; Terminate the program run.
                ;
$_exit:         BRA             HALT
                ;
                ; Get the heap memory routine.
                ;
$_get_core:     MV              R1, R4
                SETH            R2, #HIGH(HEAP_POINTER)
                OR3             R2, R2, #LOW(HEAP_POINTER)
                LD              R0, @R2
                ADD             R1, R0
                ST              R1, @R2
                JMP             R14
                ;
                ; ( Not implemented routine )
                ;
$write:
$_rel_core:
$_strerror:
$close:
$getuniqnum:
$lseek:
$open:
$read:
$getenv:
$raise:
$remove:        LDI             R0, #0
                JMP             R14

;---------------------------------------------------------------------------
;  (3) Heap and stack memory area
;---------------------------------------------------------------------------
                .section        D,data,align=4
HEAP_POINTER:   .DATA.W         HEAP_TOP

                .section        B,data,align=4
HEAP_TOP:
                .RES.B          HEAPSIZE

                .RES.B          USTACKSIZE
USTACK_BOTTOM:
                .RES.B          ISTACKSIZE
ISTACK_BOTTOM:

;---------------------------------------------------------------------------
;  (4) Reset vector area
;---------------------------------------------------------------------------
                .section        RI,code,locate=h'00000000
                SETH            R0, #HIGH(STARTUP)
                OR3             R0, R0, #LOW(STARTUP)
                JMP             R0

                .end            STARTUP

;****************************************************************************
; COPYRIGHT(C) 2004 RENESAS TECHNOLOGY CORPORATION AND RENESAS SOLUTIONS
; CORPORATION ALL RIGHTS RESERVED
;****************************************************************************

