/*
boosftuel.c

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

v1.00 first release for Hayabusa gen2, includes GM3 bar sensor conversion tables
v1.05 latest release with duty cycle disabled, otherwise functional
v1.06 development version with PAIR port as output for duty cycle

*/

/*
These are the RAM variable addresses that are internal to this subroutine
*/
#define ECU_IAP *(volatile unsigned short *)  				0x008042F0 
#define ECU_INJVOLT *(volatile unsigned short *)  			0x008042DA
#define ECU_SAP *(volatile unsigned short *)  				0x008042EE
#define ECU_RPM *(volatile unsigned short *)  				0x0080502E 
#define ECU_FI *(volatile unsigned char *)  				0x00806784
#define ECU_HOX *(volatile unsigned char *)  				0x00805085
#define ECU_COV1 *(volatile unsigned char *)  				0x00805442
#define ECU_GPS	*(volatile unsigned char *)  				0x008050B3
#define PORT1   *(volatile unsigned char *)  				0x00800701 // bit5=PAIR
#define PORT3   *(volatile unsigned char *)  				0x00804862 // bit0=DSM2, bit1=DSM1
#define ECU_IGNRETARD *(volatile unsigned char *)  			0x008063A2
#define BOOSTACTIVE *(volatile unsigned char *)  			0x00055800
#define cyl1_TPS_fuel * (volatile unsigned short *)			0x0080643C

/* 701/721=Port1, 708/728=Port2 */
#define PORTDATA *(volatile unsigned char *)  				0x00800701
#define PORTDIR	 *(volatile unsigned char *)  				0x00800721
#define PORTbit	*(volatile unsigned char *)					0x20

#define ECU_MODE *(volatile unsigned char *)  				0x008050D5
#define ModeA						0x0
#define ModeB						0x1
#define ModeC						0x2
#define DSM2						0x1
#define DSM1						0x2
#define PAIR						0x20
#define MAXBOOST					100;

/*
Internal variables for this subroutine only, these are borrowed from the ecu ram area using addresses
that are considered not having been assigned for any use.
 
area between 00806800-00806820 is used shifter2gen.bin

*/
#define ramaddr 										0x00806800 // This is the starting address for free ram area for user programs
// note +24dec, 0x18 is first free address
#define	ECU_COV1REUSED	*(volatile unsigned char *)  	(ramaddr + 0x18) // +24dec would be  is first free address, before that shifter code uses the addresses
#define	IAP_8bit 		*(volatile unsigned char *)  	(ramaddr + 0x1A) 
#define	LR				*(volatile unsigned char *) 	(ramaddr + 0x1C) 
#define	BENR			*(volatile unsigned char *) 	(ramaddr + 0x20) 
#define	PRESSURE		*(volatile unsigned char *) 	(ramaddr + 0x24) 
#define	GAUGECOPY		*(volatile unsigned char *) 	(ramaddr + 0x28) 
#define	ECU_AN15		*(volatile unsigned short *) 	(ramaddr + 0x2A) 
#define initialized 	*(volatile unsigned char *) 	(ramaddr + 0x2C) 
#define counter			*(volatile unsigned short *) 	(ramaddr + 0x2E) 
#define duty			*(volatile unsigned short *) 	(ramaddr + 0x30)
#define targetboost		*(volatile unsigned short *) 	(ramaddr + 0x34)
#define ignretard		*(volatile unsigned char *) 	(ramaddr + 0x54) 
#define igncomp		 	*(volatile unsigned char *) 	(ramaddr + 0x56) 
#define	overboost 		*(volatile unsigned char *)  	(ramaddr + 0x68)
#define BOOST_IGN_RETARD *(volatile unsigned char *)  	(ramaddr + 0x6A)

/*
The shift kill variables are defined here, e.g kill times. These are adjusted using ecueditor.
*/
#pragma SECTION C PARAMS //0x55800
const unsigned short const_pgmid = 				113;  // program id, must match to ecueditor version to be able to load this code to ecu

const unsigned short overboostlimit = 			0xb1; // 1,21bar

