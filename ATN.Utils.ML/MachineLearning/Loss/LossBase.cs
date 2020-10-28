using ATN.Utils.CollectionsExt.EnumExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATN.Utils.MachineLearning.Loss
{
    public abstract class LossBase : ILoss
    {

        public LossBase()
        {
        }


        public double[] GetLoss(double[] expected, double[] predicted)
        {
            var values = (expected, predicted).ToTuples();

            var losses = values.Select(i => Fx(i.Item1, i.Item2)).ToArray();

            return losses;
        }

        public double[] GetDerivates(double[] expected, double[] predicted)
        {
            var values = (expected, predicted).ToTuples();

            var losses = values.Select(i => dFx(i.Item1, i.Item2)).ToArray();

            return losses;
        }

        protected abstract double Fx(double expected, double predicted);

        protected abstract double dFx(double expected, double predicted);
    }
}
