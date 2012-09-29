// Calculator.h : Declaration of the CCalculator

#pragma once
#include "resource.h"       // main symbols

#include "SimpleCOMCalculator_i.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CCalculator

class ATL_NO_VTABLE CCalculator :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCalculator, &CLSID_Calculator>,
	public IDispatchImpl<ICalculator, &IID_ICalculator, &LIBID_SimpleCOMCalculatorLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCalculator()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CALCULATOR)


BEGIN_COM_MAP(CCalculator)
	COM_INTERFACE_ENTRY(ICalculator)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:

	STDMETHOD(Add)(LONG first, LONG second, LONG* result);
	STDMETHOD(get_LastResult)(LONG* pVal);

private:

	LONG _lastResult;
};

OBJECT_ENTRY_AUTO(__uuidof(Calculator), CCalculator)
