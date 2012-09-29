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


// TaskbarThumbnailsDemoView.cpp : implementation of the CTaskbarThumbnailsDemoView class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "TaskbarThumbnailsDemo.h"
#endif

#include "TaskbarThumbnailsDemoDoc.h"
#include "TaskbarThumbnailsDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTaskbarThumbnailsDemoView

IMPLEMENT_DYNCREATE(CTaskbarThumbnailsDemoView, CScrollView)

BEGIN_MESSAGE_MAP(CTaskbarThumbnailsDemoView, CScrollView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CScrollView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CScrollView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CTaskbarThumbnailsDemoView::OnFilePrintPreview)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// CTaskbarThumbnailsDemoView construction/destruction

CTaskbarThumbnailsDemoView::CTaskbarThumbnailsDemoView()
{
	// TODO: add construction code here

}

CTaskbarThumbnailsDemoView::~CTaskbarThumbnailsDemoView()
{
}

BOOL CTaskbarThumbnailsDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CScrollView::PreCreateWindow(cs);
}

// CTaskbarThumbnailsDemoView drawing

void CTaskbarThumbnailsDemoView::OnDraw(CDC* pDC)
{
	CTaskbarThumbnailsDemoDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	// TODO: add draw code for native data here
	if (!pDoc || pDoc->GetImage().IsNull())
		return;

	pDoc->GetImage().Draw(pDC->GetSafeHdc(), 0, 0);
}

void CTaskbarThumbnailsDemoView::OnInitialUpdate()
{
	CScrollView::OnInitialUpdate();

	CSize sizeTotal;
	
    // TODO: calculate the total size of this view
	SetScrollSizes( MM_TEXT, GetDocument( )->GetDocSize( ) );
}


// CTaskbarThumbnailsDemoView printing


void CTaskbarThumbnailsDemoView::OnFilePrintPreview()
{
#ifndef SHARED_HANDLERS
	AFXPrintPreview(this);
#endif
}

BOOL CTaskbarThumbnailsDemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CTaskbarThumbnailsDemoView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CTaskbarThumbnailsDemoView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CTaskbarThumbnailsDemoView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CTaskbarThumbnailsDemoView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// CTaskbarThumbnailsDemoView diagnostics

#ifdef _DEBUG
void CTaskbarThumbnailsDemoView::AssertValid() const
{
	CScrollView::AssertValid();
}

void CTaskbarThumbnailsDemoView::Dump(CDumpContext& dc) const
{
	CScrollView::Dump(dc);
}

CTaskbarThumbnailsDemoDoc* CTaskbarThumbnailsDemoView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTaskbarThumbnailsDemoDoc)));
	return (CTaskbarThumbnailsDemoDoc*)m_pDocument;
}
#endif //_DEBUG


// CTaskbarThumbnailsDemoView message handlers
