<SCRIPT LANGUAGE="VBScript" RUNAT="Server">
Option Explicit



Dim URL
URL = "http://localhost/WebServices1/EmployeesService.asmx/GetEmployeesCount"
Dim objHTTP
Set objHTTP = CreateObject("Microsoft.XMLHTTP")

' send a GET command to the URL
objHTTP.Open "POST", URL, False
objHTTP.Send

' read and display the value of the root node
Dim numEmp
numEmp = objHTTP.responseXML.documentElement.Text
Response.Write(numEmp & " employee(s) in London")





</SCRIPT>
