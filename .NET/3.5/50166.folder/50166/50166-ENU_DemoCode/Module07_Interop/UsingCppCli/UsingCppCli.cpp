// UsingCppCli.cpp : main project file.

#include "stdafx.h"
#include "Complex.h"
#include "ChatServer.h"
#include "ChatClient.h"
#include "Box.h"
#include "XmlInitializable.h"
#include "Permutations.h"

#include <vcclr.h>

using namespace System;

//Demonstrates the use of properties on a value type.
void Properties()
{
	Complex complex(2.0, 3.0);
	Console::WriteLine("{0} + {1}i",
		complex.Real, complex.Imaginary);
	Console::WriteLine("= {0:F2}*(cos({1:F2}) + i*sin({1:F2}))",
		complex.R, complex.Theta);
}

//Demonstrates the use of events in a client-server local chat emulation.
//The client objects register for the server's event in their constructor.
void Events()
{
	ChatServer^ server = gcnew ChatServer();
	ChatClient^ joe = gcnew ChatClient("Joe", server);
	ChatClient^ kate = gcnew ChatClient("Kate", server);

	joe->SendMessage("Hey there!");
	kate->SendMessage("I'm just about to leave...");
	joe->SendMessage("See you later then.");
}

//Demonstrates managed and native pointers and handles (references).
void PointersAndHandles()
{
	//Pointer to the native heap:
	NativeBox* nativeBox = new NativeBox;
	nativeBox->Boxify();
	(*nativeBox).Boxify();

	//Pointer to the managed (GC) heap:
	ManagedBox^ managedBox = gcnew ManagedBox;
	managedBox->Boxify();
	(*managedBox).Boxify();

	//error C2440: 'initializing' :
	//cannot convert from 'cli::interior_ptr<Type>' to 'int *'
	//
	//int* pToTheBox = &managedBox->InTheBox;

	//Declare a pinning pointer, and then reach
	//for the actual address:
	pin_ptr<int> pToTheBox = &managedBox->InTheBox;
	int* p = pToTheBox;
}

generic <typename T>
void Swap(T% first, T% second)
{
	T temp = first;
	first = second;
	second = temp;
}

//Demonstrates that boxing is an inherent language feature and can be
//performed in a type-safe way, allowing direct access into the box.
void BoxingAndUnboxing()
{
	int value = 42;
	int^ boxed = value;
	System::Object^ obj = boxed;

	int copy = *boxed;	//Strongly-typed, no cast
	int% refToTheBox = *boxed;
	
	int newValue = 43;
	Swap(*boxed, newValue);
}

using namespace System::Runtime::InteropServices;

//Demonstrates manual marshaling of strings from native to managed,
//using ANSI and Unicode formats.
void MarshalingStrings()
{
	System::String^ s = "Hello World!";
	pin_ptr<const wchar_t> p =
		PtrToStringChars(s);
	
	const wchar_t* unicode = p;
	char* ansi = (char*)(void*)
		Marshal::StringToHGlobalAnsi(s);

	System::String^ s2 = gcnew System::String(ansi);
	System::String^ s3 = gcnew System::String(unicode);
}

//Demonstrates the interoperability options of complex managed and native
//types.  The XmlInitializable class is a native type which uses an XmlDocument
//and an XmlTextReader for its initialization.  The Permutations class is a 
//managed type which uses the STL next_permutation algorithm and the STL vector<T>
//container to generate string permutations.
void NativeAndManagedTypes()
{
	System::IO::File::WriteAllText("sample.xml", "<doc />");

	XmlInitializable initializable;
	initializable.Load("sample.xml");

	array<System::String^>^ strings = { "A", "B", "C" };
	Permutations^ perm = gcnew Permutations(strings);
	do
	{
		System::Array::ForEach<System::String^>(perm->Next(),
			gcnew Action<System::String^>(System::Console::Write));
		System::Console::WriteLine();
	}
	while (perm->HasNextPermutation);
}

//Demonstrates the difference between a destructor (Dispose) and a finalizer
//in C++/CLI, and shows that the destructor automatically calls GC::SuppressFinalize
//so that the finalizer is invoked only once.
void DestructorVsFinalizer()
{
	array<System::String^>^ EmptyArray = gcnew array<System::String^>(0);

	Permutations^ p1 = gcnew Permutations(EmptyArray);
	delete p1;	//Calls the "destructor"

	Permutations^ p2 = gcnew Permutations(EmptyArray);
	//No explicit delete, so finalizer will be called later

	{
		Permutations p3(EmptyArray);
		p3.HasNextPermutation;	//Direct access, no ->
	}	//"destructor" called at this line
}

int main(array<System::String ^> ^args)
{
	Properties();
	Events();
	PointersAndHandles();
	BoxingAndUnboxing();
	NativeAndManagedTypes();
	DestructorVsFinalizer();

    return 0;
}
