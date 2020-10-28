using ATN.Utils.MathExt.Numerical;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Time
{
    public class CyclicTime
    {
        const DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

        readonly DateTime dt;

        public CyclicTime(DateTime dt)
        {
            this.dt = dt;
        }

        public bool IsWeekend
        {
            get
            {
                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                    return true;
                return false;
            }
        }

        public int[] GetOneHotWeekday()
        {
            var oneHot = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            var day = (int)dt.DayOfWeek;

            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                day = 7;
            }

            oneHot[day - 1] = 1;

            return oneHot;
        }

        public int[] GetOneHotMonth()
        {
            var oneHot = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            oneHot[dt.Month - 1] = 1;

            return oneHot;
        }

        public UnitCircle GetCyclicDay()
        {
            var portionOfDay = dt.TimeOfDay.TotalSeconds / Constants.SecondsInDay;

            return new UnitCircle(portionOfDay);
        }

        public UnitCircle GetCyclicWeek()
        {
            var portionOfWeek = TimePassedCurrentWeek(dt).TotalSeconds / Constants.SecondsInWeek;

            return new UnitCircle(portionOfWeek);
        }

        public UnitCircle GetCyclicYear()
        {
            var portionOfYear = TimePassedCurrentYear(dt).TotalSeconds / Constants.SecondsInLeapYear;

            return new UnitCircle(portionOfYear);

        }

        public static TimeSpan TimePassedCurrentWeek(DateTime dateTime)
        {
            var date = dateTime.Date;
            var monday = date.Subtract(new TimeSpan((int)date.DayOfWeek - 1, 0, 0, 0));

            return dateTime - monday;
        }

        public static TimeSpan TimePassedCurrentYear(DateTime date)
        {
            var firstDay = new DateTime(date.Year, 1, 1, 0, 0, 0);

            return date - firstDay;
        }


    }

    public static class DateTimeExt
    {
        public static CyclicTime ToCyclicTime(this DateTime dt)
        {
            return new CyclicTime(dt);
        }
    }

}
