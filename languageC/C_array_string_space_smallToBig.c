#include <stdio.h>
/* �Է� ���� ���� �� ����ϱ� & �Է¹��� �ҹ��� �빮�ڷ� �����Ͽ� ����ϱ�*/ 

void convertChr(char inputedString[]);

int main() {
	char inputedString[1024];
	
	printf("������ ���ڿ��� �Է��ϼ���. : ");
	
	while(1) {
		
		scanf("%s", inputedString);
		
		printf("-- ���� ��� --\n");
		
		convertChr(inputedString);
		
		/*
		for(int i = 0; i < 1024; i++) {
			if(inputedString[i] == 0){
				break;
			}
			printf("%c ", inputedString[i]);
		} 
		
		printf("\n\n");
		*/		
		 
		/*
		for(int i = 0; i < 1024; i++) {
			if(inputedString[i] < 'a' && inputedString[i] > 'z'){
				printf("���ĺ� �ҹ��ڸ� ������ �� �ֽ��ϴ�.");
				break; 
			} else {
				if(inputedString[i] == 0){
				break;
				}
				printf("%c", inputedString[i] - 32);
			}
			
		}
		*/
	}
} 

void convertChr(char inputedString[]){
	// ���ڿ� �迭�� ������ 0�� ��ġ�ϹǷ� �Ʒ��� ���� ���ǽ��� �����Ѵ�.  
	for(int i = 0; inputedString[i] != 0; i++){
		// char smallToBig = inputedString[i] | 0x20;	// ��Ʈ ������ ������ ���	
				
		char smallToBig = inputedString[i];
		if(smallToBig > 96 && smallToBig < 123){
			smallToBig -= 32;
		} 
		printf("%c   ", smallToBig);
	}
}
