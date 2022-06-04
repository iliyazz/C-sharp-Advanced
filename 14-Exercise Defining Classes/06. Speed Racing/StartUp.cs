using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int numberOfCar = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCar; i++)
            {
                Car car = new Car();
                string[] carData = Console.ReadLine().Split();
                car.Model = carData[0];
                car.FuelAmount = double.Parse(carData[1]);
                car.FuelConsumptionPerKilometer = double.Parse(carData[2]);
                cars.Add(car.Model, car);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                Car car = new Car();
                car.Drive(command, cars);
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Value.Model} {item.Value.FuelAmount:f2} {item.Value.TravelledDistance}");
            }
        }
    }
}
