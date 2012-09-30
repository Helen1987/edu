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

public partial class XmlDataSourceNoFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     sourceDVD.Data=@"<DvdList>
     <DVD ID='1' Category='Science Fiction'>
      <Title>The Matrix</Title>
      <Director>Larry Wachowski</Director>
      <Price>18.74</Price>
      <Starring>
         <Star>Keanu Reeves</Star>
         <Star>Laurence Fishburne</Star>
      </Starring>
   </DVD>
   </DvdList>";


	}
}
