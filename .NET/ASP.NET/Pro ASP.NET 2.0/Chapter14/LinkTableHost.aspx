<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkTableHost.aspx.cs" Inherits="LinkTableHost" %>

<%@ Register Src="LinkTable.ascx" TagName="LinkTable" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:LinkTable ID="LinkTable1" runat="server" OnLinkClicked="LinkClicked"/>
        <br />
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
