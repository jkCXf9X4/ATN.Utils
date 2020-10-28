using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.NativeExt.ArrayExt
{
    public static class ArrayInitializer
    {
        public static T[] Initializer<T>(int size, Func<T> constructor)
        {
            T[] array = new T[size];
            for(int i = 0; i < size; i++)
            {
                array[i] = constructor();
            }
            return array;
        }

    }
}
