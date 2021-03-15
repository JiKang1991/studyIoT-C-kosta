// CHiDlg.cpp: 구현 파일
//

#include "pch.h"
#include "CPP_MFC_Menu_Dialog.h"
#include "CHiDlg.h"
#include "afxdialogex.h"


// CHiDlg 대화 상자

IMPLEMENT_DYNAMIC(CHiDlg, CDialogEx)

CHiDlg::CHiDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_CHiDlg, pParent)
{

}

CHiDlg::~CHiDlg()
{
}

void CHiDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CHiDlg, CDialogEx)
//	ON_COMMAND(ID_HI, &CHiDlg::OnHi)
ON_COMMAND(ID_HI, &CHiDlg::OnHi)
ON_COMMAND(ID_HI, &CHiDlg::OnHi)
END_MESSAGE_MAP()


// CHiDlg 메시지 처리기



BOOL CHiDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.

	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}


void CHiDlg::OnHi()
{
	// TODO: 여기에 명령 처리기 코드를 추가합니다.
}
