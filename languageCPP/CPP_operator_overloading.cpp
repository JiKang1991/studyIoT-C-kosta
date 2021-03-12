#include <iostream>
// inheritance 활용 예제
class Point {
	double x, y;
public:
	// null 생성자
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

int func1(Point& p);

int main() {
	// struct 타입의 초기화
	// Point 객체의 초기값을 매개변수로 Rect의 기본 생성자를 호출한다.
	// 컴파일러가 자동으로 Point p1, p2 객체를 생성하고 Rect 객체를 초기화한다.
	//Rect r1 = { {10, 10}, {20, 20} };

	double n1 = 10;
	double n2 = 20;

	// class의 생성자를 이용한 초기화
	Point p1(n1, n1);
	Point p2(n2, n2);
	
	p1.setX(15);
	p1.setY(15);
	Point p3 = p1 + 10;		// p3(25, 25)
	printf("Point 클래스의 연산자 오버로딩 테스트1 (+) : p1(%.2f, %.2f) + %d ---> (%.2f, %.2f)\n",
		p1.getX(), p1.getY(), 10, p3.getX(), p3.getX());
	Point p4 = p1 + p3;
	printf("Point 클래스의 연산자 오버로딩 테스트2 (+) : p1(%.2f, %.2f) + p3(%.2f, %.2f) ---> (%.2f, %.2f)\n",
		p1.getX(), p1.getY(), p3.getX(), p3.getX(), p4.getX(), p4.getY());
	
	Point* p5 = &p4;
	
	printf("Point 클래스의 연산자 오버로딩 테스트2 (+) : p1(%.2f, %.2f) + p3(%.2f, %.2f) ---> (%.2f, %.2f)\n",
		p1.getX(), p1.getY(), p3.getX(), p3.getX(), p5->getX(), p5->getY());

	func1(*p5);

	// Point p5 = p1 + p3 + p4;
	
}

int func1(Point& p5) {

	// pointer도 레퍼런스로 받으면 '.'을 사용할 수 있다.
	printf("p5(x, y) = (%.2f, %.2f)\n",	 p5.getX(), p5.getY());

	return 0;
}