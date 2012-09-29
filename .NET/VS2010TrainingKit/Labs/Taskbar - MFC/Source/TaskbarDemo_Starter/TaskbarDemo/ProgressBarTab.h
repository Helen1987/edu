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

#pragma once


// CProgressBarTab dialog

class CProgressBarTab : public CDialog
{
	DECLARE_DYNAMIC(CProgressBarTab)

public:
	CProgressBarTab(CWnd* pParent = NULL);   // standard constructor
	virtual ~CProgressBarTab();

// Dialog Data
	enum { IDD = IDD_DIALOG_PROGRESS_BAR };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();

	DECLARE_MESSAGE_MAP()
public:

    afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar );
    afx_msg void OnCbnSelchangeProgressStatusCombo();
    CComboBox m_ProgrssStatusCombo;
    CSliderCtrl m_ProgressSlider;
    int m_ProgressSliderValue;

};
