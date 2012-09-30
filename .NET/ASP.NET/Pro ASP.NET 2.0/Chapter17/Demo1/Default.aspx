<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Default_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LegendFirstname" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextFirstname" runat="server"></asp:TextBox><br />
        <asp:Label ID="LegendLastname" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextLastname" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LegendAge" runat="server" Text="Label"></asp:Label>
        &nbsp;<asp:TextBox ID="TextAge" runat="server"></asp:TextBox><br />
        <asp:Button ID="GenerateAction" runat="server" Text="Generate Document" OnClick="GenerateAction_Click" /><br />
        <asp:Xml ID="DocumentXml" runat="server"></asp:Xml>
    </div>
    </form>
</body>
</html>
