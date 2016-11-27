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

		private void assemble()
		{
			using (StreamWriter f = new StreamWriter(openFileDialog1.FileName, false))
			using (StreamReader a = new StreamReader("fileA"))
			using (StreamReader b = new StreamReader("fileB"))
			{
				string numberA = "";
				string numberB = "";
				while (true)
				{
					// читаем новое число, если требуется
					if (numberA.Length == 0)
						numberA = readWord(a);
			
					if (numberB.Length == 0)
						numberB = readWord(b);

					// если один из файлов кончился, дописываем второй
					if (a.EndOfStream)
					{
						finishAssemblyng(f, b, numberA, numberB);
						break;
					}

					if (b.EndOfStream)
					{
						finishAssemblyng(f, a, numberB, numberA);
						break;
					}

					// если ни один из файлов не кончился, записываем меньшее значение
					if (Int32.Parse(numberA) < Int32.Parse(numberB))
					{
						f.Write(numberA + " ");
						numberA = "";
					}
					else
					{
						f.Write(numberB + " ");
						numberB = "";
					}
				}
			}
		}

		private void finishAssemblyng(StreamWriter f, StreamReader restFile, string lastNumberAnotherFile, string lastNumberRestFile)
		{
			while (!restFile.EndOfStream)
			{
				// у нас остался ещё одно число из опустошённого файла (и одно прочитано из другого файла), сравниваем их
				if (Int32.Parse(lastNumberAnotherFile) < Int32.Parse(lastNumberRestFile))
				{
					// в этом случае дописываем числа, после чего весь файл до конца
					f.Write(lastNumberAnotherFile + " ");
					f.Write(lastNumberRestFile + " ");

					while (!restFile.EndOfStream)
						f.Write((char)restFile.Read());
					return;
				}
				else
				{
					//а в этом продолжаем проверять
					f.Write(lastNumberRestFile + " ");
					lastNumberRestFile = readWord(restFile);
				}
			}

			// а здесь уже оба файла кончились, записываем числа в том или ином порядке
			if (Int32.Parse(lastNumberAnotherFile) < Int32.Parse(lastNumberRestFile))
			{
				f.Write(lastNumberAnotherFile + " ");
				f.Write(lastNumberRestFile);
			}
			else
			{
				f.Write(lastNumberRestFile + " ");
				f.Write(lastNumberAnotherFile);
			}
		}
    }
}
