#include <stdio.h>

int main(){
	
	char str[6] = "Hello";
	
	printf("--���� �� ���ڿ�--\n");
	printf("%s \n", str);
	
	for(int i = 0; i < 6; i++) {
		printf("%c", str[i]);
	}
	
	/* ���ڿ� ���� */
	for(int i = 0; i < 3; i++) {
		char temp;
		temp = str[4-i];
		printf("%c�� temp�� ����\n", str[4-i]);
		str[4-i] = str[i];
		printf("str[%d]�� %c�� str[%d]�� ����\n", i, str[i], 4 - i);
		str[i] = temp;
		printf("temp�� %c�� str[%d]�� ����\n", temp, i);
	} 
	
	printf("\n\n--���� �� ���ڿ�--\n");
	printf("%s \n", str);
	return 0;
} 
