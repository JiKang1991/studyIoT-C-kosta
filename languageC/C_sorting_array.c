#include<stdio.h>

void swap(int* a, int* b);
int sorting(int* array, int count);

int main() {
	int arr[] = { 1, 3, 5, 7, 8, 2, 4, 0, 8, 6 };
	
	// sizeof()는 macro function(o), function(x)
	// macro function는 컴파일 시에 값이 정해진다.
	// 컴파일시에 sizeof()의 매개변수가 초기화되어있다면
	// 그 매개변수의 크기를 확인할 수 있지만,
	// 초기화되어있지 않다면, 크기를 확인할 수 없다. 
	int arrayLength = sizeof(arr) / sizeof(int);
	
	printf("원 데이터 : \n");
	for(int i = 0; i < arrayLength; i++) {
		printf("%d ", arr[i]);
	}
	printf("\n\n");
	
	sorting(arr, arrayLength);
	
	printf("정렬 데이터 : \n");
	for(int i = 0; i < arrayLength; i++) {
		printf("%d ", arr[i]);
	}
	printf("\n\n");
}

int sorting(int* array, int count) {

	for(int i = 0; i < count -1; i++) {		// 배열의 비교 대상 
		for(int j = i; j < count; j++) {	// 배열의 나머지 
			if(*(array+i) > *(array+j)) { 	// array[i]
				swap(array+i, array+j);
			}
		}
	}
} 

// 두개의 변수를 swap하는 함수
void swap(int* a, int* b) {
	
	int temp = *a;		// a의 값을 임시로 저장하기위한 변수 
	*a = *b;
	*b = temp;
}
