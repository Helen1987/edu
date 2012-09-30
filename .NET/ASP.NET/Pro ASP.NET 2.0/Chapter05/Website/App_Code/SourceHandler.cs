using System;
using System.Web;
using System.IO;

public class SourceHandler : IHttpHandler
{
	public void ProcessRequest(System.Web.HttpContext context)
	{
		// Make the HTTP context objects easily available.
		HttpResponse response = context.Response;
		HttpRequest request = context.Request;
		HttpServerUtility server = context.Server;

		response.Write("<html><body>");

		// Get the name of the requested file.
		string file = request.QueryString["file"];
		try
		{
			// Open the file and display its contents, one line at a time.
			response.Write("<b>Listing " + file + "</b><br>");
			StreamReader r = File.OpenText(server.MapPath(Path.Combine("./", file)));
			string line = "";
			while (line != null)
			{
				line = r.ReadLine();

				if (line != null)
				{
					// Make sure tags and other special characters are 
					// replaced by their corresponding HTML entities, so they
					// can be displayed appropriately.
					line = server.HtmlEncode(line);

					// Replace spaces and tabs with non-breaking spaces
					// to preserve whitespace.						
					line = line.Replace(" ", "&nbsp;");
					line = line.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

					// A more sophisticated source viewer might apply color-coding.
					response.Write(line + "<br>");
				}
			}
			r.Close();
		}
		catch (ApplicationException err)
		{
			response.Write(err.Message);
		}
		response.Write("</html></body>");
	}

	public bool IsReusable
	{
		get { return true; }
	}
}
