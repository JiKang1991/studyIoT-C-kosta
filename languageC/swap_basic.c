#include<stdio.h> 
/* swap(������ ��Ҹ� ��ȯ) ���� */

void swapInteger(int *a, int *b);

int main (void) {
	//	�ΰ��� ���� a�� b�� ��ȯ
	int a = 10;
	int b = 20;
	
	swapInteger(&a, &b);
	
	printf("----- swap �Ϸ� -----\n");
	printf("a = %d\nb = %d\n", a, b);
	
}

// �ΰ��� ������ swap�ϴ� �Լ�
void swapInteger(int* a, int* b) {
	
	int temp = *a;		// a�� ���� �ӽ÷� �����ϱ����� ���� 
	*a = *b;
	*b = temp;
}

void swapFloat(int* a, int* b ) {
	
	int temp = *a;		// a�� ���� �ӽ÷� �����ϱ����� ���� 
	*a = *b;
	*b = temp;
}

 
