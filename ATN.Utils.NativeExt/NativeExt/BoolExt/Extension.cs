using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.NativeExt.BoolExt
{
    public static class Extension
    {
        public static double ToDouble(this bool b)
        {
            return Convert.ToDouble(b);
        }

    }
}
