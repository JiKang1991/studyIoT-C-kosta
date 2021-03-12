#include <iostream>
// inheritance Ȱ�� ����
class Point {
	double x, y;
public:

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
};

class Rect {
private:
	Point p1, p2;
public:

	//Rect() : p1(0, 0), p2(0, 0) {}

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

	double getArea() {
		double width = p1.getX() - p2.getX();
		double length = p1.getY() - p2.getY();

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
		double width = getP1().getX() - getP2().getX();
		double length = getP1().getY() - getP2().getY();

		return sqrt(abs(width * width + length * length));
	}
};

// Mission : Circle Ŭ������ �����ϰ� ��� �Լ��� �����ϼ���
// Member Function : ����(diameter), ���ѷ�(clength), �� ����(cArea)
// ��, Rect Ŭ������ ��ӹ޾Ƽ� �����ϼ���
// Rect�� �� ���� �������� �ϴ� ��(circle) ����

# define PI 3.14159265
class Circle : public Rect {
private:
	Point cp;			// �߽���
	double radius;		// ������
	
public:
	Circle(Point p1, Point p2) : Rect(p1, p2), cp(0,0), radius(0){
		// Rect(p1, p2);
		cp.setX((p1.getX() + p2.getX()) / 2);
		cp.setY((p1.getY() + p2.getY()) / 2);
		radius = calRadius();
	}
	
	double calRadius() {
		double a = getP2().getX() - getP1().getX();
		double b = getP2().getY() - getP1().getY();
		
		return (sqrt(abs(a * a + b * b)) / 2);
	}
	
	double getDiameter() {
		return radius * 2;
	}

	double getCArea() {
		return (radius*radius) * PI;
	}

	double getCLength() {
		return getDiameter() * PI;
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
	
	//RectEx r3(p1, p2);
		
	Circle c1(p1, p2);

	printf("����� main �Դϴ�.\n");
	//printf("�� �� p1(10, 10)�� p2(20, 20)���� �̷���� ������ ���̴� %.2f�Դϴ�.\n", r3.distance());
	printf("�� �� p1(10, 10)�� p2(20, 20)�� ���������� �ϴ� �� ������ ���̴� %.2f�Դϴ�.\n", c1.getDiameter());
	printf("�� �� p1(10, 10)�� p2(20, 20)�� ���������� �ϴ� �� �ѷ��� ���̴� %.2f�Դϴ�.\n", c1.getCLength());
	printf("�� �� p1(10, 10)�� p2(20, 20)�� ���������� �ϴ� ���� ���̴� %.2f�Դϴ�.\n", c1.getCArea());

}
