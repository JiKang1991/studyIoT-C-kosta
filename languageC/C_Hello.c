#include <stdio.h>
// #include <conio.h>

int main(){
	printf("Hello World!");
	
	// <conio.h>의 getch()는 키보드에서 이벤트 발생 즉시 해당 키값을 가져옵니다.
	// windows os에서는 콘솔헤드<conio.h>와 키보드 이벤트가 허용되지 않습니다.
	// int c = getch();
	// printf("you press [%c] key..", c);
	
	// getchar()는 표준합수로 사용이 가능합니다.
	int c = getchar();
	printf("you press [%c] key..", c);
	return 0;
}
