using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private string name;
        private int capacity;
        private List<Ski> data;

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public List<Ski> Data { get => data; set => data = value; }
        public int Count { get => Data.Count; }

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski != null)
            {
                Data.Remove(ski);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (Data.Count > 0)
            {
                Ski ski = Data.OrderBy(x => x.Year).Last();
                return ski;
            }
            return null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return ski;
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:")
                .AppendLine(string.Join(Environment.NewLine, Data).TrimEnd());
            return sb.ToString().TrimEnd();
        }
    }
}
