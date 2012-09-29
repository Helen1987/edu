// dllmain.h : Declaration of module class.

class CSimpleCOMCalculatorModule : public CAtlDllModuleT< CSimpleCOMCalculatorModule >
{
public :
	DECLARE_LIBID(LIBID_SimpleCOMCalculatorLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_SIMPLECOMCALCULATOR, "{D0857D8A-1DDC-419D-A250-6658739C55C4}")
};

extern class CSimpleCOMCalculatorModule _AtlModule;
