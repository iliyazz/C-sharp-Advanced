using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;
        public Box()
        {
            this.list = new List<T>();
        }
        public void Add(T item)
        {
            this.list.Add(item);
        }
        public int Count
        {
            get { return this.list.Count; }
        }
        public T Remove()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("The box is empty.");
            }
            var lastElement = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            return lastElement;
        }
    }
}
