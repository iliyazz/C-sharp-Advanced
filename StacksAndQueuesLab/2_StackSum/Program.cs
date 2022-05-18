using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmd[0] == "add")
                {
                    stack.Push(int.Parse(cmd[1]));
                    stack.Push(int.Parse(cmd[2]));
                }
                else if (cmd[0] == "remove" && int.Parse(cmd[1]) <= stack.Count())
                {
                    for (int i = 0; i < int.Parse(cmd[1]); i++)
                    {
                        stack.Pop();
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
