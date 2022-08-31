using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, r, S;
            string s;
            bool f;
            Console.WriteLine("Введите символ фигуры, площадь которой нужно найти (К - круг, Т - треугольник, О - прямоугольник)");
            s = Console.ReadLine();
            if (s == "К" || s == "Т" || s == "О")
            {
                if (s == "К")
                {
                    Console.WriteLine("Введите радиус");
                    s = Console.ReadLine();
                    f = double.TryParse(s, out r);
                    if (f == false)
                    {
                        Console.WriteLine("Вы ввели не число!");
                    }
                    else
                    {
                        if (r > 0)
                        {
                            Console.WriteLine($"Площадь круга равна {S = Math.PI * r * r}");
                        }
                        else
                        {
                            Console.WriteLine("Радиус не может быть отрицательным!");
                        }
                    }


                }
                if (s == "Т")
                {
                    Console.WriteLine("Введите длины сторон треугольника");
                    s = Console.ReadLine();
                    f = double.TryParse(s, out a);
                    if (f == false)
                    {
                        Console.WriteLine("Вы ввели не число!");
                    }
                    else
                    {
                        if (a <= 0)
                        {
                            Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                        }
                        else
                        {
                            s = Console.ReadLine();
                            f = double.TryParse(s, out b);
                            if (f == false)
                            {
                                Console.WriteLine("Вы ввели не число!");
                            }
                            else
                            {
                                if (b <= 0)
                                {
                                    Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                                }
                                else
                                {
                                    s = Console.ReadLine();
                                    f = double.TryParse(s, out c);
                                    if (f == false)
                                    {
                                        Console.WriteLine("Вы ввели не число!");
                                    }
                                    else
                                    {
                                        if (c <= 0)
                                        {
                                            Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                                        }
                                        else
                                        {
                                            if (a + b > c && b + c > a && a + c > b)
                                            {
                                                Console.WriteLine($"Площадь треугольника равна {S = Math.Sqrt((a + b + c) / 2 * ((a + b + c) / 2 - a) * ((a + b + c) / 2 - b) * ((a + b + c) / 2 - c))}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Треугольник не существует!");
                                            }
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
                if (s == "О")
                {
                    Console.WriteLine("Введите длины сторон прямоугольника");
                    s = Console.ReadLine();
                    f = double.TryParse(s, out a);
                    if (f == false)
                    {
                        Console.WriteLine("Вы ввели не число!");
                    }
                    else
                    {
                        if (a <= 0)
                        {
                            Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                        }
                        else
                        {
                            s = Console.ReadLine();
                            f = double.TryParse(s, out b);
                            if (f == false)
                            {
                                Console.WriteLine("Вы ввели не число!");
                            }
                            else
                            {
                                if (b <= 0)
                                {
                                    Console.WriteLine("Длина стороны не может быть отрицательной или равняться нулю!");
                                }
                                else
                                {
                                    Console.WriteLine($"Площадь прямоугольника равна {S = a * b}");
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не тот символ!");
            }
            Console.ReadKey();

        }
    }
}
