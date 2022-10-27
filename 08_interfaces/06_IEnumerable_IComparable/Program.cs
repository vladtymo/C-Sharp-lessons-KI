using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_IEnumerable
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}";
        }
    }
    class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {BirthDate.ToShortDateString()}";
        }
        //public int CompareTo(object obj)
        //{
        //    if (obj is Student)
        //    {
        //        return this.BirthDate.CompareTo((obj as Student).BirthDate);
        //    }
        //    throw new ArgumentException();
        //}

        public int CompareTo(Student other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
    }
    class Auditory : IEnumerable
    {
        private Student[] students =
        {
            new Student {
                FirstName ="John",
                LastName ="Miller",
                BirthDate =new DateTime(1997,3,12),
                StudentCard =new StudentCard { Number=189356, Series="AB" }
            },
            new Student {
                FirstName ="Candice",
                LastName ="Leman",
                BirthDate =new DateTime(1998,7,22),
                StudentCard = new StudentCard { Number=345185, Series="XA" }
            },
            new Student {
                FirstName ="Joey",
                LastName ="Finch",
                BirthDate = new DateTime(1996,11,30),
                StudentCard = new StudentCard { Number=258322, Series="AA" }
            },
            new Student {
                FirstName ="Nicole",
                LastName ="Taylor",
                BirthDate = new DateTime(1996,5,10),
                StudentCard = new StudentCard { Number=513484, Series="AA" }
            }
        };

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students, comparer);
        }
    }

    class SurnameComparer : IComparer<Student>
    {
        //public int Compare(object x, object y)
        //{
        //    if (x is Student && y is Student)
        //    {
        //        return (x as Student).LastName.CompareTo((y as Student).LastName);
        //    }
        //    throw new NotImplementedException();
        //}
        public int Compare(Student x, Student y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
    class BirthdateComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.BirthDate.CompareTo(y.BirthDate);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Auditory auditory = new Auditory();

            Console.WriteLine("\n++++++++ student list +++++++ +\n");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }

            auditory.Sort();
            Console.WriteLine("\n++++++++ sorted student list by default +++++++ +\n");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }

            auditory.Sort(new BirthdateComparer());
            Console.WriteLine("\n++++++++ sorted student list by birth date +++++++ +\n");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }

            auditory.Sort(new SurnameComparer());
            Console.WriteLine("\n++++++++ sorted student list by surname +++++++ +\n");
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
        }
    }
}
