#include <iostream>

// ��ǥ�� x��� y���� �������ִ� class
class Point {
public:
	int x = 0;
	int y = 0;
	
	// ������
	//Point() {
	//	printf("�⺻ Point ������ ���.\n");
	//}

	Point(int a, int b) {
		x = a;
		y = b;
		printf("Point(int a, int b) ������ ���. x = %d, y = %d\n", x, y);
	}

	// �޼���
	int* ppp = 0;

	// �Ҹ���
	~Point() {
		delete ppp;
	}

};

// Point�� ��ǥ�� ������ �簢���� ���̸� ���ϴ� class
class Rect {
public:
	Point* p1;
	Point* p2;

	//Rect() {
	//	printf("Rect() ������ ���.\n");
	//}

	Rect(Point* a, Point* b) {
		printf("Rect(Point a, Point b) ������ ���.\n");
		p1 = a;
		p2 = b;
	}
	
	// x * y : �� ������ �̷���� �簢���� ����
	int area() {
		int a = (*p2).x - (*p1).x;
		int b = (*p2).y - (*p1).y;
		return a * b;
	}

	double distance();
};

// �Լ��� class�� �ܺο��� �����Ͽ� ����� �� �ִ�.
double Rect::distance() {
	int a = (*p2).x - (*p1).x;
	int b = (*p2).y - (*p1).y;
	return sqrt(a * a + b * b);
}

// class Ŭ������ : �θ� Ŭ������{ }; = ��Ӱ������� ����
// ��Ӱ��迡���� ���� Ŭ������ ������� ���� Ŭ�������� ����� �� �ִ�.
class RectEx : Rect {
private:
	
	//Point p3 = { p1.x, p2.y };	// p1�� p2�� ���� �̿��Ѵ�. (p1.x, p2.y)
	//Point p4 = { p2.x, p1.y };	// p1�� p2�� ���� �̿��Ѵ�. (p2.x, p1.y)

public:	
	RectEx(Point* p1, Point* p2) {
		Rect(p1, p2);
		printf("RectEx(Point p1, Point p2) ������ ���.\n");
	}


	int tLength() {
		int a = (*p1).x - (*p2).x;
		int b = (*p1).y - (*p2).y;
		return a * 2 + b * 2;
	}	
};

int main() {
	std::cout << "2���� ��ǥ�� �簢�� �ѷ� ���ϱ�" << std::endl;
	Point p1 = { 10, 10 };
	Point p2 = { 20, 20 };
	
	RectEx r2 = RectEx(&p1 , &p2);
	
	printf("�簢���� ��ü �ѷ����̴� %d�Դϴ�.", r2.tLength());
	
}