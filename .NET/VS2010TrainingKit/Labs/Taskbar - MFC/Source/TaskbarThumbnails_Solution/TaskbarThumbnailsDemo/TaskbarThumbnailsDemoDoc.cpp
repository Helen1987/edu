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


// TaskbarThumbnailsDemoDoc.cpp : implementation of the CTaskbarThumbnailsDemoDoc class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "TaskbarThumbnailsDemo.h"
#endif

#include "TaskbarThumbnailsDemoDoc.h"

#include <propkey.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CTaskbarThumbnailsDemoDoc

IMPLEMENT_DYNCREATE(CTaskbarThumbnailsDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(CTaskbarThumbnailsDemoDoc, CDocument)
END_MESSAGE_MAP()


// CTaskbarThumbnailsDemoDoc construction/destruction

CTaskbarThumbnailsDemoDoc::CTaskbarThumbnailsDemoDoc()
{
	// TODO: add one-time construction code here

}

CTaskbarThumbnailsDemoDoc::~CTaskbarThumbnailsDemoDoc()
{
}

BOOL CTaskbarThumbnailsDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}

CSize CTaskbarThumbnailsDemoDoc::GetDocSize()
{
	CSize size(0, 0);
	if (!m_Image.IsNull())
	{
		size.cx = m_Image.GetWidth();
		size.cy = m_Image.GetHeight();
	}

	return size;
}

// CTaskbarThumbnailsDemoDoc serialization

void CTaskbarThumbnailsDemoDoc::OpenDocument(CArchive& ar)
{
    SetPathName(ar.GetFile()->GetFilePath());
	CString fNameStr = GetPathName();
	m_Image.Load(fNameStr.GetBuffer());
}

void CTaskbarThumbnailsDemoDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
        OpenDocument(ar);
	}
}

#ifdef SHARED_HANDLERS

// Support for thumbnails
void CTaskbarThumbnailsDemoDoc::OnDrawThumbnail(CDC& dc, LPRECT lprcBounds)
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
void CTaskbarThumbnailsDemoDoc::InitializeSearchContent()
{
	CString strSearchContent;
	// Set search contents from document's data. 
	// The content parts should be separated by ";"

	// For example:  strSearchContent = _T("point;rectangle;circle;ole object;");
	SetSearchContent(strSearchContent);
}

void CTaskbarThumbnailsDemoDoc::SetSearchContent(const CString& value)
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

// CTaskbarThumbnailsDemoDoc diagnostics

#ifdef _DEBUG
void CTaskbarThumbnailsDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTaskbarThumbnailsDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

CImage& CTaskbarThumbnailsDemoDoc::GetImage()
{
    return m_Image;
}

// CTaskbarThumbnailsDemoDoc commands
