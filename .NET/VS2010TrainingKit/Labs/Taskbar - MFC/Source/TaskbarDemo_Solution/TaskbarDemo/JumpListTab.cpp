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

// JumpListTab.cpp : implementation file
//

#include "stdafx.h"
#include "TaskbarDemo.h"
#include "JumpListTab.h"
#include "Mainfrm.h"

// CJumpListTab dialog

IMPLEMENT_DYNAMIC(CJumpListTab, CDialog)

CJumpListTab::CJumpListTab(CWnd* pParent /*=NULL*/)
	: CDialog(CJumpListTab::IDD, pParent)
    , m_maxSlots(0)
    , m_destinationCategory(_T(""))
    , m_destinationPath(_T(""))
    , m_taskTitle(_T(""))
    , m_taskPath(_T(""))
    , m_taskArgs(_T(""))
    , m_taskIconPath(_T(""))
    , m_taskIconIndex(0)
{

}

CJumpListTab::~CJumpListTab()
{
}

void CJumpListTab::DoDataExchange(CDataExchange* pDX)
{
    CDialog::DoDataExchange(pDX);

    DDX_Text(pDX, IDC_MAX_SLOTS, m_maxSlots);
    DDX_Control(pDX, IDC_JUMP_LIST_ITEMS, m_JumpList_Display_Items);
    DDX_Control(pDX, IDC_KNOWN_CATEGORY_COMBO, m_knownCategoryCombo);
    DDX_Text(pDX, IDC_DEST_CATEGORY, m_destinationCategory);
    DDX_Text(pDX, IDC_DEST_PATH, m_destinationPath);
    DDX_Text(pDX, IDC_TASK_TITLE, m_taskTitle);
    DDX_Text(pDX, IDC_TASK_PATH, m_taskPath);
    DDX_Text(pDX, IDC_TASK_ARGS, m_taskArgs);
    DDX_Text(pDX, IDC_TASK_ICON_PATH, m_taskIconPath);
    DDX_Text(pDX, IDC_TASK_ICON_INDEX, m_taskIconIndex);
    DDX_Control(pDX, IDC_DEST_PATH, m_destinationPathEditBox);
    DDX_Control(pDX, IDC_TASK_PATH, m_taskPathEditBox);
    DDX_Control(pDX, IDC_TASK_ICON_PATH, m_taskIconPathEditBox);
}

BOOL CJumpListTab::OnInitDialog()
{
    if (!CDialog::OnInitDialog())
        return FALSE;

    m_jumpList.InitializeList();
    m_maxSlots = m_jumpList.GetMaxSlots();

    UpdateData(false);

    return TRUE;
}

BEGIN_MESSAGE_MAP(CJumpListTab, CDialog)
    ON_BN_CLICKED(IDC_ADD_KNOWN_CATEGORY, &CJumpListTab::OnAddKnownCategory)
    ON_BN_CLICKED(IDC_ADD_DESTINATION, &CJumpListTab::OnAddDestination)
    ON_BN_CLICKED(IDC_ADD_TASK, &CJumpListTab::OnAddTask)
    ON_BN_CLICKED(IDC_CLEAR_ALL, &CJumpListTab::OnClearAll)
    ON_BN_CLICKED(IDC_COMMIT, &CJumpListTab::OnCommit)
    ON_BN_CLICKED(IDC_SELECT_CATEGORY_PATH, &CJumpListTab::OnSelectDestinationPath)
    ON_BN_CLICKED(IDC_SELECT_TASK_PATH, &CJumpListTab::OnSelectTaskPath)
    ON_BN_CLICKED(IDC_SELECT_TASK_ICON_PATH, &CJumpListTab::OnSelectTaskIconPath)
    ON_BN_CLICKED(IDC_REGISTER_FILE_TYPE, &CJumpListTab::OnRegisterFileType)
    ON_BN_CLICKED(IDC_UNREGISTER_FILE_TYPE, &CJumpListTab::OnUnregisterFileType)
END_MESSAGE_MAP()


// CJumpListTab message handlers

void CJumpListTab::OnAddKnownCategory()
{
    int curSel = m_knownCategoryCombo.GetCurSel();
    
    if (curSel < 0)
    {
        AfxMessageBox(L"Must select a known category above");
    }
    else if (curSel == 0)
    {
        if (m_jumpList.AddKnownCategory(KDC_FREQUENT))
            m_JumpList_Display_Items.AddString(L"Known Category: Frequent");
        else
            AfxMessageBox(L"Cannot Add Frequent Known Category");
    } 
    else if (curSel == 1)
    {
        if (m_jumpList.AddKnownCategory(KDC_RECENT))
            m_JumpList_Display_Items.AddString(L"Known Category: Recent");
        else
            AfxMessageBox(L"Cannot Add Recent Known Category");
    }
}

