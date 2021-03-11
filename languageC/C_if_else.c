#include<stdio.h>
/* if else 문 예제*/
int main(){
	int startNum = 0;	// 시작 값 
	int endNum = 0;		// 종료 값 
	int oddSum = 0;		// 홀수 합 
	int evenSum = 0;	// 짝수 합 
	printf("시작 값과 종료 값을 적어주세요.\n");
	scanf("%d %d", &startNum, &endNum);
	
	printf("%d과 %d 사이의 5의 배수\n", startNum, endNum); 
	for(int i = startNum; i <= endNum; i++){
		if(i % 2 == 0){
			oddSum += i;	// i가 짝수일때 짝수 합 누적 
		} else {
			evenSum += i;	// i가 홀수일때 홀수 합 누적 
		}
		
		// i가 5의 배수일 경우 
		if(i % 5 == 0){
			printf("%5d", i); 
		}
	}
		
	printf("\n계산 완료!\n");
	printf("홀수 값의 합 : %d\n", oddSum);
	printf("짝수 값의 합 : %d\n", evenSum);
}
 
