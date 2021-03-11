#include<stdio.h>
/* 문자열 생성 및 출력 예제 */ 
int main() {
	char str1[5] = "Good";	// 정상적으로 초기화 
	char str2[]	= {'m', 'o', 'r', 'n', 'i', 'n', 'g'};	// 비정상적으로 초기화 
	
	printf("%s \n", str1);
	printf("%s %s \n", str1, str2); 
	
	return 0;
}
