using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace ATN.Utils.MathExt
{
    public static class Extension
    {
        public static double ToRadians(this double degrees)
        {
            return (System.Math.PI / 180) * degrees;
        }
        
        public static double ToDegree(this double angle)
		{
		   return angle * (180.0 / System.Math.PI);
		}
    }
}
