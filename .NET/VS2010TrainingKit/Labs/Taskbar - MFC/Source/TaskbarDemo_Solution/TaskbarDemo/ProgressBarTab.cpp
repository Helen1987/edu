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

// ProgressBarTab.cpp : implementation file
//

#include "stdafx.h"
#include "TaskbarDemo.h"
#include "ProgressBarTab.h"
#include "Mainfrm.h"


// CProgressBarTab dialog

IMPLEMENT_DYNAMIC(CProgressBarTab, CDialog)

    CProgressBarTab::CProgressBarTab(CWnd* pParent /*=NULL*/)
    : CDialog(CProgressBarTab::IDD, pParent)
    , m_ProgressSliderValue(0)
{
}

CProgressBarTab::~CProgressBarTab()
{
}

void CProgressBarTab::DoDataExchange(CDataExchange* pDX)
{
    CDialog::DoDataExchange(pDX);

    DDX_Control(pDX, IDC_PROGRESS_STATUS_COMBO, m_ProgrssStatusCombo);
    DDX_Control(pDX, IDC_PROGRSS_SLIDER, m_ProgressSlider);
    DDX_Slider(pDX, IDC_PROGRSS_SLIDER, m_ProgressSliderValue);
    DDV_MinMaxInt(pDX, m_ProgressSliderValue, 0, 100);
}

BOOL CProgressBarTab::OnInitDialog()
{
    if (!CDialog::OnInitDialog())
        return FALSE;

    m_ProgrssStatusCombo.SetCurSel(0); // Normal is initially selected

    return TRUE;
}

BEGIN_MESSAGE_MAP(CProgressBarTab, CDialog)
    //}}AFX_MSG_MAP
    ON_CBN_SELCHANGE(IDC_PROGRESS_STATUS_COMBO, &CProgressBarTab::OnCbnSelchangeProgressStatusCombo)
    ON_WM_HSCROLL()

END_MESSAGE_MAP()


// CProgressBarTab message handlers

void CProgressBarTab::OnCbnSelchangeProgressStatusCombo()
{
    // TODO: Add code to handle progress bar status change
CMainFrame* mainFrm = dynamic_cast<CMainFrame*>(AfxGetApp()->GetMainWnd());

switch (m_ProgrssStatusCombo.GetCurSel())
{
case 0 :
    mainFrm->SetProgressBarState(TBPF_NORMAL);
    break;
case 1 :
    mainFrm->SetProgressBarState(TBPF_ERROR);
    break;
case 2 :
    mainFrm->SetProgressBarState(TBPF_PAUSED);
    break;
case 3 :
    mainFrm->SetProgressBarState(TBPF_INDETERMINATE);
    break;
case 4 :
    mainFrm->SetProgressBarState(TBPF_NOPROGRESS);
    break;
default:
    mainFrm->SetProgressBarState(TBPF_NORMAL);
}    
}

void CProgressBarTab::OnHScroll(UINT /* nSBCode */, UINT /* nPos */, CScrollBar* pScrollBar )
{
    if (pScrollBar == NULL) // pScrollBar will be NULL if the user clicked a window's scroll bar
        return;

    // TODO: Add code to handle slider bar change

    UpdateData();
    CMainFrame* mainFrm = dynamic_cast<CMainFrame*>(AfxGetApp()->GetMainWnd());
    mainFrm->SetProgressBarPosition(m_ProgressSliderValue);

    // Update the combo box status with meaningful status
    if (m_ProgressSliderValue > 0 && m_ProgrssStatusCombo.GetCurSel() >= 3) // No progress or intermediate
    {
        // Set to something else other than no progress
        m_ProgrssStatusCombo.SetCurSel(0); // Normal
    }
}