#pragma once


// CTestDlg 대화 상자

class CTestDlg : public CDialogEx
{
	DECLARE_DYNAMIC(CTestDlg)

public:
	CTestDlg(CWnd* pParent = nullptr);   // 표준 생성자입니다.
	virtual ~CTestDlg();

// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_DLG_Test1 };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.
	
	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	CStatic controlStaticTest;
	
	afx_msg void OnBnClickedButton1();
	CEdit controlEditInput;
	CEdit controlEditUpper;
	CEdit controlEditLength;
//	afx_msg void OnHi();
};
