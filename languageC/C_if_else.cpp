#include<stdio.h>
/* if else �� ����*/
int main(){
	int startNum = 0;	// ���� �� 
	int endNum = 0;		// ���� �� 
	int oddSum = 0;		// Ȧ�� �� 
	int evenSum = 0;	// ¦�� �� 
	printf("���� ���� ���� ���� �����ּ���.\n");
	scanf("%d %d", &startNum, &endNum);
	
	printf("%d�� %d ������ 5�� ���\n", startNum, endNum); 
	for(int i = startNum; i <= endNum; i++){
		if(i % 2 == 0){
			oddSum += i;	// i�� ¦���϶� ¦�� �� ���� 
		} else {
			evenSum += i;	// i�� Ȧ���϶� Ȧ�� �� ���� 
		}
		
		// i�� 5�� ����� ��� 
		if(i % 5 == 0){
			printf("%5d", i); 
		}
	}
		
	printf("\n��� �Ϸ�!\n");
	printf("Ȧ�� ���� �� : %d\n", oddSum);
	printf("¦�� ���� �� : %d\n", evenSum);
}
 
