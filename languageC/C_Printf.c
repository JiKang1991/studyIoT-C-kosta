#include<stdio.h>
/* printf Ȱ���ϱ� */ 
main(){
	// printf Ȱ���ϱ�
	printf("Hello Everybody \n");
	printf("%d \n", 1234);
	printf("%d %d \n", 10, 20);
	printf("My name is ~ %s \n\n", "�ؼ�");
	printf("My age is ~ %d\n", 10);
	
	// �̽������� ���� Ȱ���ϱ�
	printf("Ư������\t �ǹ�\n");
	printf("\\a :\t\t ����� �߻�\n"); 
	printf("\\b :\t\t �齺���̽�(backspace)\n");
	printf("\\f :\t\t �� �ǵ�(form feed)\n");
	printf("\\n :\t\t ����\n");
	printf("\\r :\t\t ĳ���� ����(carriage return)\n");
	printf("\\t :\t\t ���� ��\n");
	printf("\\v :\t\t ���� ��\n");
	printf("\\\\ :\t\t �齽����(\\)\n");
	printf("\\\' :\t\t ���� ����ǥ\n");
	printf("\\\" :\t\t ū ����ǥ\n"); 
	
	//
	printf("%d%d\n", 123, 456);	// 123456
	printf("%-8d %-8d %d\n", 123, 456, 789); // 123     456     789
	printf("%8d %8d %d\n\n\n", 123, 456, 789);	//      123     456     789
	
	printf("�Ǽ��� ��� : %f %f \n", 3.14159265, 456.789123);	// 3.141593 456.789123
	printf("�Ǽ��� ��� : %8.2f %10.3f \n\n", 3.14159265, 456.789123);	//      3.14    456.789
	
	// sizeof Ȱ�� 
	printf("data type �� byte �� (int) : %d byte\n", sizeof(int));
	printf("data type �� byte �� (char) : %d byte\n", sizeof(char));
	printf("data type �� byte �� (long) : %d byte\n", sizeof(long));
	printf("data type �� byte �� (float) : %d byte\n", sizeof(float));
	printf("data type �� byte �� (double) : %d byte\n", sizeof(double));
}
