#include<stdio.h>
#include<io.h>
#include<malloc.h>

#define NOTE FILE

void fileTest(){
	char *buf = (char*)malloc(255);
	NOTE *fp = fopen("C:\\kosta203\\studyC-kostaIOT\\filetest.txt", "rb");
	fscanf(fp, "%s", buf);
	printf("파일에서 읽은 문자열 : \"%s\"", buf);	
	fclose(fp);
}

int main(){
	NOTE *fp = fopen("C:\\kosta203\\studyC-kostaIOT\\filetest.txt", "ab");
	fprintf(fp, "Hello!");
	fileTest();
	fclose(fp);
} 
