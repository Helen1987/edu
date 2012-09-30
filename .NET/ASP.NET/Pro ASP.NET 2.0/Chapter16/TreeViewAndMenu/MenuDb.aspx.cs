using System.Web.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuDb : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			DataSet ds = GetProductsAndCategories();

			// Loop through the category records.
			foreach (DataRow row in ds.Tables["Categories"].Rows)
			{
				// Use the constructor that requires just text
				// and a non-displayed value.
				MenuItem itemCategory = new MenuItem(
					row["CategoryName"].ToString(),
					row["CategoryID"].ToString());

				Menu1.Items.Add(itemCategory);

				// Get the children (products) for this parent (category).
				DataRow[] childRows = row.GetChildRows(ds.Relations[0]);

				// Loop through all the products in this category.
				foreach (DataRow childRow in childRows)
				{
					MenuItem itemProduct = new MenuItem(
						childRow["ProductName"].ToString(),
						childRow["ProductID"].ToString());
					itemCategory.ChildItems.Add(itemProduct);

				}
			}
		}
	}

	private DataSet GetProductsAndCategories()
	{
		string connectionString =
  WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		SqlConnection con = new SqlConnection(connectionString);

		string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
		string sqlProd = "SELECT ProductID, ProductName, CategoryID FROM Products";

		SqlDataAdapter da = new SqlDataAdapter(sqlCat, con);
		DataSet ds = new DataSet();
		try
		{
			con.Open();

			// Fill the DataSet with the Categories table.
			da.Fill(ds, "Categories");

			// Change the command text and retrieve the Products table.
			// You could also use another DataAdapter object for this task.
			da.SelectCommand.CommandText = sqlProd;
			da.Fill(ds, "Products");
		}
		finally
		{
			con.Close();
		}
		// Define the relationship between Categories and Products.
		DataRelation relat = new DataRelation("CatProds",
		  ds.Tables["Categories"].Columns["CategoryID"],
		  ds.Tables["Products"].Columns["CategoryID"]);

		// Add the relationship to the DataSet.
		ds.Relations.Add(relat);
		return ds;
	}


	protected void Menu1_MenuItemClick(object sender, System.Web.UI.WebControls.MenuEventArgs e)
	{
if (Menu1.SelectedItem == null) return;
		if (Menu1.SelectedItem.Depth == 0)
		{
			lblInfo.Text = "You selected Category ID: ";
		}
		else if (Menu1.SelectedItem.Depth == 1)
		{
			lblInfo.Text = "You selected Product ID: ";
		}
		lblInfo.Text += Menu1.SelectedItem.Value;
	}
}

