using System;

namespace ConsoleApp1
{
    class Program
    {
        delegate double Zadanie1(double x);
        delegate double correlationCoefficient(double[] x, double[] y);
        delegate double Integration(double a, double b, int n, Zadanie1 function);
        delegate int Zadanie2(int x);
        static double Sred(double[] z)
        {
            double sum = 0;
            for (int i = 0; i < z.Length; i++)
                sum += z[i];
            return sum / z.Length;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double a;
            int q, com = 1;
            uint A;
            string s;
            bool b;
            while (true)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" \nВведите номер задания (1-5)");
                    s = Console.ReadLine();
                    b = uint.TryParse(s, out A);
                    Console.ResetColor();
                } while (b == false || A == 0 || A > 5);
                switch (A)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Первое задание ~");
                        Console.WriteLine("Нужно решить одну из двух задач в зависимости от значения x");
                        Console.WriteLine("Введите x:");
                        while (!double.TryParse(Console.ReadLine(), out a)) ;
                        Zadanie1 tanandpow = x => x < 1 ? Math.Tan(2 * x) : Math.Pow((2 * x + 10), 3);
                        Console.WriteLine(tanandpow(a));
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Второе задание ~");
                        Console.WriteLine("Введите x:");
                        while (!int.TryParse(Console.ReadLine(), out q)) ;
                        Zadanie2 plussiz = x =>
                        {
                            for (int i = 0; i < x; i++)
                            { if ((i % 2 == 0) && (i != 0)) com *= i; }
                            return x * x * com;
                        };
                        Console.WriteLine(plussiz(q));
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Третье задание ~");
                        Console.WriteLine("Нужно решить одну из трёх задач в зависимости от значения x");
                        Console.WriteLine("Введите x:");
                        while (!double.TryParse(Console.ReadLine(), out a)) ;
                        Zadanie1 sinandsqrt = x => x >= 0 ? (1 / x) : x < -7 ? (-3 * Math.Sin(2 * x)) : Math.Sqrt(Math.Pow(x, 3) - 5);
                        Console.WriteLine(sinandsqrt(a));
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Четвёртое задание ~");
                        Zadanie1 firstFunc = x => 3 * x - Math.Sin(2 * x);
                        Zadanie1 secondFunc = x => Math.Exp(-2 * x) - 2 * x + 1;
                        Integration rectangleMethod = (a1, b1, n, integrand) =>
                        {
                            double h1 = (b1 - a1) / n;
                            double sum = 0;
                            for (int i = 0; i <= n - 1; i++)
                            {
                                sum += integrand(a1 + i * h1);
                            }
                            return h1 * sum;
                        };
                        Console.WriteLine("Введите количество интервалов разбиения, n:");
                        int n0;
                        while (!int.TryParse(Console.ReadLine(), out n0)) ;
                        Console.WriteLine("Ответ: " + (rectangleMethod(0, 2 * Math.PI, n0, firstFunc) - rectangleMethod(0, Math.PI, n0, secondFunc)));
                        break;
                    case 5:
                        Console.WriteLine("Пятое задание ~");
                        Console.WriteLine("Введите n:");
                        while (!int.TryParse(Console.ReadLine(), out q)) ;

                        double[] array_X = new double[q];
                        double[] array_Y = new double[q];

                        correlationCoefficient R = (xA,yA) =>
                        {
                            int n = xA.Length;
                            double sampleMean_X, sampleMean_Y;
                            double sumNumerator = 0;
                            double sumDenominator1 = 0, sumDenominator2 = 0;
                            for (int i = 0; i < n; i++)
                            {
                                xA[i] = rnd.NextDouble();
                                yA[i] = rnd.NextDouble();
                            }
                            sampleMean_X = Sred(xA) / n;
                            sampleMean_Y = Sred(yA) / n;
                            for (int i = 0; i < n; i++)
                            {
                                sumNumerator += (xA[i] - sampleMean_X) * (yA[i] - sampleMean_Y);
                                sumDenominator1 += Math.Pow(xA[i] - sampleMean_X, 2);
                                sumDenominator2 += Math.Pow(yA[i] - sampleMean_Y, 2);
                            }
                            return sumNumerator / Math.Sqrt(sumDenominator1 * sumDenominator2);
                        };
                        Console.WriteLine("Введите размер выборки");
                        Console.WriteLine("R = " + R(array_X, array_Y));
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
