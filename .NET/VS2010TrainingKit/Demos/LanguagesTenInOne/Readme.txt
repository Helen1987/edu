System Requirements:
- .NET Framework 4
- Microsoft Excel 2010
- Microsoft Word 2010
- IronPython 2.6.2 for .NET 4.0 (http://ironpython.codeplex.com)

IronPython:
1. Download the MSI installer of IronPython 2.6.2 for .NET 4.0 from http://ironpython.codeplex.com and install it.
2. Update the references to the following IronPython assemblies in the Two.IronPythonInterop project (all located in the 'IronPython 2.6 for .NET 4.0' installation folder):
   - IronPython.dll
   - IronPython.Modules.dll
   - Microsoft.Scripting.dll
3. Copy the IronPython 'Lib' folder located at '%PROGRAMFILES(x86)%\IronPython 2.6 for .NET 4.0' into the 'bin\Debug' or 'bin\Release' folder of the Two.IronPythonInterop project.
	e.g. Copy the 'Lib' folder located at '%PROGRAMFILES(x86)%\IronPython 2.6 for .NET 4.0' to '%TKinstallationFolder\Demos\LanguagesTenInOne\Source\Two.IronPythonInterop\bin\Debug'.