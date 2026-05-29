using System;
using System.Collections.Generic;
using System.IO;

namespace VowelReverser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\University\Ізгої\2 курс\2 семестр 2026\Крос-платформенне програмування\Lab9.1\Lab9.1\sample1.txt";

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Are you sure? Pretty sure. Are you sure? Throwing trash bag into space at work. Are you sure?");
                Console.WriteLine($"A test file has been created '{filePath}'.\n");
            }

            string text = File.ReadAllText(filePath);

            Stack<char> vowelStack = new Stack<char>();

            string vowels = "aeiouyAEIOUYаеєиіїоуюяАЕЄИІЇОУЮЯ";

            foreach (char c in text)
            {
                if (vowels.Contains(c))
                {
                    vowelStack.Push(c);
                }
            }

            Console.WriteLine("Vowels from the file in reverse order:");

            while (vowelStack.Count > 0)
            {
                Console.Write(vowelStack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}