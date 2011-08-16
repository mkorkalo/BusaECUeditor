#define CLUTCH 	*(volatile unsigned short *)			0x0080651C
#define ECU_RPM *(volatile unsigned short *)  			0x0080502E
#define ECU_GPS	*(volatile unsigned char *)  			0x008050B3
#define PORT1   *(volatile unsigned char *)  			0x00800701 // bit5=PAIR
#define PAIR											0x20

#pragma SECTION C PARAMS //0x55400
const unsigned short launchRpm 		= 		0x1F40; //  8000
const unsigned short gear1ShiftRpm 	= 		0x2904; // 10500
const unsigned short gear2ShiftRpm 	= 		0x2904; // 10500
const unsigned short gear3ShiftRpm 	= 		0x2904; // 10500
const unsigned short gear4ShiftRpm 	= 		0x2904; // 10500
const unsigned short gear5ShiftRpm 	= 		0x2904; // 10500

#pragma SECTION P SHIFTLIGHTCODE
void ShiftLight(void)
{
	if(ECU_GPS == 1
		&& (CLUTCH & 1) == 1
		&& ECU_RPM >= launchRpm)
	{// Gear 1 + Clutch In => Launch Light
		PORT1 = PORT1 | PAIR;
	}
	else if(ECU_GPS == 1
		&& ECU_RPM >= gear1ShiftRpm)
	{// Gear 1 Shift Light
		PORT1 = PORT1 | PAIR;
	}
	else if(ECU_GPS == 2
		&& ECU_RPM >= gear2ShiftRpm)
	{// Gear 2 Shift Light
		PORT1 = PORT1 | PAIR;
	}
	else if(ECU_GPS == 3
		&& ECU_RPM >= gear3ShiftRpm)
	{// Gear 3 Shift Light
		PORT1 = PORT1 | PAIR;
	}
	else if(ECU_GPS == 4
		&& ECU_RPM >= gear4ShiftRpm)
	{// Gear 4 Shift Light
		PORT1 = PORT1 | PAIR;
	}
	else if(ECU_GPS == 5
		&& ECU_RPM >= gear5ShiftRpm)
	{// Gear 5 Shift Light
		PORT1 = PORT1 | PAIR;
	}
	else
	{// Not over Shift or Launch Light RPM -> Turn off Port 1
		PORT1 = PORT1 & (0xFF - PAIR);	
	}
}