using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATN.Utils.NativeExt.RangeExt
{
    // need c# 8.0 or later
    //public static class Extension
    //{
    //    public static IEnumerable<int> ToEnumerable(this Range range)
    //    {
    //        if (range.Start.IsFromEnd || range.End.IsFromEnd)
    //        {
    //            throw new Exception("Only possitive indexes may be used for this");
    //        }

    //        return Enumerable.Range(range.Start.Value, range.End.Value);
    //    }

    //    public static int[] ToArray(this Range range)
    //    {
    //        return range.ToEnumerable().ToArray();
    //    }

    //    public static List<int> ToList(this Range range)
    //    {
    //        return range.ToEnumerable().ToList();
    //    }
    //}
}
