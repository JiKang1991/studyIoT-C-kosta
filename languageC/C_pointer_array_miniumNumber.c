#include<stdio.h>
/* 포인터와 배열 기초 예제 */

int getMinimumNumber(int *p, int count);
 
int main(void) {
	
	int inputedNumbers[5];
	int minimumNumber;
	
	printf("크기를 비교할 정수 5개를 입력하세요.\n");
	scanf("%d %d %d %d %d", &inputedNumbers[0], &inputedNumbers[1], &inputedNumbers[2],
		&inputedNumbers[3], &inputedNumbers[4]);
	
	printf("입력 받은 수 : ");
	for(int i = 0; i < 5; i++) {
		printf("%d ", inputedNumbers[i]);
	}
	
	
	minimumNumber = getMinimumNumber(inputedNumbers, 5);
	
	printf("\n입력된 숫자중 가장 작은 값은 %d입니다.\n", minimumNumber);
		
	/*
	for(int i = 0; i < 5; i++){
		printf("%d번째 수 : ", i);
		scanf("%d", &inputedNumbers[i]);
	}
	
	
	*/	
		
	/*
	printf("가장 작은 수는 : %d입니다.", minimumNumber);
	*/
	
}

int getMinimumNumber(int *inputedNumbers, int count) {
		
	int minimumNumber = *inputedNumbers;		// 배열의 첫번째 요소의 값 대입 
	printf("\n -------계산 완료--------\n");
	for(int i = 0; i < count; i++) {
	
		if(minimumNumber > *(inputedNumbers+i)) {
			minimumNumber = *(inputedNumbers+i);
		}	
		
		
		/*	위의 if문과 같다	
			if(minimumNumber > inputedNumbers[i]) {
				minimumNumber = inputedNumbers[i];
			}
		*/				
	}
	return minimumNumber;
}
