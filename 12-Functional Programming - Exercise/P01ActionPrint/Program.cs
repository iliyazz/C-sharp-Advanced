using System;
using System.Collections.Generic;
using System.Linq;

namespace P01ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            Action<string> printNames =  name => Console.WriteLine(name);
            names.ForEach(printNames);
        }
    }
}
