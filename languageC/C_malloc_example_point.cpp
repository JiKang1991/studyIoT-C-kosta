#include<stdio.h>
#include<io.h>
#include<malloc.h>

#define PNUM 100


// 데이터 파일을 open하여 읽어오기 
// ---> 이름	과목명1		과목명2		과목명3		[총점]	[평균]	[석차] 
// ---> 홍길동	점수1		점수2		점수3		총점	실수	등수
//  
int main(){
	
	
	
		
	int* eng = (int*)malloc(PNUM * sizeof(int));
	int* kor = (int*)malloc(PNUM * sizeof(int));
	int* math = (int*)malloc(PNUM * sizeof(int));
	//char** name;
	
	// 파일에서 읽은 데이터 종류의 개수 
	int dataCaseNum = 0; 
	
	//name = (char**)malloc(PNUM * 10);
	FILE* fp = fopen("C:\\kosta203\\studyC-kostaIOT\\C_malloc_example_point.txt", "rb");
	for(int i = 0; i < PNUM; i++){
		// 읽혀진 데이터의 개수가 리턴되어 k에 저장된다. 
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
