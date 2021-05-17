#include <stdio.h>

int main(){
	// FILE 구조체 활용, fopen(파일 경로, 실행 형태)
	// a = append (기존의 파일이 있으면 뒤에 추가, 없으면 새로 생성
	// b = 바이너리 모드 \n , \r\n의 차이
	//FILE *filePointer = fopen("test.txt", "ab");
		
		
	char buf[256];
	printf("Input output File name : ");
	// scanf(변환 문자, 변수의 주소값)
	// 배열의 경우 배열 변수명 그 자체로 주소값을 의미하므로 &를 사용하지 않아도 된다. 
	scanf("%s",buf);
	FILE* filePointer = fopen(buf, "ab");
	
	// 0 = false, 0 이외의 값 = true
	while(1) {
		scanf("%s", buf);
		if(buf[0] == '>') break;
		fprintf(filePointer, "%s", buf);
	}
	fclose(filePointer);
	return 0;
}
