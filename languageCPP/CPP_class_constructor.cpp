#include <iostream>

// 좌표의 x축과 y축을 설정해주는 class
class Point {
public:
	int x = 0;
	int y = 0;
	
	// 생성자
	//Point() {
	//	printf("기본 Point 생성자 사용.\n");
	//}

	Point(int a, int b) {
		x = a;
		y = b;
		printf("Point(int a, int b) 생성자 사용. x = %d, y = %d\n", x, y);
	}

	// 메서드
	int* ppp = 0;

	// 소멸자
	~Point() {
		delete ppp;
	}

};

// Point의 좌표를 가지고 사각형의 넓이를 구하는 class
class Rect {
public:
	Point* p1;
	Point* p2;

	//Rect() {
	//	printf("Rect() 생성자 사용.\n");
	//}

	Rect(Point* a, Point* b) {
		printf("Rect(Point a, Point b) 생성자 사용.\n");
		p1 = a;
		p2 = b;
	}
	
	// x * y : 두 점으로 이루어진 사각형의 넓이
	int area() {
		int a = (*p2).x - (*p1).x;
		int b = (*p2).y - (*p1).y;
		return a * b;
	}

	double distance();
};

// 함수를 class의 외부에서 선언하여 사용할 수 있다.
double Rect::distance() {
	int a = (*p2).x - (*p1).x;
	int b = (*p2).y - (*p1).y;
	return sqrt(a * a + b * b);
}

// class 클래스명 : 부모 클래스명{ }; = 상속관계임을 선언
// 상속관계에서는 상위 클래스의 멤버들을 하위 클래스에서 사용할 수 있다.
class RectEx : Rect {
private:
	
	//Point p3 = { p1.x, p2.y };	// p1과 p2의 값을 이용한다. (p1.x, p2.y)
	//Point p4 = { p2.x, p1.y };	// p1과 p2의 값을 이용한다. (p2.x, p1.y)

public:	
	RectEx(Point* p1, Point* p2) {
		Rect(p1, p2);
		printf("RectEx(Point p1, Point p2) 생성자 사용.\n");
	}


	int tLength() {
		int a = (*p1).x - (*p2).x;
		int b = (*p1).y - (*p2).y;
		return a * 2 + b * 2;
	}	
};

int main() {
	std::cout << "2개의 좌표로 사각형 둘레 구하기" << std::endl;
	Point p1 = { 10, 10 };
	Point p2 = { 20, 20 };
	
	RectEx r2 = RectEx(&p1 , &p2);
	
	printf("사각형의 전체 둘레길이는 %d입니다.", r2.tLength());
	
}