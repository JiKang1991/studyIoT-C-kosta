#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int prompt (char* pt, int* afterAToI);

int main(void) {
	
	int first;
	int second;
	int third;
	
	prompt("첫번째 값을 입력하세요 : ", &first);
	third = prompt("두번째 값을 입력하세요 : ", &second);
	
	printf("first : %d, second : %d, third : %d", first, second, third);
	
}

int prompt (char* pt, int* afterAToI) {
	char buf[254];
	printf("%s", pt);
	
	fgets(buf, sizeof(buf), stdin);
	
	*afterAToI = atoi(buf);
	
	return *afterAToI;
	
}
