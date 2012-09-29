// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using WebFormsSampleApp.Models;

namespace WebFormsSampleApp.UserControls
{
    public partial class ShoppingCartControl : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShoppingCart cart = ShoppingCartFactory.GetInstance();

            ExpandedItemsCountLabel.Text = cart.TotalItems.ToString();
            CollapsedItemsCountLabel.Text = cart.TotalItems.ToString();
            ExpandedTotalLabel.Text = cart.Subtotal.ToString("c");
            CollapsedTotalLabel.Text = cart.Subtotal.ToString("c");

            this.ShopCartExpandedEmpty.Visible = cart.TotalItems == 0;
            this.ShopCartExpandedNonEmpty.Visible = cart.TotalItems != 0;

            //TODO: Bind the cart items to the ShoppingCartItemLists
        }
    }
}