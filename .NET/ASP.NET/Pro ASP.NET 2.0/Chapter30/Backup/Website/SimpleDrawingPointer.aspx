<%@ Page language="c#" Inherits="SimpleDrawingPointer" CodeFile="SimpleDrawingPointer.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SimpleDrawingPointer</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Image id="Image1" runat="server" ImageUrl="SimpleDrawing.aspx"></asp:Image></P>
			<P>
				<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
				<asp:Button id="Button1" runat="server" Text="Button"></asp:Button></P>
			<P>
				<asp:DropDownList id="DropDownList1" runat="server">
					<asp:ListItem Value="Sample Item">Sample Item</asp:ListItem>
				</asp:DropDownList></P>
			<P>
				<asp:Image id="Image2" runat="server" ImageUrl="SimpleDrawing.aspx"></asp:Image></P>
		</form>
	</body>
</HTML>
