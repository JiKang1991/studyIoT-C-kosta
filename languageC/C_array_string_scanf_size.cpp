#include<stdio.h>

int main(){
	//char buffer[10];
	char buffer[1024];  // �Ϲ������� 1000 �̻��� �迭 ũ�⸦ �����Ѵ�. 
	while(1){
		
		// �迭�� �̸��� �� ��ü�� �ּҸ� �����ϰ� �����Ƿ� 
		// �迭�� �̸� �տ��� '&'�� ������� �ʴ´�. 
		scanf("%s", buffer);
		
		printf("�Է� ���ڿ��� %s�Դϴ�.\n\n\n\n", buffer);	
	
	}
	return 0;
} 
