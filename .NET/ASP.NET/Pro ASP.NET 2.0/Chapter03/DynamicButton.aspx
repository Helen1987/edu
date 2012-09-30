<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicButton.aspx.cs" Inherits="DynamicButton" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
				<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 32px" runat="server"
				Width="364px" Height="142px">
				<p>
					<asp:Label id=Label1 runat="server">(No value.)</asp:Label></p>
				<p>
					<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder>
					<asp:Button id="cmdReset" runat="server" Width="112px" Text="Reset Text" OnClick="cmdReset_Click"></asp:Button><br/>
				</p>
					<hr/>
				<p>
					<asp:Button id="cmdCreate" runat="server" Width="137px" Text="Create Button" OnClick="cmdCreate_Click"></asp:Button>
					<asp:Button id="cmdRemove" runat="server" Width="141px" Text="Remove Button" OnClick="cmdRemove_Click"></asp:Button>
				</p>
			</asp:Panel>
	</div>
	</form>
</body>
</html>
