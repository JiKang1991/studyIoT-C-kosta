# include <stdio.h>
/* while�� Ȱ�� ����( ����a ~ b �� ¦���� ���� ���ϴ� �ڵ�) */
int main(){
	int a = 0, b = 0, result = 0;
	
	printf("������ ������ ����� ���� 2���� ���� �Է��� �ּ���.\n"); 
	scanf("%d %d", &a, &b);					// & : �ּҸ� �ǹ��Ѵ�
	
	int t = a;	// t : ���� a�� �ʱⰪ ����� 
	
	
	while(a <= b) {
		if( a % 2 == 0){
			result += a;			
		} 		
		a++;		
	}
	
	printf("while���� �̿��� ¦�� ���� ���\n"); 
	printf("a = %d\nb = %d\n", t, b);
	printf("result = %d\n", result);
	
}
