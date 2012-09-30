<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectDataSourceUpdate2.aspx.cs" Inherits="ObjectDataSourceUpdate2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="sourceEmployees" runat="server" 
            SelectMethod="GetEmployees" TypeName="DatabaseComponent.EmployeeDB" OnUpdating="sourceEmployees_Updating" UpdateMethod="UpdateEmployee">
              <UpdateParameters>
    <asp:Parameter Name="id" Type="Int32" />
  </UpdateParameters>

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
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Columns>
        </asp:GridView>
        &nbsp; &nbsp;
        &nbsp;&nbsp;<br />
       
    
    </div>
    </form>
</body>
</html>
