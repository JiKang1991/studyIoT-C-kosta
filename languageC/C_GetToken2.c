#include <stdio.h>
#include <malloc.h>
#include <string.h>

/**
 *  1. 구분자의 위치를 파악합니다.
 *  2. 다음번 구분자의 위치까지 복사(없으면 null까지)
 */

// ex) source = 123,456,789  /  index 11
char* getToken(int index, char* source, char delimeter){
	
	char buffer[1024];
	int startIndex = 0;
	int delimeterIndex;
	
	for(int i = 0; i < index; i++){	
		delimeterIndex += chrFind(source+startIndex, delimeter);
		if(delimeterIndex == -1) return NULL;
		else startIndex += delimeterIndex + 1;
	}
	
	delimeterIndex = chrFind(source+startIndex, delimeter);
	if(delimeter == -1) delimeterIndex = strlen(source);
	else delimeterIndex += startIndex;
	
	// strncpy - 버그 존재(0이 들어가지 않습니다.)
	strncpy(buffer, source+startIndex, delimeterIndex-startIndex);
	buffer[delimeterIndex - startIndex] = 0;
	return buffer;
}


int main(){
}

