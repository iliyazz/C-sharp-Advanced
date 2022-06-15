using System;
using System.Collections.Generic;

namespace P05ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                var cmdArg = command.Split();
                string personName = cmdArg[0];
                int personAge = int.Parse(cmdArg[1]);
                string personTown = cmdArg[2];
                persons.Add(new Person(personName, personAge, personTown));
            }
            var index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var notEqual = 0;
            foreach (var person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {persons.Count}");
            }
        }
    }
}
