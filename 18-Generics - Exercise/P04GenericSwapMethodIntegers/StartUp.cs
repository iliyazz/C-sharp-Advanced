using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (int i = 0; i < number; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.Add(input);
            }
            var box = new Box<int>(list);
            var indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
