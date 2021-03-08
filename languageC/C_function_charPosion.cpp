#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int charPosion (char* targetString, char searchingChar);

int main(void) {
	
	char *str = "abcdefghijklm";
	printf("문자열은 : %s\n", str);
	printf("%c의 위치는 %d 입니다.\n", 'e', charPosion(str, 'e'));	// 4
	printf("%c의 위치는 %d 입니다.\n", 'z', charPosion(str, 'z'));	// -1	
}

// 함 수 명 : int charPosion (char* targetString, char searchingChar);
// return type : int(searchingChar의 위치), 없다면 -1
// input : char* targetString(대상 문자열)
//		   char searchingChar(찾을 문자)  
// 기능 : targetString로 전달된 문자열 중에서 searchingChar 문자를 검색하여
//		  해당 위치를 반환(zero base), 검색되지 않으면 -1을 반환 
int charPosion (char* targetString, char searchingChar) {
	/* while 
		int i = 0;
		// 문자열의 마지막에는 0이 존재하므로 아래와 같이 조건식을 정의할 수 있다.
		while(*(targetString+i)){	 
			if(*(targetString+i++) == searchingChar) {	// ++연산은 i에 대해 적용한다 
				return i - 1;
			}
		} 
		return -1; 
	*/
	// for문 이용
	for(int i = 0; *(targetString+i); i++) {
		if(*(targetString+i) == searchingChar) {
			return i;
		}
	}
	return -1; 
}
