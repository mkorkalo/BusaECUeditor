/*
	v1.01 added igncut and fuelcut const flags that can be set
	and pair output code
	
*/

/* History:
11.8.2009 JaSa shifter low treshold added
	-const_killtime_2000
	-else if (ECU_RPM > 0x1E00) {duration_kill = const_killtime_3000;}
	-else {duration_kill = const_killtime_2000;}
	-if ((nt_6th_gear == 0) &&  (ECU_RPM > 0x1400)) old value 1E00
	
*/
#define ECU_AD_GPS *(volatile unsigned char *)         	0xFFFF838F
#define ECU_RPM *(volatile unsigned short *)  	       	0xFFFF8398
#define ECU_FuelKillFlag *(volatile unsigned char *)  	0xFFFF8556 
#define ECU_IgnKillFlag *(volatile unsigned char *) 	0xFFFF8453
#define ECU_PAIR *(volatile unsigned short *) 	       	0xFFFFF754
#define ECU_PAIRDISABLED *(volatile unsigned char *) 	0x0000665F

#define ECU_CLT *(volatile unsigned char *) 	       	0xFFFF8228
#define ECU_CCKSUM *(volatile unsigned char *) 	       	0xFFFF85D9
#define ECU_FAULTCODE1 *(volatile unsigned char *)     	0xFFFF822A
#define ECU_F1CKSUM *(volatile unsigned char *)        	0xFFFF85DB
#define ECU_FAULTCODE2 *(volatile unsigned char *)     	0xFFFF822B
#define ECU_F2CKSUM *(volatile unsigned char *)        	0xFFFF85DC

#define killcount *(volatile unsigned short *)         	0xFFFF8600
#define killswitch *(volatile unsigned char *)         	0xFFFF8604
#define killcountactive *(volatile unsigned char *) 	0xFFFF8606 
#define initialized *(volatile unsigned char *)        	0xFFFF8608
#define killflag *(volatile unsigned char *)  	       	0xFFFF860A
#define nt_6th_gear *(volatile unsigned short *)       	0xFFFF860C
#define nt_6th_gearcount *(volatile unsigned short *)	0xFFFF8610
#define	duration_kill *(volatile unsigned short *)  	0xFFFF8614

#pragma section ADJ //CADJ 15700
const short const_killtime_12000 = 0x177;  	//ADJ + 00 = 15700
const short const_killtime_11000 = 0x158;	//ADJ + 02 = 15702
const short const_killtime_10000 = 0x138;	//ADJ + 04 = 15704
const short const_killtime_9000 = 0x119;	//ADJ + 06 = 15706
const short const_killtime_8000 = 0xf9;		//ADJ + 08 = 15708
const short const_killtime_7000 = 0xda;		//ADJ + 10 = 1570A
const short const_killtime_6000 = 0xbb;		//ADJ + 12 = 1570C
const short const_killtime_5000 = 0x9c;		//ADJ + 14 = 1570E
const short const_killtime_4000 = 0x7c;		//ADJ + 16 = 15710
const short const_killtime_3000 = 0x5d; 	//ADJ + 18 = 15712
const short const_killtime_2000 = 0x3e; 	//ADJ + 20 = 15714	added 11.8.2009 JaSa
const short minkillactive = 5;   		//ADJ + 22 = 15715
const short killcountdelay = 400;		//ADJ + 24 = 15716
const short solenoidrpm = 0x6400;		//ADJ + 26 = 15718
const short s_GEAR12 = 0x5000;			//ADJ + 28 = 1571A
const short s_GEAR3456 = 0x6400;		//ADJ + 30 = 1571C
//const short s_6th_shift_active = 0;		//ADJ + 32 = 1571E

#define ACTIVE 					       	1
#define DEACTIVE 				       	0
#define FUELCUTACTIVE 					3
#define IGNITIONCUTACTIVE 				3 //should this be 2?? 
#define SHIFTERACTIVE 					0x40

#pragma section IDTAG //0x15740
const short const_pgmid = 200;			//15740 // Changed 11.8.2009 JaSa - orig value 101
const char igncut = ACTIVE;                     //15742
const char fuelcut = ACTIVE;                    //15743


#pragma section ASSY //PASSY 15750
#pragma inline_asm(sub_0x00011E90)
void sub_0x00011E90(void)
{
 MOV.L    #H'00011E90, R3
 JSR    @R3
 NOP
}

#pragma inline_asm(jump_back_fuel_loop)
void jump_back_fuel_loop(void)
{
 MOV.L    #H'0000E290, R3
 JMP    @R3
 NOP
}

#pragma inline_asm(jump_back_ign_loop)
void jump_back_ign_loop(void)
{
 MOV.L    #H'0000B078, R3
 JSR    @R3
 NOP
 MOV.L    #H'00012F9A, R3
 JMP    @R3
 NOP
}


#pragma section IGNCODE //0x157B0
void ignmain(void)
{
	if ( killflag == ACTIVE) 
		if (igncut == ACTIVE)
		{
			ECU_IgnKillFlag = ECU_IgnKillFlag | IGNITIONCUTACTIVE;
		}
		
	jump_back_ign_loop();
}

