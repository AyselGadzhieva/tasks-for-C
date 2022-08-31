using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3
{
    class Program
    {
        static void Main(string[] args)
        {
        
            int[] m1 = new int[10];
            int[] m2 = new int[10];
            int[] m3 = new int[10];

            Random r = new Random();

            //Заполнили массивы
            for (int i = 0; i < m1.Length; i++)
            {
                m1[i] = r.Next(-10, 10);
                m2[i] = r.Next(-10, 10);
            }


            Console.Write("1 массив: ");
            for (int i = 0; i < m1.Length; i++)
            {
                Console.Write(m1[i] + "\t");
            }

            Console.WriteLine();

            Console.Write("2 массив: ");
            for (int i = 0; i < m2.Length; i++)
            {
                Console.Write(m2[i] + "\t");
            }

            Console.WriteLine();

            for (int i = 0; i < m3.Length; i++)
            {
                m3[i] = m1[i] * m2[i];
            }

            Console.Write("3 массив: ");
            for (int i = 0; i < m3.Length; i++)
            {
                Console.Write(m3[i] + "\t");
            }

            Console.ReadKey();
        }
    }
}
