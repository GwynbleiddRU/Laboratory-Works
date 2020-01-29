using System;
using SuperFunctions;

namespace Laba_11
{
    class Kingdom : Monarchy
    {
        public string monarch;
        public string continent;
        public static int counter;
        public static string[] MONARCH_LIST = new string[100];
        public static string[] CONTINENT_LIST = new string[100];

        static new Random rand = new Random();

        public Kingdom(string type, string name, int gdp, string monarch, string continent) : base(type, name, gdp)
        {
            //name = "Королевство";
            t = type;
            this.name = name;
            GDP = gdp;
            this.monarch = monarch;
            this.continent = continent;

            counter++;
        }

        public Kingdom()
        {

            string[] CONTINENT = new string[] { "Африка", "Европа", "Азия", "Австралия", "Антарктида", "Северная Америка", "Южная Америка", "Программная инженерия" };
            string[] MONARCH = new string[] { "Карл III", "Фридрих VII", "Георгий V", "Франциск IV", "Эммануэль II", "Герман I", "Петр I", "Елизавета II", "Екатерина I", "Георг III", "Княгиня Ольга", "Владимир Мономах", "Александр I", "Иван II", "Иван Грозный", "Алексей Попович", "Добрыня Никитич", "Владимир IX", "Ульфрик I", "Талер I" };
            string[] NAME = new string[] { "Великобритания", "Замбия", "Россия", "Уганда", "Китай", "Германия", "Франция", "Помпея", "Инженерия", "Эфиопия", "Румыния", "Норвегия", "Швейцария", "Монголия", "Польша", "Киргизия", "Армения", "Япония", "Казахстан", "Офис", "Утопия", "Украина", "Беларусь", "Италия", "Испания" };

            int num_t = rand.Next(1, 3);
            if (num_t == 1) this.t = "абсолютная монархия";
            if (num_t == 2) this.t = "ограниченная монархия";

            name = $"{NAME[rand.Next(0, NAME.Length)]}";
            continent = $"{CONTINENT[rand.Next(0, CONTINENT.Length)]}";
            monarch = $"{MONARCH[rand.Next(0, MONARCH.Length)]}";
            this.gdp = rand.Next(246, 754);
            //MonarchSearch();

            MONARCH_LIST[counter] = monarch;
            CONTINENT_LIST[counter] = continent;
            counter++;
        }

        public override void Show()
        {
            //Console.WriteLine("Королевство: " + name + "\n тип: " + t + "\n монарх: " + monarch + "\n континент: " + continent + "\nВВП: " + gdp + " млн. долларов США");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n Государство: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("королевство " + name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n тип: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(t);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n монарх: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(monarch);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n континент: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(continent);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ВВП: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(gdp + " млрд. долларов США");
            Console.WriteLine();
        }

        public static int MonarchSearch()
        {
            //string[] MONARCH_LIST = new string[Kingdom.counter];
            bool ok;
            int amount;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Какой континент Вас интересует?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"1. Европа
2. Азия
3. Африка
4. Австралия
5. Антарктида
6. Северная Америка
7. Южная Америка
8. Программная Инженерия");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВаш выбор: ");
            Console.ForegroundColor = ConsoleColor.Gray;

            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out amount);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ошибка! Необходимо ввести целое число!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                if (amount < 1 || amount > 8)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Выберите вариант 1-8");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!ok || amount < 1 || amount > 8);

            return amount;

        }
        public override string ToString()
        {
            return string.Format(@"Королевство: {1}
Тип: {0}
ВВП: {2}
Монарх: {3}
Континент {4}
", t, name, gdp, monarch, continent);
        }

        public override void Input()
        {
            bool ok;
            double gdp;
            string name = Functions.EnterName("  Введите название государства: ");
            Console.Write("  Введите тип монархии: ");
            string t = Console.ReadLine();
            do
            {
                Console.Write("  Введите ВВП государства: ");
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out gdp);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("  Необходимо ввести число");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (gdp < 0 || gdp > 999)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("  Введите число от 0 до 999");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!ok || gdp < 0 || gdp > 999);
            string continent = Functions.EnterName("  Введите континент: ");
            //string monarch = Functions.EnterName("  Введите имя монарха: ");
            Console.Write("  Введите имя монарха: ");
            string monarch = Console.ReadLine();

            this.name = name;
            this.t = t;
            this.gdp = gdp;
            this.continent = continent;
            this.monarch = monarch;

        }
    }
}
