#include<stdio.h>
#include<io.h>
/* ���� ����� ����*/
int main() {
	// FILE����ü�� ���� ���� �� �ʱ�ȭ
	// fopen(�����̸�, ���¸��); 
	FILE* fp = fopen("filetest.txt", "ab");
	
	// ��������Լ�
	// fprintf(����������, ��³���); 
	fprintf(fp, "File open write close test");
	
	// ���������Լ�
	// fclose(����������); 
	fclose(fp); 
} 
