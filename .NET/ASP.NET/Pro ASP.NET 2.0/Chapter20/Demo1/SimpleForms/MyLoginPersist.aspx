<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLoginPersist.aspx.cs" Inherits="LoginPersist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<form id="form1" runat="server">
    <div style="text-align: center">
    Please Login to the System<br />
    <asp:Panel ID="MainPanel" runat="server" Height="90px" Width="380px"
        BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
        <br />
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="30%" style="height: 43px">
                    Username:</td>
                <td width="70%" style="height: 43px">
                    <asp:TextBox ID="UsernameText" 
                                    runat="server" Width="80%" />
                    <asp:RequiredFieldValidator 
                        ID="UsernameRequiredValidator" runat="server" 
                        ErrorMessage="*" ControlToValidate="UsernameText" />
                    <br />
                    <asp:RegularExpressionValidator 
                        ID="UsernameValidator" runat="server"
                        ControlToValidate="UsernameText"
                        ErrorMessage="Invalid username"
                        ValidationExpression="[\w| ]*" />
                </td>
            </tr>
            <tr>
                <td width="30%" style="height: 26px">
                    Password:</td>
                <td width="70%" style="height: 26px">
                    <asp:TextBox ID="PasswordText" runat="server" 
                                    Width="80%" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="PwdRequiredValidator"
                        runat="server" ErrorMessage="*" 
                        ControlToValidate="PasswordText" />
                    <br />
                    <asp:RegularExpressionValidator ID="PwdValidator" 
                        runat="server" ControlToValidate="PasswordText"
                        ErrorMessage="Invalid password" 
                        ValidationExpression='[\w| !"§$%&amp;/()=\-?\*]*' />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="LoginAction" runat="server"
                    OnClick="LoginAction_Click" Text="Login" /><br />
        <asp:Label ID="LegendStatus" runat="server"
                   EnableViewState="false" Text="" />
    </asp:Panel>
    </div>
</form>
</body>
</html>
