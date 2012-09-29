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

// RibbonAppDoc.cpp : implementation of the CRibbonAppDoc class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "RibbonApp.h"
#endif

#include "RibbonAppDoc.h"

#include <propkey.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CRibbonAppDoc

IMPLEMENT_DYNCREATE(CRibbonAppDoc, CDocument)

BEGIN_MESSAGE_MAP(CRibbonAppDoc, CDocument)
ON_COMMAND(ID_RECT_DRAW, &CRibbonAppDoc::OnRectDraw)
ON_COMMAND(ID_RECT_SLIDER, &CRibbonAppDoc::OnRectSlider)
ON_COMMAND(ID_FONT_COLOR, &CRibbonAppDoc::OnFontColor)
END_MESSAGE_MAP()


// CRibbonAppDoc construction/destruction

CRibbonAppDoc::CRibbonAppDoc()
{
    m_bDraw = FALSE;
}

CRibbonAppDoc::~CRibbonAppDoc()
{
}

BOOL CRibbonAppDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}

void CRibbonAppDoc::OpenDocument(CArchive& ar)
{
	SetPathName(ar.GetFile()->GetFilePath());
	CString strName=GetPathName();
	m_Image.Load(strName.GetBuffer());
}



// CRibbonAppDoc serialization

void CRibbonAppDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		OpenDocument(ar);
	}
}

#ifdef SHARED_HANDLERS

// Support for thumbnails
void CRibbonAppDoc::OnDrawThumbnail(CDC& dc, LPRECT lprcBounds)
{
	// Modify this code to draw the document's data
	dc.FillSolidRect(lprcBounds, RGB(255, 255, 255));

	CString strText = _T("TODO: implement thumbnail drawing here");
	LOGFONT lf;

	CFont* pDefaultGUIFont = CFont::FromHandle((HFONT) GetStockObject(DEFAULT_GUI_FONT));
	pDefaultGUIFont->GetLogFont(&lf);
	lf.lfHeight = 36;

	CFont fontDraw;
	fontDraw.CreateFontIndirect(&lf);

	CFont* pOldFont = dc.SelectObject(&fontDraw);
	dc.DrawText(strText, lprcBounds, DT_CENTER | DT_WORDBREAK);
	dc.SelectObject(pOldFont);
}

// Support for Search Handlers
void CRibbonAppDoc::InitializeSearchContent()
{
	CString strSearchContent;
	// Set search contents from document's data. 
	// The content parts should be separated by ";"

	// For example:  strSearchContent = _T("point;rectangle;circle;ole object;");
	SetSearchContent(strSearchContent);
}

void CRibbonAppDoc::SetSearchContent(const CString& value)
{
	if (value.IsEmpty())
	{
		RemoveChunk(PKEY_Search_Contents.fmtid, PKEY_Search_Contents.pid);
	}
	else
	{
		CMFCFilterChunkValueImpl *pChunk = NULL;
		ATLTRY(pChunk = new CMFCFilterChunkValueImpl);
		if (pChunk != NULL)
		{
			pChunk->SetTextValue(PKEY_Search_Contents, value, CHUNK_TEXT);
			SetChunkValue(pChunk);
		}
	}
}

#endif // SHARED_HANDLERS

// CRibbonAppDoc diagnostics

#ifdef _DEBUG
void CRibbonAppDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CRibbonAppDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CRibbonAppDoc commands


void CRibbonAppDoc::OnRectDraw()
{
    m_bDraw = TRUE;
    UpdateAllViews(NULL);
}


void CRibbonAppDoc::OnRectSlider()
{
	if(GetAsyncKeyState(VK_LBUTTON)==0)
    {
        UpdateAllViews(NULL);
    }
}


// Return the factor of zooming the rectangle
double CRibbonAppDoc::GetSliderFactor(void)
{
    // Get a pointer to the ribbon bar
    CMFCRibbonBar* pRibbon = ((CMDIFrameWndEx*) AfxGetMainWnd())->GetRibbonBar();
    ASSERT_VALID(pRibbon);

    CMFCRibbonSlider* pSlider = DYNAMIC_DOWNCAST(CMFCRibbonSlider, pRibbon->FindByID(ID_RECT_SLIDER));
    // Get current position
    int position =pSlider->GetPos();
    return (double)position/(double)pSlider->GetRangeMax();
}


// Return if the picture or shape can be drawn in the view or not
bool CRibbonAppDoc::EnableDraw(void)
{
	return m_bDraw;
}


COLORREF CRibbonAppDoc::GetColor(void)
{
    CMFCRibbonBar* pRibbon = ((CMDIFrameWndEx*) AfxGetMainWnd())->GetRibbonBar();
    ASSERT_VALID(pRibbon);

    CMFCRibbonColorButton* pColor = DYNAMIC_DOWNCAST(
       CMFCRibbonColorButton, pRibbon->FindByID(ID_FONT_COLOR));
    // Get the selected color
    return pColor->GetColor();
}


void CRibbonAppDoc::OnFontColor()
{
    UpdateAllViews(NULL);
}


CImage & CRibbonAppDoc::GetImage(void)
{
	return m_Image;
}


CSize CRibbonAppDoc::GetDocSize(void)
{
	CSize size(0,0);
	if(!m_Image.IsNull())
	{
		size.cx=m_Image.GetWidth();
		size.cy=m_Image.GetHeight();
	}
	return size;

}
