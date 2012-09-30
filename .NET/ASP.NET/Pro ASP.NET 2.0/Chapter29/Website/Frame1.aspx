<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frame1.aspx.cs" Inherits="Frame1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <P>
				<a href="http://www.apress.com" target="content">Apress</a><BR>
				<br>
				<img src="buttonOriginal.jpg" onClick="parent.content.location='http://www.apress.com'">
			</P>
			<P>
				<asp:Button id="Button1" runat="server" Text="Click Here for Google" Width="144px" OnClick="Button1_Click"></asp:Button></P>
    </div>
    </form>
</body>
</html>
