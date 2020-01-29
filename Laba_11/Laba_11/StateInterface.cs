using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    public interface StateInterface : IComparable
    {
        string Name { get; set; }

        double GDP { get; }

        string Type { get; set; }

        string Return_Name();

        string Return_GDP();

        void Input(); //метод ввода

        void Show(); //метод вывода

        new int CompareTo(object other); //сравнение
    }
}
