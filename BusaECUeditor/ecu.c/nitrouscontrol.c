/*

	nitrouscontrol.c
	
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

	v1.00 first release for Hayabusa gen2, includes GM3 bar sensor conversion tables
	
*/

/*
	These are the RAM variable addresses that are internal to this subroutine
*/
#define ECU_IAP *(volatile unsigned short *)  				0x008042F0 
#define ECU_INJVOLT *(volatile unsigned short *)  			0x008042DA
#define ECU_SAP *(volatile unsigned short *)  				0x008042EE
#define ECU_TPS *(volatile unsigned short *)  				0x008042EC
#define ECU_RPM *(volatile unsigned short *)  				0x0080502E 
#define ECU_FI *(volatile unsigned char *)  				0x00806784
#define ECU_HOX *(volatile unsigned char *)  				0x00805085
#define ECU_COV1 *(volatile unsigned char *)  				0x00805442
#define ECU_GPS	*(volatile unsigned char *)  				0x008050B3
#define P8DIR	 *(volatile unsigned char *)  				0x00800728
#define P8DATA	 *(volatile unsigned char *)  				0x00800708
#define ECU_MODE *(volatile unsigned char *)  				0x008050D5
#define PORT1   *(volatile unsigned char *)  				0x00800701 // bit5=PAIR
#define ECU_IGNRETARD *(volatile unsigned char *)  			0x008063A2
#define PORT3   *(volatile unsigned char *)  				0x00804862 // bit0=DSM2, bit1=DSM1

#define P8bit	*(volatile unsigned char *)					0x20
#define ModeA						0x0
#define ModeB						0x1
#define ModeC						0x2
#define DSM2						0x1
#define DSM1						0x2
#define PAIR						0x20


/*
	Internal variables for this subroutine only, these are borrowed from the ecu ram area using addresses
	that are considered not having been assigned for any use.
	
	area between 00806800-00806820 is used shifter2gen.bin
	
*/
#define ramaddr 										0x00806800 // This is the starting address for free ram area for user programs
// note +24dec, 0x18 is first free address
#define killflag 		*(volatile unsigned char *)		(ramaddr + 16) // this is a shifter variable that we may want to use
#define	ECU_COV1REUSED	*(volatile unsigned char *)  	(ramaddr + 0x18) // +24dec would be  is first free address, before that shifter code uses the addresses
#define	IAP_8bit 		*(volatile unsigned char *)  	(ramaddr + 0x1A) 
#define	LR				*(volatile unsigned char *) 	(ramaddr + 0x1C) 
#define	BENR			*(volatile unsigned char *) 	(ramaddr + 0x20) 
#define	PRESSURE		*(volatile unsigned char *) 	(ramaddr + 0x24) 
#define	GAUGECOPY		*(volatile unsigned char *) 	(ramaddr + 0x28) 
#define	ECU_AN15		*(volatile unsigned short *) 	(ramaddr + 0x2A) 
#define counter			*(volatile unsigned short *) 	(ramaddr + 0x2E) 
#define duty			*(volatile unsigned short *) 	(ramaddr + 0x30) 
#define nitrousactive	*(volatile unsigned short *) 	(ramaddr + 0x34) 
#define fueladd			*(volatile unsigned char *) 	(ramaddr + 0x38) 
#define threshold		*(volatile unsigned short *) 	(ramaddr + 0x4C) 
#define DSMbuttonpressed *(volatile unsigned short *) 	(ramaddr + 0x50) 
#define ignretard		 *(volatile unsigned char *) 	(ramaddr + 0x54) 
#define igncomp		 	 *(volatile unsigned char *) 		(ramaddr + 0x56) 
#define lastgear		 *(volatile unsigned char *) 		(ramaddr + 0x58) 
#define switchover		 *(volatile unsigned short *) 		(ramaddr + 0x5A) 
#define transition		 *(volatile unsigned char *) 		(ramaddr + 0x5C) 
#define initialized 	*(volatile unsigned char *) 	(ramaddr + 0x5E) 
#define rpg 	        *(volatile unsigned short *) 	(ramaddr + 0x60) 

