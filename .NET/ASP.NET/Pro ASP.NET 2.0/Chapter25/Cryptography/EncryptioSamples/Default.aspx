<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:LoginView runat="server" ID="MainLoginView">
        <AnonymousTemplate>
            <asp:Login ID="MainLogin" runat="server" />
        </AnonymousTemplate>
        <LoggedInTemplate>
            Credit Card: <asp:TextBox ID="CreditCardText" runat="server" /><br />
            Street: <asp:TextBox ID="StreetText" runat="server" /><br />
            Zip Code: <asp:TextBox ID="ZipCodeText" runat="server" /><br />
            City: <asp:TextBox ID="CityText" runat="server" /><br />
            <asp:Button runat="server" ID="LoadCommand" Text="Load" OnClick="LoadCommand_Click" />&nbsp;
            <asp:Button runat="server" ID="SaveCommand" Text="Save" OnClick="SaveCommand_Click" />
        </LoggedInTemplate>
    </asp:LoginView>
    </div>
    </form>
</body>
</html>
