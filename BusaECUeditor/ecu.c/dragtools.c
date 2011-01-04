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
#define ECU_RPM *(volatile unsigned short *)  			0x0080502E
#define TML1CT *(volatile unsigned long *)				0x00800FE0 // timer, only upper word counting

/*
	The programmer installer removes SAP_ignition compensation from sub_33C00 and replaces that with ign retard from this program.
*/
#define ECU_SAP_IAT_ignition_compensation *(volatile unsigned char *)	0x008063C7


/*
	Internal variables for this subroutine only, these are borrowed from the ecu ram area using addresses
	that are considered not having been assigned for any use.
*/
#define ramaddr 										0x00806800 // This is the starting address for free ram area needed for this program
/* 00 - 0x16 reserved for shifter */
/* 0x18 - 0x60 reserved for boostfuel and nitrous control */
/* 0x64 - 0x6F reserved for gen2tools */
/* 0x70 - reserved for dragtools */
#define	counter *(volatile unsigned short *)  		(ramaddr + 0x70)
#define	timer_old *(volatile unsigned long *)  		(ramaddr + 0x74)
#define	rpm_old *(volatile unsigned short *)  		(ramaddr + 0x78)
#define	rpm_tmp *(volatile unsigned short *)  		(ramaddr + 0x7C)
#define	timer_diff *(volatile unsigned short *)  	(ramaddr + 0x80)
#define	rpm_diff *(volatile unsigned short *)  		(ramaddr + 0x84)
#define	rpm_now *(volatile unsigned short *)  		(ramaddr + 0x88)
#define	rpm_rate *(volatile unsigned short *)  		(ramaddr + 0x8C)
#define	ign_retard *(volatile unsigned char *)  	(ramaddr + 0x90)

#pragma SECTION C PARAMS //0x5A000
const short const_pgmid = 				100;			// 0 program id, must match to ecueditor version to be able to load this code to ecu
const short GEAR1_RATE = 0x2300;
const short GEAR2_RATE = 0x2200;
const short GEAR36_RATE = 0x2000;
const short GEAR1_RETARD = 5;
const short GEAR2_RETARD = 2;
const short GEAR36_RETARD = 1;
const short ACTIVATION = 0x3200;

#define divider 0x64									// this is the amount of cycles that is used for calculatting average RPM

#pragma SECTION P TOOLSCODE //0x5A100
void toolsmain(void)
{
/*
	Here is the main program. 
*/

counter = counter + 1;
if (counter <= divider) 
{
	rpm_tmp = rpm_tmp + (ECU_RPM / divider) ;
	
}
else
{
	ign_retard = ECU_SAP_IAT_ignition_compensation;
	rpm_now = rpm_tmp;
	rpm_tmp = 0;
	counter = 0;
	
	if ((TML1CT > timer_old) & (ECU_RPM > ACTIVATION) & (rpm_now > rpm_old))
	{
		timer_diff = (((TML1CT - timer_old) & 0xFFFF) >> 8); 
		rpm_diff = rpm_now - rpm_old;
		rpm_rate = ((rpm_diff << 8)  / timer_diff); // this needs to be calculated to rpm/s value, a little bit unsure
	}
	else
	{
		rpm_rate = 0;
	}	
	
	rpm_old = rpm_now;
	timer_old = TML1CT; 
		
	if (ECU_GPS == 1)	  // Gear 1
		{
			if (rpm_rate > GEAR1_RATE)
				{
					ign_retard = ((ECU_SAP_IAT_ignition_compensation + (((rpm_rate - GEAR1_RATE)/256) * GEAR1_RETARD)) & 0xFF);
				}
		}
	else if (ECU_GPS == 2) // Gear 2
		{
			if (rpm_rate > GEAR2_RATE)
				{
					ign_retard = ((ECU_SAP_IAT_ignition_compensation + (((rpm_rate - GEAR2_RATE)/256) * GEAR2_RETARD)) & 0xFF);
				}
			
		}
	else if (ECU_GPS > 2) // Gear 3-6
		{
			if (rpm_rate > GEAR36_RATE)
				{
					ign_retard = ((ECU_SAP_IAT_ignition_compensation + (((rpm_rate - GEAR36_RATE)/256) * GEAR36_RETARD))  & 0xFF);
				}
			
	
		}
	
	
}

/*
	This is inline assembly put at the end of the code that returns control back to main loop in the ecu code.
*/
#pragma keyword asm on
	asm(
	" jmp R14 \n"
	);

}

