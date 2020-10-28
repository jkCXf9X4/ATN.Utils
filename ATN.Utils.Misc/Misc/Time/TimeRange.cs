using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.Time
{
    public class TimeRange : IEquatable<TimeRange>
    {
        public readonly System.DateTime StartTime;
        public readonly System.DateTime EndTime;
        public readonly TimeSpan Time_Span;

        public TimeRange(System.DateTime startTime, System.DateTime endTime)
        {
            if (startTime > endTime)
                throw new ArgumentException();

            this.StartTime = startTime;
            this.EndTime = endTime;

            this.Time_Span = endTime - startTime;
        }

        public TimeRange(System.DateTime startTime, System.DateTime endTime, TimeSpan timeSpan) : this(startTime, endTime)
        {
            this.Time_Span = timeSpan;
        }

        public double NrOfTimeSpans
        {
            get
            {
                var fullSpan = EndTime - StartTime;
                return fullSpan.TotalSeconds / Time_Span.TotalSeconds;
            }
        }

        public double NrOfFullTimeSpans
        {
            get
            {
                return System.Math.Floor(NrOfTimeSpans);
            }
        }

        public bool IsOneSpan
        {
            get
            {
                if (NrOfTimeSpans == 1)
                    return true;
                return false;
            }
        }

        public bool IsMultipleSpan
        {
            get
            {
                if (NrOfTimeSpans > 1)
                    return true;
                return false;
            }
        }

        public bool IsLastSpanShortened
        {
            get
            {
                if (NrOfTimeSpans - NrOfFullTimeSpans > 0)
                    return true;
                return false;
            }
        }

        public IEnumerable<TimeRange> EachSpanRange(bool includePartial = true)
        {
            return EachSpanRange(Time_Span);
        }

        public IEnumerable<TimeRange> EachSpanRange(TimeSpan span, bool includePartial = true)
        {
            var time = this.StartTime;

            for (int i = 0; i < NrOfTimeSpans; i++)
            {
                if (i != NrOfFullTimeSpans)
                {
                    yield return new TimeRange(time, time+ Time_Span);
                }
                if (i == NrOfFullTimeSpans && includePartial)
                {
                    yield return new TimeRange(time, EndTime);
                }
                time += Time_Span;
            }

        }

        public bool Equals(TimeRange other)
        {
            if (this.StartTime == other.StartTime && this.EndTime == other.EndTime && this.Time_Span == other.Time_Span)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return new { StartTime, EndTime, Time_Span }.GetHashCode();
        }
    }
}
