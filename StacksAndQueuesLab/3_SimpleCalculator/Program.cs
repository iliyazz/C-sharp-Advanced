using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
            int sum = int.Parse(stack.Pop());
            while(stack.Count > 0)
            {
                if (stack.Peek() == "+")
                {
                    stack.Pop();
                    sum += int.Parse(stack.Pop());
                }
                else
                {
                    stack.Pop();
                    sum -= int.Parse(stack.Pop());

                }
            }
            Console.WriteLine(sum);
        }
    }
}
