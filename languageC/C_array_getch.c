#include<stdio.h>
#include<conio.h>

void changeToChar(char *inputedString, int inputedNum);

int main(){
	char inputedString[1024];
	
	
	scanf("%s", inputedString);		// [Enter] 키를 눌러서 값을 되돌림
	printf("입력 문자열은 %s 입니다 \n\n\n\n", inputedString);	
	
	while(1){
		char inputedNum = getch();		// 단일 키값을 되돌림.
		// 숫자키 이외의 키는 종료 
		if(inputedNum < 49 || inputedNum > 57){
			break;
		}		
		changeToChar(inputedString, inputedNum - 49); // inputedNum - 49 : 숫자 키값을 인덱스 값으로 변환  
	}
}

void changeToChar(char *inputedString, int inputedNum) {
	printf("%s (%d) ---> %c\n\n", inputedString, inputedNum+1, *(inputedString+inputedNum));
}


