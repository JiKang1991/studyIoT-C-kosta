#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <sys/socket.h> // socket();
#include <netinet/in.h>
#include <unistd.h> // close();

#include <pthread.h>
#include <wiringPi.h>

int PORT = 9001;

int sock, clientSock;
struct sockaddr_in sockInfo, clientSockInfo;
char buf[1024];

void* reciptProcess();

int main(){
	
	pthread_t reciptThread;
	
	sock = socket(AF_INET, SOCK_STREAM, 0);
	sockInfo.sin_family = AF_INET;
	// .sin_addr 은 또 하나의 구조체입니다. s_addr이라는 하나의 멤버를 가지고 있습니다.
	// htonl()
	// INADDR_ANY : 어디에서든 서버에 접속할 수 있음을 의미합니다.
	sockInfo.sin_addr.s_addr = htonl(INADDR_ANY);
	sockInfo.sin_port = htons(PORT);
	
	// 클라이언트 측의 connect()와 구조적으로 동일합니다.
	// 클라이언트의 접속을 대기하는 매서드입니다.
	bind(sock, (struct sockaddr*)&sockInfo, sizeof(sockInfo));
	
	// 두번째 매개변수는 accept횟수를 의미합니다.
	listen(sock, 100);
	
	int n = sizeof(clientSockInfo);
	
	// blocking 메소드입니다.
	// accept가 반환하는 소켓 핸들은 클라이언트의 소켓 핸들 입니다.
	// 세번째 매개변수는 주소값을 전달하도록 되어있습니다.
	clientSock = accept(sock, (struct sockaddr*)&clientSockInfo, &n);
	
	pthread_create(&reciptThread, NULL, reciptProcess, NULL);
	
	while(1){
		printf("Input text > ");
		scanf("%s", buf);
		if(buf[0] == 'q') break;
		send(clientSock, buf, strlen(buf), 0);
	}
	pthread_join(reciptThread, NULL);
	close(sock);
}

void* reciptProcess(){
	
	int i;
	char reciptBuf[1024];
	
	while(1){
		i = recv(clientSock, reciptBuf, sizeof(reciptBuf), 0);
		if(i > 0) {
			reciptBuf[i] = 0;
			// 상대방 Endpoint에서 q 입력시 스레드 종료
			if(reciptBuf[0] == 'q') break;
			printf("%s\n", reciptBuf);
		}
		delay(500);
	}
	return NULL;
}
