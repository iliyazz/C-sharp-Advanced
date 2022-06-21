using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Car
    {
        private string name;
        private int speed;

        public string Name { get => name; set => name = value; }
        public int Speed { get => speed; set => speed = value; }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }
}
