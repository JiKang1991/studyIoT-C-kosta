#include<stdio.h>
/* if else else if�� ����*/
int main(){
	int startNum = 0;	// ���� �� 
	int endNum = 0;		// ���� �� 
	
	int multiple9 = 0;
	int multiple8 = 0;
	int multiple7 = 0;
	int multiple6 = 0;
	int multiple5 = 0;
	int multiple4 = 0;
	int multiple3 = 0;
	int multiple2 = 0;
	int remainNum = 0;
	
	
	printf("���� ���� ���� ���� �����ּ���.\n");
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
		
	printf("\n��� �Ϸ�!\n");
	printf("9�� ����� �� : %d\n", multiple9);
	printf("8�� ����� �� : %d\n", multiple8);
	printf("7�� ����� �� : %d\n", multiple7);
	printf("6�� ����� �� : %d\n", multiple6);
	printf("5�� ����� �� : %d\n", multiple5);
	printf("4�� ����� �� : %d\n", multiple4);
	printf("3�� ����� �� : %d\n", multiple3);
	printf("2�� ����� �� : %d\n", multiple2);
	printf("������ ���� �� : %d\n", remainNum);
	
}
