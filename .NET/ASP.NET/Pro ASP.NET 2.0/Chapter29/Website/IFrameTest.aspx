<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IFrameTest.aspx.cs" Inherits="IFrameTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <IFRAME id="Iframe2" style="Z-INDEX: 101; LEFT: 14px; WIDTH: 99.13%; POSITION: absolute; TOP: 182px; HEIGHT: 156px"
				align="right" marginWidth="0" marginHeight="0" src="IncrementalDownloadGrid.aspx" frameBorder="1"
				width="40%" height="80" runat="server"></IFRAME><iframe src="page.aspx" width="40%" height="80" align="right" id="IFRAME1" style="WIDTH: 99.13%; HEIGHT: 156px"
				runat="server" frameBorder="yes" scrolling="no"></iframe>&nbsp;
    </div>
    </form>
</body>
</html>
