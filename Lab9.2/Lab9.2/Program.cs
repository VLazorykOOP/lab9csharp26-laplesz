using System;
using System.Collections.Generic;
using System.IO;

namespace QueueTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a limit a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter a limit b: ");
            int b = int.Parse(Console.ReadLine());

            string filePath = @"D:\University\Ізгої\2 курс\2 семестр 2026\Крос-платформенне програмування\Lab9.2\Lab9.2\numbers2.txt";

            Queue<int> inRange = new Queue<int>();
            Queue<int> lessThanA = new Queue<int>();
            Queue<int> greaterThanB = new Queue<int>();

            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "12 5 25 10 3 40 18 1 50");
                    Console.WriteLine("A test file has been created 'numbers2.txt'.");
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
                                inRange.Enqueue(number);
                            else if (number < a)
                                lessThanA.Enqueue(number);
                            else
                                greaterThanB.Enqueue(number);
                        }
                    }
                }

                Console.WriteLine("\nProcessing result:");

                Console.WriteLine($"Numbers in the range [{a}, {b}]: ---");
                PrintQueue(inRange);

                Console.WriteLine($"Numbers less than {a}: ---");
                PrintQueue(lessThanA);

                Console.WriteLine($"Numbers greater than {b}: ---");
                PrintQueue(greaterThanB);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
            }
        }

        static void PrintQueue(Queue<int> queue)
        {
            if (queue.Count == 0)
                Console.WriteLine("(empty)");

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine("\n");
        }
    }
}