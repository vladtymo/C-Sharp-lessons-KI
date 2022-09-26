using System;
using System.IO;

namespace _02_files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string text = File.ReadAllText($"{desktopPath}/123.txt");

            Console.WriteLine($"Text length: {text.Length}");

            string[] words = text.Split(' ', ',', '.', '!', '?');
            Console.WriteLine($"Words count: {words.Length}");
        }
    }
}
