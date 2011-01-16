/*

	gen2tools.c
	
    This file is part of ecueditor.com

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

	SIO2, TXD2 is connecte to P17, bit4. Normally that pin sends out the gaugedata to hayabusa gauge cluster
	anyhow this program just sets it low / high when errorcode is present.
	
	v1.01, testing for removing the gear on setting an errorcode
	
*/

#define ECU_FI *(volatile unsigned char *)  			0x00806784
#define ECU_KWPDTC1 *(volatile unsigned char *)  		0x00806786
#define ECU_KWPDTC2 *(volatile unsigned char *)  		0x00806787
#define ECU_KWPDTC3 *(volatile unsigned char *)  		0x00806788
#define ECU_KWPDTC4 *(volatile unsigned char *)  		0x00806789
#define ECU_KWPDTC5 *(volatile unsigned char *)  		0x0080678A
#define ECU_KWPDTC6 *(volatile unsigned char *)  		0x0080678B

#define ECU_PORT2 *(volatile unsigned char *)  		0x00804860

#define PORT1   *(volatile unsigned char *)  				0x00800701 // bit5 = PAIR

#define P17DATA   *(volatile unsigned char *)  				0x00800711 // bit4 = TXD2 
#define P17MOD   *(volatile unsigned char *)  				0x00800751
#define P17SMOD   *(volatile unsigned char *)  				0x00800771
#define P17DIR   *(volatile unsigned char *)  				0x00800731

#define ECU_RPM *(volatile unsigned short *)  			0x0080502E // tested to work

#define PAIR						0x20
#define TXD2						0x8		
#define CLUTCH_ON       0x80

#define ramaddr             										0x00806800 
#define i        *(volatile unsigned char *)  	(ramaddr + 0x94)


#pragma SECTION C PARAMS //0x59DC0
const short const_pgmid = 				102;			// 0 program id, must match to ecueditor version to be able to load this code to ecu
const char FI_LED_no_gauges = 			0;
const short clutched_rpm = 0x1400;
const short top_rpm = 0x7800;

#pragma SECTION P TOOLSCODE //0x59E00
void toolsmain(void)
{

if ((P17MOD & TXD2) != 0)
{
	P17MOD = P17MOD & (0xFF - TXD2);		// Set as port P174 of TXD2
	P17DIR = P17DIR | TXD2;					// Set port 17 TXD2 bit to output
}

/*
      
  This sets the port on if clutch is depressed and RPM above threshold    
      
*/
if ((ECU_PORT2 & CLUTCH_ON )  != 0)
{
	if (ECU_RPM > clutched_rpm)
	{
		P17DATA = P17DATA & (0xFF - TXD2);
	}
	else
	{
		P17DATA = P17DATA | TXD2;		
	}
}

/*
      
   This sets the port on if RPM above threshold
      
*/
if ((ECU_PORT2 & CLUTCH_ON )  != 0)
{
	if (ECU_RPM > top_rpm)
	{
		P17DATA = P17DATA & (0xFF - TXD2);
	}
	else
	{
		P17DATA = P17DATA | TXD2;		
	}
}


/*
	This algorithm sets the port to +5V when errorcode present in ecu
	Masked those bits which are present with C00 anyway
	variable i makes the errorcode to blink
*/

i=i+1;
if (i > 500) 
{
  if (FI_LED_no_gauges == 0)
    {
	    if (((ECU_KWPDTC1 & (0xFF - 0xFF))== 0) &&  // first element is TST switch and  TPS _C00 setting
		     ((ECU_KWPDTC2 & (0xFF - 0x80))== 0)  && // unknown flag ???	
		      ((ECU_KWPDTC3 & (0xFF - 0x00))== 0)  && 	
		      ((ECU_KWPDTC4 & (0xFF - 0x00))== 0)  &&
		      ((ECU_KWPDTC5 & (0xFF - 0xE0))== 0)  &&	// remove gears as errors
		      ((ECU_KWPDTC6 & (0xFF - 0x07)) == 0))	// remove ABC display as error
	      {
		      P17DATA = P17DATA & (0xFF - TXD2);
	      }
	    else
	      {
		      P17DATA = P17DATA | TXD2;		
	      }
    } 
}
if (i>1000) 
{
  i=0;
}


/*
	This is inline assembly put at the end of the fuelcut code that returns control back to main loop in the ecu code.
*/
#pragma keyword asm on
	asm(
	" jmp R14 \n"
	);

}
