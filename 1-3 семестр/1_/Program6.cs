using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;                             
            Console.Write("введите число: ");
            a= Console.Read();
 
            if (a % 2==1)
            {
                Console.WriteLine("число нечетное");
           
            }
            else
            {
                Console.WriteLine("Число четное");
            }
 
 
 
            Console.ReadKey();
        }
    }
}
