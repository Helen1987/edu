<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginView.aspx.cs" Inherits="LoginView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginView runat="server" ID="MainView">
            <LoggedInTemplate>
                <h2>This is the logged in template</h2>
            </LoggedInTemplate>
            <RoleGroups>
                <asp:RoleGroup Roles="Admin">
                    <ContentTemplate>
                        <h2>Only Admins will see this</h2>
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="Contributor">
                    <ContentTemplate>
                        <h2>This is for contributors!</h2>
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="Reader, Designer">
                    <ContentTemplate>
                        <h2>This is for web designers and readers</h2>
                    </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
        </asp:LoginView>
    </div>
    </form>
</body>
</html>
