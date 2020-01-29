using System;
using System.Collections;
using System.Collections.Generic;
using SuperMenu;

namespace Laba_11
{
    public class SortedDictionaryWork
    {
        //public IEnumerator GetEnumerator()
        //{
        //    foreach (var key in _states.Keys)
        //        yield return _states[key];
        //}

        public static SortedDictionary<string, StateInterface> _states;

        public SortedDictionaryWork()
        {
        }

        private SortedDictionaryWork(SortedDictionary<string, StateInterface> states)
        {
            _states = states;
        }

        #region AddElement

        //Добавить объект
        private void Add()
        {
            string[] addMenu =
                {"Добавить монархию", "Добавить королевство", "Добавить республику", "Назад"};
            while (true)
            {
                var sw = LiveMenu.Menu("Выберите действие:", addMenu);
                StateInterface state;
                switch (sw)
                {
                    case 0:
                        Console.WriteLine("Введите монархию для добавления: ");
                        state = new Monarchy();
                        state.Input();
                        _states.Add(state.Return_Name() + " " + state.Return_GDP(), state);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("Введите королевство для добавления:");
                        state = new Kingdom();
                        state.Input();
                        _states.Add(state.Return_Name() + " " + state.Return_GDP(), state);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.WriteLine("Введите республику для добавления:");
                        state = new Republic();
                        state.Input();
                        _states.Add(state.Return_Name() + " " + state.Return_GDP(), state);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        return;
                }
            }
        }

        #endregion

        #region DeleteElement

        //Удалить объект
        private void Delete(out int k)
        {
            string[] addMenu =
                {"Удалить монархию", "Удалить королевство", "Удалить республику", "Назад"};
            k = 0;
            while (true)
            {
                var sw = LiveMenu.Menu("Выберите действие:", addMenu);
                StateInterface state;
                switch (sw)
                {
                    case 0:
                        Console.WriteLine("Введите монархию для удаления:");
                        state = new Monarchy();
                        state.Input();

                        if (!_states.ContainsKey(state.Return_Name() + " " + state.Return_GDP()))
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в словаре.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            _states.Remove(state.Return_Name() + " " + state.Return_GDP());
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_states.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 1:
                        Console.WriteLine("Введите королевство для удаления:");
                        state = new Kingdom();
                        state.Input();
                        if (!_states.ContainsKey(state.Return_Name() + " " + state.Return_GDP()))
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в словаре.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            _states.Remove(state.Return_Name() + " " + state.Return_GDP());
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_states.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 2:
                        Console.WriteLine("Введите республику для удаления:");
                        state = new Republic();
                        state.Input();
                        if (!_states.ContainsKey(state.Return_Name() + " " + state.Return_GDP()))
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в словаре.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            _states.Remove(state.Return_Name() + " " + state.Return_GDP());
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_states.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 3:
                        return;
                }
            }
        }

        #endregion

        #region Find

