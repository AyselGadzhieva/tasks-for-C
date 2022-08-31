using System;
using System.Collections.Generic;

namespace CofRMOV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Цепочка Обязанностей(Chain of responsibility)
            Console.WriteLine("Цепочка Обязанностей(Chain of responsibility)");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Что вы делайте на самоизоляции?");
            AnswerSelection answer = new AnswerSelection(true, false, false);
            ResponseHandler stay_home = new StayHome();
            ResponseHandler walk = new Walk();
            ResponseHandler hobby = new Hobby();
            stay_home.Successor = hobby;
            hobby.Successor = walk;
            stay_home.Handle(answer);
            Console.WriteLine();


            //Посредник(Mediator)
            Console.WriteLine("Посредник(Mediator)");
            Console.WriteLine("----------------------------------------------------");
            ManagerMediator mediator = new ManagerMediator();
            //стабилизация
            Component stabilization = new Body_stabilizer(mediator);
            //поворот
            Component turn = new Angle_sensor(mediator);
            //наклон
            Component incline = new Tilt_sensor(mediator);
            //шаг
            Component step = new Movement_regulator(mediator);
            mediator.Turn = turn;
            mediator.Stabilization = stabilization;
            mediator.Incline = incline;
            mediator.Step = step;
            turn.Inform(23);
            incline.Inform(23);
            step.Inform(23);
            Console.WriteLine();


            //Наблюдатель (Observer)
            Console.WriteLine("Наблюдатель (Observer)");
            Console.WriteLine("----------------------------------------------------");
            Publications publications = new Publications();
            Subscriber_2 s2 = new Subscriber_2("Arthur Attwood", publications);
            Subscriber_1 s1 = new Subscriber_1("Vivienne Hawkins", publications);
            Console.WriteLine();
            publications.Instagram();
            s1.StopSpying();
            Console.WriteLine();
            publications.Instagram();
            Console.WriteLine();


            //Посетитель (Visitor)
            Console.WriteLine("Посетитель (Visitor)");
            Console.WriteLine("----------------------------------------------------");
            var employee = new Employee();
            employee.Add(new Person ("Arthur Attwood", "April", 16000, 2555, 665,400, 3000));
            employee.Add(new Company("Procter&Gamble", "April", 1500000, 20, 3, 1, 3, 7, 1, 5, 30, 2));
            employee.Accept(new TaxFreeIncomeVisitor());
            employee.Accept(new TaxesVisitor());

            Console.ReadKey();
        }
    }



    //Цепочка Обязанностей(Chain of responsibility)

    class AnswerSelection
    {
        // находиться дома
        public bool At_Home { get; set; }
        // выходить гулять
        public bool Go_Out_For_a_Walk { get; set; }
        // уделяю время хобби
        public bool Hobby_Time { get; set; }
        public AnswerSelection(bool hom, bool wk, bool ht)
        {
            At_Home = hom;
            Go_Out_For_a_Walk = wk;
            Hobby_Time = ht;
        }
    }
    //Определяет интерфейс для обработки запроса
    abstract class ResponseHandler
    {
        public ResponseHandler Successor { get; set; }
        public abstract void Handle(AnswerSelection receiver);
    }
    //Конкретный обработчик, который реализует функционал для обработки запроса
    class StayHome : ResponseHandler
    {
        public override void Handle(AnswerSelection receiver)
        {
            if (receiver.At_Home)
                Console.WriteLine("Остаюсь дома");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    //Конкретный обработчик, который реализует функционал для обработки запроса
    class Walk : ResponseHandler
    {
        public override void Handle(AnswerSelection receiver)
        {
            if (receiver.Go_Out_For_a_Walk)
                Console.WriteLine("Гуляю с друзьями");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    //Конкретный обработчик, который реализует функционал для обработки запроса
    class Hobby : ResponseHandler
    {
        public override void Handle(AnswerSelection receiver)
        {
            if (receiver.Hobby_Time)
                Console.WriteLine("~Наконец-то появилось время для хобби~");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }



    //Посредник(Mediator)
    //Представляет интерфейс для взаимодействия с объектами Component
    abstract class Mediator
    {
        public abstract void Inform(uint val, Component component);
    }
    //Представляет интерфейс для взаимодействия с объектом Mediator
    abstract class Component
    {
        protected Mediator mediator;

        public Component(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Inform(uint value)
        {
            mediator.Inform(value, this);
        }
        public abstract void Notify(uint value);
    }
    // класс стабилизатора
    class Body_stabilizer : Component
    {
        public Body_stabilizer(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(uint value)
        {
            Console.WriteLine("Стабилизация была успешно проведена!");
        }
    }
    // датчик угла поворота
    class Angle_sensor : Component
    {
        public Angle_sensor(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(uint value)
        {
            if (value < 360)
            Console.WriteLine("Робот повернулся на " + value + " градуса(ов)!");
        }
    }
    // датчик угла наклона
    class Tilt_sensor : Component
    {
        public Tilt_sensor(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(uint value)
        {
            if (value < 90) Console.WriteLine("Угол наклона робота составляет " + value + " градуса(ов)!");
            else Console.WriteLine("Этот угол (" + value + ") недопустим. Возникнет критическое состояние!");
        }
    }
    // класс регулятора движения
    class Movement_regulator : Component
    {
        public Movement_regulator(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(uint value)
        {
            if (value < 100)
            Console.WriteLine("Робот сделал " + value + " шага(ов)!");
        }
    }
    //Конкретный посредник, реализующий интерфейс типа Mediator
    class ManagerMediator : Mediator
    {
        public Component Turn { get; set; }
        public Component Stabilization { get; set; }
        public Component Incline { get; set; }
        public Component Step { get; set; }
        public override void Inform(uint val, Component colleague)
        {
            if (Turn == colleague)
            {
                Turn.Notify(val);
                Stabilization.Notify(val);
            }
            else if (Incline == colleague)
            {
                Incline.Notify(val);
                Stabilization.Notify(val);
            }
            else if (Step == colleague)
            {
                Step.Notify(val);
                Stabilization.Notify(val);
            }
        }
    }



    //Наблюдатель (Observer)
    //Представляет наблюдателя, который подписывается на все уведомления наблюдаемого объекта
    interface IObserver
    {
        void Update(Object ob);
    }
    //Наблюдаемый
    interface IObservable
    {
        void RegisterObserver(IObserver o, string name);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
    //Конкретная реализация интерфейса IObservable.Определяет коллекцию объектов наблюдателей
    class Publications : IObservable
    {
        PInfo pInfo; // информация о публикациях

        List<IObserver> observers;
        public Publications()
        {
            observers = new List<IObserver>();
            pInfo = new PInfo();
        }
        public void RegisterObserver(IObserver o, string name)
        {
            Console.WriteLine( name + " - " + "You have subscribed to Ariana Grande");
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            Console.WriteLine("You have unsubscribed from Ariana Grande");
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(pInfo);
            }
        }

        public void Instagram()
        {
            Random rnd = new Random();
            pInfo.Video = rnd.Next(1, 151);
            pInfo.Photo = rnd.Next(151, 270);
            pInfo.Quantity = rnd.Next(1, 3);
            NotifyObservers();
        }
    }

    class PInfo
    {
        public int Photo { get; set; }
        public int Quantity { get; set; }
        public int Video { get; set; }
    }

    class Subscriber_1 : IObserver
    {
        public string Name { get; set; }
        IObservable notification;
        public Subscriber_1(string name, IObservable obs)
        {
            this.Name = name;
            notification = obs;
            notification.RegisterObserver(this, name);
        }
        public void Update(object ob)
        {
            PInfo pInfo = (PInfo)ob;

            if (pInfo.Video > 75)
                Console.WriteLine("You, {0}, lucky!  Ariana Grande liked your post." +
                    "\n~She left a comment~" +
                    "\nThanks for the {1} videos you liked.", this.Name, pInfo.Video);
            else
                Console.WriteLine("You, {0}, lucky!  Ariana Grande liked your post." +
                   "\n ~By the way~ Your {1} videos are very cool", this.Name, pInfo.Video);
        }
        public void StopSpying()
        {
            notification.RemoveObserver(this);
            notification = null;
        }
    }

    class Subscriber_2 : IObserver
    {
        public string Name { get; set; }
        IObservable notification;
        public Subscriber_2(string name, IObservable obs)
        {
            this.Name = name;
            notification = obs;
            notification.RegisterObserver(this, name);
        }
        public void Update(object ob)
        {
            PInfo pInfo = (PInfo)ob;

            if (pInfo.Photo > 210)
                Console.WriteLine("Ariana Grande I posted {0} new photos!", pInfo.Photo);
            else
                Console.WriteLine("Ariana Grande {0} minutes ago launched a live broadcast!", pInfo.Quantity);
        }
        public void StopSpying()
        {
            notification.RemoveObserver(this);
            notification = null;
        }
    }



    //Посетитель (Visitor)
    interface IVisitor
    {
        void VisitPersonAcc(Person acc);
        void VisitCompanyAc(Company acc);
    }

    // налоги
    class TaxesVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            Console.WriteLine(acc.Name + " in " + acc.MonthName + " :");
            uint taxes = acc.BasicSalary + acc.LandTax + acc.MedicalAllowance + acc.TelephoneBill + acc.Other;
            Console.WriteLine("Земельный налог = " + (acc.LandTax * 100 /taxes) + "%");
            Console.WriteLine("Медицинский налоговый вычет = " + (acc.MedicalAllowance * 100 / taxes) + "%");
            Console.WriteLine("Счёт за телефрн = " + (acc.TelephoneBill * 100 / taxes) + "%");
            Console.WriteLine("Прочие расходы = " + (acc.Other * 100 / taxes) + "%");
        }

        public void VisitCompanyAc(Company acc)
        {
            string c_personal_month = acc.Name + "-company in " + acc.MonthName + " :";
            Console.WriteLine(c_personal_month);
            Console.WriteLine("Заработная плата рабочих, составляющая " + acc.BasicSalaryOfWorkers_percent + "%, равна " + (acc.BasicSalaryOfWorkers_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Земельный налог №1, составляющий " + acc.LandTax_percent + "%, равен " + (acc.LandTax_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Земельный налог №2, составляющий " + acc.LandTax2_percent + "%, равен " + (acc.LandTax2_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Пособие на перевозку, составляющий " + acc.InsurancePremiums_percent + "%, равен " + (acc.InsurancePremiums_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Медицинский налоговый вычет, составляющий " + acc.MedicalAllowance_percent + "%, равен " + (acc.MedicalAllowance_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Счёт за телефрн, составляющий " + acc.TelephoneBill_percent + "%, равен " + (acc.TelephoneBill_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Продовольственная карта, составляющая " + acc.FoodCard_percent + "%, равен " + (acc.FoodCard_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Налог на доходы физических лиц, составляющий " + acc.PersonalIncomeTax_percent + "%, равен " + (acc.PersonalIncomeTax_percent * acc.AllIncome / 100) + " руб");
            Console.WriteLine("Прочие расходы, составляющие " + acc.Other_percent + "%, равны " + (acc.Other_percent * acc.AllIncome / 100) + " руб");
        }
    }

    // доход
    class TaxFreeIncomeVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string p_personal_month = acc.Name + " in " + acc.MonthName + " :";
            Console.WriteLine(p_personal_month);
            uint taxes = acc.BasicSalary + acc.LandTax + acc.MedicalAllowance + acc.TelephoneBill + acc.Other;
            Console.WriteLine("Счёт без выплаты налогов и прочих расходов составляет : " + (taxes) + "руб");
        }

        public void VisitCompanyAc(Company acc)
        {
            string c_personal_month = acc.Name + "-company in " + acc.MonthName + " :";
            Console.WriteLine(c_personal_month);
            uint b, c, d, e, k;
            b = acc.LandTax_percent * acc.AllIncome / 100;
            c = acc.LandTax2_percent * acc.AllIncome / 100;
            d = acc.InsurancePremiums_percent * acc.AllIncome / 100;
            e = acc.MedicalAllowance_percent * acc.AllIncome / 100;
            k = acc.PersonalIncomeTax_percent * acc.AllIncome / 100;
            Console.WriteLine("Счёт за налги составляет : " + (b + c + d + e + k) + "руб");
            Console.WriteLine("Всего % за налоги от суммы = " + ((b + c + d + e + k)  * 100 / acc.AllIncome) + "%");
            Console.WriteLine("Прибыль = " + (acc.AllIncome - (b + c + d + e + k)) + "руб");
        }
    }

    class Employee
    {
        List<ISalary> accounts = new List<ISalary>();
        public void Add(ISalary acc)
        {
            accounts.Add(acc);
        }
        public void Remove(ISalary acc)
        {
            accounts.Remove(acc);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (ISalary acc in accounts)
                acc.Accept(visitor);
        }
    }

    interface ISalary
    {
        void Accept(IVisitor visitor);
    }

    class Person : ISalary
    {
        public Person(string name, string month_name, uint basic_salary, uint land_tax, uint medical_allowance, uint telephone_bill, uint other)
        {
            Name = name;
            MonthName = month_name;
            BasicSalary = basic_salary;
            LandTax = land_tax;
            MedicalAllowance = medical_allowance;
            TelephoneBill = telephone_bill;
            Other = other;
    }
        public string Name { get; set; }
        public string MonthName{get;set;}
        public uint BasicSalary {get; set;}
        public uint LandTax /*земельный налог*/ { get; set;}
        public uint MedicalAllowance /*Медицинское пособие*/{ get;set;}
        public uint TelephoneBill /*Счет за телефон*/ { get;set; }
        public uint Other {  get;set;  }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitPersonAcc(this);
        }
    }

    class Company : ISalary
    {
        public Company(string name, string month_name, uint all_income, uint basic_salary_of_workers_percent, uint land_tax_percent, uint land_tax2_percent, uint insurance_premiums_percent, uint medical_allowance_percent, uint telephone_bill_percent, uint food_card_percent, uint personal_income_tax_percent, uint other_percent)
        {
            Name = name;
            MonthName = month_name;
            AllIncome = all_income;
            BasicSalaryOfWorkers_percent = basic_salary_of_workers_percent;
            LandTax_percent = land_tax_percent;
            LandTax2_percent = land_tax2_percent;
            InsurancePremiums_percent = insurance_premiums_percent;
            MedicalAllowance_percent = medical_allowance_percent;
            TelephoneBill_percent = telephone_bill_percent;
            FoodCard_percent = food_card_percent;
            PersonalIncomeTax_percent = personal_income_tax_percent;
            Other_percent = other_percent;
        }
        public string Name { get; set; }
        public string MonthName { get; set; }
        public uint AllIncome { get; set; }
        public uint BasicSalaryOfWorkers_percent { get; set; }
        public uint LandTax_percent /*земельный налог*/ { get; set; }
        public uint LandTax2_percent /*земельный налог*/ { get; set; }
        public uint InsurancePremiums_percent /*Пособие на перевозку*/{ get; set; }
        public uint MedicalAllowance_percent /*Медицинское пособие*/{ get; set; }
        public uint TelephoneBill_percent /*Счет за телефон*/ { get; set; }
        public uint FoodCard_percent /*Продовольственная карта*/ { get; set; }
        public uint PersonalIncomeTax_percent { get; set; }
        public uint Other_percent { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompanyAc(this);
        }
    }
}