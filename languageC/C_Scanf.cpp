# include <stdio.h>
/* scanf 활용 예제( 정수a ~ b 까지의 합을 구하는 코드) */
int main(){
	int a = 0, b = 0, result = 0;
	
	printf("범위의 누적값 계산을 위해 2개의 수를 입력해 주세요.\n"); 
	scanf("%d %d", &a, &b);					// & : 주소를 의미한다 
		
	// for(초기값; 수행조건; 증감연산) 
	for(int i = a; i <= b; i++) {
		
		result = result + i;
		//result += i;
	}
	
	printf("for문을 이용한 누적 계산\n"); 
	printf("a = %d\nb = %d\n", a, b);
	printf("result = %d\n", result);
	
}
