<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sql2005Dependency.aspx.cs" Inherits="Sql2005Dependency" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdModify" runat="server" Height="24px" OnClick="cmdModfiy_Click"
            Style="z-index: 100; left: 16px; position: absolute; top: 16px" Text="Modify Table"
            Width="103px" />
        <asp:Button ID="cmdGetItem" runat="server" Height="24px" OnClick="cmdGetItem_Click"
            Style="z-index: 103; left: 136px; position: absolute; top: 16px" Text="Check for Item"
            Width="103px" />
        <asp:Label ID="lblInfo" runat="server" BackColor="LightYellow" BorderStyle="Groove"
            BorderWidth="2px" Font-Names="Verdana" Font-Size="X-Small" Height="192px" Style="z-index: 102;
            left: 16px; position: absolute; top: 72px" Width="480px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
