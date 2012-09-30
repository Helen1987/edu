<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewDbOnDemand.aspx.cs" Inherits="TreeViewDbOnDemand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblInfo" runat="server" EnableViewState="False"></asp:Label>
        <br />
        <br />
        <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" OnTreeNodePopulate="TreeView1_TreeNodePopulate">
        </asp:TreeView>
    <asp:SqlDataSource ID="sourceCategories" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Categories"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sourceProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Products">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
