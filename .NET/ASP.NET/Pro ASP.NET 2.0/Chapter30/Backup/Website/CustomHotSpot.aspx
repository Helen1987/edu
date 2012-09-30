<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomHotSpot.aspx.cs" Inherits="CustomHotSpot" %>
<%@ Register TagPrefix="chs" Namespace="CustomHotSpots" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/triangle.gif">
          <chs:TriangleHotSpot AlternateText="Triangle" X="140" Y="50" 
                             Height="75" Width="85" />
        </asp:ImageMap>&nbsp;</div>
    </form>
</body>
</html>
