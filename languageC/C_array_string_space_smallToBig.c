#include <stdio.h>
/* 입력 받은 문자 띄어서 출력하기 & 입력받은 소문자 대문자로 변경하여 출력하기*/ 

void convertChr(char inputedString[]);

int main() {
	char inputedString[1024];
	
	printf("변경할 문자열을 입력하세요. : ");
	
	while(1) {
		
		scanf("%s", inputedString);
		
		printf("-- 변경 결과 --\n");
		
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
				printf("알파벳 소문자만 변경할 수 있습니다.");
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
	// 문자열 배열의 끝에는 0이 위치하므로 아래와 같은 조건식이 성립한다.  
	for(int i = 0; inputedString[i] != 0; i++){
		// char smallToBig = inputedString[i] | 0x20;	// 비트 연산을 적용한 방법	
				
		char smallToBig = inputedString[i];
		if(smallToBig > 96 && smallToBig < 123){
			smallToBig -= 32;
		} 
		printf("%c   ", smallToBig);
	}
}
