using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        private string name;
        private int capacity;

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public List<Employee> Data { get => data; set => data = value; }
        public int Count{ get => data.Count; }
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Employee>();
        }
        public void Add(Employee employee)
        {
            if(data.Count < capacity) { data.Add(employee); }
        }
        public bool Remove(string name)
        {
            Employee current = data.FirstOrDefault(e => e.Name == name);
            if(current == null) { return false; }
            data.Remove(current);
            return true;
        }
        public Employee GetOldestEmployee()
        {
            Employee current = Data.OrderBy(x => x.Age).Last();
            return current;
        }
        public Employee GetEmployee(string name)
        {
            Employee current = Data.FirstOrDefault(x => x.Name == name);
            return current;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}")
                .Append(string.Join(Environment.NewLine, Data));
            return sb.ToString().TrimEnd();
        }
    }
}
