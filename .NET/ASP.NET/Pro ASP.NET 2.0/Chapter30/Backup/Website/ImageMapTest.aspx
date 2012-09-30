<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageMapTest.aspx.cs" Inherits="ImageMapTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageMap ID="ImageMap1" runat="server" HotSpotMode="PostBack" ImageUrl="~/cds.jpg"
            OnClick="ImageMap1_Click">
            <asp:CircleHotSpot AlternateText="DVDs" PostBackValue="DVDs" Radius="83" X="272"
                Y="83" />
            <asp:CircleHotSpot AlternateText="Media" PostBackValue="Media" Radius="83" X="217"
                Y="221" />
            <asp:CircleHotSpot AlternateText="CDs" PostBackValue="CDs" Radius="83" X="92" Y="173" />
        </asp:ImageMap>
        <br />
        <br />
        <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Names="Verdana"></asp:Label>
    
    </div>
    </form>
</body>
</html>
