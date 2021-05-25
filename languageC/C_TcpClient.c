#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <netinet/in.h>
#include <arpa/inet.h>

// sockaddr_in을 Socket로 선언하여 활용할 수 있도록합니다.
typedef struct sockaddr_in Socket;

int main(){
	
	char buf[1024];
	scanf("%s", buf);
		
	// C에는 Socket Object가 존재하지 않습니다.
	// <netinet/in.h> 내에 sockaddr_in 구조체를 활용합니다.
	// struct sockaddr_in socket;
	Socket sock;
	// sockaddr_in 구조체의 필드입니다. struct 자료형이며 ip address를 저장합니다.
	sock.sin_addr = inet_addr("192.168.0.29");
	sock.sin_port = 9001;
	
	// AF_INET과 SOCK_STREAM은 <socket.h> 내에 정의되어 있습니다.
	int handle = socket(AF_INET,SOCK_STREAM, 0);
	
	connect(handle, &sock, sizeof(sock));
	send(handle, buf, strlen(buf), 0);
	//write(handle, buf, strlen(buf));
	//close(handle); 
}
