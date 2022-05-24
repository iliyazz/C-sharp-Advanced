using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numberToQueue = input[0];
            int numberToDequeue = input[1];
            int numberToSearch = input[2];
            Queue<int> queue = new Queue<int>();
            int[] elementsToQueue = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < numberToQueue; i++)
            {
                queue.Enqueue(elementsToQueue[i]);
            }
            for (int i = 0; i < numberToDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(numberToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
