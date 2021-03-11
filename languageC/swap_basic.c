#include<stdio.h> 
/* swap(변수의 요소를 교환) 예제 */

void swapInteger(int *a, int *b);

int main (void) {
	//	두개의 변수 a와 b의 교환
	int a = 10;
	int b = 20;
	
	swapInteger(&a, &b);
	
	printf("----- swap 완료 -----\n");
	printf("a = %d\nb = %d\n", a, b);
	
}

// 두개의 변수를 swap하는 함수
void swapInteger(int* a, int* b) {
	
	int temp = *a;		// a의 값을 임시로 저장하기위한 변수 
	*a = *b;
	*b = temp;
}

void swapFloat(int* a, int* b ) {
	
	int temp = *a;		// a의 값을 임시로 저장하기위한 변수 
	*a = *b;
	*b = temp;
}

 
