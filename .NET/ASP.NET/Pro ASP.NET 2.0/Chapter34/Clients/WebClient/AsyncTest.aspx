<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsyncTest.aspx.cs" Inherits="AsyncTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView id="GridView1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
				BackColor="White" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small">
				
				<RowStyle ForeColor="#330099" BackColor="White"></RowStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								
			</asp:GridView>
			<P>
				<asp:Button id="cmdSynchronous" runat="server" Text="Synchronous Tasks" OnClick="cmdSynchronous_Click" Width="159px"></asp:Button>&nbsp;
				<asp:Button id="cmdAsynchronous" runat="server" Text="Asynchronous Tasks" OnClick="cmdAsynchronous_Click" Width="166px"></asp:Button>&nbsp;
				<asp:Button id="Button1" runat="server" Text="Multiple Calls (Wait For All)" Width="186px" OnClick="cmdMultiple_Click"></asp:Button></P>
        <p>
				<asp:Label id="lblInfo" runat="server" Font-Size="X-Small" Font-Names="Verdana"></asp:Label>&nbsp;</p>
			<P>
				&nbsp;</P>
    </div>
    </form>
</body>
</html>
