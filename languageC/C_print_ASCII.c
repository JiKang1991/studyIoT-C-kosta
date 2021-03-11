#include<stdio.h>

int main() {
	
	for(int i = 0; i <= 31; i++) {
		for(int j = 0; j < 4; j++) {
			int pormula = i + (32 * j);
			if(pormula == 9 || pormula == 10 || pormula == 13){
				printf("%d \t 0x%02x \t\t", pormula, pormula);
			}else{
				printf("%d \t 0x%02x \t %c \t", pormula, pormula, pormula);
			}
			
			
		}
		printf("\n");
	} 
}
