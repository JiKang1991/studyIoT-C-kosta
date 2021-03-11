#include <stdio.h>
#include <string.h>
#include <conio.h>

int main(void) {
	char* dotArr = "..........";
	char ch = '|';
	
	while(1){
		int index = getch() - 0x30;	// '0' ~ '9' : 0x30 ~ 0x39
		if(index > 1 || index < 9){
			for(int i = 0; i < strlen(dotArr); i++){
				if(i == index - 1){
					printf("%c", ch);
				} else {
					printf("%c", *(dotArr+i));
				}
			}
		}
		printf("\r");
	}
	
}
