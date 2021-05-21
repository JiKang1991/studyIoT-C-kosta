#include <stdio.h>
#include <stdlib.h>
// <wiringPi.h>는 wPi를 활용하기 위한 라이브러리 입니다.
#include <wiringPi.h>
#include <softPwm.h>


int main(int argc, char **argv)
{
	if(argc < 2){
		printf("need to write pinNumber");
		return 0;
	}
	int pinNumber = atoi(argv[1]);
	int pwmRange = 100;
	// wiringPiSetup()는 <wiringPi.h>를 초기화 합니다.
	wiringPiSetup();
	
	// 사용할 pin의 용도를 설정합니다.(input, output)
	// 브레드 보드와 연결하여 사용할 pin은 wPi 번호 26번을 가지고 있습니다.
	pinMode(pinNumber, OUTPUT);
	// softPwmCreate(핀넘버, 초기값, range)
	softPwmCreate(pinNumber, 0, pwmRange);
	 
	int onOff = 0;
	while(1){		
		if(getchar() == 10){
			if(onOff == 0){
				for(int i = 0; i <= pwmRange; i++){
					softPwmWrite(pinNumber, i);
					delay(50);
				}
				onOff++;
			}
			else{
				for(int i = pwmRange; i >= 0; i--){
					softPwmWrite(pinNumber, i);
					delay(50);
				}
				onOff--;
			}			
		}
		
		
	}
	return 0;
}
