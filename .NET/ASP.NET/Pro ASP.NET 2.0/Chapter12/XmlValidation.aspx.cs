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
using System.Xml.Schema;
using System.Xml;
using System.IO;

public partial class XmlValidation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	private void MyValidateHandler(Object sender, ValidationEventArgs e)
	{
		lblStatus.Text += "Error: " + e.Message + "<br>";
	}
	protected void cmdValidate_Click(object sender, EventArgs e)
	{
		string filePath = "";
		if (optValid.Checked)
		{
			filePath = Server.MapPath("DvdList.xml");
		}
		else if (optInvalidData.Checked)
		{
			filePath += Server.MapPath("DvdListInvalid.xml");
		}

		lblStatus.Text = "";

		// Open the XML file.
		FileStream fs = new FileStream(filePath, FileMode.Open);
		XmlTextReader r = new XmlTextReader(fs);

		// Create the validating reader.
		XmlValidatingReader vr = new XmlValidatingReader(r);
		vr.ValidationType = ValidationType.Schema;

		// Add the XSD file to the validator.
		XmlSchemaCollection schemas = new XmlSchemaCollection();
		schemas.Add("", Server.MapPath("DvdList.xsd"));
		vr.Schemas.Add(schemas);

		// Connect the event handler.
		vr.ValidationEventHandler += new ValidationEventHandler(MyValidateHandler);

		// Read through the document.
		while (vr.Read())
		{
			// Process document here.
			// If an error is found, an exception will be thrown.
		}

		vr.Close();

		lblStatus.Text += "<br>Complete.";
	}
}
