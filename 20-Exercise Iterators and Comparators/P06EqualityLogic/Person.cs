﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P06EqualityLogic
{
    public class Person :IComparable<Person>
    {
        private string name;
        private int age;
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0) result = Age.CompareTo(other.Age);
            return result;
        }
        public override int GetHashCode() => Name.GetHashCode() ^ Age.GetHashCode();
        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if (other == null) return false;
            return Age == other.Age && Name == other.Name;
        }
        public override string ToString() => $"{Name} {Age}";
    }
}
