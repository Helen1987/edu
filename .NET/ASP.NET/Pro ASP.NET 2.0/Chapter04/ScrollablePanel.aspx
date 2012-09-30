<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScrollablePanel.aspx.cs" Inherits="ScrollablePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Scrollable Panel</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="116px" Width="278px" BorderStyle="Solid" BorderWidth="1px" ScrollBars="Auto">
            &nbsp;This scrolls.
            <br />
            <br />
            &nbsp;<asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:Button ID="Button2" runat="server" Text="Button" />
   &nbsp;<br />
            &nbsp;<asp:RadioButton ID="RadioButton1" runat="server" /><br />
            &nbsp;<br />
            &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="119px"></asp:TextBox><br />
            <br />
            &nbsp;7<br />
            &nbsp;8<br />
            &nbsp;9<br />
            &nbsp;10</asp:Panel>
    </div>
    </form>
</body>
</html>
