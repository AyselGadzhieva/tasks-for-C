using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_51
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] m = new int[10];

            for (int u = 0 ; u < m.Length  ; u++)
            {
                bool b;
                int a;

                do
                {
                    Console.WriteLine(" Введите целое число " + (u + 1) + ":" );
                    string s = Console.ReadLine();
                    b = int.TryParse(s, out a);
                } while (b == false);

                m[u] = a;
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


            Console.ReadKey();
        }
    }
}
