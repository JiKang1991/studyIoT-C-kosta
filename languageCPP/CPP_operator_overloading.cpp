#include <iostream>
// inheritance Ȱ�� ����
class Point {
	double x, y;
public:
	// null ������
	Point() {

	}

	Point(double a, double b) : x(a), y(b) {

	}

	void setX(double a) {
		x = a;
	}
	void setY(double a) {
		y = a;
	}
	double getX() {
		return x;
	}
	double getY() {
		return y;
	}

	// p1 = p + n;	p1, p : Point  n : int ==> p1.x = p.x + n;  p1.y = p.y + n;
	Point operator+(int n) {
		Point p1;
		p1.x = x + n;  p1.y = y + n;
		return p1;
	}
	Point operator+(Point p) {
		Point p1;
		p1.x = x + p.x;
		p1.y = y + p.y;
		return p1;
	}
};


int main() {
	// struct Ÿ���� �ʱ�ȭ
	// Point ��ü�� �ʱⰪ�� �Ű������� Rect�� �⺻ �����ڸ� ȣ���Ѵ�.
	// �����Ϸ��� �ڵ����� Point p1, p2 ��ü�� �����ϰ� Rect ��ü�� �ʱ�ȭ�Ѵ�.
	//Rect r1 = { {10, 10}, {20, 20} };

	double n1 = 10;
	double n2 = 20;

	// class�� �����ڸ� �̿��� �ʱ�ȭ
	Point p1(n1, n1);
	Point p2(n2, n2);
	
	p1.setX(15);
	p1.setY(15);
	Point p3 = p1 + 10;		// p3(25, 25)
	printf("Point Ŭ������ ������ �����ε� �׽�Ʈ (+) : p1(%.2f, %.2f) + %d ---> (%.2f, %.2f)\n",
		p1.getX(), p1.getY(), 10, p3.getX(), p3.getX());
	Point p4 = p1 + p3;
	printf("Point Ŭ������ ������ �����ε� �׽�Ʈ (+) : p1(%.2f, %.2f) + p3(%.2f, %.2f) ---> (%.2f, %.2f)\n",
		p1.getX(), p1.getY(), p3.getX(), p3.getX(), p4.getX(), p4.getY());
}