using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;
       
        public Family()
        {
            this.familyMembers = new List<Person>();
        }
        public void  AddMember()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Person currentPerson = new Person();
                string[] input = Console.ReadLine().Split();
                currentPerson.Name = input[0];
                currentPerson.Age = int.Parse(input[1]);
                familyMembers.Add(currentPerson);
            }
        }
        public void PrintPeople(int limit)
        {
            List<Person> printPersons = new List<Person>();
            foreach (var item in familyMembers)
            {
                if (item.Age > limit)
                {
                    printPersons.Add(item);
                }
            }
            if (printPersons.Any())
            {
                foreach (var item in printPersons.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"{item.Name} - {item.Age}");
                }

            }
        }
    }
}