/*
	The shift kill variables are defined here, e.g kill times. These are adjusted using ecueditor.
*/
#pragma SECTION C PARAMS //0x55800
const unsigned short const_pgmid = 				209;			// program id, must match to ecueditor version to be able to load this code to ecu
const unsigned short minrpm =					0x5000;			// 8000rpm
const unsigned short maxrpm = 					0x6E00;			// 11000rpm
const unsigned short mintps =					0x0340;			// appr 95% TPS
const unsigned short fuel_delay =				200;			// 
#define dcounter 								0x19			// divisor for AD conversion cycles to 10Hz
const unsigned short const10hz = 				dcounter;
const unsigned short dutyerr = 					(dcounter * 0/100); 
const unsigned char	 wetkitemulation =			0x0;
const unsigned char	 buttonactive =				0xFF;
const unsigned char	 DSMSELECTED =				DSM2;

#pragma SECTION C PDUTY //0x559A0
const unsigned short dutygear1 = 				0; 
const unsigned short dutygear2 = 				50; 
const unsigned short dutygear3 = 				60; 
const unsigned short dutygear4 = 				70; 
const unsigned short dutygear5 = 				80; 
const unsigned short dutygear6 = 				100; 
const unsigned short fueladdgear1 =				0;
const unsigned short fueladdgear2 =				12;
const unsigned short fueladdgear3 =				25;
const unsigned short fueladdgear4 =				25;
const unsigned short fueladdgear5 =				25;
const unsigned short fueladdgear6 =				40;
const unsigned short ignretardgear1 =			0;
const unsigned short ignretardgear2 =			5;
const unsigned short ignretardgear3 =			5;
const unsigned short ignretardgear4 =			10;
const unsigned short ignretardgear5 =			10;
const unsigned short ignretardgear6 =			10;
const unsigned short rampupgear1 =				0;
const unsigned short rampupgear2 =				0;
const unsigned short rampupgear3 =				0;
const unsigned short rampupgear4 =				0;
const unsigned short rampupgear5 =				0;
const unsigned short rampupgear6 =				0;
const unsigned short rampupdivisor = 			4;

/*
	Constants 
*/ 
#define TTT							1			/* internal const for the program */
#define FFF 						0			/* internal const for the program */
#define TRUE						1			/* internal const for the program */
#define FALSE 						0			/* internal const for the program */

/*
	This is the main programming loop. Its thrown to be executed at the end of the AD conversion loop. This way when ever
	the AD values are read then also the boostfuel value is updated. Additionally cylinder specific fuel caluclations
	needs to be changed so that the results of this calculation is included in fuel calculations.
*/ 



#pragma SECTION P NITROUSCONTROL //0x55A00
void boostfuelmain(void)
{

/*
	Initialize variables for each loop
*/
nitrousactive = FALSE;


/*
	Duty cycle solenoid control. Routine runs at every AD conversion loop.
*/

if (initialized == 0)							// if not initialized then configure port as output
	{
		initialized = 0xFF;
		switchover = 0;
		lastgear=0;
		counter = 0;
	}
	

counter = counter + 1;
if (counter >= dcounter)						// run duty cycle counter at 10Hz
	{ 
			counter = 0;
	}
	
/*
	Lets set the duty cycle for nitrous solenoid and calculate additional fuel needed
*/ 
duty = dutyerr;		//in any case use this value
ignretard = 0;
if (ECU_GPS == 0)
	{
			duty =      0;
			fueladd =   0;
			ignretard = 0;
			switchover = 0;
	}
else if (ECU_GPS == 1) 		
	{
		/* Nitrous rampup and fuel delay algorithm, this is sample first gear algorithm */
		
		rpg=rampupgear1;
		if (rpg != 0)
		{
			if ((lastgear < ECU_GPS))
				{	// reset switchover algoritm on each gear change
					lastgear = ECU_GPS;
					switchover = 0;
				}
			else 
				{	// rampup is active after gear change start counting switchiover up to maximum rampover
					// old: if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (ECU_RPM > minrpm) && (ECU_RPM < maxrpm) && (ECU_TPS > mintps))
					if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (((ECU_RPM > minrpm) && (ECU_RPM < maxrpm)) || (ECU_RPM == 0))  && (ECU_TPS > mintps))
						{
							if (switchover < rpg)
								{
									// switchoverincrease happens with dcounter as that is the ms value that every running loop makes
									switchover = switchover + (dcounter / rampupdivisor);
								}
							else
								{
									switchover = rpg;								}
						}
						else
						{
							switchover = 0;
						}
				}
				
			// calculate transition point and make sure that its within 0-100 range just in case to keep ECU running in error
			transition = (100 * switchover) / rpg;
			if (transition > 100) transition=100;
			if (transition < 0) transition=0;
			duty =      (((100 - transition) * 0 * dcounter)/10000) + ((transition * dutygear1 * dcounter)/10000);
			fueladd =   (((100 - transition) * 0)/100) + ((transition * fueladdgear1)/100);
			ignretard = (((100 - transition) * 0)/100) + ((transition * ignretardgear1)/100);
		}
		else
		{
			duty = (dutygear1*dcounter)/100;
			fueladd=fueladdgear1;
			ignretard=ignretardgear1;
		}
	}
