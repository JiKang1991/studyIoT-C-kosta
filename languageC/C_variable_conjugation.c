#include<stdio.h>
/* 변수 활용 예제(합 계산기)*/ 
int main(void){
	int a, b;
	int result;
	
	a = 10;
	b = 20;
	
	result = a + b;
	
	printf("덧셈 결과 : %d \n", result);
	printf("%d 더하기 %d는 %d 입니다. \n", a, b, result);
	
	return 0;
} 
