<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TitledTextBoxTest.aspx.cs" Inherits="TitledTextBoxTest" %>
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
        <apress:TitledTextBox Title="Sample Title" ID="TitledTextBox1" runat="server" BackColor="#FFFF80" Font-Size="X-Large" Height="85px" Text="Sample Text" Width="569px" />
    </div>
    </form>
</body>
</html>
