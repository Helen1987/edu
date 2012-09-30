<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterDetailsSinglePage.aspx.cs" Inherits="MasterDetailsSinglePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView id="gridMaster" runat="server" GridLines="None" BorderWidth="1px" BorderColor="Tan"
				Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
				ForeColor="Black" DataKeyNames="CategoryID" Font-Size="X-Small" DataSourceID="sourceCategories" OnRowDataBound="gridMaster_RowDataBound">
				
				<AlternatingRowStyle BackColor="PaleGoldenrod"></AlternatingRowStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" BackColor="Tan"></HeaderStyle>
				<FooterStyle BackColor="Tan"></FooterStyle>
				<Columns>
				
					<asp:TemplateField HeaderText="Category">
					
						<ItemStyle  VerticalAlign="Top" Width="20%"></ItemStyle>
						<ItemTemplate>
							<br>
							<b>
								<%# Eval("CategoryName") %>
							</b>
							<br>
							<br>
							<%# Eval("Description" ) %>
							<br>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Products">
						<ItemStyle VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:GridView id="DataGrid2" runat="server" Font-Size="XX-Small" BackColor="White" AutoGenerateColumns="False"
								CellPadding="4" BorderColor="#CC9966" BorderWidth="1px" Width="100%" BorderStyle="None">
						
						<RowStyle ForeColor="#330099" BackColor="White"></RowStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
																
								<Columns>
									<asp:BoundField DataField="ProductName" HeaderText="Product Name">
									<ItemStyle Width="250px" />
									</asp:BoundField>
									<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
								</Columns>		
								
							</asp:GridView>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
			</asp:GridView>    &nbsp;
        <asp:SqlDataSource ID="sourceCategories" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Categories"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sourceProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM Products WHERE CategoryID=@CategoryID">
            <SelectParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
