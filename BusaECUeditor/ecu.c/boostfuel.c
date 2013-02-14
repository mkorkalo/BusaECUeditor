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

/*
The shift kill variables are defined here, e.g kill times. These are adjusted using ecueditor.
*/
#pragma SECTION C PARAMS //0x55800
const unsigned short const_pgmid = 				112;			// program id, must match to ecueditor version to be able to load this code to ecu

const unsigned short overboostlimit = 				0xb1; // 1,21bar

const unsigned char sensormap[] = {																	
	0x05, 0x0C, 0xFF, 0xFF, 0x00, 0x05, 0x58, 0x14, 0x00, 0x05, 0x58, 0x24, 0x00, 0x00, 0x00, 0x00,		// 0x55804

	// conversion for GM3bar sensor, vacuum area
	// -100,-90 -80  -70   -60   -51   -40   -30   -21    0     +20    +35  kPa, 35 is the max for Suzuki sensor
	0x00, 0x08, 0x10, 0x18, 0x20, 0x27, 0x30, 0x38, 0x3F, 0x50, 0x60, 0x6C, 0xFF, 0xFF, 0xFF, 0xFF,		// 0x55814
	0x24, 0x33, 0x41, 0x50, 0x5E, 0x6B, 0x7C, 0x8B, 0x97, 0xB7, 0xD4, 0xEA, 0xFF, 0xFF, 0xFF, 0xFF};	// 0x55824

	const unsigned char boostmap[] = {							
		// add to TPS fuel injection pulse, positive pressure area						
		0x05, 0x10, 0x0A, 0xFF, 0x00, 0x05, 0x58, 0x44, 0x00, 0x05, 0x58, 0x54, 0x00, 0x05, 0x58, 0x74,		// 0x55834

		// 1     9    16    23    34    41    59    72  new  88    new   106   121   134   152   168       This is the positive pressure to ecumap
		0x52, 0x58, 0x5E, 0x63, 0x6C, 0x73, 0x81, 0x8b, 0x92, 0x98, 0xa0, 0xa6, 0xb2, 0xbd, 0xcb, 0xd8, 		// 0x55844
		// // 0x55854
		0x28, 0x00, // 4000
		0x32, 0x00, // 5000 new
		0x37, 0x00, // 5500 new
		0x3C, 0x00, // 6000
		0x41, 0x00, // 6500 new
		0x46, 0x00, // 7000 new
		0x4B, 0x00, // 7500 new
		0x50, 0x00,	//8000
		0x55, 0x00,	//8500 new
		0x5A, 0x00, //9000
		0x5F, 0x00, //9500
		0x64, 0x00, //10000
		0x69, 0x00, //10500
		0x6E, 0x00,	//11000	
		0x73, 0x00, //11500
		0x7C, 0x00, //12500
		//0xC0, 0x00, 
		//0xD0, 0x00,	
		//0xE0, 0x00, 
		//0xF0, 0x00,	
		//0xFF, 0xFF, 
		//0xFF, 0xFF,

		0, 1, 4, 11, 23, 27, 27, 27, 26, 25, 26, 26, 25, 27, 27, 27,                 // 4000 0x55874
		0, 1, 7, 11, 23, 29, 27, 27, 26, 25, 26, 26, 25, 27, 27, 27,                 // 5000 new
		0, 1, 7, 13, 23, 29, 28, 27, 26, 26, 26, 26, 26, 27, 27, 27,                 // 5500 new
		0, 1, 8, 15, 23, 40, 40, 53, 52, 52, 51, 51, 48, 50, 58, 58,                 // 6000
		0, 1, 8, 17, 28, 42, 51, 52, 59, 66, 74, 78, 83, 88, 98, 98,                 // 6500 new
		0, 4, 9, 20, 31, 42, 53, 58, 65, 71, 78, 82, 91, 105, 115, 126,              // 7000 new
		0, 4, 9, 20, 33, 46, 55, 64, 70, 75, 83, 87, 95, 107, 115, 126,              // 7500 new
		0, 4, 9, 20, 31, 42, 53, 64, 69, 74, 83, 87, 95, 107, 115, 126,              // 8000
		0, 4, 9, 20, 31, 41, 53, 58, 66, 73, 80, 83, 92, 105, 115, 126,              //8500
		0, 4, 9, 20, 31, 42, 53, 58, 65, 72, 77, 79, 88, 105, 107, 126,              // 9000
		0, 4, 9, 20, 31, 42, 53, 57, 65, 72, 75, 77, 86, 96, 107, 126,               // 9500
		0, 4, 9, 20, 31, 42, 61, 67, 69, 72, 62, 57, 60, 65, 72, 75,                 // 10000
		0, 4, 9, 20, 31, 42, 59, 58, 52, 45, 41, 39, 40, 49, 46, 47,                 // 10500 
		0, 4, 9, 20, 31, 42, 40, 34, 34, 33, 27, 24, 31, 46, 43, 40,                 // 11000
		0, 4, 4, 15, 26, 32, 40, 33, 26, 20, 20, 20, 26, 26, 28, 30,                 // 11500 
		0, 4, 4, 15, 26, 32, 39, 31, 26, 20, 20, 20, 20, 20, 24, 30};                // 12000


		/*
		0, 1, 4, 11, 23, 27, 27, 27, 25, 26, 25, 27, 27, 27, 27, 27,                                   // 4000 0x55874
		0, 1, 7, 11, 23, 29, 27, 27, 25, 26, 25, 27, 27, 27, 27, 27,                                   // 5000 new
		0, 1, 7, 13, 23, 29, 28, 27, 26, 26, 26, 27, 27, 28, 29, 29,                                   // 5500 new
		0, 1, 8, 15, 23, 40, 40, 53, 52, 51, 48, 50, 58, 58, 58, 58,                                   // 6000
		0, 1, 8, 17, 28, 42, 51, 52, 66, 78, 83, 88, 98, 98, 98, 98,                                   // 6500 new
		0, 4, 9, 20, 31, 42, 53, 58, 71, 82, 91, 105, 115, 126, 137, 137,                              // 7000 new
		0, 4, 9, 20, 33, 46, 55, 64, 75, 87, 95, 107, 115, 126, 137, 149,                              // 7500 new
		0, 4, 9, 20, 31, 42, 53, 64, 74, 87, 95, 107, 115, 126, 137, 149,                              // 8000
		0, 4, 9, 20, 31, 41, 53, 58, 73, 83, 92, 105, 115, 126, 137, 149,                              //8500
		0, 4, 9, 20, 31, 42, 53, 58, 72, 79, 88, 105, 107, 126, 137, 149,                              // 9000
		0, 4, 9, 20, 31, 42, 53, 57, 72, 79, 88, 96, 107, 126, 137, 149,                               // 9500
		0, 4, 9, 20, 31, 42, 61, 67, 72, 57, 60, 65, 72, 75, 77, 78,                                   // 10000
		0, 4, 9, 20, 31, 42, 59, 58, 45, 39, 40, 49, 46, 47, 47, 54,                                   // 10500 
		0, 4, 9, 20, 31, 42, 40, 34, 33, 24, 31, 46, 43, 40, 40, 40,                                   // 11000
		0, 4, 4, 15, 26, 32, 40, 33, 20, 20, 26, 26, 28, 30, 30, 30,                                   // 11500 
		0, 4, 4, 15, 26, 32, 39, 31, 20, 20, 20, 20, 24, 30, 30, 30};                                  // 12000
		*/
		/*
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 4000 0x55874
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 5000 new
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 5500 new
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 6000
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 6500 new
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 7000 new
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 7500 new
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 8000
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0x80, 0xA0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 8500 new
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 9000
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x40, 0x55, 0x76, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 9500
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x48, 0x55, 0x9B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 10000
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x48, 0x55, 0x9B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 10500 
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x48, 0x55, 0x9B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 11000
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x48, 0x55, 0x9B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,		// 11500 
		0x00, 0xA, 0x12, 0x28, 0x38, 0x40, 0x48, 0x55, 0x9B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};		// 12000
		*/

