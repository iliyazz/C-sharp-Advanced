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
        public Person GetOldestMember()
        {
            int maxAge = this.familyMembers.Select(p => p.Age).Max();
            Person currentPerson = new Person();
            currentPerson = familyMembers.First(x => x.Age == maxAge);
            return currentPerson;
        }
    }
}
