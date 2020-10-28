using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MathExt.Statistics
{
    public static class Basic
    {
        private static double StandardDeviation(List<double> numberSet, double divisor)
        {
            double mean = numberSet.Average();
            return System.Math.Sqrt(numberSet.Sum(x => (x - mean)* (x - mean)) / divisor);
        }

        public static double PopulationStandardDeviation(List<double> numberSet)
        {
            return StandardDeviation(numberSet, numberSet.Count);
        }

        public static double SampleStandardDeviation(List<double> numberSet)
        {
            return StandardDeviation(numberSet, numberSet.Count - 1);
        }

    }
}
