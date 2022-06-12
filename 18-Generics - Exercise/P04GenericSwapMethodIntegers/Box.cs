using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box<T>
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
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
                //sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> elements, int index1 ,int index2)
        {
            T temporaryElement = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temporaryElement;
        }
    }
}
