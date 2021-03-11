#include <iostream>

// 좌표의 x축과 y축을 설정해주는 class
class Point {
// private : 해당 클래스의 내부에서만 접근할 수 있도록 허용하는 키워드 (기본)
private:
// public : 클래스의 외부에서 해당 클래스의 멤버를 참조할 수 있도록 허용하는 키워드
public:
	int x;
	int y;
};

// Point의 좌표를 가지고 사각형의 넓이를 구하는 class
class Rect {
// private : 해당 클래스의 내부에서만 접근할 수 있도록 허용하는 키워드 (기본)
private:
// public : 클래스의 외부에서 해당 클래스의 멤버를 참조할 수 있도록 허용하는 키워드
public:
	Point p1;
	Point p2;
	// x * y : 두 점으로 이루어진 사각형의 넓이
	int area() {
		int a = p2.x - p1.x;
		int b = p2.y - p1.y;
		return a * b;
	}

	// distance : 거리
	double distance() {
		int a = p2.x - p1.x;
		int b = p2.y - p1.y;
		return sqrt(a * a + b * b);
	}
};

int main() {
	std::cout << "2개의 좌표로 사각형 넓이 구하기" << std::endl;

	Rect r1 = { {10, 10}, {20, 20} };
	// ctrl + k + c : 주석 설정, ctrl + k + u :  주석 해제
	//r1.p1.x = 15;
	//r1.p1.y = 15;
	printf("두 점 p1(10, 10), p2(%d, %d)로 구성되는 사각형의 면적은 %d 입니다.\n\n",
		r1.p2.x, r1.p2.y, r1.area());
	printf("두 점 p1(10, 10), p2(%d, %d)로 구성되는 직선의 길이는 %.2f 입니다.",
		r1.p2.x, r1.p2.y, r1.distance());
}