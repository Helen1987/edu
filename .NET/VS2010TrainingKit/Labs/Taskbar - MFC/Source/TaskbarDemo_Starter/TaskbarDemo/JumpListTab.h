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
#include "afxwin.h"


// CJumpListTab dialog

class CJumpListTab : public CDialog
{
	DECLARE_DYNAMIC(CJumpListTab)

public:
	CJumpListTab(CWnd* pParent = NULL);   // standard constructor
	virtual ~CJumpListTab();

// Dialog Data
	enum { IDD = IDD_DIALOG_JUMP_LIST };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();
	DECLARE_MESSAGE_MAP()

protected:
    CJumpList m_jumpList;
    int m_maxSlots;

protected:
    void UpdateRegistration(BOOL isRegister);

public:
    afx_msg void OnAddKnownCategory();
    afx_msg void OnAddDestination();
    afx_msg void OnAddTask();
    afx_msg void OnClearAll();
    afx_msg void OnCommit();
    afx_msg void OnSelectDestinationPath();
    afx_msg void OnSelectTaskPath();
    afx_msg void OnSelectTaskIconPath();
    afx_msg void OnRegisterFileType();
    afx_msg void OnUnregisterFileType();

    // List box displaying current items in the Jump List
    CListBox m_JumpList_Display_Items;

    // Known categories combo box
    CComboBox m_knownCategoryCombo;

    // destination Category value
    CString m_destinationCategory;

    // Destination Path value
    CString m_destinationPath;

    // Task Title
    CString m_taskTitle;

    // Task Path or Url
    CString m_taskPath;
    
    // Task Optional Command Arguments
    CString m_taskArgs;
    
    // Task Icon Path
    CString m_taskIconPath;
    
    // Task Icon Index
    int m_taskIconIndex;

    CEdit m_destinationPathEditBox;
    CEdit m_taskPathEditBox;
    CEdit m_taskIconPathEditBox;
};
