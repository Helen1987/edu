using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using FileDataComponent;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class FileService : System.Web.Services.WebService
{
	string folder = @"c:\temp";

	[WebMethod(BufferResponse = false)]
	[SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare)]
	public FileData DownloadFile(string serverFileName)
	{
		// Allow downloading of a named file in a set folder.
		serverFileName = Path.GetFileName(serverFileName);
		string serverFilePath = Path.Combine(folder, serverFileName);
		return new FileData(serverFilePath);
	}
}

