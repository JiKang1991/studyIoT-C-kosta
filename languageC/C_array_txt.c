// �迭

/* �迭�̶�?
	- �� �̻��� ������ ���ÿ� �����ϴ� ȿ���� ���Ѵ�.
	- ���� ���� �����͸� �ϰ������� ó���ؾ� �ϴ� ��쿡 �����ϴ�.
	- ������ Ư���� ���� ���� �ְ�, ������ Ư���� ���� ���� �ִ�. */
	
/* �迭 ���� �־ �ʿ��� �� 3����
	ex) int array[10];
	- �迭��� �ڷ��� : �迭�� �����ϴ� ������ �ڷ��� ex) int 
	- �迭 �̸� : �迭�� ������ �� ���Ǵ� �̸� ex) array
	- ����� : �迭�� ũ�⸦ ���������� �����Ϸ����� �˸���. [] 
	- �迭 ���� : �迭�� �����ϴ� ������ ���� ex) 10 */
	
/* 1���� �迭
	- �迭 ��ҿ��� �ε����� �����Ѵ�. 
	- �ε����� 0���� */ 
	
/* �迭 ���� ����
	int main(void) {
		int array[10];		// �迭 ����
		array[0] = 10;		// ù ��° ��� ����
		array[1] = 20;		// �� ��° ��� ����
		array[2] = 30; 		// �� ��° ��� ����
		...
		retrun 0;
	}
	- ����� ���ο��� ��� �Ӹ� �ƴ϶� ������ ������ �� �ִ�.
		ex) array[s] = 10;	->	S + 1 ��° ��ҿ� 10�� �����϶� */
		
/* ����� ���ÿ� �ʱ�ȭ
	int main(void){
		int arr1[5] = {1, 2, 3, 4, 5};
		int arr2[] = {1, 3, 5, 7, 9};		//  ����Ͽ� �迭�� ũ�⸦ �������� �ʴ��� ������ �����ϴ� 
		int arr3[5] = {1, 2};				//  5�� ��Ҹ� ������ �ִ� �迭�� �����ϰ� �������� �����Ⱚ�� ����ȴ�.
	}
*/

/* ���ڿ� ���
	- ���ڿ��̸鼭 ����� Ư¡�� ���Ѵ�.
	- ���� = 1byte char ( ASCII ���� )
	- ���ڿ� = char array + null(0) 
	ex) printf("Hello World! \n");	
*/

/* ���ڿ� ����
	- ���ڿ��̸鼭 ������ Ư¡�� ���Ѵ�.
	ex) char str1[5] = "Good";	-> str[0] = "G", str[1] = "o", str[2] = "o", str[3] = "d", str[4] = 0
		char str2[]	= "morning"; -> str2[0] ~ str[6] = "morning", str2[7] = 0
*/

/* ���ڿ��� char�� �迭�� ������
	char arr1[] = "abc";					// ���� ��� 
	char arr2[] = {'a', 'b', 'c'};			// ������ ��� 
	char arr3[] = {'a', 'b', 'c', '\0'}; 	// ���� ���, \0 = null ASCII ������ 0 
*/ 

/* ������ �迭
	- 2���� �̻��� �迭
	- ������ �迭�� ����
		ex)
			int arr[100]		1���� �迭 
			int arr[10][10]		10x10 2���� �迭
			int arr[5][5][5]	5x5x5, 3���� �迭	
*/

/* 2���� �迭�� ���ٹ��
	int main() {
		int arr[3][3];
		arr[0][0] = 2;
		arr[1][0] = 4;
		arr[2][2] = 8;
	}
*/

/* 2���� �迭�� �ʱ�ȭ
	int arr[3][3] = {
		{1, 2, 3},
		{1, 2, 3},
		{1, 2, 3}
	};
	
	int arr[3][3] = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	-> {1, 2, 3} {4, 5, 6} {7, 8, 9}
*/

/* 3���� �迭 */ 
	
	
	
	
	