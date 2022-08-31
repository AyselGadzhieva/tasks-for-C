using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace _0_1
{
    class Program
    {
        static Random rnd = new Random();
        static int RND(int a, int b)
        {
            if (a > b) return rnd.Next(b, a + 1);
            else return rnd.Next(a, b + 1);
        }

        static double min(double a, double b, double c, double d)
        {
            double e, f;
            e = MIN(a, b);
            f = MIN(e, c);
            return MIN(f, d);
        }
        static double MIN(double a, double b)
        {
            return a >= b ? b : a;
        }

        static void output(int[] a)
        {
            Console.WriteLine();
            for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
        }

        static void sorting(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int e = i + 1; e < arr.Length; e++)
                {
                    if (arr[i] > arr[e])
                    {
                        int t = arr[i];
                        arr[i] = arr[e];
                        arr[e] = t;

                    }
                }
            }
        }

        static int Fibonachi(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;
            else return Fibonachi(n - 1) + Fibonachi(n - 2);
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            uint A;
            string s;
            bool b;
            while (true)
            {
                do
                {
                    Console.WriteLine(" \nВведите номер задания (1-16)");
                    s = Console.ReadLine();
                    b = uint.TryParse(s, out A);
                } while (b == false || A == 0 || A > 16);

                switch (A)
                {
                    case 1:
                        Console.WriteLine("Задание № 1 \nЧетные числа от 1 до 100 включительно:");
                        Console.ForegroundColor = ConsoleColor.Green;

                        for (int i = 1; i <= 100; i++) if (i % 2 == 0) Console.Write(i + "  ");

                        Console.ResetColor();
                        break;

                    case 2:
                        Console.WriteLine("\n\nЗадание № 2 \nПрямоугольник из восьмерок:");
                        uint A_int, B_int;
                        string s_string, s1_string;
                        bool b_bool, B_bool;

                        do
                        {
                            Console.WriteLine("Введите первую сторону прямоугольника");
                            s_string = Console.ReadLine();
                            b_bool = uint.TryParse(s_string, out A_int);

                            Console.WriteLine("Введите вторую сторону прямоугольника");
                            s_string = Console.ReadLine();
                            B_bool = uint.TryParse(s_string, out B_int);

                            if (b_bool == false || B_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.(Число должно быть целым положительным.)");
                            }

                        } while (b_bool == false || B_bool == false);

                        Console.ForegroundColor = ConsoleColor.Green;

                        for (uint i = A_int; i != 0; i--)
                        {
                            for (uint j = B_int; j != 0; j--) Console.Write("8 ");
                            Console.WriteLine();
                        }

                        Console.ResetColor();
                        break;

                    case 3:
                        Console.WriteLine("\n\nЗадание № 3 \nПрямоугольный треугольник из восьмёрок со сторонами 10 и 10:");
                        s_string = "8";

                        Console.ForegroundColor = ConsoleColor.Green;

                        for (int i = 10; i != 0; i--)
                        {
                            Console.WriteLine(s_string);
                            s_string += " 8";
                        }
                        Console.ResetColor();
                        break;

                    case 4:
                        Console.WriteLine("\n\nЗадание № 4 \nМинимальное число из двух чисел:");
                        double A_double, B_double;

                        do
                        {
                            Console.WriteLine("Введите первое число:");
                            s_string = Console.ReadLine();
                            b_bool = double.TryParse(s_string, out A_double);

                            Console.WriteLine("Введите второе число:");
                            s_string = Console.ReadLine();
                            B_bool = double.TryParse(s_string, out B_double);

                            if (b_bool == false || B_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                            }

                        } while (b_bool == false || B_bool == false);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Результат сравнения:" + MIN(A_double, B_double));
                        Console.ResetColor();
                        break;
                    case 5:
                        Console.WriteLine("\n\nЗадание № 5 \nСравнение имен:");
                        do
                        {
                            Console.WriteLine("Введите первое имя:");
                            s_string = Console.ReadLine();
                            b_bool = s_string.All(char.IsLetter);

                            Console.WriteLine("Введите второе имя:");
                            s1_string = Console.ReadLine();
                            B_bool = s1_string.All(char.IsLetter);

                            if (b_bool == false || B_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.(Имя не должно содержать цифр и других символов.)");
                            }
                        } while (b_bool == false || B_bool == false);
                        Console.ForegroundColor = ConsoleColor.Green;

                        if (s_string.Length == s1_string.Length)
                        {
                            if (s_string.Equals(s1_string)) Console.WriteLine("Имена идентичны");
                            else Console.WriteLine("Длины имен равны");
                        }
                        else Console.WriteLine("Имена разные");
                        Console.ResetColor();
                        break;
                    case 6:
                        Console.WriteLine("\n\nЗадание № 6 \nМинимальное число из четырех чисел:");
                        double C_double, D_double;
                        bool C_bool, D_bool;
                        do
                        {
                            Console.WriteLine("Введите первое число:");
                            s_string = Console.ReadLine();
                            b_bool = double.TryParse(s_string, out A_double);

                            Console.WriteLine("Введите второе число:");
                            s_string = Console.ReadLine();
                            B_bool = double.TryParse(s_string, out B_double);

                            Console.WriteLine("Введите третье число:");
                            s_string = Console.ReadLine();
                            C_bool = double.TryParse(s_string, out C_double);

                            Console.WriteLine("Введите четвертое число:");
                            s_string = Console.ReadLine();
                            D_bool = double.TryParse(s_string, out D_double);

                            if (b_bool == false || B_bool == false || C_bool == false || D_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                            }

                        } while (b_bool == false || B_bool == false || C_bool == false || D_bool == false);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Результат сравнения:" + min(A_double, B_double, C_double, D_double));
                        Console.ResetColor();
                        break;

                    case 7:
                        Console.WriteLine("\n\nЗадание № 7 \nЧетверть в которой находится точка:");
                        do
                        {
                            Console.WriteLine("Введите координаты точки: \nВведите Х:");
                            s_string = Console.ReadLine();
                            b_bool = double.TryParse(s_string, out A_double);

                            Console.WriteLine("Введите У:");
                            s_string = Console.ReadLine();
                            B_bool = double.TryParse(s_string, out B_double);

                            if (b_bool == false || B_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                            }

                        } while (b_bool == false || B_bool == false);

                        Console.ForegroundColor = ConsoleColor.Green;
                        if (A_double == 0 && B_double == 0) Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится в центре (на пересечение Х и У).");
                        else if (A_double > 0 && B_double == 0) Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится на ОХ.");
                        else if (A_double == 0 && B_double > 0) Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится на ОУ.");
                        else if (A_double > 0 && B_double > 0) Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится в 1 четверти.");
                        else if (A_double < 0 && B_double > 0) Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится в 2 четверти.");
                        else if (A_double < 0 && B_double < 0) Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится в 3 четверти.");
                        else Console.WriteLine("Точка с координатами (" + A_double + "," + B_double + ") находится в 4 четверти.");
                        Console.ResetColor();
                        break;

                    case 8:
                        Console.WriteLine("\n\nЗадание № 8 \nМассив из всех четных чисел от 2 до 20:");

                        int[] arr = new int[10];
                        int sum = 0;
                        Console.ForegroundColor = ConsoleColor.Green;

                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j] = sum += 2;
                            Console.Write(arr[j] + " ");

                        }
                        Console.WriteLine();

                        sum = 0;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j] = sum += 2;
                            Console.WriteLine("\n" + arr[j]);

                        }
                        Console.ResetColor();
                        break;

                    case 9:
                        Console.WriteLine("\n\nЗадание № 9 \nМассив из всех нечётных чисел от 1 до 99:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int[] arr1 = new int[50];
                        int sum1 = 1;

                        for (int i = 0; i < arr1.Length; i++)
                        {
                            arr1[i] = sum1;
                            Console.Write(arr1[i] + " ");
                            sum1 += 2;
                        }
                        Console.WriteLine();

                        for (int i = arr1.Length - 1; i >= 0; i--)
                        {
                            Console.Write(arr1[i] + " ");
                        }
                        Console.ResetColor();
                        break;

                    case 10:
                        Console.WriteLine("\n\nЗадание № 10 \nМассив из 15 случайных целых чисел из отрезка [0;9]");

                        Console.ForegroundColor = ConsoleColor.Green;
                        int[] arr2 = new int[15];

                        for (int i = 0; i <= arr2.Length - 1; i++)
                        {
                            arr2[i] = rnd.Next(1, 10);
                            Console.Write(arr2[i] + " ");
                        }

                        int ch = 0;
                        for (int i = 0; i <= arr2.Length - 1; i++) if (arr2[i] % 2 == 0) ch += 1;

                        Console.WriteLine("Количеств четных элементов в масиве:" + ch);
                        Console.ResetColor();
                        break;

                    case 11:
                        Console.WriteLine("\n\nЗадание № 11 \nДвумерный массив из 8 строк по 5 столбцов в каждой из случайных целых чисел из отрезка [10;99]");
                        int[,] arr3 = new int[8, 5];
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                arr3[i, j] = rnd.Next(10, 100);
                                Console.Write(arr3[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        Console.ResetColor();
                        break;

                    case 12:
                        Console.WriteLine("\n\nЗадание № 12 \nДвумерный массив из 7 строк по 4 столбца в каждой из случайных целых чисел из отрезка [-5;5]:");

                        Console.ForegroundColor = ConsoleColor.Green;
                        int[,] arr4 = new int[7, 4];
                        int[] arr5 = new int[7];

                        for (int i = 0; i < 7; i++)
                        {
                            int summ = 1;
                            for (int j = 0; j < 4; j++)
                            {
                                arr4[i, j] = rnd.Next(-5, 6);
                                Console.Write(arr4[i, j] + " ");
                                summ *= Math.Abs(arr4[i, j]);
                            }
                            arr5[i] = summ;
                            Console.WriteLine();
                        }

                        int max = arr5[0], index = 0;
                        for (int i = 0; i < arr5.Length; i++)
                        {
                            if (max < arr5[i])
                            {
                                max = arr5[i];
                                index = i;
                            }
                        }

                        index += 1;
                        int max1 = arr5.Max();
                        Console.WriteLine("В строке " + index + " наибольшое произведение чисел по модулю, которое равно: " + arr5[index - 1]);
                        Console.WriteLine("Перемноженые числа в строках по модулю равны:");
                        for (int i = 0; i < 7; i++) Console.WriteLine(arr5[i] + " ");
                        Console.ResetColor();
                        break;

                    case 13:
                        Console.WriteLine("\n\nЗадание № 13 \nМассив из 20 рандомных чисел из отрезка [a, b] ");
                        int b1;
                        int[] arr6 = new int[20];
                        do
                        {
                            Console.WriteLine("Введите a:");
                            s_string = Console.ReadLine();
                            b_bool = int.TryParse(s_string, out b1);
                            Console.WriteLine("Введите b:");
                            s_string = Console.ReadLine();
                            B_bool = int.TryParse(s_string, out ch);
                            if (b_bool == false || B_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                            }
                        } while (b_bool == false || B_bool == false);
                        Console.ForegroundColor = ConsoleColor.Green;

                        for (int i = 0; i < arr6.Length; i++)
                        {
                            arr6[i] = RND(b1, ch);
                            Console.Write(arr6[i] + " ");
                        }
                        Console.ResetColor();
                        break;

                    case 14:
                        Console.WriteLine("\n\nЗадание № 14 \nМетод, который выводит массивы на экран в строку.");

                        int[] arrey1 = new int[10];
                        int[] arrey2 = new int[10];
                        int[] arrey3 = new int[10];
                        int[] arrey4 = new int[10];
                        int[] arrey5 = new int[10];
                        int z, v;
                        do
                        {
                            Console.WriteLine("Введите дипазон чисел для заполнения массива a:");
                            s_string = Console.ReadLine();
                            b_bool = int.TryParse(s_string, out z);
                            Console.WriteLine("Введите b:");
                            s_string = Console.ReadLine();
                            B_bool = int.TryParse(s_string, out v);
                            if (b_bool == false || B_bool == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.( Числа должны быть целые)");
                            }
                        } while (b_bool == false || B_bool == false);

                        for (int i = 0; i < arrey1.Length; i++)
                        {
                            arrey1[i] = RND(z, v);
                            arrey2[i] = RND(z, v);
                            arrey3[i] = RND(z, v);
                            arrey4[i] = RND(z, v);
                            arrey5[i] = RND(z, v);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        output(arrey1); output(arrey2); output(arrey3); output(arrey4); output(arrey5);
                        Console.ResetColor();
                        break;

                    case 15:
                        Console.WriteLine("\n\nЗадание № 15 \nСортировка.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int[] arr7 = new int[15];
                        for (int i = 0; i < arr7.Length; i++)
                        {
                            arr7[i] = rnd.Next(1, 10);
                            Console.Write(arr7[i] + " ");
                        }
                        sorting(arr7);
                        output(arr7);
                        Console.ResetColor();
                        break;

                    case 16:
                        Console.WriteLine("\n\nЗадание № 16 \nФибоначчи.");
                        Stopwatch stopWatch = new Stopwatch();

                        for (int i = 0; ; i++)
                        {
                            stopWatch.Start();
                            Console.Write("Число фибоначи: " + Fibonachi(i) + ". Номер элемента: " + i);
                            Console.WriteLine();
                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours,
                            ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                            if (ts.Minutes >= 01)
                            {
                                Console.WriteLine("Число фиббоначи равно: " + Fibonachi(i) + ". Номер элемента: " + i + " время: " + elapsedTime); break;
                            }
                        }
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
