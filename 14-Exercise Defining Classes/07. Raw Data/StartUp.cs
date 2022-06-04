using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            ReadData(number, cars);
            string command = Console.ReadLine();
            List<Car> outputData = new List<Car>();
            if (command == "fragile")
            {
                cars = cars.Where(x => x.Cargo1.Type == "fragile").Where(x => x.Tires1.Pressure.Any(x => x < 1)).ToList();
            }
            else if(command == "flammable")
            {
                cars = cars.Where(x => x.Engine1.Power > 250).ToList();
            }
            cars.ForEach(x => Console.WriteLine(x.Model));
        }

        private static void ReadData(int number, List<Car> cars)
        {
            for (int i = 0; i < number; i++)
            {
                string[] command = Console.ReadLine().Split();
                string model = command[0];
                int engineSpeed = int.Parse(command[1]);
                int enginePower = int.Parse(command[2]);
                int cargoWeight = int.Parse(command[3]);
                string cargoType = command[4];
                double tire1Pressure = double.Parse(command[5]);
                int tire1Age = int.Parse(command[6]);
                double tire2Pressure = double.Parse(command[7]);
                int tire2Age = int.Parse(command[8]);
                double tire3Pressure = double.Parse(command[9]);
                int tire3Age = int.Parse(command[10]);
                double tire4Pressure = double.Parse(command[11]);
                int tire4Age = int.Parse(command[12]);
                Engine engine = new Engine();
                Cargo cargo = new Cargo();
                Tires tire = new Tires();
                Car car = new Car(model, engine, cargo, tire);
                car.Tires1.Pressure = new List<double>();
                car.Tires1.Age = new List<int>();
                car.Engine1.Speed = engineSpeed;
                car.Engine1.Power = enginePower;
                car.Cargo1.Weight = cargoWeight;
                car.Cargo1.Type = cargoType;
                car.Tires1.Pressure.Add(tire1Pressure);
                car.Tires1.Age.Add(tire1Age);
                car.Tires1.Pressure.Add(tire2Pressure);
                car.Tires1.Age.Add(tire2Age);
                car.Tires1.Pressure.Add(tire3Pressure);
                car.Tires1.Age.Add(tire3Age);
                car.Tires1.Pressure.Add(tire4Pressure);
                car.Tires1.Age.Add(tire4Age);
                cars.Add(car);
            }
        }
    }
}
