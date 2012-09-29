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

// RegistrationHelper.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "FileRegistrationHelper.h"

void Usage()
{
    _tprintf(_T("Usage: RegistrationHelper <Register:TRUE|FALSE> <FullPath> <ProgId> <AppUserModelId> <FriendlyDocumentName> <ext1,ext2,et3,...>\r\n"));
}

int _tmain(int argc, _TCHAR* argv[])
{
    if (argc < 5)
    {
        Usage();
        return -1;
    }


    HRESULT hr = S_OK;

    CFileRegistrationHelper regHelper(argv[2], argv[3], argv[4], argv[5], argc - 6, (LPCTSTR*) &argv[6]);
    
    BOOL bCmdReg = _tcsnicmp(_T("TRUE"), argv[1], sizeof(_T("TRUE"))) == 0;
    BOOL bFilesRegistered = regHelper.AreFileTypesRegistered();

    if (bCmdReg && !bFilesRegistered )
    {
        hr = regHelper.RegisterToHandleFileTypes();
    }
    else if (!bCmdReg && bFilesRegistered)
    {
        hr = regHelper.UnRegisterFileTypeHandlers();
    }

    return SUCCEEDED(hr) ? 0 : -1;
}

