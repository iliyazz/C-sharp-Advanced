using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;
        public Parking(string type, int capacity)
        {
            Capacity = capacity;
            Type = type;
            Data = new List<Car>();
        }

        public string Type { get => type; set => type = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public List<Car> Data { get => data; set => data = value; }
        public int Count => data.Count;
        public void Add(Car car)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = Data.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
            if (car != null)
            {
                Data.Remove(car);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (Data.Count == 0)
            {
                return null;
            }
            Car car = Data.OrderByDescending(x => x.Year).FirstOrDefault();
            return car;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = Data.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault();
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:")
                .AppendLine(string.Join(Environment.NewLine, Data));
            return sb.ToString().TrimEnd();
        }
    }
}
