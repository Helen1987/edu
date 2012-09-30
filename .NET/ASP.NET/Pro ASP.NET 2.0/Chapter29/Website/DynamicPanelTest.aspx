<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DynamicPanelTest.aspx.cs" Inherits="DynamicPanelTest" %>

<%@ Register Assembly="JavaScriptCustomControls" Namespace="DynamicControls" TagPrefix="apress" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <apress:DynamicPanel runat="server" ID="Panel1" OnRefreshing="Panel1_Refreshing" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px" BorderColor="Red" BorderWidth="2px">
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
        </apress:DynamicPanel>
        <br />
        <apress:DynamicPanelRefreshLink runat="server" id="link1" PanelID="Panel1">Click To Refresh</apress:DynamicPanelRefreshLink>
    </div>
    </form>
</body>
</html>
