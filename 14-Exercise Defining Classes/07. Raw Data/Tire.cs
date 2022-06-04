using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Tires
    {
        private List<int> age;
        private List<double> pressure;
        public List<int> Age { get { return age; } set { age = value; } }
        public List<double> Pressure { get { return pressure; } set { pressure = value; } }
        public Tires()
        {

        }
        public Tires(List<int> age, List<double> pressure)
            :this()
        {
            Age = new List<int>();
            Pressure = new List<double>();

        }
    }
}
