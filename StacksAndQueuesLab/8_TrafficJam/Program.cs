using System;
using System.Collections.Generic;

namespace _8_TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int numberOfPassedCars = int.Parse(Console.ReadLine());
            int totalNumberOfPassedCars = 0;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    for (int i = 0; i < numberOfPassedCars; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            totalNumberOfPassedCars++;
                        }
                    }
                }
            }
            Console.WriteLine($"{totalNumberOfPassedCars} cars passed the crossroads.");
        }
    }
}
