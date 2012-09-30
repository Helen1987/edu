<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryStringSender.aspx.cs" Inherits="QueryStringSender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Enter some data here: <asp:TextBox runat="server" ID="MyData" />
    <br />
    <br />
    <asp:Button ID="SendCommand" runat="server" Text="Send Info" OnClick="SendCommand_Click" />
    </div>
    </form>
</body>
</html>
