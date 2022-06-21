using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int thread = threads.Peek();
                int task = tasks.Peek();
                if (task == taskToBeKilled)
                {
                    break;
                }
                else if (thread >= task)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else 
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
            
        }
    }
}
