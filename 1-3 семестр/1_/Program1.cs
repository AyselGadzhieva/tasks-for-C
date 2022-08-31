using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            string s;
            bool f;
            Console.WriteLine("Введите число");
            s = Console.ReadLine();
            f = double.TryParse(s, out x);
            y = Math.Floor(x);
            if (x > 0 && x == y)
            {
                Console.WriteLine("Число натуральное");
            }
            else
            {
                Console.WriteLine("Это не натуральное число");
            }
            Console.ReadKey();
        }
    }
}
