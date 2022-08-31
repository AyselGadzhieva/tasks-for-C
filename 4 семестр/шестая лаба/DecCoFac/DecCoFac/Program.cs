using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecCoFac
{
    class Program
    {
        static void Main(string[] args)
        {
            //Декоратор(Decorator)
            Console.WriteLine("Декоратор(Decorator)");
            Console.WriteLine("----------------------------------------------------");
            Superheroes superheroes1 = new DC("Clark Joseph Kent (Superman)", 1938, "Superhuman physical characteristics, " +
                "superhuman feelings,\nshock waves, energy attacks,flight, space travel,\n" +
                "tactile telekinesis, immortality", 191);
            Console.WriteLine(superheroes1.Inf);
            superheroes1 = new NewOpportunities(superheroes1);
            Console.WriteLine("Total characters in DC = " + superheroes1.Сharacter());
            Console.WriteLine();
            Superheroes superheroes2 = new DC("Bruce Wayne (Batman)", 1939, "no", 188);
            Console.WriteLine(superheroes2.Inf);
            superheroes2 = new NewOpportunities(superheroes2);
            Console.WriteLine("Total characters in DC = " + superheroes2.Сharacter());
            Console.WriteLine();
            Superheroes superheroes3 = new Marvel("Питер Бенджамин Паркер (Spider-Man)", 1962, "Superhuman physical characteristics, night vision, sensory abilities,\n" +
                "able to adhere to any kind of surface, immortality", 175);
            Console.WriteLine(superheroes3.Inf);
            Console.WriteLine("Total characters in Marvel = " + superheroes3.Сharacter());
            superheroes3 = new Encryption(superheroes3);
            Console.WriteLine("Name = " + superheroes3.Сharacter());
            Console.WriteLine();


            //Компоновщик(Composite)
            Console.WriteLine("Компоновщик(Composite)");
            Console.WriteLine("----------------------------------------------------");
            Order_With_Asos big_box = new BigBox("ABC");
            Order_With_Asos small_box = new SmallBox("abc");
            Order_With_Asos comp = new Сomputer("Системный блок игровой Alienware Aurora R8-7297");
            Order_With_Asos sneak = new Sneakers("Nike Air Force 1  Mid '07");
            small_box.Add(comp);
            small_box.Add(sneak);
            big_box.Add(small_box);
            big_box.Print();
            Console.WriteLine();


            //Фасад(Facade)
            Console.WriteLine("Фасад(Facade)");
            Console.WriteLine("----------------------------------------------------");
            Random r = new Random();
            int points_EGE = r.Next(301);
            University1 university1 = new University1("Коваленко Андрей Брониславович", points_EGE);
            University2 university2 = new University2("Коваленко Андрей Брониславович", points_EGE);
            Job job = new Job();
            CreativeClubs cc = new CreativeClubs();
            UNSFacade ide = new UNSFacade(university1, university2, job, cc);
            Student student = new Student();
            student.CreateApplication(ide);


            Console.ReadKey();
        }
    }

    //Декоратор(Decorator)
    abstract class Superheroes
    {
        public Superheroes(string name, int year_of_birth, string superpower, int height)
        {
            Name = name;
            Year_of_birth = year_of_birth;
            Superpower = superpower;
            Number_of_full_years = 2020 - year_of_birth;
            Height = height;
            Inf = "Name: " + name + " \n" + "Year of birth: " + year_of_birth + " \n" + "Superpower: " + superpower + " \n" + "Number of full years: " + Number_of_full_years + " \n" + "Height: " + height;
    }
        public string Name { get; set; }
        public int Year_of_birth { get; set; }
        public string Superpower { get; set; }
        public int Number_of_full_years { get; set; }
        public int Height { get; set; }
        public string Inf { get; set; }
        public abstract string Сharacter();
        public abstract void NO();
    }

    class DC : Superheroes
    {
        public DC (string name, int year_of_birth, string superpower, int height) : base(name, year_of_birth, superpower, height)
        {

        }
        public override string Сharacter()
        {
            return "20104";
        }
        public override void NO()
        {
            Console.WriteLine("\nSuper power(s) added!\n + Regeneration");
        }
    }
    class Marvel : Superheroes
    {
        public Marvel (string name, int year_of_birth, string superpower, int height) : base(name, year_of_birth, superpower, height)
        { }
        public override string Сharacter()
        {
            return "46510";
        }
        public override void NO()
        {
            Console.WriteLine("\nSuper power(s) added!\n + Regeneration");
        }
    }
    abstract class Enhancements : Superheroes /*Улучшения*/
    {
        protected Superheroes superheroes;
        public Enhancements(string name, int year_of_birth, int number_of_full_years, string superpower, int height, Superheroes Superheroes) : base(name, year_of_birth, superpower, height)
        {
            superheroes = Superheroes;
        }
    }
    class NewOpportunities : Enhancements /*Новые возможности*/
    {
        public NewOpportunities(Superheroes s)
            : base(s.Name, s.Year_of_birth,s.Number_of_full_years, s.Superpower, s.Height, s)
        {
           s.NO();
        }
        public override void NO()
        {
        }
        public override string Сharacter()
        {
            return superheroes.Сharacter();
        }
    }

    class Encryption : Enhancements /*Шифрование*/
    {
        public Encryption(Superheroes s)
            : base(s.Name, s.Year_of_birth, s.Number_of_full_years, s.Superpower, s.Height, s)
        {
        }
        public override void NO()
        {
        }
        public override string Сharacter()
        {
            var textBytes = Encoding.UTF8.GetBytes(Name);
            return Convert.ToBase64String(textBytes);
        }
    }



    //Компоновщик(Composite)
    abstract class Order_With_Asos
    {
        public int Id { get; set; }
        protected string name;
        public Order_With_Asos(string name)
        {
            this.name = name;
        }
        public virtual void Add(Order_With_Asos component) { }
        public virtual void Remove(Order_With_Asos component) { }
        public virtual void Print()
        {

            Console.WriteLine("Id:" + Id + " " + "Name: "+ name);
        }
    }
    class BigBox : Order_With_Asos
    {
        private List<Order_With_Asos> order_with_asos = new List<Order_With_Asos>();

        public BigBox(string name) : base(name) { }

        public override void Add(Order_With_Asos order_with_asos)
        {
            this.order_with_asos.Add(order_with_asos);
        }

        public override void Remove(Order_With_Asos order_with_asos)
        {
            this.order_with_asos.Remove(order_with_asos);
        }

        public override void Print()
        {
            Console.WriteLine("В большой коробке ({0}):", name);
            {
                for (int i = 0; i < order_with_asos.Count; i++)
                {
                    order_with_asos[i].Print();
                }
            }
        }
    }
    class SmallBox : Order_With_Asos
    {
        private List<Order_With_Asos> order_with_asos1 = new List<Order_With_Asos>();

        public SmallBox(string name): base(name) { }

        public override void Add(Order_With_Asos order_with_asos)
        {
            order_with_asos1.Add(order_with_asos);
        }

        public override void Remove(Order_With_Asos order_with_asos)
        {
            order_with_asos1.Remove(order_with_asos);
        }

        public override void Print()
        {
            Console.WriteLine("Маленькая коробка.\nВ маленькой коробке ({0}):", name);
            for (int i = 0; i < order_with_asos1.Count; i++)
            {
                order_with_asos1[i].Print();
            }
        }
    }
    class Сomputer : Order_With_Asos //Компьютер
    {
        public Сomputer(string name) : base(name)
        {
            Random s = new Random();
            Id = s.Next(2999);
        }
    }
    class Сlothes : Order_With_Asos //Одежда
    {
        public Сlothes(string name) : base(name)
        {
            Random s = new Random();
            Id = s.Next(10);
        }
    }
    class Sneakers : Order_With_Asos //Кроссовки
    {
        public Sneakers(string name) : base(name)
        {
            Random s = new Random();
            Id = s.Next(10000000);
        }
    }



    //Фасад(Facade)
    class University1
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public University1(string n, int a)
        {
            Name = n;
            Points = a;
        }
        public void SubmitDocuments()
        {
            Console.WriteLine("Поздравляю! Вы подали документы в МГУ!");
            Console.WriteLine("ФИО: " + Name + "\n"+ "Всего баллов: " + Points);
        }
        public void GetAnAnswer()
        {
            if (Points > 200)
                Console.WriteLine("Поздравляю!Вы (" + Name + ") поступили в МГУ!");
            else
                Console.WriteLine("К сожалению вы (" + Name + ") не попали с список поступивших (МГУ).");
        }
    }
    class University2
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public University2(string n, int a)
        {
            Name = n;
            Points = a;
        }
        public void SubmitDocuments()
        {
            Console.WriteLine("Поздравляю! Вы подали документы в ЮГУ");
            Console.WriteLine("ФИО: " + Name + "\n" + "Всего баллов: " + Points);
        }
        public void GetAnAnswer()
        {
            if (Points > 170)
                Console.WriteLine("Поздравляю! Вы (" + Name + ") поступили в ЮГУ!");
            else
                Console.WriteLine("К сожалению вы (" + Name + ") не попали с список поступивших (ЮГУ).");
        }
    }
    class Job
    {
        public void ApplyForAJob()
        {
            Console.WriteLine("Вы устроились на работу!");
        }
        public void QuitWork()
        {
            Console.WriteLine("Вы уволились с работы!");
        }
    }
    class CreativeClubs
    {
        public void ScientificCircles()
        {
            Console.WriteLine("Вы вступили в кружок 'Клуб интеллектуальных игр!'");
        }
        public void Volunteer()
        {
            Console.WriteLine("Вы вступили в ряды волонтёров!");
        }
    }
    class UNSFacade
    {
        University1 university1;
        University2 university2;
        Job job;
        CreativeClubs cc;
        public UNSFacade(University1 u1, University2 u2, Job j, CreativeClubs c)
        {
            university1 = u1;
            university2 = u2;
            job = j;
            cc = c;
        }
        public void SubmitDocuments()
        {
            university1.SubmitDocuments();
            university2.SubmitDocuments();
        }
        public void GetAnAnswer()
        {
            university1.GetAnAnswer();
            university2.GetAnAnswer();
        }
        public void AboutWork()
        {
            Random r = new Random();
            int rn = r.Next(2);
            if (rn == 0)
            {
                job.ApplyForAJob();
            }
            else
                job.QuitWork();
        }
        public void AboutSections()
        {
            Random r = new Random();
            int rn = r.Next(2);
            if (rn == 0)
            {
                cc.ScientificCircles();
            }
            else
                cc.Volunteer();
        }
    }

    class Student
    {
        public void CreateApplication(UNSFacade facade)
        {
            facade.SubmitDocuments();
            facade.GetAnAnswer();
            Random r = new Random();
            int rn = r.Next(2);
            if (rn == 0)
            {
                facade.AboutSections();
            }
            else
                facade.AboutWork();
        }
    }
}
