<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutputCaching.aspx.cs" Inherits="OutputCaching" %>
<%@ OutputCache Duration="20" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:Label ID="lblDate" runat="server" Font-Bold="False" Font-Names="Verdana"
            Font-Size="XX-Large"></asp:Label><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Refresh" />
    
    </div>
    </form>
</body>
</html>
