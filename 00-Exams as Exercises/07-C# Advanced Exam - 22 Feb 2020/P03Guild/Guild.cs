using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    internal class Guild
    {
        private List<Player> roster;
        private string name;
        private int capacity;

        public List<Player> Roster { get => roster; set => roster = value; }
        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Count { get => Roster.Count; }

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Roster = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            if(Roster.Count < Capacity) Roster.Add(player);
        }
        public bool RemovePlayer(string name)
        {
            Player current = Roster.FirstOrDefault(x => x.Name == name);
            if (current  == null)
                return false;
            Roster.Remove(current);
            return true;
        }
        public void PromotePlayer(string name)
        {
            Player current = Roster.FirstOrDefault(x => x.Name == name);
            if (current != null && current.Rank != "Member")
            {
                current.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player current = Roster.FirstOrDefault(x => x.Name == name);
            if (current != null && current.Rank == "Member")
            {
                current.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> result = new List<Player>();
            foreach (var item in Roster)
            {
                if (item.Class == @class)
                {
                    result.Add(item);
                }
            }
            Roster.RemoveAll(x => x.Class == @class);
            return result.ToArray();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}")
                .AppendLine(string.Join(Environment.NewLine, roster));
            return sb.ToString().TrimEnd();
        }

    }
}
