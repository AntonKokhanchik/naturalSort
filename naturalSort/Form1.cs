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
        FileStream file;
        public mainForm()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                sortButton.Enabled = true;
            }


        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            runSort();
        }

        void runSort()
        {
            FileStream fileA = new FileStream("fileA", FileMode.CreateNew, FileAccess.ReadWrite);
            FileStream fileB = new FileStream("fileB", FileMode.CreateNew, FileAccess.ReadWrite);

            StreamReader f = new StreamReader(file);
            StreamWriter a = new StreamWriter(fileA);
            StreamWriter b = new StreamWriter(fileB);

            string prev = "";
			bool isA = true;

            while(!f.EndOfStream)
            {
                char[] buffer = new char[1000];
                f.ReadBlock(buffer, 0, 1000);

                string[] tmpStringsArray = buffer.ToString().Split(' ');

                if (buffer[0] != ' ')
                    tmpStringsArray[0] = prev + tmpStringsArray[0];

				prev = tmpStringsArray.Last();

				int tmp= Int32.Parse(tmpStringsArray[0]);
				a.Write(tmpStringsArray[0] + " ");

				for (int i = 1; i < tmpStringsArray.Length; i++)
				{
					if (Int32.Parse(tmpStringsArray[i]) < tmp)
						if (isA)
							isA = false;
						else
							isA = true;

					if (isA)
						a.Write(tmpStringsArray[i].ToString() + " ");
					else
						b.Write(tmpStringsArray[i].ToString() + " ");
					tmp = Int32.Parse(tmpStringsArray[i]);
				}
            }

			StreamWriter f0 = new StreamWriter(file);
			StreamReader a0 = new StreamReader(fileA);
			StreamReader b0 = new StreamReader(fileB);

			while(!a0.EndOfStream || !b0.EndOfStream)
			{
				
			}
        }
    }
}
