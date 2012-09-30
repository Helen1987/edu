<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TrimViewState.aspx.cs" Inherits="TrimViewState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="lstBig" runat="server" EnableViewState="False">
        </asp:DropDownList><br />
        <br />
        <asp:Button ID="cmdSubmit" runat="server" OnClick="cmdSubmit_Click" Text="Button" /><br />
        <br />
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>
