<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventTracker.aspx.cs" Inherits="EventTracker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    			<h3>List of events:</h3>			
				<asp:ListBox id="lstEvents" runat="server" Height="107px" Width="355px"></asp:ListBox><br/>
				<br/><br/>
				<h3>Controls being monitored for change events:</h3>
				<asp:TextBox id="txt" runat="server" AutoPostBack="True" OnTextChanged="CtrlChanged"></asp:TextBox><br/>
				<br/>
				<asp:CheckBox id="chk" runat="server" AutoPostBack="True" OnCheckedChanged="CtrlChanged"></asp:CheckBox><br/>
				<br/>
				<asp:RadioButton id="opt1" runat="server" GroupName="Sample" AutoPostBack="True" OnCheckedChanged="CtrlChanged"></asp:RadioButton>
				<asp:RadioButton id="opt2" runat="server" GroupName="Sample" AutoPostBack="True" OnCheckedChanged="CtrlChanged"></asp:RadioButton>
    </div>
    </form>
</body>
</html>
