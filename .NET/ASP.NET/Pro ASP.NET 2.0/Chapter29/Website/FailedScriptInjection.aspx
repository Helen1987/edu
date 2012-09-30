<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FailedScriptInjection.aspx.cs" Inherits="FailedScriptInjection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <P>
				<asp:TextBox id="txtInput" runat="server" Width="298px">&lt;script&gt;alert('Script Injection');&lt;/script&gt;</asp:TextBox>
				<asp:Button id="cmdSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click"></asp:Button></P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label></P>
    </div>
    </form>
</body>
</html>
