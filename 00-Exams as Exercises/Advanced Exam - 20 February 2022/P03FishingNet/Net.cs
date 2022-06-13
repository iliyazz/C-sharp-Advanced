using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly ICollection<Fish> fish;
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => this.fish.Count;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) ||
                fish.Lenght <= 0 ||
                fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            Fish currentFish = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (currentFish != null)
            {
                return this.fish.Remove(currentFish);
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            return this.fish.FirstOrDefault(x => x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            double maxLenght = this.fish.Max(x => x.Lenght);
            Fish longest = this.fish.FirstOrDefault(x => x.Lenght == maxLenght);
            return longest;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var item in Fish.OrderByDescending(x => x.Lenght))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
