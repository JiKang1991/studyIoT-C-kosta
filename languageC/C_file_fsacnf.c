#include<stdio.h>
#include<io.h>
/* 파일 입출력 예제*/
int main() {
	char readFileBuf[256];
	
	// FILE구조체의 변수 선언 및 초기화
	// fopen(파일이름, 오픈모드); 
	FILE* fp = fopen("C:\\C_Class\\Week1\\data\\filetest.txt", "rb");
	
	for(int i = 0; i < 20; i++) {
	
	// 파일입력함수
	// fscanf(파일포인터);
	fscanf(fp, "%s", readFileBuf);
	printf("%s\n", readFileBuf);
	}
	
	
	// 파일종료함수
	// fclose(파일포인터); 
	fclose(fp); 
	
	
} 
