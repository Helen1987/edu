#pragma once

#include <vector>
#include <string>
#include <algorithm>
#include <msclr\marshal.h>
#include <msclr\marshal_cppstd.h>

using namespace System;
using namespace System::Collections::Generic;
using namespace std;
using namespace msclr::interop;

//A managed type which generates string permutations by using
//the STL vector<T> container and the next_permutation algorithm.
//A managed type cannot contain a complex native type directly, but
//may contain it through a pointer, as this example shows.
//
//This class also shows the use of the marshal_context class and its
//marshal_as method for seamless marshaling of data across the interop
//boundary.
ref class Permutations
{
private:
	vector<string>* _strings;
	marshal_context _context;
	bool _hasNextPermutation;
public:
	Permutations(IEnumerable<String^>^ strings)
		: _hasNextPermutation(true)
	{
		_strings = new vector<string>;
		for each (String^ s in strings)
			_strings->push_back(_context.marshal_as<string>(s));
	}

	array<String^>^ Next()
	{
		_hasNextPermutation = next_permutation(_strings->begin(), _strings->end());
		array<String^>^ list = gcnew array<String^>(_strings->size());
		for (vector<string>::const_iterator it = _strings->begin();
			 it != _strings->end(); ++it)
		{
			list[it - _strings->begin()] = _context.marshal_as<String^>(*it);
		}
		return list;
	}

	property bool HasNextPermutation
	{
		bool get() { return _hasNextPermutation; }
	}

	!Permutations()
	{
		System::Console::WriteLine("Permutations finalizer called");
		delete _strings;
	}
	~Permutations()
	{
		System::Console::WriteLine("Permutations destructor (Dispose) called");
		delete _strings;
		_strings = NULL;
	}
};
