using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

public class FindBook
{
	public string GetImageUrl(string isbn)
	{
		try
		{
			// Find the pointer to the book cover image.
			// Amazon.com has the most cover images,
			// so go there to look for it.
			// Start with the book details page.
			isbn = isbn.Replace("-", "");
			string bookUrl = "http://www.amazon.com/exec/obidos/ASIN/" + isbn;

			// Now retrieve the HTML content of the book details page.
			string bookHtml = GetWebPageAsString(bookUrl);

			// Search the page for an image tag that has the ISBN
			// we need.
			string imgTagPattern = "<img src=\"(http://images.amazon.com/images/P/" + isbn + "[^\"]+)\"";

			Match imgTagMatch = Regex.Match(bookHtml, imgTagPattern);
			return imgTagMatch.Groups[1].Value;
		}
		catch
		{
			return "";
		}
	}

	public string GetWebPageAsString(string url)
	{
		// Create the request.
		WebRequest requestHtml = WebRequest.Create(url);

		// Get the response.
		WebResponse responseHtml = requestHtml.GetResponse();

		// Read the response stream.
		StreamReader r = new StreamReader(responseHtml.GetResponseStream());
		string htmlContent = r.ReadToEnd();
		r.Close();

		return htmlContent;
	}
}
