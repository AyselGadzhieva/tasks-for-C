using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] m = new int[20];
            Random r = new Random();

            for (int u = 0; u < m.Length; u++)
            {

                m[u] = r.Next(1, 21);
            }

            for (int i = 0; i < m.Length - 1; i++)
            {
                for (int e = i + 1; e < m.Length; e++)
                {
                    if (m[i] > m[e])
                    {
                        int t = m[i];
                        m[i] = m[e];
                        m[e] = t;

                    }
                }
            }

            for (int i = 0; i < m.Length; i++)
            {
                Console.Write(m[i] + " ");

            }
            Console.WriteLine();
            Console.WriteLine();

            bool b;
            int x;
            string s;

            Console.WriteLine("Введите х");
            s = Console.ReadLine();
            b = int.TryParse(s, out x);

            if (b == false)
            {
                Console.WriteLine("Вы ввели не целое число");
            }
            else
            {
                int mid = m.Length / 2;
                int l = 0;
                int p = 19;


                while (m[mid] != x && ( p - l ) > 2 )

                {
                    mid = (p + l) / 2;
                    if (x < m[mid])
                    {
                        p = mid;

                    }
                   else if( x > m[mid])
                    {
                        l = mid; 
                    }

                }


                if (m[mid] == x)
                {
                    Console.WriteLine(" х находится на позиции " + (mid + 1));
                }
                else if (m[p] == x)
                {
                    Console.WriteLine(" х находится на позиции " + (p + 1));
                }
                else if (m[l] == x)
                {
                    Console.WriteLine(" х находится на позиции " + (l + 1));
                }
                else 
                {
                    Console.WriteLine("Этого числа нет в массиве ");
                }

            }

            Console.ReadKey();
        }
    }
}
