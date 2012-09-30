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

public partial class TreeViewDbOnDemand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			DataTable dtCategories = GetCategories();

			// Loop through the category records.
			foreach (DataRow row in dtCategories.Rows)
			{
				TreeNode nodeCategory = new TreeNode(
					row["CategoryName"].ToString(),
					row["CategoryID"].ToString());

				// Use the populate-on-demand feature for this
				// node's children.
				nodeCategory.PopulateOnDemand = true;

				// Make sure the node is collapsed at first,
				// so it's no populated immediately.
				nodeCategory.Collapse();
				TreeView1.Nodes.Add(nodeCategory);
			}
		}
    }

	private DataTable GetCategories()
	{
		string connectionString =
  WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		SqlConnection con = new SqlConnection(connectionString);

		string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
		
		SqlDataAdapter da = new SqlDataAdapter(sqlCat, con);
		DataSet ds = new DataSet();
		try
		{
			con.Open();

			// Fill the DataSet with the Categories table.
			da.Fill(ds, "Categories");
		}
		finally
		{
			con.Close();
		}
		
		return ds.Tables["Categories"];
	}

	private DataTable GetProducts(int categoryID)
	{
		string connectionString =
  WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		SqlConnection con = new SqlConnection(connectionString);

		string sqlProd = "SELECT ProductID, ProductName, CategoryID FROM Products WHERE CategoryID=@CategoryID";
		
		SqlDataAdapter da = new SqlDataAdapter(sqlProd, con);
		da.SelectCommand.Parameters.AddWithValue("@CategoryID", categoryID);
		DataSet ds = new DataSet();
		try
		{
			con.Open();

			// Fill the DataSet with the Categories table.
			da.Fill(ds, "Products");
		}
		finally
		{
			con.Close();
		}
		return ds.Tables["Products"];
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
	protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
	{
		// The only on-populate nodes are categories.
		// However, if there were several types you would check
		// the TreeNode.Depth to determine what type of node
		// is being expanded.
		int categoryID = Int32.Parse(e.Node.Value);
		DataTable dtProducts = GetProducts(categoryID);

		// Loop through the product records.
		foreach (DataRow row in dtProducts.Rows)
		{
			// Use the constructor that requires just text
			// and a non-displayed value.
			TreeNode nodeProduct = new TreeNode(
				row["ProductName"].ToString(),
				row["ProductID"].ToString());

			e.Node.ChildNodes.Add(nodeProduct);
		}
	}
}
