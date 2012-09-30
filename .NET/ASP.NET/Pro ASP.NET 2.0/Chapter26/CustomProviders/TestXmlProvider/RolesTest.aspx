<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RolesTest.aspx.cs" Inherits="RolesTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Rolename: <asp:TextBox ID="RoleNameText" runat="server" /><br />
        Username: <asp:TextBox ID="UserNameText" runat="server" /><br />
        <asp:Button runat="server" ID="DeleteRole" Text="Delete" OnClick="DeleteRole_Click" />
        <asp:Button runat="server" ID="FindUsersInRole" Text="Find Users In Role" OnClick="FindUsersInRole_Click" />
        <asp:Button runat="server" ID="GetAll" Text="Get All Roles" OnClick="GetAll_Click" />
        <asp:Button runat="server" ID="GetRolesForUser" Text="Get Roles For User" OnClick="GetRolesForUser_Click" />
        <asp:Button runat="server" ID="GetUsersInRole" Text="Get Users In Role" OnClick="GetUsersInRole_Click" />
        <asp:Button runat="server" ID="IsUserInRole" Text="Is User In Role" OnClick="IsUserInRole_Click" />
        <asp:Button runat="server" ID="AddUserToRole" Text="Add User To Role" OnClick="AddUserToRole_Click" />
        <asp:Button runat="server" ID="RemoveUserFromRole" Text="Remove User From Role" OnClick="RemoveUserFromRole_Click" />
        <hr />
        <asp:Label runat="server" ID="ResultsLabel" />
    </div>
    </form>
</body>
</html>
