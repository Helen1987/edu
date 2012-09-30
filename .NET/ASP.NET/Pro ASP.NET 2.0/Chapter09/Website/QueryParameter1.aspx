<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryParameter1.aspx.cs" Inherits="QueryParameter1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployeeCities" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT DISTINCT City FROM Employees">
        </asp:SqlDataSource>
        <asp:ListBox ID="lstCities" runat="server" DataSourceID="sourceEmployeeCities"
            DataTextField="City" 
            Width="161px"></asp:ListBox><br />
        <asp:Button ID="cmdGo" runat="server" OnClick="cmdGo_Click" Text="Go" /><br />
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
