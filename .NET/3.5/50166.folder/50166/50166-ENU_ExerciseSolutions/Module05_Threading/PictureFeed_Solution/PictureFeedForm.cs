using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PictureProvider;

namespace PictureFeed_Solution
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
                //Prevent the anonymous method below from incorrectly capturing
                //the iteration variable:
                IPictureProvider copy = provider;

                int count = copy.PictureCount;

                //Request picture names in batches of two pictures at a time.
                //Process each batch independently as it arrives.
                const int BatchSize = 2;
                for (int start = 0; start < count; start += BatchSize)
                {
                    Func<int, int, string[]> getPictureNames = provider.GetPictureNames;
                    IAsyncResult ar = null;
                    //Asynchronously request two picture names and add them to the UI
                    //list view when they arrive.
                    ar = getPictureNames.BeginInvoke(start, Math.Min(count - start, BatchSize), delegate
                    {
                        string[] pictures = getPictureNames.EndInvoke(ar);
                        foreach (string picture in pictures)
                        {
                            //We're doing the update from a thread that is not the UI thread,
                            //so use BeginInvoke on the list view to perform the update.
                            images.BeginInvoke((MethodInvoker)delegate
                            {
                                ListViewItem item = new ListViewItem(picture);
                                item.Tag = copy;
                                images.Items.Add(item);
                            });
                        }
                    }, null);
                }
            }
        }

        private void images_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (images.SelectedItems.Count == 0)
                return;

            ListViewItem item = images.SelectedItems[0];
            IPictureProvider provider = (IPictureProvider)item.Tag;
            
            //Request the image data asynchronously.  In the meantime, the user
            //can still interact with the UI.  Let the user know that we are working
            //by updating the form text.
            this.Text = "Retrieving picture...";
            Func<string, Picture> getPicture = provider.GetPicture;
            IAsyncResult ar = null;
            ar = getPicture.BeginInvoke(item.Text, delegate
            {
                Picture image = getPicture.EndInvoke(ar);
                //The picture arrived asynchronously on another thread, so we use
                //BeginInvoke on the form to update the UI.
                this.BeginInvoke((MethodInvoker)delegate
                {
                    picture.Image = Image.FromStream(new MemoryStream(image.Data));
                    this.Text = "Picture retrieved";
                });
            }, null);
        }
    }
}
