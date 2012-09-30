<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MembershipTests.aspx.cs" Inherits="ManageUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Username: <asp:TextBox ID="UserNameText" runat="server" /><br />
        <asp:Button runat="server" ID="DeleteUser" Text="Delete" OnClick="DeleteUser_Click" />
        <asp:Button runat="server" ID="FindByName" Text="Find By Name" OnClick="FindByName_Click" />
        <asp:Button runat="server" ID="FindByEmail" Text="Find By Email" OnClick="FindByEmail_Click" />
        <asp:Button runat="server" ID="GetAllUsers" Text="Get All" OnClick="GetAllUsers_Click" />
        <asp:Button runat="server" ID="GetUser" Text="Get User" OnClick="GetUser_Click" />
        <asp:Button runat="server" ID="GetUserNameByEmail" Text="Get Name Of Email" OnClick="GetUserNameByEmail_Click" />
        <asp:Button runat="server" ID="UpdateUser" Text="Update" OnClick="UpdateUser_Click" />
        <hr />
        <asp:Label runat="server" ID="ResultsLabel" />
    </div>
    </form>
</body>
</html>
