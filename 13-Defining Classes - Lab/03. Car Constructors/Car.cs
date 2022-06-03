using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public Car()
        {
            this.make = "VW";
            this.model = "Golf";
            this.year = 2025;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            :this()
        {
            this.make = make;
            this.model = model;
            this.year = year;

        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public void Drive(double distance)
        {
            double consumption = distance * this.FuelConsumption;
            if (this.FuelQuantity >= consumption)
            {
                this.FuelQuantity -= consumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            string info =
            $"Make: {this.Make}\r\n" +
            $"Model: {this.Model}\r\n" +
            $"Year: {this.Year}\r\n" +
            $"Fuel: {this.FuelQuantity:F2}";
            return info;
        }
    }
}
