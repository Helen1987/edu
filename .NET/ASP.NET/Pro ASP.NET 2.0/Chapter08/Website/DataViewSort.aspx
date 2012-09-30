<%@ Page language="c#" Inherits="DataViewSort" CodeFile="DataViewSort.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<body>
		<form method="post" runat="server" ID="Form1">
			<b><u>Original order</u></b><br>
			<br>
			<asp:GridView runat="server" ID="Datagrid1" HeaderStyle-Font-Bold="true" />
			<br>
			<b><u>Sort = "LastName"</u></b><br>
			<br>
			<asp:GridView runat="server" ID="Datagrid2" HeaderStyle-Font-Bold="true" />
			<br>
			<b><u>Sort = "FirstName"</u></b><br>
			<br>
			<asp:GridView runat="server" ID="Datagrid3" HeaderStyle-Font-Bold="true" />
		</form>
	</body>
</HTML>
