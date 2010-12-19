/*

	dragtools.c
	
    This file is part of BusaECUeditor - Hayabusa ECUeditor

    Hayabusa ECUeditor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Hayabusa ECUeditor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Hayabusa ECUeditor.  If not, see <http://www.gnu.org/licenses/>.

    Notice: Please note that under GPL if you use this program or parts of it
    you are obliged to distribute your software including source code
    under this same license for free. For more information see paragraph 5
    of the GNU licence.


*/

/*
	These are the RAM variable addresses that are internal to this subroutine
*/
#define ECU_AD_GPS *(volatile unsigned short *)  		0x00804318 // tested to work with 220 ohm resistor
#define ECU_GPS	*(volatile unsigned char *)  			0x008050B3
#define ECU_RPM *(volatile unsigned short *)  			0x0080502E // tested to work
#define ECU_KillFlag *(volatile unsigned char *)  		0x00806557 // 0x00806557, fuelcut - tested to work
#define IGN_KillFlag *(volatile unsigned char *)  		0x008063A9 // 0x008063A9, ignitioncut - tested to work
#define PORT3   *(volatile unsigned char *)  			0x00804862 // bit0=DSM2, bit1=DSM1

#define ECU_FI *(volatile unsigned char *)  			0x00806784
#define ECU_KWPDTC1 *(volatile unsigned char *)  		0x00806786
#define ECU_KWPDTC2 *(volatile unsigned char *)  		0x00806787
#define ECU_KWPDTC3 *(volatile unsigned char *)  		0x00806788
#define ECU_KWPDTC4 *(volatile unsigned char *)  		0x00806789
#define ECU_KWPDTC5 *(volatile unsigned char *)  		0x0080678A
#define ECU_KWPDTC6 *(volatile unsigned char *)  		0x0080678B



/*
	Internal variables for this subroutine only, these are borrowed from the ecu ram area using addresses
	that are considered not having been assigned for any use.
*/
#define ramaddr 										0x00806800 // This is the starting address for free ram area needed for this program
#define killcount *(volatile unsigned short *)    		(ramaddr)
#define killswitch *(volatile unsigned short *)   		(ramaddr + 4)
#define killcountactive *(volatile unsigned short *) 	(ramaddr + 8)
#define initialized *(volatile unsigned short *)  		(ramaddr + 12)
#define killflag *(volatile unsigned short *)  			(ramaddr + 16)

/* +0x18 - 0x60 reserved for boostfuel and nitrous control */

#define	previousgear *(volatile unsigned short *)  		(ramaddr + 0x64)
#define	overboost *(volatile unsigned char *)  			(ramaddr + 0x64 + 4) /* this is a joint variable with turbofuel module */
#define	duration_kill *(volatile unsigned short *)  	(ramaddr + 0x64 + 8)
#define	minimum_killrpm *(volatile unsigned short *)  		(ramaddr + 0x64 + 12)




#define PORT1   *(volatile unsigned char *)  				0x00800701 // bit5 = PAIR

#define P17DATA   *(volatile unsigned char *)  				0x00800711 // bit4 = TXD2 
#define P17MOD   *(volatile unsigned char *)  				0x00800751
#define P17SMOD   *(volatile unsigned char *)  				0x00800771
#define P17DIR   *(volatile unsigned char *)  				0x00800731

#define BOOSTACTIVE *(volatile unsigned char *)  		0x00055800
#define PAIR						0x20
#define TXD2						0x8		


#pragma SECTION C PARAMS //0x59DC0
const short const_pgmid = 				100;			// 0 program id, must match to ecueditor version to be able to load this code to ecu
const char FI_LED_no_gauges = 			0;

#pragma SECTION P TOOLSCODE //0x59E00
void toolsmain(void)
{

if ((P17MOD & TXD2) != 0)
{
	P17MOD = P17MOD & (0xFF - TXD2);		// Set as port P174 of TXD2
	P17DIR = P17DIR | TXD2;					// Set port 17 TXD2 bit to output
}

/*
	This algorithm sets the port to +5V when errorcode present in ecu
	Masked those bits which are present with C00 anyway
*/
if (FI_LED_no_gauges == 0)
{
	if (((ECU_KWPDTC1 & (0xFF - 0xFF))== 0) &&  // first element is TST switch and  TPS _C00 setting
		((ECU_KWPDTC2 & (0xFF - 0x80))== 0)  && // unknown flag ???	
		((ECU_KWPDTC3 & (0xFF - 0x00))== 0)  && 	
		((ECU_KWPDTC4 & (0xFF - 0x00))== 0)  &&
		((ECU_KWPDTC5 & (0xFF - 0xE0))== 0)  &&	// remove gears as errors
		((ECU_KWPDTC6 & (0xFF - 0x00)) == 0))	
	{
		P17DATA = P17DATA & (0xFF - TXD2);
	}
	else
	{
		P17DATA = P17DATA | TXD2;		
	}
}

/*
	This is inline assembly put at the end of the fuelcut code that returns control back to main loop in the ecu code.
*/
#pragma keyword asm on
	asm(
	" jmp R14 \n"
	);

}

