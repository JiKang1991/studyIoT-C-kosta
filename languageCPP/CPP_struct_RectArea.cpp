#include <iostream>

// 좌표의 x축과 y축을 설정해주는 struct
struct Point {
	int x;
	int y;
};

// Point의 좌표를 가지고 사각형의 넓이를 구하는 struct
struct Rect {
	Point p1;
	Point p2;
	// x * y : 두 점으로 이루어진 사각형의 넓이
	int area() {
		int x = p2.x - p1.x;
		int y = p2.y - p1.y;
		return x * y;
	}
};

int main() {
	std::cout << "2개의 좌표로 사각형 넓이 구하기" << std::endl;

	Rect r1 = { {10, 10}, {20, 20} };
	// ctrl + k + c : 주석 설정, ctrl + k + u :  주석 해제
	//r1.p1.x = 15;
	//r1.p1.y = 15;
	printf("두 점 p1(10, 10), p2(%d, %d)로 구성되는 사각형의 면적은 %d 입니다.",
		r1.p2.x, r1.p2.y, r1.area());
}