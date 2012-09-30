<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewFormattingEvents.aspx.cs" Inherits="GridViewFormattingEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy, City FROM Employees" ></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceEmployees" Font-Names="Verdana" Font-Size="Small" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="EmployeeID" EnableSortingAndPagingCallbacks="True" PageSize="5" HorizontalAlign="Justify" OnRowCreated="GridView1_RowCreated">
            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" BackColor="Bisque" HorizontalAlign="Left" />
            
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" >
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="Title Of Courtesy" SortExpression="TitleOfCourtesy" >
                    <ItemStyle Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
