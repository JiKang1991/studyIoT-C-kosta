// 포인터
 
// * = 포인터를 나타내는 문자 ( 아스테리스크, asterisk)
// ** = 2차원 포인터
// *** = 3차원 포인터

/* 포인터와 포인터 변수*/

/* 포인터의 타입과 선언
	- 포인터 선언시 사용되는 연산자 : *
	- A형 포인터(A*) : A형 변수의 주소값을 저장
		int main(void) {
			int*a;			// a라는 이름의 int형 포인터
		}
*/

/* 주소 관련 연산자
- &연산자 : 변수의 주소값 반환
- *연산자 : 포인터가 가리키는 메모리 참조
	int a = 2005;		// a = 2005
	int *pA = &a; 		// pA = a변수의 주소값 
	printf("%d", a);	// 2005(직접접근)
	printf("%d", *pA);	// 2005(간접접근)
*/

/* 포인터에 다양한 타입이 존재하는 이유
	- 포인터 타입은 참조할 메모리의 크기정보를 제공한다. */ 
	
/* int main(void) {
   		// 100이 어디인지 알 수 없다. 
		//만약 system area인 경우 시스템에 치명적인 에러가 발생할 수 있다.
		int* pA = 100;
		*pA = 10;
		return 0;		 
   }
*/

// DMA(Direct Memory Access) : 메인보드의 슬롯에서 데이터를 주고 받는 기법 (Linux - divice driver 관련 내용) 
	
	
	
	
