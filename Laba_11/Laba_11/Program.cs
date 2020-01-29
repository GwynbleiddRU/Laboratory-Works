using System;
using System.Collections;
using SuperFunctions;
using SuperMenu;

namespace Laba_11
{
    class SortByGDP : IComparer
    {
        public int Compare(object a, object b)
        {
            State state = a as State;
            State state1 = b as State;
            if (a != null && b != null)
                return state.CompareTo(state1);
            return 0;
        }
    }

    class Program
    {
        #region Resources
        //Пункты основного меню
        static string[] paragraphs = { "Создание коллекции",
                                          "Просмотр коллекции",
                                          "Удаление объекта коллекции",
                                          "Добавление объекта в коллекцию",
                                          "Выполнение запросов",
                                          "Работа со словарем",
                                          "Выход"};

        //Заголовки
        static string[] headlines = { "  Добро пожаловать в обозреватель государств v2.3",
                                          "  Выберите действие:" };

        //Строка продолжения
        static string end = "Для продолжения нажмите Enter...";

        //Меню запросов
        static string[] requests = {"Вывести количество объектов коллекции",
                                    "Поиск объекта в коллекции",
                                    "Вывести все республики",
                                    "Клонировать коллекцию",
                                    "Сортировка коллекции",
                                    "Вернуться в главное меню"};

        //Ручная/автоматическа генерация объекта в меню add
        static string[] autoHand = {"Заполнить поля вручную",
                                    "Заполнить поля с помощью датчика случайных чисел"};

        //Добавление объекта
        static string[] addInfo = {"Добавить монархию",
                                  "Добавить королевство",
                                  "Добавить республику"};

        //Подтверждение выбора
        static string[] proof = {"Да, продолжить операцию",
                                 "Нет, вернуться в главное меню"};

        //Меню поиска объекта
        static string[] search = {"Найти монархию",
                                  "Найти королевство",
                                  "Найти республику",
                                  "Вернуться в главное меню"};
        //Рандомное название
        static string[] NAME = new string[] { "Великобритания", "Замбия", "Россия", "Уганда", "Китай", "Германия", "Франция", "Помпея", "Инженерия", "Эфиопия", "Румыния", "Норвегия", "Швейцария", "Кровосток", "Польша", "Киргизия", "Армения", "Япония", "Казахстан", "Офис", "Утопия", "Украина" };

        //Рандомный тип республики
        static string[] R_TYPE = new string[] { "парламентарная", "президентская", "смешанная" };

        //Рандоный тип монархии
        static string[] M_TYPE = new string[] { "абсолютная монархия", "ограниченная монархия" };

        //Рандомный ВВП
        //static int gdp = rnd.Next(477, 2777);

        //Рандомный континент
        static string[] CONTINENT = new string[] { "Африка", "Европа", "Азия", "Австралия", "Антарктида", "Северная Америка", "Южная Америка", "Программная инженерия" };

        //Рандомный монарх
        static string[] MONARCH = new string[] { "Карл III", "Фридрих VII", "Георгий V", "Франциск IV", "Эммануэль II", "Герман I", "Петр I", "Елизавета II", "Екатерина I", "Георг III", "Княгиня Ольга", "Владимир Мономах", "Александр I", "Иван II", "Иван Грозный", "Алексей Попович", "Добрыня Никитич", "Владимир IX", "Ульфрик I", "Талер I" };


        //Переменная для рандома
        static Random rnd = new Random();

        #endregion Resources

        #region Functions

