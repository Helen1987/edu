<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectDataSourceParameters.aspx.cs" Inherits="ObjectDataSourceParameters" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="sourceEmployeesList" runat="server" SelectMethod="GetEmployees"
            TypeName="DatabaseComponent.EmployeeDB"></asp:ObjectDataSource><asp:ObjectDataSource ID="sourceEmployee" runat="server" SelectMethod="GetEmployee"
            TypeName="DatabaseComponent.EmployeeDB" OnSelecting="sourceEmployee_Selecting">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lstEmployees" Name="employeeID" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
        <asp:ListBox ID="lstEmployees" runat="server" DataSourceID="sourceEmployeesList" DataTextField="EmployeeID"
            Width="131px" AutoPostBack="True" Height="171px"></asp:ListBox><br />
        &nbsp;
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BorderStyle="Groove"
            BorderWidth="2px" CellPadding="4" DataSourceID="sourceEmployee" Font-Names="Verdana"
            Font-Size="Small" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
            </Fields>
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
         </div>
    </form>
</body>
</html>
