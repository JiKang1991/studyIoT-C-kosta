#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//#include <sys/socket.h>
#include <arpa/inet.h>	// inet_pton()
#include <fcntl.h>		// fcntl(), F_SETFL, O_NONBLOCK
#include <unistd.h>		// close()

#include <wiringPi.h>

char* IP = "192.168.0.29";
int PORT = 9001;

double getDistance(int trigPinNum, int echoPinNum);

int main(){

	int trigPinNum = 15;
	int echoPinNum = 16;
	
	int socketHandle;
	struct sockaddr_in sockInfo;
	char buf[1024];
	int i, j, k;
	
	wiringPiSetup();
	pinMode(trigPinNum, OUTPUT);
	pinMode(echoPinNum, INPUT);
	
	socketHandle = socket(AF_INET, SOCK_STREAM, 0);
	sockInfo.sin_family = AF_INET;
	inet_pton(AF_INET, IP, &sockInfo.sin_addr.s_addr);
	sockInfo.sin_port = htons(PORT);
	
	connect(socketHandle, (struct sockaddr*)&sockInfo, sizeof(sockInfo));
	
	k =fcntl(socketHandle, F_SETFL, 0);
	fcntl(socketHandle, F_SETFL, k | O_NONBLOCK);
	
	while(1){
		double distance = getDistance(trigPinNum, echoPinNum);
		sprintf(buf, "%f\n", distance);
		//printf("Distance : %f\n", distance);
		//buf = Encoding.Default.getbyte(distance);
		
		send(socketHandle, buf, strlen(buf), 0);
		i = recv(socketHandle, buf, sizeof(buf), 0);
		// printf() : console 출력
		// fprintf() : file 출력
		// sprintf() : 버퍼 출력 - 문자열의 마지막에 NULL 여부에 대한 체크가 필요합니다.
		// sprintf(buf, "%s\n", buf);
		
		delay(2000);
	}
	close(socketHandle);
}

double getDistance(int trigPinNum, int echoPinNum){
	
	digitalWrite(trigPinNum, LOW);
	delayMicroseconds(100);
	
	digitalWrite(trigPinNum, HIGH);
	delayMicroseconds(10);
	digitalWrite(trigPinNum, LOW);
	delayMicroseconds(200);
	
	while(digitalRead(echoPinNum) == LOW);
	long start = micros();
	while(digitalRead(echoPinNum) == HIGH);
	long end = micros();
	
	double distance = (end - start) * 0.17;
	
	return distance;
}
