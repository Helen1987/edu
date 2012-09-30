<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageTest.aspx.cs" Inherits="ImageTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ImageButton id="ImageButton1" style="Z-INDEX: 101; LEFT: 18px; POSITION: absolute; TOP: 21px"
				runat="server" ImageUrl="button.png" OnClick="ImageButton1_Click"></asp:ImageButton>
			<asp:Label id="lblResult" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 163px"
				runat="server" Height="60px" Width="393px"></asp:Label>
    </div>
    </form>
</body>
</html>
