using System;
using System.Collections.Generic;

namespace _6_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    Console.WriteLine(string.Join(System.Environment.NewLine, queue));
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
