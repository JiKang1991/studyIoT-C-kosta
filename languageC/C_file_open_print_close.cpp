#include<stdio.h>
#include<io.h>
/* 파일 입출력 예제*/
int main() {
	// FILE구조체의 변수 선언 및 초기화
	// fopen(파일이름, 오픈모드); 
	FILE* fp = fopen("filetest.txt", "ab");
	
	// 파일출력함수
	// fprintf(파일포인터, 출력내용); 
	fprintf(fp, "File open write close test");
	
	// 파일종료함수
	// fclose(파일포인터); 
	fclose(fp); 
} 
