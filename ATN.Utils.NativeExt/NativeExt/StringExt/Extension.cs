
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace ATN.Utils.NativeExt.StringExt
{
	public static class Extension
	{
	
		public static double ToDouble(this string str)
		{
			if (str == "")
				return 0;
		  	
			return Convert.ToDouble(str);

		}
        
		public static int ToInt32(this string str)
		{
			if (str == "")
				return 0;
			
			return Convert.ToInt32(str);
		}

        public static string Join2<T>(this IEnumerable<T> list, string separator)
        {
            return System.String.Join(separator, list);
        }



        /// <summary>
        /// ? - any character  (one and only one)
        /// * - any characters (zero or more)
        /// </summary>
        /// <param name="valueStr"></param>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static Boolean CompareWithWildcard(this string valueStr, string inputStr)
		{
			return Regex.IsMatch(valueStr, WildCardToRegular(inputStr));
		}
		
		private static string WildCardToRegular(string value)
		{
			return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$"; 
		}
	}
}
