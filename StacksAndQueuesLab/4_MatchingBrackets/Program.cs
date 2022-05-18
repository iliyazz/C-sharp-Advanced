using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if(input[i] == ')')
                {
                    Console.WriteLine(input.Substring(stack.Peek(), i - stack.Pop() + 1));
                }
            }
        }
    }
}
