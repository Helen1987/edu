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


// COverlayIconTab dialog

class COverlayIconTab : public CDialog
{
	DECLARE_DYNAMIC(COverlayIconTab)

public:
	COverlayIconTab(CWnd* pParent = NULL);   // standard constructor
	virtual ~COverlayIconTab();

// Dialog Data
	enum { IDD = IDD_DIALOG_OVERLAY_ICON };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

    afx_msg void OnOverlayIconInfo();
    afx_msg void OnOverlayIconQuestion();
    afx_msg void OnOverlayIconNoVolume();
    afx_msg void OnOverlayIconNone();

	DECLARE_MESSAGE_MAP()
};
