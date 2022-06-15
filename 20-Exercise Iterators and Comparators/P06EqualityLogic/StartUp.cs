using System;
using System.Collections.Generic;

namespace P06EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hasSet = new HashSet<Person>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var cmdArg = Console.ReadLine().Split();
                var person = new Person(cmdArg[0], int.Parse(cmdArg[1]));
                sortedSet.Add(person);
                hasSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hasSet.Count);
        }
    }
}
