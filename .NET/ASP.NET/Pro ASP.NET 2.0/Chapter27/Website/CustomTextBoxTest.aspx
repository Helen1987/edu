<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomTextBoxTest.aspx.cs" Inherits="CustomTextBoxTest" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary"
  Assembly="CustomServerControls" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <apress:CustomTextBox ID="CustomTextBox2" runat="server" />
        <apress:customtextbox id="CustomTextBox1" runat="server" ontextchanged="CustomTextBox1_TextChanged"></apress:customtextbox>
        <asp:Button ID="Button1" runat="server" Text="Button" /></div>
    </form>
</body>
</html>
