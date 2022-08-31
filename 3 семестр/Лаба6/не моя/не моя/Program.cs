using System;
using System.Collections;
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
            StudentCollection studentCollection1 = new StudentCollection();
            StudentCollection studentCollection2 = new StudentCollection();
            Journal journal1 = new Journal();
            studentCollection1.StudentCountChanged += journal1.AddEntry;
            studentCollection1.StudentReferenceChanged += journal1.AddEntry;
            Journal journal2 = new Journal();
            studentCollection1.StudentReferenceChanged += journal2.AddEntry;
            studentCollection2.StudentReferenceChanged += journal2.AddEntry;
            Console.WriteLine("Добавление в 1-ю коллекцию:");
            studentCollection1.AddDefaults();
            Console.WriteLine();
            Console.WriteLine("Добавление в 1-ю коллекцию:");
            studentCollection1.AddStudents(new Student());
            Console.WriteLine();
            Console.WriteLine("Изменение ссылки на элемент 1-й коллекции:");
            studentCollection1[0] = new Student("Петрова", "Анна", "Андреевна", 20);
            Console.WriteLine("Удаление из 1-й коллекции:");
            studentCollection1.Remove(0);
            Console.WriteLine();
            Console.WriteLine("Создание массива из 2-х студентов");
            Student[] students = new Student[2];
            students[0] = new Student("Иванов", "Николай", "Петрович", 20);
            students[1] = new Student("Кузнецов", "Петр", "Сергеевич", 19);
            Console.WriteLine();
            Console.WriteLine("Добавление массива во 2-ю коллекцию");
            studentCollection2.AddStudents(students);
            Console.WriteLine();
            Console.WriteLine("Изменение ссылки на элемент 2-й коллекции:");
            studentCollection2[1] = new Student("Дубровский", "Никита", "Андреевич", 20);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Удаление из 2-й коллекции");
            studentCollection2.Remove(1);
            Console.WriteLine();

            Console.WriteLine(journal1.ToString());
            Console.WriteLine(journal2.ToString());

            Console.ReadKey();
        }
    }
    class Student
    {
        private int age;
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get { return age; } set { if (value >= 14) age = value; else Console.WriteLine("Недопустимое значение!"); } }
        public Student()
        {
            Console.WriteLine("Введите фамилию студента:");
            LastName = Console.ReadLine();
            Console.WriteLine("Введите имя студента:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Введите отчество студента:");
            Patronymic = Console.ReadLine();
            Console.WriteLine("Введите возраст студента:");
            while (!int.TryParse(Console.ReadLine(), out age) || age < 14)
                Console.WriteLine("Ошибка ввода! Повторите");
        }
        public Student(string lastName, string firstName, string patronymic, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
             Age = age;
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {Patronymic} {Age} лет";
        }
    }
    class StudentCollection
    {
        public List<Student> Collection;
        public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
        public event StudentListHandler StudentCountChanged;
        public event StudentListHandler StudentReferenceChanged;
        public string CollectionName { get; set; }
        public StudentCollection()
        {
            Console.WriteLine("Введите название коллекции:");
            CollectionName = Console.ReadLine();
            Collection = new List<Student>();
        }
        // Удаление элемента из коллекции
        public bool Remove(int j)
        {
            if (j > Collection.Count - 1)
                return false;
            else
            {
                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Удален студент", Collection[j]));
                Collection.RemoveAt(j);
                return true;
            }
        }
        public void AddDefaults()
        {
            int n;
            Console.WriteLine("Сколько студентов вы хотите добавить в созданную коллекцию?");
            while (!int.TryParse(Console.ReadLine(), out n) && n >= 0)
                Console.WriteLine("Ошибка ввода! Повторите");
            Collection = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                Collection.Add(new Student());
                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавлен студент",
                Collection[i]));
            }
        }
        // Добавление элементов в коллекцию
        public void AddStudents(params Student[] students)
        {
            foreach (Student stud in students)
            {
                if (stud == null)
                    continue;
                Collection.Add(stud);
                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, "Добавлен студент", stud));
            }
        }
        public Student this[int index]
        {
            get
            {
                if (index < Collection.Count) return Collection[index];
                else
                {
                    Console.WriteLine("Неверное значение индекса!");
                    return null;
                }
            }
            set
            {
                if (index < Collection.Count && value != null)
                {
                    Collection[index] = value;
                    StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName, $"Ссылка на {index + 1}-й элемент коллекции изменилась", Collection[index]));
                }
                else Console.WriteLine("Неверное значение индекса!");
            }
        }
    }
    // Передача дополнительной информации обработчику
    class StudentListHandlerEventArgs : EventArgs
    {
        public string StudentCollectionName { get; set; }
        public string StudentCollectionTypeOfChange { get; set; }
        public Student Student { get; set; }
        public StudentListHandlerEventArgs(string studentCollectionName, string studentCollectionTypeOfChange, Student student)
        {
            StudentCollectionName = studentCollectionName;
            StudentCollectionTypeOfChange = studentCollectionTypeOfChange;
            Student = student;
        }
        public override string ToString()
        {
            return $"Коллекция: {StudentCollectionName} Изменения: {StudentCollectionTypeOfChange} Студент: {Student.ToString()}";
        }
    }
    // Запись в журнал
    class JournalEntry
    {
        private Student student;
        public string StudentCollectionName { get; set; }
        public string StudentCollectionTypeOfChange { get; set; }
        public string Student { get { return student.ToString(); } }
        public JournalEntry(string studentCollectionName, string studentCollectionTypeOfChange, Student student)
        {
            StudentCollectionName = studentCollectionName;
            StudentCollectionTypeOfChange = studentCollectionTypeOfChange;
            this.student = student;
        }

        public JournalEntry(StudentListHandlerEventArgs args)
        {
            StudentCollectionName = args.StudentCollectionName;
            StudentCollectionTypeOfChange = args.StudentCollectionTypeOfChange;
            student = args.Student;
        }
        public override string ToString()
        {
            return $"Коллекция: {StudentCollectionName} Изменения: {StudentCollectionTypeOfChange} Студент: {Student}";
        }
    }
    class Journal
    {
        private List<JournalEntry> journalEntries;
        public Journal()
        {
            journalEntries = new List<JournalEntry>();
        }
        public void AddEntry(object source, StudentListHandlerEventArgs args)
        {
            journalEntries.Add(new JournalEntry(args));
            Console.WriteLine(args.ToString());
        }
        public override string ToString()
        {
            string lines = null;
            foreach (JournalEntry entry in journalEntries)
            {
                lines += entry.ToString() + "\n";
            }
            return $"Журнал:\n{lines}";
        }
    }
}
