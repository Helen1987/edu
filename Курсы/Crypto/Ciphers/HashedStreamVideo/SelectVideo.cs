using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashedStreamVideo
{
	public partial class SelectVideo : Form
	{
		public SelectVideo()
		{
			InitializeComponent();
		}

		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == openFileDialog.ShowDialog()) {
				textBoxFileName.Text = openFileDialog.FileName;
			}
		}

		private void buttonComputeH0_Click(object sender, EventArgs e)
		{
			labelResult.Text = StreamVideo.ComputeH0(openFileDialog.FileName);
		}

		private void buttonCompare_Click(object sender, EventArgs e)
		{
			MessageBox.Show(labelResult.Text.ToLowerInvariant() == textBoxExpected.Text.ToLowerInvariant() ? "Bingo" : "Fail");
		}
	}
}
