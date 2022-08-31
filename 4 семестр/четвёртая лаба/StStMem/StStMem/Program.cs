using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StStMem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Стратегия(Strategy)
            Console.WriteLine("Стратегия(Strategy)");
            Console.WriteLine("-----------------------------------------------");
            Hogwarts hei = new Hogwarts(150, "Harry Potter", new Gryffindor());
            hei.Faculty();
            Console.WriteLine();
            Hogwarts heir = new Hogwarts(130, "Draco Malfoy", new Slytherin());
            heir.Faculty();
            Console.WriteLine("\n");

            //Состояние(State)
            Console.WriteLine("Состояние(State)");
            Console.WriteLine("-----------------------------------------------");
            string[] seasons = new string[] { "Autumn", "Spring", "Winter", "Summer" };
            Random rand = new Random();
            int temp = 0;
            Celebrity_time concert;
            for (int i = 0; i == 0 ; i++)
            {
                temp = rand.Next(4);
                if (seasons[temp] == "Autumn") {
                    concert = new Celebrity_time(new Seasons_Autumn()); }
                else if (seasons[temp] == "Spring") {

                    concert = new Celebrity_time(new Seasons_Spring()); }
                else if (seasons[temp] == "Winter") {

                    concert = new Celebrity_time(new Seasons_Winter()); }
                else { concert = new Celebrity_time(new Seasons_Summer()); }
                Console.WriteLine(seasons[temp]);
                Console.WriteLine(".......");
                concert.Celebrity();
                concert.Location();
                concert.Celebrity();
                concert.Location();
                concert.Celebrity();
                concert.Location();
                concert.Celebrity();
                concert.Location();
            }


            //Хранитель(Memento)
            Console.WriteLine("\n");
            Console.WriteLine("Хранитель(Memento)");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("~Time traveller~"); // + 1 путешествие
            Hero hero = new Hero();
            hero.Time_travel();
            GameHistory game = new GameHistory();
            hero.Best_travel();
            game.History.Push(hero.SaveState());
            hero.Time_travel();
            hero.Best_travel();
            hero.RestoreState(game.History.Pop());
            hero.Time_travel();


            Console.ReadLine();
        }
    }

    //Стратегия(Strategy)
    interface IStudy
    { void Faculty(); }

    class Gryffindor : IStudy
    {
        public void Faculty()
        {
            Console.WriteLine(" recognized by Gryffindor");
        }
    }

    class Slytherin : IStudy
    {
        public void Faculty()
        {
            Console.WriteLine(" recognized by Slytherin");
        }
    }
    class Hogwarts
    {
        protected int number_of_students;
        protected string student_name;
        public Hogwarts(int num, string faculty_name, IStudy fl)
        {
            number_of_students = num;
            student_name = faculty_name;
            Study = fl;
            Console.WriteLine("You are very lucky. You will study at Hogwarts");
            Console.WriteLine($"There are {number_of_students} students at your faculty");
            Console.Write(student_name);
        }
        public IStudy Study { private get; set; }
        public void Faculty() { Study.Faculty(); }
    }


    //Состояние(State)
    class Celebrity_time
    {
        public IWeather State { get; set; }
        public Celebrity_time(IWeather ws)
        {
            State = ws;
        }
        public void Celebrity()
        {
            State.Celebrity(this);
        }
        public void Location()
        {
            State.Location(this);
        }
    }

    interface IWeather
    {
        void Celebrity(Celebrity_time water);
        void Location(Celebrity_time water);
    }

    class Seasons_Autumn : IWeather
    {
        public void Celebrity(Celebrity_time water)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Celebrities in autumn:");
            Console.WriteLine("Ariana Grande, Lil Wayne, Chris Brown");
            Console.ResetColor();
        }
        public void Location(Celebrity_time water)
        {
            Console.WriteLine("Depending on the weather: on the street or in a huge building.");
            water.State = new Seasons_Winter();
        }
    }
    class Seasons_Spring : IWeather
    {
        public void Celebrity(Celebrity_time water)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Celebrities in spring:");
            Console.WriteLine("Lana Del Rey, Maroon 5, Beyonce");
            Console.ResetColor();
        }
        public void Location(Celebrity_time water)
        {
            Console.WriteLine("Depending on the weather: on the street or in a huge building.");
            water.State = new Seasons_Summer();
        }
    }
    class Seasons_Winter : IWeather
    {
        public void Celebrity(Celebrity_time water)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Celebrities in winter:");
            Console.WriteLine("Zayn Malik, Taylor Swift, Justin Bieber");
            Console.ResetColor();
        }
        public void Location(Celebrity_time water)
        {
            Console.WriteLine("Enclosed space with huge capacity");
            water.State = new Seasons_Spring();
        }
    }
    class Seasons_Summer : IWeather
    {
        public void Celebrity(Celebrity_time water)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Celebrities in summer:");
            Console.WriteLine("Drake Graham, Rihanna Fenty, jonas brothers");
            Console.ResetColor();
        }
        public void Location(Celebrity_time water)
        {
            Console.WriteLine("Outdoors. Desirable near nature.");
            water.State = new Seasons_Autumn();
        }
    }


    //Хранитель(Memento)
    // Создает объект хранителя для сохранения своего состояния
    class Hero
    {
        private int number_of_movements = 10; // кол-во перемещений во времени 
        private int favorites = 5; // кол-во избранных

        public void Time_travel()
        {
            if (number_of_movements > 0)
            {
                number_of_movements++;
                Console.WriteLine("Перемещение во времени! Будьте осторожны!");
                Console.WriteLine("{0} избранных, {1} перемещений", favorites, number_of_movements);
            }
            else
                Console.WriteLine("Вы ещё не путешественник во времени, но можете им стать~");
        }
        public void Best_travel()
        {
            Console.WriteLine("Хотите добавить данное перемещение в список избранных?");
            string a = Console.ReadLine();
            if (a == "Да" || a == "да" || a == "yes" || a == "Yes")
            {
                favorites++;
            }
        }
        // сохранение состояния
        public HeroMemento SaveState()
        {
            Console.WriteLine("Сохранение текущего списка путешествий. Параметры: {0} избранных, {1} перемещений", favorites, number_of_movements);
            return new HeroMemento(favorites, number_of_movements);
        }

        // восстановление состояния
        public void RestoreState(HeroMemento memento)
        {
            favorites = memento.Favorites;
            number_of_movements = memento.Number_of_movements;
            Console.WriteLine("Восстановление списка. Параметры: {0} избранных, {1} перемещений", favorites, number_of_movements);
        }
    }
    // Хранитель, который сохраняет состояние объекта
    class HeroMemento
    {
        public int Favorites { get; private set; }
        public int Number_of_movements { get; private set; }

        public HeroMemento(int favorites, int number_of_movements)
        {
            Favorites = favorites;
            Number_of_movements = number_of_movements;
        }
    }

    // выполняет только функцию хранения объекта HeroMemento
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
