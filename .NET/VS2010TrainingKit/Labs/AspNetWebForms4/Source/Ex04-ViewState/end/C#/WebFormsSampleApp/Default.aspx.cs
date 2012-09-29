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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsSampleApp.Models;

namespace WebFormsSampleApp
{
    public partial class _Default : System.Web.UI.Page
    {
        private const int pageSize = 8;

        public string SelectedCategoryName
        {
            get
            {
                if (this.CategoryNameState.Value == null)
                {
                    this.CategoryNameState.Value = "Bikes";
                }

                return this.CategoryNameState.Value;
            }
            set
            {
                this.CategoryNameState.Value = value;
            }
        }

        public int TotalPages
        {
            get
            {
                if (TotalPagesState.Value == null)
                {
                    TotalPagesState.Value = "0";
                }

                return Convert.ToInt32(TotalPagesState.Value);
            }
            set
            {
                TotalPagesState.Value = Convert.ToString(value);
            }
        }

        public int SelectedPage
        {
            get
            {
                if (this.SelectedPageState.Value == null)
                {
                    this.SelectedPageState.Value = "1";
                }

                return Convert.ToInt32(this.SelectedPageState.Value);
            }
            set
            {
                this.SelectedPageState.Value = Convert.ToString(value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SelectedCategoryName = GetCategoryName();
                this.SelectedPage = GetPageIndex();
            }

            ApplyProductsFilter();
            CreatePagerLinks();            
        }

        protected void AddToCartLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton cartLinkButton = sender as LinkButton;
            int productId = (cartLinkButton != null) ? Convert.ToInt32(cartLinkButton.CommandArgument) : 1;
            AdventureWorksRepository repository = new AdventureWorksRepository();
            Product product = repository.GetProduct(productId);

            if (product != null)
            {
                ShoppingCart cart = ShoppingCartFactory.GetInstance();
                cart.AddItem(product.ProductID, product.ProductNumber, product.ListPrice, 1);
            }
        }

        protected void CategoryLink_Load(object sender, EventArgs e)
        {
            HyperLink link = sender as HyperLink;

            if (link != null)
            {
                link.CssClass = (link.Text == this.SelectedCategoryName) ? "selected" : "";
            }
        }

        private string GetCategoryName()
        {
            string category = RouteData.Values["category"] as string;
            AdventureWorksRepository repository = new AdventureWorksRepository();

            if (category != null)
            {
                return category;
            }

            return repository.GetCategories()[0].Name;
        }

        private int GetPageIndex()
        {
            string page = RouteData.Values["page"] as string;

            if (page != null)
                return Convert.ToInt32(page);

            return 1;
        }

        private void ApplyProductsFilter()
        {
            AdventureWorksRepository repository = new AdventureWorksRepository();
            int[] subcatIds = (from c in repository.GetSubcategories(this.SelectedCategoryName)
                               select c.ProductCategoryID).ToArray();

            this.TotalPages = (int)(Math.Ceiling(((double)repository.GetProductsCountByCategories(subcatIds)) / ((double)pageSize)));
            Product[] products = repository.GetProductsByCategories(subcatIds, this.SelectedPage, (int)pageSize);

            ProductDataList.DataSource = products;
            ProductDataList.DataBind();

            ProductListPanel.Visible = true;
            PageIndexOverflowPanel.Visible = ((this.TotalPages < this.SelectedPage) && (this.TotalPages != 0));
            NoProductsFoundPanel.Visible = ((products.Length == 0) && (this.TotalPages == 0));
            PagerPanel.Visible = (this.TotalPages > 1);
        }

        private void CreatePagerLinks()
        {
            for (int i = 1; i <= this.TotalPages; i++)
            {
                HyperLink link = new HyperLink() { Text = i.ToString() };
                if (i == this.SelectedPage)
                {
                    link.CssClass = "currentPage";
                }

                PagerPanel.Controls.Add(link);

                string expression = String.Format("RouteName={0}, category={1}, page={2}", "CategoryAndPage", this.SelectedCategoryName, i);
                link.NavigateUrl = RouteUrlExpressionBuilder.GetRouteUrl(this, expression);
            }
        }
    }
}
