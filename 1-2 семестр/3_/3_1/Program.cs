using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] m = new int[20];
            Random rnd = new Random();

            for (int i = 0; i < m.Length; i++)
            {
                m[i] = rnd.Next(-10, 10);
            }

            //Распечатать массив через цикл
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write(m[i] + " ");
            }

            Console.WriteLine();

            int summ = 0;
            for (int i = 0; i < m.Length; i++)
            {
                if( m[i] > 0 )
                {
                    summ = summ + 1;
                }
            }

            Console.Write("Положительных чисел: " + summ);
            Console.ReadKey();
        }
    }
}
