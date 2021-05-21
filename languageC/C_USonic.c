#include <stdio.h>
#include <stdlib.h>
#include <wiringPi.h>


int main()
{
	int trigPinNum = 15;
	int echoPinNum = 16;
	
	wiringPiSetup();
	pinMode(trigPinNum, OUTPUT);	// 음파 신호 발생 핀
	pinMode(echoPinNum, INPUT);		// 반사 신호 검출 핀
	
	while(1){
		// 트리거 초기화 - 트리거 신호 발생의 초기 상태를 알 수 없으므로 LOW로 만들어 줍니다.
		digitalWrite(trigPinNum, LOW);
		delayMicroseconds(100);
		
		digitalWrite(trigPinNum, HIGH);	// 음파 신호 발생
		delayMicroseconds(10);			// 10 MicroSeconds trig signal
		digitalWrite(trigPinNum, LOW);	// 음파 신호 종료
		delayMicroseconds(200);			// 센서 스팩상 실제 신호 발생까지 지연시간이 필요합니다.
		
		while(digitalRead(echoPinNum) == LOW);	// until high
		// micros()는 현재 시간의 마이크로초 단위 카운트를 리턴합니다.
		long start = micros();
		while(digitalRead(echoPinNum) == HIGH);	// until low
		long end = micros();
		
		double dist = (end - start) * 0.17;
		
		printf("Distance : %f\n", dist);
		delay(1000);
	}	
}
