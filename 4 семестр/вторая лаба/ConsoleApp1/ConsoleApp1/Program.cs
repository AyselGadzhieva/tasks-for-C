using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodAndAbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Фабричный метод
            FlowerShop fl = new Bouquets("Бутик цветов");
            Flowers flowers2 = fl.Create();

            fl = new FlowersInPots("Город Цветов");
            Flowers flowers = fl.Create();



            // Абстрактная фабрика
            Monster den = new Monster(new DemonFactory());
            den.Hit();
            den.Aly();

            Monster qho = new Monster(new GhostFactory());
            qho.Hit();
            qho.Aly();
            Console.ReadLine();
        }
    }
    // Фабричный метод

    // абстрактный класс цветочной компании
    abstract class FlowerShop
    {
        public string Name { get; set; }

        public FlowerShop(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public Flowers Create();
    }
    // выпускает букеты
    class Bouquets : FlowerShop
    {
        public Bouquets(string n) : base(n)
        { Console.WriteLine("Магазин: " + n); }

        public override Flowers Create()
        {
            return new BouquetOfRoses();
        }
    }
    // выпускает цветы в горшках
    class FlowersInPots : FlowerShop
    {
        public FlowersInPots(string n) : base(n)
        { Console.WriteLine("Магазин: " + n); }
        
        public override Flowers Create()
        {
            return new Begonia();
        }
    }
    abstract class Flowers
    {
        protected int price = 0;
        protected Random r = new Random();

        public Flowers()
        {
            Console.Write("Ваш цветок:");
        }
    }
    class Begonia : Flowers
    {
        public Begonia()
        {
            Console.Write("Бегония   ");
            price = r.Next(800, 10000);
            Console.WriteLine("   Цена: " + price);

        }
    }
    class BouquetOfRoses : Flowers
    {
        public BouquetOfRoses()
        {
            Console.Write("Букет роз");
            price = r.Next(800, 10000);
            Console.WriteLine("   Цена: " + price);
        }
    }
    // Абстрактная фабрика

    //абстрактный класс - оружие
    abstract class Weapon
    {
        public abstract void Hit();
    }
    // абстрактный класс суперспособность
    abstract class Superpower
    {
        public abstract void Ability();
    }

    // класс невидимость
    class Inviz : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Становимся невидимыми на 10 секунд");
        }
    }
    // класс копье
    class Lance : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Удар копьём");
        }
    }
    // способность - невидимость
    class Invisibility : Superpower
    {
        public override void Ability()
        {
            Console.WriteLine("Невидимость");
        }
    }
    // способность - создание иллюзий
    class CreatingIllusions : Superpower
    {
        public override void Ability()
        {
            Console.WriteLine("Возможность создавать иллюзии");
        }
    }
    // класс абстрактной фабрики
    abstract class MonsterFactory
    {
        public abstract Superpower CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    // Фабрика создания летящего героя с арбалетом
    class DemonFactory : MonsterFactory
    {
        public override Superpower CreateMovement()
        {
            return new Invisibility();
        }

        public override Weapon CreateWeapon()
        {
            return new Inviz();
        }
    }
    // Фабрика создания бегущего героя с мечом
    class GhostFactory : MonsterFactory
    {
        public override Superpower CreateMovement()
        {
            return new CreatingIllusions();
        }

        public override Weapon CreateWeapon()
        {
            return new Lance();
        }
    }
    // клиент - монстр
    class Monster
    {
        private Weapon weapon;
        private Superpower superpower;
        public Monster(MonsterFactory factory)
        {
            weapon = factory.CreateWeapon();
            superpower = factory.CreateMovement();
        }
        public void Aly()
        {
            superpower.Ability();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
