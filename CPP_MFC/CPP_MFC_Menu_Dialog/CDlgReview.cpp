// CDlgReview.cpp: 구현 파일
//

#include "pch.h"
#include "MFC_Application3.h"
#include "CDlgReview.h"
#include "afxdialogex.h"


// CDlgReview 대화 상자

IMPLEMENT_DYNAMIC(CDlgReview, CDialogEx)

CDlgReview::CDlgReview(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DLG_Review, pParent)
{

}

CDlgReview::~CDlgReview()
{
}

void CDlgReview::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDlgReview, CDialogEx)
	ON_BN_CLICKED(IDC_BUTTON1, &CDlgReview::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CDlgReview::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &CDlgReview::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON4, &CDlgReview::OnBnClickedButton4)
END_MESSAGE_MAP()


// CDlgReview 메시지 처리기

int flag2 = 0;
void CDlgReview::OnBnClickedButton1()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CButton* pbtn = (CButton*)GetDlgItem(IDC_BUTTON1);
	if (flag2 == 0) {
		pbtn->SetWindowTextW(L"ON");
	}
	else {
		pbtn->SetWindowTextW(L"OFF");
	}
	flag2 = !flag2;
}


void CDlgReview::OnBnClickedButton2()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CFileDialog fileDialog(TRUE);
	OPENFILENAME& ofn = fileDialog.GetOFN();
	ofn.Flags |= OFN_ALLOWMULTISELECT;
	if (fileDialog.DoModal() == IDCANCEL) {
		return;
	}
	CString filePath = fileDialog.GetPathName();
	CFile file;
	file.Open(filePath, CFile::modeRead);
	int n = file.GetLength();

	char* buf = new char[n];
	WCHAR* wBuf = new WCHAR[n];

	file.Read(buf, n);
	file.Close();

	MultiByteToWideChar(CP_ACP, 0, buf, n, wBuf, n);

	GetDlgItem(IDC_EDIT1)->SetWindowTextW(wBuf);

	delete wBuf;
	delete buf;
}


void CDlgReview::OnBnClickedButton3()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	EndDialog(IDOK);
}


void CDlgReview::OnBnClickedButton4()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	EndDialog(IDCANCEL);
}


BOOL CDlgReview::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.

	CFont font;
	font.CreateFontW(36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, TEXT("Arial"));
	GetDlgItem(IDC_BUTTON1)->SetFont(&font, 1);
	GetDlgItem(IDC_BUTTON2)->SetFont(&font, 1);
	GetDlgItem(IDC_BUTTON3)->SetFont(&font, 1);
	GetDlgItem(IDC_BUTTON4)->SetFont(&font, 1);
	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}
