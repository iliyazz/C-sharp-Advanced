using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Console.WriteLine(string.Join(", ", queue.Where(x => x % 2 == 0)));
        }
    }
}
