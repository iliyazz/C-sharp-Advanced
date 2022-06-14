using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int index;
        public ListyIterator(params T[] data)
        {
            collection = new List<T>(data);
            index = 0;
        }
        public bool HasNext() => index < collection.Count - 1;
        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                index++;
            }
            return canMove;
        }
        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine($"{collection[index]}");
        }

        public void PrintAll() => Console.WriteLine(string.Join(" ", collection));
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
