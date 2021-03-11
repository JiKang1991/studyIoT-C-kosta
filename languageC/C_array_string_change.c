#include <stdio.h>

int main(){
	
	char str[6] = "Hello";
	
	printf("--변경 전 문자열--\n");
	printf("%s \n", str);
	
	for(int i = 0; i < 6; i++) {
		printf("%c", str[i]);
	}
	
	/* 문자열 변경 */
	for(int i = 0; i < 3; i++) {
		char temp;
		temp = str[4-i];
		printf("%c를 temp에 저장\n", str[4-i]);
		str[4-i] = str[i];
		printf("str[%d]의 %c를 str[%d]에 저장\n", i, str[i], 4 - i);
		str[i] = temp;
		printf("temp의 %c를 str[%d]에 저장\n", temp, i);
	} 
	
	printf("\n\n--변경 후 문자열--\n");
	printf("%s \n", str);
	return 0;
} 
