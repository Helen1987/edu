<%@ Page language="c#" Inherits="DataViewFilter" CodeFile="DataViewFilter.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<body>
		<form method="post" runat="server" ID="Form1">
			<b><u>Filter = "ProductName = 'Chocolade' "</u></b><br>
			<br>
			<asp:GridView runat="server" ID="Datagrid1" HeaderStyle-Font-Bold="true" />
			<br>
			<STRONG><U>Filter = "UnitsInStock = 0 AND UnitsOnOrder = 0" </U></STRONG>
			<br>
			<br>
			<asp:GridView runat="server" ID="Datagrid2" HeaderStyle-Font-Bold="true" />
			<br>
			<STRONG><U>Filter = <STRONG><U>"ProductName LIKE 'P%'"</U></STRONG></U></STRONG><br>
			<br>
			<asp:GridView runat="server" ID="Datagrid3" HeaderStyle-Font-Bold="true" />
		</form>
	</body>
</HTML>
