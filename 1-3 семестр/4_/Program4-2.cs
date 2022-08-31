using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class Program
    {
        public static void Main()
        {
            float x, y;
            x = TryReadFloat("Введите x : ");
            y = TryReadFloat("Введите y : ");
            Console.WriteLine("Расстояние от начала координат до точки, заданной числами X и Y = " + DisFPBP(x,y));
            Console.ReadKey();
        }
        public static float TryReadFloat(string title)
        {
            float v;
            Console.WriteLine(title);
            while (true)
            {
                while (!float.TryParse(Console.ReadLine(), out v))
                {
                    Console.WriteLine("Вы ввели не число, повторите");
                }
                return v;
            }
        }
            public static double DisFPBP (float x, float y)
            {
                double z;
                z =Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)));
            return z;
            }
    }
    }

