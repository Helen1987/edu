<%@ Register TagPrefix="cc1" Namespace="GDI_CustomControls" Assembly="GDI+CustomControls" %>
<%@ Page language="c#" Inherits="GradientTest" CodeFile="GradientTest.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GradientTest</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<cc1:gradientlabel id="GradientLabel1" runat="server" Text="Test String" GradientColorA="Honeydew"
				GradientColorB="RoyalBlue"></cc1:gradientlabel></form>
	</body>
</HTML>