else if (ECU_GPS == 2) 	
		{
		rpg=rampupgear2;
		if (rpg != 0)
		{
			if ((lastgear < ECU_GPS))
				{	// reset switchover algoritm on each gear change
					lastgear = ECU_GPS;
					switchover = 0;
				}
			else
				{	// rampup is active after gear change start counting switchiover up to maximum rampover
					//if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (ECU_RPM > minrpm) && (ECU_RPM < maxrpm) && (ECU_TPS > mintps))
					if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (((ECU_RPM > minrpm) && (ECU_RPM < maxrpm)) || (ECU_RPM == 0))  && (ECU_TPS > mintps))
						{
							if (switchover < rpg)
								{
									// switchoverincrease happens with dcounter as that is the ms value that every running loop makes
									switchover = switchover + (dcounter / rampupdivisor);
								}
							else
								{
									switchover = rpg;								}
						}
						else
						{
							switchover = 0;
						}
				}
				
			// calculate transition point and make sure that its within 0-100 range just in case to keep ECU running in error
			transition = (100 * switchover) / rpg;
			if (transition > 100) transition=100;
			if (transition < 0) transition=0;
			duty =      (((100 - transition) * dutygear1 * dcounter)/10000) + ((transition * dutygear2 * dcounter)/10000);
			fueladd =   (((100 - transition) * fueladdgear1)/100) + ((transition * fueladdgear2)/100);
			ignretard = (((100 - transition) * ignretardgear1)/100) + ((transition * ignretardgear2)/100);
		}
		else
		{
			duty = (dutygear2*dcounter)/100;
			fueladd=fueladdgear2;
			ignretard=ignretardgear2;
		}
		}
else if (ECU_GPS == 3) 	
	{
		rpg=rampupgear3;
		if (rpg != 0)
		{
			if ((lastgear < ECU_GPS))
				{	// reset switchover algoritm on each gear change
					lastgear = ECU_GPS;
					switchover = 0;
				}
			else
				{	// rampup is active after gear change start counting switchiover up to maximum rampover
					// if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (ECU_RPM > minrpm) && (ECU_RPM < maxrpm) && (ECU_TPS > mintps))
					if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (((ECU_RPM > minrpm) && (ECU_RPM < maxrpm)) || (ECU_RPM == 0))  && (ECU_TPS > mintps))

						{
							if (switchover < rpg)
								{
									// switchoverincrease happens with dcounter as that is the ms value that every running loop makes
									switchover = switchover + (dcounter / rampupdivisor);
								}
							else
								{
									switchover = rpg;								}
						}
						else
						{
							switchover = 0;
						}
				}
				
			// calculate transition point and make sure that its within 0-100 range just in case to keep ECU running in error
			transition = (100 * switchover) / rpg;
			if (transition > 100) transition=100;
			if (transition < 0) transition=0;
			duty =      (((100 - transition) * dutygear2 * dcounter)/10000) + ((transition * dutygear3 * dcounter)/10000);
			fueladd =   (((100 - transition) * fueladdgear2)/100) + ((transition * fueladdgear3)/100);
			ignretard = (((100 - transition) * ignretardgear2)/100) + ((transition * ignretardgear3)/100);
		}
		else
		{
			duty = (dutygear3*dcounter)/100;
			fueladd=fueladdgear3;
			ignretard=ignretardgear3;
		}
	}
