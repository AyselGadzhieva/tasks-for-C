using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] mas = new char[20];

            Console.WriteLine("Введите 20 символов:");

            for (int i = 0; i < mas.Length; i++)
            {
                string s = "";

                while (s.Length != 1)
                {
                    Console.WriteLine("Введите " + (i + 1) + " символ");
                    s = Console.ReadLine();

                    if (s.Length == 1)
                    {
                        if (s[0] < 'a' || s[0] > 'z')
                        {
                            Console.WriteLine("Введите букву от a до z");
                            s = "";
                        } else
                        {
                            mas[i] = s[0];
                        }
                    }
                }
            }

            int summ = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");

                if (mas[i] == 'x')
                {
                    summ++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("В данной строке " + summ +" x");

            Console.ReadKey();
        }
    }
}
