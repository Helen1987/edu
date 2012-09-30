<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XmlControlTest.aspx.cs" Inherits="XmlControlTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Xml id="Xml1" runat="server" DocumentSource="Products.xml" TransformSource="Products.xslt"></asp:Xml>
    </div>
    </form>
</body>
</html>
