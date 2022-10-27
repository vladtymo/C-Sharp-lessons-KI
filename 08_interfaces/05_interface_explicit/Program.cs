using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_name_concealment
{
    interface IA
    {
        void Show();
    }
    interface IB
    {
        void Show();
    }
    interface IC
    {
        void Show();
    }
    public class ImplicitRealization : IA, IB, IC
    {
        public void Show()
        {
            Console.WriteLine("Base Realization!");
        }
    }

    class ExplicitRealization : IA, IB, IC
    {
        // private method with explicit implement
        void IA.Show()
        {
            Console.WriteLine("Interface IA");
        }
        void IB.Show()
        {
            Console.WriteLine("Interface IB");
        }
        public void Show()
        {
            Console.WriteLine("Interface IC");
        }
        private void GlobalShow()
        {
            ((IA)this).Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Implicit
            ImplicitRealization ir = new ImplicitRealization();

            ir.Show();

            IA iA = ir;
            iA.Show();
            ((IB)ir).Show();
            IC iC = ir;
            iC.Show();

            // Explicit
            ExplicitRealization er = new ExplicitRealization();

            er.Show(); // вызов метода интерфейса IC неявно

            ((IA)er).Show(); // вызов метода интерфейса IA явно

            IB iB = new ExplicitRealization();
            iB.Show(); // вызов метода интерфейса IB через ссылку
        }
    }
}