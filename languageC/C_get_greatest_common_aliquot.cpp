#include<stdio.h>
/* �ִ� ����� ��� ���� */ 

int getAliquot(int inputedNum, int* aliquotArr);
int getGCA(int firstNum, int secondNum);
int getGCA2(int* firstAliquotArr, int* secondAliquotArr,
	int firstArrIndex, int secondArrIndex);

int main(void) {
	int firstNum;							// ù ��° ���� ������ ���� 
	int secondNum;							// �� ��° ���� ������ ���� 
	int firstAliquotArr[100];			// ù ��° ���� ����� ������ �迭 
	int secondAliquotArr[100];		// �� ��° ���� ����� ������ �迭 
	int firstArrIndex;
	int secondArrIndex;
	int maxNum;
	
	printf("�ִ� ������� ����� �ΰ��� ���� �Է����ּ���. : ");
	scanf("%d %d", &firstNum, &secondNum);
	
	// getAliquot�Լ��� �� ���� ����� ���Ѵ�. 
	firstArrIndex = getAliquot(firstNum, firstAliquotArr);
	printf("firstArrIndex : %d \n", firstArrIndex);
	
	secondArrIndex = getAliquot(secondNum, secondAliquotArr); 
	printf("secondArrIndex : %d \n", secondArrIndex);
	
	// ù ��° ���� ���
	printf("%d�� ��� : ", firstNum); 
	for(int i = 0; i < firstArrIndex; i++) {
		printf("%d ", firstAliquotArr[i]);
	} 
	printf("\n");

	// �� ��° ���� ���
	printf("%d�� ��� : ", secondNum); 
	for(int i = 0; i < secondArrIndex; i++) {
		printf("%d ", secondAliquotArr[i]);
	} 
	printf("\n");
	
	maxNum = getGCA2(firstAliquotArr, secondAliquotArr, firstArrIndex, secondArrIndex);
	
	printf("%d�� %d�� �ִ� ������� %d �Դϴ�.\n", firstNum, secondNum, maxNum); 
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
	return arrIndex;	// �迭�� ���� ��ŭ�� ����ϱ����� �ε����� �����Ѵ�.	
}

int getGCA2(int* firstAliquotArr,int* secondAliquotArr, int firstArrIndex, int secondArrIndex) {
				
		for(int i = firstArrIndex - 1; i >= 0; i--) {
			for(int j = 0; j < secondArrIndex; j++) {
				if(*(firstAliquotArr+i) == *(secondAliquotArr+i)){
					return *(firstAliquotArr+i);
				}
			}
		}
		return -1;	// ���� �߻� ���θ� ȣ������ �˸���. 
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
