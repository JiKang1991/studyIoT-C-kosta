// CTestDlg.cpp: 구현 파일
//

#include "pch.h"
#include "CPP_MFC_Menu_Dialog.h"
#include "CTestDlg.h"
#include "afxdialogex.h"


// CTestDlg 대화 상자

IMPLEMENT_DYNAMIC(CTestDlg, CDialogEx)

CTestDlg::CTestDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DLG_Test1, pParent)
{

}

CTestDlg::~CTestDlg()
{
}


void CTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATIC_Text1, controlStaticTest);
	DDX_Control(pDX, IDC_EDIT2, controlEditInput);
	DDX_Control(pDX, IDC_EDIT3, controlEditUpper);
	DDX_Control(pDX, IDC_EDIT4, controlEditLength);
}

BEGIN_MESSAGE_MAP(CTestDlg, CDialogEx)
	ON_BN_CLICKED(IDC_BUTTON1, &CTestDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON1, &CTestDlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// CTestDlg 메시지 처리기


BOOL CTestDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.

	// CFont 
	CFont f;
	f.CreateFontW(36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, TEXT("Arial"));

	// 매개변수의 요소가 가지고 있는 주소값을 리턴합니다.(pointer)
	// 기본 문자체계는 유니코드, "" 문자체계는 ASCII 입니다.
	// "" 앞에 L을 적어 컴파일러가 유니코드 문자체계로 치환합니다.
	// SetWindowTestW() : 와이드 문자열을 받습니다.
	//GetDlgItem(IDC_STATIC_Text1)->SetWindowTextW(L"안녕하세요. 반갑습니다.");
	// SetFont()의 매개변수는 객체의 주소값을 이용한다.
	//GetDlgItem(IDC_STATIC_Text1)->SetFont(&f);
	controlStaticTest.SetWindowTextW(L"안녕하세요. 반갑습니다.");
	controlStaticTest.SetFont(&f);
	
	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}




void CTestDlg::OnBnClickedButton1()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CString buf;
	//GetDlgItem(IDC_EDIT2)->GetWindowTextW(buf);
	controlEditInput.GetWindowTextW(buf);
	//GetDlgItem(IDC_EDIT3)->SetWindowTextW(buf.MakeUpper());
	controlEditUpper.SetWindowTextW(buf.MakeUpper());
	int n = buf.GetLength();
	CString s;
	s.Format(L"%d", n);
	//GetDlgItem(IDC_EDIT4)->SetWindowTextW(s);
	controlEditLength.SetWindowTextW(s);
	
}


