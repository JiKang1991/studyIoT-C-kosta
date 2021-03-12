#include <iostream>
// class 및 reference 활용 예제
class Point {	// 기본적으로 private, 외부 참조 불가
public:			// 외부 참조 가능
	int x, y;

	Point(int a, int b) : x(a), y(b) {
		//x = a;
		//y = b;
	}
};

class Rect {
	Point p1, p2;
public:
	// 생성자의 오버로딩
	Rect() : p1(0,0), p2(0,0) {}

	Rect(Point pp1, Point pp2) : p1(pp1), p2(pp2) {
		// p1 = pp1;
		// p2 = pp2;
	}

	// 넓이를 구하는 메소드
	int getArea() {
		// width, length 는 멤버변수가 아닌 지역변수(로컬변수)
		int width = p1.x - p2.x;
		int length = p1.y - p2.y;
		// abs() : 절대값을 리턴하는 함수
		return abs(width * length);
	}

};

// func1의 프로토타입 선언(매개변수 포인터타입)
// r1 = {2, 3}
int func1(Rect* r);

// func2의 프로토타입 선언(매개변수 레퍼런스타입)
int func2(Rect& r);


int main() {
	// struct 타입의 초기화
	// Point 객체의 초기값을 매개변수로 Rect의 기본 생성자를 호출한다.
	// 컴파일러가 자동으로 Point p1, p2 객체를 생성하고 Rect 객체를 초기화한다.
	//Rect r1 = { {10, 10}, {20, 20} };
	
	int n1 = 10;
	int n2 = 20;
	
	// class의 생성자를 이용한 초기화
	Point p1(n1, n1);
	Point p2(n2, n2);
	// class의 생성자를 이용한 초기화
	Rect r1(p1, p2);
	// 오버로딩한 생성자를 이용하여 초기화
	Rect r2;

	// func1이 포인터 형태의 매개변수를 가지고 있으므로 주소값을 매개변수로 전달해야 한다.
	func1(&r1);
	
	// func2가 레퍼런스 형태의 매개변수를 가지고 있으므로 변수명을 매개변수로 전달해야 한다.
	func2(r1);

	printf("여기는 main 입니다.\n");
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 사각형의 면적은 %d입니다.\n", r2.getArea());
}

int func1(Rect* r1) {
	printf("여기는 func1 입니다.\n");
	// 포인터로 전달받은 객체의 멤버를 사용하기 위해서는 '.'이 아닌 '->'을 사용해야 한다.
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 사각형의 면적은 %d입니다.\n", r1 -> getArea());

	return 0;
}

int func2(Rect& r1) {
	printf("여기는 func2 입니다.\n");
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 사각형의 면적은 %d입니다.\n", r1.getArea());

	return 0;
}