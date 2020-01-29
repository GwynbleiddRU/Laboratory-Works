using System;
using SuperFunctions;

namespace Laba_11
{
    class Monarchy : State, ICloneable
    {
        public static Random rand = new Random();
        public Monarchy(string type, string name, int gdp)
        {
            t = type;
            this.name = name;
            this.gdp = gdp;
        }
        public Monarchy()
        {
            string[] NAME = new string[] { "Великобритания", "Замбия", "Россия", "Уганда", "Китай", "Германия", "Франция", "Помпея", "Инженерия", "Эфиопия", "Румыния", "Норвегия", "Швейцария", "Кровосток", "Польша", "Киргизия", "Армения", "Япония", "Казахстан", "Офис", "Утопия", "Украина" };
            int num_t = rand.Next(1, 3);
            if (num_t == 1) this.t = "абсолютная монархия";
            if (num_t == 2) this.t = "ограниченная монархия";

            name = $"{NAME[rand.Next(0, NAME.Length)]}";
            this.gdp = rand.Next(222, 844);
        }
        public override void Show()
        {
            //Console.WriteLine("Государство: " + "монархия" + "\n тип: " + t + "\n название: " + name + "\n ВВП: " + gdp + " млрд. долларов США");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n Государство: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("монархия");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n тип: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(t);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n название: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ВВП: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(gdp + " млрд. долларов США");
            Console.WriteLine();
        }
        public override string ToString()
        {
            return string.Format(@"Государство: монархия
Тип: {0}
Название: {1}
ВВП: {2}
", t, name, gdp);
        }

        //ручной ввод для поиска объекта
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
            this.name = name;
            this.t = t;
            this.gdp = gdp;

        }

        //Поверхностное копирование
        public Monarchy SurfaceCopying()
        {
            return (Monarchy)this.MemberwiseClone();
        }

        //Глубокое копирование
        public object Clone()
        {
            return new Monarchy(t, name, (int)gdp);
        }
    }
}
