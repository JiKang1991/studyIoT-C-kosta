#include <stdio.h>
// <wiringPi.h>는 wPi를 활용하기 위한 라이브러리 입니다.
#include <wiringPi.h>


int main(int argc, char **argv)
{
	
	// wiringPiSetup()는 <wiringPi.h>를 초기화 합니다.
	wiringPiSetup();
	
	// 사용할 pin의 용도를 설정합니다.(input, output)
	// 브레드 보드와 연결하여 사용할 pin은 wPi 번호 8번을 가지고 있습니다.

	pinMode(26, OUTPUT);
	int onOff = 0;
	while(1){		
		if(getchar() == 10){
			
			if(onOff == 0){
				// pin을 통해 출력할 출력문을 
				// HIGH : ON(5V)를 의미합니다.
				// LOW : OFF(0V or GND)를 의미합니다.
				digitalWrite(26, HIGH);
				onOff++;
			}
			else{
				digitalWrite(26, LOW);
				onOff--;
			}			
		}
		
		
	}
	return 0;
}

