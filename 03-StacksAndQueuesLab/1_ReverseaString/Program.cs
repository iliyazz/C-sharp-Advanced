using System;
using System.Collections.Generic;

namespace _1_ReverseaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>(Console.ReadLine());
            Console.WriteLine(string.Join("", stack));
        }
    }
}
