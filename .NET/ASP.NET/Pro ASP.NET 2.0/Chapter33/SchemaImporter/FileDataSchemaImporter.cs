using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Xml.Serialization.Advanced;
using System.IO;

namespace SchemaImporter
{
	public class FileDataSchemaImporter : SchemaImporterExtension
	{
		public override string ImportSchemaType(string name, string ns, XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer, CodeCompileUnit compileUnit, CodeNamespace mainNamespace, CodeGenerationOptions options, CodeDomProvider codeProvider)
		{
			// Uncomment these lines for debugging.
			// (Messages are displayed when you run wsdl.exe
			// and this schema importer is called.)
			//Console.WriteLine("ImportSchemaType");
			//Console.WriteLine(name);
			//Console.WriteLine(ns);
			//Console.WriteLine();

			if (name.Equals("FileData") &&
				ns.Equals("http://www.apress.com/ProASP.NET/FileData"))
			{
				mainNamespace.Imports.Add(new CodeNamespaceImport("FileDataComponent"));
				return "FileData";
			}
			return null;
		}

		public override string ImportSchemaType(XmlSchemaType type, XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer, CodeCompileUnit compileUnit, CodeNamespace mainNamespace, CodeGenerationOptions options, CodeDomProvider codeProvider)
		{
			return null;
		}

		public override string ImportAnyElement(XmlSchemaAny any, bool mixed, XmlSchemas schemas, XmlSchemaImporter importer, CodeCompileUnit compileUnit, CodeNamespace mainNamespace, CodeGenerationOptions options, CodeDomProvider codeProvider)
		{
			return null;
		}

		public override CodeExpression ImportDefaultValue(string value, string type)
		{
			return null;
		}

	}
}