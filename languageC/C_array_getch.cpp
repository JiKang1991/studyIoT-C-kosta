#include<stdio.h>
#include<conio.h>

void changeToChar(char *inputedString, int inputedNum);

int main(){
	char inputedString[1024];
	
	
	scanf("%s", inputedString);		// [Enter] Ű�� ������ ���� �ǵ���
	printf("�Է� ���ڿ��� %s �Դϴ� \n\n\n\n", inputedString);	
	
	while(1){
		char inputedNum = getch();		// ���� Ű���� �ǵ���.
		// ����Ű �̿��� Ű�� ���� 
		if(inputedNum < 49 || inputedNum > 57){
			break;
		}		
		changeToChar(inputedString, inputedNum - 49); // inputedNum - 49 : ���� Ű���� �ε��� ������ ��ȯ  
	}
}

void changeToChar(char *inputedString, int inputedNum) {
	printf("%s (%d) ---> %c\n\n", inputedString, inputedNum+1, *(inputedString+inputedNum));
}


