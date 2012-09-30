using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using CustomerNotesSetTableAdapters;

namespace APress.WebParts.Samples
{
    public class CustomerNotesPart
        : WebPart, IWebEditable, INotesContract
    {
        #region INotesContract Members

        public string Notes
        {
            get
            {
                EnsureChildControls();

                if (CustomerNotesGrid.SelectedIndex >= 0)
                {
                    int RowIndex = CustomerNotesGrid.SelectedRow.DataItemIndex;

                    DataTable dt = (DataTable)CustomerNotesGrid.DataSource;
                    return (string)dt.Rows[RowIndex]["NoteContent"];
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                EnsureChildControls();

                if (CustomerNotesGrid.SelectedIndex >= 0)
                {
                    // Retrieve the selected row and upate the value
                    int RowIndex = CustomerNotesGrid.SelectedRow.DataItemIndex;

                    DataTable dt = (DataTable)CustomerNotesGrid.DataSource;
                    dt.Rows[RowIndex]["NoteContent"] = value;

                    // Write changes back to the database
                    CustomerNotesTableAdapter adpater =
                            new CustomerNotesTableAdapter();
                    adpater.Update(dt.Rows[RowIndex]);

                    // Update the grids content
                    BindGrid();
                }
            }
        }

        public DateTime SubmittedDate
        {
            get
            {
                EnsureChildControls();

                if (CustomerNotesGrid.SelectedIndex >= 0)
                {
                    int RowIndex = CustomerNotesGrid.SelectedRow.DataItemIndex;

                    DataTable dt = (DataTable)CustomerNotesGrid.DataSource;
                    return (DateTime)dt.Rows[RowIndex]["NoteDate"];
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        #endregion

        [ConnectionProvider("Notes Text")]
        public INotesContract GetNotesCommunicationPoint()
        {
            return (INotesContract)this;
        }

        #region IWebEditable Members

        EditorPartCollection IWebEditable.CreateEditorParts()
        {
            // Create editor parts
            List<EditorPart> Editors = new List<EditorPart>();
            Editors.Add(new CustomerEditor());
            return new EditorPartCollection(Editors);
        }

        object IWebEditable.WebBrowsableObject
        {
            get { return this; }
        }

        #endregion

        public CustomerNotesPart()
        {
            this.Init += new EventHandler(CustomerNotesPart_Init);
            this.Load += new EventHandler(CustomerNotesPart_Load);
            this.PreRender += new EventHandler(CustomerNotesPart_PreRender);
        }

        void CustomerNotesPart_Load(object sender, EventArgs e)
        {
            // Initialize Web Part Properties
            this.Title = "Customer Notes";
            this.TitleIconImageUrl = "NotesImage.jpg";
        }

        void CustomerNotesPart_Init(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BindGrid();
            }
        }

        void BindGrid()
        {
            EnsureChildControls();

            CustomerNotesTableAdapter adapter =
                new CustomerNotesTableAdapter();

            if (Customer.Equals(string.Empty))
                CustomerNotesGrid.DataSource = adapter.GetDataAll();
            else
                CustomerNotesGrid.DataSource = adapter.GetDataByCustomer(Customer);
        }

        void CustomerNotesPart_PreRender(object sender, EventArgs e)
        {
            if (Customer.Equals(string.Empty))
                InsertNewNote.Enabled = false;
            else
                InsertNewNote.Enabled = true;

            CustomerNotesGrid.DataBind();
        }

        public override bool AllowClose
        {
            get
            {
                return false;
            }
            set
            {
                // Don't want this to be set
            }
        }

        private string _Customer = string.Empty;

        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.User)]
        public string Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                _Customer = value;

                if (!this.DesignMode)
                {
                    EnsureChildControls();
                    CustomerNotesGrid.PageIndex = 0;
                    CustomerNotesGrid.SelectedIndex = -1;
                    BindGrid();
                }
            }
        }

        private TextBox NewNoteText;
        private Button InsertNewNote;
        private GridView CustomerNotesGrid;

        protected override void CreateChildControls()
        {
            // Create a textbox for adding new notes
            NewNoteText = new TextBox();

            // Create a button for submitting new notes
            InsertNewNote = new Button();
            InsertNewNote.Text = "Insert...";
            InsertNewNote.Click += new EventHandler(InsertNewNote_Click);

            // Create the grid for displaying customer notes
            CustomerNotesGrid = new GridView();
            CustomerNotesGrid.HeaderStyle.BackColor = Color.LightBlue;
            CustomerNotesGrid.RowStyle.BackColor = Color.LightGreen;
            CustomerNotesGrid.AlternatingRowStyle.BackColor = Color.LightGray;
            CustomerNotesGrid.SelectedRowStyle.Font.Bold = true;
            CustomerNotesGrid.SelectedRowStyle.BackColor = Color.Red;
            CustomerNotesGrid.AllowPaging = true;
            CustomerNotesGrid.PageSize = 5;
            CustomerNotesGrid.DataKeyNames = new string[] { "NoteID" };
            CustomerNotesGrid.AutoGenerateSelectButton = true;
            CustomerNotesGrid.PageIndexChanging += new GridViewPageEventHandler(CustomerNotesGrid_PageIndexChanging);
            CustomerNotesGrid.SelectedIndexChanging += new GridViewSelectEventHandler(CustomerNotesGrid_SelectedIndexChanging);

            // Add all controls to the controls collection
            Controls.Add(NewNoteText);
            Controls.Add(InsertNewNote);
            Controls.Add(CustomerNotesGrid);
        }

        void CustomerNotesGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            CustomerNotesGrid.SelectedIndex = e.NewSelectedIndex;
        }

        void CustomerNotesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CustomerNotesGrid.PageIndex = e.NewPageIndex;
        }

        void InsertNewNote_Click(object sender, EventArgs e)
        {
            CustomerNotesTableAdapter adapter =
                    new CustomerNotesTableAdapter();

            adapter.Insert(Customer, DateTime.Now, NewNoteText.Text);

            BindGrid();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<table>");

            writer.Write("<tr>");
            writer.Write("<td>");
            NewNoteText.RenderControl(writer);
            InsertNewNote.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("<tr>");
            writer.Write("<td>");
            CustomerNotesGrid.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");

            writer.Write("</table>");
        }
    }
}
