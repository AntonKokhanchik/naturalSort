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





















							prevB = tmpStringsArrayB.Last();


					}
					else
					{
					}
				}
			}


		private bool isSorted(FileStream file)
		{
			file.Seek(0, SeekOrigin.Begin);
			using (StreamReader f = new StreamReader(file))
			{
				string prev = "";

				char[] buffer = new char[1000];

				while (!f.EndOfStream)
				{
					f.ReadBlock(buffer, 0, 1000);

					if (buffer[0] != ' ')
						buffer = (prev + buffer).ToCharArray();
					else
						if (prev != "")
							buffer = (prev + " " + buffer).ToCharArray();


					string[] tmpStringsArray = buffer.ToString().Split(' ');

					if (buffer.Last() == ' ')
						prev = "";
					else
						prev = tmpStringsArray.Last();


					for (int i = 0; i < tmpStringsArray.Length - 1; i++)//внимание
					{
						if (Int32.Parse(tmpStringsArray[i]) > Int32.Parse(tmpStringsArray[i + 1]))
							return false;
					}
				}
				return true;
			}
		}
    }
}
