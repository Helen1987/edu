<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WseSecurityTest.aspx.cs" Inherits="WseSecurityTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdCallWithout" runat="server" OnClick="cmdCallWithout_Click" Text="Call Without Token" />&nbsp;
        <asp:Button ID="cmdCallWith" runat="server" OnClick="cmdCallWith_Click" Text="Call With Token" /><br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
