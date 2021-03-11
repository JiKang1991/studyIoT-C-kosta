# include <stdio.h>
/* while문 활용 예제( 정수a ~ b 까지의 합을 구하는 코드) */
int main(){
	int a = 1, b = 100, result = 0;
	int t = a;	// t : 변수 a의 초기값 저장용 
	
	
	while(a <= b) {
		
		result = result + a;
		a = a + 1;
		
		// result += a;	
		// a++;			
		
		//result += a++;
	}
	
	printf("while문을 이용한 누적 계산"); 
	printf("a = %d\nb = %d\n", t, b);
	printf("result = %d\n", result);
	
}
