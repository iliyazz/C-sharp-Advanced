using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 0;
            int sum = 0;
            int stackNumber = stack.Count;
            while(stack.Count != 0)
            {
                if (sum + stack.Peek() < rackCapacity )
                {
                    sum += stack.Pop();
                    if (stack.Count == 0)
                    {
                        rackCount++;
                        break;
                    }
                }
                else if (sum + stack.Peek() == rackCapacity)
                {
                    stack.Pop();
                    rackCount++;
                    sum = 0;
                }
                else
                {
                    rackCount++;
                    sum = 0;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
