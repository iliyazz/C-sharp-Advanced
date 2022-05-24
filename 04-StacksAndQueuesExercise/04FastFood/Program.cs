using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orderQueue= new Queue<int>(orders);
            int beggestOrder = orderQueue.Max();
            Console.WriteLine(beggestOrder);
            while (true)
            {
                if (orderQueue.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
                if (orderQueue.Peek() > quantityOfTheFood)
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', orderQueue)}");
                    break;
                }
                else
                {
                    quantityOfTheFood -= orderQueue.Dequeue();
                }
            }
        }
    }
}
