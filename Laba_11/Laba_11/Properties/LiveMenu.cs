using System;
using SuperFunctions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu
{
    public class LiveMenu
    {
        public static int Check(string task, int max, int min)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(task);
            int choice = Functions.Choice(max, min, "Ошибка. Выберите пункт из меню:");
            Console.WriteLine();
            return choice;
        }

        public static int Menu(string headLine, params string[] paragraphs)
        {
            Console.Clear();
            Console.WriteLine(headLine);
            int paragraph = 0, x = 2, y = 2, oldParagraph = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < paragraphs.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + i);
                Console.Write(paragraphs[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldParagraph);
                Console.Write(paragraphs[oldParagraph] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + paragraph);
                Console.Write(paragraphs[paragraph]);

                oldParagraph = paragraph;

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        paragraph++;
                        break;
                    case ConsoleKey.UpArrow:
                        paragraph--;
                        break;
                    case ConsoleKey.Enter:
                        choice = true;
                        break;
                }
                if (paragraph >= paragraphs.Length)
                    paragraph = 0;
                else if (paragraph < 0)
                    paragraph = paragraphs.Length - 1;
                if (choice)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorVisible = true;
                    Console.Clear();
                    break;
                }
            }
            Console.Clear();
            Console.CursorVisible = true;
            return paragraph;
        }

        public static int Menu(int k, string headLine, params string[] pechat)
        {
            Console.Clear();
            Console.WriteLine(headLine);
            int tek = 0, x = 2, y = 2, tekold = 0;
            Console.CursorVisible = false;
            var ok = false;
            for (var i = 0; i < pechat.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (i % (k + 1) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write(pechat[i]);
            }

    ;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + tekold);
                Console.Write(pechat[tekold] + " ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + tek);
                Console.Write(pechat[tek]);
                tekold = tek;
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        tek += k + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        tek -= k + 1;
                        break;
                    case ConsoleKey.Enter:
                        ok = true;
                        break;
                }

                if (tek >= pechat.Length)
                    tek = 0;
                else if (tek < 0)
                    tek = pechat.Length - 1;
            } while (!ok);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return tek + 1;
        }
    }
}
