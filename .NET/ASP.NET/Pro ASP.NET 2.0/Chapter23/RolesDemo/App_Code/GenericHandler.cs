using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace RolesDemo.Handlers
{
    public class GenericHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            byte[] ret = null;

            // Open the file specified in the context
            string PhysicalPath = context.Server.MapPath(context.Request.Path);
            using (FileStream fs = new FileStream(PhysicalPath, FileMode.Open))
            {
                ret = new byte[fs.Length];
                fs.Read(ret, 0, (int)fs.Length);
            }

            // If it is not null, return the byte array
            if (ret != null)
            {
                context.Response.BinaryWrite(ret);
            }
        }

        #endregion
    }
}
