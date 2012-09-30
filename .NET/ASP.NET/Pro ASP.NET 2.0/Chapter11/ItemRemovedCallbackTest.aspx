<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemRemovedCallbackTest.aspx.cs" Inherits="ItemRemovedCallbackTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:button id="cmdCheck" style="Z-INDEX: 104; LEFT: 18px; POSITION: absolute; TOP: 16px" runat="server"
				Width="103px" Height="24px" Text="Check Items" OnClick="cmdCheck_Click"></asp:button>
			<asp:button id="cmdRemove" style="Z-INDEX: 103; LEFT: 136px; POSITION: absolute; TOP: 16px"
				runat="server" Width="135px" Height="24px" Text="Remove One Item" OnClick="cmdRemove_Click"></asp:button>
			<asp:label id="lblInfo" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 72px" runat="server"
				Width="480px" Height="192px" Font-Names="Verdana" Font-Size="X-Small" BorderWidth="2px"
				BorderStyle="Groove" BackColor="LightYellow"></asp:label>

    </form>
</body>
</html>
