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


// TaskbarDemoView.cpp : implementation of the CTaskbarDemoView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "TaskbarDemo.h"
#endif

#include "TaskbarDemoDoc.h"
#include "TaskbarDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTaskbarDemoView

IMPLEMENT_DYNCREATE(CTaskbarDemoView, CFormView)

    BEGIN_MESSAGE_MAP(CTaskbarDemoView, CFormView)
    ON_WM_CONTEXTMENU()
    ON_WM_RBUTTONUP()
    END_MESSAGE_MAP()

    // CTaskbarDemoView construction/destruction

    CTaskbarDemoView::CTaskbarDemoView()
    : CFormView(CTaskbarDemoView::IDD)
{
    // TODO: add construction code here

}

CTaskbarDemoView::~CTaskbarDemoView()
{
}

void CTaskbarDemoView::DoDataExchange(CDataExchange* pDX)
{
    CFormView::DoDataExchange(pDX);
    DDX_Control(pDX, IDC_MAIN_TAB, m_mainTabCtrl);
}

BOOL CTaskbarDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
    // TODO: Modify the Window class or styles here by modifying
    //  the CREATESTRUCT cs

    return CFormView::PreCreateWindow(cs);
}

void CTaskbarDemoView::OnInitialUpdate()
{
    CFormView::OnInitialUpdate();
    GetParentFrame()->RecalcLayout();
    ResizeParentToFit();

	// TODO: Add extra initialization here
	m_mainTabCtrl.InitDialogs();

	m_mainTabCtrl.InsertItem(0, L"Overlay Icons");
	m_mainTabCtrl.InsertItem(1, L"Progress Bar");
	m_mainTabCtrl.InsertItem(2, L"Jump List");

	m_mainTabCtrl.CreateTabs();

}

void CTaskbarDemoView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
    ClientToScreen(&point);
    OnContextMenu(this, point);
}

void CTaskbarDemoView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
    theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CTaskbarDemoView diagnostics

#ifdef _DEBUG
void CTaskbarDemoView::AssertValid() const
{
    CFormView::AssertValid();
}

void CTaskbarDemoView::Dump(CDumpContext& dc) const
{
    CFormView::Dump(dc);
}

CTaskbarDemoDoc* CTaskbarDemoView::GetDocument() const // non-debug version is inline
{
    ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTaskbarDemoDoc)));
    return (CTaskbarDemoDoc*)m_pDocument;
}
#endif //_DEBUG


// CTaskbarDemoView message handlers

