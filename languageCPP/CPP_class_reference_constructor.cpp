#include <iostream>
// class �� reference Ȱ�� ����
class Point {	// �⺻������ private, �ܺ� ���� �Ұ�
public:			// �ܺ� ���� ����
	int x, y;

	Point(int a, int b) : x(a), y(b) {
		//x = a;
		//y = b;
	}
};

class Rect {
	Point p1, p2;
public:
	// �������� �����ε�
	Rect() : p1(0,0), p2(0,0) {}

	Rect(Point pp1, Point pp2) : p1(pp1), p2(pp2) {
		// p1 = pp1;
		// p2 = pp2;
	}

	// ���̸� ���ϴ� �޼ҵ�
	int getArea() {
		// width, length �� ��������� �ƴ� ��������(���ú���)
		int width = p1.x - p2.x;
		int length = p1.y - p2.y;
		// abs() : ���밪�� �����ϴ� �Լ�
		return abs(width * length);
	}

};

// func1�� ������Ÿ�� ����(�Ű����� ������Ÿ��)
// r1 = {2, 3}
int func1(Rect* r);

// func2�� ������Ÿ�� ����(�Ű����� ���۷���Ÿ��)
int func2(Rect& r);


int main() {
	// struct Ÿ���� �ʱ�ȭ
	// Point ��ü�� �ʱⰪ�� �Ű������� Rect�� �⺻ �����ڸ� ȣ���Ѵ�.
	// �����Ϸ��� �ڵ����� Point p1, p2 ��ü�� �����ϰ� Rect ��ü�� �ʱ�ȭ�Ѵ�.
	//Rect r1 = { {10, 10}, {20, 20} };
	
	int n1 = 10;
	int n2 = 20;
	
	// class�� �����ڸ� �̿��� �ʱ�ȭ
	Point p1(n1, n1);
	Point p2(n2, n2);
	// class�� �����ڸ� �̿��� �ʱ�ȭ
	Rect r1(p1, p2);
	// �����ε��� �����ڸ� �̿��Ͽ� �ʱ�ȭ
	Rect r2;

	// func1�� ������ ������ �Ű������� ������ �����Ƿ� �ּҰ��� �Ű������� �����ؾ� �Ѵ�.
	func1(&r1);
	
	// func2�� ���۷��� ������ �Ű������� ������ �����Ƿ� �������� �Ű������� �����ؾ� �Ѵ�.
	func2(r1);

	printf("����� main �Դϴ�.\n");
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� �簢���� ������ %d�Դϴ�.\n", r2.getArea());
}

int func1(Rect* r1) {
	printf("����� func1 �Դϴ�.\n");
	// �����ͷ� ���޹��� ��ü�� ����� ����ϱ� ���ؼ��� '.'�� �ƴ� '->'�� ����ؾ� �Ѵ�.
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� �簢���� ������ %d�Դϴ�.\n", r1 -> getArea());

	return 0;
}

int func2(Rect& r1) {
	printf("����� func2 �Դϴ�.\n");
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� �簢���� ������ %d�Դϴ�.\n", r1.getArea());

	return 0;
}