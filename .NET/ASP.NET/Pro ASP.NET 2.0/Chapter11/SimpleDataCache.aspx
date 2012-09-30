<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleDataCache.aspx.cs" Inherits="SimpleDataCache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Post Back" />
        <br />
        <br />
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
