<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RichLabelTest.aspx.cs" Inherits="XmlLabelTest" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary" Assembly="CustomServerControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <apress:RichLabel id="RichLabel1" runat="server" Height="144px" Width="382px" BackColor="#D3AE32" Text="Label">
				<Format Type="Xml" HighlightTag="b"></Format>
			</apress:RichLabel>
    </div>
    </form>
</body>
</html>
