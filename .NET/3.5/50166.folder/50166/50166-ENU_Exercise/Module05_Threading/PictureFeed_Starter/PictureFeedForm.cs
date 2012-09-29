using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PictureProvider;

namespace PictureFeed_Starter
{
    public partial class PictureFeedForm : Form
    {
        public PictureFeedForm()
        {
            InitializeComponent();
        }

        private void PictureFeedForm_Load(object sender, EventArgs e)
        {
            foreach (IPictureProvider provider in ProviderFactory.Providers)
            {
                int count = provider.PictureCount;

                //This is a synchronous call that is made to each Picture Provider
                //when the application starts.  No UI is shown while the picture names
                //are being retrieved, which makes the user wonder if the application
                //is even working!
                //This call should be performed asynchronously and populate the UI
                //as pictures arrive.  It's probably also advisable to take advantage
                //of the paging support built into the GetPictureNames method, and retrieve
                //(say) 10 image names at a time.
                string[] pictures = provider.GetPictureNames(0, count);
                foreach (string picture in pictures)
                {
                    ListViewItem item = new ListViewItem(picture);
                    item.Tag = provider;
                    images.Items.Add(item);
                }
            }
        }

        private void images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.SelectedItems.Count == 0)
                return;

            ListViewItem item = images.SelectedItems[0];
            IPictureProvider provider = (IPictureProvider)item.Tag;
            
            //This is also a synchronous call which might take a long time,
            //and in the mean time the UI is frozen, allowing no user interaction.
            //This should be an asynchronous call.
            picture.Image = Image.FromStream(new MemoryStream(provider.GetPicture(item.Text).Data));
        }
    }
}
