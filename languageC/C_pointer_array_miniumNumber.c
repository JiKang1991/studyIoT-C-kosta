#include<stdio.h>
/* �����Ϳ� �迭 ���� ���� */

int getMinimumNumber(int *p, int count);
 
int main(void) {
	
	int inputedNumbers[5];
	int minimumNumber;
	
	printf("ũ�⸦ ���� ���� 5���� �Է��ϼ���.\n");
	scanf("%d %d %d %d %d", &inputedNumbers[0], &inputedNumbers[1], &inputedNumbers[2],
		&inputedNumbers[3], &inputedNumbers[4]);
	
	printf("�Է� ���� �� : ");
	for(int i = 0; i < 5; i++) {
		printf("%d ", inputedNumbers[i]);
	}
	
	
	minimumNumber = getMinimumNumber(inputedNumbers, 5);
	
	printf("\n�Էµ� ������ ���� ���� ���� %d�Դϴ�.\n", minimumNumber);
		
	/*
	for(int i = 0; i < 5; i++){
		printf("%d��° �� : ", i);
		scanf("%d", &inputedNumbers[i]);
	}
	
	
	*/	
		
	/*
	printf("���� ���� ���� : %d�Դϴ�.", minimumNumber);
	*/
	
}

int getMinimumNumber(int *inputedNumbers, int count) {
		
	int minimumNumber = *inputedNumbers;		// �迭�� ù��° ����� �� ���� 
	printf("\n -------��� �Ϸ�--------\n");
	for(int i = 0; i < count; i++) {
	
		if(minimumNumber > *(inputedNumbers+i)) {
			minimumNumber = *(inputedNumbers+i);
		}	
		
		
		/*	���� if���� ����	
			if(minimumNumber > inputedNumbers[i]) {
				minimumNumber = inputedNumbers[i];
			}
		*/				
	}
	return minimumNumber;
}
