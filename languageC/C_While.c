# include <stdio.h>
/* while�� Ȱ�� ����( ����a ~ b ������ ���� ���ϴ� �ڵ�) */
int main(){
	int a = 1, b = 100, result = 0;
	int t = a;	// t : ���� a�� �ʱⰪ ����� 
	
	
	while(a <= b) {
		
		result = result + a;
		a = a + 1;
		
		// result += a;	
		// a++;			
		
		//result += a++;
	}
	
	printf("while���� �̿��� ���� ���"); 
	printf("a = %d\nb = %d\n", t, b);
	printf("result = %d\n", result);
	
}
