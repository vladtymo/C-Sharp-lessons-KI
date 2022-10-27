using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_inherit
{
    interface IA
    {
        void A1();
    }
    interface IB
    {
        void B1();
        void B2();
    }
    interface IC : IA, IB
    {
        void C1();
    }
    class InherInterface : IC
    {
        public void A1()
        {
            Console.WriteLine("Method A1");
        }

        public void B1()
        {
            Console.WriteLine("Method B1");
        }

        public void B2()
        {
            Console.WriteLine("Method B2");
        }
        public void C1()
        {
            Console.WriteLine("Method C1");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InherInterface obj = new InherInterface();

            obj.A1();
            obj.B1();
            obj.B2();
            obj.C1();
        }
    }
}
