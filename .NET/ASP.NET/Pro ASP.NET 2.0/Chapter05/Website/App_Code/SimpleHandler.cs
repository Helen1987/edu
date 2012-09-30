using System;
using System.Web;
using System.IO;

public class SimpleHandler : IHttpHandler
{
	public void ProcessRequest(System.Web.HttpContext context)
	{
		HttpResponse response = context.Response;
		response.Write("<html><body><h1>Rendered by the SimpleHandler");
		response.Write("</h1></body></html>");
	}

	public bool IsReusable
	{
		get { return true; }
	}
}
