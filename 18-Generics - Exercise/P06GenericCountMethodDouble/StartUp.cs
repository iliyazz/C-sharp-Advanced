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
            var list = new List<double>();
            for (int i = 0; i < number; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }
            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOfElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
