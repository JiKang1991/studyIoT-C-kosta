#include<stdio.h>
#include<io.h>

void fileTest(){
	char buf[255];
	FILE *fp = fopen("C:\\kosta203\\studyC-kostaIOT\\filetest.txt", "rb");
	fscanf(fp, "%s", buf);
	printf("���Ͽ��� ���� ���ڿ� : \"%s\"", buf);	
	fclose(fp);
}

int main(){
	FILE *fp = fopen("C:\\kosta203\\studyC-kostaIOT\\filetest.txt", "ab");
	fprintf(fp, "Hello!");
	fileTest();
	fclose(fp);
} 
