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

using namespace std;

class CFileRegistrationHelper
{
private:
    HRESULT RegisterProgid(BOOL fRegister);
    HRESULT RegisterToHandleExt(PCWSTR pszExt, BOOL fRegister);
    HRESULT RegSetString(HKEY hkey, PCWSTR pszSubKey, PCWSTR pszValue, PCWSTR pszData);

private:
    wstring m_szProgID;
    wstring m_szAppPath;
    wstring m_szFriendlyName;
    wstring m_szAppUserModelID;
    vector<wstring> m_rgszExtsToRegister;

public:
    CFileRegistrationHelper(LPCTSTR progId, LPCTSTR path, LPCTSTR friendlyName, LPCTSTR appUserModelID, int numExtensions, LPCTSTR * extensions);
    ~CFileRegistrationHelper(void);

    HRESULT RegisterToHandleFileTypes();
    bool AreFileTypesRegistered();
    HRESULT UnRegisterFileTypeHandlers();
};

