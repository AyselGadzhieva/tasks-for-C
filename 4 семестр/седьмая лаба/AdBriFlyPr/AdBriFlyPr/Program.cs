using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBriFlyPr
{
    class Program
    {
        static void Main(string[] args)
        {
            //Адаптер(Adapter)
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Адаптер(Adapter)");
            Console.WriteLine("----------------------------------------------------");
            User user = new User();
            ConventionalCalculations conventional_calculations = new ConventionalCalculations(1,2);
            user.Payment(conventional_calculations);
            ComplexCalculations complex_calculations = new ComplexCalculations();
            ICalculator ccc = new CAdapter(complex_calculations);
            user.Payment(ccc);
            Console.WriteLine();


            //Мост(Bridge)
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Мост(Bridge)");
            Console.WriteLine("----------------------------------------------------");
            Area c = new Area1(new Сircle(), 1);
            c.Gr(360);
            c.AreaCalculationsAndSoOn();
            Console.WriteLine();
            Console.WriteLine();
            c = new Area2(new Rectangle(), 1,3);
            c.Gr(760);
            c.AreaCalculationsAndSoOn();
            Console.WriteLine();


            //Приспособленец(Flyweight)
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Приспособленец(Flyweight)");
            Console.WriteLine("----------------------------------------------------");
            RoleFactory role_factory = new RoleFactory();
            Role Hades = role_factory.GetRole("Hades");
            if (Hades != null)
                Hades.Actor("Alec", 21, 192, "man", "№4");
            Console.WriteLine();
            Console.WriteLine();
            Role Jafar = role_factory.GetRole("Jafar");
            if (Jafar != null)
                Jafar.Actor("Jude", 22, 172, "man", "№1");
            Console.WriteLine();


            //Заместитель(Proxy)
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Заместитель(Proxy)");
            Console.WriteLine("----------------------------------------------------");
            var lock_ = new ProxyLock();
            lock_.Open("Маша");
            Console.ReadKey();
        }
    }
    //Адаптер(Adapter)
    interface ICalculator
    {
        void Fl();
    }
    class ConventionalCalculations : ICalculator
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public double Conclusion { get; set; }
        public ConventionalCalculations (double a, double b)
        {
            FirstNumber = a;
            SecondNumber = b;
    }
        public void Fl()
        {
            Console.WriteLine("В квадрат:\nпервое число: {0}\nвторое число: {1} ", Math.Pow(FirstNumber,2), Math.Pow(SecondNumber,2));
            Console.WriteLine("1/x:\nпервое число: {0}\nвторое число: {1} ", (1/FirstNumber), (1/SecondNumber));
            Console.WriteLine("Под корнем:\nпервое число: {0}\nвторое число: {1} ", Math.Sqrt(FirstNumber), Math.Sqrt(SecondNumber));
            Console.WriteLine("Сумма: первое число + второе число = " + (FirstNumber + SecondNumber));
        }
    }
    class User
    {
        public void Payment(ICalculator payment)
        {
            payment.Fl();
        }
    }
    interface IUCalculator
    {
        void Flesh();
    }
    class ComplexCalculations : IUCalculator
    {
        public void Flesh()
        {
            Console.WriteLine("\nОтправка расчётов!");
            Console.WriteLine("Передача данных инженерному калькулятору!");
        }
    }
    // Адаптер
    class CAdapter : ICalculator
    {
        ComplexCalculations com;
        public CAdapter(ComplexCalculations c)
        {
            com = c;
        }
        public void Fl()
        {
            com.Flesh();
        }
    }



    //Мост(Bridge)
    interface IFigure
    {
        void AreaFormula();
        void Properties(int g);
    }

    class Сircle : IFigure
    {
        public void AreaFormula()
        {
            Console.WriteLine("S = pi * r^2");
        }

        public void Properties(int g)
        {
            Console.WriteLine("Свойства окружности:" +
                "\n1.Диаметр окружности равен двум радиусам." +
                "\n2.Кратчайшее расстояние от центра окружности к секущей(хорде) всегда меньше радиуса." +
                "\n3.Через три точки, которые не лежат на одной прямым, можно провести только одну окружность." +
                "\n4.Среди всех замкнутых кривых с одинаковой длиной, окружность имеет наибольшую площадь." +
                "\n5.Если две окружности соприкасаются в одной точке, то эта точка лежит на прямой, что проходит через центры этих окружностей.");
            Console.WriteLine("Угол окружности = " + g + "°");
        }
    }

    class Rectangle : IFigure
    {
        public void AreaFormula()
        {
            Console.WriteLine("S = a * b");
        }

        public void Properties(int g)
        {
            Console.WriteLine("Свойства прямоугольника:" +
                "\n1. В прямоугольнике противоположные стороны равны." +
                "\n2. Диагонали прямоугольника пересекаются и точкой пересечения делятся пополам." +
                "\n3. Диагонали прямоугольника равны." +
                "\n4. Биссектриса угла прямоугольника отсекает от него прямоугольный равнобедренный треугольник.");
            Console.WriteLine("Угол прямоугольника = " + g + "°");
        }
    }

    abstract class Area
    {
        protected IFigure figure;
        public IFigure Figure{set { figure = value; }}
        public int G { get; set; }
        public Area(IFigure lang)
        {
            figure = lang;

        }
        public virtual void Gr(int g)
        {            G = g;
            figure.AreaFormula();
            figure.Properties(G);
        }
        public abstract void AreaCalculationsAndSoOn();
    }

    class Area1 : Area
    {
        public double R { get; set; }
        public Area1(IFigure lang, double r) : base(lang)
        {
            R = r;
        }
        public override void AreaCalculationsAndSoOn()
        {
            Console.WriteLine("Площадь круга = " + (Math.PI*R*R));
            Console.WriteLine("Длина круга = " + (Math.PI * 2 * R));
            Console.WriteLine("Диаметр круга = " + (2 * R));
        }
    }
    class Area2 : Area
    {
        public double A { get; set; }
        public double B { get; set; }
        public Area2(IFigure lang, double a, double b) : base(lang)
        {
            A = a;
            B = b;
        }
        public override void AreaCalculationsAndSoOn()
        {
            Console.WriteLine("Площадь прямоугольника = " + (A * B));
            Console.WriteLine("Периметр прямоугольника = " + (2*(A + B)));
            Console.WriteLine("Диагональ прямоугольника = " + (Math.Sqrt(A*A + B*B)));
        }
    }



    //Приспособленец(Flyweight)
    //для внутрен. состояния
    abstract class Role
    {
        protected string role;
        protected int age;
        protected int height;
        protected string gender;
        protected string character_type;
        protected string enemies;
        protected string target;
        //для вынесения внешнего состояния
        public abstract void Actor(string name, int age, int height, string gender, string school);
    }
    class RoleHades : Role
    {
        public RoleHades()
        {
            role = "Hades";
            height = 270;
            gender = "man";
            character_type = "Negative";
            enemies = "Hercules, Zeus, Megara";
            target = "To overthrow his older brother and seize power over Olympus (failed)";
        }

        public override void Actor(string name, int age, int height, string gender, string school)
        {
            Console.WriteLine("Added actor for the role of Hades!");
            Console.WriteLine("~Actor data:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("School: " + school);
            Console.WriteLine("~Your role and its characteristics:");
            Console.WriteLine(role);
            Console.WriteLine(height);
            Console.WriteLine(gender);
            Console.WriteLine(character_type);
            Console.WriteLine(enemies);
            Console.WriteLine(target);
        }
    }
    class RoleJafar : Role
    {
        public RoleJafar()
        {
            role = "Jafar";
            age = 70;
            height = 180;
            gender = "man";
            character_type = "Negative";
            enemies = "Aladdin, Jasmine, Abu, Rug, Raja";
            target = "Capture Agrab(succeeded, temporarily)" +
            "\nCapture the World(failed)" +
            "\nRevenge Alladin(failed)";
        }

        public override void Actor(string name, int age, int height, string gender, string school)
        {
            Console.WriteLine("Added actor for the role of Jafar!");
            Console.WriteLine("~Actor data:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("School: " + school);
            Console.WriteLine("Your role and its characteristics:");
            Console.WriteLine(role);
            Console.WriteLine(age);
            Console.WriteLine(height);
            Console.WriteLine(gender);
            Console.WriteLine(character_type);
            Console.WriteLine(enemies);
            Console.WriteLine(target);
        }
    }
    class RoleFactory
    {
        Dictionary<string, Role> roles = new Dictionary<string, Role>();
        public RoleFactory()
        {
            roles.Add("Hades", new RoleHades());
            roles.Add("Jafar", new RoleJafar());
        }

        public Role GetRole(string key)
        {
            if (roles.ContainsKey(key))
                return roles[key];
            else
                return null;
        }
    }



    //Заместитель(Proxy)
    interface ILockingSystem
    {
        void Open(string a);
        void Close();
    }
    class Lock : ILockingSystem
    {
        public void Open(string a)
        {
            Console.WriteLine("Your password: " + a);
            Console.WriteLine("Unlock");
        }
        public void Close()
        {
            Console.WriteLine("Lock");
        }
    }
    class ProxyLock : ILockingSystem
    {
        private Lock _lock = new Lock();
        public void Open(string a)
        {
            Console.WriteLine("Read password");
            if (a.Length > 20)
                Console.WriteLine("Wrong password!");
            else
                _lock.Open(a);
        }
        public void Close()
        {
            Console.WriteLine("Lock");
        }
    }
}
