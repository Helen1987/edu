<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewSummaries.aspx.cs" Inherits="GridViewSummaries" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="ProductID" DataSourceID="sourceProducts" 
            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" AllowPaging="True" OnDataBound="GridView1_DataBound" OnRowCreated="GridView1_RowCreated" OnDataBinding="GridView1_DataBinding" ShowFooter="True">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:C}" HeaderText="Price"
                    SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="Units In Stock" />
            </Columns>
        </asp:GridView>
        &nbsp;<br />
    
    </div>
    </form>
</body>
</html>
