using System;
using System.Runtime.Intrinsics.Arm;

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("1 - Open file");
            Console.WriteLine("2 - Create new file");
            Console.WriteLine("0 - Finish program");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Write("Enter the file path: ");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                Console.Clear();
                Console.WriteLine(file.ReadToEnd());
            }
            
            Thread.Sleep(3000);
            
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter your text below\n");

            string text = "";

            do
            {
                text += Console.ReadLine() + "\n";
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            // Console.Clear();
            // Console.WriteLine(text);
            Console.WriteLine();
            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();

            Console.Write("Enter the file name: ");
            var fileName = Console.ReadLine();
            Console.Write("Enther the path to save the file: ");
            var path = Console.ReadLine() + fileName;

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"The file {path} was saved with successfully.");

            Thread.Sleep(3000);

            Menu();
        }
    }
}