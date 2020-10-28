using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Time
{
    public static class Constants
    {
        public const double SecondsInMinute = 60;
        public const double SecondsInHour = SecondsInMinute * 60;
        public const double SecondsInDay = SecondsInHour * 24;
        public const double SecondsInWeekdays = SecondsInHour * 5;
        public const double SecondsInWeek = SecondsInHour * 7;
        public const double SecondsInYear = SecondsInDay * 365;
        public const double SecondsInLeapYear = SecondsInDay * 366;
    }
}
