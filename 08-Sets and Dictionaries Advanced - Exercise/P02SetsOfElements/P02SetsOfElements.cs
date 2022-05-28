using System;
using System.Collections.Generic;
using System.Linq;

namespace P02SetsOfElements
{
    internal class P02SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> set1 = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 0; i < input[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }
            var result = set1.Intersect(set2);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
