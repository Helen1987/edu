<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Username: <asp:TextBox runat="server" ID="UserNameText" /><br />
        Password: <asp:TextBox runat="server" ID="PasswordText" 
                               TextMode="Password"/><br />
        Confirm Password: <asp:TextBox runat="server" ID="PasswordConfirmText"
                                       TextMode="Password" /><br />
        <asp:CompareValidator runat="server" ID="ComparePasswords"
                              ControlToValidate="PasswordText"
                              ControlToCompare="PasswordConfirmtext" 
                              ErrorMessage="Password confirmation doesn't match" /><br />
        Email: <asp:TextBox runat="server" ID="UserEmailText" /><br />
        Password-Question: <asp:Textbox runat="server" ID="PwdQuestionText" /><br />
        Password-Answer: <asp:TextBox runat="server" ID="PwdAnswerText" /><br />
        <asp:Button runat="server" ID="ActionAddUser" Text="Create User..."
                    OnClick="ActionAddUser_Click" /><br />
        <asp:Label runat="server" ID="StatusLabel" Text="" EnableViewState="false" />
    </div>
    </form>
</body>
</html>