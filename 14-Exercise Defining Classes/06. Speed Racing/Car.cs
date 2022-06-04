using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model { get { return model; } set { model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double FuelConsumptionPerKilometer { get { return fuelConsumptionPerKilometer; } set { fuelConsumptionPerKilometer = value; } }

        public double TravelledDistance { get => travelledDistance; set => travelledDistance = value; }

        public Car()
        {
            this.travelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
            :this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = travelledDistance;
            
        }
        public void Drive(string command, Dictionary<string, Car> cars)
        
        {
            string[] cmdArg = command.Split();
            string carModel = cmdArg[1];
            int amountOfKm = int.Parse(cmdArg[2]);
            double consumtion = amountOfKm * cars[carModel].FuelConsumptionPerKilometer;
            if (cars[carModel].FuelAmount >= consumtion)
            {
                cars[carModel].FuelAmount -= consumtion;
                cars[carModel].travelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
