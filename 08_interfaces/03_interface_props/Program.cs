using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_interface_props
{
    interface IPerson
    {
        string LastName { get; set; }
        int Age { get; }
        string Gender { set; }
    }

    interface IIndexer
    {
        string this[int index]
        {
            get;
            set;
        }
        string this[string name]
        {
            get;
        }
    }

    enum Numbers { one, two, three, four, five };

    class IndexerClass : IIndexer
    {
        string[] _names = new string[5];

        public string this[int index]
        {
            get
            {
                return _names[index];
            }
            set
            {
                _names[index] = value;
            }
        }
        public string this[string name]
        {
            get
            {
                if (Enum.IsDefined(typeof(Numbers), name))
                    return _names[(int)Enum.Parse(typeof(Numbers), name)];
                else
                    return "";
            }
        }
        public IndexerClass()
        {
            // запись значений, используя индексатор
            // с целочисленным параметром
            this[0] = "Bob";
            this[1] = "Candice";
            this[2] = "Jimmy";
            this[3] = "Joey";
            this[4] = "Nicole";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IndexerClass indexerClass = new IndexerClass();
            Console.WriteLine("\t\tВывод значений\n");
            Console.WriteLine("Использование индексатора с целочисленным параметром:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(indexerClass[i]);
            }
            Console.WriteLine("\nИспользование индексатора со строковым параметром:");
            foreach (string item in Enum.GetNames(typeof(Numbers)))
            {
                Console.WriteLine(indexerClass[item]);
            }
        }
    }
}
