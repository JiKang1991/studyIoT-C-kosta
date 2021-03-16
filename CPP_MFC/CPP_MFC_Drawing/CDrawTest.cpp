// CDrawTest.cpp: 구현 파일
//

#include "pch.h"
#include "CPP_MFC_Drawing.h"
#include "CDrawTest.h"
#include "afxdialogex.h"


// CDrawTest 대화 상자

IMPLEMENT_DYNAMIC(CDrawTest, CDialogEx)

CDrawTest::CDrawTest(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DLG_DrawTest, pParent)
{

}

CDrawTest::~CDrawTest()
{
}

void CDrawTest::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDrawTest, CDialogEx)
	ON_WM_LBUTTONDOWN()
END_MESSAGE_MAP()


// CDrawTest 메시지 처리기

// 드로잉 패널의 주소값을 저장하는 변수입니다.
CStatic* PDraw;
// divice context의 주소값을 저장하는 변수입니다.
CDC* PDC;

BOOL CDrawTest::OnInitDialog()
{
	CDialogEx::OnInitDialog();
		
	PDraw = (CStatic*)GetDlgItem(IDC_PNL_Draw);
	PDC = GetDC();									// divice context의 주소값을 리턴하여 대입합니다.

	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}

// 마우스의 좌측 버튼을 눌렀을때 발생할 작업을 정의하는 함수 입니다.
// 매개 변수 CPoint는 좌측 버튼이 눌렸을 때 커서가 위치하고있는 좌표를 의미합니다.
void CDrawTest::OnLButtonDown(UINT nFlags, CPoint point)
{
	int r = 100;		// 원의 반지름 값을 가지고있는 변수입니다.
	//Ellipse() 타원을 
	PDC->Ellipse(point.x - r, point.y - r, point.x + r, point.y + r);
	//PDC->Ellipse(100, 100, 300, 300);

	CDialogEx::OnLButtonDown(nFlags, point);
}
