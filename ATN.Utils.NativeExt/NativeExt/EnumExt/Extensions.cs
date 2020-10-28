
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ATN.Utils.NativeExt.ObjectExt;


namespace ATN.Utils.NativeExt.EnumExt
{
    public static class Extension
    {
        #if NET5_0
        public static int MaxIndex<T>(this IEnumerable<T> source)
        {
            var (Number, Index) = source.Select((n, i) => (Number: n, Index: i)).Max();

            return Index;
        }
        #endif

        public static T Find<T>(this T i, string identifier) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " must be an enumerated type");
            }

            return (T)System.Enum.Parse(typeof(T), identifier);
        }
        public static void ForEachExt<T>(this IEnumerable<T> source, Action<T> action)
        {
            //var list = source.ToList();
            //for (int i = 0; i< source.Count(); i++)
            //    {
            //    action(list[i]);
            //}

            foreach (var item in source)
            {
                action(item);
            }
                
        }
        public static void ForEachVariable<T, S>(this IEnumerable<T> enumerable, string variableName, Func<S, S> func)
        {
            var variable = typeof(T).GetField(variableName);

            enumerable.ForEachExt(x => variable.SetValue(x, func((S)variable.GetValue(x))));
        }

        public static void ForEachVariable<T, S>(this IEnumerable<T> enumerable, Func<T, string> nameFunc, Func<S, S> func)
        {
            string variableName = nameFunc(enumerable.First());

            var variable = typeof(T).GetField(variableName);

            enumerable.ForEachExt(x => variable.SetValue(x, func((S)variable.GetValue(x))));
        }


        public static IEnumerable<T> CreateCollection<T>(this T with, int nr)
        {
            return Enumerable.Range(0, nr).Select(i => with.GetDeepCopy());
        }

        /// <summary>
        /// Use Enumerable.Cast(IEnumerable) Method instead
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<string> ToStrings<T>(this IEnumerable<T> obj)
        {
            return obj.Select(i => i.ToString());
        }

        public static bool Compare1<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            var firstNotSecond = a.Except(b).ToList();
            var secondNotFirst = b.Except(a).ToList();

            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        public static IEnumerable<T> RemoveAtWithNegative<T>(this IEnumerable<T> a, int index)
        {
            var list = a.ToList();
            if (index >= 0)
            {
                list.RemoveAt(index);
            }
            else
            {
                list.RemoveAt(a.Count() + index);
            }
            return list;
        }

        public static T SelectAtWithNegative<T>(this IEnumerable<T> a, int index)
        {
            if (index >= 0)
            {
                return a.ElementAt(index);
            }
            else
            {
                return a.ElementAt(a.Count() + index);
            }
        }



    }
}
