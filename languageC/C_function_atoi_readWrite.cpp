#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int prompt (char* pt, int* afterAToI);

int main(void) {
	
	int first;
	int second;
	int third;
	
	prompt("ù��° ���� �Է��ϼ��� : ", &first);
	third = prompt("�ι�° ���� �Է��ϼ��� : ", &second);
	
	printf("first : %d, second : %d, third : %d", first, second, third);
	
}

int prompt (char* pt, int* afterAToI) {
	char buf[254];
	printf("%s", pt);
	
	fgets(buf, sizeof(buf), stdin);
	
	*afterAToI = atoi(buf);
	
	return *afterAToI;
	
}
