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










		private string readWord(StreamReader stream)
		{
			StringBuilder word = new StringBuilder("");

			while (!stream.EndOfStream)
			{
				char tmp = (char)stream.Read();
				if (Char.IsDigit(tmp))
					word.Append(tmp);
				else
					break;
			}

			return word.ToString();
		}

		private void distribute()
		{
			using (StreamReader f = new StreamReader(openFileDialog1.FileName))
			using (StreamWriter a = new StreamWriter("FileA", false))
			using (StreamWriter b = new StreamWriter("FileB", false))
			{
				//определяет направление записи
				bool isA = true;

				string l = readWord(f);

				while (!f.EndOfStream)
				{
					if (isA)
						a.Write(l + " ");
					else
						b.Write(l + " ");

					string r = readWord(f);

					// перенаправляем поток, если левый больше правого
					if (Int32.Parse(l) > Int32.Parse(r))
						if (isA)
							isA = false;
						else
							isA = true;

					l = r;
				}

				// дописываем последний символ
				if (isA)
					a.Write(l);
				else
					b.Write(l);
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