        //Тип поиска
        private void TypeFind()
        {
            string[] queriesMenu =
                {"Поиск элемента типа Monarchy", "Поиск элемента типа Kingdom", "Поиск элемента типа Republic", "Назад"};
            while (true)
            {
                var sw = LiveMenu.Menu("Выберите нужную опцию:", queriesMenu);
                switch (sw)
                {
                    case 0:
                        StateInterface state = new Monarchy();
                        state.Input();
                        if (_states.ContainsKey(state.Return_Name() + " " + state.Return_GDP()))
                        {
                            Console.WriteLine("\nОбъект найден: ");
                            Console.WriteLine("\n{0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          _states[state.Return_Name() + " " + state.Return_GDP()]);
                        }
                        else
                            Console.WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");

                        Console.ReadKey(true);
                        break;
                    case 1:
                        state = new Kingdom();
                        state.Input();
                        if (_states.ContainsKey(state.Return_Name() + " " + state.Return_GDP()))
                        {
                            Console.WriteLine("\nОбъект найден: ");
                            Console.WriteLine("\n{0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          _states[state.Return_Name() + " " + state.Return_GDP()]);
                        }
                        else
                            Console.WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");

                        Console.ReadKey(true);
                        break;
                    case 2:
                        state = new Republic();
                        state.Input();
                        if (_states.ContainsKey(state.Return_Name() + " " + state.Return_GDP()))
                        {
                            Console.WriteLine("\nОбъект найден: ");
                            Console.WriteLine("\n{0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          _states[state.Return_Name() + " " + state.Return_GDP()]);
                        }
                        else
                            Console.WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");

                        Console.ReadKey(true);
                        break;
                    case 3:
                        return;
                }
            }
        }

        #endregion

        #region Output

        //Вывод
        public void Output()
        {
            foreach (var key in _states.Keys) _states[key].Show();

            Console.WriteLine("\n\n\nДля продолженния нажать на любую клавишу...");
            Console.ReadKey(true);
        }

        #endregion

        public void Start()
        {
            string[] stackMenu = {
                "Создать коллекцию", "Добавить элемент", "Удалить элемент", "Выполнение запросов",
                "Клонирование коллекции.", "Сортировка коллекции и поиск элемента",
                "Вывод коллекции, с использованием foreach", "Назад"
            };
            var k = 6;
            while (true)
            {
                var sw = LiveMenu.Menu(k, "  Работа со словарем: ", stackMenu);
                switch (sw)
                {
                    case 1:
                        CreateDictionary();
                        k = 0;
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Delete(out k);
                        break;
                    case 4:
                        TypeQueries();
                        break;
                    case 5:
                        Clone();
                        break;
                    case 6:
                        TypeFind();
                        break;
                    case 7:
                        Output();
                        break;
                    case 8:
                        return;
                }
            }
        }

        #region CreateDictionary

        //Ввод int
        private static int Input(string str)
        {
            var ok = true;
            var digit = 0;
            while (ok)
            {
                Console.Write(str);
                ok = int.TryParse(Console.ReadLine(), out digit);
                if (!ok || digit <= 0)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод...");
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }

            return digit;
        }

        //Создать коллекцию
        private void CreateDictionary()
        {
            _states = new SortedDictionary<string, StateInterface>(new DictComparer());
            int size;
            while (true)
            {
                size = Input("Введите размер коллекции: ");
                if (size == 0)
                    Console.WriteLine("Введена пустая коллекция. Повторите ввод...");
                else
                    break;
            }

            var array = IStateCreate.CreateArray(size);
            foreach (var element in array) _states.Add(element.Return_GDP() + " " + element.Return_Name(), element);
        }

        #endregion

        #region Queries

        //Меню
        private void TypeQueries()
        {
            string[] queriesMenu =
                {"Запросы к типу Monarchy", "Запросы к типу Kingdom", "Запросы к типу Republic", "Назад"};
            while (true)
            {
                var sw = LiveMenu.Menu(0, "Выберите нужную опцию:", queriesMenu);
                switch (sw)
                {
                    case 1:
                        Queries<Monarchy>();
                        break;
                    case 2:
                        Queries<Kingdom>();
                        break;
                    case 3:
                        Queries<Republic>();
                        break;
                    case 4:
                        return;
                }
            }
        }

        //Запросы
        private void Queries<T>()
        {
            string[] queriesMenu = { "Количество объектов", "Печать объектов", "Перегенерировать объекты", "Назад" };
            while (true)
            {
                var sw = LiveMenu.Menu("Выберите нужный пункт:", queriesMenu);
                switch (sw)
                {
                    case 0:
                        var count = 0;
                        foreach (var key in _states.Keys)
                            try
                            {
                                var element = (T)_states[key];
                                count++;
                            }
                            catch
                            {
                                // ignored
                            }

                        Console.
                            WriteLine("Кол-во объектов выбранного типа = {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                      count);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("Объекты выбранного типа: ");
                        foreach (var key in _states.Keys)
                            try
                            {
                                var element = (T)_states[key];
                                IStateCreate.Show(element);
                            }
                            catch
                            {
                                // ignored
                            }

                        Console.WriteLine("\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        count = 0;
                        var tmp = new SortedDictionary<string, StateInterface>(CloneDictionary());
                        foreach (var key in tmp.Keys)
                            try
                            {
                                var element = (T)_states[key];
                                _states.Remove(key);
                                count++;
                            }
                            catch
                            {
                                // ignored
                            }

                        for (var i = 0; i < count; i++)
                        {
                            var add = IStateCreate.CreateElement<T>();
                            _states.Add(add.Return_GDP() + " " + add.Return_Name(), add);
                        }

                        Console.
                            WriteLine("Объекты выбранного типы были перезаписаны.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        return;
                }
            }
        }

        #endregion

        #region Clone

        //Клон
        private void Clone()
        {
            Console.WriteLine("Исходный словарь: ");
            Output();
            Console.WriteLine("\n\n\nСклонированный стэк: ");
            var clone = new SortedDictionaryWork(CloneDictionary());
            clone.Output();
        }

        //Клон
        private SortedDictionary<string, StateInterface> CloneDictionary()
        {
            var newDictionary = new SortedDictionary<string, StateInterface>(new DictComparer());
            foreach (var keys in _states.Keys) newDictionary.Add(keys, _states[keys]);

            return newDictionary;
        }

        #endregion

        //public IEnumerator GetEnumerator()
        //{
        //    return new StateEnumerator<T>(this);
        //}

        //public IEnumerator<KeyValuePair<string, StateInterface>> GetEnumerator()
        //{
        //    foreach (var state in _states)
        //    {
        //        yield return state;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }

    internal class DictComparer : IComparer<string>
    {
        int IComparer<string>.Compare(string obj1, string obj2)
        {
            var state1 = obj1.Split(' ');
            var state2 = obj2.Split(' ');

            if (string.CompareOrdinal(state1[0], state2[0]) >= 1) return 1;

            if (string.CompareOrdinal(state1[0], state2[0]) <= -1) return -1;

            if (string.CompareOrdinal(state1[1], state2[1]) >= 1) return 1;

            if (string.CompareOrdinal(state1[1], state2[1]) <= -1) return -1;

            return 0;
        }

    }

    public class StateEnumerator : IEnumerable<StateInterface>
    {
        public IEnumerator<KeyValuePair<string, StateInterface>> GetEnumerator()
        {
            foreach (var state in SortedDictionaryWork._states)
            {
                yield return state;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<StateInterface> IEnumerable<StateInterface>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //    //    public Dictionary<string, StateInterface> state = new Dictionary<string, StateInterface>();

        //    //    public IEnumerator<StateInterface> GetEnumerator()
        //    //    {
        //    //        return state.Values.GetEnumerator();
        //    //    }

        //    //    IEnumerator IEnumerable.GetEnumerator()
        //    //    {
        //    //        return this.GetEnumerator();
        //    //    }
        }

    }

