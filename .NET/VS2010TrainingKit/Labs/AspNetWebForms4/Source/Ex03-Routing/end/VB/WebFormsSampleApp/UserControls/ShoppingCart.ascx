<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="ShoppingCart.ascx.vb" Inherits="WebFormsSampleApp.UserControls.ShoppingCartControl" %>
<div id="shopCart">
	<div class="shopCartOptions">
		<a href="#">Your Account</a> | <a href="#">Help</a>
	</div>
	<!------------------------ Collapsed View ------------------------>
	<asp:Panel ID="ShopCartCollapsed" ClientIDMode="Static" runat="server">
		<p class="summary">
			<span>Items:</span>
			<asp:Label ID="CollapsedItemsCountLabel" runat="server"></asp:Label>
			<span>- Subtotal:</span>
			<asp:Label ID="CollapsedTotalLabel" runat="server"></asp:Label>
			<a href="#" class="checkoutLink"><span>Checkout</span></a>
		</p>
	</asp:Panel>
	<!------------------------ Expanded View ------------------------>
	<asp:Panel ID="ShopCartExpanded" ClientIDMode="Static" runat="server">
		<asp:Panel ID="ShopCartExpandedEmpty" runat="server">
			<p class="empty">
				Your shopping cart is empty.</p>
		</asp:Panel>
		<asp:Panel ID="ShopCartExpandedNonEmpty" ClientIDMode="Inherit" runat="server">
			<p class="items">
				<span>Your cart items:</span>
			</p>
			<ul class="items">
				<asp:ListView ID="ShoppingCartItemsLists" runat="server" ClientIDMode="Static" ClientIDRowSuffix="ProductId">
					<ItemTemplate>
						<asp:Panel ID="ShoppingCartItem" ClientIDMode="Static" runat="server">
							<div class="productColumn">
                                <asp:Label ID="Quantity" ClientIDMode="Predictable" runat="server">
                                    <%#Eval("ProductName")%>&nbsp;(<%#Eval("Quantity")%>)
                                </asp:Label>
							</div>
							<div class="priceColumn">
								<asp:Label ID="TotalPrice" ClientIDMode="Predictable" runat="server">
                                    <%#String.Format(System.Globalization.CultureInfo.CurrentUICulture, "{0:c}", Eval("TotalPrice"))%>
                                </asp:Label>
							</div>
						</asp:Panel>
					</ItemTemplate>
				</asp:ListView>
			</ul>
			<p class="summary">
				<span>Items:</span>
				<asp:Label ID="ExpandedItemsCountLabel" runat="server"></asp:Label>
				<span>- Subtotal:</span>
				<asp:Label ID="ExpandedTotalLabel" runat="server"></asp:Label>
				<a href="#" class="checkoutLink"><span>Checkout</span></a>
			</p>
		</asp:Panel>
	</asp:Panel>
</div>