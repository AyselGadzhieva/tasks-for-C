using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a, b, c;
            string s;
            bool f;
            Console.WriteLine("Введите сторону a: ");
            s = Console.ReadLine();
            f = uint.TryParse(s, out a);
            if (f == false)
            {
                Console.WriteLine("Вы ввели ошибочно!");
            }
            else
            {
                if (a <= 0)
                    Console.WriteLine("Длина стороны не может быть отрицательной, либо равнятся нулю!");
                else
                {
                 Console.WriteLine("Длина стороны a = " + a);
                 Console.WriteLine("Введите сторону b: ");
                 s = Console.ReadLine();
                 f = uint.TryParse(s, out b);
                    if (f == false)
                    {
                        Console.WriteLine("Вы ввели ошибочно!");
                    }
                    else
                    {
                        if (b <= 0)
                            Console.WriteLine("Длина стороны не может быть отрицательной, либо равнятся нулю!");
                        else
                        {
                            Console.WriteLine("Длина стороны b = " + b);

                            Console.WriteLine("Введите сторону c: ");
                            s = Console.ReadLine();
                            f = uint.TryParse(s, out c);
                            if (f == false)
                            {
                                Console.WriteLine("Вы ввели ошибочно!");
                            }
                            else
                            {
                                if (c <= 0)
                                    Console.WriteLine("Длина стороны не может быть отрицательной, либо равнятся нулю!");
                                else
                                {
                                    Console.WriteLine("Длина стороны c = " + c);

                                    if (a == c && a == b && b == c)
                                    {
                                        Console.WriteLine("Треугольник равносторонний!");
                                    }
                                    else
                                    {
                                        if (a == b || b == c || c == a)
                                        {
                                            Console.WriteLine("Треугольник равнобедренный!");
                                        }
                                        else
                                        {
                                            if (a * a == b * b + c * c || b * b == c * c + a * a || c * c == a * a + b * b)
                                            {
                                                Console.WriteLine("Треугольник прямоугольный!");
                                            }
                                            else
                                            {
                                                if (a <= 0 || b <= 0 || c <= 0)
                                                    Console.WriteLine("Треугольник не существует!");
                                                else
                                                {
                                                    Console.WriteLine("Треугольник разносторонний!");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
