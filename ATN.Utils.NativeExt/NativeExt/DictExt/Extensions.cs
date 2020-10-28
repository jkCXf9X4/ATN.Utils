using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.NativeExt.DictExt
{
    public static class Extensions
    {
        public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            T key = default;

            key = dict.FirstOrDefault(x => EqualityComparer<W>.Default.Equals(x.Value, val)).Key;

            return key;
        }
    }
}
