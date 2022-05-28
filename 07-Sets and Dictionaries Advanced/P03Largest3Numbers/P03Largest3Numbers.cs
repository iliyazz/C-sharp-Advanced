using System;
using System.Linq;

namespace P03Largest3Numbers
{
    internal class P03Largest3Numbers
    {
        static void Main(string[] args)
        {
            int[] inputList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", inputList.OrderByDescending(x => x).Take(3)));
        }
    }
}
