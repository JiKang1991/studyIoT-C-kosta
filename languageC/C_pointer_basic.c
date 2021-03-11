#include<stdio.h>
/* 포인터 기초 예제 */ 
int main(void) {
	
	int a = 2005;
	int b = 2021;
	int* pA = &a;
	void* voidPointer;
	
	printf("pA : %d(10진수), %08x(16진수)\n", pA, pA);		// %08x : 8자리의 16진수 표기, 빈공간은 0으로 채움
	printf("pA : %d(10진수), %08x(16진수)\n", &a, &a);
	
	(*pA)++;	// a++ 와 같은 의미를 지닌다
	
	printf("a	: %d \n", a);
	printf("*pA	: %d \n", *pA);
	
	
	voidPointer = pA++;						// pA의 값을 증가시키기 전에 voidPointer에 대입한다. 
	printf("pA : %08x \n", pA);
	printf("*pA	: %d \n", *pA);
	printf("voidPointer : %08x \n", voidPointer++);
	// void pointer의 경우 데이터 형이 정해져 있지 않기 때문에
	// ++ 할 경우 1의 값이 증가한다. 
	printf("voidPointer : %08x \n", voidPointer);  
	 
} 
