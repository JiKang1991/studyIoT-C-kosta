#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <sys/socket.h>
#include <arpa/inet.h>
#include <fcntl.h>

char* IP = "192.168.0.29";
int PORT = 9001;

int main(){
	
	int socketHandle; // socket handle을 대입하는 변수입니다.
	
	// 주소를 저장하거나 표현하는데 사용하는 구조체입니다.
	// 주소체계가 AF_INET인 경우 사용합니다.
	struct sockaddr_in sockInfo; 
	char buf[1024];
	int i, j, k;
	
	// AF_INET은 주소체계 유형을 의미합니다.
	// socket()은 socket handle을 리턴하는 메서드입니다.
	socketHandle = socket(AF_INET, SOCK_STREAM, 0);	
	
	// sockaddr_in이므로 주소 체계를 저장하는 sin_family 필드에는 항상 AF_INET를 설정합니다.
	sockInfo.sin_family = AF_INET;
	
	// inet_pton()은 char* 형태의 ip주소를 binary형태로 변환합니다.
	// 두번째 매개변수의 값을 변환하여 세번째 매개변수가 참조하는 메모리에 대입합니다. 
	// 정산적으로 변환되었을 경우 1을 반환합니다.
	inet_pton(AF_INET, IP, &sockInfo.sin_addr.s_addr);
	
	// .sin_port는 포트 번호를 대입하는 필드입니다.
	sockInfo.sin_port = htons(PORT);
	
	connect(socketHandle, (struct sockaddr*)&sockInfo, sizeof(sockInfo));
	// 소켓 플래그를 설정합니다.
	// 블러킹 모드의 receive를 non blocking으로 설정합니다.
	k = fcntl(socketHandle, F_SETFL, 0);
	fcntl(socketHandle, F_SETFL, k | O_NONBLOCK);
	while(1){
		scanf("%s", buf);
		if(buf[0] == 'q') break;
		send(socketHandle, buf, strlen(buf), 0);
		i = recv(socketHandle, buf, sizeof(buf), 0);
		if(i > 0) buf[i] = 0;
		if(buf[0] == 'q') break;
		printf("%s\n", buf);
	}
	close(socketHandle);
}
