using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string token = string.Empty;
            List < Tire > tiresList = new List < Tire > ();
            while ((token = Console.ReadLine()) != "No more tires")
            {
                int[] currentYear = new int[4];
                double[] currentPressure = new double[4];
                string[] tokens = token.Split();
                for (int i = 0; i < 8; i += 2)
                {
                    currentYear[i / 2] = int.Parse(tokens[i]);
                    currentPressure[i / 2] = double.Parse(tokens[i + 1]);
                }
                Tire currenTires = new Tire(currentYear, currentPressure);
                tiresList.Add(currenTires);
            }
            List<Engine> engineList = new List<Engine> ();
            while ((token = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = token.Split();
                int currentHorsePower = int.Parse(tokens[0]);
                double currentCubicCapacity = double.Parse(tokens[1]);
                Engine currenEngin = new Engine(currentHorsePower, currentCubicCapacity);
                engineList.Add (currenEngin);
            }
            List<Car> carList = new List<Car> ();

            List<Car> cars = new List<Car> ();
            //int counter = 0;
            while ((token = Console.ReadLine()) != "Show special")
            {
                string[] tokens = token.Split();
                string currenMake = tokens[0];
                string currenModel = tokens[1];
                int currenYear = int.Parse(tokens[2]);
                double currenFuelQuantity = double.Parse(tokens[3]);
                double currenFuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);
                Car currentCar = new Car (currenMake, currenModel, currenYear, currenFuelQuantity, currenFuelConsumption, engineList[engineIndex], tiresList[tiresIndex]);
                carList.Add (currentCar);
            }

            carList.RemoveAll(x => x.Year < 2017 || x.Engine.HorsePower <= 330 || x.Tires.Pressure.Sum() < 9 || x.Tires.Pressure.Sum() > 10);
            //if (carList.Any())
            //{

            //}
            carList.ForEach(x => x.Drive(20));
            carList.ForEach(x => Console.WriteLine(x.WhoAmI()));
        }

    }
}
