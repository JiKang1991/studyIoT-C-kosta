#include<stdio.h>

void swap(int* a, int* b);
int sorting(int* array, int count);

int main() {
	int arr[] = { 1, 3, 5, 7, 8, 2, 4, 0, 8, 6 };
	
	// sizeof()�� macro function(o), function(x)
	// macro function�� ������ �ÿ� ���� ��������.
	// �����Ͻÿ� sizeof()�� �Ű������� �ʱ�ȭ�Ǿ��ִٸ�
	// �� �Ű������� ũ�⸦ Ȯ���� �� ������,
	// �ʱ�ȭ�Ǿ����� �ʴٸ�, ũ�⸦ Ȯ���� �� ����. 
	int arrayLength = sizeof(arr) / sizeof(int);
	
	printf("�� ������ : \n");
	for(int i = 0; i < arrayLength; i++) {
		printf("%d ", arr[i]);
	}
	printf("\n\n");
	
	sorting(arr, arrayLength);
	
	printf("���� ������ : \n");
	for(int i = 0; i < arrayLength; i++) {
		printf("%d ", arr[i]);
	}
	printf("\n\n");
}

int sorting(int* array, int count) {

	for(int i = 0; i < count -1; i++) {		// �迭�� �� ��� 
		for(int j = i; j < count; j++) {	// �迭�� ������ 
			if(*(array+i) > *(array+j)) { 	// array[i]
				swap(array+i, array+j);
			}
		}
	}
} 

// �ΰ��� ������ swap�ϴ� �Լ�
void swap(int* a, int* b) {
	
	int temp = *a;		// a�� ���� �ӽ÷� �����ϱ����� ���� 
	*a = *b;
	*b = temp;
}
