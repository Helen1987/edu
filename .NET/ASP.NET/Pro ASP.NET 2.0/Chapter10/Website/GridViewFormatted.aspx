<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewFormatted.aspx.cs" Inherits="GridViewFormatted" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT EmployeeID, FirstName, LastName, BirthDate, Title, City, Country, Notes FROM Employees">
        </asp:SqlDataSource>
        &nbsp;<asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="sourceEmployees"
            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="EmployeeID">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" InsertVisible="False"
                    ReadOnly="True" >
                    <ItemStyle Font-Bold="True" BorderWidth="1"  />
                    </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="City" HeaderText="City">
                  <ItemStyle BackColor="LightSteelBlue" />
                </asp:BoundField>
                <asp:BoundField DataField="Country" HeaderText="Country">
                  <ItemStyle BackColor="LightSteelBlue" />
                </asp:BoundField>
                <asp:BoundField DataField="BirthDate" HeaderText="Bith Date"
                        DataFormatString="{0:MM/dd/yyyy}" />

                <asp:BoundField DataField="Notes" HeaderText="Notes">
                  <ItemStyle Wrap="True" Width="400"/>
                </asp:BoundField>
                
            </Columns>
        </asp:GridView>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
