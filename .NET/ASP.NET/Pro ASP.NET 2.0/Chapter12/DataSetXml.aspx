<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataSetXml.aspx.cs" Inherits="DataSetXml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <H2>Data from SQL Server</H2>
			<asp:DataGrid id="Datagrid1" runat="server" HeaderStyle-Font-Bold="true"></asp:DataGrid><BR>
			<BR>
			<H2>Data from the XML file</H2>
			<asp:DataGrid id="Datagrid2" runat="server" HeaderStyle-Font-Bold="true"></asp:DataGrid>
    </div>
    </form>
</body>
</html>
