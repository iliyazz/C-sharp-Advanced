using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }
            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();
            var count = box.CountOfElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
