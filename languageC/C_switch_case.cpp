#include<stdio.h>
/* swich ~ case �� ����*/
int main(){
	//bool flag = 1;	// while�� �ݺ� ���θ� ���Ѵ� ����ڿ��� 0�� �Է¹��� ��� 0���� �ʱ�ȭ�Ѵ�. 
	int inputedNum = 0;
	
	//while(flag) {
	while(1) {
		
		printf("1 ~ 9 ������ ���� �ϳ��� �����ּ���.(0�� ������ ����) : ");
		scanf("%d", &inputedNum);
		
		if(inputedNum == 0){
			break;
		}
		
		switch(inputedNum){  			// switch() �� �Ű������� ������ �����ϴ�. 
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
				printf("�����ϼ̽��ϴ�.\n");
				break;
		}
	}
}
