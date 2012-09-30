<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionStateTest.aspx.cs" Inherits="SessionStateTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label id="lblSession" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 32px" runat="server" Width="232px" Height="61px" Font-Size="Medium" Font-Names="Verdana" Font-Bold="True"></asp:Label>
			<DIV style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; Z-INDEX: 105; LEFT: 16px; BORDER-LEFT: 2px groove; WIDTH: 576px; BORDER-BOTTOM: 2px groove; POSITION: absolute; TOP: 248px; HEIGHT: 160px; BACKGROUND-COLOR: lightyellow" ms_positioning="GridLayout">
				<asp:ListBox id="lstItems" style="Z-INDEX: 106; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server" Width="208px" Height="128px"></asp:ListBox>
				<asp:Button id="cmdMoreInfo" style="Z-INDEX: 106; LEFT: 248px; POSITION: absolute; TOP: 24px" runat="server" Width="120px" Height="24px" Text="More Information" OnClick="cmdMoreInfo_Click"></asp:Button>
				<asp:Label id="lblRecord" style="Z-INDEX: 106; LEFT: 248px; POSITION: absolute; TOP: 64px" runat="server" Width="272px" Height="61px" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True"></asp:Label></DIV>
    </div>
    </form>
</body>
</html>
