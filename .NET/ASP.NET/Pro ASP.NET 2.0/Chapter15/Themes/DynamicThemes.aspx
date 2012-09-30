<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicThemes.aspx.cs" Inherits="DynamicThemes_aspx" Theme="ProTheme"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="lstThemes" runat="server"></asp:ListBox><br />
        <br />
        <asp:Button ID="cmdApply" runat="server" Text="Apply Theme" OnClick="cmdApply_Click" /></div>
    </form>
</body>
</html>
