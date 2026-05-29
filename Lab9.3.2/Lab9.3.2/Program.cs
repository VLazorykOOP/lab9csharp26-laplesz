using System;
using System.Collections;
using System.IO;

namespace ArrayListTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a limit a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter a limit b: ");
            int b = int.Parse(Console.ReadLine());

            string filePath = @"D:\University\Ізгої\2 курс\2 семестр 2026\Крос-платформенне програмування\Lab9.3.2\Lab9.3.2\numbers3.txt";

            ArrayList inRange = new ArrayList();
            ArrayList lessThanA = new ArrayList();
            ArrayList greaterThanB = new ArrayList();

            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "12 5 25 10 3 40 18 1 50");
                    Console.WriteLine("Created test file 'numbers3.txt'.");
                }

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string content = sr.ReadToEnd();
                    string[] tokens = content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var token in tokens)
                    {
                        if (int.TryParse(token, out int number))
                        {
                            if (number >= a && number <= b)
                                inRange.Add(number);
                            else if (number < a)
                                lessThanA.Add(number);
                            else
                                greaterThanB.Add(number);
                        }
                    }
                }

                Console.WriteLine("\nProcessing result:");

                Console.WriteLine($"Numbers in the interval [{a}, {b}]:");
                PrintArrayList(inRange);

                Console.WriteLine($"Numbers less than {a}:");
                PrintArrayList(lessThanA);

                Console.WriteLine($"Numbers greater than {b}:");
                PrintArrayList(greaterThanB);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void PrintArrayList(ArrayList list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }
    }
}