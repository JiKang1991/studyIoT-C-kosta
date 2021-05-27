#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <sys/socket.h>
#include <arpa/inet.h>
#include <unistd.h>

char* IP = "192.168.0.29";
int PORT = 9200;

struct sockaddr_in udp_socket_info;
int socket_handle;

int main(){
	char buf[512];
	
	// 첫번째 매개변수 AddressFamily InterNetwork
	// TCP = SOCK_STREAM   UDP = SOCK_DGRAM
	socket_handle = socket(AF_INET, SOCK_DGRAM, 0);
	udp_socket_info.sin_family = AF_INET;
	inet_pton(AF_INET, IP, &udp_socket_info.sin_addr.s_addr);
	udp_socket_info.sin_port = htons(PORT);
	
	// udp는 connect과정이 존재하지 않습니다.
	
	while(1){
		printf("Input text > ");
		scanf("%s", buf);
		if(buf[0] == 'q') break;
		// send()는 tcp에서 사용합니다.
		//send(socket_handle, buf, strlen(buf), 0);
		// udp에서는 sendto()를 사용합니다 소켓 정보와 크기가 매개변수로 추가됩니다.
		sendto(socket_handle, buf, strlen(buf), 0, (struct sockaddr*)&udp_socket_info, sizeof(udp_socket_info));		
		
	}
	close(socket_handle);
}
