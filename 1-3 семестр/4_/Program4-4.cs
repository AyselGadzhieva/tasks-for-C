using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_4
{
    class Program
    {
        static void Sorting(string s, string s1, string s2, string s3)
        {
            string[] m = new string[4];

            m[0] = s;
            m[1] = s1;
            m[2] = s2;
            m[3] = s3;

            for (int i = 0; i < 4; i++)
            {
                for (int j = i; j < 4; j++)
                {
                    if (m[j].CompareTo(m[i]) < 0)
                    {
                        string temp = m[j];
                        m[j] = m[i];
                        m[i] = temp;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(m[i]);
            }
        }
        static void Main(string[] args)
        {
            string s, s1, s2, s3;

            Console.WriteLine("Введите 4 строки");
            s = Console.ReadLine();
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
            s3 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Отсортированные строки:");
            Sorting(s, s1, s2, s3);

            Console.ReadKey();
        }
    }
}
