<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RolloverTest.aspx.cs" Inherits="RolloverTest" %>

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
       <cc1:RollOverButton id="RollOverButton1" style="Z-INDEX: 100; LEFT: 22px; POSITION: absolute; TOP: 22px"
				runat="server" Width="134px" Height="36px" MouseOverImageUrl="buttonMouseOver.jpg" ImageUrl="buttonOriginal.jpg" OnImageClicked="RollOverButton1_ImageClicked"></cc1:RollOverButton>
        <br />
        <br />
			<cc1:RollOverButton id="RollOverButton2" style="Z-INDEX: 101; LEFT: 21px; POSITION: absolute; TOP: 63px"
				runat="server" Width="134px" Height="36px" MouseOverImageUrl="buttonMouseOver.jpg" ImageUrl="buttonOriginal.jpg" OnImageClicked="RollOverButton1_ImageClicked"></cc1:RollOverButton>&nbsp;
    </div>
    </form>
</body>
</html>
