using System;
using System.Collections.Generic;
using System.Linq;

namespace P02KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            //Func<string, string> printNamesFunc = name => "Sir " + name;
            //names.ForEach(x => Console.WriteLine(printNamesFunc(x)));
            Action<string> printNames = name => Console.WriteLine($"Sir { name}");
            names.ForEach(printNames);
        }
    }
}
