
/* main 함수 다시보기 : 함수의 기본 형태 
	int : 반환의형태 main : 함수의이름 (...) : 입력의 형태 { : 함수 몸체 시작	
	int main(void){		 
	
		// 작업 내용 
	
	}	// main 몸체 종료 */ 
	

/* 함수를 정의하는 이유
	- 모듈화에 의한 프로그램의 질 향상이 가능하다
	- 유지 보수 및 확장의 용이성
	- 문제 해결의 용이성 : "Divide and Conquer!(나누고 집중하라)" */
	
	
/* 4가지 형태의 함수
	- 전달 인자 존재, 반환 값 존재
		int Add(int i, int j){
			int result = i + j;
			return result;
		}
	- 전달 인자 존재, 반환 값 부재
		int Input(void){
			int input;
			scanf("%d", &input);
			return input;
		}
	- 전달 인자 부재, 반환 값 존재
		void Result_Print(int val){
			printf("덧셈에 대한 결과 : %d \n", val);
			printf("********** END **********\n");
		}
	- 전달 인자 부재, 반환 값 부재 
		void Intro(void){
			printf("********** START **********\n");
			printf("두개의 정수 입력 : "); 
		}		
*/

/* 함수선언의 필요성
	- 컴파일러의 특성상, 함수는 호출되기 전에 정의되어야 한다. 
	- 함수의 원형(프로토타입)을 선언할 경우 함수의 본체의 선언은 순서에 상관받지 않는다.
		ex)
			int Add (int a, int b);			// 함수의 원형(프로토타입) 선언 
			
			int main (){
				int sum = Add(a, b);		// 함수 호출 
			}
			
			int Add (int a, int b) {		// 함수 선언 
				...
			}
*/
	
	 
