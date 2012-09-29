// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

// MainTabCtrl.cpp : implementation file
//

#include "stdafx.h"
#include "TaskbarDemo.h"
#include "MainTabCtrl.h"
#include "JumpListTab.h"
#include "OverlayIconTab.h"
#include "ProgressBarTab.h"

// CMainTabCtrl

IMPLEMENT_DYNAMIC(CMainTabCtrl, CTabCtrl)

CMainTabCtrl::CMainTabCtrl()
{
    m_Ids[0] = IDD_DIALOG_OVERLAY_ICON;
    m_Ids[1] = IDD_DIALOG_PROGRESS_BAR;
    m_Ids[2] = IDD_DIALOG_JUMP_LIST;

	m_Dialogs[0] = new COverlayIconTab();
	m_Dialogs[1] = new CProgressBarTab();
	m_Dialogs[2] = new CJumpListTab();

	m_nPageCount = 3;
}

CMainTabCtrl::~CMainTabCtrl()
{
}

void CMainTabCtrl::InitDialogs()
{
    for (int i = 0; i < m_nPageCount; i++)
        m_Dialogs[i]->Create(m_Ids[i],GetParent());
}

void CMainTabCtrl::CreateTabs()
{
	int nSel = GetCurSel();
	if(m_Dialogs[nSel]->m_hWnd)
		m_Dialogs[nSel]->ShowWindow(SW_HIDE);

	CRect l_rectClient;
	CRect l_rectWnd;

	GetClientRect(l_rectClient);
	AdjustRect(FALSE,l_rectClient);
	GetWindowRect(l_rectWnd);
	GetParent()->ScreenToClient(l_rectWnd);
	l_rectClient.OffsetRect(l_rectWnd.left,l_rectWnd.top);

	for(int i=0; i < m_nPageCount; i++){
		m_Dialogs[i]->SetWindowPos(&wndTop, l_rectClient.left,l_rectClient.top,l_rectClient.Width(),l_rectClient.Height(),SWP_HIDEWINDOW);
	}
	
    m_Dialogs[nSel]->SetWindowPos(&wndTop,l_rectClient.left,l_rectClient.top,l_rectClient.Width(),l_rectClient.Height(),SWP_SHOWWINDOW);

	m_Dialogs[nSel]->ShowWindow(SW_SHOW);

}

BEGIN_MESSAGE_MAP(CMainTabCtrl, CTabCtrl)
	//{{AFX_MSG_MAP(CMainTabCtrl)
	ON_NOTIFY_REFLECT(TCN_SELCHANGE, OnSelchange)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()



// CMainTabCtrl message handlers

void CMainTabCtrl::OnSelchange(NMHDR* pNMHDR, LRESULT* pResult) 
{
	// TODO: Add your control notification handler code here
	CreateTabs();
	*pResult = 0;
}

