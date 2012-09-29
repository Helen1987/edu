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

// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

// RibbonAppView.cpp : implementation of the CRibbonAppView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "RibbonApp.h"
#endif

#include "RibbonAppDoc.h"
#include "RibbonAppView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CRibbonAppView

IMPLEMENT_DYNCREATE(CRibbonAppView, CScrollView)

BEGIN_MESSAGE_MAP(CRibbonAppView, CScrollView)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// CRibbonAppView construction/destruction

CRibbonAppView::CRibbonAppView()
{
	// TODO: add construction code here

}

CRibbonAppView::~CRibbonAppView()
{
}

BOOL CRibbonAppView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CScrollView::PreCreateWindow(cs);
}

// CRibbonAppView drawing

void CRibbonAppView::OnDraw(CDC* pDC)
{
	CRibbonAppDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// Draw a rectangle
	CRect client;
	CBrush brush;
	GetWindowRect(&client);
	if (pDoc->EnableDraw() && brush.CreateSolidBrush(pDoc->GetColor()))
	{
		int width=client.Width()/2; // to make it smaller
		int height= client.Height()/2;
		double factor=pDoc->GetSliderFactor(); 
		if (factor)
		{
			width=width*factor;
			height=height*factor;
		}
		CRect rect=CRect(0,0, width, height);
		pDC->FillRect(rect, &brush);
	}
		
	// Display a picture
	if(!pDoc->GetImage().IsNull())
	{
		pDoc->GetImage().Draw(pDC->GetSafeHdc(),0,0);
	}
}

void CRibbonAppView::OnInitialUpdate()
{
	CScrollView::OnInitialUpdate();
    SetScrollSizes(MM_TEXT, GetDocument()->GetDocSize());
}

void CRibbonAppView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CRibbonAppView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CRibbonAppView diagnostics

#ifdef _DEBUG
void CRibbonAppView::AssertValid() const
{
	CScrollView::AssertValid();
}

void CRibbonAppView::Dump(CDumpContext& dc) const
{
	CScrollView::Dump(dc);
}

CRibbonAppDoc* CRibbonAppView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CRibbonAppDoc)));
	return (CRibbonAppDoc*)m_pDocument;
}
#endif //_DEBUG


// CRibbonAppView message handlers