#pragma SECTION C PDUTY //0x559A0
#define dcounter 								0x19			 // 0xA=21Hz, 0x10=14Hz, 0x19=10Hz divisor for AD conversion cycles
		const unsigned char const10hz = 				dcounter;
		const unsigned char fueladdmode = 				0xFF; /* 0x00 adding, 0x10 % of TPS) */
		const unsigned char dutyactive =				0xFF; /* 0xFF inactive, 0x00 active*/
		const unsigned char solenoidtype = 				0xFF; /* 0xFF or 0x00 */

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
#pragma SECTION P BOOSTFUEL //0x55A00
		void boostfuelmain(void)
		{
			if (initialized == 0)							// if not initialized then set initialized variable and run other initialization if needed
			{
				initialized = 1;
				counter = 0;
			}

			/* 
			Define duty cycle run rate in 10 Hz 
			*/ 
			counter = counter + 1;
			if (counter >= dcounter) 
			{
				counter = 0;
			}

			/*
			Convert a 2D GM3 map to an IAP map value and store it back to ECU_IAP value.
			*/
			if (LR == 0) 	// Allow only when not active from previous run, other interrupts seem to break an ongoing
				// AD conversion cycle causing LR to get lost.
			{
				IAP_8bit = (ECU_AN15 >> 2) ; // lets change to 8bit
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

			ECU_IAP = (IAP_8bit  << 2); 			// back to 10bit value

			if (PRESSURE  >= 0x52) 
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

			/*
			Do not let the IAP sensor values exceed the limits to throw in an errorcode. BA00 is 101kPa
			*/
			if (ECU_IAP > (0xBA00 >> 6)) 
			{
				ECU_IAP = (0xBA00 >> 6);
			}

			/*

			*****************
			*****************
			*****************

			Duty cycle solenoid control. Routine runs at every AD conversion loop if activated. The most of the code
			after this point only runs if dutyactive == 0x00

			*/
			if (dutyactive == 0x00)
			{
				/*
				Lets define what is the maximum boost level for each gear / mode and set also dyty cycle per gear. 
				*/	
				if (ECU_GPS == 1) 		
				{
					targetboost = Maxboostgear1;
					ignretard = Ignretardgear1; 
					if (PRESSURE >= targetboost)
						/* If pressure is higher than targetboost by gear then start reducing duty gradually */
					{duty=0;}
					else 
						if (PRESSURE > gatepressure1)
							/* if pressure is over the gatepressure set by gear then set the gatepressure to duty by gear */
						{duty=Dutygear1;}
						else
							/* in every other case set 100% duty cycle */
						{duty=100;}
				}
				else if (ECU_GPS == 2) 	
				{	
					targetboost = Maxboostgear2;
					ignretard = Ignretardgear2; 
					if (PRESSURE >= targetboost)
					{duty=0;}
					else 
						if (PRESSURE > gatepressure2)
						{duty=Dutygear2;}
						else
						{duty=100;}
				}

				else if (ECU_GPS == 3) 	
				{
					targetboost = Maxboostgear3;
					ignretard = Ignretardgear3; 
					if (PRESSURE >= targetboost)
					{duty=0;}
					else 
						if (PRESSURE > gatepressure3)
						{duty=Dutygear3;}
						else
						{duty=100;}
				}

				else if (ECU_GPS == 4) 	
				{
					targetboost = Maxboostgear4;
					ignretard = Ignretardgear4; 
					if (PRESSURE >= targetboost)
					{duty=0;}
					else 
						if (PRESSURE > gatepressure4)
						{duty=Dutygear4;}
						else
						{duty=100;}
				}

				else if (ECU_GPS == 5) 	
				{
					targetboost = Maxboostgear5;
					ignretard = Ignretardgear5; 
					if (PRESSURE >= targetboost)
					{duty=0;}
					else 
						if (PRESSURE > gatepressure5)
						{duty=Dutygear5;}
						else
						{duty=100;}
				}
				else if (ECU_GPS == 6) 	
				{
					targetboost = Maxboostgear6;
					ignretard = Ignretardgear6; 
					if (PRESSURE >= targetboost)
					{duty=0;}
					else 
						if (PRESSURE > gatepressure6)
						{duty=Dutygear6;}
						else
						{duty=100;}
				}

				else /*every other gear */
				{	 
					targetboost = Maxboostgear1;
					ignretard=Ignretardgear1;
					duty=0;
				}

				/*
				set port based on dyty cycle

				variable duty contains duty cycle value, ie percentage is duty/100
				constXHz is the number of times the loop runs before counter is reset
				counter runs @ 10Hz so duty counter represents real % of 10Hz duty cycle

				*/
				if ((counter < ((duty * dcounter) / 100)) && (duty > 0)) 			
				{
					if (solenoidtype == 0x00) {PORT1 = PORT1 & (0xFF - PAIR);}
					else {PORT1 = PORT1 | PAIR;}			// turn port on
				}
				else
				{
					if (solenoidtype == 0x00) {PORT1 = PORT1 | PAIR;}
					else {PORT1 = PORT1 & (0xFF - PAIR);}	// turn port off
				}

				// here we add gear specific value to ignition retard
				igncomp=(ignretard + ECU_IGNRETARD) & 0xFF;
			} 
			/*
			end if dutyactive

			*****************
			*****************
			*****************

			*/

			else
			{ // if duty solenoid is not active, then we use ECU setting for ignition retard
				igncomp=ECU_IGNRETARD;
			}

			/*
			As the last thing before giving control back to ecu, set overboost to kill fuel and ignition
			*/
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