        private static State[] CreateCollection()
        //Создание коллекции
        {
            State.counter = 0; //обнуление счетчика при повторном создании коллекции
            State[] state = new State[50];
            for (int i = 0; i < state.Length; i++)
            {
                int check = rnd.Next(1, 4);
                if (check == 1)
                {
                    state[i] = new Republic(R_TYPE[rnd.Next(0, R_TYPE.Length)],
                                         NAME[rnd.Next(0, NAME.Length)],
                                         rnd.Next(477, 977));
                }
                else
                {
                    if (check == 2)
                    {
                        state[i] = new Monarchy(M_TYPE[rnd.Next(0, M_TYPE.Length)],
                                         NAME[rnd.Next(0, NAME.Length)],
                                         rnd.Next(388, 844));
                    }
                    else
                    {
                        state[i] = new Kingdom(M_TYPE[rnd.Next(0, M_TYPE.Length)],
                                         NAME[rnd.Next(0, NAME.Length)],
                                         rnd.Next(322, 712),
                                         MONARCH[rnd.Next(0, MONARCH.Length)],
                                         CONTINENT[rnd.Next(0, CONTINENT.Length)]);
                    }
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Коллекция создана!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n  " + end);
            return state;
        }

        private static void OutputArray(State[] stateArr)
        //Вывод объектов коллекции
        {
            foreach (State state in stateArr)
            {
                state.Show();
            }
            Console.Write("\n" + end);
        }

        private static Monarchy[] ToMonarchy(State[] state)
        //из State в Monarchy
        {
            Monarchy[] monarchies = null;
            foreach (State element in state)
            {
                if (element is Monarchy kingdom)
                {
                    if (monarchies == null)
                    {
                        monarchies = new Monarchy[1];
                    }
                    else
                    {
                        Array.Resize(ref monarchies, monarchies.Length + 1);
                    }

                    monarchies[monarchies.Length - 1] = kingdom;
                }
            }

            return monarchies;
        }

        public static void DeleteElement(ref State[] arr)
        //Удаление объекта коллекции с заданным номером
        {
            if (arr[0] == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n Коллекция пуста, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int i, num;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n Введите номер объекта, который хотите удалить: ");
                do
                {
                    num = CreatingArrays.EnterForArray();
                    if ((num > arr.Length) || (num == 0))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" Ошибка: ожидался номер объекта, существующего в данной коллекции. Попробуйте ещё раз: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while ((num > arr.Length) || (num == 0));
                int m = arr.Length - 1;
                State[] newarr = new State[m];
                for (i = 0; i < num - 1; i++)
                    newarr[i] = arr[i];
                for (i = num - 1; i < m; i++)
                    newarr[i] = arr[i + 1];
                arr = newarr;

                State.counter--;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  Объект успешно удален.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n  " + end);
            }
        }

        public static ArrayList Add(ref State[] arr)
        //Добавление объекта в коллекцию
        {
            bool ok = true;
            ArrayList STATE = new ArrayList();
            while (ok)
            {
                int choice = LiveMenu.Menu(headlines[1], autoHand);
                switch (choice)
                {
                    case 0:
                        STATE.AddRange(arr);
                        int decision = LiveMenu.Menu(headlines[1], addInfo);
                        switch(decision)
                        {
                            case 0:
                                Monarchy monarchy = new Monarchy();
                                monarchy.Input();
                                STATE.Add(monarchy);
                                break;
                            case 1:
                                Kingdom kingdom = new Kingdom();
                                kingdom.Input();
                                STATE.Add(kingdom);
                                break;
                            case 2:
                                Republic republic = new Republic();
                                republic.Input();
                                STATE.Add(republic);
                                break;
                            case 3:
                                break;
                        }

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  Объект успешно добавлен.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n  " + end);
                        Console.ReadLine();
                        return STATE;
                    case 1:
                        int k = rnd.Next(1, 4);
                        STATE.AddRange(arr);
                        if (k == 1)
                        {
                            Republic newState = new Republic();
                            STATE.Add(newState);
                        }
                        if (k == 2)
                        {
                            Monarchy newState = new Monarchy();
                            STATE.Add(newState);
                        }
                        if (k == 3)
                        {
                            Kingdom newState = new Kingdom();
                            STATE.Add(newState);
                        }

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  Объект успешно добавлен.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n  " + end);
                        Console.ReadLine();
                        return STATE;
                }
            }
            return STATE;
        }

        private static StateInterface[] Sort(StateInterface[] state)
        //Сортировка коллекции
        {
            Console.WriteLine("\n  Сортировка коллекции по возрастанию ВВП: \n");
            Array.Sort(state, new SortByGDP());
            //foreach (StateInterface element in state)
            //{
            //    element.Show();
            //}
            return state;
        }

        private static void Clone(State[] state)
        //Клонирование коллекции
        {
            if (state[0] == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n Коллекция пуста, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Monarchy[] monarchy = ToMonarchy(state);

                Monarchy clone = new Monarchy();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Объект для поверхностного копирования: ");
                Console.ForegroundColor = ConsoleColor.White;
                monarchy[0].Show();
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Объект для глубокого копирования: ");
                Console.ForegroundColor = ConsoleColor.White;
                monarchy[1].Show();
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Поверхностное копирование: ");
                Console.ForegroundColor = ConsoleColor.White;
                clone = monarchy[0].SurfaceCopying();
                clone.Show();
                Console.WriteLine("");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Глубокое копирование: ");
                Console.ForegroundColor = ConsoleColor.White;
                clone = (Monarchy)monarchy[1].Clone();
                clone.Show();
                Console.WriteLine("");

                Console.Write("\n  " + end);

            }
        }

        private static void FindState(StateInterface[] state)
        //Поиск объекта в коллекции
        {
            Array.Sort(state, new SortByGDP());

            bool ok = true;
            while (ok)
            {
                int index;
                int choice = LiveMenu.Menu(headlines[1], search);
                switch (choice)
                {
                    case 0:
                        Monarchy monarchy = new Monarchy();
                        monarchy.Input();
                        
                        index = Array.BinarySearch(state, monarchy);
                        try
                        {
                            Monarchy tmp = state[index] as Monarchy;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n  Искомый объект: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            tmp.Show();
                            Console.WriteLine();
                            Console.Write("\n  Номер объекта в коллекции: {0}", index+1);
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n  Искомый объект: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            monarchy.Show();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n Отсутствует в коллекции.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }

                        Console.Write("\n" + end);
                        Console.ReadLine();
                        break;
                    case 1:
                        Kingdom kingdom = new Kingdom();
                        kingdom.Input();

                        index = Array.BinarySearch(state, kingdom);
                        try
                        {
                            Kingdom tmp = state[index] as Kingdom;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n  Искомый объект: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            tmp.Show();
                            Console.WriteLine();
                            Console.Write("\n  Номер объекта в коллекции: {0}", index+1);
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n  Искомый объект: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            kingdom.Show();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n Отсутствует в коллекции.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }

                        Console.Write("\n" + end);
                        Console.ReadLine();
                        break;
                    case 2:
                        Republic republic = new Republic();
                        republic.Input();

                        index = Array.BinarySearch(state, republic);
                        try
                        {
                            Republic tmp = state[index] as Republic;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n  Искомый объект: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            tmp.Show();
                            Console.WriteLine();
                            Console.Write("\n  Номер объекта в коллекции: {0}", index+1);
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\n  Искомый объект: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            republic.Show();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n Отсутствует в коллекции.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }

                        Console.Write("\n" + end);
                        Console.ReadLine();
                        break;
                    case 3:
                        ok = false;
                        break;
                }
            }
        }

        #endregion Functions

        static void Main(string[] args)
        {
            ArrayList STATE = new ArrayList();
            State[] states = new State[50];
            bool ok = true;
            while (ok)
            {
                
                int choice = LiveMenu.Menu(headlines[0], paragraphs);
                switch (choice)
                {
                    case 0:                                                                 //Создание коллекции
                        states = CreateCollection();
                        Console.ReadLine();
                        break;
                    case 1:                                                                 //Просмотр коллекции
                        if (states[0] != null)
                            OutputArray(states);
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  Сначала необходимо создать коллекцию.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n  " + end);
                        }
                        Console.ReadLine();
                        break;

                    case 2:                                                                  //Удаление объекта с заданным номером
                        if (states[0] != null)
                        {
                            DeleteElement(ref states);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  Сначала необходимо создать коллекцию.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n  " + end);
                        }
                        Console.ReadLine();
                        break;

                    case 3:                                                                  //Добавление объекта
                        if (states[0] != null)
                        {
                            STATE = Add(ref states);
                            states = (State[])STATE.ToArray(typeof(State));
                            //преобразуем коллекцию в массив элементов типа State
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  Сначала необходимо создать коллекцию.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n  " + end);
                            Console.ReadLine();
                        }
                        break;
                    case 4:                                                                  //Работа с запросами
                        int task = LiveMenu.Menu(headlines[0], requests);
                        switch (task)
                        {
                            case 0:                                                          //Вывести количество объектов коллекции на данный момент
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n  Количество объектов в коллекции на данный момент: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(State.counter);
                                Console.ReadLine();
                                break;
                            case 1:                                                          //Поиск объекта в коллекции
                                if (states[0] == null)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("  Сначала необходимо создать коллекцию.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\n  " + end);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    int sure = LiveMenu.Menu("  Коллекция будет отсортирована, вы уверены?", proof);
                                    switch (sure)
                                    {
                                        case 0:
                                            StateInterface[] StateSearch = states;
                                            FindState(StateSearch);
                                            break;
                                        case 1:
                                            break;
                                    }
                                }
                                break;
                            case 2:                                                           //Вывод республик
                                if (states[0] == null)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("  Сначала необходимо создать коллекцию.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\n  " + end);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    int R_counter = 0;
                                    for (int i = 0; i < states.Length; i++)
                                    {
                                        if (states[i].t == "парламентарная" || states[i].t == "президентская" || states[i].t == "смешанная")
                                        {
                                            states[i].Show();
                                            R_counter++;
                                        }
                                    }
                                    Console.WriteLine("\n  Количество республик в коллекции: " + R_counter);
                                    Console.Write("\n  " + end);
                                    Console.ReadLine();
                                }
                                break;
                            case 3:                                                           //Клонирование коллекции
                                Clone(states);
                                Console.ReadLine();
                                break;
                            case 4:                                                           //Сортировка коллекции
                                if (states[0] != null)
                                {
                                    StateInterface[] StateSort = states;
                                    StateSort = Sort(StateSort);
                                    states = (State[])StateSort;
                                    OutputArray(states);
                                }                                  
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("  Сначала необходимо создать коллекцию.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\n  " + end);
                                }
                                Console.ReadLine();
                                break;
                            case 5:
                                break;
                        }
                        break;
                    case 5:
                        var dictionary = new SortedDictionaryWork();
                        //IEnumerator myEnumerator =
                        //     dictionary.GetEnumerator();
                        dictionary.Start();
                        break;
                    case 6:
                        ok = false;
                        break;
                }
            }
        }
    }
}

