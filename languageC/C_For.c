# include <stdio.h>
/* for�� Ȱ�� ����( ����a ~ b ������ ���� ���ϴ� �ڵ�) */
int main(){
	int a = 1, b = 100, result = 0;
		
	// for(�ʱⰪ; ��������; ��������) 
	for(int i = a; i <= b; i++) {
		
		result = result + i;
		//result += i;
	}
	
	printf("for���� �̿��� ���� ���\n"); 
	printf("a = %d\nb = %d\n", a, b);
	printf("result = %d\n", result);
	
}
