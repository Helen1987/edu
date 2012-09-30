<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectDataSourceSimple.aspx.cs" Inherits="ObjectDataSourceSimple" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="sourceEmployees" runat="server" SelectMethod="GetEmployees"
            TypeName="DatabaseComponent.EmployeeDB"></asp:ObjectDataSource>
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="sourceEmployees" DataTextField="EmployeeID"
            Width="131px"></asp:ListBox><br />
        &nbsp;<asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="sourceEmployees"
            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
         </div>
    </form>
</body>
</html>
