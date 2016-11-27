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


		// запуск сортировки
        private void runSort()
        {
			while (!isSorted())
			{
				distribute();
				assemble();
			}
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

		//private bool isSorted()
		//{
		//	using (StreamReader f = new StreamReader(openFileDialog1.FileName))
		//	{
		//		string prev = "";

		//		char[] buffer = new char[1000];

		//		while (!f.EndOfStream)
		//		{
		//			f.ReadBlock(buffer, 0, 1000);

		//			if (buffer[0] != ' ')
		//				buffer = (prev + buffer).ToCharArray();
		//			else
		//				if (prev != "")
		//					buffer = (prev + " " + buffer).ToCharArray();


		//			string[] tmpStringsArray = buffer.ToString().Split(' ');

		//			if (buffer.Last() == ' ')
		//				prev = "";
		//			else
		//				prev = tmpStringsArray.Last();


		//			for (int i = 0; i < tmpStringsArray.Length - 1; i++)//внимание
		//			{
		//				if (Int32.Parse(tmpStringsArray[i]) > Int32.Parse(tmpStringsArray[i + 1]))
		//					return false;
		//			}
		//		}
		//		return true;
		//	}
		//}

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

		//private void distribute()
		//{
		//	using (StreamReader f = new StreamReader(openFileDialog1.FileName))
		//	using (StreamWriter a = new StreamWriter("FileA", false))
		//	using (StreamWriter b = new StreamWriter("FileB", false))
		//	{
		//		bool isA = true; //определяет направление записи

		//		while (!f.EndOfStream)
		//		{
		//			char[] buffer = new char[100];
		//			f.ReadBlock(buffer, 0, 100);

		//			// разобъём на подстроки по пробелам
		//			string[] tmpStringsArray = String.Concat(buffer).Split(' ', '\0', '\n', '\r');
		//			tmpStringsArray = tmpStringsArray.Where(str => str != "").ToArray();

		//			// записываем первый символ, чтобы получить с чем сравнивать - tmp
		//			int tmp = Int32.Parse(tmpStringsArray[0]);
		//			a.Write(tmpStringsArray[0] + " ");

		//			for (int i = 1; i < tmpStringsArray.Length - 1; i++)
		//			{
		//				// перенаправляем запись, если следующий элемент меньше предыдущего
		//				if (Int32.Parse(tmpStringsArray[i]) < tmp)
		//					if (isA)
		//						isA = false;
		//					else
		//						isA = true;

		//				if (isA)
		//					a.Write(tmpStringsArray[i] + " ");
		//				else
		//					b.Write(tmpStringsArray[i] + " ");

		//				tmp = Int32.Parse(tmpStringsArray[i]);
		//			}


		//			if(Int32.Parse(tmpStringsArray.Last()) < tmp)
		//				if (isA)
		//					isA = false;
		//				else
		//					isA = true;

		//			string last;

		//			if (buffer.Last() == ' ')
		//				last = tmpStringsArray.Last() +  " ";
		//			else
		//				last = tmpStringsArray.Last();

		//			if (isA)
		//				a.Write(last);
		//			else
		//				b.Write(last);
		//		}
		//	}
		//}

		//private void assamblyng()
		//{
		//	using (StreamWriter f0 = new StreamWriter(openFileDialog1.FileName))
		//	using (StreamReader a0 = new StreamReader("fileA"))
		//	using (StreamReader b0 = new StreamReader("fileB"))
		//	{
		//		string prevA = "";
		//		string prevB = "";


		//		while (!a0.EndOfStream || !b0.EndOfStream)
		//		{
		//			char[] bufferA = new char[1000];
		//			char[] bufferB = new char[1000];
		//			a0.ReadBlock(bufferA, 0, 1000);
		//			b0.ReadBlock(bufferB, 0, 1000);

		//			string[] tmpStringsArrayA = bufferA.ToString().Split(' ');
		//			string[] tmpStringsArrayB = bufferB.ToString().Split(' ');

		//			if (bufferA[0] != ' ')
		//				tmpStringsArrayA[0] = prevA + tmpStringsArrayA[0];
		//			if (bufferB[0] != ' ')
		//				tmpStringsArrayB[0] = prevB + tmpStringsArrayB[0];

		//			if (bufferA.Last() == ' ')
		//				prevA = "";
		//			else
		//				prevA = tmpStringsArrayA.Last();
		//			if (bufferB.Last() == ' ')
		//				prevB = "";
		//			else
		//				prevB = tmpStringsArrayB.Last();

		//			int i = 0, j = 0;
		//			while (i < tmpStringsArrayA.Length - 1 || j < tmpStringsArrayB.Length - 1)
		//			{
		//				if (Int32.Parse(tmpStringsArrayA[i]) < Int32.Parse(tmpStringsArrayB[j]))
		//				{
		//					f0.Write(tmpStringsArrayA[i] + " ");
		//					i++;
		//				}
		//				else
		//				{
		//					f0.Write(tmpStringsArrayB[j] + " ");
		//					j++;
		//				}
		//			}
		//		}

		//		if (a0.EndOfStream)
		//		{
		//			char[] bufferB = new char[1000];
		//			b0.ReadBlock(bufferB, 0, 1000);
		//			string[] tmpStringsArrayB = bufferB.ToString().Split(' ');

		//			if (bufferB[0] != ' ')
		//				tmpStringsArrayB[0] = prevB + tmpStringsArrayB[0];

		//			if (bufferB.Last() == ' ')
		//				prevB = "";
		//			else
		//				prevB = tmpStringsArrayB.Last();

		//			int j = 0;

		//			while (j < tmpStringsArrayB.Length - 1)
		//			{
		//				f0.Write(tmpStringsArrayB[j] + " ");
		//				j++;
		//			}
		//		}
		//		else
		//		{
		//			char[] bufferA = new char[1000];
		//			b0.ReadBlock(bufferA, 0, 1000);
		//			string[] tmpStringsArrayA = bufferA.ToString().Split(' ');

		//			if (bufferA[0] != ' ')
		//				tmpStringsArrayA[0] = prevA + tmpStringsArrayA[0];

		//			if (bufferA.Last() == ' ')
		//				prevA = "";
		//			else
		//				prevA = tmpStringsArrayA.Last();

		//			int j = 0;

		//			while (j < tmpStringsArrayA.Length - 1)
		//			{
		//				f0.Write(tmpStringsArrayA[j] + " ");
		//				j++;
		//			}
		//			f0.Flush();
		//		}
		//	}
		//}

		/// <summary>
		/// выполняет этап сборки
		/// </summary>
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
    }
}
