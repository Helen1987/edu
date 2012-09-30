<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLoggerSerialization.aspx.cs" Inherits="UserLoggerSerialization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label id="lblInfo" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 51px" runat="server"
				Height="237px" Width="418px" BorderStyle="Dotted" EnableViewState="False" BorderWidth="1px"
				BackColor="Linen"></asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 20px; POSITION: absolute; TOP: 18px" runat="server"
				Height="22px" Width="90px" Text="Post Back"></asp:Button>
			<asp:Button id="cmdDelete" style="Z-INDEX: 103; LEFT: 215px; POSITION: absolute; TOP: 17px"
				runat="server" Height="22px" Width="90px" Text="Delete Log" OnClick="cmdDelete_Click"></asp:Button>
			<asp:Button id="cmdRead" style="Z-INDEX: 102; LEFT: 117px; POSITION: absolute; TOP: 17px" runat="server"
				Height="22px" Width="90px" Text="Read Log" OnClick="cmdRead_Click"></asp:Button>
    </div>
    </form>
</body>
</html>
