<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoapSecurityTest.aspx.cs" Inherits="SoapSecurityTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        User name: &nbsp;
			<asp:TextBox id="txtUserName" 
				runat="server"></asp:TextBox><br />
        Password: &nbsp;
			<asp:TextBox id="txtPassword" 
				runat="server" Width="149px" TextMode="Password"></asp:TextBox><br />
        <br />
			<asp:Button id="cmdCall" runat="server"
				Width="102px" Text="Get Data" OnClick="cmdCall_Click"></asp:Button>
        &nbsp;<asp:Button ID="cmdCreate" runat="server" OnClick="cmdCreate_Click" Style="" Text="Create This User" Width="131px" /><br />
        <br />
        <asp:Label ID="lblInfo" runat="server" EnableViewState="False"></asp:Label>
        <br />
			<asp:GridView id="GridView1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
				BackColor="White" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" style="" EnableViewState="False">
				<RowStyle ForeColor="#330099" BackColor="White"></RowStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				
				
			</asp:GridView>
    </div>
    </form>
</body>
</html>
