using System;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MyProvider
/// </summary>
public class MyProvider : System.Web.Hosting.VirtualPathProvider
{
    public static void Appinitialize()
    {
        MyProvider fileProvider = new MyProvider();
        System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(fileProvider);
    }

    private string GetFileFromDB(string virtualPath)
    {
        string contents;
        string fileName = virtualPath.Substring(
                            virtualPath.IndexOf('/', 1) + 1);

        // Read the file from the database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "data source=(local);Integrated Security=SSPI;initial catalog=AspContent";
        conn.Open();

        try
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT FileContents FROM AspContent " +
                "WHERE FileName=@fn", conn);
            cmd.Parameters.Add("@fn", fileName);
            contents = cmd.ExecuteScalar() as string;
            if (contents == null)
                contents = string.Empty;
        }
        catch
        {
            contents = string.Empty;
        }
        finally
        {
            conn.Close();
        }

        return contents;
    }

    public override bool FileExists(string virtualPath)
    {
        string contents = this.GetFileFromDB(virtualPath);
        if (contents.Equals(string.Empty))
            return false;
        else
            return true;
    }

    public override System.Web.Hosting.VirtualFile GetFile(string virtualPath)
    {
        string contents = this.GetFileFromDB(virtualPath);
        if (contents.Equals(string.Empty))
            return Previous.GetFile(virtualPath);
        else
            return new MyVirtualFile(virtualPath, contents);
    }
}

public class MyVirtualFile : System.Web.Hosting.VirtualFile
{
    private string _FileContent;

    public MyVirtualFile(string virtualPath, string fileContent)
        : base(virtualPath)
    {
        _FileContent = fileContent;
    }

    public override Stream Open()
    {
        Stream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);

        writer.Write(_FileContent);
        writer.Flush();
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}
