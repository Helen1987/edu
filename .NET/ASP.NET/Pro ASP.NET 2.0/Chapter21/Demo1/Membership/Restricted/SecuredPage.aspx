<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecuredPage.aspx.cs" Inherits="SecuredPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>This is a secured page</h1>
        <asp:LoginStatus ID="LoginStatus1" runat="server"
             LoginText="Sign In"
             LogoutText="Sign Out"
             LogoutPageUrl="~/Default.aspx" 
             LogoutAction="Redirect" />
        <br />
        <br />
        <asp:ChangePassword ID="ChangePassword1" runat="server">
        </asp:ChangePassword>
    </div>
    </form>
</body>
</html>
