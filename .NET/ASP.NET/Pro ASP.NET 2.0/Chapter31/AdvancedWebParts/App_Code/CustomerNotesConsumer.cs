using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace APress.WebParts.Samples
{
    public class CustomerNotesConsumer : WebPart
    {
        private Label NotesTextLabel;
        private TextBox NotesContentText;
        private Button UpdateNotesContent;

        protected override void CreateChildControls()
        {
            NotesTextLabel = new Label();
            NotesTextLabel.Text = DateTime.Now.ToString();

            NotesContentText = new TextBox();
            NotesContentText.TextMode = TextBoxMode.MultiLine;
            NotesContentText.Rows = 5;
            NotesContentText.Columns = 20;

            UpdateNotesContent = new Button();
            UpdateNotesContent.Text = "Update";
            UpdateNotesContent.Click += new EventHandler(UpdateNotesContent_Click);

            Controls.Add(NotesTextLabel);
            Controls.Add(NotesContentText);
            Controls.Add(UpdateNotesContent);
        }

        void UpdateNotesContent_Click(object sender, EventArgs e)
        {
            if (_NotesProvider != null)
            {
                _NotesProvider.Notes = NotesContentText.Text;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            // Don't forget to call base implementation
            base.OnPreRender(e);

            // Initialize control
            if (_NotesProvider != null)
            {
                NotesContentText.Text = _NotesProvider.Notes;
                NotesTextLabel.Text = _NotesProvider.SubmittedDate.ToShortDateString();
            }
        }

        private INotesContract _NotesProvider;

        [ConnectionConsumer("Customer Notes", "MyConsumerID")]
        public void InitializeProvider(INotesContract provider)
        {
            _NotesProvider = provider;
        }
    }
}