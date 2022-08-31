using System;
using System.Diagnostics;

namespace _0_1
{
    class Program
    {
        public static string TryReadString(string title)
        {
            string s;
            Console.WriteLine(title);
            while (true)
            {
                s = Console.ReadLine();
                if (s.Length > 0)
                {break;}
                Console.WriteLine("Вывели пустую строку, повторите");
            }
            return s;
        }
        public static double Compare(double x, double y)
        {
            double m;
            m = Math.Min(x, y);
            return m;
        }
        static Random rnd = new Random();
        static int RND(int a, int b)
        {
            if (a > b) return rnd.Next(b, a + 1);
            else return rnd.Next(a, b + 1);
        }

        static double min(double a, double b,double c, double d)
        {
            double e, f;
            e = Compare(a, b);
            f = Compare(e, c);
            return Compare(f, d);
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
        public static int TryReadInt(string title)
        {
            int v;
            Console.WriteLine(title);
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out v))
                {
                    Console.WriteLine("Вы ввели не целое число (или строку), повторите ввод: ");
                }
                return v;
            }
        }
        public static double TryReadDouble(string title)
        {
            double v;
            Console.WriteLine(title);
            while (true)
            {
                while (!double.TryParse(Console.ReadLine(), out v))
                {
                    Console.WriteLine("Вы ввели не целое число (или строку), повторите ввод: ");
                }
                return v;
            }
        }
        static void Main(string[] args)
        {
            string s_string, s1_string;
            double x, y, k, t;
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
                        for (int i = 2; i <= 100; i += 2)
                        {
                            Console.Write(i + " ");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nЗадание № 2 \nПрямоугольник из восьмерок:");
                        int m, n;
                        m = TryReadInt("Введите m: ");
                        n = TryReadInt("Введите n: ");
                        for (int a = 0; a < m; a++)
                        {
                            for (int g = 0; g < n; g++)
                            {
                                Console.Write("8");
                            }

                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nЗадание № 3 \nПрямоугольный треугольник из восьмёрок со сторонами 10 и 10:");
                        s_string = "8";
                        for (int i = 10; i != 0; i--)
                        {
                            Console.WriteLine(s_string);
                            s_string += " 8";
                        }
                        break;

                    case 4:
                        Console.WriteLine("\nЗадание № 4 \nМинимальное число из двух чисел:");
                        x = TryReadDouble("Введите x: ");
                        y = TryReadDouble("Введите y: ");
                        Console.WriteLine("Минимальное из чисел = " + Compare(x, y));
                        break;

                    case 5:
                        Console.WriteLine("\nЗадание № 5 \nСравнение имен:");
                        s_string = TryReadString("Введите первое имя:");
                        s1_string= TryReadString("Введите второе имя:");

                        if (s_string == s1_string)
                            Console.WriteLine("Имена идентичны");

                        else if (s_string.Length == s1_string.Length)
                            Console.WriteLine("Длины имен равны");
                        break;

                    case 6:
                        Console.WriteLine("\nЗадание № 6 \nМинимальное число из четырех чисел:");
                            x = TryReadDouble("Введите первое число: ");
                            y = TryReadDouble("Введите второе число: ");
                            k = TryReadDouble("Введите третье число: ");
                            t = TryReadDouble("Введите четвертое число: ");

                        Console.WriteLine("Результат сравнения:" + min(x, y, k, t));
                        Console.ResetColor();
                        break;

                    case 7:
                        Console.WriteLine("\nЗадание № 7 \nЧетверть в которой находится точка:");
                        x = TryReadDouble("Введите первое число: ");
                        y = TryReadDouble("Введите второе число: ");

                        if (x == 0 && y == 0) Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится в центре (на пересечение Х и У).");
                        else if (x > 0 && y == 0) Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится на ОХ.");
                        else if (x == 0 && y > 0) Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится на ОУ.");
                        else if (x > 0 && y > 0) Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится в 1 четверти.");
                        else if (x < 0 && y > 0) Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится в 2 четверти.");
                        else if (x < 0 && y < 0) Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится в 3 четверти.");
                        else Console.WriteLine("Точка с координатами (" + x + "," + y + ") находится в 4 четверти.");
                        break;

                    case 8:
                        Console.WriteLine("\nЗадание № 8 \nМассив из всех четных чисел от 2 до 20:");

                        int[] a1 = new int[10];
                        int i1 = 0;
                        int b0 = 2;
                        while (i1 < 10)
                        {
                            a1[i1] = b0;
                            b0 += 2;
                            i1++;
                        }
                        //Вывод в строку
                        for (i1 = 0; i1 < 10; i1++)
                        { Console.Write(a1[i1] + " "); }
                        Console.WriteLine();
                        //Вывод в столбик
                        for (i1 = 0; i1 < 10; i1++)
                        { Console.WriteLine(a1[i1] + " "); }
                        break;

                    case 9:
                        Console.WriteLine("\nЗадание № 9 \nМассив из всех нечётных чисел от 1 до 99:");
                        //В переменной а будет храниться значение размера массива, которое мы получим с помощью простого цикла
                        int p = 0;
                        for (int i = 1; i <= 99; i++)
                        {
                            if (i % 2 != 0) p++;
                        }
                        //Создадим массив, и используя цикл, заполним его ячейки. Сразу выведем на экран значения элементов массива в строку
                        int[] Mas = new int[p];
                        for (int i = 1, q = 0; i <= 99; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Mas[q] = i;
                                Console.Write(Mas[q] + " ");
                                q++;
                            }
                        }
                        Console.WriteLine();
                        for (int j = p - 1; j >= 0; j--)
                        {
                            Console.Write(Mas[j] + " ");
                        }
                        break;

                    case 10:
                        Console.WriteLine("\nЗадание № 10 \nМассив из 15 случайных целых чисел из отрезка [0;9]");
                        int[] arr2 = new int[15];
                        for (int i = 0; i < arr2.Length; i++)
                        {
                            arr2[i] = rnd.Next(0, 10);
                            Console.Write(arr2[i] + " ");
                        }
                        int ch = 0;
                        for (int i = 0; i <= arr2.Length - 1; i++) if (arr2[i] % 2 == 0) ch += 1;
                        Console.WriteLine("Количеств четных элементов в масиве:" + ch);
                        break;

                    case 11:
                        Console.WriteLine("\nЗадание № 11 \nДвумерный массив из 8 строк по 5 столбцов в каждой из случайных целых чисел из отрезка [10;99]");
                        int[,] arr3 = new int[8, 5];
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                arr3[i, j] = rnd.Next(10, 100);
                                Console.Write(arr3[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 12:
                        Console.WriteLine("\nЗадание № 12 \nДвумерный массив из 7 строк по 4 столбца в каждой из случайных целых чисел из отрезка [-5;5]:");
                        int[,] arr4 = new int[7, 4];
                        int[] arr5 = new int[arr4.Length];
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                arr4[i, j] = rnd.Next(-5, 6);
                                Console.Write(arr4[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        for (int i = 0; i < 7; i++)
                        {
                            arr5[i] = Math.Abs(arr4[i, 0] * arr4[i, 1] * arr4[i, 2] * arr4[i, 3]);
                            Console.WriteLine(arr5[i] + " ");
                        }
                        int max = 0, max_i = 0;
                        for (int i = 0; i < 7; i++)
                        {
                            if ((arr5[i]) > max)
                            {
                                max = arr5[i];
                                max_i = i;
                            }
                        }
                        max_i++;
                        Console.WriteLine("Строка с наибольшим по модулю произведением элементов (" + max + ") имеет индекс - " + max_i);
                        break;

                    case 13:
                        Console.WriteLine("\nЗадание № 13 \nМассив из 20 рандомных чисел из отрезка [a, b] ");
                        int b1, a2;
                        int[] arr6 = new int[20];
                        a2 = TryReadInt("Введите a: ");
                        b1 = TryReadInt("Введите b: ");

                        for (int i = 0; i < arr6.Length; i++)
                        {
                            arr6[i] = RND(b1, a2);
                            Console.Write(arr6[i] + " ");
                        }
                        break;

                    case 14:
                        Console.WriteLine("\nЗадание № 14 \nМетод, который выводит массивы на экран в строку.");

                        int[] arrey1 = new int[10];
                        int[] arrey2 = new int[10];
                        int[] arrey3 = new int[10];
                        int[] arrey4 = new int[10];
                        int[] arrey5 = new int[10];
                        int z, v;
                        z = TryReadInt("Введите a: ");
                        v = TryReadInt("Введите b: ");

                        for (int i = 0; i < arrey1.Length; i++)
                        {
                            arrey1[i] = RND(z, v);
                            arrey2[i] = RND(z, v);
                            arrey3[i] = RND(z, v);
                            arrey4[i] = RND(z, v);
                            arrey5[i] = RND(z, v);
                        }
                        output(arrey1); output(arrey2); output(arrey3); output(arrey4); output(arrey5);
                        break;

                    case 15:
                        Console.WriteLine("\nЗадание № 15 \nСортировка.");
                        int[] arr7 = new int[15];
                        for (int i = 0; i < arr7.Length; i++)
                        {
                            arr7[i] = rnd.Next(0, 11);
                            Console.Write(arr7[i] + " ");
                        }
                        sorting(arr7);
                        output(arr7);
                        break;

                    case 16:
                        Console.WriteLine("\nЗадание № 16 \nФибоначчи.");
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
