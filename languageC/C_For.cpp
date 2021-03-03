# include <stdio.h>
/* for문 활용 예제( 정수a ~ b 까지의 합을 구하는 코드) */
int main(){
	int a = 1, b = 100, result = 0;
		
	// for(초기값; 수행조건; 증감연산) 
	for(int i = a; i <= b; i++) {
		
		result = result + i;
		//result += i;
	}
	
	printf("for문을 이용한 누적 계산\n"); 
	printf("a = %d\nb = %d\n", a, b);
	printf("result = %d\n", result);
	
}
