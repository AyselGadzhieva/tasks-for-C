using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\ny/x |   1\t2\t3\t4\t5\t6\t7\t8\t9\t10");
            Console.Write("----------------------------------------------------------------------------------");
            Console.WriteLine();
            for (int i = 2; i < 11; i++)
            {
                Console.Write(i + "   |  ");
                for (int j = 1; j < 11; j++)
                {
                    Console.Write("\t" + i * j);
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
