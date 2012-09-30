<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageButtonTest.aspx.cs" Inherits="ImageButtonTest" %>
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
        <apress:CustomImageButton ID="CustomImageButton1" runat="server" OnImageClicked="CustomImageButton1_ImageClicked" />
    </div>
    </form>
</body>
</html>
