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

#include "StdAfx.h"
#include "FileRegistrationHelper.h"

CFileRegistrationHelper::CFileRegistrationHelper(LPCTSTR progId, LPCTSTR path, LPCTSTR friendlyName, LPCTSTR appUserModelID, int numExtensions, LPCTSTR * extensions)
{
    m_szProgID = progId;
    m_szAppPath = path;
    m_szFriendlyName = friendlyName;
    m_szAppUserModelID = appUserModelID;

    for (int i = 0; i < numExtensions; i++)
    {
        m_rgszExtsToRegister.push_back(extensions[i]);
    }
}

CFileRegistrationHelper::~CFileRegistrationHelper(void)
{
}

HRESULT CFileRegistrationHelper::RegSetString(HKEY hkey, PCWSTR pszSubKey, PCWSTR pszValue, PCWSTR pszData)
{
    size_t lenData = lstrlen(pszData);
    return HRESULT_FROM_WIN32(SHSetValue(hkey, pszSubKey, pszValue, REG_SZ, pszData, static_cast<DWORD>((lenData + 1) * sizeof(*pszData))));
}

HRESULT CFileRegistrationHelper::RegisterProgid(BOOL fRegister)
{
    HRESULT hr;
    if (fRegister)
    {
        HKEY hkeyProgid;
        hr = HRESULT_FROM_WIN32(RegCreateKeyEx(HKEY_CLASSES_ROOT, m_szProgID.c_str(), 0, NULL, REG_OPTION_NON_VOLATILE,
            KEY_SET_VALUE | KEY_CREATE_SUB_KEY , NULL, &hkeyProgid, NULL));
        if (SUCCEEDED(hr))
        {
            hr = RegSetString(hkeyProgid, NULL, L"FriendlyTypeName", m_szFriendlyName.c_str());
            hr = RegSetString(hkeyProgid, NULL, L"AppUserModelID", m_szAppUserModelID.c_str());
            if (SUCCEEDED(hr))
            {
                WCHAR szIcon[MAX_PATH + 3];
                hr = StringCchPrintf(szIcon, ARRAYSIZE(szIcon), L"%s,0", m_szAppPath.c_str());
                if (SUCCEEDED(hr))
                {
                    hr = RegSetString(hkeyProgid, L"DefaultIcon", NULL, m_szAppPath.c_str());
                    if (SUCCEEDED(hr))
                    {
                        hr = RegSetString(hkeyProgid, L"CurVer", NULL, m_szProgID.c_str());
                        if (SUCCEEDED(hr))
                        {
                            HKEY hkeyShell;
                            hr = HRESULT_FROM_WIN32(RegCreateKeyEx(hkeyProgid, L"shell", 0, NULL, REG_OPTION_NON_VOLATILE,
                                KEY_SET_VALUE | KEY_CREATE_SUB_KEY, NULL, &hkeyShell, NULL));
                            if (SUCCEEDED(hr))
                            {
                                // The list of verbs provided by the ProgID is located uner the "shell" key.  Here, only
                                // the single "Open" verb is registered.
                                WCHAR szCmdLine[MAX_PATH * 2];
                                hr = StringCchPrintf(szCmdLine, ARRAYSIZE(szCmdLine), L"%s %%1", m_szAppPath.c_str());
                                if (SUCCEEDED(hr))
                                {
                                    hr = RegSetString(hkeyShell, L"Open\\Command", NULL, szCmdLine);
                                    if (SUCCEEDED(hr))
                                    {
                                        // Set "Open" as the default verb for this ProgID.
                                        hr = RegSetString(hkeyShell, NULL, NULL, L"Open");
                                    }
                                }
                                RegCloseKey(hkeyShell);
                            }
                        }
                    }
                }
            }
            RegCloseKey(hkeyProgid);
        }
    }
    else
    {
        long lRes = RegDeleteTree(HKEY_CLASSES_ROOT, m_szProgID.c_str());
        hr = (ERROR_SUCCESS == lRes || ERROR_FILE_NOT_FOUND == lRes) ? S_OK : HRESULT_FROM_WIN32(lRes);
    }
    return hr;
}

HRESULT CFileRegistrationHelper::RegisterToHandleExt(PCWSTR pszExt, BOOL fRegister)
{
    WCHAR szKey[MAX_PATH];
    HRESULT hr = StringCchCopy(szKey, ARRAYSIZE(szKey), pszExt);
    if (SUCCEEDED(hr))
    {
        // All ProgIDs that can handle a given file type should be listed under OpenWithProgids, even if listed
        // as the default, so they can be enumerated in the Open With dialog, and so the Jump Lists can find
        // the correct ProgID to use when relaunching a document with the specific application the Jump List is
        // associated with.
        hr = PathAppend(szKey, L"OpenWithProgids") ? S_OK : E_FAIL;
        if (SUCCEEDED(hr))
        {
            HKEY hkeyProgidList;
            hr = HRESULT_FROM_WIN32(RegCreateKeyEx(HKEY_CLASSES_ROOT, szKey, 0, NULL, REG_OPTION_NON_VOLATILE,
                KEY_SET_VALUE, NULL, &hkeyProgidList, NULL));
            if (SUCCEEDED(hr))
            {
                if (fRegister)
                {
                    hr = HRESULT_FROM_WIN32(RegSetValueEx(hkeyProgidList, m_szProgID.c_str(), 0, REG_NONE, NULL, 0));
                }
                else
                {
                    hr = HRESULT_FROM_WIN32(RegDeleteKeyValue(hkeyProgidList, NULL, m_szProgID.c_str()));
                }
                RegCloseKey(hkeyProgidList);
            }
        }
    }
    return hr;
}

HRESULT CFileRegistrationHelper::RegisterToHandleFileTypes()
{
    HRESULT hr = RegisterProgid(TRUE);
    if (SUCCEEDED(hr))
    {
        for (UINT i = 0; SUCCEEDED(hr) && i < m_rgszExtsToRegister.size(); i++)
        {
            hr = RegisterToHandleExt(m_rgszExtsToRegister[i].c_str(), TRUE);
        }

        if (SUCCEEDED(hr))
        {
            // Notify that file associations have changed
            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, NULL, NULL);
        }
    }
    return hr;
}

bool CFileRegistrationHelper::AreFileTypesRegistered()
{
    bool fRet = false;
    HKEY hkeyProgid;
    if (SUCCEEDED(HRESULT_FROM_WIN32(RegOpenKey(HKEY_CLASSES_ROOT, m_szProgID.c_str(), &hkeyProgid))))
    {
        fRet = true;
        RegCloseKey(hkeyProgid);
    }
    return fRet;
}

HRESULT CFileRegistrationHelper::UnRegisterFileTypeHandlers()
{
    HRESULT hr = RegisterProgid(FALSE);
    if (SUCCEEDED(hr))
    {
        for (UINT i = 0; SUCCEEDED(hr) && i < m_rgszExtsToRegister.size(); i++)
        {
            hr = RegisterToHandleExt(m_rgszExtsToRegister[i].c_str(), FALSE);
        }

        if (SUCCEEDED(hr))
        {
            // Notify that file associations have changed
            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, NULL, NULL);
        }
    }
    return hr;
}