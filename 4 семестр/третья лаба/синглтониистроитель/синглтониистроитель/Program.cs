using System;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SingletonANDPrototypeANDBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton

            (new Thread(() =>
            {
                Sweet icecream = new Sweet();
                icecream.Fty = Factory.getInstance("Magnum");
                Console.WriteLine(icecream.Fty.Name);
            })).Start();

            Sweet chocolate = new Sweet();
            chocolate.Launch("Lindt");
            Console.WriteLine(chocolate.Fty.Name);


            // Prototype
            var John = EmployeeFactory.NewMainoffceEmployee("John", 10);
            var Jill = EmployeeFactory.NewAuxoffceEmployee("John", 10000);

            Console.WriteLine(John);
            Console.WriteLine(Jill);


            Console.ReadLine();
        }
    }
    // Singleton
    class Sweet
    {
        public Factory Fty { get; set; }
        public void Launch(string osName)
        {
            Fty = Factory.getInstance(osName);
        }
    }
    class Factory
    {
        private static Factory instance;

        public string Name { get; private set; }

        protected Factory(string name)
        {
            this.Name = name;
        }

        public static Factory getInstance(string name)
        {
            if (instance == null)
                instance = new Factory(name);
            return instance;
        }
    }

    // Prototype

    static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("Type must be serializable");
            if (ReferenceEquals(self, null))
                return default (T);
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }

        }
        
    }

    class EmployeeFactory
    {
        private static Contact main = new Contact { WorkAddress = new Address { City = "London", Street = "250 Br" } };
        private static Contact aux = new Contact { WorkAddress = new Address { City = "London", Street = "250 Br" } };

        private static Contact NewEmployee (string name, int suite, Contact prototype)
        {
            var result = prototype.DeepCopy();
            result.Name = name;
            result.WorkAddress.Suite = suite;
            return result;
        }
        public static Contact NewMainoffceEmployee (string name, int suite)
        {
            return NewEmployee(name, suite, main);
        }
        public static Contact NewAuxoffceEmployee(string name, int suite)
        {
            return NewEmployee(name, suite, aux);
        }
    }
    
    [Serializable]
    class Contact
    {
        public string Name;
        public Address WorkAddress;

        public override string ToString()
        {
            return $"Name: {Name}, WorkAddress: {WorkAddress}";
        }
    }

    [Serializable]
    class Address
    {
        public string Street;
        public string City;
        public int Suite;

        public override string ToString()
        {
            return $"Street: {Street}, City: {City}, Suite: {Suite}";
        }
    }


}
