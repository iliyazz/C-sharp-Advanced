using System;
using System.Collections.Generic;
using System.Text;

namespace P01GenericBoxOfString
{
    public class Box<T>
    {

        //constructor
        public Box(T element)
        {
            Element = element;
        }
        //property
        public T Element { get; private set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