const unsigned char sensormap[] = {																	
// Offset = 0x04 = 0x55804
	0x05, 0x0C, 0xFF, 0xFF, 0x00, 0x05, 0x58, 0x14, 0x00, 0x05, 0x58, 0x24, 0x00, 0x00, 0x00, 0x00,

// Offset = 0x14 = 0x55814
	// conversion for GM3bar sensor, vacuum area
	// -100,-90 -80  -70   -60   -51   -40   -30   -21    0     +20    +35  kPa, 35 is the max for Suzuki sensor
	0x00, 0x08, 0x10, 0x18, 0x20, 0x27, 0x30, 0x38, 0x3F, 0x50, 0x60, 0x6C, 0xFF, 0xFF, 0xFF, 0xFF,
	
// Offset = 0x24 = 0x55824
	0x24, 0x33, 0x41, 0x50, 0x5E, 0x6B, 0x7C, 0x8B, 0x97, 0xB7, 0xD4, 0xEA, 0xFF, 0xFF, 0xFF, 0xFF};
	
// add to TPS fuel injection pulse, positive pressure area
const unsigned char boostmap[] = {
// Offset = 0x34 = 0x55834
		0x05, 0x18, 0x18, 0xFF, 0x00, 0x05, 0x58, 0x44, 0x00, 0x05, 0x58, 0x5C, 0x00, 0x05, 0x58, 0x8C,

// Offset = 0x44 = 0x55844
		//This is the positive pressure to ecumap
		0x52, 0x58, 0x63, 0x6E, 0x7A, 0x85, 0x90, 0x9b, 0xA7, 0xB2, 0xBD, 0xC8, 0xD3, 0xDF, 0xEA, 0xF5, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,

// Offset = 0x5C = 0x5585C
		0x28, 0x00, //4000
		0x32, 0x00, //5000
		0x37, 0x00, //5500
		0x3C, 0x00, //6000
		0x41, 0x00, //6500
		0x46, 0x00, //7000
		0x4B, 0x00, //7500
		0x50, 0x00,	//8000
		0x55, 0x00,	//8500
		0x5A, 0x00, //9000
		0x5F, 0x00, //9500
		0x64, 0x00, //10000
		0x69, 0x00, //10500
		0x6E, 0x00,	//11000	
		0x73, 0x00, //11500
		0x78, 0x00, //12000
		0x7D, 0x00, //12500
		0x82, 0x00,	//13000
		0x87, 0x00, //13500
		0x8C, 0x00,	//14000
		0x91, 0x00, //14500
		0x96, 0x00, //15000
		0x9B, 0x00, //15500
		0xA0, 0x00, //16000

// Offset = 0x8C = 0x5588C
		0, 1, 4, 11, 23, 27, 27, 27, 26, 25, 26, 26, 25, 27, 27, 27, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 4000
		0, 1, 7, 11, 23, 29, 27, 27, 26, 25, 26, 26, 25, 27, 27, 27, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 5000
		0, 1, 7, 13, 23, 29, 28, 27, 26, 26, 26, 26, 26, 27, 27, 27, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 5500
		0, 1, 8, 15, 23, 40, 40, 53, 52, 52, 51, 51, 48, 50, 58, 58, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 6000
		0, 1, 8, 17, 28, 42, 51, 52, 59, 66, 74, 78, 83, 88, 98, 98, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 6500
		0, 4, 9, 20, 31, 42, 53, 58, 65, 71, 78, 82, 91, 105, 115, 126, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 7000
		0, 4, 9, 20, 33, 46, 55, 64, 70, 75, 83, 87, 95, 107, 115, 126, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 7500
		0, 4, 9, 20, 31, 42, 53, 64, 69, 74, 83, 87, 95, 107, 115, 126, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 8000
		0, 4, 9, 20, 31, 41, 53, 58, 66, 73, 80, 83, 92, 105, 115, 126, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 8500
		0, 4, 9, 20, 31, 42, 53, 58, 65, 72, 77, 79, 88, 105, 107, 126, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 9000
		0, 4, 9, 20, 31, 42, 53, 57, 65, 72, 75, 77, 86, 96, 107, 126, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 9500
		0, 4, 9, 20, 31, 42, 61, 67, 69, 72, 62, 57, 60, 65, 72, 75, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 10000
		0, 4, 9, 20, 31, 42, 59, 58, 52, 45, 41, 39, 40, 49, 46, 47, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 10500 
		0, 4, 9, 20, 31, 42, 40, 34, 34, 33, 27, 24, 31, 46, 43, 40, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 11000
		0, 4, 4, 15, 26, 32, 40, 33, 26, 20, 20, 20, 26, 26, 28, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 11500 
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 12000
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 12500
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 13000
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 13500
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 14000
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 14500
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 15000
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,	// 15500
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff};	// 16000

