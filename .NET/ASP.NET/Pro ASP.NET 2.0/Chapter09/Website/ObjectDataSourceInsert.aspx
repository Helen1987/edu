<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectDataSourceInsert.aspx.cs" Inherits="ObjectDataSourceInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="sourceEmployees" runat="server" InsertMethod="InsertEmployee"
            SelectMethod="GetEmployees" TypeName="DatabaseComponent.EmployeeDB" OnUpdating="sourceEmployees_Updating" UpdateMethod="UpdateEmployee" DataObjectTypeName="DatabaseComponent.EmployeeDetails" OnInserted="sourceEmployees_Inserted">
            <InsertParameters>
             <asp:Parameter Direction="ReturnValue" Name="EmployeeID" Type="Int32" Size="4" />
</InsertParameters>
            
            </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceEmployees" CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="5">
           
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="EmployeeID" InsertVisible="False" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
            </Columns>
        </asp:GridView>
        <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="sourceEmployees"
            Height="50px" Width="125px" AutoGenerateRows="False">
            <Fields>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:Label ID="lblConfirmation" runat="server"></asp:Label>&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;<br />
       
    
    </div>
    </form>
</body>
</html>
