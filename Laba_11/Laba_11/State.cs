using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba_11
{
    abstract class State : StateInterface, IComparable
    {
        public string name;
        public string type;
        public double gdp;
        public string t;
        Random rand = new Random();
        public static int counter = 0;

        //public static double totalGDP;
        public string Name //State name
        {
            get { return name; }
            set { name = value; }
        }
        public double GDP //Gross Domestic Product (n billion usd)
        {
            get { return gdp; }
            set
            {
                if ((value > 100) && (value < 999)) gdp = value;
                else gdp = rand.Next(100, 999);
            }
        }
        //public string Type //State type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}
        public string Type
        {
            get { return type; }
            set
            {
                if ((value == "монархия") || (value == "республика")) type = value;
                else type = "монархия";
            }
        }

        public State(string name)
        {
            this.name = name;
            counter++;
        }
        public State()
        {
            this.name = "";
            counter++;
        }
        virtual public void Show()
        {
            Console.WriteLine("Государство: " + name);
        }

        public string GetName
        {
            get { return name; }
        }

        public string GetGDP
        {
            get { return Convert.ToString(gdp); }
        }

        public new string GetType //new для сохранения имени
        {
            get { return type; }
        }

        public string Return_Name()
        {
            return name;
        }

        public string Return_GDP()
        {
            return Convert.ToString(gdp);
        }

        //Ввод
        abstract public void Input();

        public int CompareTo(object other)
        {
            State state = other as State;
            return String.Compare(GetGDP, state.GetGDP);

            //return string.Compare(GetName + " " + GetType, state.GetType + " " + state.GetName);
            //return String.Compare(GetName + " " + GetGDP, state.GetGDP + " " + state.GetName);
        }

    }
}
