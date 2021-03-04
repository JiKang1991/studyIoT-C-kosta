#include<stdio.h>
// textType 함수 프로토타입또는 본체가 선언되어있는 header 파일
// 사용자 임의의 헤더파일을 include할 때에는 쌍따옴표를 사용한다.
// 이러한 방식은 함수를 재사용 할 수 있다는 장점이 있다. 
#include"C_function_textType_header.h"

//void textType(int key);

int main(){
	int key;		// 입력 받은 키 값을 저장하기 위한 변수 선언 
		
	printf("타입을 확인하고자 하는 한 개의 키를 입력하고 Enter를 눌러주세요.(공백(space)입력시 프로그램 종료) : ");
	
	while(1){
			
		// %c : 단일 문자 %s : 문자열 
		scanf("%c", &key);		// 한 문자를 입력 받음
		// scanf 함수는 [Enter] 키로 입력의 끝을 검사하기 때문에
		// 단일 문자 처리시 두번 입력으로 처리한다. 
		
		// 무한 루핑 반복문을 선언했을 경우 해당 루핑을 빠져나갈 수 있는
		// 조건을 가장 먼저 선언하는 것을 권장한다. 
		if(key == 32){	// space(32)
			break;
		}
		
		// [Enter] 무시 - 케리지 리턴 값 13 
		// 키보드 버퍼에 남아있는 [Enter] 처리 방법 
		if(key != 13){	
			textType(key);
		} 
	}
	printf("space를 입력됨. 프로그램 종료.");		
}
/*
	void textType(int key){
		if(key >= 'A' && key <= 'Z') {
			printf(">%c : 대문자\n", key);
		} else if (key >= 'a' && key <= 'z') {
			printf(">%c : 소문자\n", key);
		} else if (key >= 33 && key <= 47) {	// 특수문자(! ~ /)  
			printf(">%c : 특수문자\n", key);
		} else if (key >= 33 && key <= 47) {	// 특수문자(! ~ /)  
			printf(">%c : 특수문자\n", key);
		} else if (key >= 58 && key <= 64) {	// 특수문자(: ~ @)  
			printf(">%c : 특수문자\n", key);
		} else if (key >= 91 && key <= 96) {	// 특수문자([ ~ ')  
			printf(">%c : 특수문자\n", key);
		} else if (key >= 123 && key <= 126) {	// 특수문자({ ~ ~)  
			printf(">%c : 특수문자\n", key);
		}
	}
*/
