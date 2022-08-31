using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5
{
    class Program
    {
        static void Main(string[] args)
        {

            uint A;
            string s;
            bool b;
            while (true)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" \nВведите номер задания (только 4 задания ¯|_(ツ)_/¯)");
                    s = Console.ReadLine();
                    b = uint.TryParse(s, out A);
                    Console.ResetColor();
                } while (b == false || A == 0 || A > 4);
                switch (A)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("                                              ~~~ Абстрактный класс создан ~~~                                          ");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nСоздаём питомцев!Урааа");
                        Console.WriteLine("\nЗмею!");
                        Snake sk = new Snake();
                        sk.Voice();
                        Console.WriteLine("\nСобаку!");
                        Dog dg = new Dog();
                        dg.Voice();
                        Console.WriteLine("\nСторожевую собаку!");
                        PatrolDog pd = new PatrolDog();
                        pd.Voice();
                        Console.WriteLine("\nКошку!");
                        Cat ct = new Cat();
                        ct.Voice();
                        Console.WriteLine("\nРыбу!");
                        Fish fh = new Fish();
                        fh.Voice();
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
    abstract class Pet
    {
        public string name;
        public short age;
        public string hungry;
        public string Name { get; set; }
        public Pet()
        {
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            while (!short.TryParse(Console.ReadLine(), out age) || age < 0);
            Console.WriteLine("Будете кормить питомца? Напишите да, если хотите его покормить");
            hungry = Console.ReadLine();
        }
        public abstract void Voice();
    }
    class Snake : Pet {
        public override void Voice()
        {
            Console.WriteLine("ShShSh — ShShSh — ShShSh");
        }
        public virtual void WillEat()
        {
        }
    }
    class Dog : Pet {
        public override void Voice()
        {
            Console.WriteLine("Woof — Woof — Woof");
        }
    }
    class PatrolDog : Pet {
        public override void Voice()
        {
            Console.WriteLine("Gaww — Gaww — Gaww");
        }
    }
    class Cat : Pet {
        public override void Voice()
        {
                Console.WriteLine("Наблюдая за домашней любимицей, можно заметить, что кошка мурлыкает в определенных ситуациях. \nСуществует несколько основных причин мурчания.");
                Console.WriteLine("Ваша кошка благодарит вас. Таким образом, животное может выразить свое удовольствие и расположение к хозяину");
                Console.WriteLine("Meow — Meow - Meow");
                Console.WriteLine("Ухаживайте за питомцем!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Fshhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh...");
        }
    }
    class Fish : Pet {
        public override void Voice()
        {
                Console.WriteLine("Вы - молодец ＼(￣▽￣)／");
                Console.WriteLine("Meow — Meow - Meow");
                Console.WriteLine("Ухаживайте за питомцем!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Fshhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh...");
                Console.WriteLine("Bylllll — Bylllll — Bylllll");
        }
    }
}