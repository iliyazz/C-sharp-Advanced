using System;
using System.Collections.Generic;

namespace _7_HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            int number = int.Parse(Console.ReadLine());
            int counter = 1;
            while (queue.Count != 1)
            {
                if (counter < number)
                {
                    queue.Enqueue(queue.Dequeue());
                    counter++;
                }
                else if (counter == number)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    counter = 1;
                }
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
