#include<stdio.h>
/* ������ ���� ���� */ 
int main(void) {
	
	int a = 2005;
	int b = 2021;
	int* pA = &a;
	void* voidPointer;
	
	printf("pA : %d(10����), %08x(16����)\n", pA, pA);		// %08x : 8�ڸ��� 16���� ǥ��, ������� 0���� ä��
	printf("pA : %d(10����), %08x(16����)\n", &a, &a);
	
	(*pA)++;	// a++ �� ���� �ǹ̸� ���Ѵ�
	
	printf("a	: %d \n", a);
	printf("*pA	: %d \n", *pA);
	
	
	voidPointer = pA++;						// pA�� ���� ������Ű�� ���� voidPointer�� �����Ѵ�. 
	printf("pA : %08x \n", pA);
	printf("*pA	: %d \n", *pA);
	printf("voidPointer : %08x \n", voidPointer++);
	// void pointer�� ��� ������ ���� ������ ���� �ʱ� ������
	// ++ �� ��� 1�� ���� �����Ѵ�. 
	printf("voidPointer : %08x \n", voidPointer);  
	 
} 
