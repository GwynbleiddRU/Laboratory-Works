using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAB_8
{
    [Serializable]
    public partial class Phoenix : Form
    {

        #region Функции

        //public static void OpenText(Phoenix Form1)
        //{
        //    Form1.txtWindow.Text = File.ReadAllText("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
        //}

        public int[,] CreateFile(int amount)
        {
            int[,] income = new int[amount, 12];                                                                              //сохраняем доход в двумерный массив (строки-месяцы; столбцы-подразделения)
            Random rand = new Random();
            string fileName = "C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt";                     //полный путь к файлу

            if (File.Exists(fileName) != true)
            {                                                                                                                //проверяем есть ли такой файл, если его нет, то создаем
                using (StreamWriter OurFile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                {
                    for (int x = 0; x < amount; x++)
                    {
                        for (int y = 0; y < 12; y++)
                        {
                            int temp = rand.Next(10000, 1000000);
                            OurFile.WriteLine("Income of {0} department for {1} month: {2}", x + 1, y + 1, temp);           //пишем строку
                            income[x, y] = temp;
                        }
                        //OurFile.WriteLine();
                    }
                }
                txtWindow.LoadFile("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt", RichTextBoxStreamType.PlainText);
                // txtWindow.Text = File.ReadAllText("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
            }
            else
            {                                                                                                                //если файл есть, то очищаем, откываем его и пишем в него 
                File.WriteAllText(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt", string.Empty);

                using (StreamWriter OurFile = new StreamWriter(new FileStream(fileName, FileMode.Open, FileAccess.Write)))
                {
                    (OurFile.BaseStream).Seek(0, SeekOrigin.End);                                                            //идем в конец файла и пишем строку
                    for (int x = 0; x < amount; x++)
                    {
                        for (int y = 0; y < 12; y++)
                        {
                            int temp = rand.Next(10000, 1000000);
                            OurFile.WriteLine("Income of {0} department for {1} month: {2}", x + 1, y + 1, temp);           //пишем строку
                            income[x, y] = temp;
                        }
                        //OurFile.WriteLine();
                    }
                }
                txtWindow.LoadFile("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt",  RichTextBoxStreamType.PlainText);
            }
            return income;
        }

        public void RemoveLine(int line_to_delete)
        {
            string line = null;
            int line_number = 0;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)
            {
                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    MessageBox.Show("Файл пуст");
                }
                else if (line_to_delete > arrayFiles.Length || line_to_delete <= 0)
                    MessageBox.Show("Строка с таким номером отсутствует");
                else
                {                    

                    using (StreamReader reader = new StreamReader("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt" /*Encoding.GetEncoding(1251)*/))
                    {
                        using (StreamWriter writer = new StreamWriter("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt"))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                line_number++;

                                if (line_number == line_to_delete)
                                    continue;

                                writer.WriteLine(line);
                            }
                        }
                    }

                    File.Delete(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                    File.Copy(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt", @"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                    File.Delete(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt");
                    MessageBox.Show("Строка удалена");
                    txtWindow.LoadFile("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt", RichTextBoxStreamType.PlainText);

                }
            }
            else
            {
                MessageBox.Show("Сначала создайте файл");
            }

        }

        public void ChangeFile(int line_to_change, string modify)
        {
            string line = null;
            int line_number = 0;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)
            {
                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    MessageBox.Show("Файл пуст");
                }
                else if (line_to_change > arrayFiles.Length || line_to_change <= 0)
                    MessageBox.Show("Строка с таким номером отсутствует");
                else
                {

                    string[] arrayFile = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");

                    using (StreamReader reader = new StreamReader("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt"))
                    {
                        using (StreamWriter writer = new StreamWriter("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt"))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                line_number++;

                                if (line_number == line_to_change)
                                {
                                    line = modify;
                                    writer.WriteLine(line);
                                    continue;
                                }

                                writer.WriteLine(line);
                            }
                        }
                    }

                    File.Delete(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                    File.Copy(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt", @"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                    File.Delete(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt");
                    MessageBox.Show("Строка изменена");
                    txtWindow.LoadFile("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt", RichTextBoxStreamType.PlainText);
                }
            }
            else
            {
                MessageBox.Show("Сначала создайте файл");
            }

        }

        public void AddLine(int line_to_add, string modify)
        {

            string line = null;
            int line_number = 0;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)
            {
                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    MessageBox.Show("Файл пуст");
                }
                else if (line_to_add > arrayFiles.Length || line_to_add <= 0)
                {
                    MessageBox.Show("Строка с таким номером отсутствует");
                }
                else
                {

                    using (StreamReader reader = new StreamReader("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt"))
                    {
                        using (StreamWriter writer = new StreamWriter("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt"))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                line_number++;

                                if (line_number == line_to_add)
                                {
                                    string newLine = modify;
                                    writer.WriteLine(newLine);
                                }

                                writer.WriteLine(line);
                            }
                        }
                    }

                    File.Delete(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                    File.Copy(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt", @"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                    File.Delete(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt");
                    txtWindow.LoadFile("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt", RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Строка добавлена");
                }
            }
            else
            {
                MessageBox.Show("Сначала создайте файл");
            }

        }

        public static void AverageIncome()
        {
            //int temp = 0;
            //int vault = 0;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)                       //если файл со значениями уже имеется
            {
                string[] hollow = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");

                #region Костыль
                for (int y = 0; y < hollow.Length; y++)
                {

                    if (hollow[y].Contains("1") == false && (hollow[y].Contains("2") == false && hollow[y].Contains("3") == false && hollow[y].Contains("4") == false && hollow[y].Contains("5") == false && hollow[y].Contains("6") == false && hollow[y].Contains("7") == false && hollow[y].Contains("8") == false && hollow[y].Contains("9") == false && hollow[y].Contains("0") == false))
                    {
                        y += 1;
                        MessageBox.Show("Ошибка: " + y + " строка не содержит значения прибыли");
                        return;
                    }
                    else if (hollow[y] == "0" || hollow[y] == "1" || hollow[y] == "2" || hollow[y] == "3" || hollow[y] == "4" || hollow[y] == "5" || hollow[y] == "6" || hollow[y] == "7" || hollow[y] == "8" || hollow[y] == "9")
                    {
                        y += 1;
                        MessageBox.Show("Неверное значение прибыли в строке " + y + ", - введите число, превышающее хотя бы 10");
                        return;
                    }
                    //for (int x = 0; x < hollow[y].Length; x++)
                    //{
                    //    //string c = hollow[y];
                    //    //if (c[x])
                    //}
                }
                #endregion Костыль

                if (hollow.Length == 0)
                {
                    MessageBox.Show("Файл пуст");
                    return;
                }

                else
                {
                    string[] values = new string[hollow.Length];
                    var builder = new StringBuilder();
                    int index = 0;

                    for (int x = 0; x < hollow.Length; x++)
                    {
                        if (hollow[x].Length != 0)
                        {
                            index = hollow[x].IndexOf(": ");
                            //Console.WriteLine("   {0}", hollow[x].Substring(index + 2));                                            //Тестовый вывод массива только значений доходов
                            values[x] = hollow[x].Substring(index + 2);
                            //Console.WriteLine(values[x]);
                        }
                        else
                            continue;
                    }

                    int departmentAmount = values.Length / 12;
                    int[,] incomeNew = new int[values.Length, departmentAmount];
                    int counter = 0;
                    int currentAmount = 0;
                    string message = null;
                    
                    for (int x = 0; x < departmentAmount; x++)
                    {
                        for (int y = 0; y < 12; y++)
                        {
                            currentAmount += Convert.ToInt32(values[counter]);
                            counter++;
                            //Console.WriteLine(incomeNew[y, x]);
                        }
                        message += "     Средний доход " + Convert.ToString(x + 1) + " подразделения: " + Convert.ToString(currentAmount / 12) + " рублей\n";            //средний ежемесячный доход
                        currentAmount = 0;
                    }
                    MessageBox.Show(message);

                }

            }
            else
            {
                MessageBox.Show("Сначала создайте файл");
            }

        }

        //public static void ShowTextWindow()
        //{
        //    string filename = "C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt";
        //    try
        //    {
        //        using (OpenFileDialog open = new OpenFileDialog() { Filter = "Text Documents|* .txt", Multiselect = false, ValidateNames = true })
        //        {
        //            if(open.ShowDialog() == DialogResult.OK)
        //            {
        //                using (StreamReader reader = new StreamReader(open.FileName))
        //                {
        //                    txtWindow.Text = await reader.ReadToEndAsync();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        #endregion Функции
        #region Приложение
        public Phoenix()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
                button3.Enabled = true;
            else
                button3.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox3.Text.Length > 0) && (textBox4.TextLength > 0))
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox3.Text.Length > 0) && (textBox4.TextLength > 0))
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if ((textBox5.Text.Length > 0) && (textBox6.TextLength > 0))
                button5.Enabled = true;
            else
                button5.Enabled = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if ((textBox5.Text.Length > 0) && (textBox6.TextLength > 0))
                button5.Enabled = true;
            else
                button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button6.Enabled = true;

            int amount;
            //currentSession = 1;
            amount = Convert.ToInt32(textBox1.Text);

            CreateFile(amount);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RemoveLine(Convert.ToInt32(textBox2.Text));
        }
       private void button4_Click(object sender, EventArgs e)
        {
            ChangeFile(Convert.ToInt32(textBox3.Text), textBox4.Text);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            AddLine(Convert.ToInt32(textBox5.Text), textBox6.Text);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AverageIncome();
        }

        private static void txtWindow_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion Приложение

    }
}
