using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;
        private List<Car> participants;

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Laps { get => laps; set => laps = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int MaxHorsePower { get => maxHorsePower; set => maxHorsePower = value; }
        public List<Car> Participants { get => participants; set => participants = value; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }
        public int Count
        {
            get => participants.Count;
        }
        public void Add(Car car)
        {
            if (!participants.Any(x => x.LicensePlate == car.LicensePlate))
            {
                if ((Count < this.Capacity) && (car.HorsePower <= this.MaxHorsePower))
                {
                    participants.Add(car);
                }
            }
            
        }
        public bool Remove(string licensePlate)
        {
            if (participants.Any(x => x.LicensePlate == licensePlate))
            {
                participants.Remove(participants.FirstOrDefault(x => x.LicensePlate == licensePlate));
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car car = null;
            if (participants.Any(x => x.LicensePlate == licensePlate))
            {
                car = participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            }
            return car;
        }
        public Car GetMostPowerfulCar()
        {
            if (participants.Count == 0) return null;
            return participants.OrderBy(x => x.HorsePower).Last();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})")
                .AppendLine(string.Join(Environment.NewLine, participants));
            return sb.ToString().TrimEnd();
        }
    }
}
