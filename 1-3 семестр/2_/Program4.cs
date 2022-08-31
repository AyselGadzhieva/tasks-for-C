using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {
            int N,i;
            double X;
            while (true)
            {
                Console.WriteLine("Введите Вещественное число X");
                while (!double.TryParse(Console.ReadLine(), out X))
                {
                    Console.WriteLine("Вы ввели не вещественное число, повторите");
                }
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите натуральное число N");
                while (!int.TryParse(Console.ReadLine(), out N))
                {
                    Console.WriteLine("Вы ввели не натуральное число, повторите");
                }
                {
                    if (N>0)
                    break;
                }
            }
            i = 1;
            do
            {
                Console.WriteLine(Math.Cos(Math.Pow(X, i)));
                i++;
            }
            while (i == N);

         Console.ReadKey();
            
        }
    }
}
