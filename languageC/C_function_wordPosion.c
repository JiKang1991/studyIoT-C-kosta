#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int wordPosion (char* targetString, char* searchingWord);
int charPosion (char* targetString, char searchingChar);

int main(void) {
	
	char *str = "abcdefgacdbhijklmn";
	printf("문자열은 : %s\n", str);
	//printf("%c의 위치는 %d 입니다.\n", 'z', charPosion(str, 'z'));	// -1
	//printf("%c의 위치는 %d 입니다.\n", 'e', charPosion(str, 'z'));	// 4
	printf("%s의 위치는 %d 입니다.\n", "klme", wordPosion(str, "klme"));	
}
/*
// 함 수 명 : int wordPosion (char* targetString, char searchingWord);
// return type : int(searchingWord의 위치), 없다면 -1
// input : char* targetString(대상 문자열)
//		   char searchingWord(찾을 문자)  
// 기능 : targetString로 전달된 문자열 중에서 searchingWord 단어를 검색하여
//		  해당 위치를 반환(zero base), 검색되지 않으면 -1을 반환
// =========== 로직 구현 ============= 
// 1. targetString에서 searchingWord의 첫 문자가 있는 위치를 검색한다.
// 2. 해당하는 위치에서 strncmp를 이용하여 비교한다.
// 3. 같으면 return i; 다르면 다시 1번으로
// 4. 만일 끝까지 없으면 -1 
*/
int wordPosion (char* targetString, char* searchingWord) {
	// semple	*targetString = "abcdefgacdbhijklmn";	searchingWord = "acdb"; 리턴값 7 
	int firstWordIndex = 0;
	for(int i = 0; *(targetString+i); i+=firstWordIndex+1){
		
		firstWordIndex = charPosion(targetString+i, *searchingWord);
		
		if(firstWordIndex == -1) {
			return -1;
		} 
		
		if(strncmp(targetString+firstWordIndex+i, searchingWord, strlen(searchingWord)) == 0){
			return firstWordIndex+i;
		}
	}
	return -1;
}

int charPosion (char* targetString, char searchingChar) {

	// for문 이용
	for(int i = 0; *(targetString+i); i++) {
		if(*(targetString+i) == searchingChar) {
			return i;
		}
	}
	return -1; 
}
