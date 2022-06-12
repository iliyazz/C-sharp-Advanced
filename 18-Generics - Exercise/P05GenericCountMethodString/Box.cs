using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Box
{
    public class Box<T> : IComparable<T> where T : IComparable //: IComparable<T> where T :IComparable<T>
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

        public int CompareTo(T other)
            => Element.CompareTo(other);
        public int CountOfElements<T>(List<T> list, T readline) where T : IComparable => list.Count(word => word.CompareTo(readline) > 0);

    }
}
