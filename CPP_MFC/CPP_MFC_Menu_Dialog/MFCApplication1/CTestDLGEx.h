#pragma once


// CTestDLGEx 대화 상자

class CTestDLGEx : public CDialogEx
{
	DECLARE_DYNAMIC(CTestDLGEx)

public:
	CTestDLGEx(CWnd* pParent = nullptr);   // 표준 생성자입니다.
	virtual ~CTestDLGEx();

// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_DLG_Test11 };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	DECLARE_MESSAGE_MAP()
};
