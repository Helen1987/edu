<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManualBinding.aspx.cs" Inherits="ManualBinding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdGetData" runat="server" Text="Get Data" OnClick="cmdGetData_Click" />
        <br />
        <br />
            <asp:GridView ID="GridView1" runat="server">
            
        </asp:GridView>
        <br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
