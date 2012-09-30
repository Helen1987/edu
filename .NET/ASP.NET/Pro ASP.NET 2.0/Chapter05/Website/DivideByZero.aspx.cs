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

public partial class DivideByZero_aspx : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        int j = 1;
        int k = j/i;
    }
}
