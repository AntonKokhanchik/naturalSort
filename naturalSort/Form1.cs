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

            while(true)
            {

            }
        }
    }
}
