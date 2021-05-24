#include <stdio.h>
#include <wiringPi.h>
#include <wiringPiI2C.h>

short i2cInt16(int i2cHandle, int address);

int main(){
	
	int i2cAddress = 0x68;
	// MP6050 모듈에서는 데이터 제공방식으로 메모리 블럭을 제공합니다.
	// 메모리 블럭의 각 칸은 2byte로 구성되어있습니다.
	// 1byte 혹은 2byte로 데이터를 읽을 수 있습니다.
	// 메모리 블럭의 주소(메모리 블럭의 첫 번째 칸)는 0x3b입니다.
	int bufAddress = 0x3b;
	// power managiment address
	int pwrAddress = 0x6b;
		
	wiringPiSetup();
	int i2cHandle = wiringPiI2CSetup(i2cAddress);
	
	//wiringPiI2CWirteReg8()은 i2c 모듈에 데이터를 8bit로 작성하도록 하는 메소드 입니다.
	wiringPiI2CWriteReg8(i2cHandle, pwrAddress, 0);
	
	double x1, y1, z1, x2, y2, z2;
	
	// bufAddress는 char(1byte int) 형태입니다.
	// 1byte int가 표현할 수 있는 범위는 0 ~ 255 , -128 ~ 127
	// char 형태의 데이터를 연산하여 int 형태에 대입하면 오류가 발생할 가능성이 존재합니다.
	// wiringPiI2CReadReg8()의 리턴값은 char에 대입하는 것이 적합합니다.
	// wiringPiI2CReadReg16()의 리턴값은 short에 대입하는 것이 적합합니다.
	while(1){
		// bufAddress + 6에는 온도값이 저장되어있습니다.
		x1 = i2cInt16(i2cHandle, bufAddress) / 16384.;
		y1 = i2cInt16(i2cHandle, bufAddress + 2) / 16384.;
		z1 = i2cInt16(i2cHandle, bufAddress + 4) / 16384.;
		x2 = i2cInt16(i2cHandle, bufAddress + 8) / 131.;
		y2 = i2cInt16(i2cHandle, bufAddress + 10) / 131.;
		z2 = i2cInt16(i2cHandle, bufAddress + 12) / 131.;
		
		printf("x1 = %f, y1 = %f, z1 = %f, x2 = %f, y2 = %f, z2 = %f\n", x1, y1, z1, x2, y2, z2);
		delay(1000);
	}
}

short i2cInt16(int i2cHandle, int address){
	short value1 = wiringPiI2CReadReg8(i2cHandle, address);
	short value2 = wiringPiI2CReadReg8(i2cHandle, address+1);
	short finalValue = (value1 << 8) | value2; //value1 * 256 + d2;
	return finalValue;
}
