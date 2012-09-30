<SCRIPT LANGUAGE="VBScript" RUNAT="Server">
Option Explicit



Dim URL
URL = "http://localhost/WebServices1/EmployeesService.asmx/GetEmployees"
Dim objHTTP
Set objHTTP = CreateObject("Microsoft.XMLHTTP")

' send a GET command to the URL
objHTTP.Open "POST", URL, False
objHTTP.Send

' Read and display the nodes.
Dim Doc
Set Doc = objHTTP.responseXML

' Dig into the XML DataSet structure.
Dim Child
For Each Child In Doc.documentElement.childNodes(1).childNodes(0).childNodes

    ' The first node is the ID.
    Response.Write(Child.childNodes(0).Text + "<br>")
    ' The second node is the first name.
    Response.Write(Child.childNodes(1).Text)
    ' The third node is the last name.
    Response.Write(Child.childNodes(2).Text + "<br><br>")

Next

</SCRIPT>
