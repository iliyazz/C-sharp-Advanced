using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        private string name;
        private int age;
        private string owner;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Owner { get => owner; set => owner = value; }

        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }
        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
