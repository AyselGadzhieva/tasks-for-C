using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Circle
    {
        public Circle(double x, double y, double r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        public Circle()
        {
            Console.WriteLine("Введите координату [x]:");
            while (!double.TryParse(Console.ReadLine(), out x)) ;
            Console.WriteLine("Введите координату [y]:");
            while (!double.TryParse(Console.ReadLine(), out y)) ;
            Console.WriteLine("Введите радиус [r]:");
            while (!double.TryParse(Console.ReadLine(), out r)) ;
            //ChangeCenter(); - можно дописать для нахождения координат центра круга в случайном дипазоне
        }
        private double x, y, r;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }
        public void GetLength()
        {
            double z = 2 * Math.PI * r;
            Console.WriteLine("Длина окружности равна " + z);
        }
        Random rnd = new Random();
        public void ChangeCenter()
        {
            x = rnd.Next(-99, 100);
            y = rnd.Next(-99, 100);
            Console.WriteLine("Координаты центра круга в случайном дипазоне: по X = " + x + " по У = " + y);
        }

        public double Distance(Circle c)
        {
            return Math.Sqrt(Math.Pow(x - c.x, 2) + Math.Pow(y - c.y, 2));
        }
        public short Touch(Circle c)
        {
            double z = Math.Min(r, c.r);
            double v = Math.Max(r, c.r);
            double w = v - z;
            double d = Distance(c);
            if (x == c.x && y == c.y && r == c.r)
            {
                Console.WriteLine("Окружности совпадают!");
                return 127;
            }
            else if (d > (r + c.r))
            {
                Console.WriteLine("Окружности не пересекаются!");
                return 0; }
            else if (d == (r + c.r))
            {
                Console.WriteLine("Окружности пересекаются 1 раз!");
                return 1;
            }
            else if (w == d)
            {
                Console.WriteLine("Окружности пересекаются 1 раз!");
                return 1; }
            else
                Console.WriteLine("Окружности пересекаются 2 раза!");
                return 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double i = 1;
            do
            {
                if (i != 1)
                {
                    break;
                }
                double x, y, r;
                Console.WriteLine("Введите координату [x]:");
                while (!double.TryParse(Console.ReadLine(), out x)) ;
                Console.WriteLine("Введите координату [y]:");
                while (!double.TryParse(Console.ReadLine(), out y)) ;
                Console.WriteLine("Введите радиус [r]:");
                while (!double.TryParse(Console.ReadLine(), out r)) ;

                Circle c1 = new Circle(x, y, r);
                Circle c2 = new Circle();
                Console.WriteLine("Пример: " + c2.X);
                c1.GetLength();
                c2.GetLength();
                Console.WriteLine("Расстояние между центрами= " + c1.Distance(c2));
                Console.WriteLine("Пересекаются: " + c1.Touch(c2) + " раз(а)");
                Console.WriteLine("Хотите продолжить работу? Если да, то нажмите [1]");
                Console.WriteLine("А если нет, то любую цифру отличную от [1]");
                while (!double.TryParse(Console.ReadLine(), out i)) ;
            }
            while (i == 1);
        }
    }
}