else if (ECU_GPS == 4) 	
	{
		rpg=rampupgear4;
		if (rpg != 0)
		{
			if ((lastgear < ECU_GPS))
				{	// reset switchover algoritm on each gear change
					lastgear = ECU_GPS;
					switchover = 0;
				}
			else
				{	// rampup is active after gear change start counting switchiover up to maximum rampover
					// if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (ECU_RPM > minrpm) && (ECU_RPM < maxrpm) && (ECU_TPS > mintps))
					if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (((ECU_RPM > minrpm) && (ECU_RPM < maxrpm)) || (ECU_RPM == 0))  && (ECU_TPS > mintps))

						{
							if (switchover < rpg)
								{
									// switchoverincrease happens with dcounter as that is the ms value that every running loop makes
									switchover = switchover + (dcounter / rampupdivisor);
								}
							else
								{
									switchover = rpg;								}
						}
						else
						{
							switchover = 0;
						}
				}
				
			// calculate transition point and make sure that its within 0-100 range just in case to keep ECU running in error
			transition = (100 * switchover) / rpg;
			if (transition > 100) transition=100;
			if (transition < 0) transition=0;
			duty =      (((100 - transition) * dutygear3 * dcounter)/10000) + ((transition * dutygear4 * dcounter)/10000);
			fueladd =   (((100 - transition) * fueladdgear3)/100) + ((transition * fueladdgear4)/100);
			ignretard = (((100 - transition) * ignretardgear3)/100) + ((transition * ignretardgear4)/100);
		}
		else
	{
		duty = (dutygear4*dcounter)/100;
		fueladd=fueladdgear4;
		ignretard=ignretardgear4;
	}
	}
else if (ECU_GPS == 5) 	
	{
		rpg=rampupgear5;
		if (rpg != 0)
		{
			if ((lastgear < ECU_GPS))
				{	// reset switchover algoritm on each gear change
					lastgear = ECU_GPS;
					switchover = 0;
				}
			else
				{	// rampup is active after gear change start counting switchiover up to maximum rampover
					// if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (ECU_RPM > minrpm) && (ECU_RPM < maxrpm) && (ECU_TPS > mintps))
					if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (((ECU_RPM > minrpm) && (ECU_RPM < maxrpm)) || (ECU_RPM == 0))  && (ECU_TPS > mintps))

						{
							if (switchover < rpg)
								{
									// switchoverincrease happens with dcounter as that is the ms value that every running loop makes
									switchover = switchover + (dcounter / rampupdivisor);
								}
							else
								{
									switchover = rpg;								}
						}
						else
						{
							switchover = 0;
						}
				}
				
			// calculate transition point and make sure that its within 0-100 range just in case to keep ECU running in error
			transition = (100 * switchover) / rpg;
			if (transition > 100) transition=100;
			if (transition < 0) transition=0;
			duty =      (((100 - transition) * dutygear4 * dcounter)/10000) + ((transition * dutygear5 * dcounter)/10000);
			fueladd =   (((100 - transition) * fueladdgear4)/100) + ((transition * fueladdgear5)/100);
			ignretard = (((100 - transition) * ignretardgear4)/100) + ((transition * ignretardgear5)/100);
		}
		else

	{
		duty = (dutygear5*dcounter)/100;
		fueladd=fueladdgear5;
		ignretard=ignretardgear5;
	}
	}
