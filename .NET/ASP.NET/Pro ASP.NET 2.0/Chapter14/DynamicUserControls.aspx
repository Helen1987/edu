<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicUserControls.aspx.cs" Inherits="DynamicUserControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   	<div style="BORDER-RIGHT: 1px ridge; PADDING-RIGHT: 10px; BORDER-TOP: 1px ridge; PADDING-LEFT: 10px; FONT-SIZE: x-small; PADDING-BOTTOM: 10px; MARGIN: 10px; BORDER-LEFT: 1px ridge; WIDTH: 298px; PADDING-TOP: 10px; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: Verdana; HEIGHT: 58px; BACKGROUND-COLOR: beige"
				id="div1" runat="server">
				<asp:DropDownList id="lstControls1" runat="server" Width="215px" AutoPostBack="True">
					<asp:ListItem Value="(None)">(None)</asp:ListItem>
					<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
					<asp:ListItem Value="TimeDisplay.ascx">TimeDisplay</asp:ListItem>
				</asp:DropDownList>
				<asp:PlaceHolder id="PlaceHolder1" runat="server"></asp:PlaceHolder><BR>
				<asp:Label id="PanelLabel1" runat="server" Font-Italic="True" EnableViewState="False">Panel with custom content</asp:Label>
			</div>
			<div style="BORDER-RIGHT: 1px ridge; PADDING-RIGHT: 10px; BORDER-TOP: 1px ridge; PADDING-LEFT: 10px; FONT-SIZE: x-small; PADDING-BOTTOM: 10px; MARGIN: 10px; BORDER-LEFT: 1px ridge; WIDTH: 298px; PADDING-TOP: 10px; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: Verdana; HEIGHT: 58px; BACKGROUND-COLOR: beige"
				id="div2" runat="server">
				<asp:DropDownList id="DropDownList2" runat="server" AutoPostBack="True" Width="215px">
						<asp:ListItem Value="(None)">(None)</asp:ListItem>
					<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
					<asp:ListItem Value="TimeDisplay.ascx">TimeDisplay</asp:ListItem>
				</asp:DropDownList>
				<asp:PlaceHolder id="PlaceHolder2" runat="server"></asp:PlaceHolder><BR>
				<asp:Label id="Label3" runat="server" EnableViewState="False" Font-Italic="True">Panel with custom content</asp:Label></div>
			<div style="BORDER-RIGHT: 1px ridge; PADDING-RIGHT: 10px; BORDER-TOP: 1px ridge; PADDING-LEFT: 10px; FONT-SIZE: x-small; PADDING-BOTTOM: 10px; MARGIN: 10px; BORDER-LEFT: 1px ridge; WIDTH: 298px; PADDING-TOP: 10px; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: Verdana; HEIGHT: 58px; BACKGROUND-COLOR: beige"
				id="div3" runat="server">
				<asp:DropDownList id="DropDownList3" runat="server" AutoPostBack="True" Width="215px">
						<asp:ListItem Value="(None)">(None)</asp:ListItem>
					<asp:ListItem Value="Header.ascx">Header</asp:ListItem>
					<asp:ListItem Value="TimeDisplay.ascx">TimeDisplay</asp:ListItem>
				</asp:DropDownList>
				<asp:PlaceHolder id="PlaceHolder3" runat="server"></asp:PlaceHolder><BR>
				<asp:Label id="Label4" runat="server" EnableViewState="False" Font-Italic="True">Panel with custom content</asp:Label></div>
    </form>
</body>
</html>
