#if NET5_0

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ATN.Utils.NativeExt.TupleExt
{

    public static class Extension
    {

        public static IEnumerable<(T, S)> ToTuples<T, S>(IEnumerable<T> items1, IEnumerable<S> items2)
        {
            List<(T, S)> list = new List<(T, S)>();

            var items1Enumerator = items1.GetEnumerator();
            var items2Enumerator = items2.GetEnumerator();

            while (items1Enumerator.MoveNext())
            {
                items2Enumerator.MoveNext();
                list.Add((items1Enumerator.Current, items2Enumerator.Current));
            }

            return list;
        }

        public static IEnumerable<(T, S)> ToTuples<T, S>(this (IEnumerable<T>, IEnumerable<S>) items)
        {
            return ToTuples(items.Item1, items.Item2);
        }
    }
}
#endif