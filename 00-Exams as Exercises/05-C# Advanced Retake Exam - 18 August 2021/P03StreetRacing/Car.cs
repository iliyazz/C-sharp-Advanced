﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        private string make;
        private string model;
        private string licensePlate;
        private int horsePower;
        private double weight;

        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public string LicensePlate { get => licensePlate; set => licensePlate = value; }
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public double Weight { get => weight; set => weight = value; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Make: {Make}" + Environment.NewLine).
            Append($"Model: {Model}" + Environment.NewLine).
            Append($"License Plate: {LicensePlate}" + Environment.NewLine).
            Append($"Horse Power: {HorsePower}" + Environment.NewLine).
            Append($"Weight: {Weight}");
            return sb.ToString().TrimEnd();
        }
    }
}
