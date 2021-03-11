#include<stdio.h>
/* 포인터 활용 예제 */
int main(){
	int a[3][2] = {
		{1, 2},
		{3, 4},
		{5, 6}
	};
	
	printf("a[0]	: %d \n", a[0]);
	printf("*(a+0)	: %d \n", *(a+0));
		
	printf("a[1]	: %d \n", a[1]);
	printf("*(a+1)	: %d \n", *(a+1));
	
	printf("a[2]	: %d \n", a[2]);
	printf("*(a+2)	: %d \n", *(a+2));
	
	printf("%d, %d \n", a[1][0], (*(a+1))[0]);
	printf("%d, %d \n", a[1][2], *(a[1]+2));
	printf("%d, %d \n", a[2][1], *(*(a+2)+1));
	
	return 0;
	
} 

// a[0] 은 a[0][0]의 주소값을 의미한다. 
//  
