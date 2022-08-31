using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            double v,n;
            bool q;
            string s;
            Console.WriteLine("Дан треугольник abc. Введите длину стороны a: ");
            s = Console.ReadLine();
            q = int.TryParse(s, out a);
            if (q==false)
            {
                Console.WriteLine("Вы ввели ненатуральное число!");
            }
            else
            {
                if (a<=0)
                {
                    Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                }
                else
                Console.WriteLine("a = " + a);
            }
            Console.WriteLine("Дан треугольник abc. Введите длину стороны b: ");
            s = Console.ReadLine();
            q = int.TryParse(s, out b);
            if (q == false)
            {
                Console.WriteLine("Вы ввели ненатуральное число!");
            }
            else
            {
                if (b <= 0)
                {
                    Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                }
                else
                    Console.WriteLine("b = " + b);
            }
            Console.WriteLine("Дан треугольник abc. Введите длину стороны c: ");
            s = Console.ReadLine();
            q = int.TryParse(s, out c);
            if (q == false)
            {
                Console.WriteLine("Вы ввели ненатуральное число!");
            }
            else
            {
                if (c <= 0)
                {
                    Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                }
                else
                    Console.WriteLine("c = " + c);
            }
            if (a+b > c&&b + c > a && a + c > b)
            {
                Console.WriteLine("Треугольник существует");
                Console.WriteLine($"Его периметр равен: {n = a + b + c}, а площадь равна { v = Math.Sqrt(n / 2 * (n / 2 - a) * (n / 2 - b) * (n / 2 - c))}");
            }
            else
            {
                Console.WriteLine("Треугольник не существует!");
            }
            Console.ReadKey();
        }
    }
}
