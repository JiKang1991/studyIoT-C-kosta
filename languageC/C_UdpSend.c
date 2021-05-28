#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include <sys/socket.h>
#include <arpa/inet.h> // inet_pton()
#include <unistd.h>

struct sockaddr_in udp_socket_info;
int socket_handle;

int main(int argc, char** argv){ // udpSend <192.xxx.xxx.xx> <port_no> <filePath>
	
	char* ip = argv[1];
	int port = atoi(argv[2]);
	//int port = 9001;
	char* filePath = argv[3];

	char buf[512];
	printf("%s %s %s", argv[1], argv[2], argv[3]);
	socket_handle = socket(AF_INET, SOCK_DGRAM, 0);
	
	udp_socket_info.sin_family = AF_INET;
	inet_pton(AF_INET, ip, &udp_socket_info.sin_addr.s_addr);
	udp_socket_info.sin_port = htons(port);
	printf("111");
	// b : bianry와 t: text의 가장 큰 차이는 개행문자(\n)의 처리에 있습니다.
	// bianry의 경우 있는 그대로를 읽어옵니다.
	FILE* fp = fopen(filePath, "rb");	

	while(fgets(buf, 512, fp)){	
	printf("...");
	sendto(socket_handle, buf, strlen(buf), 0, (struct sockaddr*)&udp_socket_info, sizeof(udp_socket_info));		
	sendto(socket_handle, "\r\n", 2, 0, (struct sockaddr*)&udp_socket_info, sizeof(udp_socket_info));
	}
	fclose(fp);
	close(socket_handle);
}
