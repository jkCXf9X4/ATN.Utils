
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

using ATN.Utils.NativeExt.ObjectExt;


namespace ATN.Utils.NativeExt.ListExt
{
	public static class Extension
	{
        private static string GetCommaSeparatedList(this List<string> items, string delimiter = ";")
        {
            var str =  String.Join(delimiter, items);

            return str.Trim(delimiter.ToCharArray());
        }

        public static void Shuffle<T>(this List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
