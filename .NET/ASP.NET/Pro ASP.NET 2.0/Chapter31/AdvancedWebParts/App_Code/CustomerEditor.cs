using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomersSetTableAdapters;

namespace APress.WebParts.Samples
{
    public class CustomerEditor : EditorPart
    {
        public CustomerEditor()
        {
            this.Init += new EventHandler(CustomerEditor_Init);
        }

        void CustomerEditor_Init(object sender, EventArgs e)
        {
            EnsureChildControls();

            CustomerTableAdapter adapter = new CustomerTableAdapter();
            CustomersList.DataSource = adapter.GetData();
            CustomersList.DataTextField = "CompanyName";
            CustomersList.DataValueField = "CustomerID";
            CustomersList.DataBind();

            CustomersList.Items.Insert(0, "");
        }

        public override bool ApplyChanges()
        {
            // Make sure that all controls are available
            EnsureChildControls();

            // Get the property from the WebPart
            CustomerNotesPart part = (CustomerNotesPart)WebPartToEdit;
            if (part != null)
            {
                if (CustomersList.SelectedIndex >= 0)
                    part.Customer = CustomersList.SelectedValue;
                else
                    part.Customer = string.Empty;
            }
            else
            {
                return false;
            }

            return true;
        }

        public override void SyncChanges()
        {
            // Make sure that all controls are available
            EnsureChildControls();

            // Get the property from the WebPart
            CustomerNotesPart part = (CustomerNotesPart)WebPartToEdit;
            if (part != null)
            {
                CustomersList.SelectedValue = part.Customer;
            }
        }

        private ListBox CustomersList;

        protected override void CreateChildControls()
        {
            CustomersList = new ListBox();
            CustomersList.Rows = 4;

            Controls.Add(CustomersList);
        }
    }
}