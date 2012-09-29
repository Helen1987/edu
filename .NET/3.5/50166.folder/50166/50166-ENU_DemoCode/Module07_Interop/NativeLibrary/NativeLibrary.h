#ifdef NATIVELIBRARY_EXPORTS
#define NATIVELIBRARY_API __declspec(dllexport)
#else
#define NATIVELIBRARY_API __declspec(dllimport)
#endif

#include <windows.h>

extern "C" __declspec(dllexport) int IsPrime(int number)
{
	for (int i = 2; i < (number / 2); ++i)
		if (number % i == 0) return 0;
	return 1;
}

extern "C" __declspec(dllexport) void wputs(wchar_t* s) {}

extern "C" __declspec(dllexport) BOOL IsValid(LPCWSTR lpszText)
{
	return lpszText != NULL;
}

typedef struct _ITEM
{
	int dwData;
} ITEM;

extern "C" __declspec(dllexport) void Find(CONST ITEM* items, DWORD count, ITEM* lookup, DWORD* index)
{
	*index = -1;
	for (DWORD i = 0; i < count; ++i)
	{
		if (items[i].dwData == lookup->dwData)
		{
			*index = i;
			break;
		}
	}
}

extern "C" __declspec(dllexport) void FillString(char* s, char fill)
{
	while (*s != '\0') *(s++) = fill;
}

char* strings[] = {
	"Hello", "Goodbye", "Good morning", "Great"
};

typedef BOOL (__stdcall *PFNMATCH)(char* text);

extern "C" __declspec(dllexport) DWORD FindMatch(PFNMATCH pfnMatch)
{
	for (int i = 0; i < sizeof(strings)/sizeof(strings[0]); ++i)
		if (pfnMatch(strings[i]))
			return i;

	return (DWORD)-1;
}

PFNMATCH matcher;

extern "C" __declspec(dllexport) void StoreMatch(PFNMATCH pfnMatch)
{
	matcher = pfnMatch;
}

extern "C" __declspec(dllexport) void UseMatch()
{
	matcher("Hi");
}