using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Box
{
    public class Box<T> : IComparable<T> where T : IComparable 
    {
        public Box(T element)
        {
            Element = element;
        }
        public Box(List<T> elements)
        {
            Elements = elements;
        }
        public T Element { get; private set; }
        public List<T> Elements { get; private set; }

        public int CountOfElements<T1>(List<T1> list, T1 readline) where T1 : IComparable => list.Count(word => word.CompareTo(readline) > 0);
        public int CompareTo(T other) => Element.CompareTo(other);

    }
}
