<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RandomNumber.aspx.cs" Inherits="RandomNumber" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="RandomNumberCommand" runat="server" 
                Text="Generate Number" OnClick="RandomNumberCommand_Click" />
    <asp:Label ID="ResultLabel" runat="server" />
    </div>
    </form>
</body>
</html>
