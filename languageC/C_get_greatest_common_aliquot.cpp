#include<stdio.h>
/* 최대 공약수 출력 예제 */ 

int getAliquot(int inputedNum, int* aliquotArr);
int getGCA(int firstNum, int secondNum);
int getGCA2(int* firstAliquotArr, int* secondAliquotArr,
	int firstArrIndex, int secondArrIndex);

int main(void) {
	int firstNum;							// 첫 번째 수를 저장할 변수 
	int secondNum;							// 두 번째 수를 저장할 변수 
	int firstAliquotArr[100];			// 첫 번째 수의 약수를 저장할 배열 
	int secondAliquotArr[100];		// 두 번째 수의 약수를 저장할 배열 
	int firstArrIndex;
	int secondArrIndex;
	int maxNum;
	
	printf("최대 공약수를 계산할 두개의 수를 입력해주세요. : ");
	scanf("%d %d", &firstNum, &secondNum);
	
	// getAliquot함수로 각 수의 약수를 구한다. 
	firstArrIndex = getAliquot(firstNum, firstAliquotArr);
	printf("firstArrIndex : %d \n", firstArrIndex);
	
	secondArrIndex = getAliquot(secondNum, secondAliquotArr); 
	printf("secondArrIndex : %d \n", secondArrIndex);
	
	// 첫 번째 수의 약수
	printf("%d의 약수 : ", firstNum); 
	for(int i = 0; i < firstArrIndex; i++) {
		printf("%d ", firstAliquotArr[i]);
	} 
	printf("\n");

	// 두 번째 수의 약수
	printf("%d의 약수 : ", secondNum); 
	for(int i = 0; i < secondArrIndex; i++) {
		printf("%d ", secondAliquotArr[i]);
	} 
	printf("\n");
	
	maxNum = getGCA2(firstAliquotArr, secondAliquotArr, firstArrIndex, secondArrIndex);
	
	printf("%d와 %d의 최대 공약수는 %d 입니다.\n", firstNum, secondNum, maxNum); 
}

int getAliquot(int inputedNum, int* aliquotArr) {
	
	int arrIndex = 0;
	for(int i = 1; i <= inputedNum; i++){
		if(inputedNum % i == 0) {
			
			*(aliquotArr+arrIndex) = i;
			arrIndex++;
						
			/*
				aliquotArr[arrIndex] = i;
				arrIndex++;
			*/
		}
	}
	return arrIndex;	// 배열의 개수 만큼만 출력하기위해 인덱스를 리턴한다.	
}

int getGCA2(int* firstAliquotArr,int* secondAliquotArr, int firstArrIndex, int secondArrIndex) {
				
		for(int i = firstArrIndex - 1; i >= 0; i--) {
			for(int j = 0; j < secondArrIndex; j++) {
				if(*(firstAliquotArr+i) == *(secondAliquotArr+i)){
					return *(firstAliquotArr+i);
				}
			}
		}
		return -1;	// 오류 발생 여부를 호출측에 알린다. 
}
/*
int getGCA(int firstNum, int secondNum) {
	for(int i = firstNum; i >= 1; i--) {
		if(firstNum % i == 0 && secondNum % i == 0){
			return i;
		}
	}
}
*/
