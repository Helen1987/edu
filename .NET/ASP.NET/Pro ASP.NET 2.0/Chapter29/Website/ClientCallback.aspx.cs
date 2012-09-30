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
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;

public partial class ClientCallback : System.Web.UI.Page,ICallbackEventHandler 
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			string callbackRef = Page.ClientScript.GetCallbackEventReference(
		this,"document.all['lstRegions'].value",
		"ClientCallback", "null");

			lstRegions.Attributes["onClick"] = callbackRef;
		}
	}

	protected void cmdOK_Click(object sender, EventArgs e)
	{
		lblInfo.Text = "You selected territory ID #" + Request.Form["lstTerritories"];
	}

    private string eventArgument;
    public void RaiseCallbackEvent(string eventArgument)
    {
        this.eventArgument = eventArgument;
    }

    public string GetCallbackResult()
    {
        SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Territories WHERE RegionID=@RegionID", con);
        cmd.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 4));
        cmd.Parameters["@RegionID"].Value = Int32.Parse(eventArgument);

        StringBuilder results = new StringBuilder();
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                results.Append(reader["TerritoryDescription"]);
                results.Append("|");
                results.Append(reader["TerritoryID"]);
                results.Append("||");
            }
            reader.Close();
        }
        catch (SqlException err)
        {
            // Hide errors.
        }
        finally
        {
            con.Close();
        }
        return results.ToString();
    }

}