else if (ECU_GPS == 6) 	
	{
		rpg=rampupgear6;
		if (rpg != 0)
		{
			if ((lastgear < ECU_GPS))
				{	// reset switchover algoritm on each gear change
					lastgear = ECU_GPS;
					switchover = 0;
				}
			else
				{	// rampup is active after gear change start counting switchiover up to maximum rampover
					//if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (ECU_RPM > minrpm) && (ECU_RPM < maxrpm) && (ECU_TPS > mintps))
					if (((DSMbuttonpressed) || (buttonactive != 0xFF)) && (((ECU_RPM > minrpm) && (ECU_RPM < maxrpm)) || (ECU_RPM == 0))  && (ECU_TPS > mintps))

						{
							if (switchover < rpg)
								{
									// switchoverincrease happens with dcounter as that is the ms value that every running loop makes
									switchover = switchover + (dcounter / rampupdivisor);
								}
							else
								{
									switchover = rpg;								}
						}
						else
						{
							switchover = 0;
						}
				}
				
			// calculate transition point and make sure that its within 0-100 range just in case to keep ECU running in error
			transition = (100 * switchover) / rpg;
			if (transition > 100) transition=100;
			if (transition < 0) transition=0;
			duty =      (((100 - transition) * dutygear5 * dcounter)/10000) + ((transition * dutygear6 * dcounter)/10000);
			fueladd =   (((100 - transition) * fueladdgear5)/100) + ((transition * fueladdgear6)/100);
			ignretard = (((100 - transition) * ignretardgear5)/100) + ((transition * ignretardgear6)/100);
		}
		else
		{
			duty = (dutygear6*dcounter)/100;
			fueladd=fueladdgear6;
			ignretard=ignretardgear6;
		}
	}
	
/*
	This is to recognize if DSM button has been depressed long enough to make sure that its really activated
*/
if (PORT3 & DSMSELECTED) 
	{
	if (threshold < 200)
			{
			threshold = threshold +1;
			}
	}
else
	{
		threshold = 0;
	}

/*
	Set nitrous activation window
*/ 
if (threshold > 10)
	{
	DSMbuttonpressed = TRUE;
	}
	else
	{
	DSMbuttonpressed = FALSE;
	};

if ((DSMbuttonpressed) || (buttonactive != 0xFF))
if (ECU_RPM > minrpm)
if (ECU_RPM < maxrpm)
if (ECU_TPS > mintps)
if (ECU_GPS != 0)
	{
	nitrousactive=TRUE;
	}
	else
	{
	nitrousactive=FALSE;
	}

/*
	This is purge line function, i.e. if engine RPM is 0 then nitrous is active
*/
if ((DSMbuttonpressed) || (buttonactive != 0xFF))
if (ECU_RPM == 0)
if (ECU_TPS > mintps)
if (ECU_GPS != 0)
	{
	nitrousactive=TRUE;
	}
	else
	{
	nitrousactive=FALSE;
	}


/*
	If nitrous is active set fueladd and then set port to active / inactive and also add fuel
*/
if (nitrousactive)
	{
	igncomp=(ignretard + ECU_IGNRETARD) & 0xFF;

	if (wetkitemulation != 0xFF)
	{
		ECU_COV1REUSED = fueladd;					// add fuel if wet kit emulation is on
	}
	
		if ((counter < duty) && (duty > 0))		// determine if nitrous solenoid duty cycle is on or off and set port output state accordingly
			{
				PORT1 = PORT1 | PAIR;			// turn port on
				ECU_COV1REUSED = fueladd;		// always add fuel when port is on
			}
		else
			{
				PORT1 = PORT1 & (0xFF - PAIR);	// turn port off
			}
	}
	else										
	{											// nitrous is not active
	igncomp=ECU_IGNRETARD;
	ECU_COV1REUSED = 0;							// do not add any fuel
	PORT1 = PORT1 & (0xFF - PAIR);				// turn port off
	}
	
	
/*
	Give control back to main program
*/

#pragma keyword asm on
asm(
	" jmp R14 "	// output to var TMP
);

}
