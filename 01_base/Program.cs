using System;
using System.Linq;

namespace _01_base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Data Types: 
                * reference types (classes) - can be null
                * value types (structures)  - cannot be null
            */

            int number = 10;
            string str = "hello";

            object obj = new object();
            obj.ToString();

            // Snippet: cw+TAB+TAB
            Console.WriteLine();

            Console.WriteLine("My number is " + number.ToString() + "!");
            Console.WriteLine($"My number is {number}!"); // interpolation

            string email = null; // empty reference
            //email.ToLower();   // error

            //Nullable<decimal> salary = null;
            decimal? salary = null;

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your height: ");

            float height = float.Parse(Console.ReadLine());

            Console.WriteLine($"Hello dear {name} your height: {height}cm");

            if (5 > 10)
            {
                // if condition return true
            }
            else
            {
                // if condition return false
            }

            switch (height)
            {
                case 0: // code...
                    break;
                default:
                    break;
            }

            for (int i = 0; i < 10; i++)
            {

            }

            while (true)
            {

            }

            do
            {

            } while (true);
        }
    }
}
