<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Customers.ascx.cs" Inherits="Customers" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID"
    DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowPaging="True" AllowSorting="True" PageSize="5">
    <Columns>
        <asp:BoundField DataField="CustomerID" HeaderText="ID" ReadOnly="True" SortExpression="CustomerID" />
        <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
        <asp:BoundField DataField="ContactFirstname" HeaderText="Firstname" SortExpression="ContactFirstname" />
        <asp:BoundField DataField="ContactLastname" HeaderText="Lastname" SortExpression="ContactLastname" />
        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" SortExpression="PhoneNumber" />
        <asp:BoundField DataField="EmailAddress" HeaderText="Email" SortExpression="EmailAddress" />
        <asp:BoundField DataField="Address" Visible="False" HeaderText="Address" SortExpression="Address" />
        <asp:BoundField DataField="ZipCode" Visible="False" HeaderText="ZipCode" SortExpression="ZipCode" />
        <asp:BoundField DataField="City" Visible="False" HeaderText="City" SortExpression="City" />
        <asp:BoundField DataField="Country" Visible="False" HeaderText="Country" SortExpression="Country" />
        <asp:BoundField DataField="WebSite" Visible="False" HeaderText="WebSite" SortExpression="WebSite" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CustomerDatabase %>"
    DeleteCommand="DELETE FROM [Customer] WHERE [CustomerID] = @original_CustomerID"
    InsertCommand="INSERT INTO [Customer] ([CustomerID], [CompanyName], [ContactFirstname], [ContactLastname], [PhoneNumber], [EmailAddress], [Address], [ZipCode], [City], [Country], [WebSite]) VALUES (@CustomerID, @CompanyName, @ContactFirstname, @ContactLastname, @PhoneNumber, @EmailAddress, @Address, @ZipCode, @City, @Country, @WebSite)"
    ProviderName="<%$ ConnectionStrings:CustomerDatabase.ProviderName %>"
    SelectCommand="SELECT [CustomerID], [CompanyName], [ContactFirstname], [ContactLastname], [PhoneNumber], [EmailAddress], [Address], [ZipCode], [City], [Country], [WebSite] FROM [Customer]"
    UpdateCommand="UPDATE [Customer] SET [CompanyName] = @CompanyName, [ContactFirstname] = @ContactFirstname, [ContactLastname] = @ContactLastname, [PhoneNumber] = @PhoneNumber, [EmailAddress] = @EmailAddress, [Address] = @Address, [ZipCode] = @ZipCode, [City] = @City, [Country] = @Country, [WebSite] = @WebSite WHERE [CustomerID] = @original_CustomerID">
    <InsertParameters>
        <asp:Parameter Name="CustomerID" Type="String" />
        <asp:Parameter Name="CompanyName" Type="String" />
        <asp:Parameter Name="ContactFirstname" Type="String" />
        <asp:Parameter Name="ContactLastname" Type="String" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="Address" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="Country" Type="String" />
        <asp:Parameter Name="WebSite" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="CompanyName" Type="String" />
        <asp:Parameter Name="ContactFirstname" Type="String" />
        <asp:Parameter Name="ContactLastname" Type="String" />
        <asp:Parameter Name="PhoneNumber" Type="String" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="Address" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="Country" Type="String" />
        <asp:Parameter Name="WebSite" Type="String" />
        <asp:Parameter Name="original_CustomerID" Type="String" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="original_CustomerID" Type="String" />
    </DeleteParameters>
</asp:SqlDataSource>
