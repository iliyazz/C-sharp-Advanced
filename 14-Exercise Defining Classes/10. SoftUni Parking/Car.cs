using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }
        public override string ToString()
        {

            string result = $"Make: {this.Make}{Environment.NewLine}";
            result += $"Model: {this.Model}{Environment.NewLine}";
            result += $"HorsePower: {this.HorsePower}{Environment.NewLine}";
            result += $"RegistrationNumber: {this.RegistrationNumber}";

            return result;

            //StringBuilder sb = new StringBuilder();
            //sb.Append($"Make: {Make}{Environment.NewLine}");
            //sb.Append($"Model: {Model}{Environment.NewLine}");
            //sb.Append($"HoursePower: {HoursePower}{Environment.NewLine}");
            //sb.Append($"RegistrationNumber: {RegistrationNumber}");
            //return sb.ToString();
        }
    }
}
