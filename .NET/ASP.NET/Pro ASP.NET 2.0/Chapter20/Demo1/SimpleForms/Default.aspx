<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="SignOutAction" runat="server" OnClick="SignOutAction_Click" Text="Sign Out" /><br />
        <br />
        <asp:Label ID="LegendInfo" runat="server" Text="Label"></asp:Label>&nbsp;</div>
    </form>
</body>
</html>
