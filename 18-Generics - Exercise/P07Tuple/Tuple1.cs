using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 element1, T2 element2)
        {
            Element1 = element1;
            Element2 = element2;
        }
        public T1 Element1 { get; private set;}
        public T2 Element2 { get; private set; }

        public override string ToString()
        {
            return $"{Element1} -> {Element2}";
        }
    }
}
