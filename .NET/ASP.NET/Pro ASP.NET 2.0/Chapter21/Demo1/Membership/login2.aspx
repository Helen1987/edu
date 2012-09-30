<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login2.aspx.cs" Inherits="login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Login ID="LoginCtrl" runat="server" 
                   BackColor="aliceblue" 
                   BorderColor="Black" 
                   BorderStyle="double" OnLoginError="LoginCtrl_LoginError"
                   PasswordRecoveryUrl="~/pwdrecover.aspx" OnAuthenticate="LoginCtrl_Authenticate">
            <LayoutTemplate>
                <h4>Log-In to the System</h4>
                <table>
                    <tr>
                    <td>
                    Username:
                    </td>
                    <td>
                    <asp:TextBox ID="UserName" runat="server" />
                    <asp:RequiredFieldValidator ID="UserNameRequired" 
                                    runat="server"
                                    ControlToValidate="UserName"
                                    ErrorMessage="*" />
                    <asp:RegularExpressionValidator ID="UsernameValidator"
                                    runat="server"
                                    ControlToValidate="UserName"
                                    ValidationExpression="[\w| ]*"
                                    ErrorMessage="Invalid Username" />
                    </td>
                    </tr>
                    <tr>
                    <td>
                    Password:
                    </td>
                    <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="PasswordRequired" 
                                    runat="server"
                                    ControlToValidate="Password" 
                                    ErrorMessage="*" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server"
                                    ControlToValidate="Password"
                                    ValidationExpression='[\w| !"§$%&amp;/()=\-?\*]*'
                                    ErrorMessage="Invalid Password" />
                    </td>
                    </tr>
                </table>
                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" /><br />
                <asp:Literal ID="FailureText" runat="server" /><br />
                <asp:Button ID="Login" CommandName="Login" runat="server" Text="Login"  />
            </LayoutTemplate>
        </asp:Login>  
        <br />
        
        <asp:Login ID="OtherLoginCtrl" runat="server"
                   BackColor="aliceblue" 
                   BorderColor="Black" 
                   BorderStyle="double"
                   PasswordRecoveryUrl="~/pwdrecover.aspx" OnAuthenticate="OtherLoginCtrl_Authenticate">
        
            <LayoutTemplate>
                <font face="Courier New">
                Access Key:&nbsp;<asp:Textbox ID="AccessKey" runat="server" /><br />
                Username:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="UserName" runat="server" /><br />
                Password:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Password" runat="server" TextMode="password" Width="149px" /><br />
                <asp:Button runat="server" ID="Login" CommandName="Login" Text="Login" />
                </font>
            </LayoutTemplate>
                   
        </asp:Login>   
    </div>
    </form>
</body>
</html>
