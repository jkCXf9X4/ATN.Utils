using System;
using System.Collections.Generic;
using System.Text;

namespace ATN.Utils.MachineLearning.Loss
{
    public interface ILoss
    {
        double[] GetLoss(double[] expected, double[] predicted);

        double[] GetDerivates(double[] expected, double[] predicted);
    }
}
