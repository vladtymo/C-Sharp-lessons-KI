using System;

namespace _06_inheritance
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }

        public Person() { }
        public Person(string name)
        {
            this.Name = name;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Birthdate: " + Birthdate.ToLongDateString());
            Console.WriteLine("Country: " + Country);
        }
        public void ShowTypeName()
        {
            Console.WriteLine("My type is class Person!");
        }
    }

    // Derived class can has only one parent class and many interfaces
    // Inheritance template: class Child : Parent_class, Interface1, Interface2 { }
    public class Student : Person
    {
        public float AverageMark { get; set; }
        public string Specialisation { get; set; }

        public Student(string name, float avgMark) : base(name)
        {
            this.AverageMark = avgMark;
        }
        public void ShowBonuses()
        {
            if (AverageMark >= 10) Console.WriteLine("Bouses: 100$");
            else Console.WriteLine("No bonuses!");
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Average mark: " + AverageMark);
            Console.WriteLine("Specialisation: " + Specialisation);
        }
        public new void ShowTypeName()
        {
            Console.WriteLine("My type is class Student!");
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public void PayTaxes()
        {
            Console.WriteLine("Paid some taxes!");
        }
    }

    public class Manager : Employee
    {
        public string ManagementArea { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person()
            {
                Name = "Bob",
                Birthdate = new DateTime(1990, 3, 6),
                Country = "Ukraine"
            };

            p.ShowInfo();

            Student st = new Student("Vova", 8.9F)
            {
                Birthdate = new DateTime(2004, 1, 17),
                Country = "Poland",
                Specialisation = "IT"
            };
            st.ShowInfo();

            Manager m = new Manager();
            // manager has all the members of the employee and person classes

            ///////////////// new vs override
            Person person = st;

            person.ShowTypeName(); // from Person class (new)
            person.ShowInfo();     // from Student class (override)

            //////////////// array of the classes which based on Person
            Person[] people = new Person[]
            {
                new Person("Vikrotia"),
                new Student("Oleg", 11.3F),
                new Employee(),
                new Manager()
            };
        }
    }
}

