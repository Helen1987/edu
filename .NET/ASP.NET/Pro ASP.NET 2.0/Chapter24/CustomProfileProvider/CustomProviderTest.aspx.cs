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

public partial class ComplexTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
	
		
    }
	protected void cmdSave_Click(object sender, EventArgs e)
	{
		Profile.AddressName = txtName.Text;
		Profile.AddressStreet = txtStreet.Text;
		Profile.AddressCity = txtCity.Text;
		Profile.AddressZipCode = txtZip.Text;
		Profile.AddressState = txtState.Text;
		Profile.AddressCountry = txtCountry.Text;
	}
	protected void cmdGet_Click(object sender, EventArgs e)
	{
		txtName.Text = Profile.AddressName;
		txtStreet.Text = Profile.AddressStreet;
		txtCity.Text = Profile.AddressCity;
		txtZip.Text = Profile.AddressZipCode;
		txtState.Text = Profile.AddressState;
		txtCountry.Text = Profile.AddressCountry;
	}
	
}

