using System;
using System.Collections;
using System.IO;

namespace ArrayListTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\University\Ізгої\2 курс\2 семестр 2026\Крос-платформенне програмування\Lab9.3.1\Lab9.3\sample3.txt";

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Are you sure? Pretty sure. Are you sure? Throwing trash bag into space at work. Are you sure?");
                Console.WriteLine($"A test file has been created '{filePath}'.\n");
            }

            string text = File.ReadAllText(filePath);

            ArrayList vowelList = new ArrayList();

            string vowels = "aeiouyAEIOUYаеєиіїоуюяАЕЄИІЇОУЮЯ";

            foreach (char c in text)
            {
                if (vowels.Contains(c))
                {
                    vowelList.Add(c);
                }
            }

            Console.WriteLine("Vowels from the file in reverse order:");

            for (int i = vowelList.Count - 1; i >= 0; i--)
            {
                Console.Write(vowelList[i] + " ");
            }

            Console.WriteLine();
        }
    }
}