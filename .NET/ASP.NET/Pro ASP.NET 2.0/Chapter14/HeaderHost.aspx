<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeaderHost.aspx.cs" Inherits="HeaderHost" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Header id="Header1" runat="server">
        </uc1:Header></div>
        <br />
        [ Page Content ]
    </form>
</body>
</html>
