<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewTemplate.aspx.cs" Inherits="GridViewTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy FROM Employees"
            UpdateCommand="UPDATE Employees SET Notes=@Notes, TitleOfCourtesy=@TitleOfCourtesy WHERE EmployeeID=@EmployeeID" OldValuesParameterFormatString="{0}">
        </asp:SqlDataSource>
        <asp:GridView ID="gridEmployees" runat="server" CellPadding="4" DataSourceID="sourceEmployees"
            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="498px" BorderStyle="Groove" DataKeyNames="EmployeeID" OnRowUpdating="gridEmployees_RowUpdating">
            
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
             <asp:TemplateField HeaderText="Employees">
                  <ItemTemplate>
                  <b>
                    <%# Eval("EmployeeID") %> - 
                    <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %>
                    <%# Eval("LastName") %>
                  </b>
                  <hr />
                  <small><i>
                    <%# Eval("Address") %><br />
                    <%# Eval("City") %>, <%# Eval("Country") %>,
                    <%# Eval("PostalCode") %><br />
                    <%# Eval("HomePhone") %></i>
                    <br /><br />
                    <%# Eval("Notes") %>
                    <br /><br />
                    <asp:LinkButton runat="server" Text="Edit" 
   CommandName="Edit" ID="Linkbutton1" />

                  </small>
                    
                  </ItemTemplate>
                  <EditItemTemplate>
                  <b>
                    <%# Eval("EmployeeID") %> - 
                    <asp:DropDownList runat="server" ID="EditTitle"
   SelectedIndex=
'<%# GetSelectedTitle(Eval("TitleOfCourtesy")) %>'
Font-Names="Verdana" Font-Size="XX-Small"
   DataSource='<%# TitlesOfCourtesy %>' />

                    <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %>
                    <%# Eval("LastName") %>
                  </b>
                  <hr />
                  <small><i>
                    <%# Eval("Address") %><br />
                    <%# Eval("City") %>, <%# Eval("Country") %>,
                    <%# Eval("PostalCode") %><br />
                    <%# Eval("HomePhone") %></i>
                    <br /><br />
                    <asp:TextBox Text='<%# Bind("Notes") %>' runat="server" id="textBox" Font-Names="Verdana" Font-Size="XX-Small" Height="40px" TextMode="MultiLine" Width="413px" />
                    <br /><br />
                                        <asp:LinkButton runat="server" Text="Update" 
   CommandName="Update" ID="Linkbutton1" /> 
  <asp:LinkButton runat="server" Text="Cancel" 
   CommandName="Cancel" ID="Linkbutton2" />
                  </small>


                  </EditItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
         </div>
    </form>
</body>
</html>
