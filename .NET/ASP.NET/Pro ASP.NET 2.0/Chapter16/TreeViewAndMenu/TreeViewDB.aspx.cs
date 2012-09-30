using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class TreeViewDB : System.Web.UI.Page
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
				TreeNode nodeCategory = new TreeNode(
					row["CategoryName"].ToString(),
					row["CategoryID"].ToString());

				TreeView1.Nodes.Add(nodeCategory);

				// Get the children (products) for this parent (category).
				DataRow[] childRows = row.GetChildRows(ds.Relations[0]);

				// Loop through all the products in this category.
				foreach (DataRow childRow in childRows)
				{
					TreeNode nodeProduct = new TreeNode(
						childRow["ProductName"].ToString(),
						childRow["ProductID"].ToString());
					nodeCategory.ChildNodes.Add(nodeProduct);
				}

				// Keep all categories collapsed (initially).
				nodeCategory.Collapse();
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
	protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
	{
		if (TreeView1.SelectedNode == null) return;
		if (TreeView1.SelectedNode.Depth == 0)
		{
			lblInfo.Text = "You selected Category ID: ";
		}
		else if (TreeView1.SelectedNode.Depth == 1)
		{
			lblInfo.Text = "You selected Product ID: ";
		}
		lblInfo.Text += TreeView1.SelectedNode.Value;
	}
}
