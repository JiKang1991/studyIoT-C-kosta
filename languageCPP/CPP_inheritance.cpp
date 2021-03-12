#include <iostream>
// inheritance Ȱ�� ����
class Point {	
	int x, y;
public:			

	Point(int a, int b) : x(a), y(b) {	}

	void setX(int a) {
		x = a;
	}
	void setY(int a) {
		y = a;
	}
	int getX() {
		return x;
	}
	int getY() {
		return y;
	}
};

class Rect {
private:
	Point p1, p2;
public:
	
	Rect() : p1(0, 0), p2(0, 0) {}

	Rect(Point pp1, Point pp2) : p1(pp1), p2(pp2) {
		// p1 = pp1;
		// p2 = pp2;
	}

	void setP1(Point pp1) {
		p1 = pp1;
	}
	void setP2(Point pp2) {
		p2 = pp2;
	}
	Point getP1() {
		return p1;
	}
	Point getP2() {
		return p2;
	}
	
	int getArea() {
		int width = p1.getX() - p2.getX();
		int length = p1.getY() - p2.getY();
		
		return abs(width * length);
	}

};

// Point Ŭ������ Rect Ŭ������ ���еǾ� ����.
// ������ ������ Point �����ڿ� Rect �����ڰ� �˷��� ����.
// Rect Ŭ�������� �簢���� ������ ���ϴ� �Լ��� ����
//
// ---> Rect�� �밢�� ���̸� ���ϴ� Distance �Լ��� �ʿ���.
// distance = sqrt(x*x + y*y)
// sqrt() �޼ҵ�� ��Ʈ��(double)�� �����Ѵ�.

// Rect class�� ��� (public ���) / private ���(�⺻��)�� �����ϴ�
class RectEx : public Rect {
public:
	RectEx(Point pp1, Point pp2) : Rect(pp1, pp2) {
		// SetP1(pp1);
		// SetP2(pp2);
		// Rect(pp1, pp2);

	}
	double distance() {
		int width = getP1().getX() - getP2().getX();
		int length = getP1().getY() - getP2().getY();

		return sqrt(abs(width * width + length * length));
	}
};

int func1(Rect* r);
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

	RectEx r3(p1, p2);

	// func1�� ������ ������ �Ű������� ������ �����Ƿ� �ּҰ��� �Ű������� �����ؾ� �Ѵ�.
	func1(&r1);

	// func2�� ���۷��� ������ �Ű������� ������ �����Ƿ� �������� �Ű������� �����ؾ� �Ѵ�.
	func2(r1);

	printf("����� main �Դϴ�.\n");
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� �簢���� ������ %d�Դϴ�.\n", r2.getArea());
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� ������ ���̴� %.2f�Դϴ�.\n", r3.distance());
}

int func1(Rect* r1) {
	printf("����� func1 �Դϴ�.\n");
	// �����ͷ� ���޹��� ��ü�� ����� ����ϱ� ���ؼ��� '.'�� �ƴ� '->'�� ����ؾ� �Ѵ�.
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� �簢���� ������ %d�Դϴ�.\n", r1->getArea());

	return 0;
}

int func2(Rect& r1) {
	printf("����� func2 �Դϴ�.\n");
	printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� �簢���� ������ %d�Դϴ�.\n", r1.getArea());

	return 0;
}