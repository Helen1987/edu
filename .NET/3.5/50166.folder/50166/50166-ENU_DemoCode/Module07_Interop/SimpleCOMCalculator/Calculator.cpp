// Calculator.cpp : Implementation of CCalculator

#include "stdafx.h"
#include "Calculator.h"


// CCalculator


STDMETHODIMP CCalculator::Add(LONG first, LONG second, LONG* result)
{
	if (first == 0 && second == 0)
		return E_INVALIDARG;	//Refuse to add two zeros

	*result = _lastResult = first + second;

	return S_OK;
}

STDMETHODIMP CCalculator::get_LastResult(LONG* pVal)
{
	*pVal = _lastResult;

	return S_OK;
}
