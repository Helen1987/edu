using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaddingAttack
{
	public partial class Attacker : Form
	{
		public Attacker()
		{
			InitializeComponent();
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			PaddingAttack attacker = new PaddingAttack(textBoxCiphertext.Text, textBoxUrl.Text);
			attacker.FinishGuessHandler += new EventHandler(ShowResult);
			attacker.Start();
		}

		private void ShowResult(object sender, EventArgs e)
		{
			MessageBox.Show("NextUpdate");
			var res = e as PaddingArgs;
			textBoxResult.Text = res.DecodedString;
		}
	}
}
