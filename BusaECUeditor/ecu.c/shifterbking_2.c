/*

	shiftergen2.c
	
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

	v1.00 first release for Hayabusa gen1
	v1.01 added igncut and fuelcut const flags that can be set and pair output code
	v2.00 changed to Hayabusa gen2 only, removed pair functionality and ignitioncut only for initial gen2 release
	v2.01 lowest rpm when kill possible is now 2000rpm and only 500revs is needed before next kill
	
*/

/*
	These are the RAM variable addresses that are internal to this subroutine
*/
#define ECU_AD_GPS *(volatile unsigned short *)  		0x00804318 // 804318 tested to work with 220 ohm resistor
#define ECU_GPS	*(volatile unsigned char *)  			0x008050B3 // 8050B3
#define ECU_RPM *(volatile unsigned short *)  			0x00804FB2 // 804FB2 tested to work
#define ECU_KillFlag *(volatile unsigned char *)  		0x008064CF // 8064CF BKing fuelcut - tested to work
#define IGN_KillFlag *(volatile unsigned char *)  		0x00806321 // 806321 BKing ignitioncut - tested to work

/*
	Internal variables for this subroutine only, these are borrowed from the ecu ram area using addresses
	that are considered not having been assigned for any use.
*/
#define ramaddr 										0x00806800 			
#define killcount *(volatile unsigned short *)    		(ramaddr)			// 806800
#define killswitch *(volatile unsigned short *)   		(ramaddr + 4)		// 806804
#define killcountactive *(volatile unsigned short *) 	(ramaddr + 8)		// 806808
#define initialized *(volatile unsigned short *)  		(ramaddr + 12)		// 80680C
#define killflag *(volatile unsigned short *)  			(ramaddr + 16)		// 806810
#define	duration_kill *(volatile unsigned short *)  	(ramaddr + 20)		// 806814
#define	previousgear *(volatile unsigned short *)  		(ramaddr + 0x64)	// 806864

/*
	The shift kill variables are defined here, e.g kill times. These are adjusted using ecueditor.
*/
#pragma SECTION C PARAMS //0x58400
const short const_pgmid = 				203;	// 0  58400 program id, must match to ecueditor version to be able to load this code to ecu
const short const_killtime_gear1 = 		65;		// 2  58402 kill times, these are egnie revolutions for the rpm range
const short const_killtime_gear2 = 		65;		// 4  58404
const short const_killtime_gear3 = 		65;		// 6  58406
const short const_killtime_gear4 = 		65;		// 8  58408
const short const_killtime_gear5 = 		65;		// 10 5840A
const short const_killtime_gear6 = 		65;		// 12 5840C
const short const_killtime_x = 			0x0;	// 14 5840E
const short const_killtime_y = 			0x0;	// 16 58410
const short const_killtime_z = 			0x0;	// 18 58412
const short const_killtime_c = 			0x0; 	// 20 58414
const short minkillactive = 			5;   	// 22 58416 hysteresis for how many revolutions the gps must be active before a kill is initiated
const short killcountdelay = 			500;	// 24 58418 delay of revolutions how many times must pass from last kill before a kill can be initiated again
const short fuelkillactive = 			1;		// 26 5841A igncut will be used, this can be changed by ecueditor to 0 to disable fuelcut
const short ignkillactive = 			1;		// 28 5841C fuelcut will be used, this can be changed by ecueditor to 0 to disable igncut
const short killtimedivider = 			2560;	// 30 5841E

/*
	Constants 
*/ 
#define ACTIVE 							1			/* internal const for the program */
#define DEACTIVE 						0			/* internal const for the program */
#define CUTACTIVE 						0x3			/* Bitflag for setting the cut active for ecu fuelcut variable, both soft and harduct */
#define SHIFTERACTIVE 					0x40		/* This is the internal voltage limit for 200Ohm resistor that is used to detect that shifter is active */

