#include <stdio.h>
#include <wiringPi.h>
#include <wiringPiI2C.h>
#include <string.h>
#include <stdlib.h>

// ./i2cTest 1 2 3  -> argc : 4, argv = { "i2cTest", "1", "2", "3"}
int main(int argc, char* argv[]){
	
	float senserData;
	int channel = atoi(argv[1]);
	
	if(argc < 2){
		printf("\nUsage : %s AIN_no \n\n", argv[0]);
		return 0;
	}	
	/*
	//strcmp(문자열1, 문자열2)은 문자열1이 문자열 2보다 크면 -1, 같으면 0, 작으면 1을 반환합니다.
	if(strcmp(argv[1], "0") == 0){
		printf("illumination sencer");
		channel = 0;
	}
	if(strcmp(argv[1], "1") == 0){
		printf("temperature sencer");
		channel = 1;
	}
	if(strcmp(argv[1], "3") == 0){
		printf("power sencer");
		channel = 3;
	}
	*/
	// wiringPiI2CSetup()은 I2C 모듈의 Handle을 반환합니다. 
	// 오류 발생시 -1을 반환합니다.
	int i2cHandle = wiringPiI2CSetup(0x48);
		
	// i2cHandle은 모듈 특성상 4개의 센서(채널)을 가지고 있습니다.
	// 사전에 어떤 채널을 사용할 것인지 wiringPiI2CWrite()로 명시해야 합니다.
	wiringPiI2CWrite(i2cHandle, channel);
	wiringPiI2CRead(i2cHandle);
	
	while(1){
		// wiringPiI2CRead()은 float 자료형을 리턴합니다.
		senserData = wiringPiI2CRead(i2cHandle);
		printf("%f\n", senserData);
		
		delay(2000);
	}
}
