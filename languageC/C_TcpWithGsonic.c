#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//#include <sys/socket.h>
#include <arpa/inet.h>	// inet_pton()
#include <fcntl.h>		// fcntl(), F_SETFL, O_NONBLOCK
#include <unistd.h>		// close()

#include <wiringPi.h>
#include <pthread.h>

char* IP = "192.168.0.29";
int PORT = 9001;

int socketHandle;

double getDistance(int trigPinNum, int echoPinNum);
void* readProcess();

int main(){

	int trigPinNum = 15;
	int echoPinNum = 16;
	
	
	struct sockaddr_in sockInfo;
	char buf[1024];
	int i, j, k;
	
	// Linux C에서는 thread 자료형의 선언을 pthread_t
	pthread_t readThread;
	
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
	
	pthread_create(&readThread, NULL, readProcess, NULL);
	
	while(1){
		double distance = getDistance(trigPinNum, echoPinNum);
		sprintf(buf, "%f\n", distance);
				
		send(socketHandle, buf, strlen(buf), 0);
		
		// printf() : console 출력
		// fprintf() : file 출력
		// sprintf() : 버퍼 출력 - 문자열의 마지막에 NULL 여부에 대한 체크가 필요합니다.		
		
		delay(2000);
	}
	pthread_join(readThread, NULL);
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

// 쓰레드의 기능을 정의하는 메서드는 리턴값으로 void포인터를 갖도록 약속되어있습니다.
void* readProcess(){
	int i;
	char buf[1024];
	while(1){
		i = recv(socketHandle, buf, sizeof(buf), 0);
		if(i > 0){
			buf[i] = 0;
			printf("%s\n", buf);
		}
		delay(2000);
	}
	return NULL;
}
