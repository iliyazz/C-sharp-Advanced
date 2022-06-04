using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine1;
        private Cargo cargo1;
        private Tires tires1;
        public string Model { get { return model; } set { model = value; } }
        public Engine Engine1 { get { return engine1; } set { engine1 = value; } }
        public Cargo Cargo1 { get { return cargo1; } set { cargo1 = value; } }
        public Tires Tires1 { get { return tires1; } set { tires1 = value; } }

        public Car()
        {

        }
        public Car(string model, Engine engine1, Cargo cargo1, Tires tires1)
            :this()
        {
            Model = model;
            this.engine1 = new Engine();
            this.cargo1 = new Cargo();
            this.tires1 = new Tires();
        }

    }
}
