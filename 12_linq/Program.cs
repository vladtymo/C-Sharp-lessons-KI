using System;
using System.Linq;

namespace _12_linq
{
    internal class Program
    {
        static void Show<T>(IEnumerable<T> array, string title = null)
        {
            if (title != null)
                Console.Write(title + ": ");
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 20, -3, 0, -9, 33, 10, 1, -2, 55, 120, 310, 70, 8 };

            Show(array, "Original array");

            //foreach (var item in array)
            //{
            //    if (item % 2 == 0)
            //        Console.WriteLine(item);
            //}
            
            // return array copy
            Show(array.Where(x => x % 2 == 0), "Filtered");

            Show(array.OrderBy(x => Math.Abs(x)), "Sorted");

            Show(array.Select(x => x * x), "Selected");

            // First(), Last() - throw an exception if no element was found
            // FirstOrDefault(), LastOrDefault() - return default value (0, false, null) if no element was found
            Console.WriteLine("First negative number: " + array.FirstOrDefault(x => x < -1000));
            Console.WriteLine("Last negative number: " + array.Last(x => x < 0));
        }
    }
}