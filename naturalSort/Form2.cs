using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace naturalSort
{
	public partial class Form2 : Form
	{
		public Form2(bool isError)
		{
			InitializeComponent();
			if(isError)
			{
				errorLabel.Show();
				OKLabel.Hide();
			}
			else
			{
				errorLabel.Hide();
				OKLabel.Show();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
