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

public partial class Customers : System.Web.UI.UserControl, IWebPart
{
    #region IWebPart Members

    private string _CatalogImageUrl;
    public string CatalogIconImageUrl
    {
        get
        {
            return _CatalogImageUrl;
        }
        set
        {
            _CatalogImageUrl = value;
        }
    }

    private string _Description;
    public string Description
    {
        get
        {
            return _Description;
        }
        set
        {
            _Description = value;
        }
    }

    public string Subtitle
    {
        get { return "Internal Customer List"; }
    }

    private string _TitleImage;
    public string TitleIconImageUrl
    {
        get
        {
            if (_TitleImage == null)
                return "CustomersSmall.jpg";
            else
                return _TitleImage;
        }
        set
        {
            _TitleImage = value;
        }
    }

    private string _TitleUrl;
    public string TitleUrl
    {
        get
        {
            return _TitleUrl;
        }
        set
        {
            _TitleUrl = value;
        }
    }

    public string Title
    {
        get
        {
            if (ViewState["Title"] == null)
                return string.Empty;
            else
                return (string)ViewState["Title"];
        }
        set
        {
            ViewState["Title"] = value;
        }
    }

    #endregion

    private string _MyValue = string.Empty;

    [Personalizable()]
    public string MyValue
    {
        get { return _MyValue; }
        set { _MyValue = value; }
    }
}
