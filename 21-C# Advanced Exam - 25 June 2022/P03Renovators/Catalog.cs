using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;
        private string name;
        private int neededRenovators;
        private string project;

        public List<Renovator> Renovators { get => renovators; set => renovators = value; }
        public string Name { get => name; set => name = value; }
        public int NeededRenovators { get => neededRenovators; set => neededRenovators = value; }
        public string Project { get => project; set => project = value; }
        public int Count => renovators.Count;
        public Catalog(string name, int neededRenovators, string project)
        {
            Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else if (renovators.Count() >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            if (renovator == null)
            {
                return false;
            }
            renovators.Remove(renovator);
            return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = renovators.Count();
            renovators.RemoveAll(x => x.Type == type);
            count -= renovators.Count();
            return count;
        }
        public Renovator HireRenovator(string name)
        {

            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            if (renovator == null)
            {
                return null;
            }
            renovator.Hired = true;
            return renovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> workingRenovators = new List<Renovator>();
            foreach (var renovator in renovators)
            {
                if (renovator.Days >= days)
                {
                    workingRenovators.Add(renovator);
                }
            }
            return workingRenovators;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {project}:")
                .AppendLine(string.Join(Environment.NewLine, renovators.Where(x => x.Hired == false)));
            return sb.ToString().TrimEnd();
        }
    }
}
