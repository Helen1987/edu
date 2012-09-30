<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewMasterDetails.aspx.cs" Inherits="GridViewMasterDetails" %>

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
        <asp:SqlDataSource ID="sourceRegions" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT Employees.EmployeeID, Territories.TerritoryID, Territories.TerritoryDescription FROM Employees INNER JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID INNER JOIN Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID WHERE (Employees.EmployeeID = @EmployeeID)" >
            <SelectParameters>
                <asp:ControlParameter ControlID="gridEmployees" Name="EmployeeID" PropertyName="SelectedDataKey.Values[&quot;EmployeeID&quot;]" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small">Choose an employee:</asp:Label>
        <asp:GridView ID="gridEmployees" runat="server" CellPadding="4" DataSourceID="sourceEmployees"
            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="EmployeeID" BorderStyle="Solid" BorderWidth="2px" OnSelectedIndexChanged="gridEmployees_SelectedIndexChanged">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                
               
<asp:CommandField SelectText=">" ShowSelectButton="True"  />
<asp:BoundField DataField="EmployeeID" HeaderText="ID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="Title" SortExpression="TitleOfCourtesy" />
            </Columns><PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblRegionCaption" runat="server" Font-Bold="True" Font-Names="Verdana"
            Font-Size="Small"></asp:Label>
        <br />
        <asp:GridView ID="gridRegions" runat="server" CellPadding="4" DataSourceID="sourceRegions"
            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"  BorderStyle="Solid" BorderWidth="2px">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TerritoryID" HeaderText="ID" SortExpression="TerritoryID" />
                <asp:BoundField DataField="TerritoryDescription" HeaderText="Description"
                    SortExpression="TerritoryDescription" />
            </Columns>
        </asp:GridView>
        <br />
         </div>
    </form>
</body>
</html>
