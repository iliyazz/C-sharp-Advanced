using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        private string name;
        private int age;
        private string country;
        private Car car;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Country { get => country; set => country = value; }
        public Car Car { get => car; set => car = value; }

        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }
        public override string ToString()
        {
            return $"Racer: {name}, {age} ({country})";
        }
    }
}
