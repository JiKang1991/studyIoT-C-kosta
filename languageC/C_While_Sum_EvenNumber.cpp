# include <stdio.h>
/* while문 활용 예제( 정수a ~ b 중 짝수의 합을 구하는 코드) */
int main(){
	int a = 0, b = 0, result = 0;
	
	printf("범위의 누적값 계산을 위해 2개의 수를 입력해 주세요.\n"); 
	scanf("%d %d", &a, &b);					// & : 주소를 의미한다
	
	int t = a;	// t : 변수 a의 초기값 저장용 
	
	
	while(a <= b) {
		if( a % 2 == 0){
			result += a;			
		} 		
		a++;		
	}
	
	printf("while문을 이용한 짝수 누적 계산\n"); 
	printf("a = %d\nb = %d\n", t, b);
	printf("result = %d\n", result);
	
}
