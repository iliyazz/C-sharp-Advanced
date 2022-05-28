using System;
using System.Collections.Generic;
using System.Linq;

namespace P03PeriodicTable
{
    internal class P03PeriodicTable
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                foreach (var item in input)
                {
                    set.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", set.OrderBy(x => x)));
        }
    }
}
