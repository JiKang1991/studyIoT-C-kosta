#include<stdio.h>
#include<io.h>
/* ���� ����� ����*/
int main() {
	char readFileBuf[256];
	
	// FILE����ü�� ���� ���� �� �ʱ�ȭ
	// fopen(�����̸�, ���¸��); 
	FILE* fp = fopen("C:\\C_Class\\Week1\\data\\filetest.txt", "rb");
	
	for(int i = 0; i < 20; i++) {
	
	// �����Է��Լ�
	// fscanf(����������);
	fscanf(fp, "%s", readFileBuf);
	printf("%s\n", readFileBuf);
	}
	
	
	// ���������Լ�
	// fclose(����������); 
	fclose(fp); 
	
	
} 
