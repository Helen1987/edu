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


// TaskbarDemoView.h : interface of the CTaskbarDemoView class
//


#pragma once

#include "MainTabCtrl.h"

class CTaskbarDemoView : public CFormView
{
protected: // create from serialization only
	CTaskbarDemoView();
	DECLARE_DYNCREATE(CTaskbarDemoView)

public:
	enum{ IDD = IDD_TASKBARDEMO_FORM };

// Attributes
public:
	CTaskbarDemoDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual void OnInitialUpdate(); // called first time after construct

// Implementation
public:
	virtual ~CTaskbarDemoView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	afx_msg void OnFilePrintPreview();
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);
	DECLARE_MESSAGE_MAP()
public:
    // Main Tab Control
    CMainTabCtrl m_mainTabCtrl;
};

#ifndef _DEBUG  // debug version in TaskbarDemoView.cpp
inline CTaskbarDemoDoc* CTaskbarDemoView::GetDocument() const
   { return reinterpret_cast<CTaskbarDemoDoc*>(m_pDocument); }
#endif

