#include<stdio.h>
#include<io.h>
#include<malloc.h>

#define PNUM 100


// ������ ������ open�Ͽ� �о���� 
// ---> �̸�	�����1		�����2		�����3		[����]	[���]	[����] 
// ---> ȫ�浿	����1		����2		����3		����	�Ǽ�	���
//  
int main(){
	
	
	
		
	int* eng = (int*)malloc(PNUM * sizeof(int));
	int* kor = (int*)malloc(PNUM * sizeof(int));
	int* math = (int*)malloc(PNUM * sizeof(int));
	//char** name;
	
	// ���Ͽ��� ���� ������ ������ ���� 
	int dataCaseNum = 0; 
	
	//name = (char**)malloc(PNUM * 10);
	FILE* fp = fopen("C:\\kosta203\\studyC-kostaIOT\\C_malloc_example_point.txt", "rb");
	for(int i = 0; i < PNUM; i++){
		// ������ �������� ������ ���ϵǾ� k�� ����ȴ�. 
		int k = fscanf(fp, "%d %d %d", kor+i, eng+i, math+i);	
		if(k != 3){
			break;
		} 
		dataCaseNum++;
	}
	
	for(int i = 0; i < dataCaseNum; i++) {
		printf("%d	%d	%d	\n", *(kor+i), *(eng+i), *(math+i));
	}
	
	fclose(fp);	
}
