#include<stdio.h>
/* if else else if문 예제*/
int main(){
	int startNum = 0;	// 시작 값 
	int endNum = 0;		// 종료 값 
	
	int multiple9 = 0;
	int multiple8 = 0;
	int multiple7 = 0;
	int multiple6 = 0;
	int multiple5 = 0;
	int multiple4 = 0;
	int multiple3 = 0;
	int multiple2 = 0;
	int remainNum = 0;
	
	
	printf("시작 값과 종료 값을 적어주세요.\n");
	scanf("%d %d", &startNum, &endNum);
		
	for(int i = startNum; i <= endNum; i++){
		if(i % 9 == 0){
			multiple9 += i;
		} else if (i % 8 == 0) {
			multiple8 += i;
		} else if (i % 7 == 0) {
			multiple7 += i;
		} else if (i % 6 == 0) {
			multiple6 += i;
		} else if (i % 5 == 0) {
			multiple5 += i;
		} else if (i % 4 == 0) {
			multiple4 += i;
		} else if (i % 3 == 0) {
			multiple3 += i;
		} else if (i % 2 == 0) {
			multiple2 += i;
		} else {
			remainNum += i;
		}
		
		
	}
		
	printf("\n계산 완료!\n");
	printf("9의 배수의 합 : %d\n", multiple9);
	printf("8의 배수의 합 : %d\n", multiple8);
	printf("7의 배수의 합 : %d\n", multiple7);
	printf("6의 배수의 합 : %d\n", multiple6);
	printf("5의 배수의 합 : %d\n", multiple5);
	printf("4의 배수의 합 : %d\n", multiple4);
	printf("3의 배수의 합 : %d\n", multiple3);
	printf("2의 배수의 합 : %d\n", multiple2);
	printf("나머지 수의 합 : %d\n", remainNum);
	
}
