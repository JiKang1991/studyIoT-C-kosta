#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int wordPosion (char* targetString, char* searchingWord);
int charPosion (char* targetString, char searchingChar);

int main(void) {
	
	char *str = "abcdefgacdbhijklmn";
	printf("���ڿ��� : %s\n", str);
	//printf("%c�� ��ġ�� %d �Դϴ�.\n", 'z', charPosion(str, 'z'));	// -1
	//printf("%c�� ��ġ�� %d �Դϴ�.\n", 'e', charPosion(str, 'z'));	// 4
	printf("%s�� ��ġ�� %d �Դϴ�.\n", "klme", wordPosion(str, "klme"));	
}
/*
// �� �� �� : int wordPosion (char* targetString, char searchingWord);
// return type : int(searchingWord�� ��ġ), ���ٸ� -1
// input : char* targetString(��� ���ڿ�)
//		   char searchingWord(ã�� ����)  
// ��� : targetString�� ���޵� ���ڿ� �߿��� searchingWord �ܾ �˻��Ͽ�
//		  �ش� ��ġ�� ��ȯ(zero base), �˻����� ������ -1�� ��ȯ
// =========== ���� ���� ============= 
// 1. targetString���� searchingWord�� ù ���ڰ� �ִ� ��ġ�� �˻��Ѵ�.
// 2. �ش��ϴ� ��ġ���� strncmp�� �̿��Ͽ� ���Ѵ�.
// 3. ������ return i; �ٸ��� �ٽ� 1������
// 4. ���� ������ ������ -1 
*/
int wordPosion (char* targetString, char* searchingWord) {
	// semple	*targetString = "abcdefgacdbhijklmn";	searchingWord = "acdb"; ���ϰ� 7 
	int firstWordIndex = 0;
	for(int i = 0; *(targetString+i); i+=firstWordIndex+1){
		
		firstWordIndex = charPosion(targetString+i, *searchingWord);
		
		if(firstWordIndex == -1) {
			return -1;
		} 
		
		if(strncmp(targetString+firstWordIndex+i, searchingWord, strlen(searchingWord)) == 0){
			return firstWordIndex+i;
		}
	}
	return -1;
}

int charPosion (char* targetString, char searchingChar) {

	// for�� �̿�
	for(int i = 0; *(targetString+i); i++) {
		if(*(targetString+i) == searchingChar) {
			return i;
		}
	}
	return -1; 
}
