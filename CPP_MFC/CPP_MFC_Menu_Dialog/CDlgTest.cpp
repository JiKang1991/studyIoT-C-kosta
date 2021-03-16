// CDlgTest.cpp: 구현 파일
//

#include "pch.h"
#include "MFC_Application3.h"
#include "CDlgTest.h"
#include "afxdialogex.h"


// CDlgTest 대화 상자

IMPLEMENT_DYNAMIC(CDlgTest, CDialogEx)

CDlgTest::CDlgTest(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DLG_Test1, pParent)
{

}

CDlgTest::~CDlgTest()
{
}

void CDlgTest::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDlgTest, CDialogEx)
	ON_BN_CLICKED(IDC_BUTTON1, &CDlgTest::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CDlgTest::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BTN_OK, &CDlgTest::OnBnClickedBtnOk)
	ON_BN_CLICKED(IDC_BTN_CANCEL, &CDlgTest::OnBnClickedBtnCancel)
	ON_EN_CHANGE(IDC_EDIT1, &CDlgTest::OnEnChangeEdit1)
END_MESSAGE_MAP()


// CDlgTest 메시지 처리기

int flag = 0;
void CDlgTest::OnBnClickedButton1()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CButton* btn = (CButton*)GetDlgItem(IDC_BUTTON1);
	if (flag == 0) {
		btn->SetWindowTextW(L"OFF");
	} else {
		btn->SetWindowTextW(L"ON");
	}
	flag = !flag;
}




void CDlgTest::OnBnClickedButton2()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CFileDialog dlgFile(TRUE);
	OPENFILENAME& ofn = dlgFile.GetOFN();
	ofn.Flags |= OFN_ALLOWMULTISELECT;
	if (dlgFile.DoModal() == IDCANCEL) {
		return;
	}
	CString filePath = dlgFile.GetPathName();	// 선택된 파일에 대한 full path를 리턴 후 대입합니다.
	CFile file;
	// LPCTSTR는 WCAHR와 동일합니다. 2byte 타입입니다.
	// char 배열의 경우 abcd로 문자를 저장합니다.
	// WCHAR 배열의 경우 a0b0c0d0의 형태로 문자를 저장합니다.
	// 2byte를 사용하는 문자의 경우 가나다라마바 의 형태로 문자를 저장합니다. 
	file.Open(filePath, CFile::modeRead);
	// CFile.GetLength() : 파일의 크기를 리턴(int)
	int n = file.GetLength();

	// 포인터를 선언하고 new 키워드로 배열을 선언후 대입하여 동적으로 메모리 공간을 확보합니다.
	char* buf = new char[n];
	WCHAR* wBuf = new WCHAR[n];
	
	// 버퍼에 있는 데이터를 읽는 함수입니다.
	// WCHAR형식의 배열은 읽지 못합니다.
	file.Read(buf, n);
	file.Close();
	//
	MultiByteToWideChar(CP_ACP, 0, buf, (int)strlen(buf), wBuf, n);
	// edit1의 주소값을 가져와 읽은 데이터를 set합니다.
	GetDlgItem(IDC_EDIT1)->SetWindowTextW(wBuf);

	// 사용한 버퍼(배열)을 해제합니다.(new 키워드를 사용한 경우)
	delete wBuf;
	delete buf;
}


void CDlgTest::OnBnClickedBtnOk()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	EndDialog(IDOK);
}


void CDlgTest::OnBnClickedBtnCancel()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	EndDialog(IDCANCEL);
}


void CDlgTest::OnEnChangeEdit1()
{
	// TODO:  RICHEDIT 컨트롤인 경우, 이 컨트롤은
	// CDialogEx::OnInitDialog() 함수를 재지정 
	//하고 마스크에 OR 연산하여 설정된 ENM_CHANGE 플래그를 지정하여 CRichEditCtrl().SetEventMask()를 호출하지 않으면
	// 이 알림 메시지를 보내지 않습니다.

	// TODO:  여기에 컨트롤 알림 처리기 코드를 추가합니다.
}
