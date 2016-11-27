using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naturalSort
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sortButton.Enabled = true;
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
			bool isError = false;
			try
			{
				runSort();
			}
			catch (Exception exc)
			{
				isError = true;
			}

			Form2 done = new Form2(isError);
			done.ShowDialog();
        }

        private void runSort()
        {
			while (!isSorted())
			{
				distribute();
				assemble();
			}
        }


		private bool isSorted()
		{
			using (StreamReader f = new StreamReader(openFileDialog1.FileName))
			{
				string l = readWord(f);
				while (!f.EndOfStream)
				{
					string r = readWord(f);
					if (Int32.Parse(l) > Int32.Parse(r))
						return false;
					l = r;
				}
				return true;
			}
		}





















					}
					else
					{
					}
				}
			}

		{
			{
				{

				}
			}
		}
    }
}
