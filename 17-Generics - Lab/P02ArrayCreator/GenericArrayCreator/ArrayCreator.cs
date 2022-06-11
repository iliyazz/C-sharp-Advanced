using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            var result = new T[lenght];
            for (int i = 0; i < lenght; i++)
            {
                result[i] = item;
            }
            return result;
        }
    }
}