const unsigned char ignitionretardmap[] = {																	
// Offset = 0x2CC = 0x55ACC
	0x05, 0x18, 0xFF, 0xFF, 0x00, 0x05, 0x5A, 0xDC, 0x00, 0x05, 0x5A, 0xF4, 0x00, 0x00, 0x00, 0x00,

// Offset = 0x2DC = 0x55ADC
	// conversion for presure to ignition retard
	0x52, 0x58, 0x63, 0x6E, 0x7A, 0x85, 0x90, 0x9b, 0xA7, 0xB2, 0xBD, 0xC8, 0xD3, 0xDF, 0xEA, 0xF5, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
// Offset = 0x2F4 = 0x55AF4
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};	


#pragma SECTION C PDUTY //0x55C00
#define dcounter 								0x19			 // 0xA=21Hz, 0x10=14Hz, 0x19=10Hz divisor for AD conversion cycles
		const unsigned char const10hz = 				dcounter;
		const unsigned char fueladdmode = 				0xFE; /* 0x00 adding, 0xFF % of TPS) */
		const unsigned char dutyactive =				0xFD; /* 0xFF inactive, 0x00 active*/
		const unsigned char solenoidtype = 				0xFC; /* 0xFF or 0x00 */

		const unsigned short Maxboostgear1 = 	0x81;  /* 559A0 */
		const unsigned short Maxboostgear2 = 	0x8B; 
		const unsigned short Maxboostgear3 = 	0x98; 
		const unsigned short Maxboostgear4 = 	0xA6; 
		const unsigned short Maxboostgear5 = 	0xA6; 
		const unsigned short Maxboostgear6 = 	0xA6; 

		const unsigned short gatepressure1 = 	0x70; 
		const unsigned short gatepressure2 = 	0x70; 
		const unsigned short gatepressure3 = 	0x70; 
		const unsigned short gatepressure4 = 	0x70; 
		const unsigned short gatepressure5 = 	0x70; 
		const unsigned short gatepressure6 = 	0x70; 

		const unsigned short Dutygear1 = 	40; 
		const unsigned short Dutygear2 = 	40; 
		const unsigned short Dutygear3= 	40; 
		const unsigned short Dutygear4 = 	50; 
		const unsigned short Dutygear5 = 	60; 
		const unsigned short Dutygear6 = 	80; 

		const unsigned short Ignretardgear1 = 	1; 
		const unsigned short Ignretardgear2 = 	2; 
		const unsigned short Ignretardgear3 = 	2; 
		const unsigned short Ignretardgear4 = 	2; 
		const unsigned short Ignretardgear5 = 	2; 
		const unsigned short Ignretardgear6 = 	2; 

	// Offset 0x434 = 0x55C30
		const unsigned short BoostSensorVoltage1 = 0;	// 0.0 v
		const unsigned short BoostSensorPressure1 = 0;	// 0.0 kPa
		const unsigned short BoostSensorVoltage2 = 50; 	// 5.0 v
		const unsigned short BoostSensorPressue2 = 3130;	// 313.0 kPa
		
		/*
		Constants 
		*/ 
#define TTT							1			/* internal const for the program */
#define FFF 						0			/* internal const for the program */

		/*
		This is the main programming loop. Its thrown to be executed at the end of the AD conversion loop. This way when ever
		the AD values are read then also the boostfuel value is updated. Additionally cylinder specific fuel caluclations
		needs to be changed so that the results of this calculation is included in fuel calculations.
		*/ 