#pragma section FUELCODE //0x15800
void fuelmain(void)
{
 	sub_0x00011E90();

	/*
		First time only initialization of internal variables.
	*/		
 	if (initialized != 1)
  		{
			killflag = DEACTIVE;
   			killswitch = DEACTIVE;
   			killcountactive= DEACTIVE;
   			initialized= 1;
			nt_6th_gearcount = killcountdelay;
			killcount = killcountdelay;
  		}


	/*
		Set internal variable killswitch status based on GPS sensor status.
		You may want to add conditions when	kill is not needed here including:
			- Clutch is depressed, no kill
			- Gear 6, no kill
			
		The GPS goes down and does not stabilise fast enough, some delay must be built
		for detecting the last gear.
		
		Also the actual kill time is calculated here as the each cycle this program
		is run is twice on every revolution we need to adjust the kill time
		to be independent of rpm.
	*/		
    if ( ECU_AD_GPS <=  SHIFTERACTIVE )
 		{
			if ((nt_6th_gear == 0) &&  (ECU_RPM > 0x1400)) //changed 11.8.2009 JaSa - old value 1E00
				{
			
	  				killswitch = ACTIVE;
					
					if (ECU_RPM > 0x7800) {duration_kill = const_killtime_12000;}
					else if (ECU_RPM > 0x6E00) {duration_kill = const_killtime_11000;}
					else if (ECU_RPM > 0x6400) {duration_kill = const_killtime_10000;}
					else if (ECU_RPM > 0x5A00) {duration_kill = const_killtime_9000;}
					else if (ECU_RPM > 0x5000) {duration_kill = const_killtime_8000;}
					else if (ECU_RPM > 0x4600) {duration_kill = const_killtime_7000;}
					else if (ECU_RPM > 0x3C00) {duration_kill = const_killtime_6000;}
					else if (ECU_RPM > 0x3200) {duration_kill = const_killtime_5000;}
					else if (ECU_RPM > 0x2800) {duration_kill = const_killtime_4000;}
					else if (ECU_RPM > 0x1E00) {duration_kill = const_killtime_3000;}
					else {duration_kill = const_killtime_2000;}

				}
 		}
 	else
 		{
  			killswitch = DEACTIVE;
			if (ECU_AD_GPS >= 0xF0)
				{
					nt_6th_gear = 1;
					nt_6th_gearcount = killcountdelay;
				}
			else
				{
					if (nt_6th_gearcount == 0)
						{
							nt_6th_gear = 0;
						}
					else
						{
							nt_6th_gearcount -= 1;
						}
				}
		}

	/*
		Main logic for processing fuel/ignitionkill function.
	*/
 	if( killflag == ACTIVE ) 
 		{
			/*
				Hold the killflag active until minimum duration of kill time is reached.
				When reaching the duration of kill time set kill deactive and set killcount
				to delay calculation mode that must be reached before next kill initialization. 
			*/
     		killcount += 1;          
     		if( killcount  >= duration_kill)
     			{
         			killflag = DEACTIVE;
         			killcount = killcountdelay; 
     			}
 		}
 	else                          
 		{
     		if( killcount > 0 )       
     			{
					/*
						Killswitch delay calculation mode, count from killcountdelay backwards
						waiting for the next killswitch cycle. The delay is calculated only 
						when killswitch is not depressed.
					*/
         			if( killswitch != ACTIVE )  
         				{
             				killcount -= 1 ;
         				}
     			}
     		else                   
     				{
					/*
						Killcount is zero, a new kill cycle can be initialized.
					*/
         			if( killswitch == ACTIVE )
         				{
             				killcountactive += 1;
             				if( killcountactive >= minkillactive )
								/* 
									If minimum killflag active time reached then activate kill
									and reset the killswitch counter back to zero.
								*/
			 					{
									killflag = ACTIVE;
           							killcount = 0;
	          					}
         				}
         			else
         				{
             				killcountactive = DEACTIVE; // pitäisikö tässä olla joku muukin muuttuja ?        
         				}
     				}
 		}

	/*
		Set the fuel and ignition CUT(s) on if KillFlag indicates that kill is active,
		remember that ECU parameters may contain some values that must be retained.
		You dont need to set variables inactive as ECU sets those already internally,
		while performing e.g. rev limiter etc checks.
	*/		
	if ( killflag == ACTIVE)
		if (fuelcut == ACTIVE)
		{
			ECU_FuelKillFlag = ECU_FuelKillFlag | FUELCUTACTIVE;
		}


	/*
	
	The pair valve solenoid output is reprogrammed as a rpm dependent output.
	First its tested that the normal PAIR control is disabled using ecu editor and
	if that is ok then the pair output is adjusted according to the RPM.
	
	Please note that there is something in the ECU code setting the pair output
	active before this program making an intermittent signal to pair output.
	
	*/
	
	if (ECU_PAIRDISABLED == 0x00)
		{
		if ((ECU_AD_GPS < 0xAA) && (s_GEAR12 < ECU_RPM)){ECU_PAIR = (ECU_PAIR & 0xFFEF);}
		else if ((ECU_AD_GPS < 0xF8) && (s_GEAR3456 < ECU_RPM)){ECU_PAIR = (ECU_PAIR & 0xFFEF);}
			else {ECU_PAIR = (ECU_PAIR | 0x10);}
		}

 	jump_back_fuel_loop();
}


