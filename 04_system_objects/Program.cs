using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_system_objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////// String
            
            string str = "Hello, how are you?";

            string starline = new string('#', 10);
            Console.WriteLine(starline);

            str.EndsWith('?');   // true
            str.StartsWith("!"); // false

            str.Substring(7, 3); // how

            str.IndexOf('o');    // 4
            str.LastIndexOf('o');// 16

            str.Contains("how");   // true
            str.Replace('?', '!'); // ...you!

            Console.WriteLine("String length: " + str.Length);

            string newStr = str + " Blabla. " + starline;
            Console.WriteLine(newStr);

            string[] words = str.Split(new char[] { ' ', ',', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("--- Words ---");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            ////////////////////////// Array

            int[] numbers = { 5, 1, 7, -3, 0, 13, 45 };

            // var - type auto definition

            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(string.Join("/", numbers));
         
            //////////////////////// List

            List<double> numberList = new List<double>() { 33.8, 50, 0, 2.5 };

            numberList.Add(77);
            numberList.Add(4.03);

            Console.WriteLine("List size: " + numberList.Count);

            numberList.Sort();

            //foreach (var item in numberList)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            numberList.ForEach((i) => { Console.Write(i + " "); }); Console.WriteLine();

            numberList.RemoveAt(0);  // remove first (by index)
            numberList.Remove(50); // remove 50 (by value)

            numberList.ForEach((i) => { Console.Write(i + " "); }); Console.WriteLine();

            var result = numberList.Find((i) => i > 10);

            Console.WriteLine(result);

            //////////////////////// Dictionary
            Dictionary<string, int> codes = new Dictionary<string, int>()
            {
                ["Rivne"] = 33055,
                ["Lviv"] = 56770,
                ["Kyiv"] = 19900,
                ["Poltava"] = 33033
            };

            Console.WriteLine("Rivne ZIP code: " + codes["Rivne"]);
            codes["Rivne"] = 25000;
            Console.WriteLine("Rivne ZIP code: " + codes["Rivne"]);

            foreach (var key in codes.Keys)
            {
                Console.WriteLine(key);
            }
            foreach (var value in codes.Values)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Is Kharkiv key exists - " + codes.ContainsKey("Kharkiv"));
            Console.WriteLine("Is 19900 value exists - " + codes.ContainsValue(19900));

            // TODO: investigate other collection types (Dictionary, Stack, Queue, HashSet...)
        }
    }
}
