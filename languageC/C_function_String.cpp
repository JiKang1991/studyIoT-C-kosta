#include <stdio.h>
#include <string.h>
#include <stdlib.h>
/* ���ڿ� ���� �Լ� Ȱ�� ���� */
int main(void) {
	char numberArr[30];
	int afterAToI;
	
	fgets(numberArr, sizeof(numberArr), stdin);
	printf("�Էµ� �����Դϴ� : %s", numberArr);
	
	afterAToI = atoi(numberArr);
	printf("atoi�� ��ȯ�� �����Դϴ� : %d", afterAToI);
}
