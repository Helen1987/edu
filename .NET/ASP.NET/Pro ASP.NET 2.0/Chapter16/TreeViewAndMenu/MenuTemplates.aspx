<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuTemplates.aspx.cs" Inherits="MenuTemplates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" >
  <StaticItemTemplate>
    <%# Eval("Text") %><br />
    <small><%# GetDescriptionFromTitle(((MenuItem)Container.DataItem).Text) %></small>
  </StaticItemTemplate>
  <DynamicItemTemplate>
    <%# Eval("Text") %><br />
    <small><%# GetDescriptionFromTitle(((MenuItem)Container.DataItem).Text) %></small>
  </DynamicItemTemplate>

        </asp:Menu>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    
    </div>
    </form>
</body>
</html>
