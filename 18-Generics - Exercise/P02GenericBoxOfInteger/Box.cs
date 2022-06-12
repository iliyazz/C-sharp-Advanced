using System;
using System.Collections.Generic;
using System.Text;

namespace P02GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }
        public T Element { get; private set; }
        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
