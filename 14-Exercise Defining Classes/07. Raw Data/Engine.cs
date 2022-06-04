using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private int power;
        private int speed;

        public int Power { get { return power; } set { power = value; } }
        public int Speed { get { return speed; } set { speed = value; } }


        public Engine()
        {
        }
        public Engine(int power, int speed)
        :this()
        {
            this.Power = power;
            this.Speed = speed;
        }

    }
}
