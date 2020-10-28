using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.DataPreparation.Scaler.Limiters
{
    [Serializable]
    public class SimpleLimiter : Scaler<double, double>
    {
        private readonly double min;
        private readonly double max;

        public SimpleLimiter(double min,double max)
        {
            this.min = min;
            this.max = max;
        }

        public override void Fit(IEnumerable<double> data)
        {
        }

        public override double Transform(double data)
        {
            if (data > this.max)
            {
                return this.max;
            }
            else if (data < min)
            {
                return min;
            }
            else
            {
                return data;
            }
        }

        public override double Reverse(double data)
        {
            throw new NotImplementedException();
        }
    }
}
