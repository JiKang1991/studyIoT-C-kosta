#include <iostream>
// inheritance 활용 예제
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

// Point 클래스와 Rect 클래스는 은닉되어 있음.
// 공개된 정보는 Point 생성자와 Rect 생성자가 알려져 있음.
// Rect 클래스에는 사각형의 면적을 구하는 함수가 존재
//
// ---> Rect의 대각선 길이를 구하는 Distance 함수가 필요함.
// distance = sqrt(x*x + y*y)
// sqrt() 메소드는 루트값(double)을 리턴한다.

// Rect class를 상속 (public 상속) / private 상속(기본값)도 가능하다
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

	RectEx r3(p1, p2);

	// func1이 포인터 형태의 매개변수를 가지고 있으므로 주소값을 매개변수로 전달해야 한다.
	func1(&r1);

	// func2가 레퍼런스 형태의 매개변수를 가지고 있으므로 변수명을 매개변수로 전달해야 한다.
	func2(r1);

	printf("여기는 main 입니다.\n");
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 사각형의 면적은 %d입니다.\n", r2.getArea());
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 직선의 길이는 %.2f입니다.\n", r3.distance());
}

int func1(Rect* r1) {
	printf("여기는 func1 입니다.\n");
	// 포인터로 전달받은 객체의 멤버를 사용하기 위해서는 '.'이 아닌 '->'을 사용해야 한다.
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 사각형의 면적은 %d입니다.\n", r1->getArea());

	return 0;
}

int func2(Rect& r1) {
	printf("여기는 func2 입니다.\n");
	printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 사각형의 면적은 %d입니다.\n", r1.getArea());

	return 0;
}