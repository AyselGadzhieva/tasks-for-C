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
            uint a;
            uint A;
            string s;
            bool b;
            Cow[] warrior = new Cow[4];
            warrior[0] = new Cow();
            warrior[1] = new Whale();
            warrior[2] = new Bird();
            warrior[3] = new Lamp();
            while (true)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" \nВведите номер задания (1-4)");
                    s = Console.ReadLine();
                    b = uint.TryParse(s, out A);
                    Console.ResetColor();
                } while (b == false || A == 0 || A > 4);
                switch (A)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("2 класса (Cow и Whale) определены!");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.WriteLine("\nGetName в классе Cow");
                        warrior[0].GetName();
                        Console.WriteLine("\nGetName в классе Whale");
                        warrior[1].GetName();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        GetName(warrior[0]);
                        GetName(warrior[1]);
                        GetName(warrior[2]);
                        GetName(warrior[3]);
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Cat[] army = new Cat[4];
                        Console.WriteLine("\nСоздание 2-х представителей класса Cat");
                        army[0] = new Cat();
                        army[1] = new Cat();
                        if (army[0].logical_gender != army[1].logical_gender)
                        {
                            Console.WriteLine("\nОни могут иметь потомство");
                            if (army[0].logical_gender == 'ж')
                            {
                                army[0].GetChild();
                            }
                            else
                            { army[1].GetChild(); }
                        }
                        else { Console.WriteLine("\nУ них не может быть потомства! :("); }
                        Console.WriteLine("\n\nСоздание 2-х представителей класса Dog");
                        army[2] = new Dog();
                        army[3] = new Dog();
                        if (army[2].logical_gender != army[3].logical_gender)
                        {
                            Console.WriteLine("\nОни могут иметь потомство");
                            if (army[2].logical_gender == 'ж')
                            {
                                army[2].GetChild();
                            }
                            else
                            { army[3].GetChild(); }
                        }
                        else
                        { Console.WriteLine("\nУ них не может быть потомства! :("); }
                        Console.WriteLine();
                        Console.WriteLine("\nХотите поменять пол животному? ([Д]-Да, [Н]-Нет)");
                        string selection = Console.ReadLine();
                        switch (selection)
                        {
                            case "Д":
                                Console.WriteLine("\nКакому животному вы хотите поменять пол? Внимание! Введите номер животного! (от 0 до 3 — По иерархии создания представителей класса)!");
                                while (!uint.TryParse(Console.ReadLine(), out a) || a >= 4) ;
                                if (army[a].logical_gender == 'м')
                                    army[a].logical_gender = 'ж';
                                else
                                    army[a].logical_gender = 'м';
                                break;
                            case "Н":
                                Console.WriteLine("\nПол не был изменён! :(");
                                break;
                            default:
                                Console.WriteLine("\nВы нажали неизвестную букву");
                                break;
                        }
                        Console.ResetColor();
                        break;
                }
            }
        }
        static public void GetName(Object o)
        {
            if (o.GetType().Name == "Cow")
            {
                Console.WriteLine("Корова");
            }
            if (o.GetType().Name == "Whale")
            {
                Console.WriteLine("Кит");
            }
            if (o.GetType().Name == "Bird")
            {
                Console.WriteLine("Птица");
            }
            if (o.GetType().Name == "Lamp")
            {
                Console.WriteLine("Лампа");
            }
        }
        static void Print(int a)
        {
            Console.WriteLine(a + " - это целое число");
        }
        static void Print(string a)
        {
            Console.WriteLine(a + " - это строка");
        }
        static void Print(string a, int b)
        {
            Console.WriteLine($"{a} - это строка, {b} - это целое число");
        }
        static void Print(int a, string b)
        {
            Console.WriteLine($"{a} - это целое число, {b} - это строка");
        }
        static void Print(ref double a)
        {
            Console.WriteLine(a + " - это вещественное число");
        }
    }
    class Cow
    {
        public virtual void GetName()
        {
            Console.WriteLine("Я являюсь животным отряда парнокопытных — коровой");
        }
    }
    class Whale : Cow
    {
        public override void GetName()
        {
            Console.WriteLine("Я не являюсь животным отряда парнокопытных — коровой.А являюсь морским млекопитающим из отряда китообразных — белухой(китом)");
        }
    }
    class Cat
    {
        public char logical_gender;
        protected string name;
        public Cat()
        {
            Console.WriteLine("Введите имя животного:");
            name = Console.ReadLine();
            Console.WriteLine("Введите пол животного ( Внимание! вводится либо[м], либо[ж])");
            while (!char.TryParse(Console.ReadLine(), out logical_gender) || (logical_gender != 'ж' && logical_gender != 'м')) ;
        }
        public Cat(int a)
        {
            Console.WriteLine("Введите имя животного:");
            name = Console.ReadLine();
            if (a == 1)
            {
                Console.WriteLine("Потоство женского пола");
                logical_gender = 'ж';
            }
            else
            {
                Console.WriteLine("Потоство мужского пола");
                logical_gender = 'м';
            }
        }
        public virtual Cat GetChild()
        {
            Random a = new Random();
            return new Cat(a.Next(0, 2));
        }
        public string Name { get { return name; } set { name = value; } }
    }
    class Dog : Cat
    {
        public Dog() { }
        public Dog(int a) : base(a)
        {
        }
        public override Cat GetChild()
        {
            Random b = new Random();
            return new Dog(b.Next(0, 2));
        }
    }
    class Bird : Cow
    {
    }
    class Lamp : Cow
    {
    }
    class MaximumMinimum
    {
        public static int Min(int a, int b)
        {
            if (a < b)
                return a;
            else return b;
        }
        public static long Min(long a, long b)
        {
            if (a < b)
                return a;
            else return b;
        }
        public static double Min(double a, double b)
        {
            if (a < b)
                return a;
            else return b;
        }
        public static int Max(int a, int b)
        {
            if (a > b)
                return a;
            else return b;
        }
        public static long Max(long a, long b)
        {
            if (a > b)
                return a;
            else return b;
        }
        public static double Max(double a, double b)
        {
            if (a > b)
                return a;
            else return b;
        }
    }
}