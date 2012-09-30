<%@ Page Language="C#" AutoEventWireup="false" CodeFile="XmlDataSourceXPath.aspx.cs" Inherits="XmlDataSourceXPath" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="sourceDVD" runat="server" DataFile="~/DvdList.xml" XPath="/DvdList/DVD/Starring/Star"></asp:XmlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="sourceDVD" AutoGenerateColumns="False">
  <Columns>
    <asp:TemplateField HeaderText="DVD">
      <ItemTemplate>
        <%# XPath(".")%><br />
        
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
