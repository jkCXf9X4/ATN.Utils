using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATN.Utils.MachineLearning.Loss
{
    public class SquaredError : LossBase
    {

        public SquaredError()
        {
        }


        protected override double Fx(double expected, double predicted)
        {
            var t = Math.Pow(expected -predicted, 2)/2;
            return t;
        }

        protected override double dFx(double expected, double predicted)
        {
            var t = -1 * (expected - predicted);
            return t;
        }
    }
}
