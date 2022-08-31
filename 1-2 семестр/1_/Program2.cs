using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1, x2, x3, x4;
            double y1, y2, y3, y4;
            int k;
            bool b;
            string s;
            Console.WriteLine("Введите значение степени (k): ");
            s = Console.ReadLine();
            b = int.TryParse(s, out k);
            if (b == false)
            {
                Console.WriteLine("Вы ввели не число!");
            }
            else
            {

                Console.WriteLine("Степень числа: " + k);
                Console.WriteLine("Введите значение x1: ");
                s = Console.ReadLine();
                b = double.TryParse(s, out x1);
                if (b == false)
                {
                    Console.WriteLine("Вы ввели неподходящее значение!");
                }
                else
                {
                    Console.WriteLine("x1 равно: " + x1);
                    Console.WriteLine("Введите значение x2: ");
                    s = Console.ReadLine();
                    b = double.TryParse(s, out x2);
                    if (b == false)
                    {
                        Console.WriteLine("Вы ввели неподходящее значение!");
                    }
                    else
                    {
                        Console.WriteLine("x2 равно: " + x2);

                        Console.WriteLine("Введите значение x3: ");
                        s = Console.ReadLine();
                        b = double.TryParse(s, out x3);
                        if (b == false)
                        {
                            Console.WriteLine("Вы ввели неподходящее значение!");
                        }
                        else
                        {
                            Console.WriteLine("x3 равно: " + x3);

                            Console.WriteLine("Введите значение x4: ");
                            s = Console.ReadLine();
                            b = double.TryParse(s, out x4);
                            if (b == false)
                            {
                                Console.WriteLine("Вы ввели неподходящее значение!");
                            }
                            else
                            {
                                Console.WriteLine("x4 равно: " + x4);

                                Console.WriteLine($"y1= {y1 = Math.Pow(x1, k)}, y2 = {y2 = Math.Pow(x2, k)}, y3 = {y3 = Math.Pow(x3, k)}, y4 = {y4 = Math.Pow(x4, k)}");
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
        }
    }
}
