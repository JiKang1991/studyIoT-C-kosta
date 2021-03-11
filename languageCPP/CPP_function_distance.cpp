#include <iostream>

// ��ǥ�� x��� y���� �������ִ� struct
struct Point {
	int x;
	int y;
};

// Point�� ��ǥ�� ������ �簢���� ���̸� ���ϴ� struct
struct Rect {
	Point p1;
	Point p2;
	// x * y : �� ������ �̷���� �簢���� ����
	int area() {
		int a = p2.x - p1.x;
		int b = p2.y - p1.y;
		return a * b;
	}

	// distance : �Ÿ�
	double distance() {
		int a = p2.x - p1.x;
		int b = p2.y - p1.y;
		return sqrt(a * a + b * b);
	}
};

int main() {
	std::cout << "2���� ��ǥ�� �簢�� ���� ���ϱ�" << std::endl;

	Rect r1 = { {10, 10}, {20, 20} };
	// ctrl + k + c : �ּ� ����, ctrl + k + u :  �ּ� ����
	//r1.p1.x = 15;
	//r1.p1.y = 15;
	printf("�� �� p1(10, 10), p2(%d, %d)�� �����Ǵ� �簢���� ������ %d �Դϴ�.\n\n",
		r1.p2.x, r1.p2.y, r1.area());
	printf("�� �� p1(10, 10), p2(%d, %d)�� �����Ǵ� ������ ���̴� %.2f �Դϴ�.",
		r1.p2.x, r1.p2.y, r1.distance());
}