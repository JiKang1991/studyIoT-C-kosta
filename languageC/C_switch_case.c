#include<stdio.h>
/* swich ~ case 문 예제*/
int main(){
	//bool flag = 1;	// while문 반복 여부를 정한다 사용자에게 0을 입력받을 경우 0으로 초기화한다. 
	int inputedNum = 0;
	
	//while(flag) {
	while(1) {
		
		printf("1 ~ 9 사이의 숫자 하나를 적어주세요.(0을 누르면 종료) : ");
		scanf("%d", &inputedNum);
		
		if(inputedNum == 0){
			break;
		}
		
		switch(inputedNum){  			// switch() 의 매개변수는 정수만 가능하다. 
			case 1:
				printf(">1 : One\n");
				break;
			case 2:
				printf(">2 : Two\n");
				break;
			case 3:
				printf(">3 : Three\n");
				break;
			case 4:
				printf(">4 : Four\n");
				break;
			case 5:
				printf(">5 : Five\n");
				break;
			case 6:
				printf(">6 : Six\n");
				break;
			case 7:
				printf(">7 : Seven\n");
				break;
			case 8:
				printf(">8 : Eight\n");
				break;
			case 9:
				printf(">9 : Nine\n");
				break;
			/*
			case 0:
				flag = 0;
				break;
			*/
			default:
				printf("수고하셨습니다.\n");
				break;
		}
	}
}
