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

public partial class HolmesQuote : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		SherlockLib.SherlockQuotes quotes = new SherlockLib.SherlockQuotes(Server.MapPath("./sherlock-holmes.xml"));
		SherlockLib.Quotation quote = quotes.GetRandomQuote();
		Response.Write("<b>" + quote.Source + "</b> (<i>" + quote.Date + "</i>)");
		Response.Write("<blockquote>" + quote.QuotationText + "</blockquote>");
			

	}
}
