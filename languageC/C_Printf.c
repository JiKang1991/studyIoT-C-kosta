#include<stdio.h>
/* printf 활용하기 */ 
main(){
	// printf 활용하기
	printf("Hello Everybody \n");
	printf("%d \n", 1234);
	printf("%d %d \n", 10, 20);
	printf("My name is ~ %s \n\n", "팽수");
	printf("My age is ~ %d\n", 10);
	
	// 이스케이프 문자 활용하기
	printf("특수문자\t 의미\n");
	printf("\\a :\t\t 경고음 발생\n"); 
	printf("\\b :\t\t 백스페이스(backspace)\n");
	printf("\\f :\t\t 폼 피드(form feed)\n");
	printf("\\n :\t\t 개행\n");
	printf("\\r :\t\t 캐리지 리턴(carriage return)\n");
	printf("\\t :\t\t 수평 탭\n");
	printf("\\v :\t\t 수직 탭\n");
	printf("\\\\ :\t\t 백슬래시(\\)\n");
	printf("\\\' :\t\t 작은 따옴표\n");
	printf("\\\" :\t\t 큰 따옴표\n"); 
	
	//
	printf("%d%d\n", 123, 456);	// 123456
	printf("%-8d %-8d %d\n", 123, 456, 789); // 123     456     789
	printf("%8d %8d %d\n\n\n", 123, 456, 789);	//      123     456     789
	
	printf("실수의 출력 : %f %f \n", 3.14159265, 456.789123);	// 3.141593 456.789123
	printf("실수의 출력 : %8.2f %10.3f \n\n", 3.14159265, 456.789123);	//      3.14    456.789
	
	// sizeof 활용 
	printf("data type 별 byte 수 (int) : %d byte\n", sizeof(int));
	printf("data type 별 byte 수 (char) : %d byte\n", sizeof(char));
	printf("data type 별 byte 수 (long) : %d byte\n", sizeof(long));
	printf("data type 별 byte 수 (float) : %d byte\n", sizeof(float));
	printf("data type 별 byte 수 (double) : %d byte\n", sizeof(double));
}
