using System;
using System.Reflection;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class GenericLogin : System.Web.UI.Page
{
    private ICredentialStore CreateStore()
    {
        // Read the configuration string of the format
        // assemblyname, namespace.classname
        string ConfigEntry = WebConfigurationManager.AppSettings["CredentialStoreClass"];
        string[] ConfigParts = ConfigEntry.Split(new char[] {','});

        // Load the assembly with the implementations
        Assembly CurrentAsm = Assembly.Load(ConfigParts[0].Trim());
        ICredentialStore Store = (ICredentialStore)CurrentAsm.CreateInstance(ConfigParts[1].Trim());

        if (Store == null)
            throw new Exception("Invalid credential store configuration!");
        else
            return Store;
    }

    protected void LoginAction_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid) return;

        ICredentialStore CredStore = this.CreateStore();

        if (CredStore.Authenticate(UsernameText.Text, PasswordText.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, false);
        }
        else
        {
            LegendStatus.Text = "Invalid username or password!";
        }
    }
    protected void RegisterAction_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid) return;

        ICredentialStore CredStore = this.CreateStore();
        CredStore.CreateUser(UsernameText.Text, PasswordText.Text);
        LegendStatus.Text = "User created successfully, you can log in now!";
    }
}
