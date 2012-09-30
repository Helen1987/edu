<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NavigationDataList.aspx.cs" Inherits="NavigationDataList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" StartFromCurrentNode="True" />
        <asp:GridView ID="listNavLinks" runat="server" DataSourceID="SiteMapDataSource1"
        AutoGenerateColumns="false" ShowHeader="False" BackColor="Linen" CellPadding="5">
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
                <a href='<%# Eval("Url") %>' 
                target='<%# Eval("[target]") %>'><%# Eval("Title") %></a>
                <br />
                <p style="margin: 0px; font-size: x-small;"><%# Eval("Description") %></p>
                </ItemTemplate>
               </asp:TemplateField>
           </Columns>
        </asp:GridView>
        <br />
        <asp:LinkButton ID="cmdUp" runat="server" OnClick="cmdUp_Click">Go Up</asp:LinkButton>
        </div>
    </form>
</body>
</html>
