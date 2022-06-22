using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
           Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name);

            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(p => (p.Name == name && p.Owner == owner));

            if (pet != null)
            {
                return pet;
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            Pet pet = data.OrderByDescending(p => p.Age).FirstOrDefault();
            return pet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}