/*
	The fuelcut code, the program enters here each fuel calculation loop after calculating the limiters but before calculating the amount of fuel
*/
#pragma SECTION P SHIFTERCODE // 58450
void shiftermain(void)
{
	/*
		First time only initialization of internal variables. Ram is inizialized to zero values after hw boot. assumed as its in gen1 so.
	*/		
 	if (initialized != 1)
  	{
		killflag = DEACTIVE;
   		killswitch = DEACTIVE;
   		killcountactive = DEACTIVE;
   		initialized = 1;
		killcount = killcountdelay;
  	}

	/*
		As the each cycle this program is run is twice on every revolution we need to adjust the kill time
		to be multiplied by rpm. ECU_RPM / 2.56 is the real rpm.
	*/		
    if((ECU_AD_GPS >> 2)  <=  SHIFTERACTIVE)
 	{
		if (ECU_RPM > 0x1400)
		{
			killswitch = ACTIVE;
	
			if (previousgear == 1)
			{
				duration_kill = (const_killtime_gear1 * (ECU_RPM >> 2)) / killtimedivider;
			}
			else if (previousgear == 2)
			{
				duration_kill = (const_killtime_gear2 * (ECU_RPM >> 2)) / killtimedivider;
			}
			else if (previousgear == 3)
			{
				duration_kill = (const_killtime_gear3 * (ECU_RPM >> 2)) / killtimedivider;
			}
			else if (previousgear == 4)
			{
				duration_kill = (const_killtime_gear4 * (ECU_RPM >> 2)) / killtimedivider;
			}
			else if (previousgear == 5)
			{
				duration_kill = (const_killtime_gear5 * (ECU_RPM >> 2)) / killtimedivider;
			}
			else	// default killtime is gear 6 time
			{
				duration_kill = (const_killtime_gear6 * (ECU_RPM >> 2)) / killtimedivider;
			}
		}
 	}
 	else
 	{
  		killswitch = DEACTIVE;
	}

	/*
		Main logic for processing fuel/ignitionkill function.
	*/
 	if(killflag == ACTIVE)
 	{
		/*
		Hold the killflag active until minimum duration of kill time is reached.
		When reaching the duration of kill time set kill deactive and set killcount
		to delay calculation mode that must be reached before next kill initialization. 
		*/
     	killcount += 1;

     	if(killcount >= duration_kill)
     	{
         	killflag = DEACTIVE;
         	killcount = killcountdelay; 
     	}
 	}
 	else                          
 	{
     	if(killcount > 0)
     	{
			/*
				Killswitch delay calculation mode, count from killcountdelay backwards
				waiting for the next killswitch cycle. The delay is calculated only 
				when killswitch is not depressed.
			*/
         	if(killswitch != ACTIVE)  
         	{
             	killcount -= 1 ;
         	}
     	}
     	else                   
     	{
			/*
				Killcount is zero, a new kill cycle can be initialized.
			*/
         	if(killswitch == ACTIVE)
         	{
             	killcountactive += 1;
             	
				/* 
				If minimum killflag active time reached then activate kill
				and reset the killswitch counter back to zero.
				*/
				if(killcountactive >= minkillactive)
			 	{
					killflag = ACTIVE;
					killcount = 0;
				}
         	}
         	else
         	{
				killcountactive = DEACTIVE;  
				
				/*
					Only set previousgear when you know that the GPS has stabilized enough after previous kill cycle
				*/
				previousgear = ECU_GPS;
         	}
     	}
 	}

	/*
		Use fuelcut only if parametrized to do so.
		Set the fuelkill on if KillFlag indicates that kill is active.
	*/		
	if(fuelkillactive == ACTIVE)
	{
		if(killflag == ACTIVE) 
		{
			ECU_KillFlag = ECU_KillFlag | CUTACTIVE; 
		}
	}

/*
	This is inline assembly put at the end of the fuelcut code that returns control back to main loop in the ecu code.
*/
#pragma keyword asm on
	asm(
	" addi sp, #16 \n"
	" jmp R14 \n"
	);
}

/*
	Use igncut only if parametrized to do so.
	Set the ignitionkill on if KillFlag indicates that kill is active.
*/		
#pragma SECTION P IGNCODE // 58700
void ignmain(void)
{
	if(ignkillactive == ACTIVE)
	{
		if(killflag == ACTIVE) 
		{
			IGN_KillFlag = IGN_KillFlag | CUTACTIVE; 
		}
	}

/*
	This is inline assembly put at the end of the fuelcut code that returns control back to main loop in the ecu code.
*/
#pragma keyword asm on
	asm(
	" addi sp, #16 \n"
	" jmp R14 \n"
	);
}