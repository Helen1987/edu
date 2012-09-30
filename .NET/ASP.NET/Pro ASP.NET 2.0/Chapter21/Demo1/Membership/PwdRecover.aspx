<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PwdRecover.aspx.cs" Inherits="PwdRecover" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Forgotten Password?</h1>
        <p>
            <asp:PasswordRecovery ID="PasswordRecoveryCtrl" runat="server"
                                  BackColor="Azure" 
                                  BorderColor="Black" BorderStyle="solid" OnSendingMail="PasswordRecoveryCtrl_SendingMail" OnVerifyingAnswer="PasswordRecoveryCtrl_VerifyingAnswer" OnVerifyingUser="PasswordRecoveryCtrl_VerifyingUser"> 
                <MailDefinition From="proaspnet2@apress.com"
                                Subject="Forgotten Password"
                                Priority="High" />
                <TitleTextStyle Font-Bold="True" Font-Italic="True" BorderStyle="Dotted" />
                <TextBoxStyle BackColor="Yellow" BorderStyle="Double" />
                <FailureTextStyle Font-Bold="True" />
            </asp:PasswordRecovery>
        </p>
    </div>
    </form>
</body>
</html>
