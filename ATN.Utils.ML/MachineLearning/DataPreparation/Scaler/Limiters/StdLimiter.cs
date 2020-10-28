using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Limiters
{
    [Serializable]
    public class StdLimiter : Scaler<double, double>
    {
        double RangeStandardDeviation;
        double RangeAverage;

        private SimpleLimiter limiter;
        private readonly double z;


        public StdLimiter(double z)
        {
            this.z = z;

        }

        public override void Fit(IEnumerable<double> data)
        {
            RangeAverage = data.Average();
            RangeStandardDeviation = data.StandardDeviation();

            limiter = new SimpleLimiter(
                RangeAverage - RangeStandardDeviation * this.z,
                RangeAverage + RangeStandardDeviation * this.z
                );
        }

        public override double Transform(double data)
        {
            return limiter.Transform(data);
        }

        public override string ToString()
        {
            return $"Limit: {z}, Std:{RangeStandardDeviation} Mean:{RangeAverage}";
        }

        public override double Reverse(double data)
        {
            throw new NotImplementedException();
        }
    }
}
