
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace ATN.Utils.NativeExt.ArrayExt
{
    public static class Extension
    {

        public static void DebugStringArray(this string[][] a)
        {
            for (int row = 0; row < a.GetLength(0); row++)
            {
                Debug.WriteLine(System.String.Join(":", a[row]));
            }
        }

        public static void DebugStringArray(this string[] a)
        {
            Debug.WriteLine(System.String.Join(":", a));
        }

        public static T[] Fill<T>(this T[] originalArray, T with)
        {

            var newArray = (T[])originalArray.Clone();

            if (newArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = with;
            }
            return newArray;
        }

        public static void Shuffle<T>(this T[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }


    }
}
