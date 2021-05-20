#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <wiringPi.h>
#include <wiringPiI2C.h>
/**
 * 조도센서를 활용하여 led 밝기를 조절하는 예제 
 */
int main(int argc, char **argv)
{
	int channel = atoi(argv[1]);
	float sencerData;
	wiringPiSetup();
	pinMode(26, OUTPUT);
	
	if(argc < 2){
		printf("input channel plz");
	}
	
	int i2cHandle = wiringPiI2CSetup(0x48);
	
	wiringPiI2CWrite(i2cHandle, channel);
	wiringPiI2CRead(i2cHandle);
	//sencerData = wiringPiI2CRead(i2cHandle);
	//printf("%f", sencerData);
	
	while(1){
		sencerData = wiringPiI2CRead(i2cHandle);
		//printf("%f\n", sencerData);
		
		if(sencerData > 200){
			digitalWrite(26, HIGH);
		} else {
			digitalWrite(26, LOW);
		}
		delay(500);
	}
	
	return 0;
}

