using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace LAB_8
{
    static class Program
    {
        public static int[,] income;
        public static int currentSession = 0;

        public static int[,] CreateFile(int amount)
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
                            OurFile.WriteLine("Доход {0} подразделения за {1} месяц: {2}", x + 1, y + 1, temp);           //пишем строку
                            income[x, y] = temp;
                        }
                        OurFile.WriteLine();
                    }
                }
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
                            OurFile.WriteLine("Доход {0} подразделения за {1} месяц: {2}", x + 1, y + 1, temp);           //пишем строку
                            income[x, y] = temp;
                        }
                        OurFile.WriteLine();
                    }
                }
            }
            return income;
        }

        public static void ReadFile()
        {
            string fileName = "C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt";
            if (File.Exists(fileName) == true)
            {

                if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt") == true)      // наличие измененного файла
                {
                    string[] arrayFile = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt");

                    if (arrayFile.Length != 0)
                        fileName = "C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt";
                }

                try
                {                                                                                                                //чтение айла
                    string[] allText = File.ReadAllLines(fileName);                                                              //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {                                                                                                            //вывод всех строк на консоль
                        Console.WriteLine(s);
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                //Console.ReadKey();

                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Файл пуст");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }


                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Сначала создайте файл");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        public static void ClearFile()
        {

            File.WriteAllText(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt", string.Empty);
            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt") == true)
            {
                File.WriteAllText(@"C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt", string.Empty); //наличие измененного файла
            }

            File.Delete("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttemptModified.txt");
            Console.WriteLine("     Файл очищен");
            return;
        }

        public static void RemoveLine()
        {
            string line = null;
            int line_number = 0;
            int line_to_delete;
            bool ok;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)
            {
                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Файл пуст");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("     Введите номер строки, которую вы хотите удалить: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    do
                    {
                        string buf = Console.ReadLine();
                        ok = int.TryParse(buf, out line_to_delete);
                        if (!ok)
                            Console.WriteLine("     Введите номер строки (число)");
                    } while (!ok || line_to_delete < 0);

                    using (StreamReader reader = new StreamReader("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt"))
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
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Сначала создайте файл");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void ChangeFile()
        {
            bool ok;
            string line = null;
            int line_number = 0;
            int line_to_change;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)
            {
                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Файл пуст");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("     Введите номер строки, которую вы хотите изменить: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    do
                    {
                        string buf = Console.ReadLine();
                        ok = int.TryParse(buf, out line_to_change);
                        if (!ok)
                            Console.WriteLine("     Введите номер строки (число)");
                    } while (!ok || line_to_change < 0);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("     Введите новую строку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string modify = Console.ReadLine();

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
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Сначала создайте файл");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void AddLine()
        {

            bool ok;
            string line = null;
            int line_number = 0;
            int line_to_add;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)
            {
                string[] arrayFiles = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");
                if (arrayFiles.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Файл пуст");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("     Введите номер строки, которую вы хотите добавить: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    do
                    {
                        string buf = Console.ReadLine();
                        ok = int.TryParse(buf, out line_to_add);
                        if (!ok)
                            Console.WriteLine("    Введите номер строки (число)");
                    } while (!ok || line_to_add < 0);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("    Введите новую строку: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string modify = Console.ReadLine();

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
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Сначала создайте файл");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        public static void AverageIncome()
        {
            int temp = 0;
            int vault = 0;

            if (File.Exists("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt") == true)                       //если файл со значениями уже имеется
            {
                string[] hollow = File.ReadAllLines("C:/Users/Пользователь ПК/Desktop/Soft & Coding/Files/AnotherAttempt.txt");

                if (hollow.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("     Файл пуст");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }

                else if (currentSession == 0)
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
                    for (int x = 0; x < departmentAmount; x++)
                    {
                        for (int y = 0; y < 12; y++)
                        {
                            currentAmount += Convert.ToInt32(values[counter]);
                            counter++;
                            //Console.WriteLine(incomeNew[y, x]);
                        }
                        Console.WriteLine("     Средний доход {0} подразделения: {1} рублей", x + 1, currentAmount / 12);               //средний ежемесячный доход
                        currentAmount = 0;
                    }

                    //ColorfulConsole.WriteLine("              _", Color.Orange);
                    //ColorfulConsole.WriteLine("              \\`*-.", Color.Orange);
                    //ColorfulConsole.WriteLine("               )  _`-.", Color.Orange);
                    //ColorfulConsole.WriteLine("              .  : `. .                ", Color.Orange);
                    //ColorfulConsole.WriteLine("              : _   '  \\               ", Color.Orange);
                    //ColorfulConsole.Write("              ; ", Color.Orange);
                    //ColorfulConsole.Write("*", Color.GreenYellow);
                    //ColorfulConsole.Write("` _.   `*-._", Color.Orange);
                    //ColorfulConsole.Write("\n              `", Color.DeepPink);
                    //ColorfulConsole.Write("-.- '          `-.       ", Color.Orange);
                    //ColorfulConsole.WriteLine("\n                ;       `       `.     ", Color.Orange);
                    //ColorfulConsole.WriteLine("                :.       .        \\    ", Color.Orange);
                    //ColorfulConsole.WriteLine("                . \\  .   :   .-'   .   ", Color.Orange);
                    //ColorfulConsole.WriteLine("                '  `+.;  ;  '      :   ", Color.Orange);
                    //ColorfulConsole.Write("  \\ /           ", Color.ForestGreen);
                    //ColorfulConsole.Write(":  '  | ;  ;       ;-. ", Color.Orange);
                    //ColorfulConsole.Write("\n  >v<", Color.ForestGreen);
                    //ColorfulConsole.Write("           ; '   : :`-:     _.`* ;", Color.Orange);
                    //ColorfulConsole.Write("\n  >O<        ", Color.ForestGreen);
                    //ColorfulConsole.Write("* ' /  .*'; .*`-+'  `*'", Color.Orange);
                    //ColorfulConsole.Write("\n  >O<", Color.ForestGreen);
                    //ColorfulConsole.Write("        `*-*   `*-*  `*-*'", Color.Orange);
                    //Console.WriteLine("\n");
                    //Console.ForegroundColor = ConsoleColor.White;

                }
                if (currentSession == 1)
                {
                    for (int x = 0; x < income.GetLength(0); x++)
                    {

                        for (int y = 0; y < 12; y++)
                        {
                            temp += income[x, y];
                            //if (y == 11)
                            //    vault = temp / 12;
                        }

                        vault = temp / 12;
                        Console.WriteLine("     Средний доход {0} подразделения: {1} рублей", x + 1, vault);
                        vault = 0;
                        temp = 0;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     Сначала создайте файл");
                Console.ForegroundColor = ConsoleColor.Gray;
            }


        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Phoenix());
        }
    }
}
