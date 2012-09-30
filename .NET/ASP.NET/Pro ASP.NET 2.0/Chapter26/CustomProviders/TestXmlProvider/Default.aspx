<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to the provider test application</h1>
        <asp:LoginView runat="server" ID="MainLoginView">
            <AnonymousTemplate>
                <asp:Login ID="MainLogin" runat="server" />
            </AnonymousTemplate>
            <LoggedInTemplate>
                <asp:LoginStatus ID="MainStatus" runat="server" />
                <asp:Button ID="PostbackCommand" text="Postback" 
                            runat="server"
                            OnClick="PostbackCommand_OnClick" />
            </LoggedInTemplate>
        </asp:LoginView>
        <asp:Label ID="ResultsLabel" runat="server" />
    </div>
    </form>
</body>
</html>
