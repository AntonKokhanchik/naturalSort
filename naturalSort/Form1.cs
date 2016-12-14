using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace naturalSort
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

		// Кнопка выбора файла
        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sortButton.Enabled = true;
            }
        }

		// кнопка запуска сортировки
        private void sortButton_Click(object sender, EventArgs e)
        {
			bool isError = false;
			int i = 0;
			try
			{
				i=runSort();
			}
			catch (Exception)
			{
				isError = true;
			}

			Form2 done = new Form2(isError, i);
			done.ShowDialog();
        }


		// запуск сортировки
        private int runSort()
        {
			int i = 0;
			while (!isSorted())
			{
				distribute();
				assemble();
				i++;
			}
			return i;
        }

		/// <summary>
		/// проверяет отсортированность входного файла
		/// </summary>
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

		/// <summary>
		/// читает слово (до пробела) из указанного потока
		/// </summary>
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

		/// <summary>
		/// выполняет этап распределения
		/// </summary>
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

		/// <summary>
		/// выполняет этап сборки
		/// </summary>
		private void assemble()
		{
			using (StreamWriter f = new StreamWriter(openFileDialog1.FileName, false))
			using (StreamReader a = new StreamReader("fileA"))
			using (StreamReader b = new StreamReader("fileB"))
			{
				string prevA = "";
				string prevB = "";
				string numberA = "";
				string numberB = "";
				while (true)
				{
					// читаем новое число, если требуется
					if (numberA.Length == 0)
					{
						numberA = readWord(a);
						if (prevA.Length != 0 && Int32.Parse(numberA) < Int32.Parse(prevA))
						{
							prevA = "";
							while (!b.EndOfStream)
							{
								if (prevB.Length != 0 && Int32.Parse(numberB) < Int32.Parse(prevB))
									break;
								f.Write(numberB + " ");
								prevB = numberB;
								numberB = readWord(b);
							}
							prevB = "";
						}
					}


					if (numberB.Length == 0)
					{
						numberB = readWord(b);
						if (prevB.Length != 0 && Int32.Parse(numberB) < Int32.Parse(prevB))
						{
							prevB = "";
							while (!a.EndOfStream)
							{
								if (prevA.Length != 0 && Int32.Parse(numberA) < Int32.Parse(prevA))
									break;
								f.Write(numberA + " ");
								prevA = numberA;
								numberA = readWord(a);
							}
							prevA = "";
						}
					}


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
						prevA = numberA;
						numberA = "";
					}
					else
					{
						f.Write(numberB + " ");
						prevB = numberB;
						numberB = "";
					}
				}
			}
		}

		/// <summary>
		/// дописывает файл в поток (учитывая, что уже прочитано по числу из обоих файлов)
		/// </summary>
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

		private void buttonRand_Click(object sender, EventArgs e)
		{
			int n = Int32.Parse(textBoxRand.Text);

			Random r = new Random();
			using (StreamWriter f = new StreamWriter(openFileDialog1.FileName, false))
			{
				for (int i = 0; i < n; i++)
					f.Write(r.Next(100000)+" ");
			}
		}
    }
}
