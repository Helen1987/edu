<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="MyStyles.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Login ID="Login1" runat="server" 
                   BackColor="aliceblue" BorderColor="Black" BorderStyle="double" CreateUserText="Register" CreateUserUrl="Register.aspx" HelpPageText="Additional Help" HelpPageUrl="HelpMe.htm" InstructionText="Please enter your username and password for <br>logging into the system.">
            <LoginButtonStyle BackColor="DarkBlue" ForeColor="White" />
            <TextBoxStyle CssClass="MyLoginTextBoxStyle" />
            <TitleTextStyle Font-Italic="True" Font-Bold="True" Font-Names="Verdana" />
        </asp:Login>
    </div>
    </form>
</body>
</html>
