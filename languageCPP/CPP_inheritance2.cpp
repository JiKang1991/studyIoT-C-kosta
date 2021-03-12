#include <iostream>
// inheritance 활용 예제
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
		double width = getP1().getX() - getP2().getX();
		double length = getP1().getY() - getP2().getY();

		return sqrt(abs(width * width + length * length));
	}
};

// Mission : Circle 클래스를 정의하고 멤버 함수를 구현하세요
// Member Function : 지름(diameter), 원둘레(clength), 원 면적(cArea)
// 단, Rect 클래스를 상속받아서 구현하세요
// Rect의 두 점을 지름으로 하는 원(circle) 정의

# define PI 3.14159265
class Circle : public Rect {
private:
	Point cp;			// 중심점
	double radius;		// 반지름
	
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
	// struct 타입의 초기화
	// Point 객체의 초기값을 매개변수로 Rect의 기본 생성자를 호출한다.
	// 컴파일러가 자동으로 Point p1, p2 객체를 생성하고 Rect 객체를 초기화한다.
	//Rect r1 = { {10, 10}, {20, 20} };

	double n1 = 10;
	double n2 = 20;

	// class의 생성자를 이용한 초기화
	Point p1(n1, n1);
	Point p2(n2, n2);
	
	//RectEx r3(p1, p2);
		
	Circle c1(p1, p2);

	printf("여기는 main 입니다.\n");
	//printf("두 점 p1(10, 10)과 p2(20, 20)으로 이루어진 직선의 길이는 %.2f입니다.\n", r3.distance());
	printf("두 점 p1(10, 10)과 p2(20, 20)을 반지름으로 하는 원 지름의 길이는 %.2f입니다.\n", c1.getDiameter());
	printf("두 점 p1(10, 10)과 p2(20, 20)을 반지름으로 하는 원 둘레의 길이는 %.2f입니다.\n", c1.getCLength());
	printf("두 점 p1(10, 10)과 p2(20, 20)을 반지름으로 하는 원의 넓이는 %.2f입니다.\n", c1.getCArea());

}
