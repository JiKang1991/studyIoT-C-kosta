#include<stdio.h>
/* ���ڿ� ���� �� ��� ���� */ 
int main() {
	char str1[5] = "Good";	// ���������� �ʱ�ȭ 
	char str2[]	= {'m', 'o', 'r', 'n', 'i', 'n', 'g'};	// ������������ �ʱ�ȭ 
	
	printf("%s \n", str1);
	printf("%s %s \n", str1, str2); 
	
	return 0;
}
