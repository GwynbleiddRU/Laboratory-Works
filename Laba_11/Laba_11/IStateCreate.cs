using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    internal static class IStateCreate
    {
        static string[] CONTINENT = new string[] { "Африка", "Европа", "Азия", "Австралия", "Антарктида", "Северная Америка", "Южная Америка", "Программная инженерия" };
        static string[] MONARCH = new string[] { "Карл III", "Фридрих VII", "Георгий V", "Франциск IV", "Эммануэль II", "Герман I", "Петр I", "Елизавета II", "Екатерина I", "Георг III", "Княгиня Ольга", "Владимир Мономах", "Александр I", "Иван II", "Иван Грозный", "Алексей Попович", "Добрыня Никитич", "Владимир IX", "Ульфрик I", "Талер I" };
        static string[] NAME = new string[] { "Великобритания", "Замбия", "Россия", "Уганда", "Китай", "Германия", "Франция", "Помпея", "Инженерия", "Эфиопия", "Румыния", "Норвегия", "Швейцария", "Монголия", "Польша", "Киргизия", "Армения", "Япония", "Казахстан", "Офис", "Утопия", "Украина", "Беларусь", "Италия", "Испания" };
        static string[] monarchyTypes = new string[] { "ограниченная монархия", "абсолютная монархия" };
        static string[] republicTypes = new string[] { "парламентарная", "президентская", "смешанная" };

        //Переменная для рандома
        private static readonly Random Rnd = new Random();

        //Создать массив
        public static StateInterface[] CreateArray(int size)
        {
            var state = new StateInterface[size];
            var i = 0;
            while (i < state.Length)
            {
                var check = Rnd.Next(1, 4);
                StateInterface currentState;
                if (check == 1)
                {
                    currentState = new Monarchy(monarchyTypes[Rnd.Next(0, monarchyTypes.Length)], NAME[Rnd.Next(0, NAME.Length)], Rnd.Next(277,833));
                }
                else
                {
                    if (check == 2)
                        currentState = new Kingdom(monarchyTypes[Rnd.Next(0, monarchyTypes.Length)], NAME[Rnd.Next(0, NAME.Length)], Rnd.Next(277, 833), MONARCH[Rnd.Next(0, MONARCH.Length)], CONTINENT[Rnd.Next(0, CONTINENT.Length)]);

                    else
                        currentState = new Republic(republicTypes[Rnd.Next(0, republicTypes.Length)], NAME[Rnd.Next(0, NAME.Length)], Rnd.Next(344, 966));

                }

                if (Contains(currentState, state))
                {
                }
                else
                {
                    state[i] = currentState;
                    i++;
                }
            }

            return state;
        }

        public static bool Contains(StateInterface element, StateInterface[] array)
        {
            foreach (var state in array)
            {
                if (state == null) return false;
                if (string.Compare(state.Return_GDP() + " " + state.Return_Name(), element.Return_GDP() + " " + element.Return_Name(), StringComparison.Ordinal) == 0)
                    return true;
            }

            return false;
        }

        public static StateInterface CreateElement<T>()
        {
            if (typeof(T) == typeof(Republic))
                return new Republic(republicTypes[Rnd.Next(0, republicTypes.Length)], NAME[Rnd.Next(0, NAME.Length)], Rnd.Next(344, 966));


            if (typeof(T) == typeof(Kingdom))
                return new Kingdom(monarchyTypes[Rnd.Next(0, monarchyTypes.Length)], NAME[Rnd.Next(0, NAME.Length)], Rnd.Next(277, 833), MONARCH[Rnd.Next(0, MONARCH.Length)], CONTINENT[Rnd.Next(0, CONTINENT.Length)]);


            return new Monarchy(monarchyTypes[Rnd.Next(0, monarchyTypes.Length)], NAME[Rnd.Next(0, NAME.Length)], Rnd.Next(277, 833));

        }

        public static void Show<T>(T element)
        {
            if (typeof(T) == typeof(Republic))
            {
                var republic = element as Republic;
                republic.Show();
            }
            else
            {
                if (typeof(T) == typeof(Kingdom))
                {
                    var kingdom = element as Kingdom;
                    kingdom.Show();
                }
                else
                {
                    var monarchy = element as Monarchy;
                    monarchy.Show();
                }
            }
        }
    }
}