#pragma SECTION P BOOSTFUEL //0x55D00
		void boostfuelmain(void)
		{
			if (initialized == 0)							// if not initialized then set initialized variable and run other initialization if needed
			{
				initialized = 1;
				counter = 0;
			}

			/* Define duty cycle run rate in 10 Hz */ 
			counter = counter + 1;
			
			if (counter >= dcounter) 
			{
				counter = 0;
			}

			/* Convert a 2D GM3 map to an IAP map value and store it back to ECU_IAP value. */
			if (LR == 0) 	// Allow only when not active from previous run, other interrupts seem to break an ongoing
				// AD conversion cycle causing LR to get lost.
			{
				IAP_8bit = (ECU_AN15 >> 2); // lets change to 8bit
				BENR = (ECU_AN15 >> 2);
				PRESSURE = (ECU_AN15 >> 2);

			#pragma keyword asm on
				asm(
					// push lr
					" ld24 R5, #0x80681C \n"	// LR_ramvar
					" st R14, @R5 \n"			// push lr to LR_ramvar
					
					// Process map conversion
					" ld24 R5, #0x80681A \n"	// input in variable IAP_8bit 
					" ldub R5, @R5 \n"			// load zero extended byte
					" ld24 R4, #0x55804 \n"		// conversion table address
					" bl 0x3544 \n"				// get2dmap
					" srli R0, #8 \n"
					" ld24 R5, #0x80681A \n"
					" stb R0, @R5 \n"			// store zero extended byte to var IAP_8bit 
				
					// pop LR
					" ld24 R5, #0x80681C \n"	// get LR from LR_ramvar
					" ld R14, @R5 \n"			// pop lr back to original state
				
					// Process Boost Ignition Retard Map
					" ld24 R5, #0x806824 \n"	// input in variable PRESSURE 
					" ldub R5, @R5 \n"			// load zero extended byte
					" ld24 R4, #0x55ACC \n"		// conversion table address
					" bl 0x3544 \n"				// get2dmap
					" srli R0, #8 \n"
					" ld24 R5, #0x80686A \n"
					" stb R0, @R5 \n"			// store zero extended byte to var BOOST_IGN_RETARD 
				
					// pop LR
					" ld24 R5, #0x80681C \n"	// get LR from LR_ramvar
					" ld R14, @R5 \n"			// pop lr back to original state
					
					// Process boost enrichment map
					" ld24 R6, #0x80502E \n"	// RPM
					" lduh R6, @R6 \n"
					" ld24 R5, #0x806820 \n"	// input in variable BENR 
					" ldub R5, @R5 \n"			// load zero extended byte
					" ld24 R4, #0x55834 \n"		// conversion table address
					" bl 0x35F4 \n"				// get3dmap
					" srli R0, #8 \n"
					" ld24 R5, #0x806820 \n"
					" stb R0, @R5 \n"			// store zero extended byte to BENR
				
					// pop LR
					" ld24 R5, #0x80681C \n"	// get LR from LR_ramvar
					" ld R14, @R5 \n"			// pop lr back to original state
					
					" ld24 R4, #0x0 \n"			// clear LR_ramvar to indicate that the function can be used again
					" ld24 R5, #0x80681C \n"
					" st R4, @R5 \n"		
					);
			}
			
			// back to 10bit value
			ECU_IAP = (IAP_8bit << 2);

			if (PRESSURE >= 0x52) 
			{
				if (fueladdmode != 0)
				{
					ECU_COV1REUSED = (((BENR * (cyl1_TPS_fuel>>8)) / fueladdmode) & 0xFF) ;
				}
				else
				{
					ECU_COV1REUSED = BENR;					// Store the value back to COV1
				}
			}
			else
			{
				ECU_COV1REUSED = 0;
			}

			/* Do not let the IAP sensor values exceed the limits to throw in an errorcode. BA00 is 101kPa */
			if (ECU_IAP > (0xBA00 >> 6)) 
			{
				ECU_IAP = (0xBA00 >> 6);
			}

			/*
			Duty cycle solenoid control. Routine runs at every AD conversion loop if activated. The most of the code
			after this point only runs if dutyactive == 0x00
			*/
			if (dutyactive == 0x00)
			{
				/* Lets define what is the maximum boost level for each gear / mode and set also dyty cycle per gear. */	
				if (ECU_GPS == 1) 		
				{
					targetboost = Maxboostgear1;
					ignretard = Ignretardgear1; 
					
					if (PRESSURE >= targetboost)
					{/* If pressure is higher than targetboost by gear then start reducing duty gradually */
						duty = 0;
					}
					else if (PRESSURE > gatepressure1)
					{/* if pressure is over the gatepressure set by gear then set the gatepressure to duty by gear */
						duty = Dutygear1;
					}
					else
					{/* in every other case set 100% duty cycle */
						duty = 100;
					}
				}
				else if (ECU_GPS == 2) 	
				{	
					targetboost = Maxboostgear2;
					ignretard = Ignretardgear2;
					
					if (PRESSURE >= targetboost)
					{
						duty = 0;
					}
					else if (PRESSURE > gatepressure2)
					{
						duty = Dutygear2;
					}
					else
					{
						duty = 100;
					}
				}
				else if (ECU_GPS == 3) 	
				{
					targetboost = Maxboostgear3;
					ignretard = Ignretardgear3; 
					
					if (PRESSURE >= targetboost)
					{
						duty = 0;
					}
					else if (PRESSURE > gatepressure3)
					{
						duty = Dutygear3;
					}
					else
					{
						duty = 100;
					}
				}
				else if (ECU_GPS == 4) 	
				{
					targetboost = Maxboostgear4;
					ignretard = Ignretardgear4;
					
					if (PRESSURE >= targetboost)
					{
						duty = 0;
					}
					else if (PRESSURE > gatepressure4)
					{
						duty = Dutygear4;
					}
					else
					{
						duty = 100;
					}
				}
				else if (ECU_GPS == 5) 	
				{
					targetboost = Maxboostgear5;
					ignretard = Ignretardgear5; 
					
					if (PRESSURE >= targetboost)
					{
						duty = 0;
					}
					else if (PRESSURE > gatepressure5)
					{
						duty = Dutygear5;
					}
					else
					{
						duty = 100;
					}
				}
				else if (ECU_GPS == 6) 	
				{
					targetboost = Maxboostgear6;
					ignretard = Ignretardgear6;
					
					if (PRESSURE >= targetboost)
					{
						duty = 0;
					}
					else if (PRESSURE > gatepressure6)
					{
						duty = Dutygear6;
					}
					else
					{
						duty = 100;
					}
				}
				else /*every other gear */
				{	 
					targetboost = Maxboostgear1;
					ignretard=Ignretardgear1;
					duty=0;
				}

				/*
				set port based on duty cycle

				variable duty contains duty cycle value, ie percentage is duty/100
				constXHz is the number of times the loop runs before counter is reset
				counter runs @ 10Hz so duty counter represents real % of 10Hz duty cycle

				*/
				if ((counter < ((duty * dcounter) / 100)) && (duty > 0)) 			
				{
					if (solenoidtype == 0x00) 
					{// turn port off
						PORT1 = PORT1 & (0xFF - PAIR);
					}
					else 
					{// turn port on
						PORT1 = PORT1 | PAIR;
					}
				}
				else
				{
					if (solenoidtype == 0x00) 
					{// turn port on
						PORT1 = PORT1 | PAIR;
					}
					else 
					{// turn port off
						PORT1 = PORT1 & (0xFF - PAIR);
					}
				}

				// here we add gear specific value to ignition retard
				igncomp = (ignretard + ECU_IGNRETARD + BOOST_IGN_RETARD) & 0xFF;
			} 
			else
			{ // if duty solenoid is not active, then we use ECU setting for ignition retard
				igncomp = (ECU_IGNRETARD + BOOST_IGN_RETARD) & 0xFF;
			}

			/* As the last thing before giving control back to ecu, set overboost to kill fuel and ignition */
			if (PRESSURE >= overboostlimit)
			{
				overboost=0xFF;
				duty=0;
			}
			else
			{
				overboost=0x00;
			}
			
#pragma keyword asm on
		asm(
			" jmp R14 "	
			);
		}