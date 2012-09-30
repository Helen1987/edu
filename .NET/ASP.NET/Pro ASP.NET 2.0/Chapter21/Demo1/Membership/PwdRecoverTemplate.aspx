<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PwdRecoverTemplate.aspx.cs" Inherits="PwdRecoverTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:PasswordRecovery ID="PasswordTemplateCtrl" runat="server" OnSendingMail="PasswordTemplateCtrl_SendingMail">
            <MailDefinition From="pwd@apress.com" 
                            Priority="High" 
                            Subject="Important information" />
            <UserNameTemplate>
                <span style="text-align: center">
                <font face="Courier New">
                    <h2>Forgotten your Password?</h2>
                    Please enter your username:<br />
                    <asp:TextBox ID="UserName" runat="server" />
                    <br />
                    <asp:Button ID="SubmitButton" CommandName="Submit" runat="server" Text="Next" />
                    <br />
                    <span style="color: red">
                    <asp:Literal ID="FailureText" runat="server" />
                    </span>
                </font>
                </span>
            </UserNameTemplate>
            <QuestionTemplate>
                <span style="text-align: center">
                <font face="Courier New">
                    <h2>Forgotten your Password?</h2>
                    Hello <asp:Literal ID="UserName" runat="server" />! <br />
                    Please answer your password-question:<br />
                    <asp:Literal ID="Question" runat="server" /><br />
                    <asp:TextBox ID="Answer" runat="server" /><br />
                    <asp:Button ID="NextButton" CommandName="Submit" runat="Server" Text="Send Answer" /><br />
                    <asp:Literal ID="FailureText" runat="server" />
                    </span>
                </font>
                </span>
            </QuestionTemplate>
            <SuccessTemplate>
                Your password has been sent to your email address
                <asp:Label ID="EmailLabel" runat="server" />!
            </SuccessTemplate>
        </asp:PasswordRecovery>
    </div>
    </form>
</body>
</html>
