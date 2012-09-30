using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;


public class OrderService : ConfigurationSection 
{
	[ConfigurationProperty("available",
    IsRequired = false)]
	public bool Available
	{
		get { return (bool)base["available"]; }
		set { base["available"] = value; }
	}

	[ConfigurationProperty("pollTimeout",
    IsRequired = true)]
	public TimeSpan PollTimeout
	{
		get { return (TimeSpan)base["pollTimeout"]; }
		set { base["pollTimeout"] = value; }
	}

	[ConfigurationProperty("location",
	 IsRequired = true)]
	public string Location
	{
		get { return (string)base["location"]; }
		set { base["location"] = value; }
	}
}

	
