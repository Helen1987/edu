<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Anonymous access allowed</h1>
        <a href="Restricted/SecuredPage.aspx">Secured Page</a><br />
        <asp:LoginStatus ID="LoginStatus1" runat="server"
             LoginText="Sign In"
             LogoutText="Sign Out"
             LogoutPageUrl="~/Default.aspx" 
             LogoutAction="Redirect" />
        <p>
        Here you see different contents based on your login-state
        <asp:LoginView ID="LoginViewCtrl" runat="server" OnViewChanged="LoginViewCtrl_ViewChanged">
            <AnonymousTemplate>
                <h2>You are anonymous</h2>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <h2>You are logged in</h2>
                Submit your comment: <asp:TextBox runat="server" ID="CommentText" /><br />
                <asp:Button runat="server" ID="SubmitCommentAction" Text="Submit" />
            </LoggedInTemplate>
            <RoleGroups>
            </RoleGroups>
        </asp:LoginView>
        </p>
    </div>
    </form>
</body>
</html>
