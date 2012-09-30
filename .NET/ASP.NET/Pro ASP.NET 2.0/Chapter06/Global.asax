<%@ Application Language="C#" ClassName="Global" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Collections.Generic" %>
<script runat="server">

    private static string[] fileList;
    public static string[] FileList
    {
        get
        {
            if (fileList == null)
            {
                fileList = Directory.GetFiles(HttpContext.Current.Request.PhysicalApplicationPath);
            }
            return fileList;
        }
    }

    private static Dictionary<string, string> metadata = new Dictionary<string, string>();
    public void AddMetadata(string key, string value)
    {
        lock (metadata)
        {
            metadata[key] = value;
        }
    }
    public string GetMetadata(string key)
    {
        lock (metadata)
        {
            return metadata[key];
        }
    }
</script>
