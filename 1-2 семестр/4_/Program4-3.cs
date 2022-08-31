using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    class Program
    {
        public static void Main()
        {
            int N;
            string s1, s2;
            s1 = TryReadString("Введите первую строку:");
            s2 = TryReadString("Введите вторую строку:");
            N = TryReadInt("Введите целое число:");
            Console.WriteLine(StringToString(s1, s2, N));
            Console.ReadKey();
        }
        public static string TryReadString(string title)
        {
            string s;
            Console.WriteLine(title);

            while (true)
            {
                s = Console.ReadLine();
                if (s.Length > 0)
                {
                    break;
                }
                Console.WriteLine("Вывели пустую строку, повторите");
            }

            return s;
        }
        public static int TryReadInt (string title)
        {
            int v;
            Console.WriteLine(title);
            while (true)
            {
                while (!Int32.TryParse(Console.ReadLine(), out v))
                {
                    Console.WriteLine("Вы ввели не целое число, повторите");
                }
                return v;
            }
        }
        public static string StringToString(string c1, string c2, int n)
        {
            if (n <= c1.Length)
            {
                c1 = c1.Insert(n, c2);
                return c1;
            }
            else return "Число " + n + " больше длины строки!";
        }
    }
}
   



