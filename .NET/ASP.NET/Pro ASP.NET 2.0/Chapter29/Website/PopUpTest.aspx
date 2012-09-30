<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUpTest.aspx.cs" Inherits="PopUpTest" %>

<%@ Register Assembly="JavaScriptCustomControls" Namespace="CustomServerControlsLibrary"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:popup id="PopUp1" runat="server"
        Url="PopUpAd.aspx" Scrollbars="True"
				Resizable="True"></cc1:popup>
    
    </div>
    </form>
</body>
</html>
