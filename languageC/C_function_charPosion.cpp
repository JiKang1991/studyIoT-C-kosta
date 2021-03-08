#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int charPosion (char* targetString, char searchingChar);

int main(void) {
	
	char *str = "abcdefghijklm";
	printf("���ڿ��� : %s\n", str);
	printf("%c�� ��ġ�� %d �Դϴ�.\n", 'e', charPosion(str, 'e'));	// 4
	printf("%c�� ��ġ�� %d �Դϴ�.\n", 'z', charPosion(str, 'z'));	// -1	
}

// �� �� �� : int charPosion (char* targetString, char searchingChar);
// return type : int(searchingChar�� ��ġ), ���ٸ� -1
// input : char* targetString(��� ���ڿ�)
//		   char searchingChar(ã�� ����)  
// ��� : targetString�� ���޵� ���ڿ� �߿��� searchingChar ���ڸ� �˻��Ͽ�
//		  �ش� ��ġ�� ��ȯ(zero base), �˻����� ������ -1�� ��ȯ 
int charPosion (char* targetString, char searchingChar) {
	/* while 
		int i = 0;
		// ���ڿ��� ���������� 0�� �����ϹǷ� �Ʒ��� ���� ���ǽ��� ������ �� �ִ�.
		while(*(targetString+i)){	 
			if(*(targetString+i++) == searchingChar) {	// ++������ i�� ���� �����Ѵ� 
				return i - 1;
			}
		} 
		return -1; 
	*/
	// for�� �̿�
	for(int i = 0; *(targetString+i); i++) {
		if(*(targetString+i) == searchingChar) {
			return i;
		}
	}
	return -1; 
}
