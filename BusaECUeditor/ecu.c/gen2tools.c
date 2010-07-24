/*

	gen2tools.c
	
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

	SIO2, TXD2 is connecte to P17, bit4. Normally that pin sends out the gaugedata to hayabusa gauge cluster
	anyhow this program just sets it low / high when errorcode is present.
	
*/

#define ECU_FI *(volatile unsigned char *)  		0x00806784
#define PORT1   *(volatile unsigned char *)  				0x00800701 // bit5=PAIR
#define PORT17   *(volatile unsigned char *)  				0x00800711 // bit5=PAIR

#define PAIR						0x20
#define TXD2						0x10


#pragma SECTION C PARAMS //0x59DC0
const short const_pgmid = 				100;			// 0 program id, must match to ecueditor version to be able to load this code to ecu
const char FI_LED_no_gauges = 0;

#pragma SECTION P TOOLSCODE //0x59E00
void toolsmain(void)
{

/*
	This algorithm sets the port to +5V when errorcode present in ecu
*/
if (FI_LED_no_gauges == 0)
{
	if ((ECU_FI & 0x1) != 0x1)
	{
		PORT1 = PORT1 | PAIR;
	}
	else
	{
		PORT1 = PORT1 & (0xFF - PAIR);	
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
