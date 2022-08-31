using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 6 цифр с вашего билета: ");
            int[] nomer = new int[6];
            nomer[0] = int.Parse(Console.ReadLine());
            nomer[1] = int.Parse(Console.ReadLine());
            nomer[2] = int.Parse(Console.ReadLine());
            nomer[3] = int.Parse(Console.ReadLine());
            nomer[4] = int.Parse(Console.ReadLine());
            nomer[5] = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int[] nomer1 = { nomer[0], nomer[1], nomer[2] };
            foreach (int i in nomer1)
                sum1 += i;
            Console.WriteLine("Сумма первых 3 цифр = {0}", sum1);

            int sum2 = 0;
            int[] nomer2 = { nomer[3], nomer[4], nomer[5] };
            foreach (int j in nomer2)
                sum2 += j;
            Console.WriteLine("Сумма вторых 3 цифр = {0}", sum2);

            if (sum1 == sum2)
                Console.WriteLine("Билет счастливый!");
            else
                Console.WriteLine("Билет не счастливый.");

            Console.ReadKey();
        }
    }
}
