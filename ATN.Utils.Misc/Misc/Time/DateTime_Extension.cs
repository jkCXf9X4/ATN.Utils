using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ATN.Utils.Time
{
    public static class DateTimeExtension
    {
        public static string ToOandaDateFormat(this DateTime time, DatetimeFormat format = DatetimeFormat.RFC3339)
        {
            // look into doing this within the JsonSerializer so that objects can use DateTime instead of string

            if (format == DatetimeFormat.RFC3339)
                return XmlConvert.ToString(time, "yyyy-MM-ddTHH:mm:ssZ");
            else if (format == DatetimeFormat.Unix)
                return ((int)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
            else
                throw new ArgumentException(string.Format("The value ({0}) of the format parameter is invalid.", (short)format));
        }
    }
}
