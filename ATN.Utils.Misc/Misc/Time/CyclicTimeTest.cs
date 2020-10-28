using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATN.Utils.Time
{

    public class CyclicTimePlotTest
    {
        [Fact]
        public void GetCyclicHour_HourInciment_Graph()
        {
            var X = new List<double>();
            var Y = new List<double>();

            for (int i = 0; i < 24; i++)
            {
                Time.CyclicTime ct = new CyclicTime(new DateTime(2018, 5, 1, i, 0, 0));
                var cyclicHour = ct.GetCyclicDay();
                X.Add(cyclicHour.X);
                Y.Add(cyclicHour.Y);
            }

            //ATN.Utils.Plot.GnuPlot.Set("xrange[-2:2]", "yrange[-2:2]", "xtics 0.01" );

            //ATN.Utils.Plot.GnuPlot.Plot(X.ToArray(), Y.ToArray(), "with points pt 3");

        }

    }

    
    public class CyclicTimeTest
    {
        [Fact]
        public void GetOneHotWeekday_Wensday_0010000()
        {
            var wensday = new CyclicTime(new DateTime(2018, 05, 23, 0, 0, 0));
            var oneHotref = new int[] { 0, 0, 1, 0, 0, 0, 0 };

            var onehot = wensday.GetOneHotWeekday();

            Assert.Equal(onehot, oneHotref);
        }

        [Fact]
        public void GetOneHotWeekday_Wensday_Fail0010000()
        {
            var wensday = new CyclicTime(new DateTime(2018, 05, 23, 0, 0, 0));
            var oneHotref = new int[] { 0, 0, 0, 1, 0, 0, 0 };

            var onehot = wensday.GetOneHotWeekday();

            Assert.NotEqual(onehot, oneHotref);
        }

        [Fact]
        public void GetOneHotMonth_May_Correct()
        {
            var wensday = new CyclicTime(new DateTime(2018, 05, 23, 0, 0, 0));
            var oneHotref = new int[] { 0, 0, 0, 0, 1, 0, 0 , 0, 0, 0, 0, 0};

            var onehot = wensday.GetOneHotMonth();

            Assert.Equal(onehot, oneHotref);
        }

        [Fact]
        public void GetOneHotMonth_May_FailIncorrect()
        {
            var wensday = new CyclicTime(new DateTime(2018, 05, 23, 0, 0, 0));
            var oneHotref = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            var onehot = wensday.GetOneHotMonth();

            Assert.NotEqual(onehot, oneHotref);
        }

        [Fact]
        public void TimePassedCurrentWeek_20180522_1Day()
        {
            var tuesday = new DateTime(2018, 5, 22, 0, 0, 0);

            var secondsPassed = CyclicTime.TimePassedCurrentWeek(tuesday).TotalSeconds;

            Assert.Equal(Constants.SecondsInDay, secondsPassed);
        }

        [Fact]
        public void TimePassedCurrentWeek_20180521_1Day()
        {
            var monday = new DateTime(2018, 5, 21, 5, 0, 0);

            var secondsPassed = CyclicTime.TimePassedCurrentWeek(monday).TotalSeconds;

            Assert.Equal(Constants.SecondsInHour * 5, secondsPassed);
        }

        [Fact]
        public void TimePassedCurrentYear_20180101_1Day()
        {
            var day = new DateTime(2018, 1, 2, 0, 0, 0);

            var secondsPassed = CyclicTime.TimePassedCurrentYear(day).TotalSeconds;

            Assert.Equal(Constants.SecondsInDay * 1, secondsPassed);
        }

        [Fact]
        public void TimePassedCurrentYear_20180120_20Day()
        {
            var day = new DateTime(2018, 1, 20, 0, 0, 0);

            var secondsPassed = CyclicTime.TimePassedCurrentYear(day).TotalSeconds;

            Assert.Equal(Constants.SecondsInDay * 19, secondsPassed);
        }
    }
}
