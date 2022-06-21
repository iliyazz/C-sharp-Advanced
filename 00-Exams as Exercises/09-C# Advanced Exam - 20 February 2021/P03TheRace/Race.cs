using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private string name;
        private int capacity;
        private List<Racer> data;

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public List<Racer> Data { get => data; set => data = value; }

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Racer>();
        }
        public int Count { get => Data.Count; }
        public void Add(Racer Racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            Racer current = Data.FirstOrDefault(x => x.Name == name);
            if (current != null)
            {
                data.Remove(current);
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            Racer current = Data.OrderBy(x => x.Age).Last();
            return current;
        }
        public Racer GetRacer(string name)
        {
            Racer current = Data.FirstOrDefault(x => x.Name == name);
            return current;
        }
        public Racer GetFastestRacer()
        {
            Racer current = Data.OrderBy(x => x.Car.Speed).Last();
            return current;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:")
                .AppendLine(string.Join(Environment.NewLine, Data));
            return sb.ToString().TrimEnd();
            
        }

    }
}
