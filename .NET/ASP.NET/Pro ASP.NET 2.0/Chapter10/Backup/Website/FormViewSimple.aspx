<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormViewSimple.aspx.cs" Inherits="FormViewSimple" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Employees"></asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="sourceEmployees">
      
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

                  </small>
                    
                  </ItemTemplate>
                  
                
        </asp:FormView>
        &nbsp;
        &nbsp;&nbsp;
         </div>
    </form>
</body>
</html>
