#include<stdio.h>
// textType �Լ� ������Ÿ�ԶǴ� ��ü�� ����Ǿ��ִ� header ����
// ����� ������ ��������� include�� ������ �ֵ���ǥ�� ����Ѵ�.
// �̷��� ����� �Լ��� ���� �� �� �ִٴ� ������ �ִ�. 
#include"C_function_textType_header.h"

//void textType(int key);

int main(){
	int key;		// �Է� ���� Ű ���� �����ϱ� ���� ���� ���� 
		
	printf("Ÿ���� Ȯ���ϰ��� �ϴ� �� ���� Ű�� �Է��ϰ� Enter�� �����ּ���.(����(space)�Է½� ���α׷� ����) : ");
	
	while(1){
			
		// %c : ���� ���� %s : ���ڿ� 
		scanf("%c", &key);		// �� ���ڸ� �Է� ����
		// scanf �Լ��� [Enter] Ű�� �Է��� ���� �˻��ϱ� ������
		// ���� ���� ó���� �ι� �Է����� ó���Ѵ�. 
		
		// ���� ���� �ݺ����� �������� ��� �ش� ������ �������� �� �ִ�
		// ������ ���� ���� �����ϴ� ���� �����Ѵ�. 
		if(key == 32){	// space(32)
			break;
		}
		
		// [Enter] ���� - �ɸ��� ���� �� 13 
		// Ű���� ���ۿ� �����ִ� [Enter] ó�� ��� 
		if(key != 13){	
			textType(key);
		} 
	}
	printf("space�� �Էµ�. ���α׷� ����.");		
}
/*
	void textType(int key){
		if(key >= 'A' && key <= 'Z') {
			printf(">%c : �빮��\n", key);
		} else if (key >= 'a' && key <= 'z') {
			printf(">%c : �ҹ���\n", key);
		} else if (key >= 33 && key <= 47) {	// Ư������(! ~ /)  
			printf(">%c : Ư������\n", key);
		} else if (key >= 33 && key <= 47) {	// Ư������(! ~ /)  
			printf(">%c : Ư������\n", key);
		} else if (key >= 58 && key <= 64) {	// Ư������(: ~ @)  
			printf(">%c : Ư������\n", key);
		} else if (key >= 91 && key <= 96) {	// Ư������([ ~ ')  
			printf(">%c : Ư������\n", key);
		} else if (key >= 123 && key <= 126) {	// Ư������({ ~ ~)  
			printf(">%c : Ư������\n", key);
		}
	}
*/
