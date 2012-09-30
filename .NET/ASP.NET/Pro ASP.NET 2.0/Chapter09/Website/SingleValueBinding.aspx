<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SingleValueBinding.aspx.cs" Inherits="SingleValueBinding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Image runat="server" ImageUrl='<%# FilePath %>' ID="Image1"/><br>
			<asp:Label runat="server" Text='<%# FilePath %>' ID="Label1"/><br>
			<asp:TextBox runat="server" Text='<%# GetFilePath() %>' ID="Textbox1"/><br>
			<asp:HyperLink runat="server" NavigateUrl='<%# LogoPath.Value %>' 
        Font-Bold="True" Text="Show logo" ID="Hyperlink1"/><br>
			<input type="hidden" runat="server" ID="LogoPath" value="apress.gif" NAME="LogoPath">
			<b>
				<%# FilePath %>
			</b>
			<br>
			<img src="<%# GetFilePath() %>">
    </div>
    </form>
</body>
</html>
