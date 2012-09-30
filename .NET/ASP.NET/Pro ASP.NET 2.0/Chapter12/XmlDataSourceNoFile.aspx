<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XmlDataSourceNoFile.aspx.cs" Inherits="XmlDataSourceNoFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:XmlDataSource ID="sourceDVD" runat="server"  ></asp:XmlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="sourceDVD">
            <Columns>
                <asp:TemplateField HeaderText="DVD">
                <ItemTemplate>
                <%#XPath("./@ID")%><br />
                  <b><%#XPath("./Title")%></b><br />
                  <%#XPath("./Director")%><br />
                  <%#XPath("./Price", "{0:c}")%><br />
                         </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
