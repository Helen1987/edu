#pragma once

#include <vcclr.h>
#include <string>
#include <msclr\marshal.h>
#include <msclr\marshal_cppstd.h>

using namespace System;
using namespace System::Xml;
using namespace msclr::interop;

//A native class which uses the XmlDocument and XmlTextReader
//classes from the .NET framework.  To hold a reference to a managed
//type which resides on the GC heap, the gcroot<> template is used.
class XmlInitializable
{
private:
	gcroot<XmlDocument^> _document;
public:
	void Load(const std::string& fileName)
	{
		marshal_context context;
		XmlTextReader^ reader = gcnew XmlTextReader(
			context.marshal_as<String^>(fileName));
		_document = gcnew XmlDocument();
		_document->Load(reader);
	}
};