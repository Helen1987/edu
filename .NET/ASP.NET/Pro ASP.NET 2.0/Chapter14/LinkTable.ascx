<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkTable.ascx.cs" Inherits="LinkTable" %>
<table height="43" cellSpacing="0" cellPadding="2" width="100%" border="1">
	<tr>
		<td width="100%" height="1">
			<p style="MARGIN: 8px"><asp:label id="lblTitle" Font-Size="Small" Font-Names="Verdana" Font-Bold="True" ForeColor="#C00000"
					runat="server">[Title Goes Here]</asp:label></p>
		</td>
	</tr>
	<tr>
		<td width="100%" height="1"><asp:datalist id="listContent" runat="server" OnItemCommand="listContent_ItemCommand">
				<ItemTemplate>
  <img height="23" src="exclaim.gif" 
   width="25" align="absMiddle" border="0">
  <asp:LinkButton id="HyperLink1" Font-Names="Verdana" Font-Size="XX-Small"
   ForeColor="#0000cd" runat="server" 
   Text='<%# DataBinder.Eval(Container.DataItem, "Text") %>' 
   CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Url") %>'>
  </asp:LinkButton>
</ItemTemplate>

			</asp:datalist></td>
	</tr>
</table>