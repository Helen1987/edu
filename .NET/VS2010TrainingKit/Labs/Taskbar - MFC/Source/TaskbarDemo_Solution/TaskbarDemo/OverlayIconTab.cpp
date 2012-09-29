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

// OverlayIconTab.cpp : implementation file
//

#include "stdafx.h"
#include "TaskbarDemo.h"
#include "OverlayIconTab.h"
#include "Mainfrm.h"

// COverlayIconTab dialog

IMPLEMENT_DYNAMIC(COverlayIconTab, CDialog)

COverlayIconTab::COverlayIconTab(CWnd* pParent /*=NULL*/)
	: CDialog(COverlayIconTab::IDD, pParent)
{

}

COverlayIconTab::~COverlayIconTab()
{
}

void COverlayIconTab::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(COverlayIconTab, CDialog)
    ON_BN_CLICKED(IDC_MFCBUTTON_INFO_OVERLAY, &COverlayIconTab::OnOverlayIconInfo)
    ON_BN_CLICKED(IDC_MFCBUTTON_QUESTION_OVERLAY, &COverlayIconTab::OnOverlayIconQuestion)
    ON_BN_CLICKED(IDC_MFCBUTTON_NO_VOLUME_OVERLAY, &COverlayIconTab::OnOverlayIconNoVolume)
    ON_BN_CLICKED(IDC_MFCBUTTON_NO_OVERLAY, &COverlayIconTab::OnOverlayIconNone)
END_MESSAGE_MAP()


// COverlayIconTab message handlers

void COverlayIconTab::OnOverlayIconInfo()
{
    // TODO: Add code to set info overlay icon
    CMainFrame* mainFrm = dynamic_cast<CMainFrame*>(AfxGetApp()->GetMainWnd());
    if (mainFrm)
        mainFrm->SetTaskbarOverlayIcon(IDI_ICON_INFO, L"Info");        
}

void COverlayIconTab::OnOverlayIconQuestion()
{
    // TODO: Add code to set question overlay icon
    CMainFrame* mainFrm = dynamic_cast<CMainFrame*>(AfxGetApp()->GetMainWnd());
    if (mainFrm)
        mainFrm->SetTaskbarOverlayIcon(IDI_ICON_QUESTION, L"Question");        
}

void COverlayIconTab::OnOverlayIconNoVolume()
{
    // TODO: Add code to set no-volume overlay icon
    CMainFrame* mainFrm = dynamic_cast<CMainFrame*>(AfxGetApp()->GetMainWnd());
    if (mainFrm)
        mainFrm->SetTaskbarOverlayIcon(IDI_ICON_NO_VOLUME,L"No Volume");        
}

void COverlayIconTab::OnOverlayIconNone()
{
    // TODO: Add code to clear overlay icon
    CMainFrame* mainFrm = dynamic_cast<CMainFrame*>(AfxGetApp()->GetMainWnd());
    if (mainFrm)                                       // Setting the HICON to 0,
        mainFrm->SetTaskbarOverlayIcon((HICON)0, L""); // effectively removes the overlay       
}
