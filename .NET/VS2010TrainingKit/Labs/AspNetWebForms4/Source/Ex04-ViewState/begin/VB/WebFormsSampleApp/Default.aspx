<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/UI.master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebFormsSampleApp._Default" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
	<link type="text/css" rel="Stylesheet" media="screen" href="/Styles/products.css" />
    <script type="text/javascript" src="/Scripts/shoppingCart.Effects.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<asp:HiddenField ID="ShoppingCartState" ClientIDMode="Static" runat="server" />
	<div class="products">
		<h2>
			Products</h2>
		<div class="categories">
			<h3>
				Categories</h3>
			<ul id="categoryTabs">
				<li>
					<asp:HyperLink runat="server" NavigateUrl="<%$ RouteUrl:RouteName=Category, category=Bikes %>"
								   OnLoad="CategoryLink_Load" Text="Bikes" />

					<asp:HyperLink runat="server" NavigateUrl="<%$ RouteUrl:RouteName=Category, category=Components %>"
								   OnLoad="CategoryLink_Load" Text="Components" />

					<asp:HyperLink runat="server" NavigateUrl="<%$ RouteUrl:RouteName=Category, category=Clothing %>"
								   OnLoad="CategoryLink_Load" Text="Clothing" />

					<asp:HyperLink runat="server" NavigateUrl="<%$ RouteUrl:RouteName=Category, category=Accessories %>"
								   OnLoad="CategoryLink_Load" Text="Accessories"/>
				</li>
			</ul>
		</div>
		<hr />

		<asp:Panel ID="PageIndexOverflowPanel" runat="server" Visible="false">
			<div class="noResults">
                The <strong><asp:Literal ID="Literal1" runat="server" Text="<%$ RouteValue:category%>" /></strong> category does not have the page <strong><asp:Literal ID="Literal2" runat="server" Text="<%$ RouteValue:page%>" /></strong>.
			</div>
		</asp:Panel>

		<asp:Panel ID="NoProductsFoundPanel" runat="server" Visible="false">
			<div class="noResults">
                No products were found matching the <strong><asp:Literal ID="Literal3" runat="server" Text="<%$ RouteValue:category%>" /></strong> category you have selected.
			</div>
		</asp:Panel>
		<asp:Panel ID="ProductListPanel" runat="server" Visible="false">
			<div class="productList">
				<asp:ListView ID="ProductDataList" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
					<ItemTemplate>
						<div class="productItem">
							<p class="productImage">
								<img src="/GetProductImage.ashx?pid=<%#Eval("ProductID")%>" alt="<%#Eval("Name")%>" width="50%" /></p>
							<p>
								<strong>
									<%#Eval("ProductNumber")%></strong><br />
								<%#Eval("Name")%></p>
							<p>
								<asp:Label ID="ColorLabel" Visible='<%#DataBinder.Eval(Container.DataItem, "Color") IsNot Nothing%>' runat="server">
									<strong>Color:</strong> <%#Eval("Color")%>
								</asp:Label>
								<asp:Label ID="SizeLabel" Visible='<%#DataBinder.Eval(Container.DataItem, "Size") IsNot Nothing%>' runat="server">
									<strong>Size:</strong> <%#Eval("Size")%>
								</asp:Label>
								<asp:Label ID="WeightLabel" Visible='<%#DataBinder.Eval(Container.DataItem, "Weight") IsNot Nothing%>' runat="server">
									<strong>Weight:</strong> <%#Eval("Weight")%>
								</asp:Label>
							</p>
							<p class="productPrize">
								<%#(CDec(Eval("ListPrice"))).ToString("c")%>
							</p>
							<p class="addToCart">
								<asp:LinkButton ID="AddToCartLinkButton" runat="server" CommandName="AddToCart" CommandArgument='<%#Eval("ProductID")%>'
								  OnClick="AddToCartLinkButton_Click"><span>Add to cart</span></asp:LinkButton>
							</p>
						</div>
					</ItemTemplate>
				</asp:ListView>
			</div>
			<hr />
			<div class="clear">
			</div>
			<asp:Panel ID="PagerPanel" runat="server" Visible="false" CssClass="productPager">
				<div class="productPagerLeftBorder" />
			</asp:Panel>
			<div class="clear">
			</div>
		</asp:Panel>
	</div>
</asp:Content>