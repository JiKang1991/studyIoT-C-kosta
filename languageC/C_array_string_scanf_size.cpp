#include<stdio.h>

int main(){
	//char buffer[10];
	char buffer[1024];  // 일반적으로 1000 이상의 배열 크기를 설정한다. 
	while(1){
		
		// 배열의 이름은 그 자체가 주소를 참조하고 있으므로 
		// 배열의 이름 앞에는 '&'를 사용하지 않는다. 
		scanf("%s", buffer);
		
		printf("입력 문자열은 %s입니다.\n\n\n\n", buffer);	
	
	}
	return 0;
} 
