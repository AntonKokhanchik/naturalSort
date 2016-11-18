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

                if (buffer[0] != ' ')
                    buffer = (prev + buffer.ToString()).ToCharArray();
				else
					if(prev != "")
						buffer = (prev+ " " + buffer.ToString()).ToCharArray();


                string[] tmpStringsArray = buffer.ToString().Split(' ');

				if (buffer.Last() == ' ')
					prev = "";
				else
					prev = tmpStringsArray.Last();

				int tmp= Int32.Parse(tmpStringsArray[0]);
				a.Write(tmpStringsArray[0] + " ");

				for (int i = 1; i < tmpStringsArray.Length - 1; i++)
				{
					if (Int32.Parse(tmpStringsArray[i]) < tmp)
						if (isA)
							isA = false;
						else
							isA = true;

					if (isA)
						a.Write(tmpStringsArray[i] + " ");
					else
						b.Write(tmpStringsArray[i] + " ");
					tmp = Int32.Parse(tmpStringsArray[i]);
				}
            }
			if (isA)
				a.Write(prev);
			else
				b.Write(prev);

			StreamWriter f0 = new StreamWriter(file);
			StreamReader a0 = new StreamReader(fileA);
			StreamReader b0 = new StreamReader(fileB);

			string prevA = "";
			string prevB = "";

			while(!a0.EndOfStream || !b0.EndOfStream)
			{
				char[] bufferA = new char[1000];
				char[] bufferB = new char[1000];
				a0.ReadBlock(bufferA, 0, 1000);
				b0.ReadBlock(bufferB, 0, 1000);

				string[] tmpStringsArrayA = bufferA.ToString().Split(' ');
				string[] tmpStringsArrayB = bufferB.ToString().Split(' ');

				if (bufferA[0] != ' ')
					tmpStringsArrayA[0] = prev + tmpStringsArrayA[0];
				if (bufferB[0] != ' ')
					tmpStringsArrayB[0] = prev + tmpStringsArrayB[0];

				if (bufferA.Last() == ' ')
					prevA = "";
				else
					prevA = tmpStringsArrayA.Last();
				if (bufferB.Last() == ' ')
					prevB = "";
				else
					prevB = tmpStringsArrayB.Last();

				int i = 0, j = 0;
				while (i < tmpStringsArrayA.Length-1 || j < tmpStringsArrayB.Length-1)
				{
					if (Int32.Parse(tmpStringsArrayA[i]) < Int32.Parse(tmpStringsArrayB[j]))
					{
						f0.Write(tmpStringsArrayA[i] + " ");
						i++;
					}
					else
					{
						f0.Write(tmpStringsArrayB[j] + " ");
						j++;
					}
				}

				if(i==tmpStringsArrayA.Length-1)
					while(j<tmpStringsArrayB.Length-1)
					{
						f0.Write(tmpStringsArrayB[j] + " ");
						j++;
					}
				else if(j==tmpStringsArrayB.Length-1)
				{
					while (i < tmpStringsArrayA.Length-1)
					{
						f0.Write(tmpStringsArrayA[i] + " ");
						i++;
					}
				}
			}


        }
    }
}
