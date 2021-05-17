#include <stdio.h>
#include <malloc.h>
#include <string.h>

// c#에서 GetToken 메소드
// string GetToken(int index, string str, char chr){
// 		string[] sArr = str.Split(chr);
//		return sArr[index];
// }


// 참고 함수 - 주어진 문자열에서 특정한 문자를 찾는 함수입니다.
// 문자열 str에서 문자 chr의 위치를 반환합니다.
int chrFind(char* str, char chr){
	int index = 0;
	// 문자열의 끝에는 null이 있습니다.
	while(*str){
		if(*str++ == chr) return index;
		else index++;
	}
	
	return -1;
}

int strLength(char* source){
	int index = 0;
	while(*source++){
		index++;
	}
	return index;
}

int chrCount(char* source, char divider){
	int index = 0;
	while(*source){
		if(*source++ == divider) index++;
	}
	return index;
}

char** split(char* source, char divider){
	// source = "123,456,789"
	// 포인터를 매개변수로 받아 원본 손상의 가능성이 있으므로 복사본을 생성한다.
	// malloc
	// strlen
	char* copySource = malloc(strLength(source));
	char** splitedSource = malloc((chrCount(source, divider)+1) * 4) ;
	// 단순 대입으로는 내용물이 변경되지 않는다.
	// copySource = source;
	// strcpy
	strcpy(copySource, source);
	
	int i = 1;
	*splitedSource = copySource;
	while(*copySource){
		if(*copySource == divider){
			*copySource = 0;
			*(splitedSource+i++) = copySource + 1;
			//for(int j = 0; j < i; j++){
				//printf("%s\n", *(splitedSource+j));
			//}
		}
		*copySource++;
	}
	return splitedSource;
	// source = "123" "456" "789"	
}

char* getToken(int index, char* source, char divider){
		char** ss = split(source, divider);
		return *(ss + index);
}

/*
char GetToken(int index, char* source, char divider){
	// source의 크기를 확인합니다.
	int sourceSize = 0;
	while(*source){
		sourceSize++;
	}
	
	// sourceSize 만큼의 int array를 생성합니다.
	int[] dividerIndexArr = new int[sourceSize];
	
	
	// source에 char가 몇 번째에 있는지 확인합니다.
	int arrayIndex = 0;
	int sourceIndex = 0;
	while(*source){
		if(*source++ == divider){
			dividerIndexArr[arrayIndex++] =  sourceIndex++;
		} else {
			sourceIndex++;
		}		
	}
	
	// index가 0이면 arrayIndex[0] 앞의 문자열을 리턴한다.
	// index가 1이면 arrayIndex[0] 뒤와 arrayIndex[1]의 앞을 동시에 만족하는 문자열을 리턴한다.
	
	char[] forReturn;
	
	if(index == 0){
		forReturn = new char[arrayIndex[index] - 1];
	} else if(index > 0 && index <= arrayIndex) {
		forReturn = new char
	}
	
	else if(index > arrayIndex) {
		forReturn = new char[sourceSize - arrayIndex[index -1]];
	} else
	
	
}
*/
int main(){

	//char *s1 = "abcdefghijkl";
	//while(1){
		//printf("Input char which you want to find : ");
		//int chr = getchar();
		//printf("[%c] 문자는 [%d] 번째에 있습니다.\r\n", chr, ChrFind(s1, chr) + 1);
	//}
	
	char *tt = "1,2,3,4,5,6";
	//char **ss = split(tt, ',');
	int input;
	while(1){
		printf("input number : " );
		scanf("%d", &input);
		printf("%d 번째 아이템은 %s 입니다.\n", input, getToken(input, tt, ','));
	}
	return 0;
}

