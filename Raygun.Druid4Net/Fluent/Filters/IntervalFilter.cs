using System.Collections.Generic;

namespace Raygun.Druid4Net.Fluent.Filters
{
    public class IntervalFilter : IFilterSpec
    {
        public string Type => "interval";

        public string Dimension { get; }

        public List<string> Intervals { get; }

        public IntervalFilter(string dimension, params Interval[] intervals)
        {
            Dimension = dimension;
            Intervals = new List<string>();
            AddIntervals(intervals);
        }
        
        public IntervalFilter(string dimension, IEnumerable<Interval> intervals)
        {
            Dimension = dimension;
            Intervals = new List<string>();
            AddIntervals(intervals);
        }

        private void AddIntervals(IEnumerable<Interval> intervals)
        {
            foreach (var interval in intervals)
            {
                Intervals.Add(interval.ToInterval());
            }
        }
    }
}
