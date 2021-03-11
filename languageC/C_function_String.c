#include <stdio.h>
#include <string.h>
#include <stdlib.h>
/* 문자열 관련 함수 활용 예제 */
int main(void) {
	char numberArr[30];
	int afterAToI;
	
	fgets(numberArr, sizeof(numberArr), stdin);
	printf("입력된 숫자입니다 : %s", numberArr);
	
	afterAToI = atoi(numberArr);
	printf("atoi로 변환된 숫자입니다 : %d", afterAToI);
}
