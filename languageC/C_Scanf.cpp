# include <stdio.h>
/* scanf Ȱ�� ����( ����a ~ b ������ ���� ���ϴ� �ڵ�) */
int main(){
	int a = 0, b = 0, result = 0;
	
	printf("������ ������ ����� ���� 2���� ���� �Է��� �ּ���.\n"); 
	scanf("%d %d", &a, &b);					// & : �ּҸ� �ǹ��Ѵ� 
		
	// for(�ʱⰪ; ��������; ��������) 
	for(int i = a; i <= b; i++) {
		
		result = result + i;
		//result += i;
	}
	
	printf("for���� �̿��� ���� ���\n"); 
	printf("a = %d\nb = %d\n", a, b);
	printf("result = %d\n", result);
	
}
