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

public partial class ReadWriteConfiguration_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		foreach (ConnectionStringSettings connection in
			WebConfigurationManager.ConnectionStrings)
		{
			Response.Write("Name: " + connection.Name + "<br />");
			Response.Write("Connection String: " +
			  connection.ConnectionString + "<br /><br />");
		}

		Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);

		CompilationSection compSection = (CompilationSection)config.GetSection(@"system.web/compilation");
		foreach (AssemblyInfo assm in compSection.Assemblies)
		{
			Response.Write(assm.Assembly + "<br /");
		}
	}
}
