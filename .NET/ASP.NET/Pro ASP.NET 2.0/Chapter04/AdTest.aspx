<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdTest.aspx.cs" Inherits="AdTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    			<asp:AdRotator id="AdRotator1" runat="server" Target="_blank" AdvertisementFile="ads.xml" OnAdCreated="AdRotator1_AdCreated"></asp:AdRotator>
        <br />
        <br />
			<asp:HyperLink id="lnkBanner" runat="server">HyperLink</asp:HyperLink>
    </div>
    </form>
</body>
</html>
