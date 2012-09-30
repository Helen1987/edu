using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

public partial class DataSetRelationships : System.Web.UI.Page
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the Connection, DataAdapter, and DataSet.
		string connectionString = "Data Source=localhost;Initial Catalog=Northwind;" +
			"Integrated Security=SSPI";
		SqlConnection con = new SqlConnection(connectionString);

		string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
		string sqlProd = "SELECT ProductName, CategoryID FROM Products";

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

		// Loop through the category records and build the HTML string.
		StringBuilder htmlStr = new StringBuilder("");
		foreach (DataRow row in ds.Tables["Categories"].Rows)
		{
			htmlStr.Append("<b>");
			htmlStr.Append(row["CategoryName"].ToString());
			htmlStr.Append("</b><ul>");

			// Get the children (products) for this parent (category).
			DataRow[] childRows = row.GetChildRows(relat);
			// Loop through all the products in this category.
			foreach (DataRow childRow in childRows)
			{
				htmlStr.Append("<li>");
				htmlStr.Append(childRow["ProductName"].ToString());
				htmlStr.Append("</li>");
			}
			htmlStr.Append("</ul>");
		}

		// Show the generated HTML code.
		HtmlContent.Text = htmlStr.ToString();
	}

}