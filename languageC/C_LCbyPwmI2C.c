#include <stdio.h>
#include <stdlib.h>
// <wiringPi.h>는 wPi를 활용하기 위한 라이브러리 입니다.
#include <wiringPi.h>
#include <softPwm.h>
#include <wiringPiI2C.h>


int main(int argc, char **argv)
{
	if(argc < 2){
		printf("need to write pinNumber");
		return 0;
	}
	if(argc < 3){
		printf("need to wirte channel");
		return 0;
	}
	
	int pinNumber = atoi(argv[1]);
	int channel = atoi(argv[2]);
	int pwmRange = 200;
	float sencerData;
	
	wiringPiSetup();
	pinMode(pinNumber, OUTPUT);
	
	int i2cHandler = wiringPiI2CSetup(0x48);
	wiringPiI2CWrite(i2cHandler, channel);
	wiringPiI2CRead(i2cHandler);
	
	softPwmCreate(pinNumber, 0, pwmRange);
		
	while(1){		
		sencerData = wiringPiI2CRead(i2cHandler);
		softPwmWrite(pinNumber, sencerData);
		if(getchar() == 10){
			digitalWrite(pinNumber, LOW);
		}
		delay(50);
				
	}
	return 0;
}