void CJumpListTab::OnAddDestination()
{
    UpdateData();

    if (m_destinationPath.IsEmpty() || m_destinationCategory.IsEmpty())
    {
        AfxMessageBox(L"Both Destination categeory and path must be added.");
        return;
    }

    if (!m_jumpList.AddDestination(m_destinationCategory, m_destinationPath))
    {
        AfxMessageBox(L"Failed to add destination.");
    }
    else
    {
        CString text = L"Destination: ";
        text.Append(m_destinationPath);
        m_JumpList_Display_Items.AddString(text);
    }
}

void CJumpListTab::OnAddTask()
{
    UpdateData();

    if (m_taskPath.IsEmpty() || m_taskTitle.IsEmpty())
    {
        AfxMessageBox(L"Both Task Path and Title must be added.");
        return;
    }

    if (!m_jumpList.AddTask(m_taskPath, m_taskArgs, m_taskTitle, m_taskIconPath, m_taskIconIndex))
    {
        AfxMessageBox(L"Failed to add Task.");
    }
    else
    {
        CString text = L"Task: ";
        text.Append(m_taskTitle);
        m_JumpList_Display_Items.AddString(text);
    }
}

void CJumpListTab::OnAddTaskSeparator()
{
    if (m_jumpList.AddTaskSeparator())
        m_JumpList_Display_Items.AddString(L"--- Task Separator ---");
    else
        AfxMessageBox(L"Cannot Add Task Separator");
}

void CJumpListTab::OnClearAll()
{
    m_jumpList.ClearAll();
    m_JumpList_Display_Items.ResetContent();
}

void CJumpListTab::OnCommit()
{
    if (m_jumpList.CommitList())
    {
        m_JumpList_Display_Items.ResetContent();
        // Start another list
        m_jumpList.InitializeList();
    }
    else
    {
        AfxMessageBox(L"Failed to commit jump list.");
    }
}

void CJumpListTab::OnSelectDestinationPath()
{
    CFileDialog openDlg(TRUE, NULL, NULL, OFN_FILEMUSTEXIST ,L"Jpeg Files|*.jpg;*.jpeg||");

    if (openDlg.DoModal())
    {
        m_destinationPathEditBox.SetWindowText(openDlg.GetPathName());
    }
}

void CJumpListTab::OnSelectTaskPath()
{
    CFileDialog openDlg(TRUE, NULL, NULL, OFN_FILEMUSTEXIST ,L"Executable Files|*.exe;*.cmd||");

    if (openDlg.DoModal())
    {
        m_taskPathEditBox.SetWindowText(openDlg.GetPathName());
    }
}

void CJumpListTab::OnSelectTaskIconPath()
{
    CFileDialog openDlg(TRUE, NULL, NULL, OFN_FILEMUSTEXIST ,L"Icon Files|*.ico;*.dll;*.exe||");

    if (openDlg.DoModal())
    {
        m_taskIconPathEditBox.SetWindowText(openDlg.GetPathName());
    }
}

void CJumpListTab::UpdateRegistration(BOOL isRegister)
{
    CString params;
    
    CString applicationPath;
    AfxGetModuleFileName(0, applicationPath);
    
    params.Format(L"%s \"%s\" \"%s\" \"%s\" %s %s", 
        isRegister ? L"TRUE" : L"FALSE",
        L"Microsoft.Samples.TaskbarDemo", // ProgId
        applicationPath, // Path
        L"TaskbarDemo Document", // friendly doc name
        L"TaskbarDemo.AppID.1.0.0.0", // Taskbar AppUserModeID
        L".jpg"); // extensions
 
    CString shortFileNameParam;    
    AfxGetModuleShortFileName(0, shortFileNameParam);

    CString exeFileName = applicationPath;
    exeFileName.Replace(L"TaskbarDemo.exe", L"RegistrationHelper.exe");

    SHELLEXECUTEINFO shex;

    memset( &shex, 0, sizeof( shex) );

    shex.cbSize         = sizeof( SHELLEXECUTEINFO );
    shex.fMask          = 0;
    shex.hwnd           = this->GetSafeHwnd();
    shex.lpVerb         = _T("runas");
    shex.lpFile         = exeFileName;
    shex.lpParameters   = params;
    shex.lpDirectory    = _T(".");
    shex.nShow          = SW_NORMAL;

    ::ShellExecuteEx( &shex );
}

void CJumpListTab::OnRegisterFileType()
{    
    UpdateRegistration(TRUE);
}

void CJumpListTab::OnUnregisterFileType()
{
    UpdateRegistration(FALSE);
}
