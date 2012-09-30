<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryStringSender.aspx.cs" Inherits="QueryStringSender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button id="cmdLarge" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 80px" runat="server" Text="Large Text Version" Width="144px" OnClick="cmd_Click"></asp:Button>
			<asp:Button id="cmdNormal" style="Z-INDEX: 103; LEFT: 24px; TOP: 184px" runat="server" Text="Normal Version" Width="144px" OnClick="cmd_Click"></asp:Button>
			<asp:Button id="cmdSmall" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 48px" runat="server" Text="Small Text Version" Width="144px" OnClick="cmd_Click"></asp:Button>
    </div>
    </form>
</body>
</html>
