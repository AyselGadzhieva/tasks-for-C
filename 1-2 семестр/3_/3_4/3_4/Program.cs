using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine( "Матрица ");


            int[ , ] m = new int[5, 5];

            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                for ( int j = 0; j < 5; j++)
                {
                    m[i, j] = r.Next(0, 9) ;

                    Console.Write(m[i, j]+ " ");

                }
                Console.WriteLine();


            }
            Console.WriteLine();
            Console.WriteLine("Транспонированная матрица ");

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {

                    Console.Write(m[i, j] + " ");

                }
                Console.WriteLine();
                

            }



            Console.ReadKey();
        }
    }
}
