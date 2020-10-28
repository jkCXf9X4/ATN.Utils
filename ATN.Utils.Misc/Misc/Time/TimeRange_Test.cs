using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATN.Utils.Time
{
    
    public class TimeRange_Test
    {
        [Fact]
        public void EachSpan_RangeSpanOneDay_CorrectClassification()
        {
            var range = new TimeRange(new System.DateTime(2018, 5, 18), new System.DateTime(2018, 5, 20), new TimeSpan(1, 0, 0, 0));

            var list = range.EachSpanRange().ToList();

            var checkList = new List<TimeRange>()
            {
                new TimeRange(new System.DateTime(2018, 5, 18), new System.DateTime(2018, 5, 19), new TimeSpan(1, 0, 0, 0)),
                new TimeRange(new System.DateTime(2018, 5, 19), new System.DateTime(2018, 5, 20), new TimeSpan(1, 0, 0, 0))
            };

            Assert.Equal(checkList, list);
        }

        [Fact]
        public void EachSpan_RangeSpan11Hours_CorrectClassification()
        {
            var range = new TimeRange(new System.DateTime(2018, 5, 19), new System.DateTime(2018, 5, 20), new TimeSpan(0, 11, 0, 0));

            var list = range.EachSpanRange().ToList();

            var checkList = new List<TimeRange>()
            {
                new TimeRange(new System.DateTime(2018, 5, 19,0,0,0), new System.DateTime(2018, 5, 19, 11,0,0), new TimeSpan(11, 0, 0)),
                new TimeRange(new System.DateTime(2018, 5, 19,11,0,0), new System.DateTime(2018, 5, 19,22,0,0), new TimeSpan(11, 0, 0)),
                new TimeRange(new System.DateTime(2018, 5, 19,22,0,0), new System.DateTime(2018, 5, 20,0,0,0), new TimeSpan(2, 0, 0))
            };

            Assert.Equal(checkList, list);
        }

        [Fact]
        public void EachSpan_RangeSpan1day_CorrectClassification()
        {
            var range = new TimeRange(
                new System.DateTime(2018, 5, 19),
                new System.DateTime(2018, 5, 20, 5, 0, 0),
                new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0));

            var list = range.EachSpanRange().ToList();

            var checkList = new List<TimeRange>()
            {
                new TimeRange(new System.DateTime(2018, 5, 19,0,0,0), new System.DateTime(2018, 5, 19, 23,0,0), new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0)),
                new TimeRange(new System.DateTime(2018, 5, 20, 0,0,0), new System.DateTime(2018, 5, 20, 23, 0,0), new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0)),
                new TimeRange(new System.DateTime(2018, 5, 20, 00,0,0), new System.DateTime(2018, 5, 20, 5,0,0), new TimeSpan(hours: 5, 0, 0))
            };

            Assert.Equal(checkList, list);
        }

        [Fact]
        public void EachSpan_SingleRangeSpanOneDaySpanToLarge_CorrectClassification()
        {
            var range = new TimeRange(new System.DateTime(2018, 5, 19), new System.DateTime(2018, 5, 20), new TimeSpan(0, 36, 0, 0));

            var list = range.EachSpanRange().ToList();

            var checkList = new List<TimeRange>()
            {
                new TimeRange(new System.DateTime(2018, 5, 19,0,0,0), new System.DateTime(2018, 5, 20, 0,0,0), new TimeSpan(24, 0, 0)),
            };

            Assert.Equal(checkList, list);
        }

        [Fact]
        public void IsSpanShortened_Yes_True()
        {
            var start = new System.DateTime(2018, 5, 18);
            var thru = new System.DateTime(2018, 5, 19);
            var span = new TimeSpan(72, 0, 0);

            var range = new TimeRange(start, thru, span);

            Assert.True(range.IsLastSpanShortened);
        }


        [Fact]
        public void IsMultipleSpan_SpanExtendedBeyond_False()
        {
            var start = new System.DateTime(2018, 5, 18);
            var thru = new System.DateTime(2018, 5, 19);
            var span = new TimeSpan(72, 0, 0);

            var range = new TimeRange(start, thru, span);

            Assert.False(range.IsMultipleSpan);
        }

        [Fact]
        public void IsMultipleSpan_SpanDoesNotExtendedBeyond_True()
        {
            var start = new System.DateTime(2018, 5, 18);
            var thru = new System.DateTime(2018, 5, 19);
            var span = new TimeSpan(12, 0, 0);

            var range = new TimeRange(start, thru, span);

            Assert.True(range.IsMultipleSpan);
        }

        [Fact]
        public void IsMultipleSpan_MultipleSpans_True()
        {
            var start = new System.DateTime(2018, 5, 18);
            var thru = new System.DateTime(2018, 5, 19);
            var span = new TimeSpan(6, 0, 0);

            var range = new TimeRange(start, thru, span);

            Assert.True(range.IsMultipleSpan);
        }


        [Fact]
        public void NrOfSpans_4Spans_CorrectClassification()
        {
            var range = new TimeRange(new System.DateTime(2018, 5, 18), new System.DateTime(2018, 5, 20), new TimeSpan(0, 12, 0, 0));

            var nrSpans = range.NrOfTimeSpans;

            Assert.Equal(4, nrSpans);
        }
    }
}